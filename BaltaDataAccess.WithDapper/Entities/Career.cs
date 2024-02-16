namespace BaltaDataAccess.WithDapper.Entities
{
    internal class Career
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public IList<CareerItem> Items { get; set; } = [];
    }
}
