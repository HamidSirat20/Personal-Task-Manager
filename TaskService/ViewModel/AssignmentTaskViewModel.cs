using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TaskService.Service;

namespace TaskService.ViewModel
{
    public class AssignmentTaskViewModel
    {
        public readonly IAssignmentTaskService _assignmentTaskService;
       
        public AssignmentTaskViewModel(IAssignmentTaskService taskService)
        {
            _assignmentTaskService = taskService;
        }
        public ObservableCollection<AssignmentTask> AssignmentTasks { get; } = new();

       
    }
}
