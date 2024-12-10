using DataModel.Models;
using System.Collections.ObjectModel;
using TaskService.Service;

namespace Service.TaskService
{
    public class AssignmentTaskService 
    {
        private string path1 = @"F:\Integrify-Post-Training\WPF Project\Personal Task Manager\TaskService\Service\Database\DBAssignmentTask.csv";

        public ObservableCollection<AssignmentTask> _taskItems = new ();
        public ObservableCollection<TaskCategory> _categories = new ();
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
            using (StreamReader reader = new StreamReader(path1))
            {
                _taskItems.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');
                    Enum.TryParse(values[3], out CategoryEnum cat);
                    DateTime.TryParse(values[4], out DateTime date);
                    Enum.TryParse(values[5], out Status status);
                    Enum.TryParse(values[6], out Priority priority);


                    AssignmentTask task = new AssignmentTask()
                    {
                        Id = Convert.ToInt16(values[0]),
                        Title = values[1],
                        Description = values[2],
                        Category = cat,
                        DueDate = date,
                        Status = status,
                        Priority = priority,
                    };  
                    _taskItems.Add(task);

                }
            }
        }

        private void SaveTasks()
        {
            using (StreamWriter writer = new (path1))
            {    
                foreach (AssignmentTask item in _taskItems)
                {

                    string Id = item.Id.ToString();
                    string Title = item.Title.ToString();
                    string Description = item.Description.ToString();
                    string Category = item.Category.ToString();
                    string DueDate = item.DueDate.ToString();
                    string Status = item.Status.ToString();
                    string Priority = item.Priority.ToString();
                    string line = string.Format("{0};{1};{2};{3};{4};{5};{6}", Id, Title, Description, Category, DueDate, Status, Priority);
                    writer.WriteLine(line);
                }
            }
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
                SaveTasks();
                return taskItem;
            }
        }

        public AssignmentTask EditTask(int id, AssignmentTask taskItem)
        {
            var temp = _taskItems.FirstOrDefault(x => x.Id == id);
            int index = _taskItems.IndexOf(temp);
            SaveTasks();
            return _taskItems[index] = taskItem;
        }

        public AssignmentTask AddTask(AssignmentTask taskItem)
        {
            _taskItems.Add(taskItem);
            SaveTasks();
            return taskItem;
        }
        public int GetNextId()
        {
            int generatedId = _taskItems.Any() ? _taskItems.Max(x => x.Id) + 1 : 1;
            return generatedId;
        }
    }
}
