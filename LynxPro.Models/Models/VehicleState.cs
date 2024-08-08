using LynxPro.Models.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxPro.Models
{
    public enum OdometerSource
    {
        [Display(Name = "Physical")]
        Physical = 1,
        [Display(Name = "Virtual")]
        Virtual = 2
    }

    public enum SpeedSource
    {
        [Display(Name = "Physical")]
        Physical = 1,
        [Display(Name = "Virtual")]
        Virtual = 2
    }

    //TODO: Document will replace other JSON properties later
    public class VehicleState : TenantAware, ITenantAware, IFranchiseAware, ISoftDelete
    {
        public int VehicleId { get; set; }

        public int FranchiseId { get; set; }

        [Display(Name = "Time Stamp", Description = "Vehicle Time Stamp")]
        public DateTime TimeStamp { get; set; }

        [Display(Name = "Previous Latitude", Description = "Vehicle Previous Latitude")]
        public double PrevLatitude { get; set; }

        [Display(Name = "Previous Longitude", Description = "Vehicle Previous Longitude")]
        public double PrevLongitude { get; set; }

        [Display(Name = "Latitude", Description = "Vehicle Latitude")]
        public double Latitude { get; set; }

        [Display(Name = "Longitude", Description = "Vehicle Longitude")]
        public double Longitude { get; set; }

        [Display(Name = "Altitude (m)", Description = "Vehicle Altitude (m)")]
        public double Altitude { get; set; }

        [Display(Name = "Angle", Description = "Vehicle Angle")]
        public double Angle { get; set; }

        [Display(Name = "Speed (km/h)", Description = "Vehicle Speed")]
        public double Speed { get; set; }

        [Display(Name = "Virtual Speed  (km/h)", Description = "Vehicle Virtual Speed ")]
        public double VirtualSpeed { get; set; }

        [Display(Name = "Temperature", Description = "Vehicle Temperature")]
        public double? Temperature { get; set; }

        [Display(Name = "HDOP", Description = "Vehicle HDOP")]
        public double? Hdop { get; set; }

        [Display(Name = "Is Prev Engine On", Description = "Is Vehicle Prev Engine On")]
        public bool? IsPrevEngineOn { get; set; }

        [Display(Name = "Is Engine On", Description = "Is Vehicle Engine On")]
        public bool? IsEngineOn { get; set; }

        [Display(Name = "Virtual Odometer (m)", Description = "Vehicle Virtual Odometer (m)")]
        public long VirtualOdometer { get; set; }

        [Display(Name = "Satellites No", Description = "Vehicle Satellites No")]
        public int SatellitesNo { get; set; }

        [Display(Name = "GSM Signal", Description = "Vehicle GSM Signal")]
        public int? GsmSignal { get; set; }

        [Display(Name = "GSM Operator", Description = "Vehicle GSM Operator")]
        public string GsmOperator { get; set; }

        [Display(Name = "Power Supply Voltage (V)", Description = "Vehicle Power Supply Voltage (V)")]
        public double? PowerSupplyVoltage { get; set; }

        [Display(Name = "Battery Voltage (V)", Description = "Device Battery Voltage (V)")]
        public double? BatteryVoltage { get; set; }

        [Display(Name = "Passengers No", Description = "Vehicle Passengers No")]
        public int PassengersNo { get; set; }

        [Display(Name = "Shipments No", Description = "Vehicle Shipments No")]
        public int ShipmentsNo { get; set; }

        [Display(Name = "Weight", Description = "Vehicle Weight")]
        public int Weight { get; set; }

        [Display(Name = "Volume", Description = "Vehicle Volume")]
        public int Volume { get; set; }

        [Display(Name = "Payload", Description = "Vehicle Payload")]
        public double Payload { get; set; }

        /// <summary>
        /// Previous vehicle idling time
        /// </summary>
        [Display(Name = "Prev Idling Time (sec)", Description = "Vehicle Prev Idling Time (sec)")]
        public int PrevIdlingTime { get; set; }

        /// <summary>
        /// Current vehicle idling time
        /// </summary>
        [Display(Name = "Idling Time (sec)", Description = "Vehicle Idling Time (sec)")]
        public int IdlingTime { get; set; }

        /// <summary>
        /// Cumulative odometer read of vehicle
        /// </summary>
        [Display(Name = "Odometer (m)", Description = "Vehicle Odometer (m)")]
        public long Odometer { get; set; }

        [Display(Name = "Odometer Source", Description = "Vehicle Odometer Source")]
        public OdometerSource OdometerSource { get; set; }

        [NotMapped]
        [Display(Name = "Speed Source", Description = "Vehicle Speed Source")]
        public SpeedSource SpeedSource
        {
            get
            {
                return PhysicalSpeed.HasValue ? SpeedSource.Physical : SpeedSource.Virtual;
            }
        }

        /// <summary>
        /// Cumulative engine hours read of vehicle
        /// </summary>
        [Display(Name = "Engine Hours", Description = "Vehicle Engine Hours")]
        public double EngineHours { get; set; }

        /// <summary>
        /// Previous bit mask value of digintal inputs
        /// </summary>
        [Display(Name = "Prev DIN", Description = "Vehicle Prev DIN")]
        public Din? PrevDin { get; set; }

        /// <summary>
        /// Current bit mask value of digintal inputs
        /// </summary>
        [Display(Name = "DIN", Description = "Vehicle DIN")]
        public Din? Din { get; set; }

        /// <summary>
        /// Current AIN 01
        /// </summary>
        [Display(Name = "AIN 01 (V)", Description = "Vehicle AIN 01 (V)")]
        public double? Ain01 { get; set; }

        /// <summary>
        /// Current AIN 02
        /// </summary>
        [Display(Name = "AIN 02 (V)", Description = "Vehicle AIN 02 (V)")]
        public double? Ain02 { get; set; }

        // Overspeeding properties

        [Display(Name = "Prev Overspeeding Event", Description = "Vehicle Prev Overspeeding Event")]
        public bool? PrevOverspeedingEvent { get; set; }

        [Display(Name = "Overspeeding Event", Description = "Vehicle Overspeeding Event")]
        public bool? OverspeedingEvent { get; set; }

        [Display(Name = "Overspeeding Duration", Description = "Vehicle Overspeeding Duration")]
        public int? OverspeedingDuration { get; set; }

        [Display(Name = "Overspeeding Peak Value (km/h)", Description = "Vehicle Overspeeding Peak Value (km/h)")]
        public double? OverspeedingPeakValue { get; set; }

        [Display(Name = "Overspeeding Time Stamp", Description = "Vehicle Overspeeding Time Stamp")]
        public DateTime? OverspeedingTimeStamp { get; set; }

        // Harsh Acceleration properties

        [Display(Name = "Prev Harsh Acceleration Event", Description = "Vehicle Prev Harsh Acceleration Event")]
        public bool? PrevHarshAccelerationEvent { get; set; }

        [Display(Name = "Harsh Acceleration Event", Description = "Vehicle Harsh Acceleration Event")]
        public bool? HarshAccelerationEvent { get; set; }

        [Display(Name = "Harsh Acceleration Duration", Description = "Vehicle Harsh Acceleration Duration")]
        public int? HarshAccelerationDuration { get; set; }

        [Display(Name = "Harsh Acceleration Peak Value (g)", Description = "Vehicle Harsh Acceleration Peak Value (g)")]
        public double? HarshAccelerationPeakValue { get; set; }

        [Display(Name = "Harsh Acceleration DFB Speed (km/h)", Description = "Vehicle Harsh Acceleration DFB Speed (km/h)")]
        public double? HarshAccelerationDfbSpeed { get; set; }

        [Display(Name = "Harsh Acceleration Time Stamp", Description = "Vehicle Harsh Acceleration Time Stamp")]
        public DateTime? HarshAccelerationTimeStamp { get; set; }

        // Harsh Braking properties

        [Display(Name = "Prev Harsh Braking Event", Description = "Vehicle Prev Harsh Braking Event")]
        public bool? PrevHarshBrakingEvent { get; set; }

        [Display(Name = "Harsh Braking Event", Description = "Vehicle Harsh Braking Event")]
        public bool? HarshBrakingEvent { get; set; }

        [Display(Name = "Harsh Braking Duration", Description = "Vehicle Harsh Braking Duration")]
        public int? HarshBrakingDuration { get; set; }

        [Display(Name = "Harsh Acceleration Peak Value (g)", Description = "Vehicle Harsh Acceleration Peak Value (g)")]
        public double? HarshBrakingPeakValue { get; set; }

        [Display(Name = "Harsh Braking DFB Speed (km/h)", Description = "Vehicle Harsh Braking DFB Speed (km/h)")]
        public double? HarshBrakingDfbSpeed { get; set; }

        [Display(Name = "Harsh Braking Time Stamp", Description = "Vehicle Harsh Braking Time Stamp")]
        public DateTime? HarshBrakingTimeStamp { get; set; }

        // Harsh Cornering properties

        [Display(Name = "Prev Harsh Cornering Event", Description = "Vehicle Prev Harsh Cornering Event")]
        public bool? PrevHarshCorneringEvent { get; set; }

        [Display(Name = "Harsh Cornering Event", Description = "Vehicle Harsh Cornering Event")]
        public bool? HarshCorneringEvent { get; set; }

        [Display(Name = "Harsh Braking Duration", Description = "Vehicle Harsh Cornering Duration")]
        public int? HarshCorneringDuration { get; set; }

        [Display(Name = "Harsh Acceleration Peak Value (g)", Description = "Vehicle Harsh Acceleration Peak Value (g)")]
        public double? HarshCorneringPeakValue { get; set; }

        [Display(Name = "Harsh Cornering DFB Speed (km/h)", Description = "Vehicle Harsh Cornering DFB Speed (km/h)")]
        public double? HarshCorneringDfbSpeed { get; set; }

        [Display(Name = "Harsh Cornering Time Stamp", Description = "Vehicle Harsh Cornering Time Stamp")]
        public DateTime? HarshCorneringTimeStamp { get; set; }

        [Display(Name = "X Acceleration (g)", Description = "Vehicle X Acceleration (g)")]
        public double? XAcceleration { get; set; }

        [Display(Name = "Y Acceleration (g)", Description = "Vehicle Y Acceleration (g)")]
        public double? YAcceleration { get; set; }

        [Display(Name = "Z Acceleration (g)", Description = "Vehicle Z Acceleration (g)")]
        public double? ZAcceleration { get; set; }

        [Display(Name = "Location Status", Description = "Vehicle Location Status")]
        public bool? LocationStatus { get; set; }

        /// <summary>
        /// Module of accelerometer vector
        /// </summary>
        [Display(Name = "Absolute Acceleration (g)", Description = "Vehicle Absolute Acceleration (g)")]
        public double? AbsoluteAcceleration { get; set; }

        /// <summary>
        /// The registered time when vehicle started idling, this will be reset to NULL when
        /// idling is finished
        /// </summary>
        [Display(Name = "Idling Start Time", Description = "Vehicle Idling Start Time")]
        public DateTime? IdlingStartTime { get; set; }

        /// <summary>
        /// The registered odometer when vehicle started idling, this will be reset to NULL when
        /// idling is finished
        /// </summary>
        [Display(Name = "Idling Start Odometer", Description = "Vehicle Idling Start Odometer")]
        public long? IdlingStartOdometer { get; set; }

        /// <summary>
        /// The registered engine hours when vehicle started idling, this will be reset to NULL when
        /// idling is finished
        /// </summary>
        [Display(Name = "Idling Start Engine Hours", Description = "Vehicle Idling Start Engine Hours")]
        public double? IdlingStartEngineHours { get; set; }

        /// <summary>
        /// The registered latitude when vehicle started idling, this will be reset to NULL when
        /// idling is finished
        /// </summary>
        [Display(Name = "Idling Start Latitude", Description = "Vehicle Idling Start Latitude")]
        public double? IdlingStartLatitude { get; set; }

        /// <summary>
        /// The registered longitude when vehicle started idling, this will be reset to NULL when
        /// idling is finished
        /// </summary>
        [Display(Name = "Idling Start Longitude", Description = "Vehicle Idling Start Longitude")]
        public double? IdlingStartLongitude { get; set; }

        [Display(Name = "Virtual Segment Distance (m)", Description = "Vehicle Virtual Segment Distance (m)")]
        public long VirtualSegmentDistance { get; set; }

        [Display(Name = "Physical Segment Distance (m)", Description = "Vehicle Physical Segment Distance (m)")]
        public long? PhysicalSegmentDistance { get; set; }

        /// <summary>
        /// Traveled distance between previous data and current data
        /// </summary>
        [Display(Name = "Segment Distance (m)", Description = "Vehicle Segment Distance (m)")]
        public long SegmentDistance { get; set; }

        /// <summary>
        /// Current active onboard driver on the vehicle
        /// </summary>
        [Display(Name = "Driver", Description = "Vehicle Driver Id")]
        public int? DriverId { get; set; }

        /// <summary>
        /// Current active shift on the vehicle
        /// </summary>
        [Display(Name = "Shift", Description = "Vehicle Shift Id")]
        public int? ActShiftId { get; set; }

        /// <summary>
        /// Progress difference between estimated and actual i.e. departure time
        /// </summary>
        [Display(Name = "Progress Diff (sec)", Description = "Vehicle Progress Diff (sec)")]
        public double? ProgressDiff { get; set; }

        [Display(Name = "Directions Route Id", Description = "Vehicle Directions Route Id")]
        public int? DirectionsRouteId { get; set; }

        [Display(Name = "Act Route Id", Description = "Vehicle Act Route Id")]
        public int? ActRouteId { get; set; }

        [Display(Name = "Open Critical Alerts Count", Description = "Vehicle Open Critical Alerts Count")]
        public int OpenCriticalAlertsCount { get; set; }

        [Display(Name = "Open Warning Alerts Count", Description = "Vehicle Open Warning Alerts Count")]
        public int OpenWarningAlertsCount { get; set; }

        [Display(Name = "Open Information Alerts Count", Description = "Vehicle Open Information Alerts Count")]
        public int OpenInformationAlertsCount { get; set; }

        [Display(Name = "Open Alerts Count", Description = "Vehicle Open Alerts Count")]
        public int OpenAlertsCount { get; set; }

        [Display(Name = "Has No GPS Signal", Description = "Vehicle Has No GPS Signal")]
        public bool HasNoGpsSignal { get; set; }

        [Display(Name = "Lat Lng Duplicate Count", Description = "Vehicle Lat Lng Duplicate Count")]
        public int LatLngDuplicateCount { get; set; }

        // Extra I/O data
        [Display(Name = "DTC Count", Description = "Vehicle DTC Count")]
        public int? DtcCount { get; set; }

        [Display(Name = "Physical Speed (km/h)", Description = "Vehicle Physical Speed (km/h)")]
        public double? PhysicalSpeed { get; set; }

        [Display(Name = "Physical Odometer (m)", Description = "Vehicle Physical Odometer (m)")]
        public long? PhysicalOdometer { get; set; }

        [Display(Name = "Fuel Used GPS (ml)", Description = "Vehicle Fuel Used GPS (ml)")]
        public int? FuelUsedGps { get; set; }

        [Display(Name = "Fuel Rate GPS(%)", Description = "Vehicle Fuel Rate GPS(%)")]
        public int? FuelRateGps { get; set; }

        [Display(Name = "Engine Load(%)", Description = "Vehicle Engine Load(%)")]
        public double? EngineLoad { get; set; }

        [Display(Name = "Engine Coolant Temperature (C)", Description = "Vehicle Engine Coolant Temperature (C)")]
        public double? EngineCoolantTemperature { get; set; }

        [Display(Name = "Fuel Pressure (kPa)", Description = "Vehicle Fuel Pressure (kPa)")]
        public double? FuelPressure { get; set; }

        [Display(Name = "Engine RPM (rpm)", Description = "Vehicle Engine RPM (rpm)")]
        public double? EngineRpm { get; set; }

        [Display(Name = "Intake Air Temperature (C)", Description = "Vehicle Intake Air Temperature (C)")]
        public double? IntakeAirTemperature { get; set; }

        [Display(Name = "MAF Air Flow Rate (g/sec)", Description = "Vehicle MAF Air Flow Rate (g/sec)")]
        public double? MafAirFlowRate { get; set; }

        [Display(Name = "Throttle Position(%)", Description = "Vehicle Throttle Position(%)")]
        public double? ThrottlePosition { get; set; }

        [Display(Name = "Engine Runtime Since Start (s)", Description = "Vehicle Engine Runtime Since Start (s)")]
        public long? EngineRuntimeSinceStart { get; set; }

        [Display(Name = "Commanded EGR(%)", Description = "Vehicle Commanded EGR(%)")]
        public double? CommandedEgr { get; set; }

        [Display(Name = "Fuel Level(%)", Description = "Vehicle Fuel Level(%)")]
        public double? FuelLevel { get; set; }

        [Display(Name = "Fuel Volume (L)", Description = "Vehicle Fuel Volume (L)")]
        public double? FuelVolume { get; set; }

        [Display(Name = "Barometric Pressure (kPa)", Description = "Vehicle Barometric Pressure (kPa)")]
        public double? BarometricPressure { get; set; }

        [Display(Name = "Ambient Air Temperature (C)", Description = "Vehicle Ambient Air Temperature (C)")]
        public double? AmbientAirTemperature { get; set; }

        [Display(Name = "Engine Oil Temperature (C)", Description = "Vehicle Engine Oil Temperature (C)")]
        public double? EngineOilTemperature { get; set; }

        [Display(Name = "Fuel Injection Timing (O)", Description = "Vehicle Fuel Injection Timing (O)")]
        public double? FuelInjectionTiming { get; set; }

        [Display(Name = "Engine Fuel Rate (L/h)", Description = "Vehicle Engine Fuel Rate (L/h)")]
        public double? EngineFuelRate { get; set; }

        [Display(Name = "Movement", Description = "Vehicle Movement")]
        public bool? Movement { get; set; }

        [Display(Name = "Sleep Mode", Description = "Vehicle Sleep Mode")]
        public SleepMode? SleepMode { get; set; }

        [Display(Name = "GNSS Status", Description = "Vehicle GNSS Status")]
        public GnssStatus? GnssStatus { get; set; }

        [Display(Name = "PDOP", Description = "Vehicle PDOP")]
        public double? Pdop { get; set; }

        [Display(Name = "Trip Odometer (m)", Description = "Vehicle Trip Odometer (m)")]
        public int? TripOdometer { get; set; }

        [Display(Name = "Axle Weight (kg)", Description = "Vehicle Axle Weight (kg)")]
        public double? AxleWeight { get; set; }

        [Display(Name = "Brake Pedal Level(%)", Description = "Vehicle Brake Pedal Level(%)")]
        public double? BrakePedalLevel { get; set; }

        [Display(Name = "Cruise Status", Description = "Vehicle Cruise Status")]
        public bool? CruiseStatus { get; set; }

        [Display(Name = "Driver Door Status", Description = "Vehicle Driver Door Status")]
        public bool? DriverDoorStatus { get; set; }

        [Display(Name = "DTC", Description = "Vehicle DTC")]
        public string Dtc { get; set; }

        [Display(Name = "Engine Motor Hours", Description = "Vehicle Engine Motor Hours")]
        public double? EngineMotorHours { get; set; }

        [Display(Name = "Fuel Consumed (ltr)", Description = "Vehicle Fuel Consumed (ltr)")]
        public double? FuelConsumed { get; set; }

        [Display(Name = "Trunk Status", Description = "Vehicle Trunk Status")]
        public bool? TrunkStatus { get; set; }

        [Display(Name = "Engine Temperature (C)", Description = "Vehicle Engine Temperature (C)")]
        public double? EngineTemperature { get; set; }

        //Excessive Driving Properties
        [Display(Name = "Excessive Idling Event", Description = "Excessive Idling Event")]
        public bool? ExcessiveIdlingEvent { get; set; }

        [Display(Name = "Excessive Idling Duration (s)", Description = "Excessive Idling Duration (s)")]
        public int? ExcessiveIdlingDuration { get; set; }

        [Display(Name = "Excessive Idling TimeStamp", Description = "Excessive Idling TimeStamp")]
        public DateTime? ExcessiveIdlingTimeStamp { get; set; }

        [Display(Name = "Idle Status", Description = "Idle Status")]
        public bool? IdleStatus { get; set; }

        [Display(Name = "Towing Status", Description = "Towing Status")]
        public bool? TowingStatus { get; set; }

        [Display(Name = "Power Source Status", Description = "Power Source Status")]
        public bool? ExternalPowerSourceStatus { get; set; }

        //[JsonSchema(typeof(DriverApp))]
        [Display(Name = "Driver App Data", Description = "Vehicle Driver App Data")]
        public string DriverAppData { get; set; }

        [NotMapped]
        public DriverApp DriverApp { get { return JsonMapper.MapOrDefault<DriverApp>(DriverAppData); } }

        [Display(Name = "Segment Data", Description = "Vehicle Segment Data")]
        public string SegmentData { get; set; }

        [Display(Name = "External Data", Description = "Vehicle External Data")]
        public string ExternalData { get; set; }

        [DisplayFormat(DataFormatString = StandardDateTimeFormats.Full)]
        [Display(Name = "Server Timestamp", Description = "Vehicle Server Timestamp")]
        public DateTime ServerTimestamp { get; set; }

        [Display(Name = "Ble Beacon Data", Description = "Vehicle Ble Beacon Data")]
        public string BleBeaconData { get; set; }

        [Display(Name = "Telemetry Document", Description = "Vehicle Telemetry Document")]
        public string TelemetryDocument { get; set; }

        [Display(Name = "Distance Since Last Trip (m)", Description = "Vehicle Distance Since Last Trip (m)")]
        public long DistanceSinceLastTrip { get; set; }

        // Quarantine Properties

        [Display(Name = "Is Quarantine Active", Description = "Is Vehicle Telemetry Quarantine Active")]
        public bool? IsQuarantineActive { get; set; }

        [Display(Name = "Active Quarantine Latitude", Description = "Vehicle Active Quarantine Latitude")]
        public double? ActiveQuarantineLatitude { get; set; }

        [Display(Name = "Active Quarantine Longitude", Description = "Vehicle Active Quarantine Longitude")]
        public double? ActiveQuarantineLongitude { get; set; }

        [Display(Name = "Is Quarantine Breached", Description = "Is Vehicle Telemetry Quarantine Breached")]
        public bool? IsQuarantineBreached { get; set; }

        [NotMapped]
        public IEnumerable<BleBeacon> BleBeacons { get { return JsonMapper.MapOrDefault<IEnumerable<BleBeacon>>(BleBeaconData) ?? Enumerable.Empty<BleBeacon>(); } }

        [Display(Name = "Vision Data", Description = "Vehicle Vision Data")]
        public string VisionData { get; set; }

        [NotMapped]
        public Vision Vision { get { return JsonMapper.MapOrDefault<Vision>(VisionData); } }

        [NotMapped]
        public TelemetryDocument Telemetry { get { return JsonMapper.MapOrDefault<TelemetryDocument>(TelemetryDocument); } }

        public bool IsDeleted { get; set; }

        public long? EngineOnDuration { get; set; }

        public long? EngineOffDuration { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual DirectionsRoute DirectionsRoute { get; set; }
        public virtual ActRoute ActRoute { get; set; }
        public virtual ActShift ActShift { get; set; }
        public virtual Driver Driver { get; set; }
    }
}