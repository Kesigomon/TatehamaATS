﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TatehamaATS.Exceptions
{
    /// <summary>
    /// 84:継電部初期化失敗
    /// </summary>
    internal class RelayInitialzingFailure : ATSCommonException
    {
        /// <summary>
        /// 84:継電部初期化失敗
        /// </summary>
        public RelayInitialzingFailure(int place) : base(place)
        {
        }
        /// <summary>
        /// 84:継電部初期化失敗
        /// </summary>
        public RelayInitialzingFailure(int place, string message)
            : base(place, message)
        {
        }
        /// <summary>
        /// 84:継電部初期化失敗
        /// </summary>
        public RelayInitialzingFailure(int place, string message, Exception inner)
            : base(place, message, inner)
        {
        }
        public override string ToCode()
        {
            return Place.ToString() + "84";
        }
    }
}
