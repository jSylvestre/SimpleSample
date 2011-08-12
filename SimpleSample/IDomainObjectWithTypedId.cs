using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleSample.Test
{
    /// <summary>
    /// This serves as a base interface for <see cref="DomainObjectWithTypedId{IdT}"/> and 
    /// <see cref="DomainObject"/>. Also provides a simple means to develop your own base entity.
    /// </summary>
    public interface IDomainObjectWithTypedId<IdT>
    {
        IdT Id { get; }
        bool IsTransient();
        IEnumerable<PropertyInfo> GetSignatureProperties();
    }
}
