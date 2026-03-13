using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Windows.Controls;
using Wpf_14.Pages;

namespace UnitTestProject_Auth
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AuthTestSuccess() 
        {
        }

        [TestMethod]
        public void AuthTestFail() 
        {
            var page = new AuthorizationPage();
            Assert.IsFalse(page.Auth("", ""));
            Assert.IsFalse(page.Auth("ewe", "123"));
            Assert.IsFalse(page.Auth("qwe", "ewe"));
        }
    }
}
