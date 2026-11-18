






/*NKR990513*/
/*RZ990515- Modify this sp*/
/*NKR14020729- Add Delivery Fields*/
CREATE PROCEDURE [dbo].[ApispSelectOrder]
(
	/*
		EXEC ApispSelectOrder NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1065, 1065
	*/
	@OrderID INT = NULL,
	@ordNumber BIGINT = NULL,
	@FromOrderDate DATETIME = NULL,
	@ToOrderDate DATETIME = NULL,
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
	DECLARE @QRY NVARCHAR(MAX) = ''

	IF (@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
		/**/

		SET @QRY = '
					SELECT
						OrderID AS ApiOrderID,
						OrderOprID AS ApiOrderOprID,
						(SELECT ISNULL(OO.[Name], '''') FROM [WSOrderOpr] OO WHERE OO.[OrderOprID] = O.OrderOprID) AS ApiOrderOpr,/*RZ990515*/
						PreOrderId AS ApiPreOrderId,
						(SELECT ISNULL(PO.pordTitle, '''') FROM WSPreOrder PO WHERE PO.PreOrderID = O.PreOrderId) AS ApiPreOrderTitle,
						PreOrderVerifierId AS ApiPreOrderVerifierId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = O.UserId) AS ApiPreOrderVerifier,
						ordTitle AS ApiOrdTitle,
						ordNumber AS ApiOrdNumber,
						ordDate AS ApiOrdDate,
						ordCompanyId AS ApiOrdCompanyId,
						(SELECT 
							ISNULL((SELECT CCT.CompanyTitle FROM CrmCompanyTitle CCT WHERE CCT.CompanyTitleID = CC.cmpTitleId),'''') + '' '' + /*RZ990515*/
							ISNULL(CC.cmpName, '''') 
						FROM CrmCompany CC WHERE CC.CompanyID = O.ordCompanyId) AS ApiOrdCompany,
						ordCompanyPersonId AS ApiOrdCompanyPersonId,
						(SELECT 
							ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId]),'''') + '' '' + /*RZ990515*/
							ISNULL(CCP.prsFName, '''') + '' '' + ISNULL(CCP.prsLName, '''') 
						FROM CrmCompanyPersons CCP WHERE CCP.CompanyPersonID = O.ordCompanyPersonId) AS ApiOrdCompanyPerson,
						ordProjectId AS ApiOrdProjectId,
						(SELECT ISNULL(CP.prjTitle, '''') + '' '' + ISNULL(CP.prjPostFix, '''') FROM CrmProjects CP WHERE CP.ProjectID = O.ordProjectId) AS ApiOrdProject,/*RZ990515*/
						ordSubject AS ApiOrdSubject,
						ordItemCount AS ApiOrdItemCount,
						ordItemsAmount AS ApiOrdItemsAmount,
						ordInstallAmount AS ApiOrdInstallAmount,
						ordDiscount AS ApiOrdDiscount,
						ordSumAmount AS ApiOrdSumAmount,
						ordTax AS ApiOrdTax,
						ordTaxIndex AS ApiOrdTaxIndex,
						ordCalculateTax AS ApiOrdCalculateTax,
						ordTotalAmount AS ApiOrdTotalAmount,
						ordTotalAmountStr AS ApiOrdTotalAmountStr,
						ordIsVerified AS ApiOrdIsVerified,
						ordVerifiedRegisterDate AS ApiOrdVerifiedRegisterDate,
						ordVerifiedRegisterDatePersian AS ApiOrdVerifiedRegisterDatePersian,
						ordStatusId AS ApiOrdStatusId,
						(SELECT ISNULL(OS.OrderStatus, '''') FROM WSOrderStatus OS WHERE OS.OrderStatusId = O.ordStatusId) AS ApiOrdStatus,
						ordIsFixed AS ApiOrdIsFixed, '
		SET @QRY = @QRY + '
						ordGuarantyId AS ApiOrdGuarantyId,
						(SELECT ISNULL(G.Guaranty, '''') FROM WSGuaranty G WHERE G.GuarantyID = O.ordGuarantyId) AS ApiOrdGuaranty,
						ordSpecialWord AS ApiOrdSpecialWord,
						ordDescriptionI AS ApiOrdDescriptionI,
						ordDescriptionII AS ApiOrdDescriptionII,
						ordDescriptionId AS ApiOrdDescriptionId,
						ordPrintFormatId AS ApiOrdPrintFormatId,
						(SELECT ISNULL(PF.Title, '''') FROM PrintFormat PF WHERE PF.PrintFormatID = O.ordPrintFormatId) AS ApiOrdPrintFormat,
						ordRLogoId AS ApiOrdRLogoId,
						ordLLogoId AS ApiOrdLLogoId,
						ordSigningI AS ApiOrdSigningI,
						ordSigningII AS ApiOrdSigningII,
						ordSigningIII AS ApiOrdSigningIII,
						ordAccountNumberI AS ApiOrdAccountNumberI,
						ordAccountShabaNumberI AS ApiOrdAccountShabaNumberI,
						ordAccountNumberII AS ApiOrdAccountNumberII,
						ordAccountShabaNumberII AS ApiOrdAccountShabaNumberII,
						ordSignatureId AS ApiOrdSignatureId,
						ordImportDate AS ApiOrdImportDate,	
						FPId AS ApiFPId,	
						ordVerifierId AS ApiOrdVerifierId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = O.ordVerifierId) AS ApiOrdVerifier,
						ordSettlementTypeId AS ApiOrdSettlementTypeId,
						(SELECT ISNULL(ST.Name, '''') FROM WSSettlementType ST WHERE ST.Id = O.ordSettlementTypeId) AS ApiOrdSettlementType,
						ordDay AS ApiOrdDay,
						ordTime AS ApiOrdTime, '
		SET @QRY = @QRY + '
						ordTransportation AS ApiOrdTransportation,
						ordReferUserId AS ApiOrdReferUserId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = O.ordReferUserId) AS ApiOrdReferUser,
						ordDiscountPercent AS ApiOrdDiscountPercent,
						ordDiscountTitle AS ApiOrdDiscountTitle,
						ordRound AS ApiOrdRound,
						ordNote AS ApiOrdNote,
						ordcmpTitle AS ApiOrdcmpTitle,
						ordDateTime AS ApiOrdDateTime,
						ordImportDateTime AS ApiOrdImportDateTime,
						ordDeliveryDate AS ApiOrdDeliveryDate,
						ordDeliveryDateTime AS ApiOrdDeliveryDateTime,
						ordDeliveryTime AS ApiOrdDeliveryTime,
						ordSerial AS ApiOrdSerial,	
						ordVerifierRequestId AS ApiOrdVerifierRequestId,	
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = O.ordVerifierRequestId) AS ApiOrdVerifierRequest,
						ordVerificationWorkFlowId AS ApiOrdVerificationWorkFlowId,
						(SELECT ISNULL(VWF.VerificationWorkFlowTitle, '''') FROM WSVerificationWorkFlows VWF WHERE VWF.VerificationWorkFlowId = O.ordVerificationWorkFlowId) AS ApiOrdVerificationWorkFlow,
						UserId AS ApiUserId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = O.UserId) AS ApiEditUser,						
						RegisterDate AS ApiRegisterDate,
						FirstRegisterUserId AS ApiFirstRegisterUserId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = O.FirstRegisterUserId) AS ApiFirstRegisterUser,
						FirstRegisterDate AS ApiFirstRegisterDate,
						[ordLinkAccCodeId] AS ApiOrdLinkAccCodeId
						,[ordLinkAccCode] AS ApiOrdLinkAccCode
						,[ordLinkAccOrderId] AS ApiOrdLinkAccOrderId
						,[ordLinkAccOrderNumber] AS ApiOrdLinkAccOrderNumber
						,[ordLinkAccVoucherId] AS ApiOrdLinkAccVoucherId
						/*NKR14020730- Start*/
						,[ordDeliveryTermId] AS ApiOrdDeliveryTermId
						,[ordDeliveryEndDate] AS ApiOrdDeliveryEndDate 
						,[ordDeliveryEndDateTime] AS ApiordDeliveryEndDateTime
						,[ordDeliveryEndTime] AS ApiOrdDeliveryEndTime
						,[ordDeliveryDay] AS ApiOrdDeliveryDay
						,[ordDeliveryEndDay] AS ApiOrdDeliveryEndDay
						,[ordLinkAccVoucherNumber] AS ApiOrdLinkAccVoucherNumber
						/*NKR14020730- End*/
					FROM WSOrder O WHERE 1 = 1 '

		/**/
	END
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		/**/
		SET @QRY = '
					SELECT
						OrderID AS ApiOrderID,
						OrderOprID AS ApiOrderOprID,
						(SELECT ISNULL(OO.[Name], '''') FROM [WSOrderOpr_Lang] OO WHERE OO.[OrderOprID] = O.OrderOprID AND OO.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrderOpr,/*RZ990515*/
						PreOrderId AS ApiPreOrderId,
						(SELECT ISNULL(POL.pordTitle, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = O.PreOrderId AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPreOrderTitle,
						PreOrderVerifierId AS ApiPreOrderVerifierId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = O.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPreOrderVerifier,
						(SELECT ISNULL(OL.ordTitle, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdTitle,
						ordNumber AS ApiOrdNumber,
						ordDate AS ApiOrdDate,
						ordCompanyId AS ApiOrdCompanyId,						
						(SELECT 
							ISNULL((SELECT CCT.CompanyTitle FROM CrmCompanyTitle_Lang CCT WHERE CCT.CompanyTitleID = C.cmpTitleId AND CCT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') + '' '' +/*RZ990515*/
							ISNULL((SELECT ISNULL(CCL.cmpName, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = C.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') , '''') 
						FROM CrmCompany C 
						WHERE C.CompanyID = O.ordCompanyId) AS ApiOrdCompany,
						ordCompanyPersonId AS ApiOrdCompanyPersonId,						
						(SELECT 
							ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle_Lang] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId] AND PT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') + '' '' +/*RZ990515*/
							ISNULL((SELECT ISNULL(CCPL.prsFName, '''') + '' '' + ISNULL(CCPL.prsLName, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') , '''') 
						FROM CrmCompanyPersons CCP 
						WHERE CCP.CompanyPersonID = O.ordCompanyPersonId) AS ApiOrdCompanyPerson,
						ordProjectId AS ApiOrdProjectId,
						(SELECT ISNULL(CPL.prjTitle, '''') + '' '' + ISNULL(CPL.prjPostFix, '''') FROM CrmProjects_Lang CPL WHERE CPL.ProjectID = O.ordProjectId AND CPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdProject,/*RZ990515*/
						(SELECT ISNULL(OL.ordSubject, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdSubject,
						ordItemCount AS ApiOrdItemCount,
						ordItemsAmount AS ApiOrdItemsAmount,
						ordInstallAmount AS ApiOrdInstallAmount,
						ordDiscount AS ApiOrdDiscount,
						ordSumAmount AS ApiOrdSumAmount,
						ordTax AS ApiOrdTax,
						ordTaxIndex AS ApiOrdTaxIndex,
						ordCalculateTax AS ApiOrdCalculateTax,
						ordTotalAmount AS ApiOrdTotalAmount,
						(SELECT ISNULL(OL.ordTotalAmountStr, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdTotalAmountStr,
						ordIsVerified AS ApiOrdIsVerified,
						ordVerifiedRegisterDate AS ApiOrdVerifiedRegisterDate,
						ordVerifiedRegisterDatePersian AS ApiOrdVerifiedRegisterDatePersian,
						ordStatusId AS ApiOrdStatusId,
						(SELECT ISNULL(OSL.OrderStatus, '''') FROM WSOrderStatus_Lang OSL WHERE OSL.OrderStatusId = O.ordStatusId AND OSL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdStatus,
						ordIsFixed AS ApiOrdIsFixed,
						ordGuarantyId AS ApiOrdGuarantyId, '
		SET @QRY = @QRY + '
						(SELECT ISNULL(GL.Guaranty, '''') FROM WSGuaranty_Lang GL WHERE GL.GuarantyID = O.ordGuarantyId AND GL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdGuaranty,
						(SELECT ISNULL(OL.ordSpecialWord, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdSpecialWord,
						(SELECT ISNULL(OL.ordDescriptionI, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdDescriptionI,
						(SELECT ISNULL(OL.ordDescriptionII, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdDescriptionII,
						ordDescriptionId AS ApiOrdDescriptionId,
						ordPrintFormatId AS ApiOrdPrintFormatId,
						(SELECT ISNULL(PFL.Title, '''') FROM PrintFormat_Lang PFL WHERE PFL.PrintFormatID = O.ordPrintFormatId AND PFL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdPrintFormat,
						ordRLogoId AS ApiOrdRLogoId,
						ordLLogoId AS ApiOrdLLogoId,
						(SELECT ISNULL(OL.ordSigningI, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdSigningI,
						(SELECT ISNULL(OL.ordSigningII, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdSigningII,
						(SELECT ISNULL(OL.ordSigningIII, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdSigningIII,
						ordAccountNumberI AS ApiOrdAccountNumberI,
						ordAccountShabaNumberI AS ApiOrdAccountShabaNumberI,
						ordAccountNumberII AS ApiOrdAccountNumberII,
						ordAccountShabaNumberII AS ApiOrdAccountShabaNumberII,
						ordSignatureId AS ApiOrdSignatureId,
						ordImportDate AS ApiOrdImportDate,	
						FPId AS ApiFPId,	
						ordVerifierId AS ApiOrdVerifierId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = O.ordVerifierId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdVerifier,
						ordSettlementTypeId AS ApiOrdSettlementTypeId,
						(SELECT ISNULL(STL.Name, '''') FROM WSSettlementType_Lang STL WHERE STL.Id = O.ordSettlementTypeId AND STL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdSettlementType,
						ordDay AS ApiOrdDay,
						ordTime AS ApiOrdTime,
						ordTransportation AS ApiOrdTransportation,
						ordReferUserId AS ApiOrdReferUserId, '
		SET @QRY = @QRY + '
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = O.ordReferUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdReferUser,
						ordDiscountPercent AS ApiOrdDiscountPercent,
						(SELECT ISNULL(OL.ordDiscountTitle, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdDiscountTitle,
						ordRound AS ApiOrdRound,
						(SELECT ISNULL(OL.ordNote, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdNote,
						(SELECT ISNULL(OL.ordcmpTitle, '''') FROM WSOrder_Lang OL WHERE OL.OrderID = O.OrderID AND OL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdcmpTitle,
						ordDateTime AS ApiOrdDateTime,
						ordImportDateTime AS ApiOrdImportDateTime,
						ordDeliveryDate AS ApiOrdDeliveryDate,
						ordDeliveryDateTime AS ApiOrdDeliveryDateTime,
						ordDeliveryTime AS ApiOrdDeliveryTime,
						ordSerial AS ApiOrdSerial,	
						ordVerifierRequestId AS ApiOrdVerifierRequestId,	
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = O.ordVerifierRequestId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdVerifierRequest,
						ordVerificationWorkFlowId AS ApiOrdVerificationWorkFlowId,
						(SELECT ISNULL(VWFL.VerificationWorkFlowTitle, '''') FROM WSVerificationWorkFlows_Lang VWFL WHERE VWFL.VerificationWorkFlowId = O.ordVerificationWorkFlowId AND VWFL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOrdVerificationWorkFlow,
						UserId AS ApiUserId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = O.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiEditUser,						
						RegisterDate AS ApiRegisterDate,
						FirstRegisterUserId AS ApiFirstRegisterUserId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = O.FirstRegisterUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiFirstRegisterUser,
						FirstRegisterDate AS ApiFirstRegisterDate,
						[ordLinkAccCodeId] AS ApiOrdLinkAccCodeId
						,[ordLinkAccCode] AS ApiOrdLinkAccCode
						,[ordLinkAccOrderId] AS ApiOrdLinkAccOrderId
						,[ordLinkAccOrderNumber] AS ApiOrdLinkAccOrderNumber
						,[ordLinkAccVoucherId] AS ApiOrdLinkAccVoucherId
						,[ordLinkAccVoucherNumber] AS ApiOrdLinkAccVoucherNumber
						/*NKR14020730- Start*/
						,[ordDeliveryTermId] AS ApiOrdDeliveryTermId
						,[ordDeliveryEndDate] AS ApiOrdDeliveryEndDate 
						,[ordDeliveryEndDateTime] AS ApiordDeliveryEndDateTime
						,[ordDeliveryEndTime] AS ApiOrdDeliveryEndTime
						,[ordDeliveryDay] AS ApiOrdDeliveryDay
						,[ordDeliveryEndDay] AS ApiOrdDeliveryEndDay
						/*NKR14020730- End*/
					FROM WSOrder O WHERE 1 = 1 '
		/**/
	END

	/*----------------------------------------*/
	IF (ISNULL(@OrderID, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND OrderID = ' + CAST(@OrderID AS NVARCHAR(50))
	END
	IF (ISNULL(@ordNumber, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND ordNumber = ' + CAST(@ordNumber AS NVARCHAR(50))
	END
	IF ((@FromOrderDate IS NOT NULL) AND (@ToOrderDate IS NOT NULL))
	BEGIN
		SET @QRY = @QRY + ' AND ordDateTime BETWEEN ''' + CAST(@FromOrderDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToOrderDate AS NVARCHAR(50)) + ''''
	END
	IF ((@FromRegisterDate IS NOT NULL) AND (@ToRegisterDate IS NOT NULL))
	BEGIN
		SET @QRY = @QRY + ' AND RegisterDate BETWEEN ''' + CAST(@FromRegisterDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToRegisterDate AS NVARCHAR(50)) + ''''
	END
	IF ((@FromFirstRegisterDate IS NOT NULL) AND (@ToFirstRegisterDate IS NOT NULL))
	BEGIN
		SET @QRY = @QRY + ' AND FirstRegisterDate BETWEEN ''' + CAST(@FromFirstRegisterDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToFirstRegisterDate AS NVARCHAR(50)) + ''''
	END


	EXECUTE (@QRY + N' ORDER BY ordDate, ordNumber' )/*RZ990515*/

	/**/
END





