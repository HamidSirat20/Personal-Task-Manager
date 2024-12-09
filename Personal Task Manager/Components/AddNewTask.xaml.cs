using DataModel.Models;
using Microsoft.VisualBasic;
using Service.TaskService;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            bool isValid = true;
            isValid = CheckValidity();
            if (isValid) 
            {
                AssignmentTask newTask = new AssignmentTask()
                {
                    Id = _taskService.GetNextId(),
                    Title = textTitle.Text,
                    Description = textDescription.Text,
                    Category = (CategoryEnum)comboBoxCategory.SelectedIndex,
                    DueDate = datePicker.SelectedDate.HasValue
                    ? datePicker.SelectedDate.Value
                    : DateTime.Now,
                    Status = (Status)comboBoxStatus.SelectedIndex,
                    Priority = (Priority)comboBoxPriority.SelectedIndex,
                };
                _taskService.AddTask(newTask);
                this.Close();
            }   
        }
        private bool CheckValidity()
        {
            bool isValid = true;
            string Title = textTitle.Text.Trim();
            string Description = textDescription.Text.Trim();
            int Category = comboBoxCategory.SelectedIndex;
            int Status = comboBoxStatus.SelectedIndex;
            int Priority = comboBoxPriority.SelectedIndex;

            if (string.IsNullOrEmpty(Title))
            {
                isValid = false;
                textMessageBox.Text = "Please fill in the title for the task.";
                textTitle.BorderBrush = Brushes.Red;
            }
            else if (string.IsNullOrEmpty(Description))
            {
                isValid = false;
                textMessageBox.Text = "Please fill in the description for the task.";
                textDescription.BorderBrush = Brushes.Red;
                textTitle.BorderBrush = Brushes.Black;

            }
            else if (int.IsNegative(Category))
            {
                isValid = false;
                textMessageBox.Text = "Please choose a category for the task.";
                comboBoxCategory.BorderBrush = Brushes.Red;
                textDescription.BorderBrush = Brushes.Black;
                textTitle.BorderBrush = Brushes.Black;
            }
            else if (!datePicker.SelectedDate.HasValue)
            {
                isValid = false;
                textMessageBox.Text = "Please choose a deadline.";
                datePicker.BorderBrush = Brushes.Red;
                comboBoxCategory.BorderBrush = Brushes.Black;
                textDescription.BorderBrush = Brushes.Black;
                textTitle.BorderBrush = Brushes.Black;
            }
            else if (datePicker.SelectedDate.Value < DateTime.Now)
            {
                isValid = false;
                textMessageBox.Text = "Please choose a date in the future.";
                datePicker.BorderBrush = Brushes.Red;
            }
            else if (int.IsNegative(Status))
            {
                isValid = false;
                textMessageBox.Text = "Please choose a status for the task.";
                comboBoxStatus.BorderBrush = Brushes.Red;
            }
            else if (int.IsNegative(Priority))
            {
                isValid = false;
                textMessageBox.Text = "Please choose a priority for the task.";
                comboBoxPriority.BorderBrush = Brushes.Red;
            }

            return isValid;
        }

    }
}
