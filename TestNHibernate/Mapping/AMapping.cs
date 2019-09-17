using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Classes;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace TestNHibernate.Mapping
{
    public class AMapping : IAutoMappingOverride<A>
    {
        public void Override(AutoMapping<A> mapping)
        {
            mapping.Id(m => m.Id)/*.GeneratedBy.Assigned()*/;
            mapping.Map(m => m.Name).Column("Title");
            //mapping.HasOne(m => m.D);
            mapping.References(m => m.D).Nullable();
        }
    }
}
