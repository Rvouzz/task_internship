USE [db_product]
GO
/****** Object:  StoredProcedure [dbo].[ViewAllOrders]    Script Date: 04/07/2024 19:04:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ViewAllOrders]
AS
BEGIN
    SELECT 
        SalesOrder, 
        SalesOrderItem, 
        WorkOrder, 
        ProductID, 
        ProductDescription, 
        OrderQty, 
        OrderStatus, 
        Timestamp
    FROM SalesOrders;
END;
