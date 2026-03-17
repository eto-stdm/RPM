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
            var page = new AuthorizationPage();
            Assert.IsTrue(page.Auth("ewe", "ewe"));
            Assert.IsTrue(page.Auth("a", "a"));
            Assert.IsTrue(page.Auth("d3", "3d"));
            Assert.IsTrue(page.Auth("qwe", "qwe"));
            Assert.IsTrue(page.Auth("ew", "ew"));
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
