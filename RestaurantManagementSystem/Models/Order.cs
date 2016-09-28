//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public System.Guid OrderID { get; set; }
        public string OrderDescription { get; set; }
        public Nullable<System.DateTime> OrderDateTime { get; set; }
        public string OrderPerson { get; set; }
        public string DeliveryAddress { get; set; }
        public string OrderPersonPhone { get; set; }
        public Nullable<decimal> OrderOriginalPrice { get; set; }
        public Nullable<System.Guid> OrderStatusID { get; set; }
        public Nullable<decimal> OrderDiscountedPrice { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
