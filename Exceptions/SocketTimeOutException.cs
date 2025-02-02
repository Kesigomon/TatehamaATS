﻿namespace TatehamaATS.Exceptions
{
    /// <summary>
    /// E5:連続タイムアウト
    /// </summary>
    internal class SocketTimeOutException : ATSCommonException
    {
        /// <summary>
        /// E5:連続タイムアウト
        /// </summary>
        public SocketTimeOutException(int place) : base(place)
        {
        }
        /// <summary>
        /// E5:連続タイムアウト
        /// </summary>
        public SocketTimeOutException(int place, string message)
            : base(place, message)
        {
        }
        /// <summary>
        /// E5:連続タイムアウト
        /// </summary>
        public SocketTimeOutException(int place, string message, Exception inner)
            : base(place, message, inner)
        {
        }
        public override string ToCode()
        {
            return Place.ToString() + "E5";
        }
    }
}
