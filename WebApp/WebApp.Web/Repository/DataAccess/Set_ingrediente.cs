//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp.Web.Repository.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Set_ingrediente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Set_ingrediente()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }
    
        public Nullable<double> reteta_id { get; set; }
        public double ingred_id { get; set; }
        public Nullable<double> cantitate { get; set; }
        public string um { get; set; }
        public string comentarii { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual Reteta Reteta { get; set; }
    }
}
