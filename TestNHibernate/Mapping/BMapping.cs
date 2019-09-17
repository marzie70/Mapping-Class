using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace TestNHibernate.Mapping
{
    public class BMapping : IAutoMappingOverride<B>
    {
        public void Override(AutoMapping<B> mapping)
        {
            mapping.Id(m => m.Id).Column("BId");
            mapping.Map(m => m.FirstName).Column("Name");
            mapping.Map(m => m.LastName).Column("FamilyName");
            mapping.HasMany(m => m.Cs).Cascade.All();
        }
    }
}
