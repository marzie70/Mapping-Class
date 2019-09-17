using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using NHibernate;

namespace TestNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    //var A1 = new A
                    //{
                    //    Name = "Marzie"
                    //};

                    var B1 = new B
                    {
                        FirstName = "Sara",
                        LastName = "Sanaei"

                    };
                    var C1 = new C
                    {
                        Name = "Asus",
                        Price = 30000
                    };
                    B1.Cs.Add(C1);/* many-to-one or one-to-many */

                    var D1 = new D
                    {
                        Code = 15,
                        Date = "12/01/2013"
                    };
                    var A1 = new A
                    {
                        Name = "Marzie",
                        D = D1
                    };

                    session.Save(A1);
                    session.Save(D1);
                    session.Save(B1);/* save both(B1,C1)*/
                    transaction.Commit();
                    Console.WriteLine("A Created: " + A1.Name + "\t" + A1.Id);
                    Console.WriteLine("B Created: " + B1.FirstName + "\t" + B1.LastName + "\t" + B1.Id);
                    Console.WriteLine("C Created: " + C1.Name + "\t" + C1.Price + "\t" + C1.Id);
                    Console.WriteLine("D Created: " + D1.Code + "\t" + D1.Date + "\t" + D1.Id);
                }

                Console.ReadKey();

            }
        }
    }
}
