USE [db_product]
GO
/****** Object:  StoredProcedure [dbo].[AddSalesOrder]    Script Date: 04/07/2024 19:01:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[AddSalesOrder]
    @SalesOrder VARCHAR(20),
    @SalesOrderItem INT,
    @WorkOrder VARCHAR(20),
    @ProductID VARCHAR(20),
    @ProductDescription VARCHAR(100),
    @OrderQty INT,
    @OrderStatus VARCHAR(10),
    @Timestamp DATETIME
AS
BEGIN
    INSERT INTO SalesOrders (
        SalesOrder, 
        SalesOrderItem, 
        WorkOrder, 
        ProductID, 
        ProductDescription, 
        OrderQty, 
        OrderStatus, 
        Timestamp
    )
    VALUES (
        @SalesOrder, 
        @SalesOrderItem, 
        @WorkOrder, 
        @ProductID, 
        @ProductDescription, 
        @OrderQty, 
        @OrderStatus, 
        @Timestamp
    );
END;
