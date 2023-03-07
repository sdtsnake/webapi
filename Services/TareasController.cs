using webapi.Models;
namespace webapi.Services;

public class TareaService : ITareaService{

    TareasContext context;

    public TareaService(TareasContext context){
        this.context = context;
    }

    public IEnumerable<Tarea> Get(){

        return context.Tareas;
    }

    public async Task Save(Tarea tarea){
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Tarea tarea){
        Tarea tareaActual = context.Tareas.Find(tarea.CategoriaId);

        if(tareaActual != null){
            context.Add(tarea);
            await context.SaveChangesAsync();
        }
    }

       public async Task Detelete(Guid id){
        Tarea tareaActual = context.Tareas.Find(id);

        if(tareaActual != null){
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}



public interface ITareaService{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Tarea tarea);
    Task Detelete(Guid id);
}