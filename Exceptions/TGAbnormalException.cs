﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatehamaATS.Exceptions
{
    /// <summary>
    /// C0:TG異常
    /// </summary>
    internal class TGAbnormalException : ATSCommonException
    {
        /// <summary>
        /// C0:TG異常
        /// </summary>
        public TGAbnormalException(int place) : base(place)
        {
        }
        /// <summary>
        /// C0:TG異常
        /// </summary>
        public TGAbnormalException(int place, string message)
            : base(place, message)
        {
        }
        /// <summary>
        /// C0:TG異常
        /// </summary>
        public TGAbnormalException(int place, string message, Exception inner)
            : base(place, message, inner)
        {
        }
        public override string ToCode()
        {
            return Place.ToString() + "80";
        }
    }
}