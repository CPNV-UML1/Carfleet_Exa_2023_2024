using NUnit.Framework;
using System.Collections.Generic;

namespace Carfleet
{
    public class TestDriver
    {
        #region private attributes
        private string _name = "Kiss";
        private string _firstname = "Norbert";
        private string _phonenumber = "+4398567985093";
        private string _emailaddress = "kiss.norbert@fia.com";
        private List<string> _languages = new List<string>();
        private string _workZone = "Spain";
        private Driver _driver;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            _driver = new Driver(_emailaddress, _name, _firstname, _phonenumber, _workZone, _languages);
        }

        [Test]
        public void AllProperties_AfterInstantiation_GetCorrectValues()
        {
            //given

            //when

            //then
            Assert.AreEqual(_emailaddress, _driver.Emailaddress);
            Assert.AreEqual(_name, _driver.Name);
            Assert.AreEqual(_firstname, _driver.Firstname);
            Assert.AreEqual(_phonenumber, _driver.Phonenumber);
            Assert.AreEqual(_languages, _driver.Languages);
            Assert.AreEqual(_workZone, _driver.WorkZone);
        }


    }
}