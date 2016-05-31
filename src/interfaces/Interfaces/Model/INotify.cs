﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISDPP.UPnP.PCL.Enum;

namespace ISDPP.UPnP.PCL.Interfaces.Model
{
    public interface INotify : IHost, IHeaders, IParserError
    {
        CastMethod NotifyCastMethod { get; }
        TimeSpan CacheControl { get;}
        Uri Location { get; }
        string NT { get;}
        string SID { get;}
        string SVCID { get; }
        string SEQ { get; }
        string LVL { get; }
        NTS NTS { get; }
        IServer Server { get; }
        string USN { get; }
        string BOOTID { get; }
        string CONFIGID { get; }
        string SEARCHPORT { get; }
        string NEXTBOOTID { get; }
        string SECURELOCATION { get; }
        bool IsUuidUpnp2Compliant { get; }
        MemoryStream Data { get; }
    }
}
