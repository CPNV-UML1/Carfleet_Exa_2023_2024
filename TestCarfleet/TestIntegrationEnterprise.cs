using NUnit.Framework;
using System.Collections.Generic;
using static Carfleet.Driver;
using static Carfleet.Enterprise;

namespace Carfleet
{
    public class TestIntegrationEnterprise
    {
        #region private attributes
        #region vehicle
        private string _registration = "VD 123 567";
        private string _brand = "Mercedes-Benz";
        private string _model = "Vito";
        private string _chassisNumber = "SV30-0169266";
        private Vehicle _vehicule;
        #endregion

        #region driver
        private string _driverName = "Kiss";
        private string _firstname = "Norbert";
        private string _driverPhonenumber = "+4398567985093";
        private string _driverEmailaddress = "kiss.norbert@fia.com";
        private List<string> _languages = new List<string>();
        private string _workZone = "Spain";
        private Driver _driver;
        #endregion private driver

        #region enterprise
        private string _enterpriseName = "Friderici";
        private string _street = "Av. de Genève 12";
        private string _city = "1200 Lausanne";
        private string _enterprisePhonenumber = "+41 21 456 78 90";
        private string _enterpriseEmailaddress = "info@friderici.ch";
        private Enterprise _enterprise;
        #endregion entreprise
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            _vehicule = new Vehicle(_registration, _brand, _model, _chassisNumber);
            _driver = new Driver(_driverEmailaddress, _driverName,_firstname,
                                 _driverPhonenumber, _workZone);
            _enterprise = new Enterprise(_enterpriseName, _street, _city, _enterprisePhonenumber, _enterpriseEmailaddress);
        }

        [Test]
        public void GetVehicleByChassisNumber_NewVehicle_VehicleAddedAndGiven()
        {
            //given

            //when
            _enterprise.Add(_vehicule);

            //then
            Assert.AreEqual(_registration, _enterprise.GetVehicleByChassisNumber(_chassisNumber).Registration);
        }

        [Test]
        public void GetVehicleByChassisNumber_MissingVehicle_ThrowException()
        {
            //given

            //when
            Assert.Throws<VehicleNotFoundException>(() => _enterprise.GetVehicleByChassisNumber(_chassisNumber));

            //then
            //Exception thrown
        }

        [Test]
        public void GetDriverByEmailaddress_NewDriver_DriverAddedAndGiven()
        {
            //given

            //when
            _enterprise.Add(_driver);

            //then
            Assert.AreEqual(_driverName, _enterprise.GetDriverByEmailaddress(_driverEmailaddress).Name);
        }

        [Test]
        public void GetDriverByEmailaddress_MissingDriver_ThrowException()
        {
            //given

            //when
            Assert.Throws<DriverNotFoundException>(() => _enterprise.GetDriverByEmailaddress(_driverEmailaddress));

            //then
            //Exception thrown
        }

        [Test]
        public void AssignVehicleToDriver_DriverAndCarAvailable_AssignationSuccessfull()
        {
            //given
            _enterprise.Add(_vehicule);
            _enterprise.Add(_driver);

            //when
            _enterprise.AssignVehicleToDriver(_chassisNumber, _driverEmailaddress);

            //then
            Assert.AreEqual(_registration, _enterprise.GetDriverByEmailaddress(_driverEmailaddress).Vehicle.Registration);
        }

        [Test]
        public void ReleaseVehicleFromDriver_DriverAndCarAvailable_VehicleReleased()
        {
            //given
            _enterprise.Add(_vehicule);
            _enterprise.Add(_driver);
            _enterprise.AssignVehicleToDriver(_chassisNumber, _driverEmailaddress);

            //when
            _enterprise.ReleaseVehicleFromDriver(_driverEmailaddress);

            //then
            Assert.IsNull(_enterprise.GetDriverByEmailaddress(_driverEmailaddress).Vehicle);
        }

        [Test]
        public void ReleaseVehicleFromDriver_DriverAndCarAvailable_ThrowException()
        {
            //given
            _enterprise.Add(_vehicule);
            _enterprise.Add(_driver);
            //we do not assign the vehicle to the driver

            //when
            Assert.Throws<NoVehicleAssignedException>(() => _enterprise.ReleaseVehicleFromDriver(_driverEmailaddress));

            //then
            //Exception thrown
        }
    }
}