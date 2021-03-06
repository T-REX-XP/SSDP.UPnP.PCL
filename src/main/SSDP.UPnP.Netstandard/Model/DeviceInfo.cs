﻿using ISSDP.UPnP.PCL.Interfaces.Model;

namespace SSDP.UPnP.PCL.Model
{
    public class DeviceInfo : IDeviceInfo
    {
        public string FullString { get; internal set; }
        public string OperatingSystem { get; internal set; }
        public string OperatingSystemVersion { get; internal set; }
        public string ProductName { get; internal set; }
        public string ProductVersion { get; internal set; }
        public string UpnpMajorVersion { get; internal set; }
        public string UpnpMinorVersion { get; internal set; }
        public bool IsUpnp2 { get; internal set; }
    }
}
