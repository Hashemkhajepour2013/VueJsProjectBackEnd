using ProjectUserPost.Entities.Common;

namespace ProjectUserPost.Entities
{
    public sealed class User : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Company { get; set; }

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
