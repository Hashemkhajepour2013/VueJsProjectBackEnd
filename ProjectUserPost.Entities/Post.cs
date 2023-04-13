using ProjectUserPost.Entities.Common;

namespace ProjectUserPost.Entities
{
    public sealed class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public int userId { get; set; }
        public User User { get; set; }
    }
}
