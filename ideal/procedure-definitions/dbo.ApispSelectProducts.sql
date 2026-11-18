





/*NKR990509*/
/*RZ990511- Modify this sp*/
/*RZ14011019- Add PrdLinkAccPrdCode*/
CREATE PROCEDURE [dbo].[ApispSelectProducts]
(
	/*
		exec [dbo].[ApispSelectProducts] 0, 15, NULL, NULL, NULL, NULL, NULL, 1033, 1065
	*/

	@ProductID INT,
	@PrdGroupID INT = NULL,
	@PrdCode NVARCHAR(50) = NULL,
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
	/*RZ990511- Add ApiPrd to all field name in this sp*/

	DECLARE @QRY NVARCHAR(MAX) = ''


	IF (@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
	/**/
		SET @QRY = '
				SELECT
					[ProductID] AS [ApiProductID],
					[PrdGroupID] AS [ApiPrdGroupID],
					(SELECT ISNULL(PS.SGName, '''') FROM WSProductSecondGroup PS WHERE PS.PrdSecondGroupID = P.PrdGroupID) AS ApiPrdGroup,
					[PrdCode] AS [ApiPrdCode],
					[PrdName] AS [ApiPrdName],
					[PrdLatinName] AS [ApiPrdLatinName],
					[PrdType] AS [ApiPrdType],
					[PrdDesign] AS [ApiPrdDesign],
					[PrdSize] AS [ApiPrdSize],
					[PrdColorId] AS [ApiPrdColorId],
					(SELECT ISNULL(PC.Color, '''') FROM WSProductColor PC WHERE PC.ProductColorID = P.PrdColorId) AS [ApiPrdColor],
					[PrdUnitId] AS [ApiPrdUnitId],
					(SELECT ISNULL(PU.Unit, '''') FROM WSProductUnits PU WHERE PU.ProductUnitID = P.PrdUnitId) AS [ApiPrdUnit],
					[PrdMinQty] AS [ApiPrdMinQty],
					[PrdMaxQty] AS [ApiPrdMaxQty],
					[PrdSleepDay] AS [ApiPrdSleepDay],
					[PrdFirstSerial] AS [ApiPrdFirstSerial],
					[PrdSecondSerial] AS [ApiPrdSecondSerial],
					[PrdThirdSerial] AS [ApiPrdThirdSerial],
					[PrdFirstBarcode] AS [ApiPrdFirstBarcode],
					[PrdSecondBarcode] AS [ApiPrdSecondBarcode],
					[PrdThirdBarcode] AS [ApiPrdThirdBarcode],
					[PrdDescription] AS [ApiPrdDescription],	
					[FPId] AS [ApiFPId],
					[PrdBarCode] AS [ApiPrdBarCode],
					[PrdBarCodeTypeId] AS [ApiPrdBarCodeTypeId],
					[PrdAutoNumBarcode] AS [ApiPrdAutoNumBarcode],
					[PrdAutoNumBarCodeTypeId] AS [ApiPrdAutoNumBarCodeTypeId],
					[PrdAutoCharBarcode] AS [ApiPrdAutoCharBarcode],
					[prdAutoCharBarCodeTypeId] AS [ApiprdAutoCharBarCodeTypeId],
					[PrdModel] AS [ApiPrdModel],
					[PrdInactiveInSale] AS [ApiPrdInactiveInSale],
					[PrdInactiveInBuy] AS [ApiPrdInactiveInBuy],	
					[PrdCommissionDisable] AS [ApiPrdCommissionDisable], '
		SET @QRY = @QRY + 
				'	[PrdCommissionPercentRate] AS [ApiPrdCommissionPercentRate],
					[PrdSHPIsActive] AS [ApiPrdSHPIsActive],
					[PrdSHPTitle] AS [ApiPrdSHPTitle],
					[PrdSHPCode] AS [ApiPrdSHPCode],
					[PrdSHPModel] AS [ApiPrdSHPModel],
					[PrdSHPDescription] AS [ApiPrdSHPDescription],
					[PrdSHPDescriptionII] AS [ApiPrdSHPDescriptionII],
					[PrdSHPStockManageTypeId] AS [ApiPrdSHPStockManageTypeId],
					[PrdSHPStockManualyCount] AS [ApiPrdSHPStockManualyCount],
					[PrdSHPHiddenPriceInNoStock] AS [ApiPrdSHPHiddenPriceInNoStock],
					[PrdSHPSelfSupplier] AS [ApiPrdSHPSelfSupplier],
					[PrdSHPOtherSupplierId] AS [ApiPrdSHPOtherSupplierId],
					(SELECT 
						ISNULL((SELECT CCT.CompanyTitle FROM CrmCompanyTitle CCT WHERE CCT.CompanyTitleID = CC.cmpTitleId),'''') + '' '' +/*RZ990511*/
						ISNULL(CC.cmpName, '''') 
					FROM CrmCompany CC 
					WHERE CC.CompanyID = P.PrdSHPOtherSupplierId) AS [ApiPrdSHPOtherSupplier],
					[OrderView] AS [ApiOrderView],
					[UserId] AS [ApiUserId],
					(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = P.UserId) AS ApiEditUser,
					[RegisterDate] AS [ApiRegisterDate],
					[FirstRegisterUserId] AS [ApiFirstRegisterUserId],
					(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = P.FirstRegisterUserId) AS ApiFirstRegisterUser,
					[FirstRegisterDate] AS [ApiFirstRegisterDate],
					(SELECT [FirstGroupId] FROM [dbo].[WSProductSecondGroup] SG WHERE SG.[PrdSecondGroupID] = P.[PrdGroupID]) [ApiPrdFGroupId],  
					(SELECT [FGName] FROM [dbo].[WSProductFirstGroup] FG WHERE FG.[PrdFirstGroupID] =
						(SELECT [FirstGroupId] FROM [dbo].[WSProductSecondGroup] SG WHERE SG.[PrdSecondGroupID] = P.[PrdGroupID])) [ApiPrdFGroupName]
					,[PrdLinkAccPrdCode] [ApiPrdLinkAccPrdCode] /*RZ14011019- Add PrdLinkAccPrdCode*/ ,
					/*NKR14020730- Start*/
					[PrdValidity] AS [ApiPrdValidity],
					[PrdValidityDay] AS [ApiPrdValidityDay],
					[PrdValidityTime] AS [ApiPrdValidityTime],
					[PrdValidityCounting] AS [ApiPrdValidityCounting],
					[PrdValidityCountingNum] AS [ApiPrdValidityCountingNum],
					[PrdValidityCountingMin] AS [ApiPrdValidityCountingMin],
					[PrdValidityCountingNumIsActive] AS [ApiPrdValidityCountingNumIsActive],
					[PrdValidityCountingNumNeedOrder] AS [ApiPrdValidityCountingNumNeedOrder],
					[PrdValidityCountingNumDefaultVal] AS [ApiPrdValidityCountingNumDefaultVal],
					[PrdValidityCountingNumNoCheckRemain] AS [PrdValidityCountingNumNoCheckRemain],
					[PrdValidityCountingMinIsActive] AS [ApiPrdValidityCountingMinIsActive],
					[PrdValidityCountingMinNeedOrder] AS [ApiPrdValidityCountingMinNeedOrder],
					[PrdValidityCountingMinDefaultVal] AS [ApiPrdValidityCountingMinDefaultVal],
					[PrdValidityCountingMinNoCheckRemain] AS [ApiPrdValidityCountingMinNoCheckRemain],
					[PrdValidityUpdatePrjRemindDateAfterIssueOrd] AS [ApiPrdValidityUpdatePrjRemindDateAfterIssueOrd],
					[PrdValidityControlFOPrjTitleGroup] AS [ApiPrdValidityControlFOPrjTitleGroup],
					[PrdValidityControlFOPrjTitleGroupIds] AS [ApiPrdValidityControlFOPrjTitleGroupIds],
					[PrdValidityControlFODeActivePrjTitleGroupDesc] AS [ApiPrdValidityControlFODeActivePrjTitleGroupDesc]
					/*NKR14020730- End*/
				FROM WSProducts P 
				WHERE 1 = 1 '		
	/**/
	END
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
	/**/
		SET @QRY = '
					SELECT
						[ProductID] AS [ApiProductID],
						[PrdGroupID] AS [ApiPrdGroupID],
						(SELECT ISNULL(PSL.SGName, '''') FROM WSProductSecondGroup_Lang PSL WHERE PSL.PrdSecondGroupID = P.PrdGroupID AND PSL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdGroup,
						[PrdCode] AS [ApiPrdCode],
						(SELECT ISNULL(PL.PrdName, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdName,
						(SELECT ISNULL(PL.PrdLatinName, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdLatinName,
						(SELECT ISNULL(PL.PrdType, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdType,
						(SELECT ISNULL(PL.PrdDesign, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdDesign,
						(SELECT ISNULL(PL.PrdSize, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdSize,
						[PrdColorId] AS [ApiPrdColorId],
						(SELECT ISNULL(PCL.Color, '''') FROM WSProductColor_Lang PCL WHERE PCL.ProductColorID = P.PrdColorId AND PCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdColor,
						[PrdUnitId] AS [ApiPrdUnitId],
						(SELECT ISNULL(PUL.Unit, '''') FROM WSProductUnits_Lang PUL WHERE PUL.ProductUnitID = P.PrdUnitId AND PUL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdUnit,
						[PrdMinQty] AS [ApiPrdMinQty],
						[PrdMaxQty] AS [ApiPrdMaxQty],
						[PrdSleepDay] AS [ApiPrdSleepDay],
						[PrdFirstSerial] AS [ApiPrdFirstSerial],
						[PrdSecondSerial] AS [ApiPrdSecondSerial],
						[PrdThirdSerial] AS [ApiPrdThirdSerial],
						[PrdFirstBarcode] AS [ApiPrdFirstBarcode],
						[PrdSecondBarcode] AS [ApiPrdSecondBarcode],
						[PrdThirdBarcode] AS [ApiPrdThirdBarcode],
						(SELECT ISNULL(PL.PrdDescription, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdDescription,
						[FPId] AS [ApiFPId],
						[PrdBarCode] AS [ApiPrdBarCode],
						[PrdBarCodeTypeId] AS [ApiPrdBarCodeTypeId],
						[PrdAutoNumBarcode] AS [ApiPrdAutoNumBarcode],
						[PrdAutoNumBarCodeTypeId] AS [ApiPrdAutoNumBarCodeTypeId],
						[PrdAutoCharBarcode] AS [ApiPrdAutoCharBarcode], '
		SET @QRY = @QRY +
					'	[prdAutoCharBarCodeTypeId] AS [ApiprdAutoCharBarCodeTypeId],
						(SELECT ISNULL(PL.PrdModel, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdModel,
						[PrdInactiveInSale] AS [ApiPrdInactiveInSale],
						[PrdInactiveInBuy] AS [ApiPrdInactiveInBuy],	
						[PrdCommissionDisable] AS [ApiPrdCommissionDisable],
						[PrdCommissionPercentRate] AS [ApiPrdCommissionPercentRate],
						[PrdSHPIsActive] AS [ApiPrdSHPIsActive],
						(SELECT ISNULL(PL.PrdSHPTitle, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdSHPTitle,
						[PrdSHPCode] AS [ApiPrdSHPCode],
						(SELECT ISNULL(PL.PrdSHPModel, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdSHPModel,
						(SELECT ISNULL(PL.PrdSHPDescription, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdSHPDescription,
						(SELECT ISNULL(PL.PrdSHPDescriptionII, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = P.ProductID AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrdSHPDescriptionII,
						[PrdSHPStockManageTypeId] AS [ApiPrdSHPStockManageTypeId],
						[PrdSHPStockManualyCount] AS [ApiPrdSHPStockManualyCount],
						[PrdSHPHiddenPriceInNoStock] AS [ApiPrdSHPHiddenPriceInNoStock],
						[PrdSHPSelfSupplier] AS [ApiPrdSHPSelfSupplier],
						[PrdSHPOtherSupplierId] AS [ApiPrdSHPOtherSupplierId],
						(SELECT 
							ISNULL((SELECT CCT.CompanyTitle FROM CrmCompanyTitle_Lang CCT WHERE CCT.CompanyTitleID = CC.cmpTitleId AND CCT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') + '' '' +
							ISNULL((SELECT CCL.cmpName FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''') 
						FROM CrmCompany CC 
						WHERE CC.CompanyID = P.PrdSHPOtherSupplierId) AS ApiPrdSHPOtherSupplier,/*RZ990511*/
						[OrderView] AS [ApiOrderView],
						[UserId] AS [ApiUserId],
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = P.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiEditUser,
						[RegisterDate] AS [ApiRegisterDate],
						[FirstRegisterUserId] AS [ApiFirstRegisterUserId],
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = P.FirstRegisterUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiFirstRegisterUser,
						[FirstRegisterDate] AS [ApiFirstRegisterDate],
						(SELECT [FirstGroupId] FROM [dbo].[WSProductSecondGroup] SG WHERE SG.[PrdSecondGroupID] = P.[PrdGroupID]) [ApiPrdFGroupId],  
						(SELECT [FGName] FROM [dbo].[WSProductFirstGroup_Lang] FG WHERE FG.[PrdFirstGroupID] =
						(SELECT [FirstGroupId] FROM [dbo].[WSProductSecondGroup] SG WHERE SG.[PrdSecondGroupID] = P.[PrdGroupID]) AND FG.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') [ApiPrdFGroupName]
						,[PrdLinkAccPrdCode] [ApiPrdLinkAccPrdCode] /*RZ14011019- Add PrdLinkAccPrdCode*/  ,
						/*NKR14020730- Start*/
						[PrdValidity] AS [ApiPrdValidity],
						[PrdValidityDay] AS [ApiPrdValidityDay],
						[PrdValidityTime] AS [ApiPrdValidityTime],
						[PrdValidityCounting] AS [ApiPrdValidityCounting],
						[PrdValidityCountingNum] AS [ApiPrdValidityCountingNum],
						[PrdValidityCountingMin] AS [ApiPrdValidityCountingMin],
						[PrdValidityCountingNumIsActive] AS [ApiPrdValidityCountingNumIsActive],
						[PrdValidityCountingNumNeedOrder] AS [ApiPrdValidityCountingNumNeedOrder],
						[PrdValidityCountingNumDefaultVal] AS [ApiPrdValidityCountingNumDefaultVal],
						[PrdValidityCountingNumNoCheckRemain] AS [PrdValidityCountingNumNoCheckRemain],
						[PrdValidityCountingMinIsActive] AS [ApiPrdValidityCountingMinIsActive],
						[PrdValidityCountingMinNeedOrder] AS [ApiPrdValidityCountingMinNeedOrder],
						[PrdValidityCountingMinDefaultVal] AS [ApiPrdValidityCountingMinDefaultVal],
						[PrdValidityCountingMinNoCheckRemain] AS [ApiPrdValidityCountingMinNoCheckRemain],
						[PrdValidityUpdatePrjRemindDateAfterIssueOrd] AS [ApiPrdValidityUpdatePrjRemindDateAfterIssueOrd],
						[PrdValidityControlFOPrjTitleGroup] AS [ApiPrdValidityControlFOPrjTitleGroup],
						[PrdValidityControlFOPrjTitleGroupIds] AS [ApiPrdValidityControlFOPrjTitleGroupIds],
						(SELECT PL.[PrdValidityControlFODeActivePrjTitleGroupDesc] FROM [dbo].[WSProducts_Lang] PL WHERE PL.[ProductID] = P.[ProductID] AND PL.[LanguageID] = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiPrdValidityControlFODeActivePrjTitleGroupDesc]
						/*NKR14020730- End*/
					FROM WSProducts P 
					WHERE 1 = 1 '
	/**/
	END

	/*------------------------------------------------*/
	/*RZ990511*/
	IF (ISNULL(@ProductID, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND ProductID = ' + CAST(@ProductID AS NVARCHAR(50))
	END
	IF (ISNULL(@PrdGroupID, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND PrdGroupID = ' + CAST(@PrdGroupID AS NVARCHAR(50))
	END
	IF (ISNULL(@PrdCode, '') <> '')
	BEGIN
		SET @QRY = @QRY + ' AND PrdCode = ''' + @PrdCode + ''''
	END
	IF ((@FromRegisterDate IS NOT NULL) AND (@ToRegisterDate IS NOT NULL))
	BEGIN
		SET @QRY = @QRY + ' AND RegisterDate BETWEEN ''' + CAST(@FromRegisterDate AS NVARCHAR(50)) + + ''' AND ''' + CAST(@ToRegisterDate AS NVARCHAR(50)) + ''''
	END
	IF ((@FromFirstRegisterDate IS NOT NULL) AND (@ToFirstRegisterDate IS NOT NULL))
	BEGIN
		SET @QRY = @QRY + ' AND FirstRegisterDate BETWEEN ''' + CAST(@FromFirstRegisterDate AS NVARCHAR(50)) + + ''' AND ''' + CAST(@ToFirstRegisterDate AS NVARCHAR(50)) + ''''
	END

	EXECUTE (@QRY + N' ORDER BY ISNULL([OrderView],[ProductID])')
	
	/*RZ990511- END*/
/**/
END





