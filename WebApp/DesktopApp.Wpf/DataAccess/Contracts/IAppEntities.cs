using System.Data.Entity;

namespace DesktopApp.Wpf.DataAccess.Contracts
{
    public interface IAppEntities
    {
        DbSet<Categorie> Categories { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Reteta> Retetas { get; set; }
        DbSet<Set_ingrediente> Set_ingrediente { get; set; }
    }
}
