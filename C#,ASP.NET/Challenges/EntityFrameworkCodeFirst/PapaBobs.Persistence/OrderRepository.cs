using PapaBobs.DTO;
using PapaBobs.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Persistence
{
    public class OrderRepository
    {
        public static void CreateOrder(OrderDTO orderDTO)
        {
            var db = new PapaBobsEntities();
            var order = convertToEntity(orderDTO);
            db.Orders.Add(order);
            db.SaveChanges();
        }

        private static Order convertToEntity(OrderDTO orderDTO)
        {
            var order = new Order();

            order.OrderId = orderDTO.OrderId;
            order.Size = orderDTO.Size;
            order.Crust = orderDTO.Crust;
            order.Sausage = orderDTO.Sausage;
            order.Pepperoni = orderDTO.Pepperoni;
            order.Onions = orderDTO.Onions;
            order.GreenPeppers = orderDTO.GreenPeppers;
            order.TotalCost = orderDTO.TotalCost;
            order.Name = orderDTO.Name;
            order.Address = orderDTO.Address;
            order.Zip = orderDTO.Zip;
            order.Phone = orderDTO.Phone;
            order.PaymentType = orderDTO.PaymentType;
            order.Completed = orderDTO.Completed;

            return order;
        }

        public static List<OrderDTO> GetOrders()
        {
            var db = new PapaBobsEntities();
            var orders = db.Orders.Where(p => p.Completed == false).ToList();
            var ordersDTO = convertToDTO(orders);
            return ordersDTO;
        }

        private static List<OrderDTO> convertToDTO(List<Order> orders)
        {
            var ordersDTO = new List<OrderDTO>();

            foreach (var order in orders)
            {
                var orderDTO = new OrderDTO();

                orderDTO.OrderId = order.OrderId;
                orderDTO.Size = order.Size;
                orderDTO.Crust = order.Crust;
                orderDTO.Sausage = order.Sausage;
                orderDTO.Pepperoni = order.Pepperoni;
                orderDTO.Onions = order.Onions;
                orderDTO.GreenPeppers = order.GreenPeppers;
                orderDTO.TotalCost = order.TotalCost;
                orderDTO.Name = order.Name;
                orderDTO.Address = order.Address;
                orderDTO.Zip = order.Zip;
                orderDTO.Phone = order.Phone;
                orderDTO.PaymentType = order.PaymentType;
                orderDTO.Completed = order.Completed;

                ordersDTO.Add(orderDTO);
            }
            return ordersDTO;
        }

        public static void FinishOrder(Guid orderId)
        {
            var db = new PapaBobsEntities();
            var order = db.Orders.First(p => p.OrderId == orderId);
            order.Completed = true;
            db.SaveChanges();
        }
    }
}
