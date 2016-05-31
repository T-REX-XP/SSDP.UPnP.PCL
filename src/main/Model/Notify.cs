﻿using System;
using System.Collections.Generic;
using System.IO;
using ISDPP.UPnP.PCL.Enum;
using ISDPP.UPnP.PCL.Interfaces.Model;
using ISimpleHttpServer.Model;
using SDPP.UPnP.PCL.Model.Base;
using static SDPP.UPnP.PCL.Helper.Convert;
using static SDPP.UPnP.PCL.Helper.HeaderHelper;

namespace SDPP.UPnP.PCL.Model
{
    internal class Notify : ParserErrorBase, INotify
    {
        public string HostIp { get; }
        public int HostPort { get;  }
        public CastMethod NotifyCastMethod { get; } = CastMethod.NoCast;
        public TimeSpan CacheControl { get; }
        public Uri Location { get; }
        public string NT { get; }
        public string SID { get; }
        public string SVCID { get; }
        public string SEQ { get; }
        public string LVL { get; }
        public NTS NTS { get; }
        public IServer Server { get;}
        public string USN { get;}

        public string BOOTID { get; }
        public string CONFIGID { get; }
        public string SEARCHPORT { get; }
        public string NEXTBOOTID { get; }
        public string SECURELOCATION { get; }
        public bool IsUuidUpnp2Compliant { get; }
        public IDictionary<string, string> Headers { get; }
        public MemoryStream Data { get; }

        internal Notify(IHttpRequest request)
        {
            try
            {
                NotifyCastMethod = GetCastMetod(request);
                HostIp = request.RemoteAddress;
                HostPort = request.RemotePort;
                CacheControl = TimeSpan.FromSeconds(GetMaxAge(request.Headers));
                Location = UrlToUri(GetHeaderValue(request.Headers, "LOCATION"));
                NT = GetHeaderValue(request.Headers, "NT");
                NTS = ConvertToNotificationSubTypeEnum(GetHeaderValue(request.Headers, "NTS"));
                Server = ConvertToServer(GetHeaderValue(request.Headers, "SERVER"));
                USN = GetHeaderValue(request.Headers, "USN");
                SID = GetHeaderValue(request.Headers, "SID");
                SVCID = GetHeaderValue(request.Headers, "SVCID");
                SEQ = GetHeaderValue(request.Headers, "SEQ");
                LVL = GetHeaderValue(request.Headers, "LVL");

                BOOTID = GetHeaderValue(request.Headers, "BOOTID.UPNP.ORG");
                CONFIGID = GetHeaderValue(request.Headers, "CONFIGID.UPNP.ORG");
                SEARCHPORT = GetHeaderValue(request.Headers, "SEARCHPORT.UPNP.ORG");
                NEXTBOOTID = GetHeaderValue(request.Headers, "NEXTBOOTID.UPNP.ORG");
                SECURELOCATION = GetHeaderValue(request.Headers, "SECURELOCATION.UPNP.ORG");

                Headers = SingleOutAdditionalHeaders(new List<string>
                {
                    "HOST", "CACHE-CONTROL", "LOCATION", "NT", "NTS", "SERVER", "USN",
                    "BOOTID.UPNP.ORG", "CONFIGID.UPNP.ORG", "SID", "SVCID", "SEQ", "LVL",
                    "SEARCHPORT.UPNP.ORG", "NEXTBOOTID.UPNP.ORG", "SECURELOCATION.UPNP.ORG"
                }, request.Headers);

                Data = request.Body;
            }
            catch (Exception)
            {
                InvalidRequest = true;
            }

            Guid guid;
            IsUuidUpnp2Compliant = Guid.TryParse(USN, out guid);
        }
    }
}
