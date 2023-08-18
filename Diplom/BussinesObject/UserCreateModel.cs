namespace Diplom.BussinesObject
{
    public class UserCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public override string? ToString()
        {
            return $"FirstName: {FirstName} LastName: {LastName} Password: {Password}";
        }
    }
}
