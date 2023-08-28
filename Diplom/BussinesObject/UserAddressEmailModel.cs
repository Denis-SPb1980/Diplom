namespace Diplom.BussinesObject
{
    public class UserAddressEmailModel
    {
        public string EMail { get; set; }
        public override string? ToString()
        {
            return $"Mail: {EMail}";
        }
    }
}