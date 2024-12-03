namespace DataModel.Models
{
    public class AssignmentTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CategoryEnum Category { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

        public string TaskDescription()
        {
            return Description +"\n" + "Priority Level: " +Priority;
        }
    }

}
