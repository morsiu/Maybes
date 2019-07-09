using Mors.Maybes.Test.Extensions;
using NUnit.Framework.Constraints;

namespace Mors.Maybes.Test
{
    internal sealed class Assert : NUnit.Framework.Assert
    {
        public static void That(
            RecordedValueDelegate del,
            IResolveConstraint expr)
        {
            That(del, expr, null, null);
        }

        public static void That(
            RecordedValueDelegate del,
            IResolveConstraint expr,
            string message,
            params object[] args)
        {
            NUnit.Framework.Assert.That(del, expr, message, args);
        }
    }
}