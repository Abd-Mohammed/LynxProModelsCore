namespace LynxPro.Models
{
    public static class VehicleExtensions
    {
        public static Device MediaDeviceOrDefault(this Vehicle vehicle)
        {
            if (HasStreamingCapabilities(vehicle.PrimaryDevice))
            {
                return vehicle.PrimaryDevice;
            }
            else if (HasStreamingCapabilities(vehicle.SecondaryDevice))
            {
                return vehicle.SecondaryDevice;
            }
            else
            {
                return null;
            }
        }

        public static bool TryGetMediaDevice(this Vehicle vehicle, out Device device)
        {
            device = null;
            var hasMedia = false;

            try
            {
                if (HasStreamingCapabilities(vehicle.PrimaryDevice))
                {
                    hasMedia = true;
                    device = vehicle.PrimaryDevice;
                }
                else if (HasStreamingCapabilities(vehicle.SecondaryDevice))
                {
                    hasMedia = true;
                    device = vehicle.SecondaryDevice;
                }

                return hasMedia;
            }
            catch
            {
                return hasMedia;
            }
        }

        private static bool HasStreamingCapabilities(Device device)
        {
            return device?.DeviceType.Capabilities.Streaming == true;
        }
    }
}