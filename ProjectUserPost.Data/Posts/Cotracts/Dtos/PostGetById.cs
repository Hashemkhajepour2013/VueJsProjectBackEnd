namespace ProjectUserPost.Data.Posts.Cotracts.Dtos
{
    public sealed class PostGetById
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public string NameUser { get; set; }
    }
}
