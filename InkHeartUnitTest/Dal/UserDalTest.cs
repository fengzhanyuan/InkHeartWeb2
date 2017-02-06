using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InkHeart.EFDAL;
using InkHeart.Model;
using System.Linq;
using InkHeart.IDAL;
using InkHeart.BLL;
using InkHeart.IBLL;

namespace InkHeartUnitTest.Dal
{
    [TestClass]
    public class UserDalTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //IUserDal dal = new UserDal();
            IUserService userService = new UserService();
            User user = new User() {
            Age = 10,
            Birthday = DateTime.Now,
            Email = "870831935@qq.com",
            LogName = "feng",
            LogTime = DateTime.Now,
            Name = "feng",
            Password = "1234546",
            PhoneNumber = "18351801922",
            State = false
            };
            //单元测试不许自己处理数据，不能依赖第三方数据。如果依赖数据那么先自己创建数据用完之后再清除数据
            userService.Add(user);

          IQueryable<User>usertemp= userService.GetEntities(u => u.Name.Contains("feng"));
            //断言
          Assert.AreEqual(true,usertemp.Count()>0);
        }
    }
}
