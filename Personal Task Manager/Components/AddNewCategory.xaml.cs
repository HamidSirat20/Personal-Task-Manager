using DataModel.Models;
using System.Collections.ObjectModel;
using System.Windows;
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
            TaskCategory newCategory = new()
            {
                Id = _categoryService.GetNextId(),
                TaskType = textNewCategory.Text,
            };
            _categoryService.AddCategory(newCategory);
            ////MessageBox.Show(_categoryService.PrintCategory());
            this.Close();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryGrid.SelectedIndex >= 0)

            {
                CurrentCategory = CategoryGrid.SelectedItem as TaskCategory;
              
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryGrid.SelectedIndex >= 0)
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
