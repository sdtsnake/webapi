using webapi.Models;

namespace webapi.Services;
public class CategoriaService : ICategoriaService{

    TareasContext context;

    public CategoriaService(TareasContext context){
        this.context = context;
    }

    public IEnumerable<Categoria> Get(){

        return context.Categorias;
    }

    public async Task Save(Categoria categoria){
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Categoria categoria){
        Categoria categoriaActual = context.Categorias.Find(categoria.CategoriaId);

        if(categoriaActual != null){
            context.Add(categoria);
            await context.SaveChangesAsync();
        }
    }

       public async Task Detelete(Guid id){
        Categoria categoriaActual = context.Categorias.Find(id);

        if(categoriaActual != null){
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }
}


public interface ICategoriaService{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Categoria categoria);
    Task Detelete(Guid id);
}