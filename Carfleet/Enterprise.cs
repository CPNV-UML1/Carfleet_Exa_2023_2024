using System;
using System.Collections.Generic;

namespace Carfleet
{
    public class Enterprise
    {
        #region private attributes
        private List<Vehicle> _vehicles = new List<Vehicle>();
        private List<Driver> _drivers = new List<Driver>();
        #endregion private attributes

        #region public methods
        public void AssignVehicleToDriver(Vehicle vehicleToAssign, Driver driverToAssign)
        {
            Driver driver = null;
            Vehicle vehicle = null;
            try
            {
                //STEP 1.1
                driver = this.GetDriverByEmailaddress(driverToAssign.Emailaddress);
            }
            catch (DriverNotFoundException)
            {
                //STEP 1.1.1
                this.HireDriver(driverToAssign);
                driver = driverToAssign;
            }

            try
            {
                //STEP 1.2
                vehicle = this.GetVehicleByChassisNumber(vehicleToAssign.ChassisNumber);
            }
            catch (VehicleNotFoundException)
            {
                //STEP 1.2.1
                this.AddVehicleToFleet(vehicleToAssign);
                vehicle = vehicleToAssign;
            }

            driver.TakeAVehicle(vehicle);
        }

        public List<Vehicle> Vehicles { get => _vehicles; set => _vehicles = value; }
        public List<Driver> Drivers { get => _drivers; set => _drivers = value; }

        #endregion public methods

        #region private methods
        private Driver GetDriverByEmailaddress(string driverEmailaddress)
        {
            foreach (Driver driver in _drivers)
            {
                if (driver.Emailaddress == driverEmailaddress)
                {
                    return driver;
                }
            }
            //STEP 1.1 Exception
            throw new DriverNotFoundException();
        }

        private Vehicle GetVehicleByChassisNumber(string chassisNumber)
        {
            foreach (Vehicle vehicle in _vehicles)
            {
                if (vehicle.ChassisNumber == chassisNumber)
                {
                    return vehicle;
                }
            }
            //STEP 1.2.1 Exception
            throw new VehicleNotFoundException();
        }

        //STEP 1.1.1
        private void HireDriver(Driver driverToHire)
        {
             _drivers.Add(driverToHire);
        }

        //STEP 1.2.1
        private void AddVehicleToFleet(Vehicle vehicleToAdd)
        {
            _vehicles.Add(vehicleToAdd);
        }
        #endregion private methods

        #region nesteded class
        public class EnterpriseException : Exception { } //Not mandatory
        public class VehicleNotFoundException : EnterpriseException { }
        public class DriverNotFoundException : EnterpriseException { }
        #endregion nesteded class
    }
}
