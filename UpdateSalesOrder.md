USE [db_product]
GO
/****** Object:  StoredProcedure [dbo].[UpdateSalesOrder]    Script Date: 04/07/2024 19:03:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[UpdateSalesOrder]
    @ProductID VARCHAR(20),
    @SalesOrder VARCHAR(20) = NULL,
    @SalesOrderItem INT = NULL,
    @WorkOrder VARCHAR(20) = NULL,
    @ProductDescription VARCHAR(100) = NULL,
    @OrderQty INT = NULL,
    @OrderStatus VARCHAR(10) = NULL,
    @Timestamp DATETIME = NULL
AS
BEGIN
    UPDATE SalesOrders
    SET 
        SalesOrder = COALESCE(@SalesOrder, SalesOrder),
        SalesOrderItem = COALESCE(@SalesOrderItem, SalesOrderItem),
        WorkOrder = COALESCE(@WorkOrder, WorkOrder),
        ProductDescription = COALESCE(@ProductDescription, ProductDescription),
        OrderQty = COALESCE(@OrderQty, OrderQty),
        OrderStatus = COALESCE(@OrderStatus, OrderStatus),
        Timestamp = COALESCE(@Timestamp, Timestamp)
    WHERE 
        ProductID = @ProductID;
END;
