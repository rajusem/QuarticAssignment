using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Quartic.Assignement.BusinessLogic;
using Quartic.Assignment.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ValueType = Quartic.Assignment.Model.ValueType;

namespace Quartic.Assignment.BusinessLogic.Test
{
    [TestClass]
    public class RuleEngineTest
    {
        private List<SignalModel> signals;
        private RuleEngine ruleEngine;

        public RuleEngineTest()
        {
            var JSON = System.IO.File.ReadAllText(System.Environment.CurrentDirectory + "/InputData/raw_signal.json");
            signals = JsonConvert.DeserializeObject<List<SignalModel>>(JSON);
            ruleEngine = new RuleEngine();
        }

        [TestMethod]
        public void Signal_With_String_Test()
        {
            List<SignalRule> signalRules = new List<SignalRule>();
            signalRules.Add(
                new SignalRule
                {
                    SignalName = "ATL2",
                    AvailableRules = new List<Rule>
                    {
                        new Rule
                        {
                            ValueType = ValueType.String,
                            Operation = Operation.Equal,
                            Value = Constants.Low
                        }
                    }
                });

            List<SignalModel> badData = ruleEngine.ValidateSignalAgainstRule(signals, signalRules);

            Assert.IsTrue(badData.Count == 6);
        }


        [TestMethod]
        public void Same_Signal_With_String_And_Integer_Test()
        {
            List<SignalRule> signalRules = new List<SignalRule>();
            signalRules.Add(
                new SignalRule
                {
                    SignalName = "ATL1",
                    AvailableRules = new List<Rule>
                    {
                        new Rule
                        {
                            ValueType = ValueType.String,
                            Operation = Operation.Equal,
                            Value = Constants.Low
                        },
                        new Rule
                        {
                            ValueType = ValueType.Integer,
                            Operation = Operation.GreaterThan,
                            Value = "70"
                        }
                    }
                });

            List<SignalModel> badData = ruleEngine.ValidateSignalAgainstRule(signals, signalRules);

            Assert.IsTrue(badData.Count == 16);
        }


        [TestMethod]
        public void Different_Signal_With_String_And_Integer_Test()
        {
            List<SignalRule> signalRules = new List<SignalRule>();
            signalRules.Add(
                new SignalRule
                {
                    SignalName = "ATL1",
                    AvailableRules = new List<Rule>
                    {
                        new Rule
                        {
                            ValueType = ValueType.String,
                            Operation = Operation.Equal,
                            Value = Constants.High
                        }
                    }
                });
           signalRules.Add(
                new SignalRule
                 {
                     SignalName = "ATL8",
                     AvailableRules = new List<Rule>
                    {
                        new Rule
                        {
                            ValueType = ValueType.Integer,
                            Operation = Operation.LessThan,
                            Value = "80"
                        }
                    }
                 }
                );

            List<SignalModel> badData = ruleEngine.ValidateSignalAgainstRule(signals, signalRules);

            Assert.IsTrue(badData.Count == 18);
        }



        [TestMethod]
        public void Signal_With_DateTime_Test()
        {
            List<SignalRule> signalRules = new List<SignalRule>();
            signalRules.Add(
                new SignalRule
                {
                    SignalName = "ATL9",
                    AvailableRules = new List<Rule>
                    {
                        new Rule
                        {
                            ValueType = ValueType.Datetime,
                            Operation = Operation.LessThan,
                            Value = "2016-10-10 03:10:10"
                        }
                    }
                });
            signalRules.Add(
                 new SignalRule
                 {
                     SignalName = "ATL3",
                     AvailableRules = new List<Rule>
                     {
                        new Rule
                        {
                            ValueType = ValueType.Datetime,
                            Operation = Operation.GreaterThan,
                            Value = "2017-10-10 03:10:10"
                        }
                     }
                 });

            List<SignalModel> badData = ruleEngine.ValidateSignalAgainstRule(signals, signalRules);

            Assert.IsTrue(badData.Count == 38);
        }


    }
}
