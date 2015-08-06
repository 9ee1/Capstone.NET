using Gee.External.Capstone;
using NUnit.Framework;

namespace Tests.Gee.External.Capstone
{
    [TestFixture]
    public sealed class TestExports
    {
        [Test]
        public void TestApiVersion()
        {
            int major;
            int minor;
            uint compositeVersion = CapstoneImport.GetApiVersion(out major, out minor);

            Assert.AreEqual(((((uint)major) << 8) | (uint)minor), compositeVersion,
                string.Format("Composite version 0x{0:X8} doesn't match major 0x{1:X8} and minor 0x{2:X2}",
                    compositeVersion, major, minor));
            System.Console.WriteLine(
                string.Format("Running on API version {0}.{1}", major, minor));
            return;
        }

        [Test]
        public void TestErrorTexts()
        {
            int minTestedCode = int.MaxValue;
            int maxTestedCode = int.MinValue;
            // Find min and max error codes.
            foreach(CapstoneImport.ErrorCode testedCode in System.Enum.GetValues(typeof(CapstoneImport.ErrorCode))) {
                minTestedCode = System.Math.Min(minTestedCode, (int)testedCode);
                maxTestedCode = System.Math.Max(maxTestedCode, (int)testedCode);
            }
            // Retrieve unknown error text and make sure it is not null.
            Assert.AreNotEqual(minTestedCode, int.MinValue);
            string unknownErrorCodeString = CapstoneImport.GetErrorText((CapstoneImport.ErrorCode)(minTestedCode - 1));
            // Make sure every known error code has an associated error text
            // and that this text is different from the one for unknown errors.
            foreach (CapstoneImport.ErrorCode testedCode in System.Enum.GetValues(typeof(CapstoneImport.ErrorCode))) {
                switch (testedCode) {
                    // These two codes are known not to return valid error text for now.
                    case CapstoneImport.ErrorCode.UnsupportedATTSyntax:
                    case CapstoneImport.ErrorCode.UnsupportedIntelSyntax:
                        continue;
                    default:
                        break;
                }
                string errorText = CapstoneImport.GetErrorText(testedCode);
                Assert.NotNull(errorText,
                    string.Format("Failed to retrieve error text for error code '{0}'.", testedCode));
                Assert.AreNotEqual(errorText, unknownErrorCodeString,
                    string.Format("Error code '{0}' appears to be unknown.'.", testedCode));
                System.Console.WriteLine(
                    string.Format("Error code '{0}' successfully checked.'.", testedCode));
            }
            return;
        }
    }
}
