using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.TaskService
{
    public class TaskService
    {
        //private string FilePath = @"./Database/DBTask.csv";
        private ObservableCollection<TaskItem> _taskItems = new ObservableCollection<TaskItem>();
        public TaskService()
        {
            ReadTasks();
        }
        private void ReadTasks()
        {
            Category daily = new Category(1,"Chores");
            Category health = new Category(1, "Chores");

            TaskItem taskItem1 = new TaskItem()
            {
                Id = IdGenerator(),
                Title = "Homework.",
                Description = "Math Homework should be completed by tomorrow!",
                Category = daily,
                DueDate = DateTime.Now,
                IsCompleted = false,
                Priority = "Medium"
            };
            TaskItem taskItem2 = new TaskItem()
            {
                Id = IdGenerator(),
                Title = "Visit Doctor.",
                Description = "You have an appointment with the tooth doctor!",
                Category = health,
                DueDate = DateTime.Now,
                IsCompleted = false,
                Priority = "High"
            };
            _taskItems.Add(taskItem1);
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
            int generatedId = _taskItems.Count > 0 ? _taskItems.Max(x => x.Id) : 1;
            return generatedId;
        }
       
    }
}
