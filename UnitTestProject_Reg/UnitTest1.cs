using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Controls;
using Wpf_14.Pages;

namespace UnitTestProject_Reg
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RegTestSuccess()
        {
            var page = new RegistratonPage();
            Assert.IsTrue(page.Registr("daydream", "myau:3", "name", "surname", "30-10-2007"));
            Assert.IsTrue(page.Registr("night", "bop", "uwu", "beep", "05-09-2001"));
            Assert.IsTrue(page.Registr("bomp", "bemp", "huh", "hmm", "14-12-2010"));
        }

        [TestMethod]
        public void RegTestFail() 
        {
            var page = new RegistratonPage();
            Assert.IsFalse(page.Registr("", "", "", "", ""));
            Assert.IsFalse(page.Registr("test", "test", "test", "test", "123"));
            Assert.IsFalse(page.Registr("ifgfosajorgjposdjkgposdkfjpogkpsdokghpowerkhksrklhp[sekh[kl[pwelr", "jfadklhfsahgkjsahgkjhsafkjghkjsdhgkjfhskjghksfjdghkljsadfoghaokglka", "f", "f", "13-07-2007"));
        }

    }
}
