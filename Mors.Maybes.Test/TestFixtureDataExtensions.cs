using NUnit.Framework;

namespace Mors.Maybes.Test
{
    internal static class TestFixtureDataExtensions
    {
        public static TestFixtureData WithDisplayName(
            this TestFixtureData data,
            string name) =>
            data.SetArgDisplayNames(
                name
                    .Replace("(", "_")
                    .Replace(")", "_"));
    }
}