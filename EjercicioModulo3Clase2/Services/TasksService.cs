
using EjercicioModulo3Clase2.Domain.Entities;
using EjercicioModulo3Clase2.Repository;
using System.ComponentModel.DataAnnotations;
using EjercicioModulo3Clase2.Services.Interfaces;


namespace EjercicioModulo3Clase2.Services;
public class TasksService : ITasksService
{

    private ToDoListDBContext _context;

    public TasksService(ToDoListDBContext context) {  _context = context; }



    public List<Tasks> getTasks()
    {
        return _context.Tasks.ToList();
    }

    Tasks ITasksService.getTaskById(int id)
    {
        Tasks task = _context.Tasks.FirstOrDefault(task => task.Id == id);
       return task ;
    }

    Tasks ITasksService.putCompleteTask(int id)
    {
        Tasks task = _context.Tasks.FirstOrDefault(task => task.Id == id);
        task.IsCompleted = true;
        _context.SaveChanges();
        return task;
    }

    Tasks ITasksService.putDarBaja(int id)
    {
        Tasks task = _context.Tasks.FirstOrDefault(task => task.Id == id);
        task.IsActive = false;
        _context.SaveChanges();
        return task;
    }

    void ITasksService.saveTask(Tasks task)
    {
        _context.Add(task);
        _context.SaveChanges();
    }
}