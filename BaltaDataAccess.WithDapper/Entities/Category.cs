namespace BaltaDataAccess.WithDapper.Entities
{
    public class Category
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }

        public String? Summary { get; set; }

        public int? Order { get; set; }

        public string? Description { get; set; }

        public bool? Featured { get; set; }

    }
}
