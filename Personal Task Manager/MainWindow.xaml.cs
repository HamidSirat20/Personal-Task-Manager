using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using DataModel.Models;
using Personal_Task_Manager.Components;
using Service.TaskService;

namespace Personal_Task_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AssignmentTaskService taskService = new();
        ObservableCollection<AssignmentTask> tasks = new ObservableCollection<AssignmentTask>();
        public AssignmentTask CurrentTask { get; set; } = new AssignmentTask();

        public MainWindow()
        {
            InitializeComponent();
            
            TasksGrid.ItemsSource = taskService._taskItems;
            ControlComponent controlComponent = new ControlComponent( taskService);
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
            AddNewTask addNewTask = new AddNewTask(taskService);
            addNewTask.ShowDialog();
        }
    }
}