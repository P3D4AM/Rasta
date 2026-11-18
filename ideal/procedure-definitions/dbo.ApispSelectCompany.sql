





/*NKR990506*/
/*RZ990511- Modify this sp*/
/*RZ14010519- Add fields*/
Create PROCEDURE [dbo].[ApispSelectCompany]
(
	/*	
		EXEC [ApispSelectCompany] 6156,NULL , NULL ,NULL,NULL ,NULL ,NULL ,1033, 1065 	
	*/
	
	@CompanyId INT,
	@CmpCode NVARCHAR(500) = NULL ,
	@CmpNumber INT = NULL ,
	@FromRegisterDate DATETIME = NULL ,
	@ToRegisterDate DATETIME = NULL ,
	@FromFirstRegisterDate DATETIME = NULL ,
	@ToFirstRegisterDate DATETIME = NULL ,
	@LanguageID INT = NULL,
	@DefaultLanguageID INT = NULL 
)
AS
BEGIN
	/**/
	/*RZ990511- Add ApiCmp to all field name in this sp*/
	DECLARE @QRY NVARCHAR(MAX) = ''

	IF(@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
		/**/
		SET @QRY = ''

		SET @QRY = 'SELECT
						CompanyID AS [ApiCompanyID],
						ImportDate AS [ApiCmpImportDate],
						cmpNumber AS [ApiCmpNumber],
						cmpName AS [ApiCmpName],
						cmpNameEng AS [ApiCmpNameEng],
						cmpTitleId AS [ApiCmpTitleId],
						(SELECT ISNULL(CCT.CompanyTitle, '''') FROM CrmCompanyTitle CCT WHERE CCT.CompanyTitleID = CC.cmpTitleId) AS [ApiCmpTitle],
						(ISNULL((SELECT ISNULL(CCT.CompanyTitle, '''') FROM CrmCompanyTitle CCT WHERE CCT.CompanyTitleID = CC.cmpTitleId),'''') + '' '' +
						 ISNULL(CC.cmpName, '''')) AS ApiCompanyName,
						cmpFame AS [ApiCmpFame],
						cmpActivityType AS [ApiCmpActivityType],
						cmpGroupId AS [ApiCmpGroupId],
						(SELECT ISNULL(CCG.GroupName, '''') FROM CrmCompanyGroups CCG WHERE CCG.CompanyGroupID = CC.cmpGroupId) AS [ApiCmpGroup],
						cmpSubGroupId AS [ApiCmpSubGroupId],
						(SELECT ISNULL(CCSG.SubGroupName, '''') FROM CrmCompanySubGroups CCSG WHERE CCSG.CompanySubGroupID = CC.cmpSubGroupId) AS [ApiCmpSubGroup],
						cmpGroupIdII AS [ApiCmpGroupIdII],
						(SELECT ISNULL(CCG.GroupIIName, '''') FROM CrmCompanyGroupsII CCG WHERE CCG.CompanyGroupIIID = CC.cmpGroupIdII) AS [ApiCmpGroupII],
						cmpGroupIdIII AS [ApiCmpGroupIdIII],
						(SELECT ISNULL(CCG.GroupIIIName, '''') FROM CrmCompanyGroupsIII CCG WHERE CCG.CompanyGroupIIIID = CC.cmpGroupIdIII) AS [ApiCmpGroupIII],
						cmpGroupIdIV AS [ApiCmpGroupIdIV],
						(SELECT ISNULL(CCG.GroupIVName, '''') FROM CrmCompanyGroupsIV CCG WHERE CCG.CompanyGroupIVID = CC.cmpGroupIdIV) AS [ApiCmpGroupIV],
						cmpTypeId AS [ApiCmpTypeId],
						(SELECT ISNULL(CCT.CompanyTypeName, '''') FROM CrmCompanyType CCT WHERE CCT.CompanyTypeID = CC.cmpTypeId) AS [ApiCmpType],
						cmpPresentationId AS [ApiCmpPresentationId],
						(SELECT ISNULL(CCP.Presentation, '''') FROM CrmCompanyPresentation CCP WHERE CCP.CompanyPresentationID = CC.cmpPresentationId) AS [ApiCmpPresentation],
						cmpPreTel AS [ApiCmpPreTel],
						cmpTel AS [ApiCmpTel],
						cmpTelUpTo AS [ApiCmpTelUpTo],
						cmpTelDesc AS [ApiCmpTelDesc],
						cmpPreTelII AS [ApiCmpPreTelII],
						cmpTelII AS [ApiCmpTelII],
						cmpTelUpToII AS [ApiCmpTelUpToII],
						cmpTelIIDesc AS [ApiCmpTelIIDesc],
						cmpMobile AS [ApiCmpMobile],
						cmpFax AS [ApiCmpFax],
						cmpFaxDesc AS [ApiCmpFaxDesc],
						cmpCountryId AS [ApiCmpCountryId],'

		/*RZ14010519- Add fields*/
		SET @QRY = @QRY + '  
			[cmpNameOfficial] AS [ApiCmpNameOfficial],			
			[cmpCampaignIds] AS [ApiCmpCampaignIds],
			(SELECT (STUFF((SELECT '','' + ISNULL(Camp.[CampaignName], '''') 
			FROM  [dbo].[CrmCompanyCampaign] Camp
			WHERE Camp.[CompanyCampaignId] IN((SELECT CAST([value] AS INT) FROM STRING_SPLIT(cmpCampaignIds, '','') WHERE CAST([value] AS INT) <> 0)) 			
			FOR XML PATH(''''), TYPE).value(N''(./text())[1]'', N''NVARCHAR(MAX)''), 1, 1, ''''))) AS [ApiCmpCampaignNames],
		 '
		/*RZ14010519- End*/
		SET @QRY = @QRY +
					' (SELECT ISNULL(C.Country, '''') FROM Country C WHERE C.CountryID = CC.cmpCountryId) AS [ApiCmpCountry],
						cmpProvinceId AS [ApiCmpProvinceId],
						(SELECT ISNULL(P.Province, '''') FROM Province P WHERE P.ProvinceID = CC.cmpProvinceId) AS [ApiCmpProvince],
						cmpCityId AS [ApiCmpCityId],
						(SELECT ISNULL(C.City, '''') FROM City C WHERE C.CityID = CC.cmpCityId) AS [ApiCmpCity],
						cmpAddress AS [ApiCmpAddress],
						cmpAddressDesc AS [ApiCmpAddressDesc],
						cmpZipCode AS [ApiCmpZipCode],
						cmpPostBox AS [ApiCmpPostBox],
						cmpWebSite AS [ApiCmpWebSite],
						cmpEmail AS [ApiCmpEmail] ,
						cmpInteresting AS [ApiCmpInteresting],
						cmpSpecialPoint AS [ApiCmpSpecialPoint],
						cmpDescription AS [ApiCmpDescription],
						cmpUserName AS [ApiCmpUserName],
						cmpPassword AS [ApiCmpPassword],
						RegisterDate AS [ApiCmpRegisterDate],						
						cmpRegistrationNumber AS [ApiCmpRegistrationNumber],
						cmpEconomicCode AS [ApiCmpEconomicCode],
						cmpNationalCode AS [ApiCmpNationalCode],
						cmpBuyLimit AS [ApiCmpBuyLimit],
						cmpAccountNumber AS [ApiCmpAccountNumber],
						cmpAccInquiry AS [ApiCmpAccInquiry],
						cmpFreight AS [ApiCmpFreight],
						cmpInquiry AS [ApiCmpInquiry],
						cmpReferUserId AS [ApiCmpReferUserId],
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = CC.cmpReferUserId) AS [ApiCmpReferUser],
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = CC.UserId) AS [ApiEditUser],
						FirstRegisterDate AS [ApiFirstRegisterDate],
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = CC.FirstRegisterUserId) AS [ApiFirstRegisterUser],						
						cmpSpecialWordForCI AS [ApiCmpSpecialWordForCI],
						cmpCode AS [ApiCmpCode],
						cmpEffectiveDatePersian AS [ApiCmpEffectiveDatePersian],
						cmpEffectiveDateTime AS [ApiCmpEffectiveDateTime],
						ImportDateTime AS [ApiCmpImportDateTime],
						cmpCoordinateLatitude AS [ApiCmpCoordinateLatitude],
						cmpCoordinateLongitude AS [ApiCmpCoordinateLongitude],
						cmpCoordinateLastDate AS [ApiCmpCoordinateLastDate],
						cmpCoordinateLastDatePersian AS [ApiCmpCoordinateLastDatePersian],
						cmpCoordinateZoomLevel AS [ApiCmpCoordinateZoomLevel],
						cmpCoordinateLastUserId AS [ApiCmpCoordinateLastUserId],
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = CC.cmpCoordinateLastUserId) AS [ApiCmpCoordinateLastUser],
						cmpIsDraft AS [ApiCmpIsDraft],
						cmpKind AS [ApiCmpKind],
						cmpMainPersonId AS [ApiCmpMainPersonId],
						(SELECT 
								ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId]),'''') + '' ''+ 	/*RZ990511- Add prsTitle*/
								ISNULL(CCP.prsFName, '''') + '' '' + ISNULL(CCP.prsLName, '''') 
						FROM CrmCompanyPersons CCP 
						WHERE CCP.CompanyPersonID = CC.cmpMainPersonId) AS [ApiCmpMainPerson],
						[UserId] AS [ApiUserId],
						[FirstRegisterUserId] AS [ApiFirstRegisterUserId] 
					FROM CrmCompany CC
					WHERE 1 = 1 '		
		/**/
	END 
	ELSE IF(@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		/**/

		SET @QRY = ''

		SET @QRY = '
					SELECT
						CompanyID AS [ApiCompanyID],
						ImportDate AS [ApiCmpImportDate],
						cmpNumber AS [ApiCmpNumber],
						(SELECT ISNULL(CCL.cmpName, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpName],
						cmpNameEng AS [ApiCmpNameEng],
						cmpTitleId AS [ApiCmpTitleId],
						(SELECT ISNULL(CCTL.CompanyTitle, '''') FROM CrmCompanyTitle_Lang CCTL WHERE CCTL.CompanyTitleID = CC.cmpTitleId AND CCTL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpTitle],
						((SELECT ISNULL(CCTL.CompanyTitle, '''') FROM CrmCompanyTitle_Lang CCTL WHERE CCTL.CompanyTitleID = CC.cmpTitleId AND CCTL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') + '' '' + 
						 (SELECT ISNULL(CCL.cmpName, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ')) AS [ApiCompanyName],
						(SELECT ISNULL(CCL.cmpFame, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpFame],
						(SELECT ISNULL(CCL.cmpActivityType, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpActivityType],
						cmpGroupId AS [ApiCmpGroupId],
						(SELECT ISNULL(CCGL.GroupName, '''') FROM CrmCompanyGroups_Lang CCGL WHERE CCGL.CompanyGroupID = CC.cmpGroupId AND CCGL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpGroup],
						cmpSubGroupId AS [ApiCmpSubGroupId],
						(SELECT ISNULL(CCSGL.SubGroupName, '''') FROM CrmCompanySubGroups_Lang CCSGL WHERE CCSGL.CompanySubGroupID = CC.cmpSubGroupId AND CCSGL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpSubGroup],
						cmpGroupIdII AS [ApiCmpGroupIdII],
						(SELECT ISNULL(CCGL.GroupIIName, '''') FROM CrmCompanyGroupsII_Lang CCGL WHERE CCGL.CompanyGroupIIID = CC.cmpGroupIdII AND CCGL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpGroupII],
						cmpGroupIdIII AS [ApiCmpGroupIdIII],
						(SELECT ISNULL(CCGL.GroupIIIName, '''') FROM CrmCompanyGroupsIII_Lang CCGL WHERE CCGL.CompanyGroupIIIID = CC.cmpGroupIdIII AND CCGL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpGroupIII],
						cmpGroupIdIV AS [ApiCmpGroupIdIV],
						(SELECT ISNULL(CCGL.GroupIVName, '''') FROM CrmCompanyGroupsIV_Lang CCGL WHERE CCGL.CompanyGroupIVID = CC.cmpGroupIdIV AND CCGL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpGroupIV],
						cmpTypeId AS [ApiCmpTypeId],
						(SELECT ISNULL(CCTL.CompanyTypeName, '''') FROM CrmCompanyType_Lang CCTL WHERE CCTL.CompanyTypeID = CC.cmpTypeId AND CCTL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpType],
						cmpPresentationId AS [ApiCmpPresentationId],
						(SELECT ISNULL(CCPL.Presentation, '''') FROM CrmCompanyPresentation_Lang CCPL WHERE CCPL.CompanyPresentationID = CC.cmpPresentationId AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpPresentation],
						cmpPreTel AS [ApiCmpPreTel],
						cmpTel AS [ApiCmpTel],
						cmpTelUpTo AS [ApiCmpTelUpTo],
						(SELECT ISNULL(cmpTelDesc, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpTelDesc],
						cmpPreTelII AS [ApiCmpPreTelII],
						cmpTelII AS [ApiCmpTelII],
						cmpTelUpToII AS [ApiCmpTelUpToII],
						(SELECT ISNULL(cmpTelIIDesc, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpTelIIDesc],
						cmpMobile AS [ApiCmpMobile],
						cmpFax AS [ApiCmpFax],
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = CC.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiEditUser],'
		/*RZ14010519- Add fields*/
		SET @QRY = @QRY + '  
			(SELECT ISNULL(CCL.cmpNameOfficial, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpNameOfficial],			
			[cmpCampaignIds] AS [ApiCmpCampaignIds],			
			(SELECT (STUFF((SELECT '','' + ISNULL(Camp.[CampaignName], '''') 
			FROM  [dbo].[CrmCompanyCampaign_Lang] Camp
			WHERE Camp.[CompanyCampaignId] IN((SELECT CAST([value] AS INT) FROM STRING_SPLIT(cmpCampaignIds, '','') WHERE CAST([value] AS INT) <> 0)) 	
			AND Camp.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50))  + ' 
			FOR XML PATH(''''), TYPE).value(N''(./text())[1]'', N''NVARCHAR(MAX)''), 1, 1, ''''))) AS [ApiCmpCampaignNames],
		 '
		/*RZ14010519- End*/
		SET @QRY = @QRY + '
							FirstRegisterDate AS [ApiFirstRegisterDate],
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users_Lang U WHERE U.UserId = CC.FirstRegisterUserId AND U.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiFirstRegisterUser],	
							(SELECT ISNULL(cmpFaxDesc, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpFaxDesc],
							cmpCountryId AS [ApiCmpCountryId],
							(SELECT ISNULL(CL.Country, '''') FROM Country_Lang CL WHERE CL.CountryID = CC.cmpCountryId AND CL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpCountry],
							cmpProvinceId AS [ApiCmpProvinceId],
							(SELECT ISNULL(PL.Province, '''') FROM Province_Lang PL WHERE PL.ProvinceID = CC.cmpProvinceId AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpProvince],
							cmpCityId AS [ApiCmpCityId],
							(SELECT ISNULL(CL.City, '''') FROM City_Lang CL WHERE CL.CityID = CC.cmpCityId AND CL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpCity],
							(SELECT ISNULL(cmpAddress, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpAddress],
							(SELECT ISNULL(cmpAddressDesc, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpAddressDesc],
							cmpZipCode AS [ApiCmpZipCode],
							cmpPostBox AS [ApiCmpPostBox],
							cmpWebSite AS [ApiCmpWebSite],
							cmpEmail AS [ApiCmpEmail],
							(SELECT ISNULL(cmpInteresting, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpInteresting],
							(SELECT ISNULL(cmpSpecialPoint, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpSpecialPoint],
							(SELECT ISNULL(cmpDescription, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS  [ApiCmpDescription],
							cmpUserName AS [ApiCmpUserName],
							cmpPassword AS [ApiCmpPassword],
							RegisterDate AS [ApiCmpRegisterDate],							
							cmpRegistrationNumber AS [ApiCmpRegistrationNumber],
							cmpEconomicCode AS [ApiCmpEconomicCode],
							cmpNationalCode AS [ApiCmpNationalCode],
							cmpBuyLimit AS [ApiCmpBuyLimit],
							cmpAccountNumber AS [ApiCmpAccountNumber],
							cmpAccInquiry AS [ApiCmpAccInquiry],
							cmpFreight AS [ApiCmpFreight],
							(SELECT ISNULL(cmpInquiry, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpInquiry],
							cmpReferUserId AS [ApiCmpReferUserId], 
							(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = CC.cmpReferUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpReferUser],							
							(SELECT ISNULL(cmpSpecialWordForCI, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CC.CompanyID AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpSpecialWordForCI],
							cmpCode AS [ApiCmpCode],
							cmpEffectiveDatePersian AS [ApiCmpEffectiveDatePersian],
							cmpEffectiveDateTime AS [ApiCmpEffectiveDateTime],
							ImportDateTime AS [ApiCmpImportDateTime],
							cmpCoordinateLatitude AS [ApiCmpCoordinateLatitude],
							cmpCoordinateLongitude AS [ApiCmpCoordinateLongitude],
							cmpCoordinateLastDate AS [ApiCmpCoordinateLastDate],
							cmpCoordinateLastDatePersian AS [ApiCmpCoordinateLastDatePersian],
							cmpCoordinateZoomLevel AS [ApiCmpCoordinateZoomLevel],
							cmpCoordinateLastUserId AS [ApiCmpCoordinateLastUserId],
							(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = CC.cmpCoordinateLastUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCmpCoordinateLastUser],
							cmpIsDraft AS [ApiCmpIsDraft],
							cmpKind AS [ApiCmpKind],
							cmpMainPersonId AS [ApiCmpMainPersonId],
							(SELECT 
								ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle_Lang] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId]AND PT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') + '' ''+ 	/*RZ990511- Add prsTitle*/
								ISNULL((SELECT ISNULL(CCP.prsFName, '''') + '' '' + ISNULL(CCP.prsLName, '''') FROM CrmCompanyPersons_Lang CCPL 
									WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID
									AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''')
							FROM CrmCompanyPersons CCP 
							WHERE CCP.CompanyPersonID = CC.cmpMainPersonId) AS  [ApiCmpMainPerson] ,
							[UserId] AS [ApiUserId],
						[FirstRegisterUserId] AS [ApiFirstRegisterUserId] 
						FROM CrmCompany CC
						WHERE 1 = 1 '

		/**/
	END
	/*-------------------------------------------------------*/
	/*RZ990511*/
	IF (ISNULL(@CompanyId, 0) > 0)
	BEGIN
		/**/
		SET @QRY = @QRY + ' AND CC.CompanyID =  ' + CAST(@CompanyId AS NVARCHAR(50))
		/**/
	END
	IF (@CmpCode IS NOT NULL)
	BEGIN
		/**/
		SET @QRY = @QRY + ' AND CC.cmpCode = ''' + @CmpCode + ''''
		/**/
	END
	IF (ISNULL(@CmpNumber, 0) > 0)
	BEGIN
		/**/
		SET @QRY = @QRY + ' AND CC.cmpNumber = ' + CAST(@CmpNumber AS NVARCHAR(50))
		/**/
	END
	IF (@FromRegisterDate IS NOT NULL) AND (@ToRegisterDate IS NOT NULL)
	BEGIN
		/**/
		SET @QRY = @QRY + ' AND CC.RegisterDate BETWEEN ''' + CAST(@FromRegisterDate AS NVARCHAR(60)) + ''' AND ''' + CAST(@ToRegisterDate AS NVARCHAR(60)) + ''''
		/**/
	END
	IF (@FromFirstRegisterDate IS NOT NULL) AND (@ToFirstRegisterDate IS NOT NULL)
	BEGIN
		/**/
		SET @QRY = @QRY + ' AND CC.FirstRegisterDate BETWEEN ''' + CAST(@FromFirstRegisterDate AS NVARCHAR(60)) + ''' AND ''' + CAST(@ToFirstRegisterDate AS NVARCHAR(60)) + ''''
		/**/
	END
		
	SET @QRY = @QRY + ' ORDER BY CC.CompanyID '
	
	EXECUTE(@QRY)
	/*RZ990511- End*/
	/**/
END








