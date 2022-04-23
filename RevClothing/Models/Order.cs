using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RevClothing.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string BillingAddress { get; set; }
        public string ContactNo { get; set; }
        public string Remarks { get; set; }
        public PaymentMethod Method { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateCompleted { get; set; }
    }
    public enum PaymentMethod
    {
        CashOnDelivery = 1,
        BankDeposit = 2
    }
    public enum OrderStatus
    {
        OnGoing = 1,
        Completed = 2
    }
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public virtual Order Order { get; set; }
        public User Customer { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }

    }
}
