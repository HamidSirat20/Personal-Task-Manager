using DataModel.Models;
using System.Collections.ObjectModel;
using TaskService.Service;

namespace Service.TaskService
{
    public class AssignmentTaskService 
    {
        //private string FilePath = @"./Database/DBTask.csv";
        public ObservableCollection<AssignmentTask> _taskItems = new ObservableCollection<AssignmentTask>();
        private static AssignmentTaskService _instance;
        private AssignmentTaskService()
        {
            ReadTasks();
        }
        public static AssignmentTaskService Instance 
        { get
            {
                if(_instance == null)
                {
                    _instance = new AssignmentTaskService();
                }
                return _instance;
            } 
        }
        void ReadTasks()
        {
            AssignmentTask taskItem1 = new AssignmentTask()
            {
                Id = GetNextId(),
                Title = "Homework.",
                Description = "Math Homework should be completed by tomorrow!",
                Category = CategoryEnum.Education,
                DueDate = DateTime.Now,
                Status = Status.NotStarted,
                Priority = Priority.High,
            };
            _taskItems.Add(taskItem1);
            AssignmentTask taskItem2 = new AssignmentTask()
            {
                Id = GetNextId(),
                Title = "Visit Doctor.",
                Description = "You have an appointment with the tooth doctor!",
                Category = CategoryEnum.Health,
                DueDate = DateTime.Now,
                Status = Status.Completed,
                Priority = Priority.Medium
            };
            _taskItems.Add(taskItem2);
        }

        public AssignmentTask DeleteTask(int id)
        {
            AssignmentTask? taskItem = _taskItems.FirstOrDefault(x => x?.Id == id, null);
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

        public AssignmentTask EditTask(int id, AssignmentTask taskItem)
        {
            var temp = _taskItems.FirstOrDefault(x => x.Id == id);
            int index = _taskItems.IndexOf(temp);
            return _taskItems[index] = taskItem;
        }

        public AssignmentTask AddTask(AssignmentTask taskItem)
        {
            _taskItems.Add(taskItem);
            return taskItem;
        }
        public int GetNextId()
        {
            int generatedId = _taskItems.Any() ? _taskItems.Max(x => x.Id) + 1 : 1;
            return generatedId;
        }
    }
}
