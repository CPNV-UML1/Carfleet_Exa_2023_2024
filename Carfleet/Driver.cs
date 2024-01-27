using System;
using System.Collections.Generic;

namespace Carfleet
{
    public class Driver : Person
    {
        #region private attributes
        private Vehicle _vehicle = null;
        #endregion private attributes

        #region public methods
        public Driver(string emailaddress) : base(emailaddress) { }

        //STEP 1.3
        public void TakeAVehicle(Vehicle vehicle)
        {
            //Is Driver available ?
            if (_vehicle != null)
            {
                throw new VehicleAlreadyAssignedException();
            }
            _vehicle = vehicle;
            this.PreUseCheck();
        }

        public Vehicle Vehicle { get => _vehicle; set => _vehicle = value; }
        #endregion public methods

        #region private attributs
        //STEP 1.3.1
        private void PreUseCheck()
        {
            _vehicle.StartEngine();
            _vehicle.StopEngine();
            float fluelLevel = _vehicle.FuelLevel;
            List<string> damages = this.DetectMinorDamages();
            if (damages != null)
            {
                this.Report(damages);
            }
        }
        private List<string> DetectMinorDamages()
        {
            return new List<string>();
        }

        private DamageReport Report(List<string> damages)
        {
            return new DamageReport(damages, _vehicle);
        }
        #endregion private attributs

        #region nesteded classes
        public class DriverException : Exception { } //Not mandatory
        public class VehicleAlreadyAssignedException : DriverException { }
        #endregion nested classes
    }
}
