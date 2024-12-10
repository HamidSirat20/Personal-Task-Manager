using DataModel.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaskService.Service;

namespace Personal_Task_Manager.Components
{
    /// <summary>
    /// Interaction logic for AddNewCategory.xaml
    /// </summary>
    public partial class AddNewCategory : Window
    {
        //

        private readonly CategoryService _categoryService;
        private readonly TaskCategory _TaskService;
        private TaskCategory CurrentCategory { get; set; }
        public bool isEditing = false;

        public AddNewCategory(CategoryService category)
        {
            InitializeComponent();
            _categoryService = category;
            CategoryGrid.ItemsSource = _categoryService._categories;
        }

        public AddNewCategory(CategoryService category, TaskCategory taskCategory)
        {
            InitializeComponent();
            _categoryService = category;
            CategoryGrid.ItemsSource = _categoryService._categories;
            CurrentCategory = taskCategory;
            isEditing = true;
            textNewCategory.Text = CurrentCategory.TaskType;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            

            bool isValid = true;
            isValid = CheckValidity();
            if (isValid)
            {
                TaskCategory newCategory = new()
                {
                    Id = _categoryService.GetNextId(),
                    TaskType = textNewCategory.Text,
                };
                _categoryService.AddCategory(newCategory);
                ////MessageBox.Show(_categoryService.PrintCategory());
                this.Close();
            }

        }

        private bool CheckValidity()
        {
            bool isValid = true;
            string TaskType = textNewCategory.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(TaskType))
            {
                isValid = false;
                categoryMessageBox.Text = "Please write a new category.";
                textNewCategory.BorderBrush = Brushes.Red;
            }
            else if (_categoryService._categories.FirstOrDefault(x=>x.TaskType.ToLower() ==TaskType) !=null)
            {
                isValid = false;
                categoryMessageBox.Text = "This category already exist!";
                textNewCategory.BorderBrush = Brushes.Red;
            }
          
            return isValid;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryGrid.SelectedIndex < 0)
            {
                categoryMessageBox.Text = "Please choose a category from the left to delete.";
            }
            else if (CategoryGrid.SelectedIndex >= 0)
            {
                CurrentCategory = CategoryGrid.SelectedItem as TaskCategory;
                _categoryService.DeleteCategory(CurrentCategory.Id);
            }
        }

        private void CategoryGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CategoryGrid.SelectedIndex >= 0)
            {
                CurrentCategory = CategoryGrid.SelectedItem as TaskCategory;  
            }

        }

    }
}
