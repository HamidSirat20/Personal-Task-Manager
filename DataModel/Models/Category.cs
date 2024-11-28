namespace DataModel.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string TaskType { get; set; } = string.Empty;
        public Category(int id, string taskType)
        {
            Id = id;
            TaskType = taskType;
        }
    }
}
