﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Tools
{
    public class Utils
    {
        public static DateTime RoundToNearest30Minutes(DateTime dateTime)
        {
            int totalMinutes = (int)(dateTime.Minute / 30) * 30;

            if (dateTime.Minute >= 30)
            {
                totalMinutes = (dateTime.Minute / 30) * 30;
            }
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, totalMinutes, 0);
        }
    }
}
