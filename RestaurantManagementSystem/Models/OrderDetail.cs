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
    
    public partial class OrderDetail
    {
        public System.Guid OrderDetailID { get; set; }
        public System.Guid OrderID { get; set; }
        public System.Guid FoodID { get; set; }
        public System.Guid DrinkID { get; set; }
        public string Notes { get; set; }
    
        public virtual Drink Drink { get; set; }
        public virtual Food Food { get; set; }
        public virtual Order Order { get; set; }
    }
}
