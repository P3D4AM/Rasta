






/*NKR990514*/
/*RZ990519- Modify this sp*/
Create PROCEDURE [dbo].[ApispSelectDoc]
(
	/*
		EXEC ApispSelectDoc null, null, null, null , null, null, null, null, null, 1033, 1065				
	*/
	@DocID INT = NULL,
	@DocNumber INT = NULL,
	@OprId INT = NULL,
	@FromDocDate DATETIME = NULL,
	@ToDocDate DATETIME = NULL,
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
		SET @QRY = '
					SELECT 
						DocID AS ApiDocID,
						OprId AS ApiOprId,
						(SELECT ISNULL(DO.Name, '''') FROM WSDocOpr DO WHERE DO.DocOprID = D.OprId) AS ApiOpr,
						DocNumber AS ApiDocNumber,
						DocDate AS ApiDocDate,
						SenderId AS ApiSenderId,
						SenderName AS ApiSenderName,
						FactorNumber AS ApiFactorNumber,
						Description AS ApiDescription,
						IsFix AS ApiIsFix,
						WHId AS ApiWHId,
						(SELECT ISNULL(WH.WrhsName, '''') FROM WsWareHouse WH WHERE WH.WareHouseID = D.WHId) AS ApiWH,
						FPId AS ApiFPId,
						OrderId AS ApiOrderId,
						BuyOrderId AS ApiBuyOrderId,						
						SendAddress AS ApiSendAddress,
						DriverName AS ApiDriverName,
						DriverTel AS ApiDriverTel,
						FreightName AS ApiFreightName,
						BijakNumber AS ApiBijakNumber,
						CarNumber AS ApiCarNumber,
						DocDateTime AS ApiDocDateTime,
						WHIdI AS ApiWHIdI,
						(SELECT ISNULL(WH.WrhsName, '''') FROM WsWareHouse WH WHERE WH.WareHouseID = D.WHIdI) AS ApiWHI, '
		SET @QRY = @QRY + '
						CompanyId AS ApiCompanyId,
						/*RZ990519- Modify this sp*/
						(SELECT 
							ISNULL((SELECT CCT.CompanyTitle FROM CrmCompanyTitle CCT WHERE CCT.CompanyTitleID = C.cmpTitleId),'''') + '' '' +
							ISNULL(C.cmpName, '''') 
						FROM CrmCompany C 
						WHERE C.CompanyID = D.CompanyId) AS ApiCompany,						
						CompanyPersonId AS ApiCompanyPersonId,						
						(SELECT 
							ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId]),'''') + '' '' +
							ISNULL(CCP.prsFName, '''') + '' '' + ISNULL(CCP.prsLName, '''') 
						FROM CrmCompanyPersons CCP 
						WHERE CCP.CompanyPersonID = D.CompanyPersonId) AS ApiCompanyPerson,
						/*RZ990519- End*/
						ProjectId AS ApiProjectId,
						(SELECT ISNULL(P.prjTitle, '''') + '' '' + ISNULL(P.prjPostFix, '''') FROM CrmProjects P WHERE P.ProjectID = D.ProjectId) AS ApiProject,
						cmpTitle AS ApicmpTitle,												
						UserId AS ApiUserId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = D.UserId) AS ApiEditUser,
						RegisterDate AS ApiRegisterDate,
						FirstRegisterUserId AS ApiFirstRegisterUserId,
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = D.FirstRegisterUserId) AS ApiFirstRegisterUser,	
						FirstRegisterDate AS ApiFirstRegisterDate						
						,[DocLinkAccCodeId] AS ApiDocLinkAccCodeId
						,[DocLinkAccCode] AS ApiDocLinkAccCode
						,[DocLinkAccDocId] AS ApiDocLinkAccDocId
						,[DocLinkAccDocNumber] AS ApiDocLinkAccDocNumber
						,[DocLinkAccVoucherId] AS ApiDocLinkAccVoucherId
						,[DocLinkAccVoucherNumber] AS ApiDocLinkAccVoucherNumber
					FROM WSDoc D WHERE 1 = 1 '
	END
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		SET @QRY = '
					SELECT 
						DocID AS ApiDocID,
						OprId AS ApiOprId,
						(SELECT ISNULL(DOL.Name, '''') FROM WSDocOpr_Lang DOL WHERE DOL.DocOprID = D.OprId AND DOL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiOpr,
						DocNumber AS ApiDocNumber,
						DocDate AS ApiDocDate,
						SenderId AS ApiSenderId,	
						(SELECT ISNULL(DL.SenderName, '''') FROM WSDoc_Lang DL WHERE DL.DocID = D.DocID AND DL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiSenderName,
						FactorNumber AS ApiFactorNumber,
						(SELECT ISNULL(DL.Description, '''') FROM WSDoc_Lang DL WHERE DL.DocID = D.DocID AND DL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiDescription,
						IsFix AS ApiIsFix,
						WHId AS ApiWHId,
						(SELECT ISNULL(WHL.WrhsName, '''') FROM WsWareHouse_Lang WHL WHERE WHL.WareHouseID = D.WHId AND WHL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiWH,
						FPId AS ApiFPId,
						OrderId AS ApiOrderId,
						BuyOrderId AS ApiBuyOrderId,						
						(SELECT ISNULL(DL.SendAddress, '''') FROM WSDoc_Lang DL WHERE DL.DocID = D.DocID AND DL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiSendAddress,
						(SELECT ISNULL(DL.DriverName, '''') FROM WSDoc_Lang DL WHERE DL.DocID = D.DocID AND DL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiDriverName,
						DriverTel AS ApiDriverTel,	
						(SELECT ISNULL(DL.FreightName, '''') FROM WSDoc_Lang DL WHERE DL.DocID = D.DocID AND DL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiFreightName,
						BijakNumber AS ApiBijakNumber,
						CarNumber AS ApiCarNumber,
						DocDateTime AS ApiDocDateTime,'
		SET @QRY = @QRY + '
						WHIdI AS ApiWHIdI,
						(SELECT ISNULL(WHL.WrhsName, '''') FROM WsWareHouse_Lang WHL WHERE WHL.WareHouseID = D.WHIdI AND WHL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' ) AS ApiWHI,
						CompanyId AS ApiCompanyId,						
						/*RZ990519- Modify this sp*/
						(SELECT 
							ISNULL((SELECT CCT.CompanyTitle FROM CrmCompanyTitle_Lang CCT WHERE CCT.CompanyTitleID = C.cmpTitleId AND CCT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') + '' '' +
							ISNULL((SELECT ISNULL(CCL.cmpName, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = C.CompanyId AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''') 
						FROM CrmCompany C 
						WHERE C.CompanyID = D.CompanyId) AS ApiCompany,						
						CompanyPersonId AS ApiCompanyPersonId,						
						(SELECT 
							ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle_Lang] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId] AND PT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') + '' '' +
							ISNULL((SELECT ISNULL(CCP.prsFName, '''') + '' '' + ISNULL(CCP.prsLName, '''') FROM CrmCompanyPersons_Lang CPL WHERE CPL.CompanyPersonID = CCP.CompanyPersonId AND CPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''')														 
						FROM CrmCompanyPersons CCP 
						WHERE CCP.CompanyPersonID = D.CompanyPersonId) AS ApiCompanyPerson,
						/*RZ990519- End*/
						ProjectId AS ApiProjectId,
						(SELECT ISNULL(PL.prjTitle, '''') + '' '' + ISNULL(PL.prjPostFix, '''') FROM CrmProjects_Lang PL WHERE PL.ProjectID = D.ProjectId AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiProject,
						(SELECT ISNULL(DL.cmpTitle, '''') FROM WSDoc_Lang DL WHERE DL.DocID = D.DocID AND DL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApicmpTitle,												
						UserId AS ApiUserId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = D.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiEditUser,
						RegisterDate AS ApiRegisterDate,
						FirstRegisterUserId AS ApiFirstRegisterUserId,
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = D.FirstRegisterUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiFirstRegisterUser,	
						FirstRegisterDate AS ApiFirstRegisterDate
						,[DocLinkAccCodeId] AS ApiDocLinkAccCodeId
						,[DocLinkAccCode] AS ApiDocLinkAccCode
						,[DocLinkAccDocId] AS ApiDocLinkAccDocId
						,[DocLinkAccDocNumber] AS ApiDocLinkAccDocNumber
						,[DocLinkAccVoucherId] AS ApiDocLinkAccVoucherId
						,[DocLinkAccVoucherNumber] AS ApiDocLinkAccVoucherNumber
					FROM WSDoc D WHERE 1 = 1 '
	END
	

	IF (ISNULL(@DocID, 0) > 0)
	BEGIN	
		SET @QRY = @QRY + ' AND DocID = ' + CAST(@DocID AS NVARCHAR(50))
	END
	IF (ISNULL(@DocNumber, 0) > 0)
	BEGIN	
		SET @QRY = @QRY + ' AND DocNumber = ' + CAST(@DocNumber AS NVARCHAR(50))
	END
	IF (ISNULL(@OprId, 0) > 0)
	BEGIN	
		SET @QRY = @QRY + ' AND OprId = ' + CAST(@OprId AS NVARCHAR(50))
	END
	IF (@FromDocDate IS NOT NULL AND @ToDocDate IS NOT NULL)
	BEGIN	
		SET @QRY = @QRY + ' AND DocDateTime BETWEEN ''' + CAST(@FromDocDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToDocDate AS NVARCHAR(50)) + ''''
	END
	IF (@FromRegisterDate IS NOT NULL AND @ToRegisterDate IS NOT NULL)
	BEGIN	
		SET @QRY = @QRY + ' AND RegisterDate BETWEEN ''' + CAST(@FromRegisterDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToRegisterDate AS NVARCHAR(50)) + ''''
	END
	IF (@FromFirstRegisterDate IS NOT NULL AND @ToFirstRegisterDate IS NOT NULL)
	BEGIN	
		SET @QRY = @QRY + ' AND FirstRegisterDate BETWEEN ''' + CAST(@FromFirstRegisterDate AS NVARCHAR(50)) + ''' AND ''' + CAST(@ToFirstRegisterDate AS NVARCHAR(50)) + ''''
	END

	EXECUTE (@QRY + N' ORDER BY DocDate, DocNumber') /*RZ990519- Modify this sp*/
	
	/**/
END





