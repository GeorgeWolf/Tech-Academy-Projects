namespace PapaBobs.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PizzaPrice")]
    public partial class PizzaPrice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal SmallSizeCost { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal MediumSizeCost { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal LargeSizeCost { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal RegularCrustCost { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal ThinCrustCost { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal ThickCrustCost { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal SausageCost { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal PepperoniCost { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal OnionsCost { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal GreenPeppersCost { get; set; }
    }
}
