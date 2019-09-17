using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class B
    {
        public B()
        {
            Id = Guid.NewGuid();
            Cs = new List<C>();
        }
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual ICollection<C> Cs { get; set; }
    }
}
