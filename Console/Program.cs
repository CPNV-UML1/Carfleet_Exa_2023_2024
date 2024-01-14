namespace Carfleet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Enterprise _enterprise = new Enterprise();
            string _chassisNumber = "XFEFDREA";
            string _driverEmailaddress = "nic@gmail.com";
            _enterprise.AssignVehicleToDriver(_chassisNumber, _driverEmailaddress);   
        }
    }
}