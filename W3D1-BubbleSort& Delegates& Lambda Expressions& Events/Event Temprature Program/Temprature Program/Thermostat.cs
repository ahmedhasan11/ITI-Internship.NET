using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprature_Program
{
    class Thermostat
    {
        private float currentTemp;

        public delegate void TempratureChange(float changingtemp);

        public event TempratureChange OnTempratureChange;

        public float CurrentTemp 
        {
            get { return currentTemp; }
            set
            {

                if (currentTemp != value)
                {
					currentTemp = value;
					OnTempratureChange?.Invoke(currentTemp);
                }
            }
        }
    }
}
