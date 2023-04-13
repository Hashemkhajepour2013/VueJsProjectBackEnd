namespace ProjectUserPost.Data.Users.Contracts.Dtos
{
    public sealed class UserGetByIdDto
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public string Company { get; set; }
    }
}
