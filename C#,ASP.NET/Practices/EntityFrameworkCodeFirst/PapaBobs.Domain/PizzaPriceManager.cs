using PapaBobs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class PizzaPriceManager
    {
        public static decimal CalculateCost(OrderDTO orderDTO)
        {
            decimal cost = 0.0M;
            var prices = getPizzaPrices();
            cost += calculateSizeCost(orderDTO, prices);
            cost += calculateCrustCost(orderDTO, prices);
            cost += calculateToppings(orderDTO, prices);
            return cost;
        }

        private static PizzaPriceDTO getPizzaPrices()
        {
            var prices = Persistence.PizzaPriceRepository.GetPizzaPrices();
            return prices;
        }

        private static decimal calculateSizeCost(OrderDTO orderDTO, PizzaPriceDTO pricesDTO)
        {
            decimal cost = 0.0M;
            switch (orderDTO.Size)
            {
                case DTO.Enums.SizeType.Small:
                    cost = pricesDTO.SmallSizeCost;
                    break;
                case DTO.Enums.SizeType.Medium:
                    cost = pricesDTO.MediumSizeCost;
                    break;
                case DTO.Enums.SizeType.Large:
                    cost = pricesDTO.LargeSizeCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static decimal calculateCrustCost(OrderDTO orderDTO, PizzaPriceDTO pricesDTO)
        {
            decimal cost = 0.0M;
            switch (orderDTO.Crust)
            {
                case DTO.Enums.CrustType.Regular:
                    cost = pricesDTO.RegularCrustCost;
                    break;
                case DTO.Enums.CrustType.Thin:
                    cost = pricesDTO.ThinCrustCost;
                    break;
                case DTO.Enums.CrustType.Thick:
                    cost = pricesDTO.ThickCrustCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static decimal calculateToppings(OrderDTO orderDTO, PizzaPriceDTO pricesDTO)
        {
            decimal cost = 0.0M;
            cost += (orderDTO.Sausage) ? pricesDTO.SausageCost : 0M;
            cost += (orderDTO.Pepperoni) ? pricesDTO.PepperoniCost : 0M;
            cost += (orderDTO.Onions) ? pricesDTO.OnionsCost : 0M;
            cost += (orderDTO.GreenPeppers) ? pricesDTO.GreenPeppersCost : 0M;
            return cost;
        }
    }
}
