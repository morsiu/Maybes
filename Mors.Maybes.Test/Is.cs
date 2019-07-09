using Mors.Maybes.Test.Extensions;
using NUnit.Framework.Constraints;

namespace Mors.Maybes.Test
{
    internal sealed class Is : NUnit.Framework.Is
    {
        public static ConstraintExpression RecordedValue =>
            new ConstraintExpression().Append(new RecordedValueOperator());
    }
}