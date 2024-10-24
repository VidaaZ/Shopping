namespace OnlineShop.Models.User
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}
