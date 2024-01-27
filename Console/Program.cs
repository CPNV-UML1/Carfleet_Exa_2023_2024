namespace Carfleet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Enterprise _enterprise = new Enterprise();
            string _chassisNumber = "XFEFDREA";
            string _driverEmailaddress = "nic@gmail.com";
            Vehicle _vehicle = new Vehicle(_chassisNumber);
            Driver _driver = new Driver(_driverEmailaddress);

            //STEP 1
            _enterprise.AssignVehicleToDriver(_vehicle, _driver);   
        }
    }
}