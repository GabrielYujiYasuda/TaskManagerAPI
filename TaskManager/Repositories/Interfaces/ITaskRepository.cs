using TaskManager.Models;

namespace TaskManager.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> AddTask(TaskModel taskModel);
        Task<TaskModel> UpdateTask(TaskModel taskModel, int id);
        Task<bool> DeleteTask(int id);
    }
}
