using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace TestNHibernate.Mapping
{
    public class DMapping : IAutoMappingOverride<D>
    {
        public void Override(AutoMapping<D> mapping)
        {
            mapping.Id(m => m.Id);
            mapping.Map(m => m.Code);
            mapping.Map(m => m.Date);
            //mapping.HasOne(m => m.A);
            //mapping.References(m => m.A);

        }
    }
}
