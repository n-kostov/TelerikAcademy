namespace CalendarSystemTests
{
    using System;
    using CalendarSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandParseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCommandParse_InvalidCommand()
        {
            string input = "End";
            Command command = Command.Parse(input);
        }

        [TestMethod]
        public void TestCommandParse_ListEvents_NoEventsAtAll()
        {
            string input = "AddEvent 2012-01-21T20:00:00 | party Viki | home";
            Command actualCommand = Command.Parse(input);
            Command expectedCommand = new Command(
                "AddEvent",
                new string[] { "2012-01-21T20:00:00", "party Viki", "home" });

            bool areCommandParametersEqual = true;
            for (int i = 0; i < actualCommand.Parameters.Length; i++)
            {
                if (actualCommand.Parameters[i] != expectedCommand.Parameters[i])
                {
                    areCommandParametersEqual = false;
                    break;
                }
            }

            Assert.IsTrue(actualCommand.Name == expectedCommand.Name &&
                areCommandParametersEqual);
        }

        [TestMethod]
        public void TestCommandParse_AddEvent_TwoParameters()
        {
            string input = "AddEvent 2012-03-26T09:00:00 | C# exam";
            Command actualCommand = Command.Parse(input);
            Command expectedCommand = new Command(
                "AddEvent",
                new string[] { "2012-03-26T09:00:00", "C# exam" });

            bool areCommandParametersEqual = true;
            for (int i = 0; i < actualCommand.Parameters.Length; i++)
            {
                if (actualCommand.Parameters[i] != expectedCommand.Parameters[i])
                {
                    areCommandParametersEqual = false;
                    break;
                }
            }

            Assert.IsTrue(actualCommand.Name == expectedCommand.Name &&
                areCommandParametersEqual);
        }

        [TestMethod]
        public void TestCommandParse_ListEvents()
        {
            string input = "ListEvents 2012-01-07T20:00:00 | 10";
            Command actualCommand = Command.Parse(input);
            Command expectedCommand = new Command(
                "ListEvents",
                new string[] { "2012-01-07T20:00:00", "10" });

            bool areCommandParametersEqual = true;
            for (int i = 0; i < actualCommand.Parameters.Length; i++)
            {
                if (actualCommand.Parameters[i] != expectedCommand.Parameters[i])
                {
                    areCommandParametersEqual = false;
                    break;
                }
            }

            Assert.IsTrue(actualCommand.Name == expectedCommand.Name &&
                areCommandParametersEqual);
        }

        [TestMethod]
        public void TestComamndParse_DeleteEvents()
        {
            string input = "DeleteEvents My granny's bushes";
            Command actualCommand = Command.Parse(input);
            Command expectedCommand = new Command(
                "DeleteEvents",
                new string[] { "My granny's bushes" });

            bool areCommandParametersEqual = true;
            for (int i = 0; i < actualCommand.Parameters.Length; i++)
            {
                if (actualCommand.Parameters[i] != expectedCommand.Parameters[i])
                {
                    areCommandParametersEqual = false;
                    break;
                }
            }

            Assert.IsTrue(actualCommand.Name == expectedCommand.Name &&
                areCommandParametersEqual);
        }

        [TestMethod]
        public void TestComamndParse_RandomCommand_ManyParameters()
        {
            string input = "I have | too | many | parameters | for | you | to | check";
            Command actualCommand = Command.Parse(input);
            Command expectedCommand = new Command(
                "I",
                new string[] { "have", "too", "many", "parameters", "for", "you", "to", "check" });

            bool areCommandParametersEqual = true;
            for (int i = 0; i < actualCommand.Parameters.Length; i++)
            {
                if (actualCommand.Parameters[i] != expectedCommand.Parameters[i])
                {
                    areCommandParametersEqual = false;
                    break;
                }
            }

            Assert.IsTrue(actualCommand.Name == expectedCommand.Name &&
                areCommandParametersEqual);
        }
    }
}
