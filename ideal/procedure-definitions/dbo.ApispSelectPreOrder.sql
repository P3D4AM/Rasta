





/*NKR990512*/
/*RZ990515- Modify this sp*/
/*NKR14020730- Add Delivery Fields*/
CREATE PROCEDURE [dbo].[ApispSelectPreOrder]
(
	/*
		EXEC ApispSelectPreOrder 2396, 920001, '2020-06-11 20:20:00', '2020-06-13 20:20:00', '2020-02-01 02:41:00', '2020-02-02 11:41:00', '2020-04-22 02:46:04', '2020-04-23 10:46:04', 1065, 1065		
	*/
	@PreOrderID INT = NULL,
	@pordNumber BIGINT = NULL,
	@FromPreOrderDate DATETIME = NULL,
	@ToPreOrderDate DATETIME = NULL,
	@FromRegisterDate DATETIME = NULL,
	@ToRegisterDate DATETIME = NULL,
	@FromFirstRegisterDate DATETIME = NULL,
	@ToFirstRegisterDate DATETIME = NULL,
	@LanguageID INT  = NULL,
	@DefaultLanguageID INT  = NULL
)
AS
BEGIN
	/**/

	DECLARE @QRY NVARCHAR(MAX) = ''
	

	/*======================= Start Columns =======================*/

	
	IF (@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
		/**/
		SET @QRY = 
			'	SELECT 
					PreOrderID AS ApiPreOrderID,
					pordTitle AS ApiPordTitle,
					pordNumber AS ApiPordNumber,
					pordDate AS ApiPordDate,
					pordCompanyId AS ApiPordCompanyId,
					(SELECT 
						ISNULL((SELECT CCT.CompanyTitle FROM CrmCompanyTitle CCT WHERE CCT.CompanyTitleID = C.cmpTitleId),'''') + '' '' +/*RZ990515*/
						ISNULL(C.cmpName, '''') 
					FROM CrmCompany C WHERE C.CompanyID = PO.pordCompanyId) AS ApiPordCompany,
					pordCompanyPersonId AS ApiPordCompanyPersonId,
					(SELECT 
						ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.[PersonTitleID] = CP.[prsTitleId]),'''') + '' '' +/*RZ990515*/
						ISNULL(CP.prsFName, '''') + '' '' + ISNULL(CP.prsLName, '''') 
					FROM CrmCompanyPersons CP WHERE CP.CompanyPersonID = PO.pordCompanyPersonId) AS ApiPordCompanyPerson,
					pordProjectId AS ApiPordProjectId,
					(SELECT ISNULL(P.prjTitle, '''') + '' '' + ISNULL(P.prjPostFix, '''') FROM CrmProjects P WHERE P.ProjectID = PO.pordProjectId) AS ApiPordProject,/*RZ990515*/
					pordSubject AS ApiPordSubject,
					pordItemCount AS ApiPordItemCount,
					pordItemsAmount AS ApiPordItemsAmount,
					pordInstallAmount AS ApiPordInstallAmount,
					pordDiscount AS ApiPordDiscount,
					pordSumAmount AS ApiPordSumAmount,
					pordTax AS ApiPordTax,
					pordTaxIndex AS ApiPordTaxIndex,
					pordCalculateTax AS ApiPordCalculateTax,
					pordTotalAmount AS ApiPordTotalAmount,
					pordTotalAmountStr AS ApiPordTotalAmountStr,
					pordIsVerified AS ApiPordIsVerified,
					pordVerifierId AS ApiPordVerifierId,
					(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = PO.pordVerifierId) AS ApiPordVerifier,
					pordVerifierRequestId AS ApiPordVerifierRequestId,
					(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = PO.pordVerifierRequestId) AS ApiPordVerifierRequest,
					pordVerifiedRegisterDate AS ApiPordVerifiedRegisterDate,
					pordStatusId AS ApiPordStatusId,
					(SELECT ISNULL(POS.PreOrderStatus, '''') FROM WSPreOrderStatus POS WHERE POS.PreOrderStatusId = PO.pordStatusId) AS ApiPordStatus,
					pordIsFixed AS ApiPordIsFixed, '
		SET @QRY = @QRY + '
					pordGuarantyId AS ApiPordGuarantyId,
					(SELECT ISNULL(G.Guaranty, '''') FROM WSGuaranty G WHERE G.GuarantyID = PO.pordGuarantyId) AS ApiPordGuaranty,
					pordPayConditionId AS ApiPordPayConditionId,
					(SELECT ISNULL(PC.PayCondition, '''') FROM WSPayCondition PC WHERE PC.PayConditionID = PO.pordPayConditionId) AS ApiPordPayCondition,
					pordDeliveryTimeId AS ApiPordDeliveryTimeId,
					(SELECT ISNULL(DT.DeliveryTime, '''') FROM WSDeliveryTime DT WHERE DT.DeliveryTimeID = PO.pordDeliveryTimeId) AS ApiPordDeliveryTimeTitle,
					pordCreditDurationId AS ApiPordCreditDurationId,
					(SELECT ISNULL(CD.CreditDuration, '''') FROM WSCreditDuration CD WHERE CD.CreditDurationID = PO.pordCreditDurationId) AS ApiPordCreditDuration,
					pordSpecialWord AS ApiPordSpecialWord,
					pordDescriptionI AS ApiPordDescriptionI,
					pordDescriptionII AS ApiPordDescriptionII,
					pordDescriptionId AS ApiPordDescriptionId,
					pordPrintFormatId AS ApiPordPrintFormatId,
					(SELECT ISNULL(PF.Title, '''') FROM PrintFormat PF WHERE PF.PrintFormatID = PO.pordPrintFormatId) AS ApiPordPrintFormat,
					pordRLogoId AS ApiPordRLogoId, 
					(SELECT L.LogoDescription FROM WSLogo L WHERE L.LogoID = PO.pordRLogoId) AS ApiPordRLogo,
					pordLLogoId AS ApiPordLLogoId,
					(SELECT L.LogoDescription FROM WSLogo L WHERE L.LogoID = PO.pordLLogoId) AS ApiPordLLogo,
					pordSigningI AS ApiPordSigningI,
					pordSigningII AS ApiPordSigningII,
					pordSigningIII AS ApiPordSigningIII,
					pordAccountNumberI AS ApiPordAccountNumberI,
					pordAccountShabaNumberI AS ApiPordAccountShabaNumberI,
					pordAccountNumberII AS ApiPordAccountNumberII,
					pordAccountShabaNumberII AS ApiPordAccountShabaNumberII,
					pordAddress AS ApiPordAddress,
					pordTelephone AS ApiPordTelephone,
					pordFax AS ApiPordFax,
					pordWebSite AS ApiPordWebSite,
					pordEmail AS ApiPordEmail, '
		SET @QRY = @QRY + '
					pordSignatureId AS ApiPordSignatureId,
					pordImportDate AS ApiPordImportDate,
					FPId AS ApiFPId,		
					pordDay AS ApiPordDay,
					pordTime AS ApiPordTime,
					pordDiscountTitle AS ApiPordDiscountTitle,
					pordDiscountPercent AS ApiPordDiscountPercent,
					pordTransportation AS ApiPordTransportation,
					pordReferUserId AS ApiPordReferUserId,
					(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = PO.pordReferUserId) AS ApiPordReferUser,
					pordRound AS ApiPordRound,
					pordcmpTitle AS ApiPordcmpTitle,
					pordDateTime AS ApiPordDateTime,
					pordImportDateTime AS ApiPordImportDateTime,
					pordDeliveryDateTime AS ApiPordDeliveryDateTime,
					pordDeliveryTime AS ApiPordDeliveryTime,
					PreOrderOprID AS ApiPreOrderOprID,
					(SELECT ISNULL(POO.PreOrderOpr, '''') FROM WSPreOrderOpr POO WHERE POO.PreOrderOprID = PO.PreOrderOprID) AS ApiPreOrderOpr,
					pordVerificationWorkFlowId AS ApiPordVerificationWorkFlowId,
					(SELECT ISNULL(VWF.VerificationWorkFlowTitle, '''') FROM WSVerificationWorkFlows VWF WHERE VWF.VerificationWorkFlowId = PO.pordVerificationWorkFlowId) AS ApiPordVerificationWorkFlow,
					pordExpireDateTime AS ApiPordExpireDateTime,
					pordLinkAccPreOrderId AS ApiPordLinkAccPreOrderId,
					pordLinkAccPreOrderNumber AS ApiPordLinkAccPreOrderNumber,
					UserId AS ApiUserId,
					(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = PO.UserId) AS ApiEditUser,
					RegisterDate AS ApiRegisterDate,
					FirstRegisterUserId AS ApiFirstRegisterUserId,
					(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = PO.FirstRegisterUserId) AS ApiFirstRegisterUser,
					FirstRegisterDate AS ApiFirstRegisterDate,
					/*NKR14020730- Start*/
					[pordDeliveryDate] AS [ApiPordDeliveryDate],
					[pordDeliveryTermId] AS [ApiPordDeliveryTermId],
					[pordDeliveryEndDate] AS [ApiPordDeliveryEndDate],
					[pordDeliveryEndDateTime] AS [ApiPordDeliveryEndDateTime],
					[pordDeliveryEndTime] AS [ApiPordDeliveryEndTime],
					[pordDeliveryDay] AS [ApiPordDeliveryDay],
					[pordDeliveryEndDay] AS [ApiPordDeliveryEndDay]
					/*NKR14020730- End*/
				FROM WSPreOrder PO	WHERE 1 = 1 '
		/**/
	END
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		SET @QRY = 
				'
				SELECT 
					PreOrderID AS ApiPreOrderID,
					(SELECT ISNULL(POL.pordTitle, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordTitle,
					pordNumber AS ApiPordNumber,
					pordDate AS ApiPordDate,
					pordCompanyId AS ApiPordCompanyId,
										
					(SELECT 
						ISNULL((SELECT CCT.CompanyTitle FROM CrmCompanyTitle_Lang CCT WHERE CCT.CompanyTitleID = C.cmpTitleId AND CCT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') + '' '' +/*RZ990515*/
						ISNULL((SELECT ISNULL(CL.cmpName, '''') FROM CrmCompany_Lang CL WHERE CL.CompanyID = C.CompanyID AND CL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''') 
					FROM CrmCompany C 
					WHERE C.CompanyID = PO.pordCompanyId) AS ApiPordCompany,

					pordCompanyPersonId AS ApiPordCompanyPersonId,					
					(SELECT 
						ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId] AND PT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') + '' '' +/*RZ990515*/
						ISNULL((SELECT ISNULL(CPL.prsFName, '''') + '' '' + ISNULL(CPL.prsLName, '''') FROM CrmCompanyPersons_Lang CPL WHERE CPL.CompanyPersonID = CCP.CompanyPersonID AND CPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') ,'''') 
					FROM CrmCompanyPersons CCP 
					WHERE CCP.CompanyPersonID = PO.pordCompanyPersonId) AS ApiPordCompanyPerson,
					pordProjectId AS ApiPordProjectId,
					(SELECT ISNULL(PL.prjTitle, '''') + '' '' + ISNULL(PL.prjPostFix, '''') FROM CrmProjects_Lang PL WHERE PL.ProjectID = PO.pordProjectId AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordProject,/*RZ990515*/
					(SELECT ISNULL(POL.pordSubject, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordSubject,
					pordItemCount AS ApiPordItemCount,
					pordItemsAmount AS ApiPordItemsAmount,
					pordInstallAmount AS ApiPordInstallAmount,
					pordDiscount AS ApiPordDiscount,
					pordSumAmount AS ApiPordSumAmount,
					pordTax AS ApiPordTax,
					pordTaxIndex AS ApiPordTaxIndex,
					pordCalculateTax AS ApiPordCalculateTax,
					pordTotalAmount AS ApiPordTotalAmount,
					(SELECT ISNULL(POL.pordTotalAmountStr, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordTotalAmountStr,
					pordIsVerified AS ApiPordIsVerified,
					pordVerifierId AS ApiPordVerifierId,
					(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = PO.pordVerifierId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordVerifier,
					pordVerifierRequestId AS ApiPordVerifierRequestId,
					(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = PO.pordVerifierRequestId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordVerifierRequest,
					pordVerifiedRegisterDate AS ApiPordVerifiedRegisterDate,
					pordStatusId AS ApiPordStatusId,
					(SELECT ISNULL(POSL.PreOrderStatus, '''') FROM WSPreOrderStatus_Lang POSL WHERE POSL.PreOrderStatusId = PO.pordStatusId AND POSL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordStatus,
					pordIsFixed AS ApiPordIsFixed,
					pordGuarantyId AS ApiPordGuarantyId, '
		SET @QRY = @QRY + '
					(SELECT ISNULL(GL.Guaranty, '''') FROM WSGuaranty_Lang GL WHERE GL.GuarantyID = PO.pordGuarantyId AND GL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordGuaranty,
					pordPayConditionId AS ApiPordPayConditionId,
					(SELECT ISNULL(PCL.PayCondition, '''') FROM WSPayCondition_Lang PCL WHERE PCL.PayConditionID = PO.pordPayConditionId AND PCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordPayCondition,
					pordDeliveryTimeId AS ApiPordDeliveryTimeId,
					(SELECT ISNULL(DTL.DeliveryTime, '''') FROM WSDeliveryTime_Lang DTL WHERE DTL.DeliveryTimeID = PO.pordDeliveryTimeId AND DTL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordDeliveryTimeTitle,
					pordCreditDurationId AS ApiPordCreditDurationId,
					(SELECT ISNULL(CDL.CreditDuration, '''') FROM WSCreditDuration_Lang CDL WHERE CDL.CreditDurationID = PO.pordCreditDurationId AND CDL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordCreditDuration,
					(SELECT ISNULL(POL.pordSpecialWord, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordSpecialWord,
					(SELECT ISNULL(POL.pordDescriptionI, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordDescriptionI,
					(SELECT ISNULL(POL.pordDescriptionII, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordDescriptionII,
					pordDescriptionId AS ApiPordDescriptionId,
					pordPrintFormatId AS ApiPordPrintFormatId,
					(SELECT ISNULL(PFL.Title, '''') FROM PrintFormat_Lang PFL WHERE PFL.PrintFormatID = PO.pordPrintFormatId AND PFL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordPrintFormat,
					pordRLogoId AS ApiPordRLogoId,
					(SELECT LL.LogoDescription FROM WSLogo_Lang LL WHERE LL.LogoID = PO.pordRLogoId AND LL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordRLogo,
					pordLLogoId AS ApiPordLLogoId,
					(SELECT LL.LogoDescription FROM WSLogo_Lang LL WHERE LL.LogoID = PO.pordLLogoId AND LL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordLLogo,
					(SELECT ISNULL(POL.pordSigningI, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordSigningI,
					(SELECT ISNULL(POL.pordSigningII, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordSigningII,
					(SELECT ISNULL(POL.pordSigningIII, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordSigningIII,
					pordAccountNumberI AS ApiPordAccountNumberI,
					pordAccountShabaNumberI AS ApiPordAccountShabaNumberI,
					pordAccountNumberII AS ApiPordAccountNumberII,
					pordAccountShabaNumberII AS ApiPordAccountShabaNumberII,
					(SELECT ISNULL(POL.pordAddress, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordAddress,
					pordTelephone AS ApiPordTelephone,
					pordFax AS ApiPordFax,
					pordWebSite AS ApiPordWebSite,
					pordEmail AS ApiPordEmail,
					pordSignatureId AS ApiPordSignatureId,
					pordImportDate AS ApiPordImportDate,
					FPId AS ApiFPId,'
		SET @QRY = @QRY + '
					pordDay AS ApiPordDay,
					pordTime AS ApiPordTime,
					(SELECT ISNULL(POL.pordDiscountTitle, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordDiscountTitle,
					pordDiscountPercent AS ApiPordDiscountPercent,
					pordTransportation AS ApiPordTransportation,
					pordReferUserId AS ApiPordReferUserId,
					(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = PO.pordReferUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordReferUser,
					pordRound AS ApiPordRound,
					(SELECT ISNULL(POL.pordcmpTitle, '''') FROM WSPreOrder_Lang POL WHERE POL.PreOrderID = PO.PreOrderID AND POL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordcmpTitle,
					pordDateTime AS ApiPordDateTime,
					pordImportDateTime AS ApiPordImportDateTime,
					pordDeliveryDateTime AS ApiPordDeliveryDateTime,
					pordDeliveryTime AS ApiPordDeliveryTime,
					PreOrderOprID AS ApiPreOrderOprID,
					(SELECT ISNULL(POO.PreOrderOpr, '''') FROM WSPreOrderOpr_Lang POO WHERE POO.PreOrderOprID = PO.PreOrderOprID AND POO.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPreOrderOpr,/*RZ990515*/
					pordVerificationWorkFlowId AS ApiPordVerificationWorkFlowId,
					(SELECT ISNULL(VWFL.VerificationWorkFlowTitle, '''') FROM WSVerificationWorkFlows_Lang VWFL WHERE VWFL.VerificationWorkFlowId = PO.pordVerificationWorkFlowId AND VWFL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPordVerificationWorkFlow,
					pordExpireDateTime AS ApiPordExpireDateTime,
					pordLinkAccPreOrderId AS ApiPordLinkAccPreOrderId,
					pordLinkAccPreOrderNumber AS ApiPordLinkAccPreOrderNumber,
					UserId AS ApiUserId,
					(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = PO.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiEditUser,
					RegisterDate AS ApiRegisterDate,
					FirstRegisterUserId AS ApiFirstRegisterUserId,
					(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = PO.FirstRegisterUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiFirstRegisterUser,
					FirstRegisterDate AS ApiFirstRegisterDate,
					/*NKR14020730- Start*/
					[pordDeliveryDate] AS [ApiPordDeliveryDate],
					[pordDeliveryTermId] AS [ApiPordDeliveryTermId],
					[pordDeliveryEndDate] AS [ApiPordDeliveryEndDate],
					[pordDeliveryEndDateTime] AS [ApiPordDeliveryEndDateTime],
					[pordDeliveryEndTime] AS [ApiPordDeliveryEndTime],
					[pordDeliveryDay] AS [ApiPordDeliveryDay],
					[pordDeliveryEndDay] AS [ApiPordDeliveryEndDay]
					/*NKR14020730- End*/
				FROM WSPreOrder PO  WHERE 1 = 1 '
	END


	/*======================= End Columns =======================*/
	
	/*======================= Start Conditions =======================*/

	IF (ISNULL(@PreOrderID, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND PreOrderID = ' + CAST(@PreOrderID AS NVARCHAR(50)) + ' '
	END
	IF (ISNULL(@pordNumber, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND pordNumber = ' + CAST(@pordNumber AS NVARCHAR(50)) + ' '
	END
	IF ((@FromPreOrderDate IS NOT NULL) AND (@ToPreOrderDate IS NOT NULL))
	BEGIN
		SET @QRY = @QRY + ' AND pordDateTime BETWEEN ''' + CAST(@FromPreOrderDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToPreOrderDate AS NVARCHAR(50)) + ''' '
	END
	IF ((@FromRegisterDate IS NOT NULL) AND (@ToRegisterDate IS NOT NULL))
	BEGIN
		SET @QRY = @QRY + ' AND RegisterDate BETWEEN ''' + CAST(@FromRegisterDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToRegisterDate AS NVARCHAR(50)) + ''' '
	END
	IF ((@FromFirstRegisterDate IS NOT NULL) AND (@ToFirstRegisterDate IS NOT NULL))
	BEGIN
		SET @QRY = @QRY + ' AND FirstRegisterDate BETWEEN ''' + CAST(@FromFirstRegisterDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToFirstRegisterDate AS NVARCHAR(50)) + ''' '
	END


	/*======================== End Conditions ========================*/


	SET @QRY = @QRY + ' ORDER BY pordDate, pordNumber '
	
	EXECUTE (@QRY)

	/**/
END





