using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient
{
    internal static class CustomExtensions
    {
        /// <summary>
        /// Extension para convertir la hora a hora central Mexico. -6
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static DateTime CentralTime(this DateTime date)
        {
            var centralTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            return TimeZoneInfo.ConvertTimeFromUtc(date.ToUniversalTime(), centralTimeZone);
        }
    }
}
