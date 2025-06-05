using Hangfire;
using Hangfire.API.Model;
using Hangfire.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //Tarefa agendada
    [HttpPost("schedule")]
    public IActionResult ScheduleUser([FromBody] User user)
    {
        BackgroundJob.Schedule(
            () => _userRepository.UserInsert(user.Name, user.Email),
            TimeSpan.FromMinutes(1)
        );

        return Ok("User scheduled to be inserted in 1 minute");
    }

    // Runs every day at 8:00
    [HttpPost("recurring")]
    public IActionResult CreateRecurringJob()
    {
        RecurringJob.AddOrUpdate(
            "InsertRecurringUserJob", // ← Esse é o ID do job
            () => _userRepository.UserInsert("John Doe", "john.doe@example.com"),
            Cron.Daily(8) //8:00
        );

        return Ok("Recurring job registered to run daily.");
    }

    // Recurring job every 2 minutes
    [HttpPost("recurring/every-2-minutes")]
    public IActionResult CreateRecurringJobTwoMinutes()
    {
        RecurringJob.AddOrUpdate(
            "InsertUserEvery2Minutes",
            () => _userRepository.UserInsert("John Doe", "john.doe@example.com"),
            "*/2 * * * *" // Cron: a cada 2 minutos
        );

        return Ok("Recurring job registered to run every 2 minutes.");
    }
}
