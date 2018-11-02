using Academy.Data;
using Academy.DataContext;
using Academy.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Academy.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public async Task GetUserByIdShouldReturnUser()
        {
            var contextOptions = new DbContextOptionsBuilder<AcademySiteContext>()
                .UseInMemoryDatabase(databaseName: "GetUserByIdShouldReturnUser")
                .Options;


            using (var context = new AcademySiteContext(contextOptions))
            {

                context.Users.Add(new User()
                {
                    Id = 1,
                    UserName = "pesho12",
                    FullName = "Pesho Peshev",
                    RoleId = 2
                });

                context.SaveChanges();
            }

            using (var context = new AcademySiteContext(contextOptions))
            {
                var courseService = new UserService(context);
                var user = await courseService.GetUserByIdAsync(1);

                Assert.IsTrue(user.UserName == "pesho12");

            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task GetUserByIdShouldThrowExceptionWhenIdNotValid()
        {
            var contextOptions = new DbContextOptionsBuilder<AcademySiteContext>()
                .UseInMemoryDatabase(databaseName: "GetUserByIdShouldThrowExceptionWhenIdNotValid")
                .Options;


            using (var context = new AcademySiteContext(contextOptions))
            {

                context.Users.Add(new User()
                {
                    Id = 1,
                    UserName = "pesho12",
                    FullName = "Pesho Peshev",
                    RoleId = 2
                });

                context.SaveChanges();
            }

            using (var context = new AcademySiteContext(contextOptions))
            {
                var courseService = new UserService(context);
                var user = await courseService.GetUserByIdAsync(-1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetUserByIdShouldThrowExceptionWhenIdNotFound()
        {
            var contextOptions = new DbContextOptionsBuilder<AcademySiteContext>()
                .UseInMemoryDatabase(databaseName: "GetUserByIdShouldThrowExceptionWhenIdNotFound")
                .Options;


            using (var context = new AcademySiteContext(contextOptions))
            {

                context.Users.Add(new User()
                {
                    Id = 1,
                    UserName = "pesho12",
                    FullName = "Pesho Peshev",
                    RoleId = 2
                });

                context.SaveChanges();
            }

            using (var context = new AcademySiteContext(contextOptions))
            {
                var courseService = new UserService(context);
                var user = await courseService.GetUserByIdAsync(10);
            }
        }

    }
}
