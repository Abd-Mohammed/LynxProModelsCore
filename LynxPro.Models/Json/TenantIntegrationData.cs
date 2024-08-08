namespace LynxPro.Models.Json
{
    public class TenantIntegrationData
    {
        public TenantIntegrationData()
        {
            RideSharing = new RideSharingData();
            RideSharingAnalytics = new RideSharingAnalyticsData();
        }

        public RideSharingData RideSharing { get; set; }

        public RideSharingAnalyticsData RideSharingAnalytics { get; set; }

        public bool? WmsEnabled { get; set; }

        public bool? TelemetryEnabled { get; set; }
    }

    public class RideSharingData
    {
        public string Token { get; set; }
    }

    public class RideSharingAnalyticsData
    {
        public string ApiKey { get; set; }
    }
}
