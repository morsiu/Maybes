using System;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace Mors.Maybes.Test.Extensions
{
    public sealed class RecordedValueConstraint : PrefixConstraint
    {
        public RecordedValueConstraint(IResolveConstraint baseConstraint)
            : base(baseConstraint)
        {
            DescriptionPrefix = "recorded value";
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (!(actual is RecordedValueDelegate action))
            {
                throw new Exception($"Actual value must be a {nameof(RecordedValueDelegate)}");
            }

            var recordedValue = new RecordedValue();
            using (new TestExecutionContext.IsolatedContext())
            {
                action(recordedValue);
            }

            var (hasValue, value) = recordedValue;

            return !hasValue
                ? BaseConstraint.ApplyTo(new NoValue())
                : BaseConstraint.ApplyTo(value);
        }

        private sealed class NoValue
        {
            public override string ToString() => "no value";
        }
    }
}