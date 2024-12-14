namespace Ex4.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
