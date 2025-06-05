# API.Hangfire.NET
This repository demonstrates how to integrate Hangfire with a .NET Web API application to manage background jobs, recurring tasks, and delayed execution.


# Route
https://localhost:7138/hangfire

</br>

![image](https://github.com/user-attachments/assets/db279de5-504f-4bd3-a639-42fa0a7c4316)

----

# Operation

## Schedule Default

### Create a User 
![image](https://github.com/user-attachments/assets/92bc28cb-e1d2-482f-8f9f-327637bf0ee9)

---

### Hangfire DashBoard
![image](https://github.com/user-attachments/assets/3b509dbc-ffed-45af-84ad-fd3ab7a79623)

---


### Database Before 
![image](https://github.com/user-attachments/assets/1e4249fb-1164-4922-b7fc-22837e89716d)

----

### Database After (one minute)
![image](https://github.com/user-attachments/assets/033e0d91-7c8e-45b5-9474-711e60c0753f)

---

### DashBoard
![image](https://github.com/user-attachments/assets/0319a53e-7a2f-44ac-9038-e5d87165a7b8)

----

![image](https://github.com/user-attachments/assets/836274b1-b60f-4ab9-8295-51da09c56aae)

----

## Schedule Daily
```csharp
[HttpPost("recurring")]
public IActionResult CreateRecurringJob()
{
    RecurringJob.AddOrUpdate(
        "InsertRecurringUserJob", 
        () => _userRepository.UserInsert("John Doe", "john.doe@example.com"),
        Cron.Daily(8) //8:00
    );

    return Ok("Recurring job registered to run daily.");
}
```
![image](https://github.com/user-attachments/assets/8c307af0-f27c-492c-9f6f-c704e3051d6e)

-----


## Recurring job every 2 minutes
```csharp
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
```

![image](https://github.com/user-attachments/assets/a96cbd63-82cb-4c36-9a33-90161c8c53f9)



# References
https://www.youtube.com/watch?v=sVCK_l4QChs

https://www.youtube.com/watch?v=cvpSx10z5Og

https://medium.com/@shekhartarare/step-by-step-guide-to-scheduling-api-calls-with-hangfire-in-asp-net-core-8db442b0dea1
