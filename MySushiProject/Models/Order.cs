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

        public Guid Id { get;  }// = Guid.NewGuid();
        public List<BasketOrder> BasketOrders { get; set; }
        public User User { get; set; }
        public double TotalCoast { get; set; }
        public DateTime Date { get; set; }
        public bool isCompleted { get; set; } = false;
        public bool isDelivered { get; set; } = false;
        public bool isPaid { get; set; } = false;

        //[JsonConstructor]
        //public Order(Guid id, List<BasketOrder> basketOrders, User user, double totalCoast, DateTime date)
        //{
        //    Id = id;
        //    BasketOrders = basketOrders;
        //    User = user;
        //    TotalCoast = totalCoast;
        //    Date = date;
        //}

        public Order(Guid id)
        {
            Id = id;
        }

        //public Order()
        //{

        //}

        

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

        public override string ToString()
        {
            return $"{User} \n Заказ:\n {BasketOrders}\n Общая стоимость заказа {TotalCoast}";
        }

        public void Dispose()
        {
            //if (this.isCompleted == true)
            //{
                this.OrderComplited -= OrderComplited;
            //}

            //if (this.isDelivered == true)
            //{
                this.OrderDelivered -= OrderDelivered;
            //}

            //if (this.isPaid == true)
            //{
                this.OrderPaid -= OrderPaid;
            //}
        }
    }
}
