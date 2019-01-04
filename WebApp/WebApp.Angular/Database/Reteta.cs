using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Angular.Database
{
    [Table("Reteta")]
    public class Reteta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reteta()
        {
            this.Set_ingrediente = new HashSet<Set_ingrediente>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public double reteta_id { get; set; }
        public string nume { get; set; }
        public string descriere { get; set; }
        public double? categ_id { get; set; }
        public string vegetariana { get; set; }
        public double? timp_preparare { get; set; }
        public int? portii { get; set; }
        public string sursa { get; set; }

        public virtual Categorie Categorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Set_ingrediente> Set_ingrediente { get; set; }
    }
}
