using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApiTask
{
    public class WeatherReport
    {
        public string name
        {
            get;
            set;
        }
        public string country
        {
            get;
            set;
        }
        public string state
        {
            get;
            set;
        }
        public long lat
        {
            get;
            set;
        }
        public long lon
        {
            get;
            set;
        }
    }
}
