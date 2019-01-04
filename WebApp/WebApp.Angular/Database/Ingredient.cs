using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Angular.Database
{
    [Table("Ingredient")]
    public class Ingredient
    {
        public double? ingred_id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ingredient { get; set; }

        public virtual Set_ingrediente Set_ingrediente { get; set; }
    }
}
