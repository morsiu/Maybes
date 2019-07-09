using System;

namespace Mors.Maybes.Test.Extensions
{
    public sealed class RecordedValue
    {
        private bool _hasValue;
        private object _value;

        public T Return<T>(in T @return)
        {
            return @return;
        }

        public RecordedValue Record(object value)
        {
            if (_hasValue)
            {
                throw new Exception("Recorded value has already been set.");
            }
            _value = value;
            _hasValue = true;
            return this;
        }

        public void Deconstruct(out bool hasValue, out object value)
        {
            hasValue = _hasValue;
            value = _value;
        }
    }
}