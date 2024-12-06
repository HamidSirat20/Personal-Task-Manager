using DataModel.Models;
using System.Collections.ObjectModel;
using System.Text;

namespace TaskService.Service
{
    public class CategoryService 
    {
        public ObservableCollection<TaskCategory> _categories = new();

        public CategoryService()
        {
            ReadCategory();
        }
        public void ReadCategory()
        {
            var category = new TaskCategory()
            {
                Id = GetNextId(),
                TaskType = "Health"
            };
            _categories.Add(category);
            var category1 = new TaskCategory()
            {
                Id = GetNextId(),
                TaskType = "Work"
            };
            _categories.Add(category1);
            var category2 = new TaskCategory()
            {
                Id = GetNextId(),
                TaskType = "Education"
            };
            _categories.Add(category2);
        }
        public string PrintCategory()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var category in _categories)
            {
                sb.Append(category.TaskType+" ");
            }
            return sb.ToString();
        }
        public TaskCategory AddCategory(TaskCategory category)
        {
            _categories.Add(category);
            return category;
        }

        public TaskCategory DeleteCategory(int id)
        {
           var foundCategory = _categories.First(c => c.Id == id);
            if (foundCategory != null)
            {
                _categories.Remove(foundCategory);
            }
            return foundCategory;
        }

        public TaskCategory EditCategory(int id, TaskCategory category)
        {
            var temp = _categories.FirstOrDefault(x => x.Id == id);
            int index = _categories.IndexOf(temp);
            return _categories[index] = category;
        }

        public int GetNextId()
        {
            int generatedId = _categories.Any() ? _categories.Max(x => x.Id) + 1 : 1;
            return generatedId;
        }

      
    }
}
