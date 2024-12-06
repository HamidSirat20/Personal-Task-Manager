using Service.TaskService;
using System.Windows;
using System.Windows.Controls;

namespace Personal_Task_Manager.Components
{
    /// <summary>
    /// Interaction logic for ControlComponent.xaml
    /// </summary>
    public partial class ControlComponent : UserControl
    {
        private readonly AssignmentTaskService _taskService;

        // Default parameterless constructor
        public ControlComponent()
        {
            InitializeComponent();
        }

        // Constructor with dependency injection
        public ControlComponent(AssignmentTaskService taskService) : this()
        {
            _taskService = taskService;
        }

        private void btnAdd_New_Task(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
