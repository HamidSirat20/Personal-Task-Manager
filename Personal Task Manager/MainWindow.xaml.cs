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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AssignmentTaskService taskService = new();
        ObservableCollection<AssignmentTask> tasks = new ();

        CategoryService categoryService = new();
        ObservableCollection<TaskCategory> categories = new ();

        private bool isToDo = false;
        private bool isInProgress = false;
        private bool isCompleted = false;
        private bool isShowAll = false;
        public AssignmentTask CurrentTask { get; set; } = new ();
        public TaskCategory CurrentCategory { get; set; } = new ();


        public MainWindow()
        {
            InitializeComponent();

            UpdateTaskGrid();
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

        private void btn_toDo_Click(object sender, RoutedEventArgs e)
        {
            isToDo = true;
            isInProgress = false;
            isCompleted = false;
            isShowAll = false;
            UpdateTaskGrid();
        }

        private void btn_InProgress_Click(object sender, RoutedEventArgs e)
        {
            isToDo = false;
            isInProgress = true;
            isCompleted = false;
            isShowAll = false;
            UpdateTaskGrid();
        }

        private void btn_Completed_Click(object sender, RoutedEventArgs e)
        {
            isToDo = false;
            isInProgress = false;
            isCompleted = true;
            isShowAll = false;
            UpdateTaskGrid();
        }

        private void btn_showAll_Click(object sender, RoutedEventArgs e)
        {
            isToDo = false;
            isInProgress = false;
            isCompleted = false;
            isShowAll = true;
            UpdateTaskGrid();
        }

        private void UpdateTaskGrid()
        {
            var tasks = taskService._taskItems.ToList();

            if (isToDo)
            {
                TasksGrid.ItemsSource = tasks.Where(x => x.Status == Status.NotStarted).ToList();
            }

            else if (isInProgress)
            {
                TasksGrid.ItemsSource = tasks.Where(x => x.Status == Status.InProgress).ToList();
            }
            else if (isCompleted)
            {
                TasksGrid.ItemsSource = tasks.Where(x => x.Status == Status.Completed).ToList();
            }
            else
            {
                TasksGrid.ItemsSource = tasks;
            }
        }
    }
}