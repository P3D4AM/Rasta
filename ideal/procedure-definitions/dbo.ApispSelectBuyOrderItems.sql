






/*NKR14030301*/
CREATE PROCEDURE [dbo].[ApispSelectBuyOrderItems]
(
	/*
		EXEC [ApispSelectBuyOrderItems]
			@BuyOrderItemId=0,
			@BuyOrderId=411,
			@LanguageID=1065,
			@DefaultLanguageID=1065
	*/
	@BuyOrderItemId INT = NULL,
	@BuyOrderId INT = NULL,
	@LanguageID INT = NULL,
	@DefaultLanguageID INT  = NULL
)
AS
BEGIN
	/**/
	DECLARE @Cols NVARCHAR(MAX) = '',
			@Term NVARCHAR(MAX) = '',
			@LanguageCollation NVARCHAR(50) = (SELECT L.LanguageCollation FROM Languages L WHERE L.LanguageID = @LanguageID)


	/**/
	IF (@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
		/**/
		SET @Cols = N'
			[BuyOrderItemId] AS [ApiBuyOrderItemId],
			[BuyOrderId] AS [ApiBuyOrderId],
			[bordIPrdId] AS [ApiBordIPrdId],
			[bordIQuantity] AS [ApiBordIQuantity],
			[bordICost] AS [ApiBordICost],
			[bordITotalCost] AS [ApiBordITotalCost],
			[bordIDescription] AS [ApiBordIDescription],
			[bordIQuantityDesc] AS [ApiBordIQuantityDesc],
			[bordIDiscount] AS [ApiBordIDiscount],
			[bordIDiscountI] AS [ApiBordIDiscountI],
			[bordIDiscountPercent] AS [ApiBordIDiscountPercent],
			[bordIDiscountIPercent] AS [ApiBordIDiscountIPercent],
			[bordIPrdUnitId] AS [ApiBordIPrdUnitId],
			(SELECT U.Unit FROM WSProductUnits U WHERE U.ProductUnitID = BOI.bordIPrdUnitId) AS [ApiBordIPrdUnit],
			[bordICurrencyUnitId] AS [ApiBordICurrencyUnitId],
			(SELECT U.CurrencyUnit FROM WSCurrencyUnits U WHERE U.CurrencyUnitID = BOI.bordICurrencyUnitId) AS [ApiBordICurrencyUnit],
			[bordIOrderView] AS [ApiBordIOrderView],
			[bordIFCR] AS [ApiBordIFCR],
			[bordITax] AS [ApiBordITax],
			[bordITaxIndex] AS [ApiBordITaxIndex],
			[bordICalculateTax] AS [ApiBordICalculateTax],
			[bordINotVisible] AS [ApiBordINotVisible],
			[bordIFCRI] AS [ApiBordIFCRI],
			[bordINotInSum] AS [ApiBordINotInSum],
			[bordIWHId] AS [ApiBordIWHId],
			(SELECT WrhsName FROM WsWareHouse W WHERE W.WareHouseID = BOI.bordIWHId) AS [ApiBordIWH],
			[bordILinkAccItemId] AS [ApiBordILinkAccItemId],
			[bordIPrdCostGroupID] AS [ApiBordIPrdCostGroupID],
			[bordITracing] AS [ApiBordITracing],
			[bordICostSum] AS [ApiBordICostSum],
			[bordIDiscountSum] AS [ApiBordIDiscountSum],
			[bordIDiscountISum] AS [ApiBordIDiscountISum],
			[bordITaxSum] AS [ApiBordITaxSum],
			[bordITaxCleared] AS [ApiBordITaxCleared],
			[bordITaxClearedDate] AS [ApiBordITaxClearedDate],
			(FORMAT([bordITaxClearedDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordITaxClearedDatePersian],
			[bordIFacilityCost] AS [ApiBordIFacilityCost],
			[bordIFacilityCostPercent] AS [ApiBordIFacilityCostPercent],
			[bordIForwarderName] AS [ApiBordIForwarderName],
			[bordIFreightCost] AS [ApiBordIFreightCost],
			[bordIFreightCurrUnId] AS [ApiBordIFreightCurrUnId],
			(SELECT U.CurrencyUnit FROM WSCurrencyUnits U WHERE U.CurrencyUnitID = BOI.bordIFreightCurrUnId) AS [ApiBordIFreightCurrUn],
			[bordIFreightCurrencyRate] AS [ApiBordIFreightCurrencyRate],
			[bordIFinalFreightCost] AS [ApiBordIFinalFreightCost],
			[bordICustomsPart] AS [ApiBordICustomsPart],
			[bordICustomsFee] AS [ApiBordICustomsFee],
			[bordICustomsCurrUnId] AS [ApiBordICustomsCurrUnId],
			'
		SET @Cols = @Cols + N'
			(SELECT U.CurrencyUnit FROM WSCurrencyUnits U WHERE U.CurrencyUnitID = BOI.[bordICustomsCurrUnId]) AS [ApiBordICustomsCurrUn],
			[bordICustomsCurrencyRate] AS [ApiBordICustomsCurrencyRate],
			[bordIFinalCustomsFee] AS [ApiBordIFinalCustomsFee],
			[bordITotalFinalCost] AS [ApiBordITotalFinalCost],
			[bordIPreOrderItemId] AS [ApiBordIPreOrderItemId],
			[bordICommission] AS [ApiBordICommission],
			[bordICommissionCurrUnId] AS [ApiBordICommissionCurrUnId],
			(SELECT U.CurrencyUnit FROM WSCurrencyUnits U WHERE U.CurrencyUnitID = BOI.bordICommissionCurrUnId) AS [ApiBordICommissionCurrUn],
			[bordICommissionCurrencyRate] AS [ApiBordICommissionCurrencyRate],
			[bordIFinalCommission] AS [ApiBordIFinalCommission],
			[bordICostSheetItemId] AS [ApiBordICostSheetItemId],
			[bordILinkAccWHIdStr] AS [ApiBordILinkAccWHIdStr],
			[bordIQuantityTotal] AS [ApiBordIQuantityTotal],
			[bordIPrdUnitIdI] AS [ApiBordIPrdUnitIdI],
			(SELECT U.Unit FROM WSProductUnits U WHERE U.ProductUnitID = BOI.bordIPrdUnitIdI) AS [ApiBordIPrdUnitI],
			[bordIPrdUnitIRateResult] AS [ApiBordIPrdUnitIRateResult],
			[bordIPrdColorId] AS [ApiBordIPrdColorId],
			[bordIPrdNickname] AS [ApiBordIPrdNickname],
			[bordILinkAccFirstTransferDate] AS [ApiBordILinkAccFirstTransferDate],
			[bordILinkAccLastTransferDate] AS [ApiBordILinkAccLastTransferDate],
			[bordILinkAccItemIdStr] AS [ApiBordILinkAccItemIdStr],
			[bordICurrencyUnitIdI] AS [ApiBordICurrencyUnitIdI],
			(SELECT U.CurrencyUnitID FROM WSCurrencyUnits U WHERE U.CurrencyUnitID = BOI.bordICurrencyUnitIdI) AS [ApiBordICurrencyUnitI],
			[bordICurrencyUnitIRate] AS [ApiBordICurrencyUnitIRate],
			[bordICostCurrencyI] AS [ApiBordICostCurrencyI],
			[bordITotalCostCurrencyI] AS [ApiBordITotalCostCurrencyI],
			[bordIDiscountCurrencyI] AS [ApiBordIDiscountCurrencyI],
			[bordIDiscountICurrencyI] AS [ApiBordIDiscountICurrencyI],
			[bordITaxCurrencyI] AS [ApiBordITaxCurrencyI],
			[bordICostSumCurrencyI] AS [ApiBordICostSumCurrencyI],
			[bordIDiscountSumCurrencyI] AS [ApiBordIDiscountSumCurrencyI],
			[bordIDiscountISumCurrencyI] AS [ApiBordIDiscountISumCurrencyI],
			[bordITaxSumCurrencyI] AS [ApiBordITaxSumCurrencyI],
			
			[GUId] AS [ApiGUId],
			[UserId] AS [ApiUserId],
			(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = BOI.UserId) AS [ApiEditUser],
			[FPId] AS [ApiFPId],
			[Month1] AS [ApiMonth1],
			[RegisterDate] AS [ApiRegisterDate],
			(FORMAT([RegisterDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiRegisterDatePersian],
			[AppType] AS [ApiAppType],
			[LanguageID] AS [ApiLanguageID],
			[FirstRegisterUserId] AS [ApiFirstRegisterUserId],
			(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = BOI.FirstRegisterUserId) AS [ApiFirstRegisterUser],
			[FirstRegisterDate] AS [ApiFirstRegisterDate],
			(FORMAT([FirstRegisterDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiFirstRegisterDatePersian]
		'
		/**/
	END
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		/**/
		SET @Cols = N'
			[BuyOrderItemId] AS [ApiBuyOrderItemId],
			[BuyOrderId] AS [ApiBuyOrderId],
			[bordIPrdId] AS [ApiBordIPrdId],
			[bordIQuantity] AS [ApiBordIQuantity],
			[bordICost] AS [ApiBordICost],
			[bordITotalCost] AS [ApiBordITotalCost],
			[bordIDescription] AS [ApiBordIDescription],
			[bordIQuantityDesc] AS [ApiBordIQuantityDesc],
			[bordIDiscount] AS [ApiBordIDiscount],
			[bordIDiscountI] AS [ApiBordIDiscountI],
			[bordIDiscountPercent] AS [ApiBordIDiscountPercent],
			[bordIDiscountIPercent] AS [ApiBordIDiscountIPercent],
			[bordIPrdUnitId] AS [ApiBordIPrdUnitId],
			(SELECT U.Unit FROM WSProductUnits_Lang U WHERE U.ProductUnitID = BOI.bordIPrdUnitId AND U.LanguageID = ' + CAST(@LanguageID AS VARCHAR(50)) + ') AS [ApiBordIPrdUnit],
			[bordICurrencyUnitId] AS [ApiBordICurrencyUnitId],
			(SELECT U.CurrencyUnit FROM WSCurrencyUnits_Lang U WHERE U.CurrencyUnitID = BOI.bordICurrencyUnitId AND U.LanguageID = ' + CAST(@LanguageID AS VARCHAR(50)) + ') AS [ApiBordICurrencyUnit],
			[bordIOrderView] AS [ApiBordIOrderView],
			[bordIFCR] AS [ApiBordIFCR],
			[bordITax] AS [ApiBordITax],
			[bordITaxIndex] AS [ApiBordITaxIndex],
			[bordICalculateTax] AS [ApiBordICalculateTax],
			[bordINotVisible] AS [ApiBordINotVisible],
			[bordIFCRI] AS [ApiBordIFCRI],
			[bordINotInSum] AS [ApiBordINotInSum],
			[bordIWHId] AS [ApiBordIWHId],
			(SELECT WrhsName FROM WsWareHouse_Lang W WHERE W.WareHouseID = BOI.bordIWHId AND W.LanguageID = ' + CAST(@LanguageID AS VARCHAR(50)) + ') AS [ApiBordIWH],
			[bordILinkAccItemId] AS [ApiBordILinkAccItemId],
			[bordIPrdCostGroupID] AS [ApiBordIPrdCostGroupID],
			[bordITracing] AS [ApiBordITracing],
			[bordICostSum] AS [ApiBordICostSum],
			[bordIDiscountSum] AS [ApiBordIDiscountSum],
			[bordIDiscountISum] AS [ApiBordIDiscountISum],
			[bordITaxSum] AS [ApiBordITaxSum],
			[bordITaxCleared] AS [ApiBordITaxCleared],
			[bordITaxClearedDate] AS [ApiBordITaxClearedDate],
			(FORMAT([bordITaxClearedDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordITaxClearedDatePersian],
			[bordIFacilityCost] AS [ApiBordIFacilityCost],
			[bordIFacilityCostPercent] AS [ApiBordIFacilityCostPercent],
			[bordIForwarderName] AS [ApiBordIForwarderName],
			[bordIFreightCost] AS [ApiBordIFreightCost],
			[bordIFreightCurrUnId] AS [ApiBordIFreightCurrUnId],
			(SELECT U.CurrencyUnit FROM WSCurrencyUnits_Lang U WHERE U.CurrencyUnitID = BOI.bordIFreightCurrUnId AND U.LanguageID = ' + CAST(@LanguageID AS VARCHAR(50)) + ') AS [ApiBordIFreightCurrUn],
			[bordIFreightCurrencyRate] AS [ApiBordIFreightCurrencyRate],
			[bordIFinalFreightCost] AS [ApiBordIFinalFreightCost],
			[bordICustomsPart] AS [ApiBordICustomsPart],
			[bordICustomsFee] AS [ApiBordICustomsFee],
			[bordICustomsCurrUnId] AS [ApiBordICustomsCurrUnId],
			'
		SET @Cols = @Cols + N'
			(SELECT U.CurrencyUnit FROM WSCurrencyUnits_Lang U WHERE U.CurrencyUnitID = BOI.[bordICustomsCurrUnId] AND U.LanguageID = ' + CAST(@LanguageID AS VARCHAR(50)) + ') AS [ApiBordICustomsCurrUn],
			[bordICustomsCurrencyRate] AS [ApiBordICustomsCurrencyRate],
			[bordIFinalCustomsFee] AS [ApiBordIFinalCustomsFee],
			[bordITotalFinalCost] AS [ApiBordITotalFinalCost],
			[bordIPreOrderItemId] AS [ApiBordIPreOrderItemId],
			[bordICommission] AS [ApiBordICommission],
			[bordICommissionCurrUnId] AS [ApiBordICommissionCurrUnId],
			(SELECT U.CurrencyUnit FROM WSCurrencyUnits_Lang U WHERE U.CurrencyUnitID = BOI.bordICommissionCurrUnId AND U.LanguageID = ' + CAST(@LanguageID AS VARCHAR(50)) + ') AS [ApiBordICommissionCurrUn],
			[bordICommissionCurrencyRate] AS [ApiBordICommissionCurrencyRate],
			[bordIFinalCommission] AS [ApiBordIFinalCommission],
			[bordICostSheetItemId] AS [ApiBordICostSheetItemId],
			[bordILinkAccWHIdStr] AS [ApiBordILinkAccWHIdStr],
			[bordIQuantityTotal] AS [ApiBordIQuantityTotal],
			[bordIPrdUnitIdI] AS [ApiBordIPrdUnitIdI],
			(SELECT U.Unit FROM WSProductUnits_Lang U WHERE U.ProductUnitID = BOI.bordIPrdUnitIdI AND U.LanguageID = ' + CAST(@LanguageID AS VARCHAR(50)) + ') AS [ApiBordIPrdUnitI],
			[bordIPrdUnitIRateResult] AS [ApiBordIPrdUnitIRateResult],
			[bordIPrdColorId] AS [ApiBordIPrdColorId],
			[bordIPrdNickname] AS [ApiBordIPrdNickname],
			[bordILinkAccFirstTransferDate] AS [ApiBordILinkAccFirstTransferDate],
			[bordILinkAccLastTransferDate] AS [ApiBordILinkAccLastTransferDate],
			[bordILinkAccItemIdStr] AS [ApiBordILinkAccItemIdStr],
			[bordICurrencyUnitIdI] AS [ApiBordICurrencyUnitIdI],
			(SELECT U.CurrencyUnitID FROM WSCurrencyUnits_Lang U WHERE U.CurrencyUnitID = BOI.bordICurrencyUnitIdI AND U.LanguageID = ' + CAST(@LanguageID AS VARCHAR(50)) + ') AS [ApiBordICurrencyUnitI],
			[bordICurrencyUnitIRate] AS [ApiBordICurrencyUnitIRate],
			[bordICostCurrencyI] AS [ApiBordICostCurrencyI],
			[bordITotalCostCurrencyI] AS [ApiBordITotalCostCurrencyI],
			[bordIDiscountCurrencyI] AS [ApiBordIDiscountCurrencyI],
			[bordIDiscountICurrencyI] AS [ApiBordIDiscountICurrencyI],
			[bordITaxCurrencyI] AS [ApiBordITaxCurrencyI],
			[bordICostSumCurrencyI] AS [ApiBordICostSumCurrencyI],
			[bordIDiscountSumCurrencyI] AS [ApiBordIDiscountSumCurrencyI],
			[bordIDiscountISumCurrencyI] AS [ApiBordIDiscountISumCurrencyI],
			[bordITaxSumCurrencyI] AS [ApiBordITaxSumCurrencyI],
			
			[GUId] AS [ApiGUId],
			[UserId] AS [ApiUserId],
			(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users_Lang U WHERE U.UserId = BOI.UserId AND U.LanguageID = ' + CAST(@LanguageID AS VARCHAR(50)) + ') AS [ApiEditUser],
			[FPId] AS [ApiFPId],
			[Month1] AS [ApiMonth1],
			[RegisterDate] AS [ApiRegisterDate],
			(FORMAT([RegisterDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiRegisterDatePersian],
			[AppType] AS [ApiAppType],
			[LanguageID] AS [ApiLanguageID],
			[FirstRegisterUserId] AS [ApiFirstRegisterUserId],
			(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users_Lang U WHERE U.UserId = BOI.FirstRegisterUserId AND U.LanguageID = ' + CAST(@LanguageID AS VARCHAR(50)) + ') AS [ApiFirstRegisterUser],
			[FirstRegisterDate] AS [ApiFirstRegisterDate],
			(FORMAT([FirstRegisterDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiFirstRegisterDatePersian]
		'
		/**/
	END
	
	IF (ISNULL(@BuyOrderItemId, 0) > 0)
	BEGIN
		SET @Term = @Term + ' AND BuyOrderItemId = ' + CAST(@BuyOrderItemId AS NVARCHAR(50))
	END
	IF (ISNULL(@BuyOrderId, 0) > 0)
	BEGIN
		SET @Term = @Term + ' AND BuyOrderId = ' + CAST(@BuyOrderId AS NVARCHAR(50))
	END
	
	EXECUTE (N'SELECT ' + @Cols + N' FROM WSBuyOrderItems BOI WHERE 1=1 ' + @Term + ' ORDER BY bordIOrderView' )

	/**/
END






