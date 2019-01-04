using System.Collections.Generic;
using DesktopApp.Wpf.DataAccess;
using DesktopApp.Wpf.ViewModels;

namespace DesktopApp.Wpf.Repository
{
    public interface IFoodRepository
    {
        ICollection<Reteta> GetReteteVegetariene();
        ICollection<Reteta> GetReteteWithoutCiuperci();
        ICollection<Reteta> GetRetetaVegetarianaWithMinTimpPreparare();

        ICollection<RetetaPairViewModel> GetMeniu();

        ICollection<SIViewModel> GetSIFaraComentarii();
        ICollection<SIViewModel> GetAllSI();
        ICollection<SIViewModel> GetSIWithMoreThenCiuperci();
        ICollection<SIViewModel> GetMaxUsturoi();

        ICollection<CategorieViewModel> GetTimpMediu();
    }
}
