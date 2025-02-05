﻿using Microsoft.EntityFrameworkCore;

namespace LynxPro.Models
{
    public partial class LynxContext
    {
        public DbSet<Action> Actions { get; set; }
        public DbSet<ActShiftBreak> ActShiftBreaks { get; set; }
        public DbSet<ApiManager> ApiManagers { get; set; }
        public DbSet<ApiService> ApiServices { get; set; }
        public DbSet<AlarmType> AlarmTypes { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<AlertRule> AlertRules { get; set; }
        public DbSet<AlertRuleNotificationRule> AlertRuleNotificationRules { get; set; }
        public DbSet<AlertBlob> AlertBlobs { get; set; }
        public DbSet<AlertRuleAction> AlertRuleActions { get; set; }
        public DbSet<AreaGroup> AreaGroups { get; set; }
        public DbSet<AreaItem> AreaItems { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AuditSolution> AuditSolutions { get; set; }
        public DbSet<AuditVehicle> AuditVehicles { get; set; }
        public DbSet<AuditDriver> AuditDrivers { get; set; }
        public DbSet<Blob> Blobs { get; set; }
        public DbSet<BlobStorage> BlobStorages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDeviceInfo> CustomerDeviceInfoes { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerPhoneVerification> CustomerPhoneVerifications { get; set; }
        public DbSet<DeviceCommand> DeviceCommands { get; set; }
        public DbSet<DeviceMessage> DeviceMessages { get; set; }
        public DbSet<DriverShift> DriverShifts { get; set; }
        public DbSet<EventNotification> EventNotifications { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<DirectionsActivity> DirectionsActivities { get; set; }
        public DbSet<DirectionsRoute> DirectionsRoutes { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverSetting> DriverSettings { get; set; }
        public DbSet<EmailMessage> EmailMessages { get; set; }
        public DbSet<EmailNotificationRule> EmailNotificationRules { get; set; }
        public DbSet<PushNotificationRule> PushNotificationRules { get; set; }
        public DbSet<NotificationRule> NotificationRules { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PermissionArea> PermissionAreas { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionShortcutLink> PermissionShortcutLinks { get; set; }
        public DbSet<PlannedJob> PlannedJobs { get; set; }
        public DbSet<PoiGroup> PoiGroups { get; set; }
        public DbSet<PoiItem> PoiItems { get; set; }
        public DbSet<Poi> Pois { get; set; }
        public DbSet<PudoLocation> PudoLocations { get; set; }
        public DbSet<PudoLocationKeyword> PudoLocationKeywords { get; set; }
        public DbSet<RestrictedPudoLocation> RestrictedPudoLocations { get; set; }
        public DbSet<ResolutionState> ResolutionStates { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<SmsMessage> SmsMessages { get; set; }
        public DbSet<GprsMessage> GprsMessages { get; set; }
        public DbSet<SmsNotificationRule> SmsNotificationRules { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleFranchise> VehicleFranchises { get; set; }
        public DbSet<VehicleState> VehicleStates { get; set; }
        public DbSet<VehicleRideState> VehicleRideStates { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleGroup> VehicleGroups { get; set; }
        public DbSet<VehicleItem> VehicleItems { get; set; }
        public DbSet<VehicleEvent> VehicleEvents { get; set; }
        public DbSet<VehicleCrewMember> VehicleCrewMembers { get; set; }
        public DbSet<VehiclePeripheral> VehiclePeripherals { get; set; }
        public DbSet<FineType> FineTypes { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<MaintenanceServiceType> MaintenanceServiceTypes { get; set; }
        public DbSet<MaintenanceService> MaintenanceServices { get; set; }
        public DbSet<MaintenanceServicePart> MaintenanceServiceParts { get; set; }
        public DbSet<VehicleAccident> VehicleAccidents { get; set; }
        public DbSet<VehicleRegistration> VehicleRegistrations { get; set; }
        public DbSet<EscalationChain> EscalationChains { get; set; }
        public DbSet<EscalationRule> EscalationRules { get; set; }
        public DbSet<EscalationRuleNotificationRule> EscalationRuleNotificationRules { get; set; }
        public DbSet<EscalationRuleAction> EscalationRuleActions { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<CrewMember> CrewMembers { get; set; }
        public DbSet<CrewMemberShift> CrewMemberShifts { get; set; }
        public DbSet<CrewMemberVehicleType> CrewMemberVehicleTypes { get; set; }
        public DbSet<IncidentType> Incidents { get; set; }
        public DbSet<VcrCategory> VcrCategories { get; set; }
        public DbSet<Vcr> Vcrs { get; set; }
        public DbSet<VcrDefect> VcrDefects { get; set; }
        public DbSet<MasterRoute> MasterRoutes { get; set; }
        public DbSet<DeviceHealth> DeviceHealths { get; set; }
        public DbSet<DeviceHealthAlertRule> DeviceHealthAlertRules { get; set; }
        public DbSet<AlertRulePeriod> AlertRulePeriods { get; set; }
        public DbSet<ExternalDataType> ExternalDataTypes { get; set; }
        public DbSet<ExternalDataItem> ExternalDataItems { get; set; }
        public DbSet<ActCrewMemberShift> ActCrewMemberShifts { get; set; }
        public DbSet<AlertActionAudit> AlertActionAudits { get; set; }
        public DbSet<UserActionAudit> UserActionAudits { get; set; }
        public DbSet<AlertRuleTag> AlertRuleTags { get; set; }
        public DbSet<AlertComment> AlertComments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AlertActivity> AlertActivities { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<VehicleCondition> VehicleConditions { get; set; }
        public DbSet<ScoreCard> ScoreCards { get; set; }
        public DbSet<ScoreMetric> ScoreMetrics { get; set; }
        public DbSet<DriverGroup> DriverGroups { get; set; }
        public DbSet<DriverGroupItem> DriverGroupItems { get; set; }
        public DbSet<ActiveAlert> ActiveAlerts { get; set; }
        public DbSet<ActiveAlertActivity> ActiveAlertActivities { get; set; }
        public DbSet<ActiveAlertBlob> ActiveAlertBlobs { get; set; }
        public DbSet<Dvir> Dvirs { get; set; }
        public DbSet<DriverHos> DriverHoses { get; set; }
        public DbSet<Manifest> Manifests { get; set; }
        public DbSet<HosRuleset> HosRulesets { get; set; }
        public DbSet<HosStatus> HosStatuses { get; set; }
        public DbSet<Rods> Rodses { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<VehicleHos> VehicleHoses { get; set; }
        public DbSet<TrailerInspectionCategory> TrailerInspectionCategories { get; set; }
        public DbSet<TrailerInspectionDefect> TrailerInspectionDefects { get; set; }
        public DbSet<TenantResource> TenantResources { get; set; }
        public DbSet<VehicleInspectionCategory> VehicleInspectionCategories { get; set; }
        public DbSet<VehicleInspectionDefect> VehicleInspectionDefects { get; set; }
        public DbSet<TrackedItemCrumb> TrackedItemCrumbs { get; set; }
        public DbSet<TrackedItem> TrackedItems { get; set; }
        public DbSet<TrackedItemType> TrackedItemTypes { get; set; }
        public DbSet<TrackedItemGroup> TrackedItemGroups { get; set; }
        public DbSet<TrackedItemItem> TrackedItemItems { get; set; }
        public DbSet<TrackedItemState> TrackedItemStates { get; set; }
        public DbSet<TenantSetting> TenantSettings { get; set; }
        public DbSet<TenantArchivingPolicy> TenantArchivingPolicies { get; set; }
        public DbSet<TenantJob> TenantJobs { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Addon> Addons { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<FareSchedule> FareSchedules { get; set; }
        public DbSet<FareSchedulePeriod> FareSchedulePeriods { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CityFare> CityFares { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<PromoCodeUsage> PromoCodeUsages { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<RideType> RideTypes { get; set; }
        public DbSet<RideTypeVehicleType> RideTypeVehicleTypes { get; set; }
        public DbSet<RideRequest> RideRequests { get; set; }
        public DbSet<RideCancelReason> RideCancelReasons { get; set; }
        public DbSet<RidePreference> RidePreferences { get; set; }
        public DbSet<TenantCurrency> TenantCurrencies { get; set; }
        public DbSet<CityFareExtraCharge> CityFareExtraCharges { get; set; }
        public DbSet<Toll> Tolls { get; set; }
        public DbSet<CityFareTransit> CityFareTransits { get; set; }
        public DbSet<FareMeterCommand> FareMeterCommands { get; set; }
        public DbSet<RideInvoiceTemplate> RideInvoiceTemplates { get; set; }
        public DbSet<DriverRideStatistics> DriverRideStatistics { get; set; }

        // Billing
        public DbSet<DriverBalance> DriverBalances { get; set; }
        public DbSet<DriverTransaction> DriverTransactions { get; set; }
        public DbSet<DriverInvoice> DriverInvoices { get; set; }

        // Dispatch and Job Scheduling
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<VehicleTypeLoad> VehicleTypeLoads { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<ExportTask> ExportTasks { get; set; }

        //VehicleTelemetriesPartitions
        public DbSet<VehicleTelemetryPartition01> VehicleTelemetryPartition01 { get; set; }
        public DbSet<VehicleTelemetryPartition02> VehicleTelemetryPartition02 { get; set; }
        public DbSet<VehicleTelemetryPartition03> VehicleTelemetryPartition03 { get; set; }
        public DbSet<VehicleTelemetryPartition04> VehicleTelemetryPartition04 { get; set; }
        public DbSet<VehicleTelemetryPartition05> VehicleTelemetryPartition05 { get; set; }
        public DbSet<VehicleTelemetryPartition06> VehicleTelemetryPartition06 { get; set; }
        public DbSet<VehicleTelemetryPartition07> VehicleTelemetryPartition07 { get; set; }
        public DbSet<VehicleTelemetryPartition08> VehicleTelemetryPartition08 { get; set; }
        public DbSet<VehicleTelemetryPartition09> VehicleTelemetryPartition09 { get; set; }
        public DbSet<VehicleTelemetryPartition10> VehicleTelemetryPartition10 { get; set; }
        public DbSet<VehicleTelemetryPartition11> VehicleTelemetryPartition11 { get; set; }
        public DbSet<VehicleTelemetryPartition12> VehicleTelemetryPartition12 { get; set; }
    }
}