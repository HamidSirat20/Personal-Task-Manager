using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using DataModel.Models;
using Service.TaskService;

namespace Personal_Task_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TaskService taskService = new TaskService();
        ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();
        public TaskItem CurrentTask { get; set; } = new TaskItem();

        public MainWindow()
        {
            InitializeComponent();
            FillData();
            TasksGrid.ItemsSource = tasks;
        }

        private void TasksGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksGrid.SelectedIndex >= 0)
            {
                CurrentTask = TasksGrid.SelectedItem as TaskItem;
                TaskLabel.Content = CurrentTask.TaskDescription();
            }

        }
     
        private void FillData()
        {
            tasks = taskService._taskItems;
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            TasksPanel.Visibility = Visibility.Visible;
            
        }

       
        
    }
}