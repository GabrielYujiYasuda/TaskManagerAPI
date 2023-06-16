using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repositories.Interfaces;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<TaskModel>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetAllTasks();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            TaskModel task = await _taskRepository.GetTaskById(id);

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> AddTask([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.AddTask(taskModel);

            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;

            TaskModel task = await _taskRepository.UpdateTask(taskModel, id);

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTask(int id)
        {
            bool isDeleted = await _taskRepository.DeleteTask(id);

            return Ok(isDeleted);
        }
    }
}
