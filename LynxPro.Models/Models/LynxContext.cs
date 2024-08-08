using Audit.EntityFramework;
using Audit.EntityFramework.Providers;
using LynxPro.Models.Configurations;
using Microsoft.Azure.SqlDatabase.ElasticScale.ShardManagement;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using LynxPro.Models.Json;
using System.Linq.Expressions;

namespace LynxPro.Models
{
    [AuditDbContext(IncludeEntityObjects = true)]
    public partial class LynxContext : AuditDbContext
    {
        public string SmmDbConnectionString { get; }

        public int ShardingKey { get; internal set; }

        public List<int> FranchiseIds { get; set; }

        public int? FranchiseId { get; set; }

        public LynxContext(DbContextOptions<LynxContext> options, LynxContextOptions lynxContextOptions)
             : base(options)
        {
            Initialize();
            ShardingKey = lynxContextOptions.ShardingKey;
            FranchiseId = lynxContextOptions.FranchiseId;
            FranchiseIds = lynxContextOptions.FranchiseIds?.ToList();
            SmmDbConnectionString = lynxContextOptions.SmmDbConnectionString;
        }

        public void ChangeTenantAwareAddedOrModifiedEntries()
        {
            var addedEntries = ChangeTracker.Entries().Where(t => t.State == EntityState.Added);
            foreach (var addedEntry in addedEntries)
            {
                if (addedEntry.Entity is ITenantAware tenantAware)
                {
                    tenantAware.TenantId = ShardingKey;
                }
            }

            var modifiedEntries = ChangeTracker.Entries().Where(t => t.State == EntityState.Modified);
            foreach (var modifiedEntry in modifiedEntries)
            {
                if (modifiedEntry.Entity is ITenantAware tenantAware)
                {
                    Entry(tenantAware).Property("TenantId").IsModified = false;
                }
            }
        }

        public void ChangeFranchiseAwareAddedOrModifiedEntries()
        {
            if (!FranchiseId.HasValue) return;

            var addedEntries = ChangeTracker.Entries().Where(t => t.State == EntityState.Added);
            foreach (var addedEntry in addedEntries)
            {
                if (addedEntry.Entity is IFranchiseAware franchiseAware)
                {
                    franchiseAware.FranchiseId = FranchiseId.Value;
                }
            }

            var modifiedEntries = ChangeTracker.Entries().Where(t => t.State == EntityState.Modified);
            foreach (var modifiedEntry in modifiedEntries)
            {
                if (modifiedEntry.Entity is IFranchiseAware franchiseAware)
                {
                    Entry(franchiseAware).Property("FranchiseId").IsModified = true;
                    franchiseAware.FranchiseId = FranchiseId.Value;
                }
            }
        }

