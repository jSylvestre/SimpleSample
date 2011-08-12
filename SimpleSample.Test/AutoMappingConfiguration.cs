using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHibernate;

namespace SimpleSample.Test
{
    public class AutoMappingConfiguration : IMappingConfiguration
    {
        private FluentConfiguration _fluentConfiguration;

        public static IMappingConfiguration CreateWithoutOverrides(Assembly mappingAssembly)
        {
            var autoPersistenceModel =
                new AutoPersistenceModelGenerator().GenerateFromAssembly(mappingAssembly);

            var configuration = Fluently.Configure()
                .Mappings(m => m.AutoMappings.Add(autoPersistenceModel));

            return new AutoMappingConfiguration { _fluentConfiguration = configuration };
        }

        public static IMappingConfiguration CreateWithOverrides(AutoPersistenceModel autoPersistenceModel)
        {
            var configuration = Fluently.Configure()
                .Mappings(m => m.AutoMappings.Add(autoPersistenceModel));

            return new AutoMappingConfiguration { _fluentConfiguration = configuration };
        }

        public static IMappingConfiguration CreateWithOverrides<TClassInDomainObjectAssembly, TClassInMappingAssembly>()
        {
            var autoPersistenceModel =
                new AutoPersistenceModelGenerator().GenerateFromAssembly
                    <TClassInDomainObjectAssembly, TClassInMappingAssembly>();

            var configuration = Fluently.Configure()
                .Mappings(m => m.AutoMappings.Add(autoPersistenceModel));

            return new AutoMappingConfiguration { _fluentConfiguration = configuration };
        }

        public ISessionFactory BuildSessionFactory()
        {
            return _fluentConfiguration.BuildSessionFactory();
        }
    }
}
