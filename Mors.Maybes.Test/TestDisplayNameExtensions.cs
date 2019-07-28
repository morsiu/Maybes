using NUnit.Framework;

namespace Mors.Maybes.Test
{
    internal static class TestDisplayNameExtensions
    {
        public static TestFixtureData WithArgsDisplayName(
            this TestFixtureData data,
            string name)
        {
            return data.SetArgDisplayNames(CompatibleDisplayName(name));
        }

        public static TestCaseData WithArgsDisplayName(
            this TestCaseData data,
            string name)
        {
            return data.SetArgDisplayNames(CompatibleDisplayName(name));
        }

        private static string CompatibleDisplayName(string name)
        {
            return
                name.Replace("[", "⦋")
                    .Replace("]", "⦌")
                    .Replace("(", "❨")
                    .Replace(")", "❩");
        }
    }
}