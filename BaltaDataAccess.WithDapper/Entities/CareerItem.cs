namespace BaltaDataAccess.WithDapper.Entities
{
    internal class CareerItem
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }

        public Course? Course { get; set; }
    }
}
