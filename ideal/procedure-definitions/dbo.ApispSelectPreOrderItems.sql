





/*NKR990513*/
/*RZ990515- Modify this sp*/
/*RZ990818- Add sum of tax,discount,price before tax*/
/*RZ14011019- Add PrdLinkAccPrdCode*/
/*NKR14020727- Add Delivery Fields*/
CREATE PROCEDURE [dbo].[ApispSelectPreOrderItems]
(
	/*
		EXEC ApispSelectPreOrderItems 0, 2396, 1065, 1065		
	*/
	@PreOrderItemID INT = NULL,
	@PreOrderId INT = NULL,
	@LanguageID INT = NULL,
	@DefaultLanguageID INT = NULL
)
AS
BEGIN
	/**/
	DECLARE @QRY NVARCHAR(MAX) = ''


	IF (@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
		/**/
		SET @QRY = '
				SELECT 
					PreOrderItemID AS ApiPreOrderItemID,
					PreOrderId AS ApiPreOrderId,
					(SELECT ISNULL(PO.pordTitle, '''') FROM WSPreOrder PO WHERE PO.PreOrderID = POI.PreOrderId) AS ApiPreOrder,
					pordIPrdId AS ApipordIPrdId,
					(SELECT ISNULL(P.PrdName, '''') FROM WSProducts P WHERE P.ProductID = POI.pordIPrdId) AS ApipordIPrd,
					pordIQuantity AS ApipordIQuantity,
					pordIPrice AS ApipordIPrice,
					pordITotalPrice AS ApipordITotalPrice,
					pordIDescription AS ApipordIDescription,	
					FPId AS ApiFPId,
					pordIQuantityDesc AS ApipordIQuantityDesc,
					pordIDiscount AS ApipordIDiscount,
					pordIDiscountI AS ApipordIDiscountI,
					pordIDiscountPercent AS ApipordIDiscountPercent,
					pordIDiscountIPercent AS ApipordIDiscountIPercent,
					pordIPrdUnitId AS ApipordIPrdUnitId,
					(SELECT ISNULL(PU.Unit, '''') FROM WSProductUnits PU WHERE PU.ProductUnitID = POI.pordIPrdUnitId) AS ApipordIPrdUnit,
					pordICurrencyUnitId AS ApipordICurrencyUnitId,
					(SELECT ISNULL(CU.CurrencyUnit, '''') FROM WSCurrencyUnits CU WHERE CU.CurrencyUnitID = POI.pordICurrencyUnitId) AS ApipordICurrencyUnit,
					pordIOrderView AS ApipordIOrderView, '
		SET @QRY = @QRY + '
					pordIFCR AS ApipordIFCR,
					pordITax AS ApipordITax,
					pordITaxIndex AS ApipordITaxIndex,
					pordICalculateTax AS ApipordICalculateTax,
					pordINotVisible AS ApipordINotVisible,
					pordIFCRI AS ApipordIFCRI,
					pordINotInSum AS ApipordINotInSum,
					pordIWHId AS ApipordIWHId,
					(SELECT ISNULL(WH.WrhsName, '''') FROM WsWareHouse WH WHERE WH.WareHouseID = POI.pordIWHId) AS ApipordIWH,
					pordIRound AS ApipordIRound,
					pordIRoundPlus AS ApipordIRoundPlus,
					pordIPrdPriceGroupID AS ApipordIPrdPriceGroupID,
					(SELECT ISNULL(PPG.ProductPriceGroupName, '''') FROM WSProductPriceGroup PPG WHERE PPG.ProductPriceGroupID = POI.pordIPrdPriceGroupID) AS ApipordIPrdPriceGroup,
					pordITracing AS ApipordITracing,
					UserId AS ApiUserId,
					(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = POI.UserId) AS ApiEditUser,					
					RegisterDate AS ApiRegisterDate,
					FirstRegisterUserId AS ApiFirstRegisterUserId,
					(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = POI.FirstRegisterUserId) AS ApiFirstRegisterUser,
					FirstRegisterDate AS ApiFirstRegisterDate
					/*RZ990818- Add sum of tax,discount,price before tax*/					
					,[pordIPriceSum] AS ApipordIPriceSum
					,[pordIDiscountSum] AS ApipordIDiscountSum
					,[pordIDiscountISum] AS ApipordIDiscountISum
					,[pordITaxSum] AS ApipordITaxSum
					/*RZ990818- End*/
					,(SELECT ISNULL(P.PrdLinkAccPrdCode, '''') FROM WSProducts P WHERE P.ProductID = POI.pordIPrdId) AS ApipordIPrdLinkAccPrdCode /*RZ14011019- Add PrdLinkAccPrdCode*/
					/*NKR14020730- Start*/
					,[pordIValidityExpireDate] AS ApipordIValidityExpireDate
					,[pordIDeliveryTermId] AS ApipordIDeliveryTermId
					,[pordIDeliveryDate] AS ApipordIDeliveryDate
					,[pordIDeliveryTime] AS ApipordIDeliveryTime
					,[pordIDeliveryDay] AS ApipordIDeliveryDay
					,[pordIDeliveryEndDate] ApipordIDeliveryEndDate
					,[pordIDeliveryEndTime] ApipordIDeliveryEndTime
					,[pordIDeliveryEndDay] ApipordIDeliveryEndDay
					/*NKR14020730- End*/
				FROM WSPreOrderItems POI WHERE 1 = 1 '
		/**/
	END
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		SET @QRY = '
					SELECT 
						PreOrderItemID AS ApiPreOrderItemID,
						PreOrderId AS ApiPreOrderId,
						(SELECT ISNULL(POL.pordTitle, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = POI.PreOrderId AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPreOrder,
						pordIPrdId AS ApipordIPrdId,
						(SELECT ISNULL(PL.PrdName, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = POI.pordIPrdId AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApipordIPrd,
						pordIQuantity AS ApipordIQuantity,
						pordIPrice AS ApipordIPrice,
						pordITotalPrice AS ApipordITotalPrice,
						pordIDescription AS ApipordIDescription,	
						FPId AS ApiFPId,
						pordIQuantityDesc AS ApipordIQuantityDesc,
						pordIDiscount AS ApipordIDiscount,
						pordIDiscountI AS ApipordIDiscountI,
						pordIDiscountPercent AS ApipordIDiscountPercent,
						pordIDiscountIPercent AS ApipordIDiscountIPercent,
						pordIPrdUnitId AS ApipordIPrdUnitId,
						(SELECT ISNULL(PUL.Unit, '''') FROM WSProductUnits_Lang PUL WHERE PUL.ProductUnitID = POI.pordIPrdUnitId AND PUL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApipordIPrdUnit,
						pordICurrencyUnitId AS ApipordICurrencyUnitId,
						(SELECT ISNULL(CUL.CurrencyUnit, '''') FROM WSCurrencyUnits_Lang CUL WHERE CUL.CurrencyUnitID = POI.pordICurrencyUnitId AND CUL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApipordICurrencyUnit,
						pordIOrderView AS ApipordIOrderView, '
		SET @QRY = @QRY + '
						pordIFCR AS ApipordIFCR,
						pordITax AS ApipordITax,
						pordITaxIndex AS ApipordITaxIndex,
						pordICalculateTax AS ApipordICalculateTax,
						pordINotVisible AS ApipordINotVisible,
						pordIFCRI AS ApipordIFCRI,
						pordINotInSum AS ApipordINotInSum,
						pordIWHId AS ApipordIWHId,
						(SELECT ISNULL(WHL.WrhsName, '''') FROM WsWareHouse_Lang WHL WHERE WHL.WareHouseID = POI.pordIWHId AND WHL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApipordIWH,
						pordIRound AS ApipordIRound,
						pordIRoundPlus AS ApipordIRoundPlus,
						pordIPrdPriceGroupID AS ApipordIPrdPriceGroupID,
						(SELECT ISNULL(PPGL.ProductPriceGroupName, '''') FROM WSProductPriceGroup_Lang PPGL WHERE PPGL.ProductPriceGroupID = POI.pordIPrdPriceGroupID AND PPGL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApipordIPrdPriceGroup,
						pordITracing AS ApipordITracing,
						UserId AS ApiUserId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = POI.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiEditUser,
						Month1 AS ApiMonth1,
						RegisterDate AS ApiRegisterDate,
						FirstRegisterUserId AS ApiFirstRegisterUserId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = POI.FirstRegisterUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiFirstRegisterUser,
						FirstRegisterDate AS ApiFirstRegisterDate
						/*RZ990818- Add sum of tax,discount,price before tax*/					
						,[pordIPriceSum] AS ApipordIPriceSum
						,[pordIDiscountSum] AS ApipordIDiscountSum
						,[pordIDiscountISum] AS ApipordIDiscountISum
						,[pordITaxSum] AS ApipordITaxSum
						/*RZ990818- End*/
						,(SELECT ISNULL(P.PrdLinkAccPrdCode, '''') FROM WSProducts P WHERE P.ProductID = POI.pordIPrdId) AS ApipordIPrdLinkAccPrdCode /*RZ14011019- Add PrdLinkAccPrdCode*/
						/*NKR14020730- Start*/
						,[pordIValidityExpireDate] AS ApipordIValidityExpireDate
						,[pordIDeliveryTermId] AS ApipordIDeliveryTermId
						,[pordIDeliveryDate] AS ApipordIDeliveryDate
						,[pordIDeliveryTime] AS ApipordIDeliveryTime
						,[pordIDeliveryDay] AS ApipordIDeliveryDay
						,[pordIDeliveryEndDate] ApipordIDeliveryEndDate
						,[pordIDeliveryEndTime] ApipordIDeliveryEndTime
						,[pordIDeliveryEndDay] ApipordIDeliveryEndDay
						/*NKR14020730- End*/
					FROM WSPreOrderItems POI WHERE 1 = 1 '
	END

	/**/
	IF (ISNULL(@PreOrderItemID, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND PreOrderItemID = ' + CAST(@PreOrderItemID AS NVARCHAR(50))
	END
	IF (ISNULL(@PreOrderId, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND PreOrderId = ' + CAST(@PreOrderId AS NVARCHAR(50))
	END

	EXECUTE (@QRY + N' ORDER BY pordIOrderView')/*RZ990515- Modify this sp*/

	/**/
END







