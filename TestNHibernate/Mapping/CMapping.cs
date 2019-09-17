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
    public class CMapping : IAutoMappingOverride<C>
    {
        public void Override(AutoMapping<C> mapping)
        {
            mapping.Id(m => m.Id).Column("CId");
            mapping.Map(m => m.Name).Column("Number");
            mapping.Map(m => m.Price).Column("Price");
            //mapping.References(m => m.B).Cascade.All();

        }
    }
}
