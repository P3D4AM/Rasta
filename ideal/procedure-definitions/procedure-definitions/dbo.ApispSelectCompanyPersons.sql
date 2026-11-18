






/*NKR990507*/
/*RZ990511- Modify this sp*/
Create PROCEDURE [dbo].[ApispSelectCompanyPersons]
(
	/*
		exec [dbo].[ApispSelectCompanyPersons] 17996,0,1033,1065
	*/
	@CompanyPersonID INT,
	@CompanyId INT,
	@LanguageID INT = NULL,
	@DefaultLanguageID INT = NULL 
)
AS
BEGIN
	/**/
		/*RZ990511- Add ApiPrs to all field name in this sp*/
	DECLARE @QRY NVARCHAR(MAX) = ''

	IF (@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
		SET @QRY = 
					'SELECT
						CompanyPersonID  AS [ApiCompanyPersonID],
						prsCompanyId  AS [ApiPrsCompanyId],
						(SELECT 
							ISNULL((SELECT ISNULL(CCT.CompanyTitle, '''') FROM CrmCompanyTitle CCT WHERE CCT.CompanyTitleID = CC.cmpTitleId),'''') + '' '' +/*RZ990511- Modify this sp*/
							ISNULL(CC.cmpName, '''') 
						FROM CrmCompany CC 
						WHERE CC.CompanyID = CCP.prsCompanyId) AS [ApiPrsCompany],
						prsLName  AS [ApiPrsLName],
						prsFName  AS [ApiPrsFName],
						prsTitleId AS [ApiPrsTitleId],
						(ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId]),'''')) AS [ApiPrsTitle], /*RZ990511*/
						(ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId]),'''') + '' ''+ 	/*RZ990511e*/						
						ISNULL(prsFName, '''') + '' '' + ISNULL(prsLName, '''')) AS [ApiPersonName],
						prsJobId AS [ApiPrsJobId],
						(SELECT ISNULL(CPJ.Jobs, '''') FROM CrmPersonJobs CPJ WHERE CPJ.PersonJobID = CCP.prsJobId) AS [ApiPrsJob],
						prsTypeId AS [ApiPrsTypeId],
						(SELECT ISNULL(CPT.PersonType, '''') FROM CrmPersonType CPT WHERE CPT.PersonTypeID = CCP.prsTypeId) AS [ApiPrsType],
						prsGroupId AS [ApiPrsGroupId],
						(SELECT ISNULL(CPG.PersonGroup, '''') FROM CrmPersonGroups CPG WHERE CPG.PersonGroupID = CCP.prsGroupId) AS [ApiPrsGroup],
						prsSexId AS [ApiPrsSexId],
						(SELECT ISNULL(S.SexType, '''') FROM Sex S WHERE S.SexID = CCP.prsSexId) AS [ApiPrsSex],
						prsEducationId AS [ApiPrsEducationId],
						(SELECT ISNULL(E.Education, '''') FROM Education E WHERE E.EducationID = CCP.prsEducationId) AS [ApiPrsEducation],
						prsPreTel AS [ApiPrsPreTel],
						prsTel AS [ApiPrsTel],
						prsTelUpTo AS [ApiPrsTelUpTo],
						prsTelDesc AS [ApiPrsTelDesc],
						prsTelII AS [ApiPrsTelII],
						prsFax AS [ApiPrsFax],
						prsFaxDesc AS [ApiPrsFaxDesc],
						prsMobile AS [ApiPrsMobile],
						prsWebSite AS [ApiPrsWebSite],
						prsEmail AS [ApiPrsEmail],
						prsEmailII AS [ApiPrsEmailII], '
		SET @QRY = @QRY  +
					'	prsCountryId AS [ApiPrsCountryId],
						(SELECT ISNULL(C.Country, '''') FROM Country C WHERE C.CountryID = CCP.prsCountryId) AS [ApiPrsCountry],
						prsProvinceId AS [ApiPrsProvinceId],
						(SELECT ISNULL(P.Province, '''') FROM Province P WHERE P.ProvinceID = CCP.prsProvinceId) AS [ApiPrsProvince],
						prsCityId AS [ApiPrsCityId],
						(SELECT ISNULL(C.City, '''') FROM City C WHERE C.CityID = CCP.prsCityId) AS [ApiPrsCity],
						prsAddress AS [ApiPrsAddress],
						prsAddressDesc AS [ApiPrsAddressDesc],
						prsZipCode AS [ApiPrsZipCode],
						prsPostBox AS [ApiPrsPostBox],
						prsNationalCode AS [ApiPrsNationalCode],
						prsIdentityNumber AS [ApiPrsIdentityNumber],
						prsFatherName AS [ApiPrsFatherName],
						prsBirthDate AS [ApiPrsBirthDate],
						prsBirthPlace AS [ApiPrsBirthPlace],
						prsIsMarried AS [ApiPrsIsMarried],
						prsMarriageDate AS [ApiPrsMarriageDate],
						prsEducationField AS [ApiPrsEducationField],
						prsSkill AS [ApiPrsSkill],
						prsStudyField AS [ApiPrsStudyField],
						prsInteresting AS [ApiPrsInteresting],
						prsSpecialPoint AS [ApiPrsSpecialPoint],
						prsDescription AS [ApiPrsDescription],						
						ImportDate AS [ApiPrsImportDate],
						prsDepartmentId AS [ApiPrsDepartmentId],
						(SELECT ISNULL(CPD.PersonDepartment, '''') FROM CrmPersonDepartments CPD WHERE CPD.PersonDepartmentId = CCP.prsDepartmentId) AS [ApiPrsDepartment],
						prsStopSendSms AS [ApiPrsStopSendSms],
						prsOrderView AS [ApiPrsOrderView],
						prsWorkingOut AS [ApiPrsWorkingOut],
						CompanyPersonTemplateID AS [ApiCompanyPersonTemplateID],
						(SELECT ISNULL(CCPT.prsFName, '''') + '' '' + ISNULL(CCPT.prsLName, '''') FROM CrmCompanyPersonsTemplate CCPT 
							WHERE CCPT.CompanyPersonTemplateID = CCP.CompanyPersonTemplateID) AS [ApiCompanyPersonTemplate],
						prsBirthDateTime AS [ApiPrsBirthDateTime],
						prsMarriageDateTime AS [ApiPrsMarriageDateTime],
						ImportDateTime AS [ApiPrsImportDateTime],
						prsTelegramId AS [ApiPrsTelegramId],						
						UserId AS [ApiUserId],
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.FName, '''') FROM Users U WHERE U.UserId = CCP.UserId) AS [ApiEditUser],
						RegisterDate AS [ApiRegisterDate],
						FirstRegisterDate AS [ApiFirstRegisterDate],
						FirstRegisterUserId AS [ApiFirstRegisterUserId],
						(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.FName, '''') FROM Users U WHERE U.UserId = CCP.FirstRegisterUserId) AS [ApiFirstRegisterUser]
					FROM CrmCompanyPersons CCP
					WHERE 1 = 1 '		
	END
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		SET @QRY = '
					SELECT
						CompanyPersonID AS [ApiCompanyPersonID],
						prsCompanyId AS [ApiPrsCompanyId],
						(SELECT 
							ISNULL((SELECT ISNULL(CCT.CompanyTitle, '''') FROM CrmCompanyTitle_Lang CCT WHERE CCT.CompanyTitleID = CC.cmpTitleId AND CCT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') + '' '' +/*RZ990511- Modify this sp*/
							ISNULL((SELECT ISNULL(CCL.cmpName, '''') FROM CrmCompany_Lang CCL WHERE CCL.CompanyID = CCP.prsCompanyId AND CCL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '), '''') 
						FROM CrmCompany CC 
						WHERE CC.CompanyID = CCP.prsCompanyId) AS [ApiPrsCompany],
						
						(SELECT ISNULL(CCPL.prsLName, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsLName],
						(SELECT ISNULL(CCPL.prsFName, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsFName],
						prsTitleId AS [ApiPrsTitleId],						
						(SELECT PersonTitle FROM [dbo].[CrmPersonTitle_Lang] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId] AND PT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ')  AS [ApiPrsTitle], /*RZ990511*/
						(
							ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle_Lang] PT WHERE PT.[PersonTitleID] = CCP.[prsTitleId] AND PT.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + '),'''') + '' '' +/*RZ990511*/						
							ISNULL((SELECT ISNULL(CCPL.prsFName, '''') + '' '' + ISNULL(CCPL.prsLName, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' ),'''')
						) AS [ApiPersonName],
						prsJobId AS [ApiPrsJobId],
						(SELECT ISNULL(CPJL.Jobs, '''') FROM CrmPersonJobs_Lang CPJL WHERE CPJL.PersonJobID = CCP.prsJobId AND CPJL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiPrsJob],/*RZ990511*/
						prsTypeId AS [ApiPrsTypeId],
						(SELECT ISNULL(CPTL.PersonType, '''') FROM CrmPersonType_Lang CPTL WHERE CPTL.PersonTypeID = CCP.prsTypeId AND CPTL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiPrsType],/*RZ990511*/
						prsGroupId AS [ApiPrsGroupId],
						(SELECT ISNULL(CPGL.PersonGroup, '''') FROM CrmPersonGroups_Lang CPGL WHERE CPGL.PersonGroupID = CCP.prsGroupId AND CPGL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiPrsGroup],/*RZ990511*/
						prsSexId AS [ApiPrsSexId],
						(SELECT ISNULL(SL.SexType, '''') FROM Sex_Lang SL WHERE SL.SexID = CCP.prsSexId AND SL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiPrsSex],/*RZ990511*/
						prsEducationId AS [ApiPrsEducationId],
						(SELECT ISNULL(EL.Education, '''') FROM Education_Lang EL WHERE EL.EducationID = CCP.prsEducationId AND EL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiPrsEducation],/*RZ990511*/
						prsPreTel AS [ApiPrsPreTel],
						prsTel AS [ApiPrsTel],
						prsTelUpTo AS [ApiPrsTelUpTo],
						(SELECT ISNULL(CCPL.prsTelDesc, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' ) AS [ApiPrsTelDesc],
						prsTelII AS [ApiPrsTelII],
						prsFax AS [ApiPrsFax],						
						(SELECT ISNULL(CCPL.prsFaxDesc, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' ) AS [ApiPrsFaxDesc],
						prsMobile AS [ApiPrsMobile],
						prsWebSite AS [ApiPrsWebSite],
						prsEmail AS [ApiPrsEmail],
						prsEmailII AS [ApiPrsEmailII], '
		SET @QRY = @QRY + 
					'	prsCountryId AS [ApiPrsCountryId],
						(SELECT ISNULL(CL.Country, '''') FROM Country_Lang CL WHERE CL.CountryID = CCP.prsCountryId AND CL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiPrsCountry],/*RZ990511*/
						prsProvinceId AS [ApiPrsProvinceId],
						(SELECT ISNULL(PL.Province, '''') FROM Province_Lang PL WHERE PL.ProvinceID = CCP.prsProvinceId AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiPrsProvince],/*RZ990511*/
						prsCityId AS [ApiPrsCityId],
						(SELECT ISNULL(CL.City, '''') FROM City_Lang CL WHERE CL.CityID = CCP.prsCityId AND CL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiPrsCity],/*RZ990511*/
						(SELECT ISNULL(CCPL.prsAddress, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsAddress],
						(SELECT ISNULL(CCPL.prsAddressDesc, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsAddressDesc],
						prsZipCode AS [ApiPrsZipCode],
						prsPostBox AS [ApiPrsPostBox],
						prsNationalCode AS [ApiPrsNationalCode],
						prsIdentityNumber AS [ApiPrsIdentityNumber],
						(SELECT ISNULL(CCPL.prsFatherName, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsFatherName],
						prsBirthDate AS [ApiPrsBirthDate],
						(SELECT ISNULL(CCPL.prsBirthPlace, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsBirthPlace],
						prsIsMarried AS [ApiPrsIsMarried],
						prsMarriageDate AS [ApiPrsMarriageDate],
						(SELECT ISNULL(CCPL.prsEducationField, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsEducationField],
						(SELECT ISNULL(CCPL.prsSkill, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsSkill] ,
						(SELECT ISNULL(CCPL.prsStudyField, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsStudyField] ,
						(SELECT ISNULL(CCPL.prsInteresting, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsInteresting],
						(SELECT ISNULL(CCPL.prsSpecialPoint, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsSpecialPoint],
						(SELECT ISNULL(CCPL.prsDescription, '''') FROM CrmCompanyPersons_Lang CCPL WHERE CCPL.CompanyPersonID = CCP.CompanyPersonID AND CCPL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ' )  AS [ApiPrsDescription],						
						ImportDate AS [ApiPrsImportDate],
						prsDepartmentId AS [ApiPrsDepartmentId],
						(SELECT ISNULL(CPDL.PersonDepartment, '''') FROM CrmPersonDepartments_Lang CPDL WHERE CPDL.PersonDepartmentId = CCP.prsDepartmentId AND CPDL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiPrsDepartment],/*RZ990511*/
						prsStopSendSms AS [ApiPrsStopSendSms],
						prsOrderView AS [ApiPrsOrderView],
						prsWorkingOut AS [ApiPrsWorkingOut],
						CompanyPersonTemplateID AS [ApiCompanyPersonTemplateID],
						(SELECT ISNULL(CCPTL.prsFName, '''') + '' '' + ISNULL(CCPTL.prsLName, '''') FROM CrmCompanyPersonsTemplate_Lang CCPTL WHERE CCPTL.CompanyPersonTemplateID = CCP.CompanyPersonTemplateID AND CCPTL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiCompanyPersonTemplate],/*RZ990511*/
						prsBirthDateTime AS [ApiPrsBirthDateTime],
						prsMarriageDateTime AS [ApiPrsMarriageDateTime],
						ImportDateTime AS [ApiPrsImportDateTime],
						prsTelegramId AS [ApiPrsTelegramId],						
						UserId AS [ApiUserId],
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.FName, '''') FROM Users_Lang UL WHERE UL.UserId = CCP.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiEditUser],/*RZ990511*/
						RegisterDate AS [ApiRegisterDate],
						FirstRegisterDate AS [ApiFirstRegisterDate],
						FirstRegisterUserId AS [ApiFirstRegisterUserId],
						(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.FName, '''') FROM Users_Lang UL WHERE UL.UserId = CCP.FirstRegisterUserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS [ApiFirstRegisterUser] /*RZ990511*/
					FROM CrmCompanyPersons CCP
					WHERE 1 = 1 '		
	END

	/*--------------------------------------------*/
	/*RZ990511*/
	IF (ISNULL(@CompanyId, 0) > 0)
		BEGIN
			SET @QRY = @QRY + ' AND CCP.prsCompanyId  = ' + CAST(@CompanyId AS NVARCHAR(50))
		END
		ELSE IF (ISNULL(@CompanyPersonID, 0) > 0)
		BEGIN
			SET @QRY = @QRY + ' AND CCP.CompanyPersonID  = ' + CAST(@CompanyPersonID AS NVARCHAR(50))
		END

	EXECUTE (@QRY + N' ORDER BY ISNULL(prsOrderView, CompanyPersonID)')

	/*RZ990511- End*/
/**/
END




