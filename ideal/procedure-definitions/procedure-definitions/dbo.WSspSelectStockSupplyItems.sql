





/*RZ14020908*/
Create Procedure [dbo].[WSspSelectStockSupplyItems]
(
/* 
	exec WSspSelectStockSupplyItems  1 , 1033, 1065
*/
@StockSupplyId INT,
@LanguageID INT = NULL,
@DefaultLanguageID INT = NULL 
)
AS
BEGIN
/**/
IF(@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
BEGIN
/**/
	SELECT 
		 [StockSupplyItemId]
		,[StockSupplyId]
		,[stsupIPrdId]		
		,(SELECT TOP(1) PrdName FROM [dbo].[WSProducts] P WHERE ProductID = [stsupIPrdId]) [stsupIPrdName]
		,(SELECT TOP(1) PrdCode FROM [dbo].[WSProducts] P WHERE ProductID = [stsupIPrdId]) [stsupIPrdCode]	
		,(SELECT TOP(1) PrdSingleItem FROM [dbo].[WSProducts] P WHERE ProductID = [stsupIPrdId]) [stsupISingleItem]			
		,(SELECT TOP(1) FGName 
		  FROM [dbo].[WSProductFirstGroup] FG 
		  WHERE PrdFirstGroupId = (SELECT FirstGroupId 
							       FROM [dbo].[WSProductSecondGroup] SG 
								   WHERE PrdSecondGroupId = (SELECT TOP(1) PrdGroupId FROM [dbo].[WSProducts] P WHERE ProductID = [stsupIPrdId]))) [stsupIPrdFGName]
		,(SELECT TOP(1) SGName 
		  FROM [dbo].[WSProductSecondGroup] SG 
		  WHERE PrdSecondGroupId = (SELECT TOP(1) PrdGroupId FROM [dbo].[WSProducts] P WHERE ProductID = [stsupIPrdId]))[stsupIPrdSGName]		
		,[stsupIQuantity]
		,[stsupIDescription]
		,[stsupIQuantityDesc]
		,[stsupIPrdUnitId]
		,(SELECT TOP(1) [Unit] FROM [dbo].[WSProductUnits] U WHERE ProductUnitID = [stsupIPrdUnitId]) [stsupIPrdUnit]
		,[stsupIOrderView]
		,[stsupIFCR]
		,[stsupIFCRI]		
		,[stsupIWHId]
		,(SELECT TOP(1) WH.WrhsName FROM [dbo].[WsWareHouse] WH WHERE WH.WareHouseID = [stsupIWHId]) AS [stsupIWrhsName]
		,[stsupITracing]
		,[stsupIPrdUnitIdI]
		,(SELECT TOP(1) [Unit] FROM [dbo].[WSProductUnits] U WHERE ProductUnitID = [stsupIPrdUnitIdI]) [stsupIPrdUnitI]
		,[stsupIPrdUnitIRateResult]
		,(CASE WHEN (ISNULL([stsupIPrdUnitIRateResult],0) <> 0 )
			   THEN 
					(CAST((FORMAT(ISNULL([stsupIQuantity],0) / ISNULL([stsupIPrdUnitIRateResult],0), '000.000')) AS FLOAT))						
			   ELSE NULL
		 END) [stsupIPrdUnitIRate]
		,[stsupIPrdColorId]
		,(SELECT TOP (1) [Color] FROM [dbo].[WSProductColor] PC WHERE PC.[ProductColorID] = [stsupIPrdColorId]) [stsupIPrdColor]
		,[stsupIPrdNickname]
		,[stsupIPreOrderId]
		,[stsupIPreOrderItemId]		
		,(SELECT TOP (1) [pordIQuantity] FROM [dbo].[WSPreOrderItems] POI WHERE POI.[PreOrderItemId] = [stsupIPreOrderItemId]) [pordIQuantity]
		,(SELECT TOP (1) [pordIFCR] FROM [dbo].[WSPreOrderItems] POI WHERE POI.[PreOrderItemId] = [stsupIPreOrderItemId]) [pordIFCR]
		,(SELECT TOP (1) [pordIFCRI] FROM [dbo].[WSPreOrderItems] POI WHERE POI.[PreOrderItemId] = [stsupIPreOrderItemId]) [pordIFCRI]		
		/**/
		,[stsupIBuyOrderIds]		
		,(SELECT 
			 [BuyOrderID]
			,[BuyOrderOprId]
			,(SELECT TOP (1) [Name] FROM [dbo].[WSBuyOrderOpr] BOPR WHERE BOPR.[BuyOrderOprID] = BO.[BuyOrderOprId])[BuyOrderOpr]
			,[bordNumber]
			,[bordDate]
			,[bordDateTime]			
		FROM [dbo].[WSBuyOrder] BO
		WHERE BO.[BuyOrderID] IN((SELECT CAST(ISNULL(L.[value],'0') AS INT) FROM STRING_SPLIT([stsupIBuyOrderIds], ',') L WHERE CAST(ISNULL([value],'0') AS INT) <> 0))
		FOR JSON PATH) [stsupIBuyOrders] 
		/**/
		,[stsupIBuyOrderItemIds]
		,(SELECT 
			 [BuyOrderItemId]
			,[BuyOrderId]			
			,[bordIQuantity]			
			,[bordIFCR]			
			,[bordIFCRI]			
		FROM [dbo].[WSBuyOrderItems] BOI
		WHERE [BuyOrderItemId] IN(SELECT CAST(ISNULL(L.[value],'0') AS INT) FROM STRING_SPLIT([stsupIBuyOrderItemIds], ',') L WHERE CAST(ISNULL([value],'0') AS INT) <> 0)
		FOR JSON PATH) [stsupIBuyOrderItems]		
		/**/
		,[stsupILinkAccWHIdStr]
		,[FirstRegisterUserId]
		,[FirstRegisterDate]
		,[FirstRegisterDatePersian]
		,[UserId]
		,[FPId]
		,[Month1]
		,[RegisterDate]
		,[RegisterDatePersian]
		,[GUId]
		,[AppType]
		,[LanguageID]
	FROM [dbo].[WSStockSupplyItems] STI
	WHERE [StockSupplyId] = @StockSupplyId
	ORDER BY [stsupIOrderView]
/**/
END
ELSE IF(@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
BEGIN
/**/
	SELECT 
		 [StockSupplyItemId]
		,[StockSupplyId]
		,[stsupIPrdId]		
		,(SELECT TOP(1) PrdName FROM [dbo].[WSProducts_Lang] P WHERE ProductID = [stsupIPrdId] AND P.LanguageID = @LanguageID) [stsupIPrdName]
		,(SELECT TOP(1) PrdCode FROM [dbo].[WSProducts] P WHERE ProductID = [stsupIPrdId]) [stsupIPrdCode]	
		,(SELECT TOP(1) PrdSingleItem FROM [dbo].[WSProducts] P WHERE ProductID = [stsupIPrdId]) [stsupISingleItem]			
		,(SELECT TOP(1) FGName 
		  FROM [dbo].[WSProductFirstGroup_Lang] FG 
		  WHERE PrdFirstGroupId = (SELECT FirstGroupId 
							       FROM [dbo].[WSProductSecondGroup] SG 
								   WHERE PrdSecondGroupId = (SELECT TOP(1) PrdGroupId FROM [dbo].[WSProducts] P WHERE ProductID = [stsupIPrdId]))
		 AND FG.LanguageID = @LanguageID) [stsupIPrdFGName]
		,(SELECT TOP(1) SGName 
		  FROM [dbo].[WSProductSecondGroup_Lang] SG 
		  WHERE PrdSecondGroupId = (SELECT TOP(1) PrdGroupId FROM [dbo].[WSProducts] P WHERE ProductID = [stsupIPrdId])
		  AND SG.LanguageID = @LanguageID)[stsupIPrdSGName]		
		,[stsupIQuantity]
		,(SELECT TOP(1) STILN.[stsupIDescription] FROM [dbo].[WSStockSupplyItems_Lang] STILN WHERE STILN.StockSupplyItemId = STI.StockSupplyItemId AND STILN.LanguageID = @LanguageID)[stsupIDescription]
		,(SELECT TOP(1) STILN.[stsupIQuantityDesc] FROM [dbo].[WSStockSupplyItems_Lang] STILN WHERE STILN.StockSupplyItemId = STI.StockSupplyItemId AND STILN.LanguageID = @LanguageID) [stsupIQuantityDesc]
		,[stsupIPrdUnitId]
		,(SELECT TOP(1) [Unit] FROM [dbo].[WSProductUnits_Lang] U WHERE ProductUnitID = [stsupIPrdUnitId] AND U.LanguageID = @LanguageID) [stsupIPrdUnit]
		,[stsupIOrderView]
		,[stsupIFCR]
		,[stsupIFCRI]		
		,[stsupIWHId]
		,(SELECT TOP(1) WH.WrhsName FROM [dbo].[WsWareHouse_Lang] WH WHERE WH.WareHouseID = [stsupIWHId] AND WH.LanguageID = @LanguageID) AS [stsupIWrhsName]
		,[stsupITracing]
		,[stsupIPrdUnitIdI]
		,(SELECT TOP(1) [Unit] FROM [dbo].[WSProductUnits_Lang] U WHERE ProductUnitID = [stsupIPrdUnitIdI] AND U.LanguageID = @LanguageID) [stsupIPrdUnitI]
		,[stsupIPrdUnitIRateResult]
		,(CASE WHEN (ISNULL([stsupIPrdUnitIRateResult],0) <> 0 )
			   THEN 
					(CAST((FORMAT(ISNULL([stsupIQuantity],0) / ISNULL([stsupIPrdUnitIRateResult],0), '000.000')) AS FLOAT))						
			   ELSE NULL
		 END) [stsupIPrdUnitIRate]
		,[stsupIPrdColorId]
		,(SELECT TOP (1) [Color] FROM [dbo].[WSProductColor_Lang] PC WHERE PC.[ProductColorID] = [stsupIPrdColorId] AND PC.LanguageID = @LanguageID) [stsupIPrdColor]
		,(SELECT TOP(1) STILN.[stsupIPrdNickname] FROM [dbo].[WSStockSupplyItems_Lang] STILN WHERE STILN.StockSupplyItemId = STI.StockSupplyItemId AND STILN.LanguageID = @LanguageID)[stsupIPrdNickname]
		,[stsupIPreOrderId]
		,[stsupIPreOrderItemId]
		,(SELECT TOP (1) [pordIQuantity] FROM [dbo].[WSPreOrderItems] POI WHERE POI.[PreOrderItemId] = [stsupIPreOrderItemId]) [pordIQuantity]
		,(SELECT TOP (1) [pordIFCR] FROM [dbo].[WSPreOrderItems] POI WHERE POI.[PreOrderItemId] = [stsupIPreOrderItemId]) [pordIFCR]
		,(SELECT TOP (1) [pordIFCRI] FROM [dbo].[WSPreOrderItems] POI WHERE POI.[PreOrderItemId] = [stsupIPreOrderItemId]) [pordIFCRI]		
		/**/
		,[stsupIBuyOrderIds]		
		,(SELECT 
			 [BuyOrderID]
			,[BuyOrderOprId]
			,(SELECT TOP (1) [Name] FROM [dbo].[WSBuyOrderOpr_Lang] BOPR WHERE BOPR.[BuyOrderOprID] = BO.[BuyOrderOprId] AND BOPR.LanguageID = @LanguageID)[BuyOrderOpr]
			,[bordNumber]
			,[bordDate]
			,[bordDateTime]			
		FROM [dbo].[WSBuyOrder] BO
		WHERE BO.[BuyOrderID] IN((SELECT CAST(ISNULL(L.[value],'0') AS INT) FROM STRING_SPLIT([stsupIBuyOrderIds], ',') L WHERE CAST(ISNULL([value],'0') AS INT) <> 0))
		FOR JSON PATH) [stsupIBuyOrders] 
		/**/
		,[stsupIBuyOrderItemIds]
		,(SELECT 
			 [BuyOrderItemId]
			,[BuyOrderId]			
			,[bordIQuantity]			
			,[bordIFCR]			
			,[bordIFCRI]			
		FROM [dbo].[WSBuyOrderItems] BOI
		WHERE [BuyOrderItemId] IN(SELECT CAST(ISNULL(L.[value],'0') AS INT) FROM STRING_SPLIT([stsupIBuyOrderItemIds], ',') L WHERE CAST(ISNULL([value],'0') AS INT) <> 0)
		FOR JSON PATH) [stsupIBuyOrderItems]		
		/**/
		,[stsupILinkAccWHIdStr]
		,[FirstRegisterUserId]
		,[FirstRegisterDate]
		,[FirstRegisterDatePersian]
		,[UserId]
		,[FPId]
		,[Month1]
		,[RegisterDate]
		,[RegisterDatePersian]
		,[GUId]
		,[AppType]
		,[LanguageID]
	FROM [dbo].[WSStockSupplyItems] STI
	WHERE [StockSupplyId] = @StockSupplyId
	ORDER BY [stsupIOrderView]
/**/
END
/**/
END