        public void ChangeFranchiseAwareEntries<T>(List<T> entityList, bool includeGraph) where T : class
        {
            if (!FranchiseId.HasValue) return;

            foreach (var entity in entityList)
            {
                if (entity is IFranchiseAware franchiseAware)
                {
                    franchiseAware.FranchiseId = FranchiseId.Value;
                }

                if (includeGraph)
                {
                    var type = entity.GetType();
                    foreach (var propertyInfo in type.GetProperties())
                    {
                        if (typeof(IFranchiseAware).IsAssignableFrom(propertyInfo.PropertyType))
                        {
                            var propertyValue = propertyInfo.GetValue(entity);
                            if (propertyValue is IFranchiseAware franchiseAwareProperty)
                            {
                                if (franchiseAwareProperty.FranchiseId == 0)
                                {
                                    franchiseAwareProperty.FranchiseId = FranchiseId.Value;
                                }
                            }
                        }
                        else if (typeof(IEnumerable<IFranchiseAware>).IsAssignableFrom(propertyInfo.PropertyType))
                        {
                            if (propertyInfo.GetValue(entity) is IEnumerable<IFranchiseAware> collectionValue)
                            {
                                foreach (var itemValue in collectionValue)
                                {
                                    itemValue.FranchiseId = FranchiseId.Value;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void ChangeTenantAwareEntries<T>(List<T> entityList, bool includeGraph) where T : class
        {
            foreach (var entity in entityList)
            {
                if (entity is ITenantAware tenantAware)
                {
                    tenantAware.TenantId = ShardingKey;
                }

                if (includeGraph)
                {
                    var type = entity.GetType();
                    foreach (var propertyInfo in type.GetProperties())
                    {
                        if (typeof(ITenantAware).IsAssignableFrom(propertyInfo.PropertyType))
                        {
                            var propertyValue = propertyInfo.GetValue(entity);
                            if (propertyValue is ITenantAware tenantAwareProperty)
                            {
                                tenantAwareProperty.TenantId = ShardingKey;
                            }
                        }
                        else if (typeof(IEnumerable<ITenantAware>).IsAssignableFrom(propertyInfo.PropertyType))
                        {
                            if (propertyInfo.GetValue(entity) is IEnumerable<ITenantAware> collectionValue)
                            {
                                foreach (var itemValue in collectionValue)
                                {
                                    itemValue.TenantId = ShardingKey;
                                }
                            }
                        }
                    }
                }
            }
        }

        public override int SaveChanges()
        {
            ChangeTenantAwareAddedOrModifiedEntries();
            ChangeFranchiseAwareAddedOrModifiedEntries();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTenantAwareAddedOrModifiedEntries();
            ChangeFranchiseAwareAddedOrModifiedEntries();

            return await base.SaveChangesAsync(cancellationToken);
        }

        public static ListShardMap<int> ShardMap()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var sharding = new Sharding(configuration);

            return sharding.ShardMap;
        }

        protected internal virtual void Initialize()
        {
            AuditDataProvider = new EntityFrameworkDataProvider(_ => _
            .AuditTypeExplicitMapper(m => m
                .Map<SimCard, ActivityLog>((evt, entry, audit) =>
                {
                    var sim = (SimCard)entry.Entity;
                    entry.CustomFields.Add("Username", sim.ModifiedBy);
                    entry.CustomFields.Add("Time", sim.ModifiedDate);

                    if (entry.Action.Equals("Insert"))
                    {
                        audit.Type = ActivityLogType.Add;
                        audit.Title = "Initial Create";
                    }
                    else if (entry.Action.Equals("Update"))
                    {
                        audit.Type = ActivityLogType.Change;
                        if (entry.Changes.Any(ch => ch.ColumnName.Equals("UsageMode")) && entry.Changes.Count == 1)
                        {
                            audit.Title = sim.Devices.Any() ? "Associated" : "Disassociated";
                        }
                        else
                        {
                            audit.Title = "Info Change";
                        }
                    }
                    else
                    {
                        audit.Type = ActivityLogType.Remove;
                        audit.Title = "Deleted";
                    }
                })
                .Map<Device, ActivityLog>((evt, entry, audit) =>
                {
                    var device = (Device)entry.Entity;
                    entry.CustomFields.Add("Username", device.ModifiedBy);
                    entry.CustomFields.Add("Time", device.ModifiedDate);

                    if (entry.Action.Equals("Insert"))
                    {
                        audit.Type = ActivityLogType.Add;
                        audit.Title = "Initial Create";
                    }
                    else if (entry.Action.Equals("Update"))
                    {
                        audit.Type = ActivityLogType.Change;
                        if (entry.Changes.Any(ch => ch.ColumnName.Equals("UsageMode")) && entry.Changes.Count == 1)
                        {
                            audit.Title = device.PrimaryVehicles.Any() || device.SecondaryVehicles.Any() ? "Associated to Vehicle" : device.TrackedItems.Any() ? "Associated to Tracked Asset" : "Disassociated";
                        }
                        else
                        {
                            audit.Title = "Info Change";
                        }
                    }
                    else
                    {
                        audit.Type = ActivityLogType.Remove;
                        audit.Title = "Deleted";
                    }
                })
                .Map<Vehicle, ActivityLog>((evt, entry, audit) =>
                {
                    var vehicle = (Vehicle)entry.Entity;
                    evt.CustomFields.Add("Username", vehicle.ModifiedBy);
                    evt.CustomFields.Add("Time", vehicle.ModifiedDate);
                    return false;
                })
                .Map<TrackedItem, ActivityLog>((evt, entry, audit) =>
                {
                    var trackedItem = (TrackedItem)entry.Entity;
                    evt.CustomFields.Add("Username", trackedItem.ModifiedBy);
                    evt.CustomFields.Add("Time", trackedItem.ModifiedDate);
                    return false;
                })
                .Map<CityFare, ActivityLog>((evt, entry, audit) =>
                {
                    if (entry.Action.Equals("Insert"))
                    {
                        audit.Type = ActivityLogType.Add;
                        audit.Title = "Initial Create";
                    }
                    else if (entry.Action.Equals("Update"))
                    {
                        audit.Type = ActivityLogType.Change;
                        audit.Title = "Info Change";
                    }
                    else
                    {
                        audit.Type = ActivityLogType.Remove;
                        audit.Title = "Deleted";
                    }

                    var cityFare = (CityFare)entry.Entity;
                    evt.CustomFields.Add("Username", cityFare.ModifiedBy);
                    evt.CustomFields.Add("Time", cityFare.ModifiedDate);
                })
                .AuditEntityAction<ActivityLog>((evt, entry, audit) =>
                {
                    var entryInput = JsonConvert.DeserializeObject<ExpandoObject>(entry.ToJson());

                    audit.EntityName = entry.Table;
                    audit.EntityKey = Convert.ToInt32(entry.PrimaryKey.Values.First());
                    audit.Time = GetDateTimeValue(evt.CustomFields) ?? GetDateTimeValue(entry.CustomFields) ?? DateTime.UtcNow;
                    audit.Username = GetUsernameValue(evt.CustomFields) ?? GetUsernameValue(entry.CustomFields) ?? "n/a";
                    audit.TenantId = ((ITenantAware)entry.Entity).TenantId;
                    audit.Details = JsonConvert.SerializeObject(entryInput, new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                }))
                .IgnoreMatchedProperties(true));

            DateTime? GetDateTimeValue(Dictionary<string, object> customFields)
            {
                return customFields.TryGetValue("DateTime", out var value) ? (DateTime)value : (DateTime?)null;
            }

            string GetUsernameValue(Dictionary<string, object> customFields)
            {
                return customFields.TryGetValue("Username", out var value) ? value.ToString() : null;
            }
        }

        private void ValidateEntities()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added || e.State == EntityState.Modified
                           select e.Entity;

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remove cascade delete convention
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Configure DateTime properties
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                                                      .SelectMany(t => t.GetProperties())
                                                      .Where(p => p.ClrType == typeof(DateTime)))
            {
                property.SetColumnType("datetime2");
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ITenantAware).IsAssignableFrom(entityType.ClrType) && entityType.BaseType == null) 
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, "TenantId");
                    var constant = Expression.Constant(ShardingKey);
                    var equality = Expression.Equal(property, constant);
                    var lambda = Expression.Lambda(equality, parameter);

                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(lambda);
                }
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, "IsDeleted");
                    var constant = Expression.Constant(false);
                    var equality = Expression.Equal(property, constant);
                    var lambda = Expression.Lambda(equality, parameter);

                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(lambda);
                }
            }


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IFranchiseAware).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, "FranchiseId");
                    var franchiseIdsConstant = Expression.Constant(FranchiseIds.ToList(), typeof(IEnumerable<int>));

                    var propertyAsNullable = Expression.Convert(property, typeof(int?));

                    var containsMethod = typeof(Enumerable).GetMethods()
                        .Single(m => m.Name == "Contains" && m.GetParameters().Length == 2)
                        .MakeGenericMethod(typeof(int));

                    var convertedProperty = Expression.Convert(property, typeof(int));

                    var franchiseIdContains = Expression.Call(
                        containsMethod,
                        franchiseIdsConstant,
                        convertedProperty
                    );

                    var nullCondition = Expression.Equal(propertyAsNullable, Expression.Constant(null, typeof(int?)));

                    var finalCondition = Expression.OrElse(franchiseIdContains, nullCondition);
                    var lambda = Expression.Lambda(finalCondition, parameter);

                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(lambda);
                }
            }


            modelBuilder.ApplyConfiguration(new ActActivityConfiguration());
            modelBuilder.ApplyConfiguration(new ActRouteConfiguration());
            modelBuilder.ApplyConfiguration(new ActShiftConfiguration());
            modelBuilder.ApplyConfiguration(new ActShiftBreakConfiguration());
            modelBuilder.ApplyConfiguration(new AlarmTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlertRuleConfiguration());
            modelBuilder.ApplyConfiguration(new AlertWorkflowConfiguration());
            modelBuilder.ApplyConfiguration(new AlertRuleActionConfiguration());
            modelBuilder.ApplyConfiguration(new AlertRuleNotifRuleConfiguration());
            modelBuilder.ApplyConfiguration(new AlertConfiguration());
            modelBuilder.ApplyConfiguration(new AlertActionAuditConfiguration());
            modelBuilder.ApplyConfiguration(new AlertActivityConfiguration());
            modelBuilder.ApplyConfiguration(new AreaGroupConfiguration());
            modelBuilder.ApplyConfiguration(new AreaItemConfiguration());
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            modelBuilder.ApplyConfiguration(new AuditVehicleConfiguration());
            modelBuilder.ApplyConfiguration(new BlobConfiguration());
            modelBuilder.ApplyConfiguration(new DriverConfiguration());
            modelBuilder.ApplyConfiguration(new DriverSettingConfiguration());
            modelBuilder.ApplyConfiguration(new DriverShiftConfiguration());
            modelBuilder.ApplyConfiguration(new DriverVehicleConfiguration());
            modelBuilder.ApplyConfiguration(new DriverGroupItemConfiguration());
            modelBuilder.ApplyConfiguration(new DriverVehicleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PoiGroupConfiguration());
            modelBuilder.ApplyConfiguration(new PoiItemConfiguration());
            modelBuilder.ApplyConfiguration(new PoiConfiguration());
            modelBuilder.ApplyConfiguration(new PudoLocationConfiguration());
            modelBuilder.ApplyConfiguration(new PudoLocationKeywordConfiguration());
            modelBuilder.ApplyConfiguration(new RestrictedPudoLocationConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new SmsMessageConfiguration());
            modelBuilder.ApplyConfiguration(new GprsMessageConfiguration());
            modelBuilder.ApplyConfiguration(new TmcEventConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserSettingConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleFranchiseConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleStateConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleItemConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleGroupConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionShortcutLinkConfiguration());
            modelBuilder.ApplyConfiguration(new EventNotificationRuleConfiguration());
            modelBuilder.ApplyConfiguration(new EventNotificationConfiguration());
            modelBuilder.ApplyConfiguration(new PushNotificationRuleConfiguration());
            modelBuilder.ApplyConfiguration(new SmsNotificationRuleConfiguration());
            modelBuilder.ApplyConfiguration(new EmailNotificationRuleConfiguration());
            modelBuilder.ApplyConfiguration(new EscalationRuleNotifRuleConfiguration());
            modelBuilder.ApplyConfiguration(new EscalationRuleActionConfiguration());
            modelBuilder.ApplyConfiguration(new CrewMemberVehicleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CrewMemberShiftConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleCrewMemberConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceHealthAlertRuleConfiguration());
            modelBuilder.ApplyConfiguration(new AlertRuleTagConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityLogConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceMessageConfiguration());
            modelBuilder.ApplyConfiguration(new ActiveAlertConfiguration());
            modelBuilder.ApplyConfiguration(new ActiveAlertBlobConfiguration());
            modelBuilder.ApplyConfiguration(new ActiveAlertActivityConfiguration());
            modelBuilder.ApplyConfiguration(new RideConfiguration());
            modelBuilder.ApplyConfiguration(new RideTypeVehicleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RideRequestConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerDeviceInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerPhoneVerificationConfiguration());
            modelBuilder.ApplyConfiguration(new CityFareConfiguration());
            modelBuilder.ApplyConfiguration(new PromoCodeConfiguration());
            modelBuilder.ApplyConfiguration(new PromoCodeUsageConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleRideStateConfiguration());
            modelBuilder.ApplyConfiguration(new TollConfiguration());
            modelBuilder.ApplyConfiguration(new CityFareExtraChargeConfiguration());
            modelBuilder.ApplyConfiguration(new CityFareTransitConfiguration());
            modelBuilder.ApplyConfiguration(new FareMeterCommandConfiguration());
            modelBuilder.ApplyConfiguration(new DriverRideStatisticsConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreMetricConfiguration());
            modelBuilder.ApplyConfiguration(new DriverBalanceConfiguration());
            modelBuilder.ApplyConfiguration(new DriverInvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new DriverTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new DirectionsRouteConfiguration());
            modelBuilder.ApplyConfiguration(new DirectionsActivityConfiguration());
            modelBuilder.ApplyConfiguration(new DvirConfiguration());
            modelBuilder.ApplyConfiguration(new DriverHosConfiguration());
            modelBuilder.ApplyConfiguration(new ManifestConfiguration());
            modelBuilder.ApplyConfiguration(new RodsConfiguration());
            modelBuilder.ApplyConfiguration(new HosRulesetConfiguration());
            modelBuilder.ApplyConfiguration(new HosStatusConfiguration());
            modelBuilder.ApplyConfiguration(new TrailerConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleHosConfiguration());
            modelBuilder.ApplyConfiguration(new TrackedItemConfiguration());
            modelBuilder.ApplyConfiguration(new TrackedItemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TrackedItemGroupConfiguration());
            modelBuilder.ApplyConfiguration(new TrackedItemItemConfiguration());
            modelBuilder.ApplyConfiguration(new TrackedItemCrumbConfiguration());
            modelBuilder.ApplyConfiguration(new TrackedItemStateConfiguration());
            modelBuilder.ApplyConfiguration(new TenantSettingConfiguration());
            modelBuilder.ApplyConfiguration(new TenantJobConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInventoryConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleTypeLoadConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderLineConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry01Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry02Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry03Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry04Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry05Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry06Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry07Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry08Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry09Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry10Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry11Configuration());
            modelBuilder.ApplyConfiguration(new VehicleTelemetry12Configuration());
            modelBuilder.ApplyConfiguration(new VehicleQuarantineConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleQuarantineLogConfiguration());
        }
    }
}