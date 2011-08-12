using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace SimpleSample.Test
{
    public class CustomMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterfaces().Any(x =>
                                            x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDomainObjectWithTypedId<>));
        }

        public override bool ShouldMap(Member member)
        {
            return base.ShouldMap(member) && member.CanWrite;
        }

        public override bool AbstractClassIsLayerSupertype(Type type)
        {
            return type == typeof(DomainObjectWithTypedId<>) || type == typeof(DomainObject);
        }

        public override bool IsId(Member member)
        {
            return member.Name == "Id";
        }
    }
}
