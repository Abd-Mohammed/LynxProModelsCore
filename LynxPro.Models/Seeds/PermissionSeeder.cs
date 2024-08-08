using Microsoft.EntityFrameworkCore;

namespace LynxPro.Models.Seeds
{
    public class PermissionSeeder
    {
        public static void TrySeed(LynxContext context, bool enableBackup = true)
        {
            var seededPermissionAreas = new List<PermissionArea>();
            var existingPermissionAreas = context.PermissionAreas.Include(pa => pa.Permissions).ToList();

            try
            {
                if (enableBackup)
                {
                    // Backup Roles
                    context.Database.ExecuteSqlRaw("IF OBJECT_ID('dbo.__BakRoles', 'U') IS NOT NULL DROP TABLE dbo.__BakRoles");
                    context.Database.ExecuteSqlRaw("SELECT * INTO dbo.__BakRoles FROM dbo.Roles;");

                    // Backup Permissions
                    context.Database.ExecuteSqlRaw("IF OBJECT_ID('dbo.__BakPermissions', 'U') IS NOT NULL DROP TABLE dbo.__BakPermissions");
                    context.Database.ExecuteSqlRaw("SELECT * INTO dbo.__BakPermissions FROM dbo.Permissions;");

                    // Backup Role Permissions
                    context.Database.ExecuteSqlRaw("IF OBJECT_ID('dbo.__BakRolePermissions', 'U') IS NOT NULL DROP TABLE dbo.__BakRolePermissions");
                    context.Database.ExecuteSqlRaw("SELECT * INTO dbo.__BakRolePermissions FROM dbo.RolePermissions;");

                    // Backup Permission Shortcut Links
                    context.Database.ExecuteSqlRaw("IF OBJECT_ID('dbo.__BakPermissionShortcutLinks', 'U') IS NOT NULL DROP TABLE dbo.__BakPermissionShortcutLinks");
                    context.Database.ExecuteSqlRaw("SELECT * INTO dbo.__BakPermissionShortcutLinks FROM dbo.PermissionShortcutLinks;");
                }

                context.Database.ExecuteSqlRaw("ALTER TABLE [dbo].[RolePermissions] NOCHECK CONSTRAINT ALL");
                context.Database.ExecuteSqlRaw("ALTER TABLE [dbo].[PermissionShortcutLinks] NOCHECK CONSTRAINT ALL");

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 100,
                    Description = "[[[[Administration]]]]",
                    Code = "Administration",
                    Icon = "icon-key",
                    Link = "/Administration",
                    Number = 1,
                    Permissions = new List<Permission>()
                    {
                        new Permission() { PermissionId = 100, Description = "[[[[Users]]]]", Code = "Users", Icon = "fa fa-user", Link = "/Users" },
                        new Permission() { PermissionId = 101, Description = "[[[[Roles]]]]", Code = "Roles", Icon = "fa fa-users", Link = "/Roles" },
                        new Permission() { PermissionId = 103, Description = "[[[[User Roles]]]]", Code = "UserRoles" },
                        new Permission() { PermissionId = 104, Description = "[[[[Role Permissions]]]]", Code = "RolePermissions" },
                        new Permission() { PermissionId = 105, Description = "[[[[Role Users]]]]", Code = "RoleUsers" },
                        new Permission() { PermissionId = 106, Description = "[[[[Shortcut Links]]]]", Code = "PermissionShortcutLinks", Icon = "fa fa-chain", Link = "/PermissionShortcutLinks" },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 200,
                    Description = "[[[[Management]]]]",
                    Code = "Management",
                    Icon = "fa fa-briefcase",
                    Link = "/Management",
                    Number = 2,
                    Permissions = new List<Permission>()
                    {
                   new Permission() { PermissionId = 201, Description = "[[[[Areas]]]]", Code = "Areas", Icon = "fa fa-cube", Link = "/Areas" },
                   new Permission() { PermissionId = 202, Description = "[[[[Area Groups]]]]", Code = "AreaGroups", Icon = "fa fa-cubes", Link = "/AreaGroups" },
                   new Permission() { PermissionId = 203, Description = "[[[[Vehicle Types]]]]", Code = "VehicleTypes", Icon = "fa fa-building", Link = "/VehicleTypes" },
                   new Permission() { PermissionId = 205, Description = "[[[[POI Groups]]]]", Code = "PoiGroups", Icon = "fa fa-tags", Link = "/PoiGroups" },
                   new Permission() { PermissionId = 206, Description = "[[[[POIs]]]]", Code = "Pois", Icon = "fa fa-map-marker", Link = "/Pois" },
                   new Permission() { PermissionId = 207, Description = "[[[[Pick-Ups/Drop-Offs]]]]", Code = "PudoLocations", Icon = "fa fa-map-o", Link = "/PudoLocations" },
                   new Permission() { PermissionId = 209, Description = "[[[[Device Types]]]]", Code = "DeviceTypes", Icon = "fa fa-tablet", Link = "/DeviceTypes" },
                   new Permission() { PermissionId = 209, Description = "[[[[Device Types]]]]", Code = "DeviceTypes", Icon = "fa fa-tablet", Link = "/DeviceTypes" },
                   new Permission() { PermissionId = 210, Description = "[[[[Device Type Files]]]]", Code = "DeviceTypeFiles"},
                   new Permission() { PermissionId = 211, Description = "[[[[Vehicle Franchises]]]]", Code = "VehicleFranchises", Icon = "fa fa-star", Link = "/VehicleFranchises" },
                   new Permission() { PermissionId = 213, Description = "[[[[Restricted Locations]]]]", Code = "RestrictedPudoLocations", Icon = "fa fa-bomb", Link = "/RestrictedPudoLocations" },
                   new Permission() { PermissionId = 215, Description = "[[[[Shifts]]]]", Code = "Shifts", Icon = "fa fa-calendar", Link = "/Shifts" },
               }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 300,
                    Description = "[[[[Planning]]]]",
                    Code = "Planning",
                    Icon = "fa fa-bullseye",
                    Link = "/Planning",
                    Number = 3,
                    Permissions = new List<Permission>()
                    {
                        //new Permission { Description = "[[[[Planned Jobs]]]]", Code = "PlannedJobs", Icon = "fa fa-suitcase", Link = "/PlannedJobs" },
                        //new Permission { Description = "[[[[Planned Job Details]]]]", Code = "PlannedJobDetails" },
                        // new Permission { Description = "[[[[What If Analysis]]]]", Code = "WhatIfAnalysis", Icon = "fa fa-random", Link = "/WhatIfAnalysis/Create" },
                        //new Permission { Description = "[[[[Compared Jobs]]]]", Code = "ComparedJobs" },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 400,
                    Description = "[[[[Dispatch]]]]",
                    Code = "Dispatch",
                    Icon = "fa fa-adjust",
                    Link = "/Dispatch",
                    Number = 4,
                    Permissions = new List<Permission>()
                {
                   new Permission() { PermissionId = 402, Description = "[[[[Alert Rules]]]]", Code = "AlertRules", Icon = "fa fa-bell", Link = "/AlertRules" },
                   new Permission() { PermissionId = 403, Description = "[[[[Vehicles]]]]", Code = "Vehicles", Icon = "fa fa-car", Link = "/Vehicles" },
                   new Permission() { PermissionId = 404, Description = "[[[[Vehicle Groups]]]]", Code = "VehicleGroups", Icon = "fa fa-life-ring", Link = "/VehicleGroups" },
                   new Permission() { PermissionId = 405, Description = "[[[[Drivers]]]]", Code = "Drivers", Icon = "fa fa-users", Link = "/Drivers" },
                   new Permission() { PermissionId = 406, Description = "[[[[In-Vehicle Messaging]]]]", Code = "InVehicleMessaging", Icon = "fa fa-paper-plane", Link = "/InVehicleMessaging/Send",IsFranchise=true },
                   new Permission() { PermissionId = 407, Description = "[[[[Driver Messaging]]]]", Code = "DriverMessaging", Icon = "fa fa-paper-plane-o", Link = "/DriverMessaging/Send" },
                   new Permission() { PermissionId = 408, Description = "[[[[Devices]]]]", Code = "Devices", Icon = "fa fa-tablet", Link = "/Devices" },
                   new Permission() { PermissionId = 409, Description = "[[[[Deactivated Vehicles]]]]", Code = "DeactivatedVehicles", Icon = "fa fa-car", Link = "/DeactivatedVehicles" },
                   new Permission() { PermissionId = 410, Description = "[[[[Resolution States]]]]", Code = "ResolutionStates", Icon = "fa fa-ticket", Link = "/ResolutionStates" },
                   new Permission() { PermissionId = 411, Description = "[[[[Resource Management]]]]", Code = "ResourceManagement", Icon = "fa fa-wrench", Link = "/ResourceManagement/Edit" , IsFranchise = true },
                   new Permission() { PermissionId = 414, Description = "[[[[Trk Asset Types]]]]", Code = "TrackedAssetTypes", Icon = "fa fa-database", Link = "/TrackedAssetTypes" },
                   new Permission() { PermissionId = 415, Description = "[[[[Trk Assets]]]]", Code = "TrackedAssets", Icon = "fa fa-cube", Link = "/TrackedAssets" },
                   new Permission() { PermissionId = 416, Description = "[[[[Trk Asset Groups]]]]", Code = "TrackedAssetGroups", Icon = "fa fa-cubes", Link = "/TrackedAssetGroups" },
                   new Permission() { PermissionId = 417, Description = "[[[[Multi SaaS Vehicles]]]]", Code = "MultiSaasVehicles", Icon = "fa fa-car", Link = "/MultiSaasVehicles", IsMultiSaas = true },
                   new Permission() { PermissionId = 418, Description = "[[[[Multi SaaS Tracked Assets]]]]", Code = "MultiSaasTrackedAssets", Icon = "fa fa-cube", Link = "/MultiSaasTrackedAssets", IsMultiSaas = true},
                   new Permission() { PermissionId = 419, Description = "[[[[Customers]]]]", Code = "Customers", Icon = "fa fa-street-view", Link = "/Customers" },
                   new Permission() { PermissionId = 420, Description = "[[[[Notification Rules]]]]", Code = "NotificationRules", Icon = "fa fa-users", Link = "/NotificationRules" },
                   new Permission() { PermissionId = 421, Description = "[[[[Actions]]]]", Code = "Actions", Icon = "fa fa-users", Link = "/Actions" },
                   new Permission() { PermissionId = 422, Description = "[[[[Escalation Chains]]]]", Code = "EscalationChains", Icon = "fa fa-chain", Link = "/EscalationChains" },
                   new Permission() { PermissionId = 423, Description = "[[[[Master Routes]]]]", Code = "MasterRoutes", Icon = "fa fa-road", Link = "/MasterRoutes" },
                   new Permission() { PermissionId = 426, Description = "[[[[VCR Categories]]]]", Code = "VcrCategories", Icon = "fa fa-camera-retro", Link = "/VcrCategories" },
                   new Permission() { PermissionId = 427, Description = "[[[[Device Health]]]]", Code = "DeviceHealth", Icon = "fa fa-tablet", Link = "/DeviceHealth" },
                   new Permission() { PermissionId = 428, Description = "[[[[SLA Alert Rules]]]]", Code = "SlaAlertRules", Icon = "fa fa-flask", Link = "/SlaAlertRules" },
                   new Permission() { PermissionId = 430, Description = "[[[[Vehicle Conditions]]]]", Code = "VehicleConditions", Icon = "fa fa-car", Link = "/VehicleConditions" },
                   new Permission() { PermissionId = 432, Description = "[[[[SIM Cards]]]]", Code = "SimCards", Icon = "fa fa-barcode", Link = "/SimCards" },
                   new Permission() { PermissionId = 433, Description = "[[[[Driver Groups]]]]", Code = "DriverGroups", Icon = "fa fa-user", Link = "/DriverGroups" },
                   new Permission() { PermissionId = 434, Description = "[[[[Quarantined Vehicles]]]]", Code = "QuarantinedVehicles", Icon = "fa fa-lock", Link = "/QuarantinedVehicles" },
                   new Permission() { PermissionId = 435, Description = "[[[[Alert Workflows]]]]", Code = "AlertWorkflows", Icon = "fa fa-exchange", Link = "/AlertWorkflows" }
                }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 500,
                    Description = "[[[[Fleet Administration]]]]",
                    Code = "FleetAdministration",
                    Icon = "fa fa-flag",
                    Link = "/FleetAdministration",
                    Number = 5,
                    Permissions = new List<Permission>()
                {

                   new Permission() { PermissionId = 500, Description = "[[[[Maintenance Service Types]]]]", Code = "MaintenanceServiceTypes", Icon = "fa fa-gears", Link = "/MaintenanceServiceTypes" },
                   new Permission() { PermissionId = 501, Description = "[[[[Maintenance Services]]]]", Code = "MaintenanceServices", Icon ="fa fa-wrench", Link = "/MaintenanceServices" },
                   new Permission() { PermissionId = 502, Description = "[[[[Vehicle Registrations]]]]", Code = "VehicleRegistrations", Icon ="fa fa-automobile ", Link = "/VehicleRegistrations" },
                   new Permission() { PermissionId = 503, Description = "[[[[Vehicle Accidents]]]]", Code = "VehicleAccidents", Icon ="fa fa-ambulance", Link = "/VehicleAccidents" },
                   new Permission() { PermissionId = 504, Description = "[[[[Fine Types]]]]", Code = "FineTypes", Icon = "fa fa-ticket", Link = "/FineTypes" },
                   new Permission() { PermissionId = 505, Description = "[[[[Fines]]]]", Code = "Fines", Icon = "fa fa-money", Link = "/Fines" },
               }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 600,
                    Description = "[[[[ELD]]]]",
                    Code = "Eld",
                    Icon = "fa fa-dashboard ",
                    Link = "/Eld",
                    Number = 6,
                    Permissions = new List<Permission>()
                {
                   new Permission() { PermissionId = 600, Description = "[[[[Manifests]]]]", Code = "Manifests", Icon = "fa-file-text-o", Link = "/Manifests" },
                   new Permission() { PermissionId = 601, Description = "[[[[Trailers]]]]", Code = "Trailers", Icon = "fa fa-truck", Link = "/Trailers" },
                   new Permission() { PermissionId = 602, Description = "[[[[HOS Rulesets]]]]", Code = "HosRulesets", Icon = "fa fa-recycle", Link = "/HosRulesets" },
                   new Permission() { PermissionId = 603, Description = "[[[[Vehicle Inspection Cats]]]]", Code = "VehicleInspectionCategories", Icon = "fa fa-puzzle-piece", Link = "/VehicleInspectionCategories" },
                   new Permission() { PermissionId = 604, Description = "[[[[Vehicle Inspection Defects]]]]", Code = "VehicleInspectionDefects" },
                   new Permission() { PermissionId = 605, Description = "[[[[Trailer Inspection Cats]]]]", Code = "TrailerInspectionCategories", Icon = "fa fa-ticket", Link = "/TrailerInspectionCategories" },
                   new Permission() { PermissionId = 606, Description = "[[[[Trailer Inspection Defects]]]]", Code = "TrailerInspectionDefects" },
                   new Permission() { PermissionId = 607, Description = "[[[[DVIRs]]]]", Code = "Dvirs", Icon = "fa fa-search", Link = "/Dvirs" },
                   new Permission() { PermissionId = 608, Description = "[[[[Record of Duty Status]]]]", Code = "Rodses", Icon = "fa fa-empire", Link = "/Rodses" },
                   new Permission() { PermissionId = 609, Description = "[[[[ELD Report]]]]", Code = "Report", Icon = "fa fa-file-pdf-o", Link = "/Report" },
               }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 700,
                    Description = "[[[[Transport Control]]]]",
                    Code = "TransportControl",
                    Icon = "fa fa-desktop",
                    Link = "/TransportControl",
                    Number = 7,
                    Permissions = new List<Permission>()
                    {
                       new Permission() { PermissionId = 700, Description = "[[[[Preview Progress]]]]", Code = "PreviewProgress", Icon = "fa fa-spinner", Link = "/PreviewProgress" },
                       new Permission() { PermissionId = 702, Description = "[[[[Active Alerts]]]]", Code = "ActiveAlerts", Icon = "fa fa-bell-o", Link = "/ActiveAlerts",IsFranchise = true },
                       new Permission() { PermissionId = 703, Description = "[[[[Active Alerts (Resolve)]]]]", Code = "ActiveAlerts-Resolve",IsFranchise= true},
                       new Permission() { PermissionId = 704, Description = "[[[[Active Alerts Past Stream]]]]", Code = "ActiveAlerts-PastStream",IsFranchise= true},
                       new Permission() { PermissionId = 705, Description = "[[[[Multi SaaS Active Alerts]]]]", Code = "MultiSaasActiveAlerts", Icon = "fa fa-bell-o", Link = "/MultiSaasActiveAlerts", IsMultiSaas = true },
                       new Permission() { PermissionId = 706, Description = "[[[[SaaS Active Alerts (Resolve)]]]]", Code = "SaasActiveAlerts-Resolve" , IsMultiSaas = true },
                       new Permission() { PermissionId = 708, Description = "[[[[Vehicle Run Sheets]]]]", Code = "VehicleRunSheets", Icon = "fa fa-road", Link = "/VehicleRunSheets",IsFranchise= true },
                       new Permission() { PermissionId = 714, Description = "[[[[Network Run Sheets]]]]", Code = "NetworkRunSheets", Icon = "fa fa-sun-o", Link = "/NetworkRunSheets" , IsFranchise = true },
                       new Permission() { PermissionId = 715, Description = "[[[[Situational Awareness]]]]", Code = "SituationalAwareness", Icon = "fa fa-tachometer", Link = "/SituationalAwareness",IsFranchise= true },
                       new Permission() { PermissionId = 717, Description = "[[[[Asset Situational Awareness]]]]", Code = "TrackedItemSituationalAwareness", Icon = "fa fa-crosshairs", Link = "/TrackedItemSituationalAwareness" },
                       new Permission() { PermissionId = 718, Description = "[[[[Closed Alerts]]]]", Code = "ClosedAlerts", Icon = "fa fa-bell-slash", Link = "/ClosedAlerts",IsFranchise=true },
                       new Permission() { PermissionId = 720, Description = "[[[[Vehicle Crew]]]]", Code = "VehicleCrew", Icon = "fa fa-users", Link = "/VehicleCrew" },
                       new Permission() { PermissionId = 726, Description = "[[[[Act. Vehicle Run Sheets]]]]", Code = "ActVehicleRunSheets", Icon = "fa fa-road", Link = "/ActVehicleRunSheets",IsFranchise= true },
                       new Permission() { PermissionId = 728, Description = "[[[[Act. Driver Shifts]]]]", Code = "ActDriverShifts", Icon = "fa fa-calendar", Link = "/ActDriverShifts",IsFranchise = true },
                       new Permission() { PermissionId = 729, Description = "[[[[VCRs]]]]", Code = "Vcrs", Icon = "fa fa-wrench", Link = "/Vcrs" },
                       new Permission() { PermissionId = 730, Description = "[[[[Devices Health Status]]]]", Code = "DevicesHealthStatus", Icon = "fa fa-stethoscope", Link = "/DevicesHealthStatus" },
                       new Permission() { PermissionId = 731, Description = "[[[[Shipments]]]]", Code = "Shipments", Icon = "fa fa-archive", Link = "/Shipments" },
                       new Permission() { PermissionId = 732, Description = "[[[[Alert Summary]]]]", Code = "AlertSummary"},
                       new Permission() { PermissionId = 733, Description = "[[[[New Maps (Resolve)]]]]", Code = "NewMaps-Resolve",IsFranchise= true},
                       new Permission() { PermissionId = 734, Description = "[[[[New Maps (Live Stream)]]]]", Code = "NewMaps-LiveStream",IsFranchise = true},
                       new Permission() { PermissionId = 735, Description = "[[[[New Maps (View Alert)]]]]", Code = "NewMaps-ViewAlert",IsFranchise = true},
                       new Permission() { PermissionId = 736, Description = "[[[[Maps]]]]", Code = "NewMaps", Icon = "fa fa-map-marker", Link = "/NewMaps" },
                       new Permission() { PermissionId = 737, Description = "[[[[Alert Summary (Resolve)]]]]", Code = "AlertSummary-Resolve",IsFranchise= true},
                       new Permission() { PermissionId = 739, Description = "[[[[CommandSender (Resolve)]]]]", Code = "CommandSender-Resolve",IsFranchise= false},
                       new Permission() { PermissionId = 740, Description = "[[[[Multi SaaS Vehicle Idle Times]]]]", Code = "MultiSaaSVehicleIdleTimes", Icon = "fa fa-map-marker", Link = "/MultiSaaSVehicleIdleTimes", IsMultiSaas = true},
                       new Permission() { PermissionId = 741, Description = "[[[[Cameras Health Status]]]]", Code = "VehicleCamStatus", Icon = "fa fa-camera", Link = "/VehicleCamStatus" },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 900,
                    Description = "[[[[Logs]]]]",
                    Code = "Logs",
                    Icon = "fa fa-history",
                    Link = "/Logs",
                    Number = 9,
                    Permissions = new List<Permission>()
                {
                   new Permission() { PermissionId = 900, Description = "[[[[Audit Vehicles]]]]", Code = "AuditVehicles", Icon = "fa fa-leaf", Link = "/AuditVehicles" },
                   new Permission() { PermissionId = 901, Description = "[[[[Audit Drivers]]]]", Code = "AuditDrivers", Icon = "fa fa-male", Link = "/AuditDrivers" },
                   new Permission() { PermissionId = 902, Description = "[[[[Event Notifications]]]]", Code = "EventNotifications", Icon = "fa fa-adjust", Link = "/EventNotifications" },
                   new Permission() { PermissionId = 903, Description = "[[[[Email Messages]]]]", Code = "EmailMessages", Icon = "fa fa-inbox", Link = "/EmailMessages" },
                   new Permission() { PermissionId = 904, Description = "[[[[In-Vehicle Messages]]]]", Code = "InVehicleMessages", Icon = "fa fa-envelope-o", Link = "/InVehicleMessages",IsFranchise=true },
                   new Permission() { PermissionId = 905, Description = "[[[[SMS Messages]]]]", Code = "SmsMessages", Icon = "fa fa-envelope", Link = "/SmsMessages" },
                   new Permission() { PermissionId = 906, Description = "[[[[Device Commands]]]]", Code = "DeviceCommands", Icon = "fa fa-check-circle", Link = "/DeviceCommands" },
                   new Permission() { PermissionId = 907, Description = "[[[[Alert Action Audits]]]]", Code = "AlertActionAudits", Icon = "fa fa-file-text-o", Link = "/AlertActionAudits" },
                   new Permission() { PermissionId = 908, Description = "[[[[User Action Audits]]]]", Code = "UserActionAudits", Icon = "fa fa-user", Link = "/UserActionAudits" },
                   new Permission() { PermissionId = 909, Description = "[[[[Meter Commands]]]]", Code = "MeterCommands", Icon = "fa fa-envelope", Link = "/MeterCommands" },
                   new Permission() { PermissionId = 910, Description = "[[[[Vehicle Quarantine Logs]]]]", Code = "VehicleQuarantineLogs", Icon = "fa fa-lock", Link = "/VehicleQuarantineLogs" },
               }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 1000,
                    Description = "[[[[Reporting]]]]",
                    Code = "Reporting",
                    Icon = "fa fa-database",
                    Link = "/Reporting",
                    Number = 10,
                    Permissions = new List<Permission>()
                {
                   new Permission() { PermissionId = 1002, Description = "[[[[Driver Activity Report]]]]", Code = "DriverActivityReport", Icon = "fa fa-file-text-o", Link = "/DriverActivityReport" },
                   new Permission() { PermissionId = 1003, Description = "[[[[Driver Dtl Activity Report]]]]", Code = "DriverDetailedActivityReport", Icon = "fa fa-file-text-o", Link = "/DriverDetailedActivityReport" },
                   new Permission() { PermissionId = 1004, Description = "[[[[Driver RODS Report]]]]", Code = "DriverRodsReport", Icon = "fa fa-file-text-o", Link = "/DriverRodsReport" },
                   new Permission() { PermissionId = 1005, Description = "[[[[Vehicle Activity Report]]]]", Code = "VehicleActivityReport", Icon = "fa fa-file-text-o", Link = "/VehicleActivityReport" },
                   new Permission() { PermissionId = 1008, Description = "[[[[Vehicle Report]]]]", Code = "VehicleReport", Icon = "fa fa-file-text-o", Link = "/VehicleReport" },
                   new Permission() { PermissionId = 1010, Description = "[[[[Vehicle Accident Report]]]]", Code = "VehicleAccidentReport", Icon = "fa fa-file-text-o", Link = "/VehicleAccidentReport" },
                   new Permission() { PermissionId = 1011, Description = "[[[[Vehicle Registration Report]]]]", Code = "VehicleRegistrationReport", Icon = "fa fa-file-text-o", Link = "/VehicleRegistrationReport" },
                   new Permission() { PermissionId = 1013, Description = "[[[[Trk Asset Raw Data Report]]]]", Code = "TrackedAssetRawDataReport", Icon = "fa fa-file-text-o", Link = "/TrackedAssetRawDataReport" },
                   new Permission() { PermissionId = 1014, Description = "[[[[Vehicle Alert Report]]]]", Code = "VehicleAlertReport", Icon = "fa fa-file-text-o", Link = "/VehicleAlertReport" },
                   new Permission() { PermissionId = 1015, Description = "[[[[Trk Asset Alert Report]]]]", Code = "TrackedAssetAlertReport", Icon = "fa fa-file-text-o", Link = "/TrackedAssetAlertReport" },
                   new Permission() { PermissionId = 1016, Description = "[[[[Fine Report]]]]", Code = "FineReport", Icon = "fa fa-file-text-o", Link = "/FineReport" },
                   new Permission() { PermissionId = 1017, Description = "[[[[Maintenance Service Report]]]]", Code = "MaintenanceServiceReport", Icon = "fa fa-file-text-o", Link = "/MaintenanceServiceReport" },
                   new Permission() { PermissionId = 1018, Description = "[[[[SLA Violations Report]]]]", Code = "AlertSlaReport", Icon = "fa fa-file-text-o", Link = "/AlertSlaReport" },
                   new Permission() { PermissionId = 1019, Description = "[[[[Route Heat Maps Report]]]]", Code = "RouteHeatMapsReport", Icon = "fa fa-file-text-o", Link = "/RouteHeatMapsReport" },
                   new Permission() { PermissionId = 1020, Description = "[[[[Route Summary Report]]]]", Code = "RouteSummaryReport", Icon = "fa fa-file-text-o", Link = "/RouteSummaryReport" },
                   new Permission() { PermissionId = 1021, Description = "[[[[Closed Alerts Heat Maps Report]]]]", Code = "ClosedAlertsHeatMapsReport", Icon = "fa fa-file-text-o", Link = "/ClosedAlertsHeatMapsReport" },
                   new Permission() { PermissionId = 1022, Description = "[[[[Vehicle Alert Summary Report]]]]", Code = "VehicleAlertSummaryReport", Icon = "fa fa-file-text-o", Link = "/VehicleAlertSummaryReport" },
                   new Permission() { PermissionId = 1023, Description = "[[[[Master Routes Report]]]]", Code = "MasterRoutesReport", Icon = "fa fa-file-text-o", Link = "/MasterRoutesReport" },
                   new Permission() { PermissionId = 1024, Description = "[[[[Streaming Activity Log Report]]]]", Code = "StreamingActivityLogReport", Icon = "fa fa-file-text-o", Link = "/StreamingActivityLogReport", IsMultiSaas = true },
                   new Permission() { PermissionId = 1025, Description = "[[[[Ride Report]]]]", Code = "RideReport", Icon = "fa fa-file-text-o", Link = "/RideReport"},
                   new Permission() { PermissionId = 1027, Description = "[[[[Vehicle Telemetry Report]]]]", Code = "VehicleTelemetryReport", Icon = "fa fa-file-text-o", Link = "/VehicleTelemetryReport",IsFranchise=true},
                   new Permission() { PermissionId = 1804, Description = "[[[[Meter Telemetry Report]]]]", Code = "MeterTelemetryReport", Icon = "fa fa-file-text-o", Link = "/MeterTelemetryReport",IsFranchise=true},
                   new Permission() { PermissionId = 1028, Description = "[[[[Multi SaaS Vehicle Alert Report]]]]", Code = "MultiSaasVehicleAlertReport", Icon = "fa fa-file-text-o", Link = "/MultiSaasVehicleAlertReport", IsMultiSaas = true },
                   new Permission() { PermissionId = 1029, Description = "[[[[Multi Tenant Vehicle Alert Report]]]]", Code = "MultiTenantVehicleAlertReport", Icon = "fa fa-file-text-o", Link = "/MultiTenantVehicleAlertReport", IsMultiSaas = true },
                   new Permission() { PermissionId = 1031, Description = "[[[[Driver Performance Report]]]]", Code = "DriverRidePerformanceReport", Icon = "fa fa-file-text-o", Link = "/DriverRidePerformanceReport"},
                   new Permission() { PermissionId = 1032, Description = "[[[[Multi Saas Consolidated Alert Report]]]]", Code = "MultiSaasConsolidatedAlertReport", Icon = "fa fa-file-text-o", Link = "/MultiSaasConsolidatedAlertReport", IsMultiSaas = true },
                   new Permission() { PermissionId = 1033, Description = "[[[[Multi Saas Streaming Activity Advanced Report]]]]", Code = "MultiSaasStreamingActivityAdvancedReport", Icon = "fa fa-file-text-o", Link = "/MultiSaasStreamingActivityAdvancedReport", IsMultiSaas = true },
                   new Permission() { PermissionId = 1034, Description = "[[[[Vehicle Telemetry Report Past Stream]]]]", Code = "VehicleTelemetryReport-PastStream",IsFranchise=true},
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 1100,
                    Description = "[[[[Driver Behavior]]]]",
                    Code = "DriverBehavior",
                    Icon = "fa fa-list-alt",
                    Link = "/DriverBehavior",
                    Number = 11,
                    Permissions = new List<Permission>()
                    {
                       new Permission() { PermissionId = 1101, Description = "[[[[Driver Scorecard]]]]", Code = "DriverScorecard", Icon = "fa fa-credit-card", Link = "/DriverScorecard/#/driver-scorecard" },
                       new Permission() { PermissionId = 1102, Description = "[[[[Scorecards]]]]", Code = "Scorecards", Icon = "fa fa-bell-o", Link = "/Scorecards/#/scorecards" },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 1300,
                    Description = "[[[[Fare Management]]]]",
                    Code = "FareManagement",
                    Icon = "icon-key",
                    Link = "/FareManagement",
                    Number = 13,
                    Permissions = new List<Permission>()
                {
                    new Permission() { PermissionId = 1300, Description = "[[[[Fares]]]]", Code = "Fares", Icon = "fa fa-star", Link = "/Fares" },
                    new Permission() { PermissionId = 1301, Description = "[[[[Cities]]]]", Code = "Cities", Icon = "fa fa-map-o", Link = "/Cities" },
                    new Permission() { PermissionId = 1302, Description = "[[[[Fare Schedules]]]]", Code = "FareSchedules", Icon = "fa fa-calendar-o", Link = "/FareSchedules" },
                    new Permission() { PermissionId = 1303, Description = "[[[[Promo Codes]]]]", Code = "PromoCodes", Icon = "fa fa-calendar-o", Link = "/PromoCodes" },
                    new Permission() { PermissionId = 1304, Description = "[[[[Price Estimate]]]]", Code = "PriceEstimate", Icon = "fa fa-money", Link = "/PriceEstimate" },
                    new Permission() { PermissionId = 1305, Description = "[[[[Ride Types]]]]", Code = "RideTypes", Icon = "fa fa-cubes", Link = "/RideTypes" },
                    new Permission() { PermissionId = 1306, Description = "[[[[Tolls]]]]", Code = "Tolls", Icon = "fa fa-map-o", Link = "/Tolls" },
                    new Permission() { PermissionId = 1307, Description = "[[[[Invoice Templates]]]]", Code = "InvoiceTemplates", Icon = "fa fa-cubes", Link = "/InvoiceTemplates" },
                }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 1400,
                    Description = "[[[[Ride Dispatch Center]]]]",
                    Code = "RideDispatchCenter",
                    Icon = "icon-key",
                    Link = "/RideDispatchCenter",
                    Number = 14,
                    Permissions = new List<Permission>()
                    {
                        new Permission() { PermissionId = 1400, Description = "[[[[Rides]]]]", Code = "Rides", Icon = "fa fa-road", Link = "/Rides", IsFranchise= true },
                        new Permission() { PermissionId = 1401, Description = "[[[[New Ride Request]]]]", Code = "CreateRideRequest", Icon = "fa fa-road", Link = "/CreateRideRequest" },
                        new Permission() { PermissionId = 1403, Description = "[[[[Send Meter Command]]]]", Code = "VehicleRideStatus-SendMeterCommand" , IsFranchise= true },
                        new Permission() { PermissionId = 1404, Description = "[[[[Ride Preferences]]]]", Code = "RidePreferences", Icon = "fa fa-star", Link = "/RidePreferences" },
                        new Permission() { PermissionId = 1405, Description = "[[[[Vehicle Ride Status]]]]", Code = "VehicleRideStatus", Icon = "fa fa-calendar", Link = "/VehicleRideStatus", IsFranchise = true },
                        new Permission() { PermissionId = 1406, Description = "[[[[Manual Ride Request]]]]", Code = "ManualRideRequests"},
                        new Permission() { PermissionId = 1407, Description = "[[[[Pending Meter Commands]]]]", Code = "PendingMeterCommands", Icon = "fa fa-calendar", Link = "/PendingMeterCommands" , IsFranchise=true },
                        new Permission() { PermissionId = 1408, Description = "[[[[Dtl. Completed Rides]]]]", Code = "DetailedCompletedRides", Icon = "fa fa-file-text-o", Link = "/DetailedCompletedRides" , IsFranchise=true },
                        new Permission() { PermissionId = 1409, Description = "[[[[Ride Requests]]]]", Code = "RideRequests", Icon = "fa fa-map-o", Link = "/RideRequests" , IsFranchise=true },
                        new Permission() { PermissionId = 1410, Description = "[[[[Ride Cancellation Reasons]]]]", Code = "RideCancellationReasons", Icon = "fa fa-close", Link = "/RideCancellationReasons" },
                        new Permission() { PermissionId = 1411, Description = "[[[[Ride Analytics]]]]", Code = "RideAnalytics", Icon = "fa fa-bar-chart", Link = "/RideAnalytics" ,IsFranchise = true },
                        new Permission() { PermissionId = 1412, Description = "[[[[QR Generator]]]]", Code = "QrGenerator", Icon = "fa fa-bar-chart", Link = "/QrGenerator" ,IsFranchise = true },
                        new Permission() { PermissionId = 1413, Description = "[[[[Passenger Hotspot Demand]]]]", Code = "PassengerHotspotDemand", Icon = "fa fa-envelope-o", Link = "/PassengerHotspotDemand" ,IsFranchise = true },
                        new Permission() { PermissionId = 1414, Description = "[[[[Unsettled Trips]]]]", Code = "UnsettledTrips", Icon = "fa fa-file-text-o", Link = "/TripSummary" ,IsFranchise = true },
                        new Permission() { PermissionId = 1415, Description = "[[[[Audit Logs]]]]", Code = "AuditLogs", Icon = "fa fa-pencil-square-o", Link = "/AuditLogs" ,IsFranchise = true },
                        new Permission() { PermissionId = 1416, Description = "[[[[Trip Summary]]]]", Code = "TripSummary"},
                        new Permission() { PermissionId = 1417, Description = "[[[[Suspicious Activities]]]]", Code = "SuspiciousActivities", Icon = "fa fa-pencil-square-o", Link = "/SuspiciousActivities" ,IsFranchise = true },
                        new Permission() { PermissionId = 1418, Description = "[[[[Unsettled Trips (Settle)]]]]", Code = "UnsettledTrips-Settle" ,IsFranchise = true },
                        new Permission() { PermissionId = 1419, Description = "[[[[Unsettled Trips (Delete)]]]]", Code = "UnsettledTrips-Delete" ,IsFranchise = true },
                        new Permission() { PermissionId = 1420, Description = "[[[[Unsettled Trips (Playback)]]]]", Code = "UnsettledTrips-Playback ",IsFranchise = true },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 1500,
                    Description = "[[[[Billing]]]]",
                    Code = "Billing",
                    Icon = "fa fa-money",
                    Link = "/Billing",
                    Number = 15,
                    Permissions = new List<Permission>()
                    {
                        new Permission() { PermissionId = 1500, Description = "[[[[Driver Transactions]]]]", Code = "DriverTransactions", Icon = "fa fa-exchange", Link = "/DriverTransactions" },
                        new Permission() { PermissionId = 1501, Description = "[[[[Driver Invoices]]]]", Code = "DriverInvoices", Icon = "fa fa-edit", Link = "/DriverInvoices" ,IsFranchise=true},
                        new Permission() { PermissionId = 1502, Description = "[[[[Driver Cashiering ]]]]", Code = "Cashiering", Icon = "fa fa-money", Link = "/Cashiering" },
                        new Permission() { PermissionId = 1503, Description = "[[[[Detailed Shift Invoices]]]]", Code = "DetailedShiftInvoices", Icon = "fa fa-file-text-o", Link = "/DetailedShiftInvoices",IsFranchise=true },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 1600,
                    Description = "[[[[Dispatch Management]]]]",
                    Code = "DispatchManagement",
                    Icon = "fa fa-adjust",
                    Link = "/DispatchManagement",
                    Number = 16,
                    Permissions = new List<Permission>()
                    {
                        new Permission() { PermissionId = 1600, Description = "[[[[Product Specifications]]]]", Code = "ProductSpecifications", Icon = "fa fa-exchange", Link = "/ProductSpecifications" },
                        new Permission() { PermissionId = 1601, Description = "[[[[Product Types]]]]", Code = "ProductTypes", Icon = "fa fa-cube", Link = "/ProductTypes" },
                        new Permission() { PermissionId = 1602, Description = "[[[[Products]]]]", Code = "Products", Icon = "fa fa-cube", Link = "/Products" },
                        new Permission() { PermissionId = 1603, Description = "[[[[Warehouses]]]]", Code = "Warehouses", Icon = "fa fa-cube", Link = "/Warehouses" },
                        new Permission() { PermissionId = 1604, Description = "[[[[Vehicle Type Loads]]]]", Code = "VehicleTypeLoads", Icon = "fa fa-cube", Link = "/VehicleTypeLoads" },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 1700,
                    Description = "[[[[Order & Shipment Scheduling]]]]",
                    Code = "OrderShipmentScheduling",
                    Icon = "fa fa-cubes",
                    Link = "/OrderShipmentScheduling",
                    Number = 17,
                    Permissions = new List<Permission>()
                    {
                        new Permission() { PermissionId = 1700, Description = "[[[[Orders]]]]", Code = "Orders", Icon = "fa fa-exchange", Link = "/Orders" },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 1800,
                    Description = "[[[[WASL]]]]",
                    Code = "Wasl",
                    Icon = "fa fa-cogs",
                    Link = "/Wasl",
                    Number = 18,
                    Permissions = new List<Permission>()
                    {
                        new Permission() { PermissionId = 1800, Description = "[[[[Drivers]]]]", Code = "WaslDrivers", Icon = "fa fa-users", Link = "/WaslDrivers" },
                        new Permission() { PermissionId = 1801, Description = "[[[[Vehicles]]]]", Code = "WaslVehicles", Icon = "fa fa-car", Link = "/WaslVehicles" },
                        new Permission() { PermissionId = 1802, Description = "[[[[Vehicle Historical Locations]]]]", Code = "WaslVehicleHistoricalLocations", Icon = "fa fa-tachometer", Link = "/WaslVehicleHistoricalLocations" },
                        new Permission() { PermissionId = 1803, Description = "[[[[Vehicle Live Locations]]]]", Code = "WaslVehicleLiveLocations", Icon = "fa fa-road", Link = "/WaslVehicleLiveLocations" }
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 1900,
                    Description = "[[[[Vehicle Scheduling]]]]",
                    Code = "VehicleScheduling",
                    Icon = "fa fa-bus",
                    Link = "/VehicleScheduling",
                    Number = 19,
                    Permissions = new List<Permission>()
                    {
                        new Permission() { PermissionId = 1900, Description = "[[[[Lines]]]]", Code = "Lines", Icon = "fa fa-exchange", Link = "/Lines" },
                        new Permission() { PermissionId = 1902, Description = "[[[[Vehicle Trip Run Sheets]]]]", Code = "VehicleTripRunSheets", Icon = "fa fa-road", Link = "/VehicleTripRunSheets" },
                        new Permission() { PermissionId = 1903, Description = "[[[[Route Network Maps]]]]", Code = "RouteNetworkMaps", Icon = "fa fa-map-marker", Link = "/RouteNetworkMaps" },
                        new Permission() { PermissionId = 1904, Description = "[[[[Operators]]]]", Code = "Operators", Icon = "fa fa-users", Link = "/Operators" },
                        new Permission() { PermissionId = 1905, Description = "[[[[Bookings]]]]", Code = "Bookings", Icon = "fa fa-pencil-square-o", Link = "/Bookings" },
                        new Permission() { PermissionId = 1906, Description = "[[[[Bookings Summary]]]]", Code = "BookingsSummary", Icon = "fa fa-file-text-o", Link = "/BookingsSummary" },
                        new Permission() { PermissionId = 1907, Description = "[[[[Prices]]]]", Code = "Prices", Icon = "fa fa-money", Link = "/Prices" },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 2000,
                    Description = "[[[[Device Iot]]]]",
                    Code = "DeviceIot",
                    Icon = "fa fa-fighter-jet",
                    Link = "/DeviceIot",
                    Number = 20,
                    Permissions = new List<Permission>()
                    {
                        new Permission() { PermissionId = 2000, Description = "[[[[Command Sender]]]]", Code = "CommandSender", Icon = "fa fa-fighter-jet", Link = "/CommandSender" },
                        new Permission() { PermissionId = 2001, Description = "[[[[Tracked Command Sender]]]]", Code = "TrackedCommandSender", Icon = "fa fa-fighter-jet", Link = "/TrackedCommandSender" },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea()
                {
                    PermissionAreaId = 2100,
                    Description = "[[[[Maintenance]]]]",
                    Code = "Maintenance",
                    Icon = "fa fa-wrench",
                    Link = "/Maintenance",
                    Number = 21,
                    Permissions = new List<Permission>()
                    {
                        new Permission() { PermissionId = 2101, Description = "[[[[Vendors]]]]", Code = "Vendors", Icon = "fa fa-briefcase", Link = "/Vendors" },
                    }
                });

                seededPermissionAreas.Add(new PermissionArea
                {
                    PermissionAreaId = 2200,
                    Description = "[[[[Resource Planning]]]]",
                    Code = "ResourcePlanning",
                    Icon = "fa fa-tasks",
                    Link = "/ResourcePlanning",
                    Number = 21,
                    Permissions = new List<Permission>
                    {
                        new Permission() { PermissionId = 2102, Description = "[[[[Solver Configuration]]]]", Code = "SolverConfiguration", Icon = "fa fa-cog", Link = "/SolverConfiguration" },
                    }
                });

                ValidateAll(seededPermissionAreas);

                foreach (var seededPermissionArea in seededPermissionAreas)
                {
                    AddOrUpdate(context, existingPermissionAreas, seededPermissionArea);
                }

                context.SaveChanges();
            }
            catch
            {
            }
            finally
            {
                context.Database.ExecuteSqlRaw("ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT ALL");
                context.Database.ExecuteSqlRaw("ALTER TABLE [dbo].[PermissionShortcutLinks] CHECK CONSTRAINT ALL");
            }
        }

        private static void ValidateAll(IEnumerable<PermissionArea> permissionAreas)
        {
            List<int> tempIds;
            var groups = permissionAreas.GroupBy(pa => pa.PermissionAreaId);
            if (groups.Any(g => g.Count() > 1))
            {
                throw new Exception($"Duplicated Permission Area Ids");
            }

            foreach (var permArea in permissionAreas)
            {
                tempIds = new List<int>();

                foreach (var perm in permArea.Permissions)
                {
                    if (tempIds.Contains(perm.PermissionId))
                    {
                        throw new Exception($"Duplicated Permission Id {perm.PermissionId}");
                    }

                    if (perm.PermissionId < permArea.PermissionAreaId || perm.PermissionId > (permArea.PermissionAreaId + 99))
                    {
                        throw new ArgumentOutOfRangeException($"Permission Id {perm.PermissionId} not within permission area range");
                    }

                    tempIds.Add(perm.PermissionId);
                }
            }
        }

        private static void AddOrUpdate(LynxContext context, IEnumerable<PermissionArea> existingPermissionAreas, PermissionArea permissionArea)
        {
            var existingPermissionArea = existingPermissionAreas.SingleOrDefault(pa => pa.PermissionAreaId == permissionArea.PermissionAreaId);
            if (existingPermissionArea == null)
            {
                context.PermissionAreas.Add(permissionArea);
            }
            else
            {
                foreach (var permission in permissionArea.Permissions)
                {
                    permission.PermissionAreaId = existingPermissionArea.PermissionAreaId;
                    if (!existingPermissionArea.Permissions.Any(p => p.PermissionId == permission.PermissionId))
                    {
                        context.Permissions.Add(permission);
                    }
                }
            }
        }
    }
}
