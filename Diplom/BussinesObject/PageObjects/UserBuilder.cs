﻿using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.BussinesObject.PageObjects
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
