﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Chargers.Core.AppSetting
{
    public class SqlAppSetting
    {
        public static string SectionName { get; set; } = "sql";
        public string? ConnectionString { get; set; }
    }
}
