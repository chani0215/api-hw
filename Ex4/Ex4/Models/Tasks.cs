namespace Ex4.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public virtual Users? Users { get; set; }
    }
}
