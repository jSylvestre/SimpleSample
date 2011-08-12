using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using SimpleSample.Test;

namespace SimpleSample
{
    public class ExampleTable : DomainObject
    {
        public virtual int Id { get; set; }
        public virtual string Col1 { get; set; }
        public virtual string Col2 { get; set; }
    }

    public class ExampleTableMap : ClassMap<ExampleTable>
    {
        public ExampleTableMap()
        {
            Id(x => x.Id);
            Map(x => x.Col1);
            Map(x => x.Col2);
        }
    }
}
