namespace DataModel.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
