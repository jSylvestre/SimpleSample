using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;

namespace SimpleSample.Test
{
    public class AutoPersistenceModelGenerator
    {
        public virtual AutoPersistenceModel GenerateFromAssembly(Assembly domainObjectAssembly)
        {
            var mappings = AutoMap.Assembly(domainObjectAssembly, new CustomMappingConfiguration());

            SetAutoPersistenceModelDefaults(mappings);

            return mappings;
        }

        public virtual AutoPersistenceModel GenerateFromAssembly<TClassInDomainObjectAssembly, TClassInMappingAssembly>()
        {
            var mappings = AutoMap.AssemblyOf<TClassInDomainObjectAssembly>(new CustomMappingConfiguration());

            SetAutoPersistenceModelDefaults(mappings);

            mappings.UseOverridesFromAssemblyOf<TClassInMappingAssembly>();

            return mappings;
        }

        private void SetAutoPersistenceModelDefaults(AutoPersistenceModel mappings)
        {
            mappings.Conventions.Setup(GetConventions());
            mappings.IgnoreBase<DomainObject>();
            mappings.IgnoreBase(typeof(DomainObjectWithTypedId<>));
        }

        public virtual Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                AddPrimaryKeyConvention(c);
                AddHasManyConvention(c);
                AddManyToManyConvention(c);
                AddReferenceConvention(c);
                AddTableNameConvention(c);
            };
        }

        public virtual void AddPrimaryKeyConvention(IConventionFinder conventionFinder)
        {
            conventionFinder.Add<PrimaryKeyConvention>();
        }

        public virtual void AddHasManyConvention(IConventionFinder conventionFinder)
        {
            conventionFinder.Add<HasManyConvention>();
        }

        public virtual void AddManyToManyConvention(IConventionFinder conventionFinder)
        {
            conventionFinder.Add<ManyToManyConvention>();
        }

        public virtual void AddTableNameConvention(IConventionFinder conventionFinder)
        {
            conventionFinder.Add<TableNameConvention>();
        }

        public virtual void AddReferenceConvention(IConventionFinder conventionFinder)
        {
            conventionFinder.Add<ReferenceConvention>();
        }
    }
}
