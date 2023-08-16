namespace Diplom.BussinesObject
{
    internal class UserBuilder
    {
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
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Password = Faker.Identification.SocialSecurityNumber(),
                EMail = Faker.Internet.Email(),
                
            };
        }

        public static UserLoginModel GetUnknownUser()
        {
            return new UserLoginModel
            {
                Mail = Faker.Internet.Email(),
                Password = Faker.Identification.SocialSecurityNumber(),
            };
        }

        public static UserAddressModel GetUserData()
        {
            return new UserAddressModel
            {
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Address = Faker.Address.StreetAddress(),
                PostalCode = TestContext.Parameters.Get("PostalCode"),
                City = Faker.Address.City(),
                MobilePhone =  Faker.Phone.Number(),
                AddressAlias = Faker.Address.StreetName(),

            };
        }
    }
}
