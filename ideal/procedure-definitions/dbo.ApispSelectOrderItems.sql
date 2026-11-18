







/*NKR990513*/
/*RZ990515- Modify this sp*/
/*RZ990818- Add sum of tax,discount,price before tax*/
/*RZ14011019- Add PrdLinkAccPrdCode*/  
/*NKR14020726- Add Delivery Fields*/
/*NKR14020817- Add ApiOrdILinkAccWHIdStr*/
CREATE PROCEDURE [dbo].[ApispSelectOrderItems]
(
	/*
		EXEC ApispSelectOrderItems 0, 17190, 1065, 1065		
	*/
	@OrderItemID INT = NULL,
	@OrderId INT = NULL,
	@LanguageID INT = NULL,
	@DefaultLanguageID INT  = NULL
)
AS
BEGIN
	/**/

	DECLARE @QRY NVARCHAR(MAX) = ''

	IF (@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
		SET @QRY = '
					SELECT 
						OrderItemID AS ApiOrderItemID,
						OrderId AS ApiOrderId,
						(SELECT ISNULL(O.ordTitle, '''') FROM WSOrder O WHERE O.OrderID = OI.OrderId) AS ApiOrder,
						ordIPrdId AS ApiOrdIPrdId,
						(SELECT ISNULL(P.PrdName, '''') FROM WSProducts P WHERE P.ProductID = OI.ordIPrdId) AS ApiOrdIPrd,
						ordIQuantity AS ApiOrdIQuantity,
						ordIPrice AS ApiOrdIPrice,
						ordITotalPrice AS ApiOrdITotalPrice,
						ordIDescription AS ApiOrdIDescription,
						FPId AS ApiFPId,
						ordIQuantityDesc AS ApiOrdIQuantityDesc,
						ordIDiscountI AS ApiOrdIDiscountI,
						ordIDiscount AS ApiOrdIDiscount,
						ordIDiscountPercent AS ApiOrdIDiscountPercent,
						ordIDiscountIPercent AS ApiOrdIDiscountIPercent,
						ordIPrdUnitId AS ApiOrdIPrdUnitId,
						(SELECT ISNULL(PU.Unit, '''') FROM WSProductUnits PU WHERE PU.ProductUnitID = OI.ordIPrdUnitId) AS ApiOrdIPrdUnit,
						ordICurrencyUnitId AS ApiOrdICurrencyUnitId,
						(SELECT ISNULL(CU.CurrencyUnit, '''') FROM WSCurrencyUnits CU WHERE CU.CurrencyUnitID = OI.ordICurrencyUnitId) AS ApiOrdICurrencyUnit,
						ordIOrderView AS ApiOrdIOrderView,
						ordIFCR AS ApiOrdIFCR,
						ordITax AS ApiOrdITax,
						ordITaxIndex AS ApiOrdITaxIndex,
						ordICalculateTax AS ApiOrdICalculateTax,
						ordINotVisible AS ApiOrdINotVisible, 
						ordILinkAccWHIdStr AS ApiOrdILinkAccWHIdStr/*NKR14020817*/,'
		SET @QRY = @QRY + '
						ordIFCRI AS ApiOrdIFCRI,
						ordINotInSum AS ApiOrdINotInSum,
						ordIWHId AS ApiOrdIWHId,
						(SELECT ISNULL(WH.WrhsName, '''') FROM WsWareHouse WH WHERE WH.WareHouseID = OI.ordIWHId) AS ApiOrdIWH,
						ordIRound AS ApiOrdIRound,
						ordIRoundPlus AS ApiOrdIRoundPlus,
						ordIPricePartRate AS ApiOrdIPricePartRate,
						ordIPricePartI AS ApiOrdIPricePartI,
						ordIPricePartII AS ApiOrdIPricePartII,
						ordIPrdPriceGroupID AS ApiOrdIPrdPriceGroupID,
						(SELECT ISNULL(PPG.ProductPriceGroupName, '''') FROM WSProductPriceGroup PPG WHERE PPG.ProductPriceGroupID = OI.ordIPrdPriceGroupID) AS ApiOrdIPrdPriceGroup,
						ordITracing AS ApiOrdITracing,						
						UserId AS ApiUserId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = OI.UserId) AS ApiEditUser,	
						RegisterDate AS ApiRegisterDate,
						FirstRegisterUserId AS ApiFirstRegisterUserId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = OI.FirstRegisterUserId) AS ApiFirstRegisterUser,
						FirstRegisterDate AS ApiFirstRegisterDate,
						[ordILinkAccItemId] AS ApiOrdILinkAccItemId
						/*RZ990818- Add sum of tax,discount,price before tax*/
						,[ordIPriceSum] AS ApiOrdIPriceSum
						,[ordIDiscountISum] AS ApiOrdIDiscountISum
						,[ordIDiscountSum] AS ApiOrdIDiscountSum
						,[ordITaxSum] AS ApiOrdITaxSum
						/*RZ990818- End*/
						,(SELECT ISNULL(P.PrdLinkAccPrdCode, '''') FROM WSProducts P WHERE P.ProductID = OI.ordIPrdId) AS ApiOrdIPrdLinkAccPrdCode /*RZ14011019- Add PrdLinkAccPrdCode*/  
						,ordIValidityExpireDate AS ApiOrdIValidityExpireDate
						/*NKR14020730- Start*/
						,ordIPrdValidityCountingMin AS ApiOrdIPrdValidityCountingMin
						,ordIPrdValidityCountingNum AS ApiOrdIPrdValidityCountingNum
						,ordIDeliveryTermId AS ApiOrdIDeliveryTermId
						,ordIDeliveryDate AS ApiOrdIDeliveryDate
						,ordIDeliveryTime AS ApiOrdIDeliveryTime
						,ordIDeliveryDay AS ApiOrdIDeliveryDay
						,ordIDeliveryEndDate AS ApiOrdIDeliveryEndDate
						,ordIDeliveryEndTime AS ApiOrdIDeliveryEndTime
						,ordIDeliveryEndDay AS ApiOrdIDeliveryEndDay
						,ordIDeliveryUserId AS ApiOrdIDeliveryUserId
						/*NKR14020730- End*/
					FROM WSOrderItems OI WHERE 1 = 1 '
	END
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		SET @QRY = '
					SELECT 
						OrderItemID AS ApiOrderItemID,
						OrderId AS ApiOrderId,
						(SELECT ISNULL(OL.ordTitle, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = OI.OrderId AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrder,
						ordIPrdId AS ApiOrdIPrdId,
						(SELECT ISNULL(PL.PrdName, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = OI.ordIPrdId AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdIPrd,
						ordIQuantity AS ApiOrdIQuantity,
						ordIPrice AS ApiOrdIPrice,
						ordITotalPrice AS ApiOrdITotalPrice,
						(SELECT ISNULL(OIL.ordIDescription, '''') FROM WSOrderItems_Lang OIL WHERE OIL.OrderItemID = OI.OrderItemID AND OIL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdIDescription,
						FPId AS ApiFPId,
						(SELECT ISNULL(OIL.ordIQuantityDesc, '''') FROM WSOrderItems_Lang OIL WHERE OIL.OrderItemID = OI.OrderItemID AND OIL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdIQuantityDesc,
						ordIDiscountI AS ApiOrdIDiscountI,
						ordIDiscount AS ApiOrdIDiscount,
						ordIDiscountPercent AS ApiOrdIDiscountPercent,
						ordIDiscountIPercent AS ApiOrdIDiscountIPercent,
						ordIPrdUnitId AS ApiOrdIPrdUnitId,
						(SELECT ISNULL(PUL.Unit, '''') FROM WSProductUnits_Lang PUL WHERE PUL.ProductUnitID = OI.ordIPrdUnitId AND PUL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdIPrdUnit,
						ordICurrencyUnitId AS ApiOrdICurrencyUnitId,
						(SELECT ISNULL(CUL.CurrencyUnit, '''') FROM WSCurrencyUnits_Lang CUL WHERE CUL.CurrencyUnitID = OI.ordICurrencyUnitId AND CUL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdICurrencyUnit,
						ordIOrderView AS ApiOrdIOrderView,
						ordIFCR AS ApiOrdIFCR, '
		SET @QRY = @QRY + '
						ordITax AS ApiOrdITax,
						ordITaxIndex AS ApiOrdITaxIndex,
						ordICalculateTax AS ApiOrdICalculateTax,
						ordINotVisible AS ApiOrdINotVisible,
						ordILinkAccWHIdStr AS ApiOrdILinkAccWHIdStr/*NKR14020817*/,
						ordIFCRI AS ApiOrdIFCRI,
						ordINotInSum AS ApiOrdINotInSum,
						ordIWHId AS ApiOrdIWHId,
						(SELECT ISNULL(WHL.WrhsName, '''') FROM WsWareHouse_Lang WHL WHERE WHL.WareHouseID = OI.ordIWHId AND WHL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdIWH,
						ordIRound AS ApiOrdIRound,
						ordIRoundPlus AS ApiOrdIRoundPlus,
						ordIPricePartRate AS ApiOrdIPricePartRate,
						ordIPricePartI AS ApiOrdIPricePartI,
						ordIPricePartII AS ApiOrdIPricePartII,
						ordIPrdPriceGroupID AS ApiOrdIPrdPriceGroupID,
						(SELECT ISNULL(PPGL.ProductPriceGroupName, '''') FROM WSProductPriceGroup_Lang PPGL WHERE PPGL.ProductPriceGroupID = OI.ordIPrdPriceGroupID AND PPGL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdIPrdPriceGroup,
						ordITracing AS ApiOrdITracing,						
						UserId AS ApiUserId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = OI.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiEditUser,	
						RegisterDate AS ApiRegisterDate,
						FirstRegisterUserId AS ApiFirstRegisterUserId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = OI.FirstRegisterUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiFirstRegisterUser,
						FirstRegisterDate AS ApiFirstRegisterDate,
						[ordILinkAccItemId] AS ApiOrdILinkAccItemId
						/*RZ990818- Add sum of tax,discount,price before tax*/
						,[ordIPriceSum] AS ApiOrdIPriceSum
						,[ordIDiscountISum] AS ApiOrdIDiscountISum
						,[ordIDiscountSum] AS ApiOrdIDiscountSum
						,[ordITaxSum] AS ApiOrdITaxSum
						/*RZ990818- End*/
						,(SELECT ISNULL(P.PrdLinkAccPrdCode, '''') FROM WSProducts P WHERE P.ProductID = OI.ordIPrdId) AS ApiOrdIPrdLinkAccPrdCode /*RZ14011019- Add PrdLinkAccPrdCode*/ 
						,ordIValidityExpireDate AS ApiOrdIValidityExpireDate
						/*NKR14020730- Start*/
						,ordIPrdValidityCountingMin AS ApiOrdIPrdValidityCountingMin
						,ordIPrdValidityCountingNum AS ApiOrdIPrdValidityCountingNum
						,ordIDeliveryTermId AS ApiOrdIDeliveryTermId
						,ordIDeliveryDate AS ApiOrdIDeliveryDate
						,ordIDeliveryTime AS ApiOrdIDeliveryTime
						,ordIDeliveryDay AS ApiOrdIDeliveryDay
						,ordIDeliveryEndDate AS ApiOrdIDeliveryEndDate
						,ordIDeliveryEndTime AS ApiOrdIDeliveryEndTime
						,ordIDeliveryEndDay AS ApiOrdIDeliveryEndDay
						,ordIDeliveryUserId AS ApiOrdIDeliveryUserId
						/*NKR14020730- End*/
					FROM WSOrderItems OI WHERE 1 = 1
		'
	END

	/*-----------------------------*/
	IF (ISNULL(@OrderItemID, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND OrderItemID = ' + CAST(@OrderItemID AS NVARCHAR(50))
	END
	IF (ISNULL(@OrderId, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND OrderId = ' + CAST(@OrderId AS NVARCHAR(50))
	END

	EXECUTE (@QRY + N' ORDER BY ordIOrderView')/*RZ990515*/

	/**/
END






