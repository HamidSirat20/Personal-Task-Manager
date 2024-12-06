namespace DataModel.Models
{
    public class TaskCategory
    {
        public int Id { get; set; }
        public string TaskType { get; set; }
        public TaskCategory(int id, string cat)
        {
            Id = id;
            TaskType = cat;  
        }
        public TaskCategory()
        {
            
        }
    }
}
