using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprature_Program
{
    class Heater
    {
        private float Heatertemp;
        public Heater(float temp)
        {
            Heatertemp = temp;
        }

        public void TempratureChange(float tempchanged)
        {
            if (tempchanged<Heatertemp)
            {
				Console.WriteLine("Heater is ON, temprature is < Heater Temprature");
            }
        }
    }
}
