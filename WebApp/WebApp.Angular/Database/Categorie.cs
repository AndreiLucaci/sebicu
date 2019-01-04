using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Angular.Database
{
    [Table("Categorie")]
    public class Categorie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categorie()
        {
            this.Retetas = new HashSet<Reteta>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public double categ_id { get; set; }
        public string tip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reteta> Retetas { get; set; }
    }
}
