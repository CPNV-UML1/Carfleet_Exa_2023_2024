using System;

namespace Carfleet
{
    public class Vehicle
    {
        #region private attributes
        private string _chassisNumber;
        #endregion private attributes

        #region public methods
        public Vehicle(string chassisNumber)
        {
            _chassisNumber = chassisNumber;
        }

        public void StartEngine(){}

        public void StopEngine() { }

        public string ChassisNumber { get => _chassisNumber; }
        public float FuelLevel { get => 20f; }
        #endregion public methods
    }
}
