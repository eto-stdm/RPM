using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using Wpf_14.Pages;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AuthTest()
        {
            var page = new AuthorizationPage();
        }
    }
}
