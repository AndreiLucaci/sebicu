using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Angular.Database
{
    [Table("Set_ingrediente")]
    public class Set_ingrediente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Set_ingrediente()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }

        public double? reteta_id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public double ingred_id { get; set; }
        public double? cantitate { get; set; }
        public string um { get; set; }
        public string comentarii { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual Reteta Reteta { get; set; }
    }
}
