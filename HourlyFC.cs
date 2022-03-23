using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Detyra1F2_Projekti11_SH.B
{
    class HourlyFC
    {
        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
        public class ForecastInfo
        {
            public List<hourly> hourly { get; set; }
        }
        public class hourly
        {
            public long dt { get; set; }
            public double temp { get; set; }

            public double pressure { get; set; }

            public double wind_speed { get; set; }

            public List<weather> weather { get; set; }

        }
    }
}
