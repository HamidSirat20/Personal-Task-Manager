using DataModel.Models;
using System.Collections.ObjectModel;
using System.Text;

namespace Service.TaskService
{
    public class TaskService
    {
        //private string FilePath = @"./Database/DBTask.csv";
        public ObservableCollection<TaskItem> _taskItems = new ObservableCollection<TaskItem>();
        public TaskService()
        {
            ReadTasks();
        }
        private void ReadTasks()
        {
            Category daily = new Category(1,"Chores");
            Category health = new Category(1, "Health");

            TaskItem taskItem1 = new TaskItem()
            {
                Id = IdGenerator(),
                Title = "Homework.",
                Description = "Math Homework should be completed by tomorrow!",
                Category = daily.TaskType,
                DueDate = DateTime.Now,
                IsCompleted = false,
                Priority = "Medium"
            };
            _taskItems.Add(taskItem1);
            TaskItem taskItem2 = new TaskItem()
            {
                Id = IdGenerator(),
                Title = "Visit Doctor.",
                Description = "You have an appointment with the tooth doctor!",
                Category = health.TaskType,
                DueDate = DateTime.Now,
                IsCompleted = false,
                Priority = "High"
            };
            _taskItems.Add(taskItem2);
        }

          public TaskItem DeleteTask(int id)
        {
            TaskItem? taskItem = _taskItems.FirstOrDefault(x=> x?.Id == id,null);
            if (taskItem == null)
            {
                return null;
            }
            else
            {
                _taskItems.Remove(taskItem);
                return taskItem;
            }
        }

        public TaskItem EditTask(int id,TaskItem taskItem)
        {
            var temp = _taskItems.FirstOrDefault(x=>x.Id ==id);
            int index = _taskItems.IndexOf(temp);
            return _taskItems[index] = taskItem;  
        }

        public TaskItem AddTask(TaskItem taskItem)
        {
            _taskItems.Add(taskItem);
            return taskItem;
        }
        private int IdGenerator()
        {
            int generatedId = _taskItems.Any() ? _taskItems.Max(x => x.Id) + 1 : 1;
            return generatedId;
        }
       
    }
}
