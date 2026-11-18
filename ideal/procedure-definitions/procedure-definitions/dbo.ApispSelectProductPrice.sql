




/*NKR990511*/
/*RZ990514- Modify this sp*/
Create PROCEDURE [dbo].[ApispSelectProductPrice]
(
	/*

	EXEC ApispSelectProductPrice 0, 7927, 0, '2020-01-05 01:01:01', '2020-12-05 03:03:03', null, null, 1033, 1065
	
	*/
	@PrdPriceID INT,
	@PrdId INT = NULL,
	@ProductPriceGroupId INT = NULL,
	@FromRegisterDate DATETIME = NULL,
	@ToRegisterDate DATETIME = NULL,
	@FromFirstRegisterDate DATETIME = NULL,
	@ToFirstRegisterDate DATETIME = NULL,
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
						PrdPriceID AS ApiPrdPriceID,
						PrdId AS ApiPrdId,
						(SELECT ISNULL(P.PrdName, '''') FROM WSProducts P WHERE P.ProductID = PP.PrdId) AS ApiProductName,
						DocDate AS ApiDocDate,
						DocNumber AS ApiDocNumber,
						Price AS ApiPrice,
						CurrencyPrice AS ApiCurrencyPrice,
						CurrencyUnitId AS ApiCurrencyUnitId,
						(SELECT ISNULL(CU.CurrencyUnit, '''') FROM WSCurrencyUnits CU WHERE CU.CurrencyUnitID = PP.CurrencyUnitId) AS ApiCurrencyUnit,
						CooperationPrice AS ApiCooperationPrice,
						PricePercent AS ApiPricePercent,
						DiscountPrecent AS ApiDiscountPrecent,
						Discount AS ApiDiscount,
						OtherPrice AS ApiOtherPrice,
						Description AS ApiDescription,
						FPId AS ApiFPId,
						RegisterDate AS ApiRegisterDate,
						WHId AS ApiWHId,
						(SELECT ISNULL(WH.WrhsName, '''') FROM WsWareHouse WH WHERE WH.WareHouseID = PP.WHId) AS ApiWareHouse,
						ProductPriceGroupId AS ApiProductPriceGroupId,
						(SELECT ISNULL(PPG.ProductPriceGroupName, '''') FROM WSProductPriceGroup PPG WHERE PPG.ProductPriceGroupID = PP.ProductPriceGroupId) AS ApiProductPriceGroup,
						DocDateTime AS ApiDocDateTime,
						UserId AS ApiUserId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = PP.UserId) AS ApiEditUser,
						FirstRegisterUserId AS ApiFirstRegisterUserId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = PP.FirstRegisterUserId) AS ApiFirstRegisterUser,
						FirstRegisterDate AS ApiFirstRegisterDate 	
					FROM WSProductPrice PP WHERE 1 = 1 '
		/**/
	END
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		/**/

		SET @QRY = '
					SELECT 
						PrdPriceID AS ApiPrdPriceID,
						PrdId AS ApiPrdId,
						(SELECT ISNULL(PL.PrdName, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = PP.PrdId AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiProductName,
						DocDate AS ApiDocDate,
						DocNumber AS ApiDocNumber,
						Price AS ApiPrice,
						CurrencyPrice AS ApiCurrencyPrice,
						CurrencyUnitId AS ApiCurrencyUnitId,
						(SELECT ISNULL(CUL.CurrencyUnit, '''') FROM WSCurrencyUnits_Lang CUL WHERE CUL.CurrencyUnitID = PP.CurrencyUnitId AND CUL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiCurrencyUnit,
						CooperationPrice AS ApiCooperationPrice,
						PricePercent AS ApiPricePercent,
						DiscountPrecent AS ApiDiscountPrecent,
						Discount AS ApiDiscount,
						OtherPrice AS ApiOtherPrice,
						(SELECT ISNULL(PPL.Description, '''') FROM WSProductPrice_Lang PPL WHERE PPL.PrdPriceID = PP.PrdPriceID AND PPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiDescription,
						FPId AS ApiFPId,
						RegisterDate AS ApiRegisterDate,
						WHId AS ApiWHId,
						(SELECT ISNULL(WHL.WrhsName, '''') FROM WsWareHouse_Lang WHL WHERE WHL.WareHouseID = PP.WHId AND WHL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiWareHouse,
						ProductPriceGroupId AS ApiProductPriceGroupId,
						(SELECT ISNULL(PPGL.ProductPriceGroupName, '''') FROM WSProductPriceGroup_Lang PPGL WHERE PPGL.ProductPriceGroupID = PP.ProductPriceGroupId AND PPGL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiProductPriceGroup,
						DocDateTime AS ApiDocDateTime,
						UserId AS ApiUserId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = PP.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiEditUser,
						FirstRegisterUserId AS ApiFirstRegisterUserId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = PP.FirstRegisterUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiFirstRegisterUser,
						FirstRegisterDate AS ApiFirstRegisterDate
					FROM WSProductPrice PP WHERE 1 = 1 '

		/**/
	END


	IF (ISNULL(@PrdPriceID, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND PrdPriceID = ' + CAST(@PrdPriceID AS NVARCHAR(50))
	END
	ELSE IF (ISNULL(@PrdId, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND PrdId = ' + CAST(@PrdId AS NVARCHAR(50))
	END
	ELSE IF (ISNULL(@ProductPriceGroupId, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND ProductPriceGroupId = ' + CAST(@ProductPriceGroupId AS NVARCHAR(50))
	END
	ELSE IF (@FromRegisterDate IS NOT NULL AND @ToRegisterDate IS NOT NULL)
	BEGIN
		SET @QRY = @QRY + ' AND RegisterDate BETWEEN ''' + CAST(@FromRegisterDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToRegisterDate AS NVARCHAR(50)) + ''''
	END
	ELSE IF (@FromFirstRegisterDate IS NOT NULL AND @ToFirstRegisterDate IS NOT NULL)
	BEGIN
		SET @QRY = @QRY + ' AND FirstRegisterDate BETWEEN ''' + CAST(@FromFirstRegisterDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToFirstRegisterDate AS NVARCHAR(50)) + ''''
	END

	EXECUTE (@QRY + N' ORDER BY DocDate')/*RZ990514- Modify this sp*/

	/**/
END





