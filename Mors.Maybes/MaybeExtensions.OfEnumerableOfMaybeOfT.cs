using System.Collections.Generic;
using System.Linq;

namespace Mors.Maybes
{
    public static partial class MaybeExtensions
    {
        public static IEnumerable<T> WhereSome<T>(
            this IEnumerable<Maybe<T>> value)
        {
            return value.Where(x => x.HasValue).Select(x => x.Value);
        }
    }
}