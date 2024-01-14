using NUnit.Framework;
using System;
using System.Collections.Generic;
using static Carfleet.Driver;
using static Carfleet.Person;

namespace Carfleet
{
    public class TestPerson
    {
        #region private attributes
        private string _name = "Einstein";
        private string _firstname = "Albert";
        private string _phonenumber = "+41793456789";
        private string _emailaddress = "ae@relativity.org";
        private List<string> _languages = new List<string>();
        private Person _person;
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            _languages = new List<string>();
            _person = new Person(_emailaddress, _name, _firstname, _phonenumber, _languages);
        }

        [Test]
        public void AllProperties_AfterInstantiation_GetCorrectValues()
        {
            //given

            //when

            //then
            Assert.AreEqual(_name, _person.Name);
            Assert.AreEqual(_firstname, _person.Firstname);
            Assert.AreEqual(_phonenumber, _person.Phonenumber);
            Assert.AreEqual(_emailaddress, _person.Emailaddress);
            Assert.AreEqual(_languages, _person.Languages);
        }

        [Test]
        public void Constructor_EmailaddressEmpty_ThrowException()
        {
            //given

            //when
            Assert.Throws<EmailaddressException>(() => new Person("", _name, _firstname, _phonenumber, _languages));

            //then
            //throws exception
        }

        [Test]
        public void Constructor_EmailaddressBadFormat_ThrowException()
        {
            //given

            //when
            Assert.Throws<EmailaddressException>(() => new Person("badFormatEmailaddress", _name, _firstname, _phonenumber, _languages));

            //then
            //throws exception
        }

        [Test]
        public void Languages_AddFirstLanguage_GetCorrectUniqueLanguage()
        {
            //given
            string expectedLanguage = "French";
            List<string> expectedLanguages = new List<string>() {expectedLanguage };

            //when
            _person.Languages = expectedLanguages;

            //then
            Assert.AreEqual(expectedLanguage, _person.Languages[0]);
        }

        [Test]
        public void Languages_AddMultipleLanguagesAtOnce_GetCorrectListOfLanguages()
        {
            //given
            List<string> expectedLanguages = new List<string>() { "French", "Spanish", "German" };

            //when
            _person.Languages = expectedLanguages;

            //then
            Assert.AreEqual(expectedLanguages.Count, _person.Languages.Count);
            foreach(string expectedLanguage in expectedLanguages)
            {
                bool languageExists = false;
                if(_person.Languages.Contains(expectedLanguage))
                {
                    languageExists = true;
                }
                Assert.IsTrue(languageExists);
            }
        }

        [Test]
        public void Languages_AddMultipleLanguagesInExistingLanguagesList_GetCorrectListOfLanguages()
        {
            //given
            List<string> initialLanguages = new List<string>() { "French", "Spanish", "German" };
            List<string> additionnalLanguages = new List<string>() { "Vietnamese"};
            List<string> expectedLanguages = new List<string>();
            expectedLanguages.AddRange(initialLanguages);
            expectedLanguages.AddRange(additionnalLanguages);
            _person.Languages = initialLanguages;
            Assert.AreEqual(initialLanguages.Count, _person.Languages.Count);

            //when
            _person.Languages = additionnalLanguages;

            //then
            Assert.AreEqual(expectedLanguages.Count, _person.Languages.Count);
            foreach (string expectedLanguage in expectedLanguages)
            {
                bool languageExists = false;
                if (_person.Languages.Contains(expectedLanguage))
                {
                    languageExists = true;
                }
                Assert.IsTrue(languageExists);
            }
        }

        [Test]
        public void Languages_AddMultipleLanguagesInExistingLanguagesListWithDuplicate_GetCorrectListOfLanguages()
        {
            //given
            List<string> initialLanguages = new List<string>() { "French", "Spanish", "German" };
            List<string> additionnalLanguages = new List<string>() { "Vietnamese" , "French" };
            List<string> expectedLanguages = new List<string>();
            expectedLanguages.AddRange(initialLanguages);
            expectedLanguages.Add("Vietnamese");
            _person.Languages = initialLanguages;
            Assert.AreEqual(initialLanguages.Count, _person.Languages.Count);

            //when
            _person.Languages = additionnalLanguages;

            //then
            Assert.AreEqual(expectedLanguages.Count, _person.Languages.Count);
            foreach (string expectedLanguage in expectedLanguages)
            {
                bool languageExists = false;
                if (_person.Languages.Contains(expectedLanguage))
                {
                    languageExists = true;
                }
                Assert.IsTrue(languageExists);
            }
        }
    }
}