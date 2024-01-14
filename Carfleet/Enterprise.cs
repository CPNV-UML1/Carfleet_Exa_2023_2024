using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Carfleet
{
    public class Enterprise
    {
        #region private attributes
        private List<Vehicle> _vehicles = new List<Vehicle>();
        private List<Driver> _drivers = new List<Driver>();
        #endregion private attributes

        #region public methods
        public Vehicle GetVehicleByChassisNumber(string chassisNumber)
        {
            foreach (Vehicle vehicle in _vehicles)
            {
                if (vehicle.ChassisNumber == chassisNumber)
                {
                    return vehicle;
                }
            }
            throw new VehicleNotFoundException();
        }

        //STEP 1.1
        public Driver GetDriverByEmailaddress(string driverEmailaddress)
        {
            foreach (Driver driver in _drivers)
            {
                if (driver.Emailaddress == driverEmailaddress)
                {
                    return driver;
                }
            }
            throw new DriverNotFoundException();
        }

        //STEP 1.2
        public void AssignVehicleToDriver(string chassisNumber, string driverEmailaddress)
        {
            Driver driver = this.GetDriverByEmailaddress(driverEmailaddress);
            Vehicle vehicle = this.GetVehicleByChassisNumber(chassisNumber);
            driver.TakeAVehicle(vehicle);
        }
        #endregion public methods

        #region nesteded class
        public class EnterpriseException : Exception { } //Not mandatory
        public class VehicleNotFoundException : EnterpriseException { }
        public class DriverNotFoundException : EnterpriseException { }
        #endregion nesteded class
    }
}
