﻿using System;
using System.ComponentModel;

namespace Ulaw.ApplicationProcessor.Extensions
{
    static class EnumExtensions
    {
        public static string ToDescription(this Enum en)
        {
            var type = en.GetType();

            var memInfo = type.GetMember(en.ToString());

            if (memInfo.Length <= 0) return en.ToString();
            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attrs.Length > 0 
                ? ((DescriptionAttribute)attrs[0]).Description 
                : en.ToString();
        }
    }

}
