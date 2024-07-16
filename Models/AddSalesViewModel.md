using System;
using System.ComponentModel.DataAnnotations;

namespace SalesRecordManagementSystem.Models
{
    public class AddSalesViewModel
    {
        [Display(Name = "Sales Order")]
        [Required(ErrorMessage = "Sales Order is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Sales Order must be between 1 and 20 characters")]
        public string SalesOrder { get; set; } = string.Empty;

        [Display(Name = "Sales Order Item")]
        [Required(ErrorMessage = "Sales Order Item is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Sales Order Item must be between 1 and 20 characters")]
        public string SalesOrderItem { get; set; } = string.Empty;

        [Display(Name = "Work Order")]
        [Required(ErrorMessage = "Work Order is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Work Order must be between 1 and 20 characters")]
        public string WorkOrder { get; set; } = string.Empty;

        [Display(Name = "Product ID")]
        [Required(ErrorMessage = "Product ID is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Product ID must be between 1 and 20 characters")]
        public string ProductId { get; set; } = string.Empty;

        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "Product Description is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Product Description must be between 1 and 100 characters")]
        public string ProductDesc { get; set; } = string.Empty;

        [Display(Name = "Order Quantity")]
        [Required(ErrorMessage = "Order Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Order Quantity must be a positive number")]
        public decimal OrderQuantity { get; set; }

        [Display(Name = "Order Status")]
        [Required(ErrorMessage = "Order Status is required")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Order Status must be between 1 and 10 characters")]
        public string OrderStatus { get; set; } = string.Empty;

        [Display(Name = "Timestamp")]
        [Required(ErrorMessage = "Timestamp is required")]
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
