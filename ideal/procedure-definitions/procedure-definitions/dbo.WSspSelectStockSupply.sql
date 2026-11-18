








/*RZ14020908*/
Create PROCEDURE [dbo].[WSspSelectStockSupply]
( 
/*
	exec WSspSelectStockSupply 
	@FDate ='14020908', 
	@TDate = '14020908', 
	@FDateTime = '2023-11-29', 
	@TDateTime = '2023-11-29', 
	@StockSupplyId = 0, 
	@stsupNumber = 0,	
	@UserId = 3,			
	@LanguageID = 1033,
	@DefaultLanguageID = 1065
	
*/
@FDate VARCHAR(10), 
@TDate VARCHAR(10), 
@FDateTime DATETIME, 
@TDateTime DATETIME, 
@StockSupplyId INT, 
@stsupNumber BIGINT,	
@UserId INT,			
@LanguageID INT = NULL,
@DefaultLanguageID INT = NULL
)
AS 
BEGIN 
/**/
/*------------------------------------------------------------------------------------*/
	DECLARE @Qry NVARCHAR(MAX) = 'SELECT ', @From NVARCHAR(MAX) = ' FROM [dbo].[WSStockSupply] ST ', @Trems NVARCHAR(MAX) = ' WHERE 1=1 '
	, @OrderBy NVARCHAR(MAX) = ' '
	/**/
	SET @Trems = @Trems + ' AND (ST.[stsupReferUserId] = ' + CAST(@UserId AS VARCHAR(50)) + '
		 OR (ST.[stsupReferUserId] <> ' + CAST(@UserId AS VARCHAR(50)) + '  AND
				(
					SELECT COUNT (*)
						FROM dbo.CrmLinkedUsers L
						WHERE L.LinkedTypeId = 32
						AND L.CrmUserId = ' + CAST(@UserId AS VARCHAR(50)) + '
						AND L.LinkedUserId = ST.[stsupReferUserId]
				) > 0
			)		
		)  ' 		
	/**/
	IF (@FDate = '-20')
	BEGIN
		/**/
		DECLARE @IndicatorTermTxt VARCHAR(MAX) 
		SELECT @IndicatorTermTxt = Txt FROM dbo.CrmsysDBTempInfo WHERE TypeId = 90 AND UserId = @UserId
		/**/
		SET @Trems = @IndicatorTermTxt
		/**/
	END
	ELSE IF (@stsupNumber > 0)
	BEGIN
	/**/
		SET @Trems = @Trems + ' AND [stsupNumber] = ' + CAST(@stsupNumber AS VARCHAR(50))
		SET @OrderBy = ' ORDER BY [stsupDateTime], [stsupNumber] '
	/**/
	END
	ELSE IF (@StockSupplyId = 0)
	BEGIN
	/**/
		SET @Trems = @Trems + ' AND CAST([stsupDateTime] AS DATE) BETWEEN CAST(''' + CAST(@FDateTime AS VARCHAR(50)) + ''' AS DATE) AND CAST(''' + CAST(@TDateTime AS VARCHAR(50)) + ''' AS DATE) '
		SET @OrderBy = ' ORDER BY [stsupDateTime], [stsupNumber] '
	/**/
	END
	ELSE IF (@StockSupplyId > 0)
	BEGIN
	/**/
		SET @Trems = @Trems + ' AND [StockSupplyId] = ' + CAST(@StockSupplyId AS VARCHAR(50))
		SET @OrderBy = ' ORDER BY [stsupDateTime], [stsupNumber] '
	/**/
	END	
	/*------------------------------------------------------------------------------------*/
	IF(@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
	/**/
		SET @Qry = @Qry + ' 
			 [StockSupplyId]
			,[StockSupplyOprId]
			,'''' [StockSupplyOpr]
			,[stsupReferUserId]
			,(SELECT TOP(1) ISNULL(FName +'' '', '''') + ISNULL(LName,'''') FROM [dbo].[Users] U WHERE U.UserId = ST.[stsupReferUserId]) [stsupReferUser]
			,[stsupNumber]
			,[stsupDateTime]
			,[stsupDate]
			,[stsupCompanyId]
			,[stsupCompanyPersonId]
			,[stsupProjectId] 
			'

		SET @Qry = @Qry + ' 
			,(SELECT TOP(1) 
				ISNULL((SELECT TOP(1) CompanyTitle FROM [dbo].[CrmCompanyTitle] CT WHERE CT.CompanyTitleID = C.cmpTitleId) + '' '','''') +
				ISNULL(C.cmpName,'''')
			  FROM [dbo].[CrmCompany] C
			  WHERE C.CompanyID = [stsupCompanyId]) [CompanyName]		
			,(SELECT TOP(1) 
				ISNULL((SELECT TOP(1) PersonTitle FROM [dbo].[CRMPersonTitle] PT WHERE PT.PersonTitleID = CP.prsTitleId) + '' '','''') +
				ISNULL(CP.prsFName + '' '','''') + ISNULL(Cp.prsLName,'''')
			  FROM [dbo].[CrmCompanyPersons] CP
			  WHERE CP.CompanyPersonID = [stsupCompanyPersonId]) [CompanyPerson]
			,(SELECT TOP(1) 				
				ISNULL(PRJ.prjTitle,'''') + ISNULL('' '' + PRJ.prjPostFix,'''') +
				+ ISNULL('' '' + REPLACE(((FORMAT(prjRemindDateTime, ''yyyy/MM/dd'', ISNULL((SELECT TOP (1) [LanguageCollation] FROM [dbo].[Languages] L WHERE L.[LanguageID] = PRJ.[LanguageID]),''fa-IR'')))),''.'',''/'') ,'''')
			  FROM [dbo].[CrmProjects] PRJ
			  WHERE PRJ.ProjectId = [stsupProjectId]) [ProjectTitle]
			,(SELECT TOP(1) prsMobile FROM [dbo].[CrmCompanyPersons] CP WHERE CP.CompanyPersonID = [stsupCompanyPersonId]) [CompanyPersonMobile]
			,(SELECT TOP(1) prsEmail FROM [dbo].[CrmCompanyPersons] CP WHERE CP.CompanyPersonID = [stsupCompanyPersonId]) [CompanyPersonEmail]
			,(SELECT TOP(1) prsEmailII FROM [dbo].[CrmCompanyPersons] CP WHERE CP.CompanyPersonID = [stsupCompanyPersonId]) [CompanyPersonEmailII]
			'

		SET @Qry = @Qry + ' 
			,[stsupIsFixed]
			,[stsupIsCanceled]
			,'''' [stsupIsCanceledTitle]
			,[stsupIsVerified]
			,[stsupVerifierRequestId]
			,(SELECT TOP(1) ISNULL(FName +'' '', '''') + ISNULL(LName,'''') FROM [dbo].[Users] U WHERE U.UserId = ST.[stsupVerifierRequestId]) [stsupVerifierRequest]
			,[stsupVerifierId]
			,(SELECT TOP(1) ISNULL(FName +'' '', '''') + ISNULL(LName,'''') FROM [dbo].[Users] U WHERE U.UserId = ST.[stsupVerifierId]) [stsupVerifier]
			,[stsupVerifiedRegisterDate]
			,[stsupVerifiedRegisterDatePersian]
			,[stsupVerificationWorkFlowId] 
			'
			
		SET @Qry = @Qry + ' 
			,[stsupPrintFormatId]
			,(SELECT TOP(1) PF.Title FROM [dbo].[PrintFormat] PF WHERE PF.PrintFormatID = ST.[stsupPrintFormatId]) [stsupPrintFormat]
			,[stsupNote]
			,[stsupItemCount]
			,[stsupItemsQty]
			,[stsupPreOrderId] 
			,[FirstRegisterUserId]
			,(SELECT TOP(1) ISNULL(FName +'' '', '''') + ISNULL(LName,'''') FROM [dbo].[Users] U WHERE U.UserId = ST.[FirstRegisterUserId]) [FirstRegisterUser]
			,[FirstRegisterDate]
			,[FirstRegisterDatePersian]
			,[UserId]
			,(SELECT TOP(1) ISNULL(FName +'' '', '''') + ISNULL(LName,'''') FROM [dbo].[Users] U WHERE U.UserId = ST.[UserId]) [EditUser]
			,[FPId]
			,[Month1]
			,[RegisterDate]
			,[RegisterDatePersian]
			,[GUId]
			,[AppType]
			,[LanguageID] 
			'					
	/**/
	END
	ELSE IF(@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
	/**/
		SET @Qry = @Qry + ' 
			 [StockSupplyId]
			,[StockSupplyOprId]
			,'''' [StockSupplyOpr]
			,[stsupReferUserId]
			,(SELECT TOP(1) ISNULL(FName +'' '', '''') + ISNULL(LName,'''') FROM [dbo].[Users_Lang] U WHERE U.UserId = ST.[stsupReferUserId] AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') [stsupReferUser]
			,[stsupNumber]
			,[stsupDateTime]
			,[stsupDate]
			,[stsupCompanyId]
			,[stsupCompanyPersonId]
			,[stsupProjectId] 
			'

		SET @Qry = @Qry + ' 
			,(SELECT TOP(1) 
				ISNULL((SELECT TOP(1) CompanyTitle FROM [dbo].[CrmCompanyTitle_Lang] CT WHERE CT.CompanyTitleID = C.cmpTitleId AND CT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') + '' '','''') +
				ISNULL((SELECT TOP(1) CLN.CmpName FROM [dbo].[CrmCompany_Lang] CLN WHERE CLN.CompanyID = C.CompanyID and CLN.LanguageID =' + CAST(@LanguageID AS NVARCHAR(50)) +'),'''')
			  FROM [dbo].[CrmCompany] C
			  WHERE C.CompanyID = [stsupCompanyId]) [CompanyName]		
			,(SELECT TOP(1) 
				ISNULL((SELECT TOP(1) PersonTitle FROM [dbo].[CRMPersonTitle_Lang] PT WHERE PT.PersonTitleID = CP.prsTitleId AND PT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') + '' '','''') +
				ISNULL((SELECT TOP(1) ISNULL(CPLN.prsFName + '' '','''') + ISNULL(CPLN.prsLName,'''') FROM [dbo].[CrmCompanyPersons_Lang] CPLN WHERE CPLN.CompanyPersonID = CP.CompanyPersonID and CPLN.LanguageID =' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''')				
			  FROM [dbo].[CrmCompanyPersons] CP
			  WHERE CP.CompanyPersonID = [stsupCompanyPersonId]) [CompanyPerson]
			,(SELECT TOP(1) 	
				ISNULL((SELECT TOP(1) ISNULL(PRJLN.prjTitle,'''') + ISNULL('' '' + PRJLN.prjPostFix,'''') FROM [dbo].[CrmProjects_Lang] PRJLN WHERE PRJLN.ProjectId = PRJ.ProjectId AND PRJLN.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') +			
				+ ISNULL('' '' + REPLACE(((FORMAT(prjRemindDateTime, ''yyyy/MM/dd'', ISNULL((SELECT TOP (1) [LanguageCollation] FROM [dbo].[Languages] L WHERE L.[LanguageID] = ' + CAST(@LanguageID AS NVARCHAR(50)) +'),''en-US'')))),''.'',''/'') ,'''')
			  FROM [dbo].[CrmProjects] PRJ
			  WHERE PRJ.ProjectId = [stsupProjectId]) [ProjectTitle]
			,(SELECT TOP(1) prsMobile FROM [dbo].[CrmCompanyPersons] CP WHERE CP.CompanyPersonID = [stsupCompanyPersonId]) [CompanyPersonMobile]
			,(SELECT TOP(1) prsEmail FROM [dbo].[CrmCompanyPersons] CP WHERE CP.CompanyPersonID = [stsupCompanyPersonId]) [CompanyPersonEmail]
			,(SELECT TOP(1) prsEmailII FROM [dbo].[CrmCompanyPersons] CP WHERE CP.CompanyPersonID = [stsupCompanyPersonId]) [CompanyPersonEmailII]
			'

		SET @Qry = @Qry + ' 
			,[stsupIsFixed]
			,[stsupIsCanceled]
			,'''' [stsupIsCanceledTitle]
			,[stsupIsVerified]
			,[stsupVerifierRequestId]
			,(SELECT TOP(1) ISNULL(FName +'' '', '''') + ISNULL(LName,'''') FROM [dbo].[Users_Lang] U WHERE U.UserId = ST.[stsupVerifierRequestId] AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') [stsupVerifierRequest]
			,[stsupVerifierId]
			,(SELECT TOP(1) ISNULL(FName +'' '', '''') + ISNULL(LName,'''') FROM [dbo].[Users_Lang] U WHERE U.UserId = ST.[stsupVerifierId] AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') [stsupVerifier]
			,[stsupVerifiedRegisterDate]
			,[stsupVerifiedRegisterDatePersian]
			,[stsupVerificationWorkFlowId] 
			'
			
		SET @Qry = @Qry + ' 
			,[stsupPrintFormatId]
			,(SELECT TOP(1) PF.Title FROM [dbo].[PrintFormat_Lang] PF WHERE PF.PrintFormatID = ST.[stsupPrintFormatId] AND PF.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') [stsupPrintFormat]			
			,(SELECT TOP(1) STLN.[stsupNote] FROM [dbo].[WSStockSupply_Lang] STLN WHERE STLN.[StockSupplyId] = ST.[StockSupplyId] AND STLN.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') [stsupNote]
			,[stsupItemCount]
			,[stsupItemsQty]
			,[stsupPreOrderId] 
			,[FirstRegisterUserId]
			,(SELECT TOP(1) ISNULL(FName +'' '', '''') + ISNULL(LName,'''') FROM [dbo].[Users_Lang] U WHERE U.UserId = ST.[FirstRegisterUserId] AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') [FirstRegisterUser]
			,[FirstRegisterDate]
			,[FirstRegisterDatePersian]
			,[UserId]
			,(SELECT TOP(1) ISNULL(FName +'' '', '''') + ISNULL(LName,'''') FROM [dbo].[Users_Lang] U WHERE U.UserId = ST.[UserId] AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') [EditUser]
			,[FPId]
			,[Month1]
			,[RegisterDate]
			,[RegisterDatePersian]
			,[GUId]
			,[AppType]
			,[LanguageID] 
			'					
	/**/
	END
	/*------------------------------------------------------------------------------------*/
	/*SELECT @Qry + @From + @Trems + @OrderBy*/
	EXEC (@Qry + @From + @Trems + @OrderBy)
/*------------------------------------------------------------------------------------*/
/**/
END







