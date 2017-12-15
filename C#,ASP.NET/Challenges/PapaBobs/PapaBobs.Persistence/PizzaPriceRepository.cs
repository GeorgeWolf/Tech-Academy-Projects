using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobs.DTO;

namespace PapaBobs.Persistence
{
    public class PizzaPriceRepository
    {
        public static PizzaPriceDTO GetPizzaPrices()
        {
            var db = new PapaBobsDbEntities();
            var getPrices = db.PizzaPrices.First();
            var dtoPrices = convertToDTO(getPrices);
            return dtoPrices;
        }

        private static PizzaPriceDTO convertToDTO(PizzaPrice pizzaPrice)
        {
            var dtoPrices = new PizzaPriceDTO();
            
            dtoPrices.SmallSizeCost = pizzaPrice.SmallSizeCost;
            dtoPrices.MediumSizeCost = pizzaPrice.MediumSizeCost;
            dtoPrices.LargeSizeCost = pizzaPrice.LargeSizeCost;
            dtoPrices.RegularCrustCost = pizzaPrice.RegularCrustCost;
            dtoPrices.ThinCrustCost = pizzaPrice.ThinCrustCost;
            dtoPrices.ThickCrustCost = pizzaPrice.ThickCrustCost;
            dtoPrices.SausageCost = pizzaPrice.SausageCost;
            dtoPrices.PepperoniCost = pizzaPrice.PepperoniCost;
            dtoPrices.OnionsCost = pizzaPrice.OnionsCost;
            dtoPrices.GreenPeppersCost = pizzaPrice.GreenPeppersCost;

            return dtoPrices;
        }
    }
}
