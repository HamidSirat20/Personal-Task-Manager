using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using DataModel.Models;
using Personal_Task_Manager.Components;
using Service.TaskService;
using TaskService.Service;

namespace Personal_Task_Manager
{
    public partial class MainWindow : Window
    {
        AssignmentTaskService taskService = new();
        ObservableCollection<AssignmentTask> tasks = new ();

        CategoryService categoryService = new();
        ObservableCollection<TaskCategory> categories = new ();
        public AssignmentTask CurrentTask { get; set; } = new ();
        public TaskCategory CurrentCategory { get; set; } = new ();
        public MainWindow()
        {
            InitializeComponent();
            
            TasksGrid.ItemsSource = taskService._taskItems;
        }

        private void TasksGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksGrid.SelectedIndex >= 0)
            {
                CurrentTask = TasksGrid.SelectedItem as AssignmentTask;
                TaskLabel.Content = CurrentTask.TaskDescription();
            }
        }
     
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            TasksPanel.Visibility = Visibility.Visible;
            
        }

        private void btnAdd_New_Task(object sender, RoutedEventArgs e)
        {
            AddNewTask addNewTask = new AddNewTask(taskService,categoryService);
            addNewTask.ShowDialog();
        }

        private void btnManage_Category(object sender, RoutedEventArgs e)
        {
           AddNewCategory addNewCategory = new(categoryService);
           addNewCategory.ShowDialog(); 
        }
    }
}