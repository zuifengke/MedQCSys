using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMRDBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMRDBLib.HerenHis;
using Heren.Common.Libraries;
namespace EMRDBLib.Tests
{
    [TestClass()]
    public class DiagnosisAccessTests
    {
        [TestInitialize]
        public void Initial()
        {
            SystemConfig.Instance.ConfigFile = SystemParam.Instance.ConfigFile;
        }
        [TestMethod()]
        public void GetListTest()
        {
            List<Diagnosis> lstDiagnosis = null;
            DiagnosisAccess.Instance.GetList("10030", "2015034788", ref lstDiagnosis);
            Assert.IsTrue(lstDiagnosis != null && lstDiagnosis.Count > 0);
            Assert.Fail();
        }
    }
}