namespace PapaBobs.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using PapaBobs.DTO.Enums;

    public partial class Order
    {
        public Guid OrderId { get; set; }

        public SizeType Size { get; set; }

        public CrustType Crust { get; set; }

        public bool Sausage { get; set; }

        public bool Pepperoni { get; set; }

        public bool Onions { get; set; }

        public bool GreenPeppers { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal TotalCost { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Zip { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        public PaymentType PaymentType { get; set; }

        public bool Completed { get; set; }
    }
}
