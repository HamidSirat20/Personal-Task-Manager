using DataModel.Models;
using System.Collections.ObjectModel;

namespace TaskService.Service
{
    public interface IAssignmentTaskService
    {
        AssignmentTask DeleteTask(int id);
        AssignmentTask EditTask(int id, AssignmentTask taskItem);
        AssignmentTask AddTask(AssignmentTask taskItem);
        int GetNextId();
    }
}
