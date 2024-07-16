using Microsoft.AspNetCore.Mvc;
using SalesRecordManagementSystem.Models;
using System.Linq;

namespace SalesRecordManagementSystem.Controllers
{
    public class SalesController : Controller
    {
        private readonly SalesDataAccessLayer _salesDataAccessLayer = new SalesDataAccessLayer();

        public IActionResult Index()
        {
            var salesList = _salesDataAccessLayer.GetAllSales().ToList();
            return View(salesList);
        }

        [HttpPost]
        public IActionResult SaveAdd(Sales model)
        {
            if (ModelState.IsValid)
            {
                var sales = new Sales
                {
                    SalesOrder = model.SalesOrder,
                    SalesOrderItem = model.SalesOrderItem,
                    WorkOrder = model.WorkOrder,
                    ProductId = model.ProductId,
                    ProductDesc = model.ProductDesc,
                    OrderQuantity = model.OrderQuantity,
                    OrderStatus = model.OrderStatus,
                    Timestamp = model.Timestamp
                };

                _salesDataAccessLayer.AddSales(sales);
                return RedirectToAction("Index");
            }
            return PartialView("_AddSalesPartial", model);
        }

        public IActionResult SaveEdit(Sales model)
        {
            if (ModelState.IsValid)
            {
                var existingSales = _salesDataAccessLayer.GetSalesData(model.Id);
                if (existingSales == null)
                {
                    return NotFound();
                }

                existingSales.SalesOrder = model.SalesOrder;
                existingSales.SalesOrderItem = model.SalesOrderItem;
                existingSales.WorkOrder = model.WorkOrder;
                existingSales.ProductId = model.ProductId;
                existingSales.ProductDesc = model.ProductDesc;
                existingSales.OrderQuantity = model.OrderQuantity;
                existingSales.OrderStatus = model.OrderStatus;
                existingSales.Timestamp = model.Timestamp;

                _salesDataAccessLayer.UpdateSales(existingSales);
                return RedirectToAction("Index");
            }
            else
            {
                // Return the partial view with the validation errors
                return PartialView("_EditSalesPartial", model);
            }
        }

        public IActionResult GetSalesData(int id)
        {
            var salesData = _salesDataAccessLayer.GetSalesData(id);
            return PartialView("_DetailsSalesPartial", salesData);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _salesDataAccessLayer.DeleteSales(Id);
            return RedirectToAction("Index");
        }
    }
}