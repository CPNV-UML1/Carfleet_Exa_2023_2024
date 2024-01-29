using NUnit.Framework;
using System.Collections.Generic;

namespace Carfleet
{
    public class TestIntegrationEnterprise
    {
        #region private attributes
        #region vehicle
        private string _chassisNumber = "SV30-0169266";
        private Vehicle _vehicle;
        #endregion

        #region driver
        private string _driverEmailaddress = "kiss.norbert@fia.com";
        private Driver _driver;
        #endregion private driver

        #region enterprise
        private Enterprise _enterprise;
        #endregion entreprise
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            _vehicle = new Vehicle(_chassisNumber);
            _driver = new Driver(_driverEmailaddress);
            _enterprise = new Enterprise();
        }

        [Test]
        public void SequenceAssignVehicleToDriver_NewDriverAndNewVehicle_VehicleAssignedToTheDriver()
        {
            //STEP 01 - Assign Vehicle To Driver
            //given
            //refer to Setup Method
            Assert.IsFalse(_enterprise.Drivers.Exists(driver => driver.Emailaddress == _driverEmailaddress));
            Assert.IsFalse(_enterprise.Vehicles.Exists(vehicle => vehicle.ChassisNumber == _chassisNumber));

            //when
            _enterprise.AssignVehicleToDriver(_vehicle, _driver);

            //then
            Assert.AreEqual(_vehicle, _driver.Vehicle);
        }

        #region utils
        private List<Driver> GenerateDrivers(int amoutOfDrivers)
        {
            List<Driver> drivers = new List<Driver>();
            return drivers;
        }

        private List<Vehicle> GenerateVehicles(int amoutOfVehicles)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            return vehicles;
        }
        #endregion utils
    }
}