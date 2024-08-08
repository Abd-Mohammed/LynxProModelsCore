using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models.Json
{
    [Flags]
    public enum PayloadEventTypes
    {
        None = 0,
        Telemetry = 1,
        Event = 2,
        Alarm = 4,
        Ble = 8,
        Vision = 16,
        External = 32,
        Adas = 64,
        Alpr = 128,
        Meter = 256
    }
    public enum SleepMode
    {
        // Module will never enter sleep mode
        [Display(Name = "Disabled")]
        Disabled = 0,
        // Module reduces level of power usage by turning GPS module to sleep
        [Display(Name = "Sleep")]
        Sleep = 1,
        // Module turns GPS module to sleep and device is deregistered from network, note that some devices
        // will not receive SMS
        [Display(Name = "Deep Sleep")]
        DeepSleep = 2,
        // Device behavior is the same as in deep sleep, but GSM module stays on
        [Display(Name = "Online Sleep")]
        OnlineSleep = 3,
    }

    public enum GnssStatus
    {
        [Display(Name = "Off")]
        Off = 0,
        [Display(Name = "On With Fix")]
        OnWithFix = 1,
        [Display(Name = "On Without Fix")]
        OnWithoutFix = 2,
        [Display(Name = "Sleep State")]
        SleepState = 3,
    }

    [Flags]
    public enum Din
    {
        [Display(Name = "DIN 01")]
        Din01 = 1,
        [Display(Name = "DIN 02")]
        Din02 = 2,
        [Display(Name = "DIN 03")]
        Din03 = 4,
        [Display(Name = "DIN 04")]
        Din04 = 8,
    }

    [Flags]
    public enum Dout
    {
        [Display(Name = "DOUT 01")]
        Dout01 = 1,
        [Display(Name = "DOUT 02")]
        Dout02 = 2,
        [Display(Name = "DOUT 03")]
        Dout03 = 4,
        [Display(Name = "DOUT 04")]
        Dout04 = 8
    }

    public class TelemetryPayload
    {
        [JsonProperty("ident", Required = Required.Always)]
        public string Ident { get; set; }

        [JsonProperty("latitude", Required = Required.Always)]
        public double Latitude { get; set; }

        [JsonProperty("longitude", Required = Required.Always)]
        public double Longitude { get; set; }

        [JsonProperty("altitude", Required = Required.Always)]
        public double Altitude { get; set; }

        [JsonProperty("angle", Required = Required.Always)]
        public double Angle { get; set; }

        [JsonProperty("speed", Required = Required.Always)]
        public double Speed { get; set; }

        [JsonProperty("virtualSpeed", Required = Required.Always)]
        public double VirtualSpeed { get; set; }

        [JsonProperty("hdop", Required = Required.DisallowNull)]
        public double? Hdop { get; set; }

        [JsonProperty("engineOn", Required = Required.DisallowNull)]
        public bool? IsEngineOn { get; set; }

        [JsonProperty("virtualOdometer", Required = Required.Always)]
        public long VirtualOdometer { get; set; }

        [JsonProperty("satellitesNo", Required = Required.DisallowNull)]
        public int? SatellitesNo { get; set; }

        [JsonProperty("gsmSignal", Required = Required.DisallowNull)]
        public int? GsmSignal { get; set; }

        [JsonProperty("gsmOperator", Required = Required.DisallowNull)]
        public string GsmOperator { get; set; }

        [JsonProperty("powerSupplyVoltage", Required = Required.DisallowNull)]
        public double? PowerSupplyVoltage { get; set; }

        [JsonProperty("batteryVoltage", Required = Required.DisallowNull)]
        public double? BatteryVoltage { get; set; }

        [JsonProperty("harshAccelerationCount", Required = Required.DisallowNull)]
        public int? HarshAccelerationCount { get; set; }

        [JsonProperty("harshBrakingCount", Required = Required.DisallowNull)]
        public int? HarshBrakingCount { get; set; }

        [JsonProperty("extremeBrakingCount", Required = Required.DisallowNull)]
        public int? ExtremeBrakingCount { get; set; }

        [JsonProperty("overspeedingCount", Required = Required.DisallowNull)]
        public int? OverspeedingCount { get; set; }

        [JsonProperty("idlingTime", Required = Required.DisallowNull)]
        public int? IdlingTime { get; set; }

        [JsonProperty("staffId", Required = Required.DisallowNull)]
        public string StaffId { get; set; }

        [JsonProperty("rfidCode", Required = Required.DisallowNull)]
        public string RfidCode { get; set; }

        [JsonProperty("ibuttonCode", Required = Required.DisallowNull)]
        public string IButtonCode { get; set; }

        [JsonProperty("referenceNumber", Required = Required.DisallowNull)]
        public string ReferenceNumber { get; set; }

        [JsonProperty("ain01", Required = Required.DisallowNull)]
        public double? Ain01 { get; set; }

        [JsonProperty("ain02", Required = Required.DisallowNull)]
        public double? Ain02 { get; set; }

        [JsonProperty("ain03", Required = Required.DisallowNull)]
        public double? Ain03 { get; set; }

        [JsonProperty("ain04", Required = Required.DisallowNull)]
        public double? Ain04 { get; set; }

        [JsonProperty("eventTypeCode", Required = Required.DisallowNull)]
        public string EventTypeCode { get; set; }

        [JsonProperty("alarmTypeCode", Required = Required.DisallowNull)]
        public int? AlarmTypeCode { get; set; }

        [JsonProperty("locationStatus", Required = Required.DisallowNull)]
        public bool? LocationStatus { get; set; }

        [JsonProperty("temperature", Required = Required.DisallowNull)]
        public double? Temperature { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("din", Required = Required.DisallowNull)]
        public Din? Din { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("dout", Required = Required.DisallowNull)]
        public Dout? Dout { get; set; }

        [JsonProperty("overspeedingEvent", Required = Required.DisallowNull)]
        public bool? OverspeedingEvent { get; set; }

        [JsonProperty("harshAccelerationEvent", Required = Required.DisallowNull)]
        public bool? HarshAccelerationEvent { get; set; }

        [JsonProperty("harshBrakingEvent", Required = Required.DisallowNull)]
        public bool? HarshBrakingEvent { get; set; }

        [JsonProperty("harshCorneringEvent", Required = Required.DisallowNull)]
        public bool? HarshCorneringEvent { get; set; }

        [JsonProperty("overRevvingEvent", Required = Required.DisallowNull)]
        public bool? OverRevvingEvent { get; set; }

        [JsonProperty("absoluteAcceleration", Required = Required.DisallowNull)]
        public double? AbsoluteAcceleration { get; set; }

        [JsonProperty("xAcceleration", Required = Required.DisallowNull)]
        public double? XAcceleration { get; set; }

        [JsonProperty("yAcceleration", Required = Required.DisallowNull)]
        public double? YAcceleration { get; set; }

        [JsonProperty("zAcceleration", Required = Required.DisallowNull)]
        public double? ZAcceleration { get; set; }

        [JsonProperty("virtualSegmentDistance", Required = Required.Always)]
        public long VirtualSegmentDistance { get; set; }

        [JsonProperty("physicalSegmentDistance", Required = Required.DisallowNull)]
        public long? PhysicalSegmentDistance { get; set; }

        [JsonProperty("odometer", Required = Required.Always)]
        public long Odometer { get; set; }

        // Additional I/O
        [JsonProperty("dtcCount", Required = Required.DisallowNull)]
        public int? DtcCount { get; set; }

        [JsonProperty("physicalSpeed", Required = Required.DisallowNull)]
        public double? PhysicalSpeed { get; set; }

        [JsonProperty("physicalOdometer", Required = Required.DisallowNull)]
        public long? PhysicalOdometer { get; set; }

        [JsonProperty("fuelUsedGps", Required = Required.DisallowNull)]
        public int? FuelUsedGps { get; set; }

        [JsonProperty("fuelRateGps", Required = Required.DisallowNull)]
        public int? FuelRateGps { get; set; }

        [JsonProperty("engineLoad", Required = Required.DisallowNull)]
        public double? EngineLoad { get; set; }

        [JsonProperty("engineCoolantTemperature", Required = Required.DisallowNull)]
        public double? EngineCoolantTemperature { get; set; }

        [JsonProperty("fuelPressure", Required = Required.DisallowNull)]
        public double? FuelPressure { get; set; }

        [JsonProperty("engineRpm", Required = Required.DisallowNull)]
        public double? EngineRpm { get; set; }

        [JsonProperty("intakeAirTemperature", Required = Required.DisallowNull)]
        public double? IntakeAirTemperature { get; set; }

        [JsonProperty("mafAirFlowRate", Required = Required.DisallowNull)]
        public double? MafAirFlowRate { get; set; }

        [JsonProperty("throttlePosition", Required = Required.DisallowNull)]
        public double? ThrottlePosition { get; set; }

        [JsonProperty("engineRuntimeSinceStart", Required = Required.DisallowNull)]
        public long? EngineRuntimeSinceStart { get; set; }

        [JsonProperty("commandedEgr", Required = Required.DisallowNull)]
        public double? CommandedEgr { get; set; }

        [JsonProperty("fuelLevel", Required = Required.DisallowNull)]
        public double? FuelLevel { get; set; }

        [JsonProperty("fuelVolume", Required = Required.DisallowNull)]
        public double? FuelVolume { get; set; }

        [JsonProperty("barometricPressure", Required = Required.DisallowNull)]
        public double? BarometricPressure { get; set; }

        [JsonProperty("ambientAirTemperature", Required = Required.DisallowNull)]
        public double? AmbientAirTemperature { get; set; }

        [JsonProperty("engineOilTemperature", Required = Required.DisallowNull)]
        public double? EngineOilTemperature { get; set; }

        [JsonProperty("fuelInjectionTiming", Required = Required.DisallowNull)]
        public double? FuelInjectionTiming { get; set; }

        [JsonProperty("engineFuelRate", Required = Required.DisallowNull)]
        public double? EngineFuelRate { get; set; }

        [JsonProperty("movement", Required = Required.DisallowNull)]
        public bool? Movement { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("sleepMode", Required = Required.DisallowNull)]
        public SleepMode? SleepMode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("gnssStatus", Required = Required.DisallowNull)]
        public GnssStatus? GnssStatus { get; set; }

        [JsonProperty("pdop", Required = Required.DisallowNull)]
        public double? Pdop { get; set; }

        [JsonProperty("tripOdometer", Required = Required.DisallowNull)]
        public int? TripOdometer { get; set; }

        [JsonProperty("axleWeight", Required = Required.DisallowNull)]
        public double? AxleWeight { get; set; }

        [JsonProperty("brakePedalLevel", Required = Required.DisallowNull)]
        public double? BrakePedalLevel { get; set; }

        [JsonProperty("cruiseStatus", Required = Required.DisallowNull)]
        public bool? CruiseStatus { get; set; }

        [JsonProperty("driverDoorStatus", Required = Required.DisallowNull)]
        public bool? DriverDoorStatus { get; set; }

        [JsonProperty("dtc", Required = Required.DisallowNull)]
        public string Dtc { get; set; }

        [JsonProperty("engineMotorHours", Required = Required.DisallowNull)]
        public double? EngineMotorHours { get; set; }

        [JsonProperty("fuelConsumed", Required = Required.DisallowNull)]
        public double? FuelConsumed { get; set; }

        [JsonProperty("trunkStatus", Required = Required.DisallowNull)]
        public bool? TrunkStatus { get; set; }

        [JsonProperty("engineTemperature", Required = Required.DisallowNull)]
        public double? EngineTemperature { get; set; }

        [JsonProperty("idleStatus", Required = Required.DisallowNull)]
        public bool? IdleStatus { get; set; }

        [JsonProperty("towingStatus", Required = Required.DisallowNull)]
        public bool? TowingStatus { get; set; }

        [JsonProperty("externalPowerSourceStatus", Required = Required.DisallowNull)]
        public bool? ExternalPowerSourceStatus { get; set; }

        [JsonProperty("cpuTemperature", Required = Required.DisallowNull)]
        public double? CpuTemperature { get; set; }

        [JsonProperty("deviceName", Required = Required.DisallowNull)]
        public string DeviceName { get; set; }

        [JsonProperty("simImsi", Required = Required.DisallowNull)]
        public string SimImsi { get; set; }

        [JsonProperty("simMsisdn", Required = Required.DisallowNull)]
        public string SimMsisdn { get; set; }

        [JsonProperty("simIccid", Required = Required.DisallowNull)]
        public string SimIccid { get; set; }

        [JsonProperty("accessTechnology", Required = Required.DisallowNull)]
        public string AccessTechnology { get; set; }

        [JsonProperty("gsmSignalLevel", Required = Required.DisallowNull)]
        public int? GsmSignalLevel { get; set; }

        [JsonProperty("deviceTemperature", Required = Required.DisallowNull)]
        public double? DeviceTemperature { get; set; }

        [JsonProperty("xAxisAngle", Required = Required.DisallowNull)]
        public double? XAxisAngle { get; set; }

        [JsonProperty("yAxisAngle", Required = Required.DisallowNull)]
        public double? YAxisAngle { get; set; }

        [JsonProperty("zAxisAngle", Required = Required.DisallowNull)]
        public double? ZAxisAngle { get; set; }

        [JsonProperty("cpuUtilization", Required = Required.DisallowNull)]
        public double? CpuUtilization { get; set; }

        [JsonProperty("crashEvent", Required = Required.DisallowNull)]
        public bool? CrashEvent { get; set; }

        [JsonProperty("bleBeacons", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<BleBeacon> BleBeacons { get; set; } = new List<BleBeacon>();

        [JsonProperty("vision", Required = Required.DisallowNull)]
        public Vision Vision { get; set; }

        [JsonProperty("usbDevice", Required = Required.DisallowNull)]
        public UsbDevice UsbDevice { get; set; }

        [JsonProperty("adas", Required = Required.DisallowNull)]
        public Adas Adas { get; set; }

        [JsonProperty("aqs", Required = Required.DisallowNull)]
        public Aqs Aqs { get; set; }

        [JsonProperty("dsm", Required = Required.DisallowNull)]
        public Dsm Dsm { get; set; }

        [JsonProperty("hotspot", Required = Required.DisallowNull)]
        public Hotspot Hotspot { get; set; }

        [JsonProperty("alpr", Required = Required.DisallowNull)]
        public Alpr Alpr { get; set; }

        [JsonProperty("external", Required = Required.DisallowNull)]
        public JToken JExteral { get; set; }

        /// <summary>
        /// This is currently related to exiting quarantine zone
        /// </summary>
        [JsonProperty("geofenceExit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? GeofenceExit { get; set; }

        /// <summary>
        /// This is currently related to message being forwarded directly with minimal calculations
        /// </summary>
        [JsonProperty("directForward", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? DirectForward { get; set; }

        [JsonProperty("temperatureSensor01", Required = Required.DisallowNull)]
        public double? TemperatureSensor01 { get; set; }

        [JsonProperty("temperatureSensor02", Required = Required.DisallowNull)]
        public double? TemperatureSensor02 { get; set; }

        [JsonProperty("temperatureSensor03", Required = Required.DisallowNull)]
        public double? TemperatureSensor03 { get; set; }

        [JsonProperty("temperatureSensor04", Required = Required.DisallowNull)]
        public double? TemperatureSensor04 { get; set; }

        [JsonProperty("ahtTemperature", Required = Required.DisallowNull)]
        public double? AhtTemperature { get; set; }

        [JsonProperty("harshAccelerationDetected", Required = Required.DisallowNull)]
        public bool? HarshAccelerationDetected { get; set; }

        [JsonProperty("harshBrakingDetected", Required = Required.DisallowNull)]
        public bool? HarshBrakingDetected { get; set; }

        [JsonProperty("harshCorneringDetected", Required = Required.DisallowNull)]
        public bool? HarshCorneringDetected { get; set; }

        [JsonProperty("overRevvingDetected", Required = Required.DisallowNull)]
        public bool? OverRevvingDetected { get; set; }

        [JsonProperty("driverSeatBeltBuckled", Required = Required.DisallowNull)]
        public bool? DriverSeatBeltBuckled { get; set; }

        [JsonProperty("passengerSeatBeltBuckled", Required = Required.DisallowNull)]
        public bool? PassengerSeatBeltBuckled { get; set; }

        [JsonProperty("backSeatBeltBuckled", Required = Required.DisallowNull)]
        public bool? BackSeatBeltBuckled { get; set; }

        [JsonProperty("gpsVelocity", Required = Required.DisallowNull)]
        public double? GpsVelocity { get; set; }

        [JsonProperty("distanceToEmpty", Required = Required.DisallowNull)]
        public double? DistanceToEmpty { get; set; }

        [JsonProperty("evBatteryLevel", Required = Required.DisallowNull)]
        public double? EVBatteryLevel { get; set; }

        [JsonProperty("passengerCount", Required = Required.DisallowNull)]
        public int? PassengerCount { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("eventType", Required = Required.Always)]
        public PayloadEventTypes EventType { get; set; }

        [JsonProperty("childDetected", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? ChildDetected { get; set; }

        [JsonProperty("phoneDetected", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? PhoneDetected { get; set; }

        [JsonProperty("seatbeltDetected", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? SeatbeltDetected { get; set; }

        [JsonProperty("passengerDetected", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? PassengerDetected { get; set; }

        [JsonProperty("childTimestamp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ChildTimestamp { get; set; }

        [JsonProperty("phoneTimestamp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PhoneTimestamp { get; set; }

        [JsonProperty("seatbeltTimestamp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? SeatbeltTimestamp { get; set; }

        [JsonProperty("keyStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? KeyStatus { get; set; }

        [JsonProperty("bulbStatus", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? BulbStatus { get; set; }

        [JsonProperty("averageFuelConsumption", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? AverageFuelConsumption { get; set; }
    }
}