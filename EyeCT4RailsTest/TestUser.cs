using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EyeCT4RailsBackend;
using ExtendedObservableCollection;
using System.Linq;

namespace EyeCT4RailsTest
{
    [TestClass]
    public class TestUser
    {
        [TestMethod]
        public void TestGet()
        {
            UserRepository a = new UserRepository(new UserMemoryContext(true), new GroupMemoryContext(true));
            ExtendedObservableCollection<User> b = a.UserRepo.Collection;
            List<User> c = TestData.GetUsers();

            for(int i = 0; i < b.Count; i ++)
            {
                Assert.AreEqual(b[i].ToString(), c[i].ToString());
            }
        }

        //[TestMethod]
        //public void TestInsert()
        //{
        //    UserRepository a = new UserRepository(new UserMemoryContext(true));
        //    int b = a.Get().Count;
        //    a.Insert(new User(1, "naam", "email", new Group(1)));
        //    int c = a.Get().Count;

        //    //check if insert has succeeded
        //    Assert.AreNotEqual(b, c);
        //}

        //[TestMethod]
        //public void TestUpdate()
        //{
        //    UserRepository a = new UserRepository(new UserMemoryContext(true));

        //    //get the id
        //    var b = a.Get()[0];
        //    string b_n = b.Username;
        //    int b_id = b.ID;

        //    //update b
        //    a.Update(new User(2, "Stan", "frits@hotmail.com", new Group(1)));

        //    b = a.Get()[0];
        //    string c_n = b.Username;
        //    int c_id = b.ID;
            
        //    Assert.AreEqual(b_id, c_id);
        //}
    }
}
