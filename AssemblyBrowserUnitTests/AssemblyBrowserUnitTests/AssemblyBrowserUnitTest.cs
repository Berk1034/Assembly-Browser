using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyBrowserLibrary;

namespace AssemblyBrowserUnitTests
{
    [TestClass]
    public class AssemblyBrowserUnitTest
    {
        private AssemblyBrowserModel assemblyBrowser;
        [TestInitialize]
        public void Initialize()
        {
            assemblyBrowser = new AssemblyBrowserModel(AppDomain.CurrentDomain.BaseDirectory + "\\AssemblyBrowserLibrary.dll");
        }

        [TestMethod]
        public void DLLLoad_ShouldLoadDLL()
        {
            Assert.IsNotNull(assemblyBrowser);
        }

        [TestMethod]
        public void NamespaceParse_ShouldReturnOneNamespace()
        {
            Assert.AreEqual(1, assemblyBrowser.Namespaces.Count);
        }

        [TestMethod]
        public void ClassParse_ShouldReturnAssemblyBrowserModelClass()
        {
            Assert.AreEqual("public class AssemblyBrowserModel", assemblyBrowser.Namespaces[0].Classes[0].Name);
        }

        [TestMethod]
        public void ClassParse_ShouldReturnOneConstructor()
        {
            Assert.AreEqual(1, assemblyBrowser.Namespaces[0].Classes[0].Constructors.Count);
        }

        [TestMethod]
        public void ClassParse_ShouldReturnThreeFields()
        {
            Assert.AreEqual(3, assemblyBrowser.Namespaces[0].Classes[0].Fields.Count);
        }

        [TestMethod]
        public void ClassParse_ShouldReturnThreeMethods()
        {
            Assert.AreEqual(3, assemblyBrowser.Namespaces[0].Classes[0].Methods.Count);
        }
    }
}
