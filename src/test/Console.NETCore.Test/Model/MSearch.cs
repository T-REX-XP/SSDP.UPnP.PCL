﻿using System;
using System.Collections.Generic;
using ISSDP.UPnP.PCL.Enum;
using ISSDP.UPnP.PCL.Interfaces.Model;

namespace Console.NETCore.Test.Model
{
    internal class MSearch : IMSearchRequest
    {
        public bool InvalidRequest { get; } = false;
        public string HostIp { get; internal set; }
        public int HostPort { get; internal set; }
        public IDictionary<string, string> Headers { get; internal set; }
        public CastMethod SearchCastMethod { get; internal set; }
        public string MAN { get; internal set; }
        public TimeSpan MX { get; internal set; }
        public string ST { get; internal set; }
        public IUserAgent UserAgent { get; internal set; }
        public string CPFN { get; internal set; }
        public string CPUUID { get; internal set; }
        public string TCPPORT { get; internal set; }

    }
}
