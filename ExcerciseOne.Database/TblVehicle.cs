//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExcerciseOne.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblVehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblVehicle()
        {
            this.TblRoutes = new HashSet<TblRoute>();
        }
    
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public decimal EnterCost { get; set; }
        public decimal DistanceCost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblRoute> TblRoutes { get; set; }
    }
}
