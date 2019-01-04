using System;
using System.Collections.Generic;
using System.Linq;
using DesktopApp.Wpf.DataAccess;
using DesktopApp.Wpf.DataAccess.Contracts;
using DesktopApp.Wpf.ViewModels;

namespace DesktopApp.Wpf.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly IAppEntities _entities;

        public FoodRepository(IAppEntities entities)
        {
            _entities = entities;
        }

        public ICollection<Reteta> GetReteteVegetariene()
        {
            var retete =
                from reteta in _entities.Retetas
                where reteta.vegetariana == "D"
                orderby reteta.timp_preparare descending
                select reteta;

            return retete.ToList();
        }

        public ICollection<Reteta> GetReteteWithoutCiuperci()
        {
            var retete =
                from set_ingrediente in _entities.Set_ingrediente
                join reteta in _entities.Retetas on set_ingrediente.reteta_id equals reteta.reteta_id
                join ingredient in _entities.Ingredients on set_ingrediente.ingred_id equals ingredient.ingred_id
                where ingredient.ingredient1 != "ciuperci"
                select reteta;

            return retete.Distinct().ToList();
        }

        public ICollection<SIViewModel> GetSIFaraComentarii()
        {
            var siValues =
                from set_ingrediente in _entities.Set_ingrediente
                join reteta in _entities.Retetas on set_ingrediente.reteta_id equals reteta.reteta_id
                join ingredient in _entities.Ingredients on set_ingrediente.ingred_id equals ingredient.ingred_id
                where string.IsNullOrEmpty(set_ingrediente.comentarii)
                select new SIViewModel
                {
                    NumeIngredient = ingredient.ingredient1,
                    NumeReteta = reteta.nume,
                    cantitate = set_ingrediente.cantitate,
                    comentarii = set_ingrediente.comentarii,
                    um = set_ingrediente.um
                };

            return siValues.ToList();
        }

        public ICollection<SIViewModel> GetAllSI()
        {
            var siValues =
                from set_ingrediente in _entities.Set_ingrediente
                join reteta in _entities.Retetas on set_ingrediente.reteta_id equals reteta.reteta_id
                join ingredient in _entities.Ingredients on set_ingrediente.ingred_id equals ingredient.ingred_id
                select new SIViewModel
                {
                    NumeIngredient = ingredient.ingredient1,
                    NumeReteta = reteta.nume,
                    cantitate = set_ingrediente.cantitate,
                    comentarii = set_ingrediente.comentarii,
                    um = set_ingrediente.um
                };

            return siValues.ToList();
        }

        public ICollection<RetetaPairViewModel> GetMeniu()
        {
            var retetaFelul1 =
                (from reteta in _entities.Retetas
                 join categorie in _entities.Categories on reteta.categ_id equals categorie.categ_id
                 where categorie.tip == "Ciorba" || categorie.tip == "Supa"
                 select reteta).ToList();

            var retetaFelul2 =
                (from reteta in _entities.Retetas
                 join categorie in _entities.Categories on reteta.categ_id equals categorie.categ_id
                 where categorie.tip != "Ciorba" && categorie.tip != "Supa"
                 select reteta).ToList();

            var items = (from felul2 in retetaFelul2
                         from felul1 in retetaFelul1
                         select new RetetaPairViewModel
                         {
                             Felul1 = felul1.nume,
                             Felul2 = felul2.nume
                         })
                .OrderBy(i => i.Felul1)
                .ToList();

            return items;
        }

        public ICollection<Reteta> GetRetetaVegetarianaWithMinTimpPreparare()
        {
            var retete =
                from reteta in _entities.Retetas
                where reteta.vegetariana == "D"
                orderby reteta.timp_preparare descending
                select reteta;

            var min = retete.ToList().Min(i => i.timp_preparare);

            return retete.Where(i => i.timp_preparare == min).ToList();
        }

        public ICollection<SIViewModel> GetSIWithMoreThenCiuperci()
        {
            var maxIngredienteCiuperci =
                (from set_ingrediente in _entities.Set_ingrediente
                 join ingredient in _entities.Ingredients on set_ingrediente.ingred_id equals ingredient.ingred_id
                 where ingredient.ingredient1 == "ciuperci"
                 select set_ingrediente)
                .ToList().Max(x => x.cantitate);

            var siValues =
                from set_ingrediente in _entities.Set_ingrediente
                join reteta in _entities.Retetas on set_ingrediente.reteta_id equals reteta.reteta_id
                join ingredient in _entities.Ingredients on set_ingrediente.ingred_id equals ingredient.ingred_id
                where reteta.nume != "tocanita cu ciuperci" && set_ingrediente.cantitate > maxIngredienteCiuperci && ingredient.ingredient1 != "ciuperci"
                select new SIViewModel
                {
                    NumeIngredient = ingredient.ingredient1,
                    NumeReteta = reteta.nume,
                    cantitate = set_ingrediente.cantitate,
                    comentarii = set_ingrediente.comentarii,
                    um = set_ingrediente.um
                };

            return siValues.ToList();
        }

        public ICollection<SIViewModel> GetMaxUsturoi()
        {
            var maxIngredienteUsturoi =
                (from set_ingrediente in _entities.Set_ingrediente
                    join ingredient in _entities.Ingredients on set_ingrediente.ingred_id equals ingredient.ingred_id
                    where ingredient.ingredient1 == "usturoi"
                    select set_ingrediente)
                .ToList().Max(x => x.cantitate);

            var siValues =
                from set_ingrediente in _entities.Set_ingrediente
                join reteta in _entities.Retetas on set_ingrediente.reteta_id equals reteta.reteta_id
                join ingredient in _entities.Ingredients on set_ingrediente.ingred_id equals ingredient.ingred_id
                join categorie in _entities.Categories on reteta.categ_id equals categorie.categ_id
                where categorie.tip == "ciorba" && set_ingrediente.cantitate == maxIngredienteUsturoi
                select new SIViewModel
                {
                    NumeIngredient = ingredient.ingredient1,
                    NumeReteta = reteta.nume,
                    cantitate = set_ingrediente.cantitate,
                    comentarii = set_ingrediente.comentarii,
                    um = set_ingrediente.um
                };

            return siValues.ToList();
        }

        public ICollection<CategorieViewModel> GetTimpMediu()
        {
            var catItems =
                from categorie in _entities.Categories
                join reteta in _entities.Retetas on categorie.categ_id equals reteta.categ_id
                group reteta by new
                {
                    categorie.tip,
                }
                into grouping
                select new CategorieViewModel
                {
                    TimpMediuDePregatire = grouping.Average(i => i.timp_preparare),
                    NumeCategorie = grouping.Key.tip
                };

            return catItems.ToList();
        }
    }
}
