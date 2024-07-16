USE [db_product]
GO
/****** Object:  StoredProcedure [dbo].[DeleteSalesOrder]    Script Date: 04/07/2024 19:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[DeleteSalesOrder]
    @ProductID VARCHAR(20)
AS
BEGIN
    DELETE FROM SalesOrders
    WHERE ProductID = @ProductID;
END;
