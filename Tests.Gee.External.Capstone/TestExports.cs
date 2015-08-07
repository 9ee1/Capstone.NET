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
            foreach (DisassembleErrorCode testedCode in System.Enum.GetValues(typeof(DisassembleErrorCode))) {
                minTestedCode = System.Math.Min(minTestedCode, (int)testedCode);
                maxTestedCode = System.Math.Max(maxTestedCode, (int)testedCode);
            }
            // Retrieve unknown error text and make sure it is not null.
            Assert.AreNotEqual(minTestedCode, int.MinValue);
            string unknownErrorCodeString = CapstoneImport.GetErrorText((DisassembleErrorCode)(minTestedCode - 1));
            // Make sure every known error code has an associated error text
            // and that this text is different from the one for unknown errors.
            foreach (DisassembleErrorCode testedCode in System.Enum.GetValues(typeof(DisassembleErrorCode))) {
                switch (testedCode) {
                    // These two codes are known not to return valid error text for now.
                    case DisassembleErrorCode.UnsupportedATTSyntax:
                    case DisassembleErrorCode.UnsupportedIntelSyntax:
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

        [Test]
        public void TestFeatureSupport()
        {
            System.Console.WriteLine("Diet mode is {0}.",
                CapstoneImport.IsFeatureSupported(CapstoneImport.Feature.Diet)
                    ? "enabled"
                    : "disabled");
            System.Console.WriteLine("All architectures are {0}.",
                CapstoneImport.IsFeatureSupported(CapstoneImport.Feature.All)
                    ? "enabled"
                    : "not enabled");
            System.Console.WriteLine("X86 reduce mode is {0}.",
                CapstoneImport.IsFeatureSupported(CapstoneImport.Feature.X86ReduceMode)
                    ? "enabled"
                    : "disabled");
            CapstoneImport.Feature[] values =
                (CapstoneImport.Feature[])System.Enum.GetValues(typeof(CapstoneImport.Feature));

            System.Array.Sort(values, delegate(CapstoneImport.Feature x, CapstoneImport.Feature y)
                {
                    int xInt = (int)x;
                    int yInt = (int)y;

                    return (xInt == yInt)
                        ? 0
                        : (xInt > yInt)
                            ? 1
                            : -1;
                });
            int lastArchitectureIndex = -1;
            for (int index = 0; index < values.Length; index++) {
                CapstoneImport.Feature scannedFeature = values[index];

                if (CapstoneImport.Feature.All == scannedFeature) { break; }
                lastArchitectureIndex = index;
                System.Console.WriteLine("{0} feature is {1}.",
                    scannedFeature,
                    CapstoneImport.IsFeatureSupported(scannedFeature)
                        ? "enabled"
                        : "disabled");
            }
            Assert.Greater(lastArchitectureIndex, -1,
                "There is no defined architecture in CapstoneImport.Feature enumeration");
            int firstUndefinedArchitecture = lastArchitectureIndex + 1;
            Assert.False(CapstoneImport.IsFeatureSupported((CapstoneImport.Feature)firstUndefinedArchitecture),
                string.Format("Capstone DLL supports architecture {0} which is not defined in CapstoneImport.Feature enumeration.",
                    firstUndefinedArchitecture));
        }
    }
}
