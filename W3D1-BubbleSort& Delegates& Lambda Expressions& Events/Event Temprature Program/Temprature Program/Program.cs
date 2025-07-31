namespace Temprature_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();
			Heater H = new Heater(20);
			Cooler C = new Cooler(25);


            thermostat.OnTempratureChange += H.TempratureChange;
            thermostat.OnTempratureChange += C.TempratureChange;
			thermostat.CurrentTemp = 18;
			thermostat.CurrentTemp = 28;
			thermostat.CurrentTemp = 30;


		}
    }
}
