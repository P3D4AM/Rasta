






/*NKR14030231*/
CREATE PROCEDURE [dbo].[ApispSelectBuyOrder]
(
	/*
		EXEC [ApispSelectBuyOrder] @BuyOrderID=NULL,@BuyOrdNumber=NULL,@FromDate=NULL,@ToDate=NULL,@FromRegisterDate=NULL,
			@ToRegisterDate=NULL,@FromFirstRegisterDate=NULL,@ToFirstRegisterDate=NULL,@LanguageID=1033,@DefaultLanguageID=1065
	*/
	@BuyOrderID INT = NULL,
	@BuyOrdNumber BIGINT = NULL,
	@FromDate DATETIME = NULL,
	@ToDate DATETIME = NULL,
	@FromRegisterDate DATETIME = NULL,
	@ToRegisterDate DATETIME = NULL,
	@FromFirstRegisterDate DATETIME = NULL,
	@ToFirstRegisterDate DATETIME  = NULL,
	@LanguageID INT = NULL,
	@DefaultLanguageID INT = NULL
)
AS
BEGIN
	/**/
	DECLARE @Cols NVARCHAR(MAX) = '',
			@Term NVARCHAR(MAX) = '',
			@LanguageCollation NVARCHAR(50) = (SELECT L.LanguageCollation FROM Languages L WHERE L.LanguageID = @LanguageID)
			
	IF (@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
		/**/
		SET @Cols = N'
			[BuyOrderID] AS [ApiBuyOrderID],
			[BuyOrderOprId] AS [ApiBuyOrderOprId],
			(SELECT BOP.[Name] FROM WSBuyOrderOpr BOP WHERE BOP.BuyOrderOprID = BO.BuyOrderOprId) AS [ApiBuyOrderOpr],
			[bordTitle] AS [ApiBordTitle],
			[bordNumber] AS [ApiBordNumber],
			[bordOrderNumber] AS [ApiBordOrderNumber],
			[bordDateTime] AS [ApiBordDateTime],
			(FORMAT([bordDateTime], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordDate],
			[bordOrderDateTime] AS [ApiBordOrderDateTime],
			(FORMAT([bordOrderDateTime], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordOrderDate],
			[bordCompanyId] AS [ApiBordCompanyId],
			(CASE WHEN ISNULL((SELECT C.[cmpKind] FROM CrmCompany C WHERE C.CompanyID = BO.bordCompanyId),0) = 0
				THEN ((ISNULL((SELECT CompanyTitle FROM [dbo].[CrmCompanyTitle] CT WHERE CT.[CompanyTitleID] = (SELECT C.[cmpTitleId] FROM CrmCompany C WHERE C.CompanyID = BO.bordCompanyId)),'''') + '' '' + 
						ISNULL((SELECT C.[cmpName] FROM CrmCompany C WHERE C.CompanyID = BO.bordCompanyId),'''')))
				ELSE	(SELECT ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.PersonTitleID = CCP.prsTitleId),'''')  + '' '' +
							ISNULL(prsFName, '''') + '' '' + ISNULL(prsLName,'''')
					FROM [dbo].[CRMvwSelectCompanyPersons] CCP
					WHERE CCP.CompanyPersonID = (SELECT C.[cmpMainPersonId] FROM CrmCompany C WHERE C.CompanyID = BO.bordCompanyId)
				)				
			END) ApiCmpNameWithTitle,
			[bordCompanyPersonId] AS [ApiBordCompanyPersonId],
			(SELECT ISNULL(P.prsFName, '''') + '' '' + ISNULL(P.prsLName, '''') FROM CrmCompanyPersons P WHERE P.CompanyPersonID = BO.bordCompanyPersonId) AS [ApiBordCompanyPerson],
			[bordProjectId] AS [ApiBordProjectId],
			(SELECT P.prjTitle FROM CrmProjects P WHERE P.ProjectID = BO.bordProjectId) AS [ApiBordProject],
			[bordSubject] AS [ApiBordSubject],
			[bordItemCount] AS [ApiBordItemCount],
			[bordItemsAmount] AS [ApiBordItemsAmount],
			[bordDiscount] AS [ApiBordDiscount],
			[bordSumAmount] AS [ApiBordSumAmount],
			[bordTax] AS [ApiBordTax],
			[bordTaxIndex] AS [ApiBordTaxIndex],
			[bordCalculateTax] AS [ApiBordCalculateTax],
			[bordTotalAmount] AS [ApiBordTotalAmount],
			[bordTotalAmountStr] AS [ApiBordTotalAmountStr],
			[bordIsVerified] AS [ApiBordIsVerified],
			[bordStatusId] AS [ApiBordStatusId],
			(SELECT S.BuyOrderStatus FROM WSBuyOrderStatus S WHERE S.BuyOrderStatusId = BO.bordStatusId) AS [ApiBordStatus],
			[bordIsFixed] AS [ApiBordIsFixed],
			[bordPrintFormatId] AS [ApiBordPrintFormatId],
			(SELECT P.Title FROM PrintFormat P WHERE P.PrintFormatID = BO.bordPrintFormatId) AS [ApiBordPrintFormat],
			[bordImportDateTime] AS [ApiBordImportDateTime],
			(FORMAT([bordImportDateTime], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordImportDate],
			[bordVerifierId] AS [ApiBordVerifierId],
			(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = BO.[bordVerifierId]) AS [ApiBordVerifier],
			[bordVerifiedRegisterDate] AS [ApiBordVerifiedRegisterDate],
			(FORMAT([bordVerifiedRegisterDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordVerifiedRegisterDatePersian],
			[bordFirstRegisterUserId] AS [ApiBordFirstRegisterUserId],
			(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = BO.[bordFirstRegisterUserId]) AS [ApiBordFirstRegisterUser],
			[bordSettlementTypeId] AS [ApiBordSettlementTypeId],
			(SELECT S.[Name] FROM WSSettlementType S WHERE S.Id = BO.bordSettlementTypeId) AS [ApiBordSettlementType],
			[bordDay] AS [ApiBordDay],
			[bordTime] AS [ApiBordTime],
		'
		SET @Cols = @Cols + N'
			[bordTransportation] AS [ApiBordTransportation],
			[bordReferUserId] AS [ApiBordReferUserId],
			(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = BO.[bordReferUserId]) AS [ApiBordReferUser],
			[bordRound] AS [ApiBordRound],
			[bordDiscountPercent] AS [ApiBordDiscountPercent],
			[bordDiscountTitle] AS [ApiBordDiscountTitle],
			[bordNote] AS [ApiBordNote],
			[bordcmpTitle] AS [ApiBordcmpTitle],
			[bordLinkAccCodeId] AS [ApiBordLinkAccCodeId],
			[bordLinkAccCode] AS [ApiBordLinkAccCode],
			[bordLinkAccBuyOrderId] AS [ApiBordLinkAccBuyOrderId],
			[bordLinkAccBuyOrderNumber] AS [ApiBordLinkAccBuyOrderNumber],
			[bordLinkAccVoucherId] AS [ApiBordLinkAccVoucherId],
			[bordLinkAccVoucherNumber] AS [ApiBordLinkAccVoucherNumber],
			[bordCurrencyUnitId] AS [ApiBordCurrencyUnitId],
			(SELECT C.CurrencyUnit FROM WSCurrencyUnits C WHERE C.CurrencyUnitID = BO.[bordCurrencyUnitId]) AS [ApiBordCurrencyUnit],
			[bordFacilityCmpId] AS [ApiBordFacilityCmpId],
			(CASE WHEN ISNULL((SELECT C.[cmpKind] FROM CrmCompany C WHERE C.CompanyID = BO.[bordFacilityCmpId]),0) = 0
				THEN ((ISNULL((SELECT CompanyTitle FROM [dbo].[CrmCompanyTitle] CT WHERE CT.[CompanyTitleID] = (SELECT C.[cmpTitleId] FROM CrmCompany C WHERE C.CompanyID = BO.[bordFacilityCmpId])),'''') + '' '' + 
						ISNULL((SELECT C.[cmpName] FROM CrmCompany C WHERE C.CompanyID = BO.[bordFacilityCmpId]),'''')))
				ELSE	(SELECT ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.PersonTitleID = CCP.prsTitleId),'''')  + '' '' +
							ISNULL(prsFName, '''') + '' '' + ISNULL(prsLName,'''')
					FROM [dbo].[CRMvwSelectCompanyPersons] CCP
					WHERE CCP.CompanyPersonID = (SELECT C.[cmpMainPersonId] FROM CrmCompany C WHERE C.CompanyID = BO.[bordFacilityCmpId])
				)				
			END)  AS [ApiBordFacilityCmp],
			[bordFacilityPrsId] AS [ApiBordFacilityPrsId],
			(SELECT ISNULL(P.prsFName, '''') + '' '' + ISNULL(P.prsLName, '''') FROM CrmCompanyPersons P WHERE P.CompanyPersonID = BO.[bordFacilityPrsId]) AS [ApiBordFacilityPrs],
			[bordFacilityPrjId] AS [ApiBordFacilityPrjId],
			(SELECT P.prjTitle FROM CrmProjects P WHERE P.ProjectID = BO.bordProjectId) AS [ApiBordFacilityPrj],
			[bordReqCmpId] AS [ApiBordReqCmpId],
			(CASE WHEN ISNULL((SELECT C.[cmpKind] FROM CrmCompany C WHERE C.CompanyID = BO.[bordReqCmpId]),0) = 0
				THEN ((ISNULL((SELECT CompanyTitle FROM [dbo].[CrmCompanyTitle] CT WHERE CT.[CompanyTitleID] = (SELECT C.[cmpTitleId] FROM CrmCompany C WHERE C.CompanyID = BO.[bordReqCmpId])),'''') + '' '' + 
						ISNULL((SELECT C.[cmpName] FROM CrmCompany C WHERE C.CompanyID = BO.[bordReqCmpId]),'''')))
				ELSE	(SELECT ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.PersonTitleID = CCP.prsTitleId),'''')  + '' '' +
							ISNULL(prsFName, '''') + '' '' + ISNULL(prsLName,'''')
					FROM [dbo].[CRMvwSelectCompanyPersons] CCP
					WHERE CCP.CompanyPersonID = (SELECT C.[cmpMainPersonId] FROM CrmCompany C WHERE C.CompanyID = BO.[bordReqCmpId])
				)				
			END)  AS [ApiBordReqCmp],
			[bordReqPrsId] AS [ApiBordReqPrsId],
			(SELECT ISNULL(P.prsFName, '''') + '' '' + ISNULL(P.prsLName, '''') FROM CrmCompanyPersons P WHERE P.CompanyPersonID = BO.[bordReqPrsId]) AS [ApiBordReqPrs],
			[bordReqPrjId] AS [ApiBordReqPrjId],
			(SELECT P.prjTitle FROM CrmProjects P WHERE P.ProjectID = BO.[bordReqPrjId]) AS [ApiBordReqPrj],
			[bordDeliveryTerm] AS [ApiBordDeliveryTerm],
			[bordDeliveryDate] AS [ApiBordDeliveryDate],
			(FORMAT([bordDeliveryDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordDeliveryDatePersian],
			[bordTaxCleared] AS [ApiBordTaxCleared],
			[bordTaxClearedDate] AS [ApiBordTaxClearedDate],
			(FORMAT([bordTaxClearedDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordTaxClearedDatePersian],
		'
		SET @Cols = @Cols + N'
			[bordFacilityCost] AS [ApiBordFacilityCost],
			[bordFacilityCostPercent] AS [ApiBordFacilityCostPercent],
			[bordSupplierDeliveryDate] AS [ApiBordSupplierDeliveryDate],
			(FORMAT([bordSupplierDeliveryDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordSupplierDeliveryDatePersian],
			[bordForwarderName] AS [ApiBordForwarderName],
			[bordFreightCost] AS [ApiBordFreightCost],
			[bordFreightCurrUnId] AS [ApiBordFreightCurrUnId],
			(SELECT C.CurrencyUnit FROM WSCurrencyUnits C WHERE C.CurrencyUnitID = BO.[bordFreightCurrUnId]) AS [ApiBordFreightCurrUn],
			[bordFreightCurrencyRate] AS [ApiBordFreightCurrencyRate],
			[bordFinalFreightCost] AS [ApiBordFinalFreightCost],
			[bordCustomsPart] AS [ApiBordCustomsPart],
			[bordCustomsFee] AS [ApiBordCustomsFee],
			[bordCustomsCurrUnId] AS [ApiBordCustomsCurrUnId],
			(SELECT C.CurrencyUnit FROM WSCurrencyUnits C WHERE C.CurrencyUnitID = BO.[bordCustomsCurrUnId]) AS [ApiBordCustomsCurrUn],
			[bordCustomsCurrencyRate] AS [ApiBordCustomsCurrencyRate],
			[bordFinalCustomsFee] AS [ApiBordFinalCustomsFee],
			[bordFinalDeliveryDate] AS [ApiBordFinalDeliveryDate],
			(FORMAT([bordFinalDeliveryDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordFinalDeliveryDatePersian],
			[bordTotalFinalCost] AS [ApiBordTotalFinalCost],
			[bordCommission] AS [ApiBordCommission],
			[bordCommissionCurrUnId] AS [ApiBordCommissionCurrUnId],
			(SELECT C.CurrencyUnit FROM WSCurrencyUnits C WHERE C.CurrencyUnitID = BO.[bordCommissionCurrUnId]) AS [ApiBordCommissionCurrUn],
			[bordCommissionCurrencyRate] AS [ApiBordCommissionCurrencyRate],
			[bordFinalCommission] AS [ApiBordFinalCommission],
			[bordCostSheetId] AS [ApiBordCostSheetId],
			(SELECT CS.ctshTitle FROM WSCostSheets CS WHERE CS.CostSheetId = BO.[bordCostSheetId]) AS [ApiBordCostSheet],
			[bordNumRef] AS [ApiBordNumRef],
			[bordItemsQty] AS [ApiBordItemsQty],
			[bordItemsDiscount] AS [ApiBordItemsDiscount],
			[bordItemsTax] AS [ApiBordItemsTax],
			[bordDefaultSettingId] AS [ApiBordDefaultSettingId],
			(SELECT DS.SettingTitle FROM WSBuyOrderDefaultSetting DS WHERE DS.BuyOrderDefaultSettingId = BO.[bordDefaultSettingId]) AS [ApiBordDefaultSetting],
			[bordVerificationWorkFlowId] AS [ApiBordVerificationWorkFlowId],
			(SELECT V.VerificationWorkFlowTitle FROM WSVerificationWorkFlows V WHERE V.VerificationWorkFlowId = BO.[bordVerificationWorkFlowId]) AS [ApiBordVerificationWorkFlow],
			[bordLinkAccFirstTransferDate] AS [ApiBordLinkAccFirstTransferDate],
			(FORMAT([bordLinkAccFirstTransferDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordLinkAccFirstTransferDatePersian],
			[bordLinkAccLastTransferDate] AS [ApiBordLinkAccLastTransferDate],
			[bordLinkAccBuyOrderIdStr] AS [ApiBordLinkAccBuyOrderIdStr],
			[bordCurrencyUnitIdI] AS [ApiBordCurrencyUnitIdI],
			(SELECT C.CurrencyUnitID FROM WSCurrencyUnits C WHERE C.CurrencyUnitID = BO.[bordCurrencyUnitIdI]) AS [ApiBordCurrencyUnitI],
			[bordCurrencyUnitIRate] AS [ApiBordCurrencyUnitIRate],
			[bordItemsAmountCurrencyI] AS [ApiBordItemsAmountCurrencyI],
			[bordDiscountCurrencyI] AS [ApiBordDiscountCurrencyI],
			[bordSumAmountCurrencyI] AS [ApiBordSumAmountCurrencyI],
			[bordTaxCurrencyI] AS [ApiBordTaxCurrencyI],
			[bordTotalAmountCurrencyI] AS [ApiBordTotalAmountCurrencyI],
			[bordTotalAmountCurrencyIStr] AS [ApiBordTotalAmountCurrencyIStr],
			[bordTransportationCurrencyI] AS [ApiBordTransportationCurrencyI],
			[bordRoundCurrencyI] AS [ApiBordRoundCurrencyI],
			[bordItemsDiscountCurrencyI] AS [ApiBordItemsDiscountCurrencyI],
			[bordItemsTaxCurrencyI] AS [ApiBordItemsTaxCurrencyI],
		'
		SET @Cols = @Cols + N'
			[UserId] AS [ApiUserId],
			(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = BO.[UserId]) AS [ApiEditUser],
			[FPId] AS [ApiFPId],
			[Month1] AS [ApiMonth1],
			[RegisterDate] AS [ApiRegisterDate],
			(FORMAT([RegisterDate], ''yyyy/MM/dd HH:mm'')) AS [ApiRegisterDatePersian],
			[GUId] AS [ApiGUId],
			[AppType] AS [ApiAppType],
			[LanguageID] AS [ApiLanguageID],
			[FirstRegisterUserId] AS [ApiFirstRegisterUserId],
			(SELECT ISNULL(FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = BO.[FirstRegisterUserId]) AS [ApiFirstRegisterUser],
			[FirstRegisterDate] AS [ApiFirstRegisterDate],
			(FORMAT([FirstRegisterDate], ''yyyy/MM/dd HH:mm'')) AS [ApiFirstRegisterDatePersian]
		'
		/**/
	END
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		/**/
		SET @Cols = N'
				 [BuyOrderID] AS [ApiBuyOrderID]
				,[BuyOrderOprId] AS [ApiBuyOrderOprId]
				,(SELECT BOP.[Name] FROM WSBuyOrderOpr_Lang BOP WHERE BOP.BuyOrderOprID = BO.BuyOrderOprId AND BOP.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBuyOrderOpr]
				,[bordTitle] AS [ApiBordTitle]
				,[bordNumber] AS [ApiBordNumber]
				,[bordOrderNumber] AS [ApiBordOrderNumber]
				,[bordDateTime] AS [ApiBordDateTime]
				,(FORMAT([bordDateTime], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordDate]
				,[bordOrderDateTime] AS [ApiBordOrderDateTime]
				,(FORMAT([bordOrderDateTime], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordOrderDate]
				,[bordCompanyId] AS [ApiBordCompanyId]
				,(CASE WHEN ISNULL((SELECT C.[cmpKind] FROM CrmCompany C WHERE C.CompanyID = BO.bordCompanyId), 0) = 0
					THEN ((ISNULL((SELECT CompanyTitle FROM [dbo].[CrmCompanyTitle_Lang] CT WHERE CT.[CompanyTitleID] = (SELECT C.[cmpTitleId] FROM CrmCompany C WHERE C.CompanyID = BO.bordCompanyId) AND CT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''') + '' '' + 
							ISNULL((SELECT C.[cmpName] FROM CrmCompany_Lang C WHERE C.CompanyID = BO.bordCompanyId AND C.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''')))
					ELSE (SELECT ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle_Lang] PT WHERE PT.PersonTitleID = CCP.prsTitleId AND PT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''') + '' '' + ISNULL(prsFName, '''') + '' '' + ISNULL(prsLName, '''') FROM [dbo].[CRMvwSelectCompanyPersons_Lang] CCP
								WHERE CCP.CompanyPersonID = (SELECT C.[cmpMainPersonId] FROM CrmCompany C WHERE C.CompanyID = BO.bordCompanyId)
								  AND CCP.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ')
				 END) ApiCmpNameWithTitle
				,[bordCompanyPersonId] AS [ApiBordCompanyPersonId]
				,(SELECT ISNULL(P.prsFName, '''') + '' '' + ISNULL(P.prsLName, '''')FROM CrmCompanyPersons P WHERE P.CompanyPersonID = BO.bordCompanyPersonId) AS [ApiBordCompanyPerson]
				,[bordProjectId] AS [ApiBordProjectId]
				,(SELECT P.prjTitle FROM CrmProjects_Lang P WHERE P.ProjectID = BO.bordProjectId AND P.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordProject]
				,[bordSubject] AS [ApiBordSubject]
				,[bordItemCount] AS [ApiBordItemCount]
				,[bordItemsAmount] AS [ApiBordItemsAmount]
				,[bordDiscount] AS [ApiBordDiscount]
				,[bordSumAmount] AS [ApiBordSumAmount]
				,[bordTax] AS [ApiBordTax]
				,[bordTaxIndex] AS [ApiBordTaxIndex]
				,[bordCalculateTax] AS [ApiBordCalculateTax]
				,[bordTotalAmount] AS [ApiBordTotalAmount]
				,[bordTotalAmountStr] AS [ApiBordTotalAmountStr]
				,[bordIsVerified] AS [ApiBordIsVerified]
				,[bordStatusId] AS [ApiBordStatusId]
				,(SELECT S.BuyOrderStatus FROM WSBuyOrderStatus_Lang S WHERE S.BuyOrderStatusId = BO.bordStatusId AND S.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordStatus]
				,[bordIsFixed] AS [ApiBordIsFixed]
				,[bordPrintFormatId] AS [ApiBordPrintFormatId]
				,(SELECT P.Title FROM PrintFormat_Lang P WHERE P.PrintFormatID = BO.bordPrintFormatId AND P.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordPrintFormat]
				,[bordImportDateTime] AS [ApiBordImportDateTime]
				,(FORMAT([bordImportDateTime], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordImportDate]
				,[bordVerifierId] AS [ApiBordVerifierId]
				,(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users_Lang U WHERE U.UserId = BO.[bordVerifierId] AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordVerifier]
				,[bordVerifiedRegisterDate] AS [ApiBordVerifiedRegisterDate]
				,(FORMAT([bordVerifiedRegisterDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordVerifiedRegisterDatePersian]
				,[bordFirstRegisterUserId] AS [ApiBordFirstRegisterUserId]
				,(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users_Lang U WHERE U.UserId = BO.[bordFirstRegisterUserId] AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordFirstRegisterUser]
				,[bordSettlementTypeId] AS [ApiBordSettlementTypeId]
				,(SELECT S.[Name] FROM WSSettlementType_Lang S WHERE S.Id = BO.bordSettlementTypeId AND S.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordSettlementType]
				,[bordDay] AS [ApiBordDay]
				,[bordTime] AS [ApiBordTime]
			'
		SET @Cols = @Cols + N'
				,[bordTransportation] AS [ApiBordTransportation]
				,[bordReferUserId] AS [ApiBordReferUserId]
				,(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users_Lang U WHERE U.UserId = BO.[bordReferUserId] AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordReferUser]
				,[bordRound] AS [ApiBordRound]
				,[bordDiscountPercent] AS [ApiBordDiscountPercent]
				,[bordDiscountTitle] AS [ApiBordDiscountTitle]
				,[bordNote] AS [ApiBordNote]
				,[bordcmpTitle] AS [ApiBordcmpTitle]
				,[bordLinkAccCodeId] AS [ApiBordLinkAccCodeId]
				,[bordLinkAccCode] AS [ApiBordLinkAccCode]
				,[bordLinkAccBuyOrderId] AS [ApiBordLinkAccBuyOrderId]
				,[bordLinkAccBuyOrderNumber] AS [ApiBordLinkAccBuyOrderNumber]
				,[bordLinkAccVoucherId] AS [ApiBordLinkAccVoucherId]
				,[bordLinkAccVoucherNumber] AS [ApiBordLinkAccVoucherNumber]
				,[bordCurrencyUnitId] AS [ApiBordCurrencyUnitId]
				,(SELECT C.CurrencyUnit FROM WSCurrencyUnits_Lang C WHERE C.CurrencyUnitID = BO.[bordCurrencyUnitId] AND C.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordCurrencyUnit]
				,[bordFacilityCmpId] AS [ApiBordFacilityCmpId]
				,(CASE WHEN ISNULL((SELECT C.[cmpKind] FROM CrmCompany C WHERE C.CompanyID = BO.[bordFacilityCmpId]), 0) = 0
						THEN ((ISNULL((SELECT CompanyTitle FROM [dbo].[CrmCompanyTitle_Lang] CT WHERE CT.[CompanyTitleID] = (SELECT C.[cmpTitleId] FROM CrmCompany C WHERE C.CompanyID = BO.[bordFacilityCmpId]) AND CT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''') + '' '' + 
								ISNULL((SELECT C.[cmpName] FROM CrmCompany_Lang C WHERE C.CompanyID = BO.[bordFacilityCmpId] AND C.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''')))
						ELSE (SELECT ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle_Lang] PT WHERE PT.PersonTitleID = CCP.prsTitleId AND PT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''') + '' '' + ISNULL(prsFName, '''') + '' '' + ISNULL(prsLName, '''') FROM [dbo].[CRMvwSelectCompanyPersons_Lang] CCP
								WHERE CCP.CompanyPersonID = (SELECT C.[cmpMainPersonId] FROM CrmCompany C WHERE C.CompanyID = BO.[bordFacilityCmpId])
								  AND CCP.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ')
				END) AS [ApiBordFacilityCmp]
				,[bordFacilityPrsId] AS [ApiBordFacilityPrsId]
				,(SELECT ISNULL(P.prsFName, '''') + '' '' + ISNULL(P.prsLName, '''') FROM CrmCompanyPersons_Lang P WHERE P.CompanyPersonID = BO.[bordFacilityPrsId] AND P.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordFacilityPrs]
				,[bordFacilityPrjId] AS [ApiBordFacilityPrjId]
				,(SELECT P.prjTitle FROM CrmProjects_Lang P WHERE P.ProjectID = BO.bordProjectId AND P.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordFacilityPrj]
				,[bordReqCmpId] AS [ApiBordReqCmpId]
				,(CASE WHEN ISNULL((SELECT C.[cmpKind] FROM CrmCompany C WHERE C.CompanyID = BO.[bordReqCmpId]), 0) = 0
					THEN ((ISNULL((SELECT CompanyTitle FROM [dbo].[CrmCompanyTitle_Lang] CT WHERE CT.[CompanyTitleID] = (SELECT C.[cmpTitleId] FROM CrmCompany C WHERE C.CompanyID = BO.[bordReqCmpId]) AND CT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''') + '' '' + 
							ISNULL((SELECT C.[cmpName]FROM CrmCompany_Lang C WHERE C.CompanyID = BO.[bordReqCmpId] AND C.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''')))
					ELSE (SELECT ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle_Lang] PT WHERE PT.PersonTitleID = CCP.prsTitleId AND PT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''') + '' '' + ISNULL(prsFName, '''') + '' '' + ISNULL(prsLName, '''') FROM [dbo].[CRMvwSelectCompanyPersons_Lang] CCP
							WHERE CCP.CompanyPersonID = (SELECT C.[cmpMainPersonId] FROM CrmCompany C WHERE C.CompanyID = BO.[bordReqCmpId])
							  AND CCP.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ')
				END) AS [ApiBordReqCmp]
				,[bordReqPrsId] AS [ApiBordReqPrsId]
				,(SELECT ISNULL(P.prsFName, '''') + '' '' + ISNULL(P.prsLName, '''') FROM CrmCompanyPersons_Lang P WHERE P.CompanyPersonID = BO.[bordReqPrsId] AND P.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordReqPrs]
				,[bordReqPrjId] AS [ApiBordReqPrjId]
				,(SELECT P.prjTitle FROM CrmProjects_Lang P WHERE P.ProjectID = BO.[bordReqPrjId] AND P.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordReqPrj]
				,[bordDeliveryTerm] AS [ApiBordDeliveryTerm]
				,[bordDeliveryDate] AS [ApiBordDeliveryDate]
				,(FORMAT([bordDeliveryDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordDeliveryDatePersian]
				,[bordTaxCleared] AS [ApiBordTaxCleared]
				,[bordTaxClearedDate] AS [ApiBordTaxClearedDate]
				,(FORMAT([bordTaxClearedDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordTaxClearedDatePersian]
			'
		SET @Cols = @Cols + N'
				,[bordFacilityCost] AS [ApiBordFacilityCost]
				,[bordFacilityCostPercent] AS [ApiBordFacilityCostPercent]
				,[bordSupplierDeliveryDate] AS [ApiBordSupplierDeliveryDate]
				,(FORMAT([bordSupplierDeliveryDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordSupplierDeliveryDatePersian]
				,[bordForwarderName] AS [ApiBordForwarderName]
				,[bordFreightCost] AS [ApiBordFreightCost]
				,[bordFreightCurrUnId] AS [ApiBordFreightCurrUnId]
				,(SELECT C.CurrencyUnit FROM WSCurrencyUnits_Lang C WHERE C.CurrencyUnitID = BO.[bordFreightCurrUnId] AND C.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordFreightCurrUn]
				,[bordFreightCurrencyRate] AS [ApiBordFreightCurrencyRate]
				,[bordFinalFreightCost] AS [ApiBordFinalFreightCost]
				,[bordCustomsPart] AS [ApiBordCustomsPart]
				,[bordCustomsFee] AS [ApiBordCustomsFee]
				,[bordCustomsCurrUnId] AS [ApiBordCustomsCurrUnId]
				,(SELECT C.CurrencyUnit FROM WSCurrencyUnits_Lang C WHERE C.CurrencyUnitID = BO.[bordCustomsCurrUnId] AND C.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordCustomsCurrUn]
				,[bordCustomsCurrencyRate] AS [ApiBordCustomsCurrencyRate]
				,[bordFinalCustomsFee] AS [ApiBordFinalCustomsFee]
				,[bordFinalDeliveryDate] AS [ApiBordFinalDeliveryDate]
				,(FORMAT([bordFinalDeliveryDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordFinalDeliveryDatePersian]
				,[bordTotalFinalCost] AS [ApiBordTotalFinalCost]
				,[bordCommission] AS [ApiBordCommission]
				,[bordCommissionCurrUnId] AS [ApiBordCommissionCurrUnId]
				,(SELECT C.CurrencyUnit FROM WSCurrencyUnits_Lang C WHERE C.CurrencyUnitID = BO.[bordCommissionCurrUnId] AND C.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordCommissionCurrUn]
				,[bordCommissionCurrencyRate] AS [ApiBordCommissionCurrencyRate]
				,[bordFinalCommission] AS [ApiBordFinalCommission]
				,[bordCostSheetId] AS [ApiBordCostSheetId]
				,(SELECT CS.ctshTitle FROM WSCostSheets_Lang CS WHERE CS.CostSheetId = BO.[bordCostSheetId] AND CS.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordCostSheet]
				,[bordNumRef] AS [ApiBordNumRef]
				,[bordItemsQty] AS [ApiBordItemsQty]
				,[bordItemsDiscount] AS [ApiBordItemsDiscount]
				,[bordItemsTax] AS [ApiBordItemsTax]
				,[bordDefaultSettingId] AS [ApiBordDefaultSettingId]
				,(SELECT DS.SettingTitle FROM WSBuyOrderDefaultSetting_Lang DS WHERE DS.BuyOrderDefaultSettingId = BO.[bordDefaultSettingId] AND DS.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordDefaultSetting]
				,[bordVerificationWorkFlowId] AS [ApiBordVerificationWorkFlowId]
				,(SELECT V.VerificationWorkFlowTitle FROM WSVerificationWorkFlows_Lang V WHERE V.VerificationWorkFlowId = BO.[bordVerificationWorkFlowId] AND V.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordVerificationWorkFlow]
				,[bordLinkAccFirstTransferDate] AS [ApiBordLinkAccFirstTransferDate]
				,(FORMAT([bordLinkAccFirstTransferDate], ''yyyy/MM/dd HH:mm'', ''' + @LanguageCollation + ''')) AS [ApiBordLinkAccFirstTransferDatePersian]
				,[bordLinkAccLastTransferDate] AS [ApiBordLinkAccLastTransferDate]
				,[bordLinkAccBuyOrderIdStr] AS [ApiBordLinkAccBuyOrderIdStr]
				,[bordCurrencyUnitIdI] AS [ApiBordCurrencyUnitIdI]
				,(SELECT C.CurrencyUnitID FROM WSCurrencyUnits_Lang C WHERE C.CurrencyUnitID = BO.[bordCurrencyUnitIdI] AND C.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiBordCurrencyUnitI]
				,[bordCurrencyUnitIRate] AS [ApiBordCurrencyUnitIRate]
				,[bordItemsAmountCurrencyI] AS [ApiBordItemsAmountCurrencyI]
				,[bordDiscountCurrencyI] AS [ApiBordDiscountCurrencyI]
				,[bordSumAmountCurrencyI] AS [ApiBordSumAmountCurrencyI]
				,[bordTaxCurrencyI] AS [ApiBordTaxCurrencyI]
				,[bordTotalAmountCurrencyI] AS [ApiBordTotalAmountCurrencyI]
				,[bordTotalAmountCurrencyIStr] AS [ApiBordTotalAmountCurrencyIStr]
				,[bordTransportationCurrencyI] AS [ApiBordTransportationCurrencyI]
				,[bordRoundCurrencyI] AS [ApiBordRoundCurrencyI]
				,[bordItemsDiscountCurrencyI] AS [ApiBordItemsDiscountCurrencyI]
				,[bordItemsTaxCurrencyI] AS [ApiBordItemsTaxCurrencyI]
		'
		SET @Cols = @Cols + N'
				,[UserId] AS [ApiUserId]
				,(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users_Lang U WHERE U.UserId = BO.[UserId] AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiEditUser]
				,[FPId] AS [ApiFPId]
				,[Month1] AS [ApiMonth1]
				,[RegisterDate] AS [ApiRegisterDate]
				,(FORMAT([RegisterDate], ''yyyy/MM/dd HH:mm'')) AS [ApiRegisterDatePersian]
				,[GUId] AS [ApiGUId]
				,[AppType] AS [ApiAppType]
				,[LanguageID] AS [ApiLanguageID]
				,[FirstRegisterUserId] AS [ApiFirstRegisterUserId]
				,(SELECT ISNULL(FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users_Lang U WHERE U.UserId = BO.[FirstRegisterUserId] AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiFirstRegisterUser]
				,[FirstRegisterDate] AS [ApiFirstRegisterDate]
				,(FORMAT([FirstRegisterDate], ''yyyy/MM/dd HH:mm'')) AS [ApiFirstRegisterDatePersian]
		'
		/**/
	END

	IF (ISNULL(@BuyOrderID, 0) > 0)
	BEGIN
		SET @Term = @Term + ' AND BuyOrderID = ' + CAST(@BuyOrderID AS NVARCHAR(50))
	END
	IF (ISNULL(@BuyOrdNumber, 0) > 0)
	BEGIN
		SET @Term = @Term + ' AND bordNumber = ' + CAST(@BuyOrdNumber AS NVARCHAR(50))
	END
	IF ((@FromDate IS NOT NULL) AND (@ToDate IS NOT NULL))
	BEGIN
		SET @Term = @Term + ' AND bordDateTime BETWEEN ''' + CAST(@FromDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToDate AS NVARCHAR(50)) + ''''
	END
	IF ((@FromRegisterDate IS NOT NULL) AND (@ToRegisterDate IS NOT NULL))
	BEGIN
		SET @Term = @Term + ' AND RegisterDate BETWEEN ''' + CAST(@FromRegisterDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToRegisterDate AS NVARCHAR(50)) + ''''
	END
	IF ((@FromFirstRegisterDate IS NOT NULL) AND (@ToFirstRegisterDate IS NOT NULL))
	BEGIN
		SET @Term = @Term + ' AND FirstRegisterDate BETWEEN ''' + CAST(@FromFirstRegisterDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToFirstRegisterDate AS NVARCHAR(50)) + ''''
	END


	EXECUTE (N'SELECT ' + @Cols + N' FROM WSBuyOrder BO WHERE 1=1 ' + @Term + ' ORDER BY bordDateTime, bordNumber' )

	/**/
END






