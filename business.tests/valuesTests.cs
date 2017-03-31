using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business;
using configs;

namespace business.tests
{
    [TestClass()]
    public class valuesTests
    {
        private configurations c;

        public valuesTests()
        {
            c = new configurations();
        }

        [TestMethod()]
        [TestCategory("Configuration Value Test")]
        public void fromNameTest()
        {
            Assert.IsNotNull(c.fromName);
            Assert.AreNotEqual("", c.fromName);
        }

        [TestMethod()]
        [TestCategory("Configuration Value Test")]
        public void fromEmailTest()
        {
            Assert.IsNotNull(c.fromEmail);
            Assert.AreNotEqual("", c.fromEmail);
        }

        [TestMethod()]
        [TestCategory("Configuration Value Test")]
        public void toNameTest()
        {
            Assert.IsNotNull(c.toName);
            Assert.AreNotEqual("", c.toName);
        }

        [TestMethod()]
        [TestCategory("Configuration Value Test")]
        public void toEmailTest()
        {
            Assert.IsNotNull(c.toEmail);
            Assert.AreNotEqual("", c.toEmail);
        }

        [TestMethod()]
        [TestCategory("Configuration Value Test")]
        public void usernameTest()
        {
            Assert.IsNotNull(c.username);
            Assert.AreNotEqual("", c.username);
        }

        [TestMethod()]
        [TestCategory("Configuration Value Test")]
        public void passwordTest()
        {
            Assert.IsNotNull(c.password);
            Assert.AreNotEqual("", c.password);
        }

        [TestMethod()]
        [TestCategory("Configuration Value Test")]
        public void hostnameTest()
        {
            Assert.IsNotNull(c.hostname);
            Assert.AreNotEqual("", c.hostname);
        }

        [TestMethod()]
        [TestCategory("Configuration Value Test")]
        public void portnumberTest()
        {
            Assert.IsNotNull(c.portnumber);
            Assert.AreNotEqual("", c.portnumber);
        }
    }
}