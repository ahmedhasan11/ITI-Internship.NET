using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temprature_Program
{
    class Cooler
    {
        private float CoolerTemp;

        public Cooler(float temp)
        {
            CoolerTemp = temp;
        }

        public void TempratureChange(float tempchanged)
        {
            if (tempchanged>CoolerTemp)
            {
				Console.WriteLine("cooler starts working , temprature is > CoolerTemp");
            }
        }
    }
}
