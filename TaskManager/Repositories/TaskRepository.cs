using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Repositories.Interfaces;

namespace TaskManager.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerDBContext _dbContext;

        public TaskRepository(TaskManagerDBContext taskManagerDBContext)
        {
            _dbContext = taskManagerDBContext;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> UpdateTask(TaskModel taskModel, int id)
        {
            TaskModel taskById = await GetTaskById(id);

            if (taskById == null)
            {
                throw new Exception($"User for {id} ID not found.");
            }

            taskById.Name = taskModel.Name;
            taskById.Description = taskModel.Description;
            taskById.Status = taskModel.Status;
            taskById.UserId = taskModel.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<TaskModel> AddTask(TaskModel taskModel)
        {
            await _dbContext.Tasks.AddAsync(taskModel);
            await _dbContext.SaveChangesAsync();

            return taskModel;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskModel = await GetTaskById(id);

            if (taskModel == null)
            {
                throw new Exception($"Task {id} not found.");
            }

            _dbContext.Tasks.Remove(taskModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
