using DataModel.Models;
using System.Collections.ObjectModel;
using System.Text;

namespace TaskService.Service
{
    public class CategoryService 
    {
        private string path1 = @"F:\Integrify-Post-Training\WPF Project\Personal Task Manager\TaskService\Service\Database\DBCategory.csv";


        public ObservableCollection<TaskCategory> _categories = new();

        public CategoryService()
        {
            ReadCategory();
        }
        public void ReadCategory()
        {
            using (StreamReader reader = new StreamReader(path1))
            {
                _categories.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    TaskCategory category = new()
                    {
                        Id = Convert.ToInt16(values[0]),
                        TaskType = values[1],
                    };

                    _categories.Add(category);
                }
            }
        }
        private void SaveCategory()
        {
            using (StreamWriter writer = new(path1))
            {
                foreach (TaskCategory item in _categories)
                {

                    string Id = item.Id.ToString();
                    string taskType = item.TaskType.ToString();
                    string line = string.Format("{0};{1}",Id, taskType);
                    writer.WriteLine(line);
                }
            }
        }
        public string PrintCategory()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var category in _categories)
            {
                sb.Append(category.TaskType+" ");
            }
            SaveCategory();
            return sb.ToString();
        }
        public TaskCategory AddCategory(TaskCategory category)
        {
            _categories.Add(category);
            SaveCategory();
            return category;
        }

        public TaskCategory DeleteCategory(int id)
        {
           var foundCategory = _categories.First(c => c.Id == id);
            if (foundCategory != null)
            {
                _categories.Remove(foundCategory);
            }
            SaveCategory();
            return foundCategory;
        }

        public TaskCategory EditCategory(int id, TaskCategory category)
        {
            var temp = _categories.FirstOrDefault(x => x.Id == id);
            int index = _categories.IndexOf(temp);
            SaveCategory();
            return _categories[index] = category;
        }

        public int GetNextId()
        {
            int generatedId = _categories.Any() ? _categories.Max(x => x.Id) + 1 : 1;
            return generatedId;
        }

      
    }
}
