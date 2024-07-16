using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SalesRecordManagementSystem.Utility;

namespace SalesRecordManagementSystem.Models
{
    public class SalesDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        // Method untuk mendapatkan semua data penjualan
        public IEnumerable<Sales> GetAllSales()
        {
            List<Sales> lstSales = new List<Sales>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ViewAllOrders", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Sales sales = new Sales();
                    sales.Id = Convert.ToInt32(rdr["Id"]);
                    sales.SalesOrder = rdr["SalesOrder"].ToString();
                    sales.SalesOrderItem = rdr["SalesOrderItem"].ToString();
                    sales.WorkOrder = rdr["WorkOrder"].ToString();
                    sales.ProductId = rdr["ProductId"].ToString();
                    sales.ProductDesc = rdr["ProductDescription"].ToString();
                    sales.OrderQuantity = Convert.ToDecimal(rdr["OrderQty"]);
                    sales.OrderStatus = rdr["OrderStatus"].ToString();
                    sales.Timestamp = Convert.ToDateTime(rdr["Timestamp"]);

                    lstSales.Add(sales);
                }
                con.Close();
            }

            return lstSales;
        }

        // Method untuk menambahkan data penjualan
        public void AddSales(Sales sales)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddSalesOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SalesOrder", sales.SalesOrder);
                cmd.Parameters.AddWithValue("@SalesOrderItem", sales.SalesOrderItem);
                cmd.Parameters.AddWithValue("@WorkOrder", sales.WorkOrder);
                cmd.Parameters.AddWithValue("@ProductId", sales.ProductId);
                cmd.Parameters.AddWithValue("@ProductDescription", sales.ProductDesc);
                cmd.Parameters.AddWithValue("@OrderQty", sales.OrderQuantity);
                cmd.Parameters.AddWithValue("@OrderStatus", sales.OrderStatus);
                cmd.Parameters.AddWithValue("@Timestamp", sales.Timestamp);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Method untuk memperbarui data penjualan
        public void UpdateSales(Sales sales)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateOrderById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", sales.Id);
                cmd.Parameters.AddWithValue("@SalesOrder", sales.SalesOrder);
                cmd.Parameters.AddWithValue("@SalesOrderItem", sales.SalesOrderItem);
                cmd.Parameters.AddWithValue("@WorkOrder", sales.WorkOrder);
                cmd.Parameters.AddWithValue("@ProductId", sales.ProductId);
                cmd.Parameters.AddWithValue("@ProductDescription", sales.ProductDesc);
                cmd.Parameters.AddWithValue("@OrderQty", sales.OrderQuantity);
                cmd.Parameters.AddWithValue("@OrderStatus", sales.OrderStatus);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Method untuk mendapatkan data penjualan berdasarkan ID
        public Sales GetSalesData(int? Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id), "Id cannot be null");
            }

            Sales sales = new Sales();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ViewOrderById", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Id", Id);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            sales.Id = Convert.ToInt32(rdr["Id"]);
                            sales.SalesOrder = rdr["SalesOrder"].ToString();
                            sales.SalesOrderItem = rdr["SalesOrderItem"].ToString();
                            sales.WorkOrder = rdr["WorkOrder"].ToString();
                            sales.ProductId = rdr["ProductId"].ToString();
                            sales.ProductDesc = rdr["ProductDescription"].ToString();
                            sales.OrderQuantity = Convert.ToDecimal(rdr["OrderQty"]);
                            sales.OrderStatus = rdr["OrderStatus"].ToString();
                            sales.Timestamp = Convert.ToDateTime(rdr["Timestamp"]);
                        }
                    }
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) as per your logging framework
                throw new Exception("Error while fetching sales data", ex);
            }

            return sales;
        }

        // Method untuk menghapus data penjualan berdasarkan ID
        public void DeleteSales(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        internal Sales UpdateSales(int id)
        {
            return GetSalesData(id);
        }

    }
}