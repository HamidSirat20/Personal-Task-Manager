using DataModel.Models;
using Service.TaskService;
using System.Windows;
using System.Windows.Controls;
using TaskService.Service;

namespace Personal_Task_Manager.Components
{
    /// <summary>
    /// Interaction logic for AddNewTask.xaml
    /// </summary>
    public partial class AddNewTask : Window
    {
        private readonly AssignmentTaskService _taskService;
        private readonly CategoryService _categoryService;
        public AddNewTask(AssignmentTaskService assignment, CategoryService category)
        {
            InitializeComponent();
           
            _taskService = assignment;
            _categoryService = category;
            comboBoxCategory.ItemsSource = _categoryService._categories;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            AssignmentTask newTask = new AssignmentTask()
            {
                Id = _taskService.GetNextId(),
                Title = textTitle.Text,
                Description = textDescription.Text,
                Category =(CategoryEnum)comboBoxCategory.SelectedIndex,
                Status = (Status)comboBoxStatus.SelectedIndex,
                Priority= (Priority)comboBoxPriority.SelectedIndex,
            };
            _taskService.AddTask(newTask);
            this.Close();
        }
       

    }
}
