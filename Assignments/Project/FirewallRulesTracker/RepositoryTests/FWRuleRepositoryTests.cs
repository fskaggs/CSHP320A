using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Tests
{
    [TestClass()]
    public class FWRuleRepositoryTests
    {
        FWRuleRepository fwRepo = new FWRuleRepository();

        [TestMethod()]
        public void AddTest()
        {
            var rule = new FWRuleEntity()
            {
                //FWRuleID      = 1234,
                RequestorID   = 1,
                RequestorName = "Fred",
                ServiceName   = "Canary",
                RoleName      = "Svc",
                Direction     = DataDirection.Inbound,
                Port          = 443,
                Protocol      = ProtocolType.TCP,
                RoleID        = 2,
                SRA           = "SRA06052021",
                WorkItem      = "VSO93533",
                Version       = 1
            };

            fwRepo.Add(rule);
            var ruleFromDB = fwRepo.Get(14);
            Assert.IsNotNull(ruleFromDB);
            Assert.AreEqual(14, ruleFromDB.FWRuleID);
            Assert.AreEqual(rule.RequestorID,   ruleFromDB.RequestorID);
            Assert.AreEqual(rule.RequestorName, ruleFromDB.RequestorName);
            Assert.AreEqual(rule.ServiceName  , ruleFromDB.ServiceName  );
            //Assert.AreEqual(rule.RoleName     , ruleFromDB.RoleName     );
            Assert.AreEqual(rule.Direction    , ruleFromDB.Direction    );
            Assert.AreEqual(rule.Port         , ruleFromDB.Port         );
            Assert.AreEqual(rule.Protocol     , ruleFromDB.Protocol     );
            Assert.AreEqual(rule.RoleID       , ruleFromDB.RoleID       );
            Assert.AreEqual(rule.SRA          , ruleFromDB.SRA          );
            Assert.AreEqual(rule.WorkItem     , ruleFromDB.WorkItem     );
            Assert.AreEqual(rule.Version      , ruleFromDB.Version      );
        }
    }
}