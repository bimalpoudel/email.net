using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business;
using configs;
using System.IO;

namespace business.tests
{
    [TestClass()]
    public class attachmentsTests
    {
        [TestMethod()]
        [TestCategory("Attachment Test")]
        public void attachmentDoesNotExistTest()
        {
            string filename = @"d:\\testr.zip";

            email ea = new email();
            bool attachable = ea.attachableFile(filename);

            Assert.IsFalse(attachable);
        }

        [TestMethod()]
        [TestCategory("Attachment Test")]
        public void attachmentExistsTest()
        {
            string filename = @"d:\\test.7z";

            email ea = new email();
            bool attachable = ea.attachableFile(filename);

            Assert.IsTrue(attachable);
        }
    }
}