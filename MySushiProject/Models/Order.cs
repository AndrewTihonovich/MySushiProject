using MySushiProject.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MySushiProject.Models
{
    class Order : IDisposable
    {
        public event Action<Order> OrderComplited;
        public event Action<Order> OrderDelivered;
        public event Action<Order> OrderPaid;

        public Guid Id { get;  }
        public List<BasketOrder> BasketOrders { get; set; }
        public User User { get; set; }
        public double TotalCoast { get; set; }
        public DateTime Date { get; set; }
        public bool isCompleted { get; set; } = false;
        public bool isDelivered { get; set; } = false;
        public bool isPaid { get; set; } = false;

        public Order(Guid id)
        {
            Id = id;
        }

        public void CheckCompleted(Order order)
        {
            if (order.isCompleted == true)
            {
                OrderComplited?.Invoke(order);
            }
        }

        public void CheckDelivered(Order order)
        {
            if (order.isDelivered == true)
            {
                OrderDelivered?.Invoke(order);
            }
        }

        public void CheckPaid(Order order)
        {
            if (order.isPaid == true)
            {
                OrderPaid?.Invoke(order);
            }
        }

        public void Dispose()
        {
            if (isCompleted == true)
            {
                OrderComplited -= OrderComplited;
            }

            if (isDelivered == true)
            {
                OrderDelivered -= OrderDelivered;
            }

            if (isPaid == true)
            {
                OrderPaid -= OrderPaid;
            }
        }

        public string BasketOrdersToString()
        {
            string result=default;
            for (int i = 0; i < this.BasketOrders.Count; i++)
            {
                result = result + $"{this.BasketOrders[i].Name} - {this.BasketOrders[i].AmountInOrder} шт.\n";
            }
            return result;
        }
    }
}
