using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EyeCT4RailsBackend;
using ExtendedObservableCollection;

namespace EyeCT4RailsTest
{
    /// <summary>
    /// Summary description for UnitTest1 todo
    /// </summary>
    [TestClass]
    public class TestGroup
    {
        List<User> dummyUsers = new List<User>();

        [TestMethod]
        public void TestGet()
        {
            UserRepository a = new UserRepository(new UserMemoryContext(true), new GroupMemoryContext(true));
            ExtendedObservableCollection<Group> b = a.GroupRepo.Collection;
            List<Group> c = TestData.GetGroups();

            for (int i = 0; i < b.Count; i++)
            {
                Assert.AreEqual(b[i].ToString(), c[i].ToString());
            }
        }

        //[TestMethod]
        //public void TestInsert()
        //{
        //    GroupRepository repo = new GroupRepository(new GroupMemoryContext(true));

        //    int b = repo.Get().Count;
        //    repo.Insert(new Group(1));
        //    int c = repo.Get().Count;

        //    Assert.AreNotEqual(b, c);
        //}

        //[TestMethod]
        //public void TestUpdate()
        //{
        //    GroupRepository repo = new GroupRepository(new GroupMemoryContext(true));

        //    //get the id
        //    Group group1 = repo.Get()[0];
        //    Group group2 = group1;

        //    //update
        //    group2.Name = "New group name";
        //    repo.Update(group2);
        //    group2 = repo.Get()[0];

        //    //compare
        //    Assert.AreEqual(group2.ID, group1.ID);
        //}
    }
}
