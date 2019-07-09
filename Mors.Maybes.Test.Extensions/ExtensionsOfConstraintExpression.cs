using NUnit.Framework.Constraints;

namespace Mors.Maybes.Test.Extensions
{
    public static class ExtensionsOfConstraintExpression
    {
        public static ConstraintExpression RecordedValue(this ConstraintExpression e)
        {
            return e.Append(new RecordedValueOperator());
        }
    }
}