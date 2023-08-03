using Bogus;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.BussinesObject
{
    internal class UserBuilder
    {
        static Faker Faker = new();
        
        public static UserLoginModel GetStandandartUser()
        {
            return new UserLoginModel
            {
                Mail = TestContext.Parameters.Get("StandartUserMail"),
                Password = TestContext.Parameters.Get("StandartUserPassword")
            };
        }

        public static UserCreateModel GetUserDataLogin()
        {
            return new UserCreateModel
            {
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
                Password = Faker.Random.Word(),
                EMail = Faker.Internet.Email(),
            };
        }

        public static UserLoginModel GetUnknownUser()
        {
            return new UserLoginModel
            {
                Mail = Faker.Internet.Email(),
                Password = Faker.Internet.Password(),
            };
        }

        public static UserAddressModel GetUserData()
        {
            return new UserAddressModel
            {
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
                Address = Faker.Address.StreetAddress(),
                PostalCode = TestContext.Parameters.Get("PostalCode"),
                City = Faker.Address.City(),
                MobilePhone = Faker.Phone.PhoneNumber(),
                AddressAlias = Faker.Random.Word(),

            };
        }
    }
}
