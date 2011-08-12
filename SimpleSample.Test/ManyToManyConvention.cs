using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace SimpleSample.Test
{
    public class ManyToManyConvention : IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {
            var entityName = instance.EntityType.Name;
            var childName = instance.ChildType.Name;

            var tableName = string.Format("{0}X{1}", entityName, childName);

            instance.Table(tableName);
            instance.Key.Column(entityName + "ID");
            instance.Relationship.Column(childName + "ID");
        }
    }
}
