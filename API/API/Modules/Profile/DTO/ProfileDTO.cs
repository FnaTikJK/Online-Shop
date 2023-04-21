namespace API.Modules.Profile.DTO
{
    public class ProfileDTO
    {
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string? ThirdName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
