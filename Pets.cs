//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YP5
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pets()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int ID_Pets { get; set; }
        public string PetName { get; set; }
        public bool Documents { get; set; }
        public decimal Price { get; set; }
        public int BreedOfPet_ID { get; set; }
        public int Shelter_ID { get; set; }
        public int Naimenovanie_ID { get; set; }
    
        public virtual BreedOfPet BreedOfPet { private get; set; }
        public virtual NaimenovaniePetsa NaimenovaniePetsa { private get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { private get; set; }
        public virtual Shelter Shelter { private get; set; }
    }
}