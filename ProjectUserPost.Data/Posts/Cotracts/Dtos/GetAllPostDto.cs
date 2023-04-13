namespace ProjectUserPost.Data.Posts.Cotracts.Dtos
{
    public sealed class GetAllPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public string NameUser { get; set; }
    }
}
