USE [db_product]
GO
/****** Object:  StoredProcedure [dbo].[ViewByProductID]    Script Date: 04/07/2024 19:03:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[ViewByProductID]
    @ProductID VARCHAR(20)
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
    FROM SalesOrders
    WHERE ProductID = @ProductID;
END;
