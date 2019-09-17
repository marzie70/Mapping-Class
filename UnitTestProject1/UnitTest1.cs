using System;
using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNHibernate;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    //var A1 = new A
                    //{
                    //    Name = "Marzie",
                    //    D = D1

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
                    B1.Cs.Add(C1);

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
                    session.Save(B1);
                    session.Save(D1);
                    transaction.Commit();

                    var result1 = session.Get<A>(A1.Id);
                    Assert.AreEqual(A1.Name, result1.Name);

                    var result2 = session.Get<B>(B1.Id);
                    Assert.AreEqual(B1.FirstName, result2.FirstName);
                    Assert.AreEqual(B1.LastName, result2.LastName);

                    var result3 = session.Get<C>(C1.Id);
                    Assert.AreEqual(C1.Name, result3.Name);
                    Assert.AreEqual(C1.Price, result3.Price);

                    var result4 = session.Get<D>(D1.Id);
                    Assert.AreEqual(D1.Code, result4.Code);
                    Assert.AreEqual(D1.Date, result4.Date);


                }
            }
        }
    }
}
