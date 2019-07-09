using NUnit.Framework.Constraints;

namespace Mors.Maybes.Test.Extensions
{
    public sealed class RecordedValueOperator : PrefixOperator
    {
        public RecordedValueOperator()
        {
            left_precedence = right_precedence = 1;
        }

        public override IConstraint ApplyPrefix(IConstraint constraint)
        {
            return new RecordedValueConstraint(constraint);
        }
    }
}