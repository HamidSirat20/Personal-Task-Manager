using System.Windows;
using System.Windows.Controls;
using TaskService.Service;

namespace Personal_Task_Manager.Components
{
    /// <summary>
    /// Interaction logic for ControlComponent.xaml
    /// </summary>
    public partial class ControlComponent : UserControl
    {
        private readonly IAssignmentTaskService _taskService;

        // Default parameterless constructor
        public ControlComponent()
        {
            InitializeComponent();
        }

        // Constructor with dependency injection
        public ControlComponent(IAssignmentTaskService taskService) : this()
        {
            _taskService = taskService;
        }

        private void btnAdd_New_Task(object sender, RoutedEventArgs e)
        {
            AddNewTask addNewTask = new AddNewTask(_taskService);
            addNewTask.ShowDialog();
        }
    }
}
