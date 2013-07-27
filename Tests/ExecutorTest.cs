using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlScriptExecuter;

namespace Tests {
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ExecutorTest {
        public ExecutorTest() {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private const string connectionString = "put connection string here";
        private const string sampleFullNameFileHere = "Tests.ScriptsFiles.script.sql";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExecuteScript_Whitout_ConnectionString() {
            MysqlScriptExecutor executor = new MysqlScriptExecutor();
            executor.ExecuteScripts();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExecuteScript_Whitout_ScriptsFiles() {
            MysqlScriptExecutor executor = new MysqlScriptExecutor();
            executor.ConnectionString = connectionString;
            executor.ExecuteScripts();
        }

        [TestMethod]
        public void ExecuteScript() {
            MysqlScriptExecutor executor = new MysqlScriptExecutor();
            executor.ConnectionString = connectionString;
            executor.ScriptsFiles = new string[] { sampleFullNameFileHere };
            executor.ExecuteScripts();
        }
    } //class
}
