using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SimpleSample.Test
{
    public interface IMappingConfiguration
    {
        ISessionFactory BuildSessionFactory();
    }
}
