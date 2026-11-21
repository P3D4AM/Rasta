





/*AI14020405*/
/*AI14020407 - Add check*/
/*AI14020530 - cnvsDesc length from 4000 to MAX*/
/*AI14021005 - Add OrderView to project*/
CREATE PROCEDURE [dbo].[MobspInsertQuickPrjCnvsForDuplicate]
/*
	EXEC MobspInsertQuickPrjCnvsForDuplicate
*/
(
@CompanyId INT,
@CompanyPersonId INT = NULL,
@Company NVARCHAR(MAX) = NULL,
@PersonList NVARCHAR(MAX) = NULL,
@ProjectList NVARCHAR(MAX) = NULL,
@ConversationList NVARCHAR(MAX) = NULL,
/**/
@UserId INT,
@Year1 SMALLINT,
@Month1 SMALLINT,
@RegisterDate DATETIME,
@RegisterDatePersian NVARCHAR(8),
@AppType VARCHAR(20), 
@LanguageID INT = NULL,
@DefaultLanguageID INT = NULL,
@ErrorMessage NVARCHAR(MAX) OUTPUT,
@InsertedPersonIds NVARCHAR(1000) OUTPUT,
@InsertedProjectIds NVARCHAR(1000) OUTPUT,
@InsertedConversationIds NVARCHAR(1000) OUTPUT
)
AS
BEGIN

DECLARE @CurrYear SMALLINT
SET @CurrYear = CAST(SUBSTRING(@RegisterDatePersian, 1, 4) AS SMALLINT)
/**/
DECLARE @RegisterTime NVARCHAR(8)
SET @RegisterTime = (CONVERT(CHAR(8), @RegisterDate, 108))
/**/
DECLARE @ErrorFrom VARCHAR(50), @ErrorNumber INT
/**/
DECLARE @IsDuplicate BIT



BEGIN TRANSACTION Main


DECLARE
	@cmpName NVARCHAR(300),
	@cmpTitleId INT

DECLARE @CmpField NVARCHAR(MAX) = NULL
WHILE LEN(@Company) > 0
BEGIN
    IF PATINDEX('%|#|%', @Company) > 0
    BEGIN
        SET @CmpField = SUBSTRING(@Company,
                                    0,
                                    PATINDEX('%|#|%', @Company))
        /*SELECT @CmpField*/
        /*--------------------------------------------------------------------------------*/
        /*Get parameter name and split value form parameter*/
        /*For example => cmpTypeId=102 => cmpTypeId= => cmpTypeId => Compare => value*/
        DECLARE @CmpFieldValue NVARCHAR(MAX)
        DECLARE @CmpFieldName NVARCHAR(200)
        SET @CmpFieldName = SUBSTRING(@CmpField, 1, CHARINDEX('=',@CmpField)-1)                                    
		SET @CmpFieldValue = SUBSTRING(@CmpField, CHARINDEX('=', @CmpField)+1, Len(@CmpField))
        /*--------------------------------------------------------------------------------*/
        /*---------------------------- BEGIN Fill variabele ------------------------------*/
        /*BEGIN COMPANY*/
        /*--------------------------*/
		IF @CmpFieldName = 'cmpName'
        BEGIN
			SET @cmpName = CASE WHEN @CmpFieldValue = '' OR @CmpFieldValue = 'null' THEN NULL ELSE @CmpFieldValue END	
			SET @cmpName = (SELECT dbo.[fnConvertArabicCharacterToPersian](@cmpName)) /*AI14011027*/		
        END
        /*--------------------------*/
		IF @CmpFieldName = 'cmpTitleId'
        BEGIN
			SELECT @cmpTitleId = CASE WHEN @CmpFieldValue = 'null' THEN NULL ELSE CAST(@CmpFieldValue AS INT) END
        END
        /*--------------------------*/
        /*END COMPANY*/		
        /*END GENERAL*/
        /*---------------------------- END Fill variabele --------------------------------*/
        /*---------------------------- Remove current parameter from listparam ------------*/
        SET @Company = SUBSTRING(@Company,
                                  LEN(@CmpField + '|#|') + 1,
                                  LEN(@Company))
    END
    ELSE
    BEGIN
        SET @CmpField = @Company
        SET @Company = NULL
        /*SELECT @CmpField*/
    END
END




/**/
DECLARE @PrsAllFields NVARCHAR(MAX) = NULL
DECLARE @PrsField NVARCHAR(MAX) = NULL
/**************** Define & set null field **************/
DECLARE 
	@prsCompanyId INT = NULL,
	@prsLName NVARCHAR(100) = NULL,
	@prsFName NVARCHAR(50) = NULL,
	@prsTitleId INT = NULL,
	@prsJobId INT = NULL,
	@prsTypeId INT = NULL,
	@prsGroupId INT = NULL,
	@prsSexId INT = NULL,
	@prsEducationId INT = NULL,
	@prsPreTel NVARCHAR(10) = NULL,
	@prsTel NVARCHAR(15) = NULL,
	@prsTelUpTo NVARCHAR(10) = NULL,
	@prsTelDesc NVARCHAR(50) = NULL,
	@prsTelII NVARCHAR(15) = NULL,
	@prsFax NVARCHAR(15) = NULL,
	@prsFaxDesc NVARCHAR(50) = NULL,
	@prsMobile NVARCHAR(15) = NULL,
	@prsWebSite NVARCHAR(50) = NULL,
	@prsEmail NVARCHAR(50) = NULL,
	@prsEmailII NVARCHAR(50) = NULL,
	@prsCountryId INT = NULL,
	@prsProvinceId INT = NULL,
	@prsCityId INT = NULL,
	@prsAddress NVARCHAR(250) = NULL,
	@prsAddressDesc NVARCHAR(100) = NULL,
	@prsZipCode NVARCHAR(50) = NULL,
	@prsPostBox NVARCHAR(50) = NULL,
	@prsNationalCode NVARCHAR(30) = NULL,
	@prsIdentityNumber NVARCHAR(30) = NULL,
	@prsFatherName NVARCHAR(50) = NULL,
	@prsBirthDate NVARCHAR(8) = NULL,
	@prsBirthDateTime DATETIME = NULL,
	@prsBirthPlace NVARCHAR(50) = NULL,
	@prsIsMarried BIT = NULL,
	@prsMarriageDate NVARCHAR(8) = NULL,
	@prsMarriageDateTime DATETIME = NULL,
	@prsEducationField NVARCHAR(50) = NULL,
	@prsSkill NVARCHAR(50) = NULL,
	@prsStudyField NVARCHAR(50) = NULL,
	@prsInteresting NVARCHAR(500) = NULL,
	@prsSpecialPoint NVARCHAR(500) = NULL,
	@prsDescription NVARCHAR(500) = NULL,
	@prsImportDate NVARCHAR(8) = NULL,
	@prsImportDateTime DATETIME = NULL,
	@prsFirstRegisterUserId INT = NULL,
	@prsDepartmentId INT = NULL,
	@prsStopSendSms BIT = NULL,
	@prsOrderView INT = NULL,
	@prsWorkingOut BIT = NULL,
	@CompanyPersonTemplateID INT = NULL,
	@prsFirstRegisterDatePersian NVARCHAR(8) = NULL,
	@prsTelegramId INT = NULL,
	@prsFirstRegisterDate DATETIME  = NULL,
	@PersonPicture VARBINARY(MAX)/*IMAGE*/ = NULL	
WHILE LEN(@PersonList) > 0 AND (@PersonList IS NOT NULL)
BEGIN
	/*@PersonList = N'prsName=name1|&|prsTitle=1|&||^#^|prsName=name2|&|prsTitle=2|&||^#^|'*/
	IF PATINDEX('%|^#^|%', @PersonList) > 0
	BEGIN
		SET @PrsAllFields = SUBSTRING(@PersonList,
									0,
									PATINDEX('%|^#^|%', @PersonList))
		/*--------------------------------------------------------------------------------*/
		/*For example => @PrsAllFields = prsName=name1|&|prsTitle=1|&|*/
		/*--------------------------------------------------------------------------------*/
		/*---------------------------- BEGIN Fill fields  --------------------------------*/
		/*BEGIN PERSON*/
		DECLARE @PAllFields NVARCHAR(MAX)
		SET @PAllFields = @PrsAllFields
        
		/****************  set null field **************/         
			SET @prsCompanyId  = NULL
			SET @prsLName  = NULL
			SET @prsFName  = NULL
			SET @prsTitleId  = NULL
			SET @prsJobId  = NULL
			SET @prsTypeId  = NULL
			SET @prsGroupId  = NULL
			SET @prsSexId  = NULL
			SET @prsEducationId  = NULL
			SET @prsPreTel  = NULL
			SET @prsTel  = NULL
			SET @prsTelUpTo  = NULL
			SET @prsTelDesc  = NULL
			SET @prsTelII  = NULL
			SET @prsFax  = NULL
			SET @prsFaxDesc  = NULL
			SET @prsMobile  = NULL
			SET @prsWebSite  = NULL
			SET @prsEmail  = NULL
			SET @prsEmailII  = NULL
			SET @prsCountryId  = NULL
			SET @prsProvinceId  = NULL
			SET @prsCityId  = NULL
			SET @prsAddress  = NULL
			SET @prsAddressDesc  = NULL
			SET @prsZipCode  = NULL
			SET @prsPostBox  = NULL
			SET @prsNationalCode  = NULL
			SET @prsIdentityNumber  = NULL
			SET @prsFatherName  = NULL
			SET @prsBirthDate  = NULL
			SET @prsBirthDateTime  = NULL
			SET @prsBirthPlace  = NULL
			SET @prsIsMarried  = NULL
			SET @prsMarriageDate  = NULL
			SET @prsMarriageDateTime  = NULL
			SET @prsEducationField  = NULL
			SET @prsSkill  = NULL
			SET @prsStudyField  = NULL
			SET @prsInteresting  = NULL
			SET @prsSpecialPoint  = NULL
			SET @prsDescription  = NULL
			SET @prsImportDate  = NULL
			SET @prsImportDateTime  = NULL
			SET @prsFirstRegisterUserId  = NULL
			SET @prsDepartmentId  = NULL
			SET @prsStopSendSms  = NULL
			SET @prsOrderView  = NULL
			SET @prsWorkingOut  = NULL
			SET @CompanyPersonTemplateID  = NULL
			SET @prsFirstRegisterDatePersian  = NULL
			SET @prsTelegramId  = NULL
			SET @prsFirstRegisterDate   = NULL
			SET @PersonPicture  = NULL				
                
		/**/
		WHILE LEN(@PAllFields) > 0
		BEGIN
			IF PATINDEX('%|#|%', @PAllFields) > 0
			BEGIN
				SET @PrsField = SUBSTRING(@PAllFields,
											0,
											PATINDEX('%|#|%', @PAllFields))
				/*--------------------------------------------------------------------------------*/
				/*Get parameter name and split value form parameter*/
				/*For example => prsTypeId=102 => prsTypeId= => prsTypeId => Compare => value*/
				DECLARE @PrsFieldValue NVARCHAR(MAX)
				DECLARE @PrsFieldName NVARCHAR(200)
				SET @PrsFieldName = SUBSTRING(@PrsField, 1, CHARINDEX('=',@PrsField)-1)                                    
				SET @PrsFieldValue = SUBSTRING(@PrsField, CHARINDEX('=', @PrsField)+1, Len(@PrsField))
				/*--------------------------------------------------------------------------------*/
				/*---------------------------- BEGIN Fill variabele ------------------------------*/
				/*BEGIN PERSON*/
				/*--------------------------*/
				IF @PrsFieldName = 'prsCompanyId'
				BEGIN
					SELECT @prsCompanyId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsLName'
				BEGIN
					SET @prsLName = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
					SET @prsLName = (SELECT dbo.[fnConvertArabicCharacterToPersian](@prsLName))
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsFName'
				BEGIN
					SET @prsFName = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
					SET @prsFName = (SELECT dbo.[fnConvertArabicCharacterToPersian](@prsFName))
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsTitleId'
				BEGIN
					SELECT @prsTitleId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsJobId'
				BEGIN
					SELECT @prsJobId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsTypeId'
				BEGIN
					SELECT @prsTypeId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsGroupId'
				BEGIN
					SELECT @prsGroupId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsSexId'
				BEGIN
					SELECT @prsSexId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsEducationId'
				BEGIN
					SELECT @prsEducationId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsPreTel'
				BEGIN
					SET @prsPreTel = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsTel'
				BEGIN
					SET @prsTel = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END														
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsTelUpTo'
				BEGIN
					SET @prsTelUpTo = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsTelDesc'
				BEGIN
					SET @prsTelDesc = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsTelII'
				BEGIN
					SET @prsTelII = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsFax'
				BEGIN
					SET @prsFax = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsFaxDesc'
				BEGIN
					SET @prsFaxDesc = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsMobile'
				BEGIN
					SET @prsMobile = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END													
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsWebSite'
				BEGIN
					SET @prsWebSite = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsEmail'
				BEGIN
					SET @prsEmail = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END										
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsEmailII'
				BEGIN
					SET @prsEmailII = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END										
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsCountryId'
				BEGIN
					SELECT @prsCountryId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsProvinceId'
				BEGIN
					SELECT @prsProvinceId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsCityId'
				BEGIN
					SELECT @prsCityId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsAddress'
				BEGIN
					SET @prsAddress = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsAddressDesc'
				BEGIN
					SET @prsAddressDesc = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsZipCode'
				BEGIN
					SET @prsZipCode = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsPostBox'
				BEGIN
					SET @prsPostBox = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsNationalCode'
				BEGIN
					SET @prsNationalCode = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsIdentityNumber'
				BEGIN
					SET @prsIdentityNumber = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsFatherName'
				BEGIN
					SET @prsFatherName = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsBirthDate'
				BEGIN
					SET @prsBirthDate = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE REPLACE(@PrsFieldValue, '/', '') END	
					SET @prsBirthDateTime = CASE WHEN @prsBirthDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prsBirthDate, NULL/*AI14010122 - @RegisterTime*/) END			 	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsBirthPlace'
				BEGIN
					SET @prsBirthPlace = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsIsMarried'
				BEGIN
					SET @prsIsMarried = CASE WHEN @PrsFieldValue = 'null' THEN NULL 
										WHEN @PrsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsMarriageDate'
				BEGIN
					SET @prsMarriageDate = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE REPLACE(@PrsFieldValue, '/', '') END
					SET @prsMarriageDateTime = CASE WHEN @prsMarriageDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prsMarriageDate, NULL/*AI14010122 - @RegisterTime*/) END			 	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsEducationField'
				BEGIN
					SET @prsEducationField = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsSkill'
				BEGIN
					SET @prsSkill = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsStudyField'
				BEGIN
					SET @prsStudyField = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsInteresting'
				BEGIN
					SET @prsInteresting = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsSpecialPoint'
				BEGIN
					SET @prsSpecialPoint = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsDescription'
				BEGIN
					SET @prsDescription = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE @PrsFieldValue END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsImportDate'
				BEGIN
					SET @prsImportDate = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE REPLACE(@PrsFieldValue, '/', '') END	
					SET @prsImportDateTime = CASE WHEN @prsImportDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prsImportDate, @RegisterTime) END			 	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsFirstRegisterUserId'
				BEGIN
					SELECT @prsFirstRegisterUserId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsDepartmentId'
				BEGIN
					SELECT @prsDepartmentId = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsStopSendSms'
				BEGIN
					SET @prsStopSendSms = CASE WHEN @PrsFieldValue = 'null' THEN NULL 
										WHEN @PrsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsOrderView'
				BEGIN
					SELECT @prsOrderView = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsWorkingOut'
				BEGIN
					SET @prsWorkingOut = CASE WHEN @PrsFieldValue = 'null' THEN NULL 
										WHEN @PrsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @PrsFieldName = 'CompanyPersonTemplateID'
				BEGIN
					SELECT @CompanyPersonTemplateID = CASE WHEN @PrsFieldValue = 'null' THEN NULL ELSE CAST(@PrsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrsFieldName = 'prsFirstRegisterDatePersian'
				BEGIN
					SET @prsFirstRegisterDatePersian = CASE WHEN @PrsFieldValue = '' OR @PrsFieldValue = 'null' THEN NULL ELSE REPLACE(@PrsFieldValue, '/', '') END							
					SET @prsFirstRegisterDate = CASE WHEN @prsFirstRegisterDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prsFirstRegisterDatePersian, @RegisterTime) END			 	
				END				
				/*END PERSON*/		
				/*END GENERAL*/
				/*---------------------------- END Fill variabele --------------------------------*/
				/*---------------------------- Remove current parameter from listparam ------------*/
				SET @PAllFields = SUBSTRING(@PAllFields,
									LEN(@PrsField + '|#|') + 1,
									LEN(@PAllFields))                                                                                                      
			END
			ELSE
			BEGIN
				SET @PrsField = @PAllFields
				SET @PAllFields = NULL
				/*SELECT @CmpField*/
			END
		END  
		/************* Insert to tmp table***************/		
		/*END PERSON*/		
		/*END GENERAL*/
		/*---------------------------- END Fill fields ------------------------------------*/
		/*---------------------------- Remove current parameter from listparam ------------*/
		SET @PersonList = SUBSTRING(@PersonList,
									LEN(@PrsAllFields + '|^#^|') + 1,
									LEN(@PersonList))                                  
	END
	ELSE
	BEGIN
		SET @PrsAllFields = @PersonList
		SET @PersonList = NULL
		/*SELECT @CmpField*/
	END
END
/**/


/*******************************************************************************************************/
/*AI14020407 - Add*/
IF(ISNULL(@prsMobile, '') <> '')
BEGIN
	SET @CompanyPersonId = (SELECT TOP 1 
							[CompanyPersonID] 
						FROM [dbo].[CrmCompanyPersons] 
						WHERE [prsCompanyId] = @CompanyId
						AND [prsMobile] = @prsMobile
						)
END
/*AI14020407 - End*/

IF(ISNULL(@CompanyPersonId,0) = 0)
BEGIN
/**/
	IF(ISNULL(@prsTitleId, 0) <> 0)
	BEGIN
		SET @CompanyPersonId = (SELECT TOP 1 
								[CompanyPersonID] 
							FROM [dbo].[CrmCompanyPersons] WHERE
							[prsCompanyId] = @CompanyId
							AND dbo.[fnConvertArabicCharacterToPersian]([prsLName]) = @prsLName
							AND [prsTitleId] = @prsTitleId
							)
	END
	ELSE
	BEGIN
		SET @CompanyPersonId = (SELECT TOP 1 
								[CompanyPersonID] 
							FROM [dbo].[CrmCompanyPersons] WHERE
							[prsCompanyId] = @CompanyId
							AND dbo.[fnConvertArabicCharacterToPersian]([prsLName]) = @prsLName
							)
	END
/**/
END


IF(ISNULL(@CompanyPersonId,0) = 0)
BEGIN
	INSERT INTO [dbo].[CrmCompanyPersons]
			([prsCompanyId]
			,[prsLName]
			,[prsFName]
			,[prsTitleId]
			,[prsJobId]
			,[prsTypeId]
			,[prsGroupId]
			,[prsSexId]
			,[prsEducationId]
			,[prsPreTel]
			,[prsTel]
			,[prsTelUpTo]
			,[prsTelDesc]
			,[prsTelII]
			,[prsFax]
			,[prsFaxDesc]
			,[prsMobile]
			,[prsWebSite]
			,[prsEmail]
			,[prsEmailII]
			,[prsCountryId]
			,[prsProvinceId]
			,[prsCityId]
			,[prsAddress]
			,[prsAddressDesc]
			,[prsZipCode]
			,[prsPostBox]
			,[prsNationalCode]
			,[prsIdentityNumber]
			,[prsFatherName]
			,[prsBirthDate]
			,[prsBirthDateTime]
			,[prsBirthPlace]
			,[prsIsMarried]
			,[prsMarriageDate]
			,[prsMarriageDateTime]
			,[prsEducationField]
			,[prsSkill]
			,[prsStudyField]
			,[prsInteresting]
			,[prsSpecialPoint]
			,[prsDescription]
			,[UserId]
			,[Year1]
			,[Month1]
			,[RegisterDate]
			,[RegisterDatePersian]
			,[ImportDate]
			,[ImportDateTime]
			,[prsFirstRegisterUserId]
			,[prsDepartmentId]
			,[prsStopSendSms]
			,[prsOrderView]
			,[prsWorkingOut]
			,[CompanyPersonTemplateID]
			,[AppType]
			,[LanguageID]
			,[FirstRegisterUserId]
			,[FirstRegisterDatePersian]
			,[prsTelegramId]
			,[FirstRegisterDate])
		VALUES
			(@CompanyId
			,@prsLName
			,@prsFName
			,@prsTitleId
			,@prsJobId
			,@prsTypeId
			,@prsGroupId
			,@prsSexId
			,@prsEducationId
			,@prsPreTel
			,@prsTel
			,@prsTelUpTo
			,@prsTelDesc
			,@prsTelII
			,@prsFax
			,@prsFaxDesc
			,@prsMobile
			,@prsWebSite
			,@prsEmail
			,@prsEmailII
			,@prsCountryId
			,@prsProvinceId
			,@prsCityId
			,@prsAddress
			,@prsAddressDesc
			,@prsZipCode
			,@prsPostBox
			,@prsNationalCode
			,@prsIdentityNumber
			,@prsFatherName
			,@prsBirthDate
			,@prsBirthDateTime
			,@prsBirthPlace
			,@prsIsMarried
			,@prsMarriageDate
			,@prsMarriageDateTime
			,@prsEducationField
			,@prsSkill
			,@prsStudyField
			,@prsInteresting
			,@prsSpecialPoint
			,@prsDescription
			,@UserId
			,@Year1
			,@Month1
			,@RegisterDate
			,@RegisterDatePersian
			,@RegisterDatePersian
			,@RegisterDate
			,@prsFirstRegisterUserId
			,@prsDepartmentId
			,@prsStopSendSms
			,@prsOrderView
			,@prsWorkingOut
			,@CompanyPersonTemplateID
			,@AppType
			,@DefaultLanguageID
			,@prsFirstRegisterUserId
			,@RegisterDatePersian
			,@prsTelegramId
			,@RegisterDate
			)
	SET @CompanyPersonId = SCOPE_IDENTITY()	
END
/*******************************************************************************************************/




IF(@CompanyId <> 0 AND ISNULL(@CompanyPersonId, 0) <> 0)
BEGIN

/************************ Make A Table For ProjectList **************************/
DECLARE @ProjectTmpTable TABLE (
	[ProjectID] INT ,
	[prjCompanyId] INT ,
	[prjTitle] NVARCHAR(100) ,
	[prjDesc] NVARCHAR(300) ,
	[prjStartDate] NVARCHAR(8) ,
	[prjStartDay] NVARCHAR(20) ,
	[prjStartTime] NVARCHAR(15) ,
	[prjStartDateTime] DATETIME ,
	[prjStarterUserId] INT ,
	[prjFinishedStatusId] INT ,
	[prjIsFinished] BIT ,
	[prjFinishedDate] NVARCHAR(8) ,
	[prjFinishedDay] NVARCHAR(50) ,
	[prjFinishedTime] NVARCHAR(15) ,
	[prjFinishedDateTime] DATETIME ,
	[prjFinishedUserId] INT ,
	[prjGradeId] INT ,
	[prjPriorityId] INT ,
	[prjFirstRegisterUserId] INT ,
	[prjGroupId] INT ,
	[prjcnvsStatusGroupId] INT ,
	[prjOrderView] INT ,
	[prjPostFix] NVARCHAR(200) ,
	[prjFirstRegisterDatePersian] VARCHAR(8) ,
	[prjFirstRegisterDate] DATETIME ,
	[prjRemindDate] VARCHAR(8) ,
	[prjRemindDateTime] DATETIME ,
	[prjInsertForbidden] BIT,	
	[prjFOCmpCanSee] BIT,
	[prjIsTicket] BIT,
	[prjUserDepartmentId]INT,
	[prjHaveSms] BIT,
	[prjSmsPrsIds] NVARCHAR(3000),
	[prjSmsText] NVARCHAR(2000),
	[prjSmsSendDate] DATETIME,
	[prjSmsSendDatePersian] NVARCHAR(8),
	[prjInquiryNum] NVARCHAR(100),
	[prjSubject] NVARCHAR(1000),
	[prjTitleGroup] NVARCHAR(200),
	[prjCategoryId] INT,
	[prjDescI] NVARCHAR(MAX),
	[prjNumRef] NVARCHAR(150),
	[prjNumR] BIGINT,
	[prjToDoDateTime] DATETIME,
	[prjToDoRegisterDateTime] DATETIME,
	[prjToDoDoneDateTime] DATETIME,
	[prjFOCmpCanInsCnvs] BIT,
	[prjFOCmpCanNotInsCnvs] BIT,
	[prjTicketStop] BIT,
	[prjIsTicketNew] BIT,
	[prjToDoTimeSec] BIGINT,
	[prjToDoTimeRegisterHistory] NVARCHAR(MAX),
	[prjcmpPresentationId] INT,
	[prjcmpCampaignIds] NVARCHAR(2000)
)
/************************ Make A Table For ConversationList *********************/
DECLARE @ConversationTmpTable TABLE (
	[ConversationID] INT,
	[cnvsProjectId] INT,
	[cnvsCompanyId] INT,
	[cnvsDate] NVARCHAR(8),
	[cnvsDay] NVARCHAR(20),
	[cnvsTime] NVARCHAR(15),
	[cnvsDateTime] DATETIME,
	[cnvsTopicId] INT,
	[cnvsSubject] NVARCHAR(50),
	[cnvsDesc] NVARCHAR(MAX), /*AI14020530*/
	[cnvsPersonId] INT,
	[cnvsUserId] INT,
	[cnvsReferUserId] INT,
	[cnvsReferDesc] NVARCHAR(500),
	[cnvsStatusId] INT,
	[cnvsPriorityId] INT,
	[cnvsRemindDate] NVARCHAR(8),
	[cnvsRemindTime] NVARCHAR(15),
	[cnvsRemindDateTime] DATETIME,
	[cnvsRemindOk] BIT,
	[cnvsIsBookMark] BIT,
	[cnvsFirstRegisterUserId] INT,
	[cnvsFirstRegisterDatePersian] NVARCHAR(8),
	[cnvsFirstRegisterDate] DATETIME,		
	[cnvsRemindDateForAllarm] NVARCHAR(8),
	[cnvsRemindDateTimeForAllarm] DATETIME,
	[ApiId] NVARCHAR(200),	
	[cnvsCoordinateLatitude] NVARCHAR(100),
	[cnvsCoordinateLongitude] NVARCHAR(100),
	[cnvsCoordinateLastDate] DATETIME,
	[cnvsCoordinateLastDatePersian] VARCHAR(8),
	[cnvsEventPolicyNeedCheck] BIT,
	[TmpUserMultiUserText] 	NVARCHAR(Max),
	[cnvsFOCmpCanSee] BIT,
	[cnvsIsTicket] BIT,	
	[cnvsTicketIsRead] BIT,
	[cnvsDoingTime] TIME(7),
	[cnvsIsCopy] BIT,
	[cnvsDoingTimeSec] BIGINT,
	[cnvsStatusProcessKindId] INT,
	[cnvsStatusGroupId] INT,
	[cnvsEmailEventPolicyNeedCheck] BIT,
	[cnvsAvoidSendSms] BIT,
	[cnvsAvoidSendEmail] BIT,
	[cnvsHappyVote] INT,
	[cnvsStatusResultId] INT,
	[cnvsKnowledgeTankIds] NVARCHAR(MAX)
)  


/********************************************************************************/
/****************************** Project *****************************************/
/********************************************************************************/
BEGIN TRAN
/**/
DECLARE @PrjAllFields NVARCHAR(MAX) = NULL
DECLARE @PrjField NVARCHAR(MAX) = NULL
/**************** Define & set null field **************/
DECLARE @ProjectID INT = NULL,
	@prjCompanyId INT = NULL,
	@prjTitle NVARCHAR(100) = NULL,
	@prjDesc NVARCHAR(300) = NULL,
	@prjStartDate NVARCHAR(8) = NULL,
	@prjStartDay NVARCHAR(20) = NULL,
	@prjStartTime NVARCHAR(15) = NULL,
	@prjStartDateTime DATETIME = NULL,
	@prjStarterUserId INT = NULL,
	@prjFinishedStatusId INT = NULL,
	@prjIsFinished BIT = NULL,
	@prjFinishedDate NVARCHAR(8) = NULL,
	@prjFinishedDay NVARCHAR(50) = NULL,
	@prjFinishedTime NVARCHAR(15) = NULL,
	@prjFinishedDateTime DATETIME = NULL,
	@prjFinishedUserId INT = NULL,
	@prjGradeId INT = NULL,
	@prjPriorityId INT = NULL,
	@prjFirstRegisterUserId INT = NULL,
	@prjGroupId INT = NULL,
	@prjcnvsStatusGroupId INT = NULL,
	@prjOrderView INT = NULL,
	@prjPostFix NVARCHAR(200) = NULL,
	@prjFirstRegisterDatePersian VARCHAR(8) = NULL,
	@prjFirstRegisterDate DATETIME = NULL,
	@prjRemindDate VARCHAR(8) = NULL,
	@prjRemindDateTime DATETIME = NULL,
	@prjInsertForbidden BIT = NULL, 	
	@prjFOCmpCanSee BIT = NULL,
	@prjIsTicket BIT = NULL,
	@prjUserDepartmentId INT = NULL,
	@prjHaveSms BIT = NULL,
	@prjSmsPrsIds NVARCHAR(3000) = NULL,
	@prjSmsText NVARCHAR(2000) = NULL,
	@prjSmsSendDate DATETIME = NULL,
	@prjSmsSendDatePersian NVARCHAR(8) = NULL,
	@prjInquiryNum NVARCHAR(100) = NULL,
	@prjSubject NVARCHAR(1000) = NULL,
	@prjTitleGroup NVARCHAR(200) = NULL,
	@prjCategoryId INT = NULL,
	@prjDescI NVARCHAR(MAX) = NULL,
	@prjNumRef NVARCHAR(150) = NULL,
	@prjNumR BIGINT = NULL,
	@prjToDoDate NVARCHAR(8) = NULL,
	@prjToDoTime NVARCHaR(15) = NULL,
	@prjToDoDateTime DATETIME = NULL,
	@prjToDoRegisterDate NVARCHAR(8) = NULL,
	@prjToDoRegisterTime NVARCHaR(15) = NULL,
	@prjToDoRegisterDateTime DATETIME = NULL,
	@prjToDoDoneDate NVARCHAR(8) = NULL,
	@prjToDoDoneTime NVARCHaR(15) = NULL,
	@prjToDoDoneDateTime DATETIME = NULL,
	@prjFOCmpCanInsCnvs BIT = NULL,
	@prjFOCmpCanNotInsCnvs BIT = NULL,
	@prjTicketStop BIT = NULL,
	@prjIsTicketNew BIT = NULL,
	@prjToDoTimeSec BIGINT = NULL,
	@prjToDoTimeRegisterHistory NVARCHAR(MAX) = NULL,
	@prjcmpPresentationId INT = NULL,
	@prjcmpCampaignIds NVARCHAR(2000) = NULL


WHILE LEN(@ProjectList) > 0 AND (@ProjectList IS NOT NULL)
BEGIN
	/*@ProjectList = N'prjTitle=title1|&|prjGroupId=1|&||^#^|prjTitle=title2|&|prjGroupId=2|&||^#^|'*/
    IF PATINDEX('%|^#^|%', @ProjectList) > 0
    BEGIN
        SET @PrjAllFields = SUBSTRING(@ProjectList,
                                    0,
                                    PATINDEX('%|^#^|%', @ProjectList))
        /*--------------------------------------------------------------------------------*/
        /*For example => @PrjAllFields = prjTitle=title1|&|prjGroupId=1|&|*/
        /*--------------------------------------------------------------------------------*/
        /*---------------------------- BEGIN Fill fields  --------------------------------*/
        /*BEGIN PROJETC*/
        DECLARE @PjAllFields NVARCHAR(MAX)
        SET @PjAllFields = @PrjAllFields
        
        /**************** set null field **************/
        SET @ProjectID  = NULL
		SET @prjCompanyId  = NULL
		SET @prjTitle  = NULL
		SET @prjDesc  = NULL
		SET @prjStartDate  = NULL
		SET @prjStartDay  = NULL
		SET @prjStartTime  = NULL
		SET @prjStartDateTime  = NULL
		SET @prjStarterUserId  = NULL
		SET @prjFinishedStatusId  = NULL
		SET @prjIsFinished  = NULL
		SET @prjFinishedDate  = NULL
		SET @prjFinishedDay  = NULL
		SET @prjFinishedTime  = NULL
		SET @prjFinishedDateTime  = NULL
		SET @prjFinishedUserId  = NULL
		SET @prjGradeId  = NULL
		SET @prjPriorityId  = NULL
		SET @prjFirstRegisterUserId  = NULL
		SET @prjGroupId  = NULL
		SET @prjcnvsStatusGroupId  = NULL
		SET @prjOrderView  = NULL
		SET @prjPostFix  = NULL
		SET @prjFirstRegisterDatePersian  = NULL
		SET @prjFirstRegisterDate  = NULL
		SET @prjRemindDate  = NULL
		SET @prjRemindDateTime  = NULL
		SET @prjInsertForbidden  = NULL	
		SET @prjFOCmpCanSee = NULL
		SET @prjIsTicket = NULL
		SET @prjUserDepartmentId = NULL
		SET @prjHaveSms = NULL
		SET @prjSmsPrsIds = NULL
		SET @prjSmsText = NULL
		SET @prjSmsSendDate = NULL
		SET @prjSmsSendDatePersian = NULL
		SET @prjInquiryNum = NULL
		SET @prjSubject = NULL
		SET @prjTitleGroup = NULL
		SET @prjCategoryId = NULL
		SET @prjDescI = NULL
		SET @prjNumRef = NULL
		SET @prjNumR = NULL
		SET @prjToDoDate = NULL
		SET @prjToDoTime = NULL
		SET @prjToDoDateTime = NULL
		SET @prjToDoRegisterDate = NULL
		SET @prjToDoRegisterTime = NULL
		SET @prjToDoRegisterDateTime = NULL
		SET @prjToDoDoneDate = NULL
		SET @prjToDoDoneTime = NULL
		SET @prjToDoDoneDateTime = NULL
		SET @prjFOCmpCanInsCnvs = NULL
		SET @prjFOCmpCanNotInsCnvs = NULL
		SET @prjTicketStop = NULL
		SET @prjIsTicketNew = NULL
		SET @prjToDoTimeSec = NULL
		SET @prjToDoTimeRegisterHistory = NULL
		SET @prjcmpPresentationId = NULL
		SET @prjcmpCampaignIds = NULL
        /**/
        WHILE LEN(@PjAllFields) > 0
		BEGIN
			IF PATINDEX('%|#|%', @PjAllFields) > 0
			BEGIN
				SET @PrjField = SUBSTRING(@PjAllFields,
											0,
											PATINDEX('%|#|%', @PjAllFields))
				/*--------------------------------------------------------------------------------*/
				/*Get parameter name and split value form parameter*/
				/*For example => prjGroupId=102 => prjGroupId= => prjGroupId => Compare => value*/
				DECLARE @PrjFieldValue NVARCHAR(MAX)
				DECLARE @PrjFieldName NVARCHAR(200)
				SET @PrjFieldName = SUBSTRING(@PrjField, 1, CHARINDEX('=',@PrjField)-1)                                    
				SET @PrjFieldValue = SUBSTRING(@PrjField, CHARINDEX('=', @PrjField)+1, Len(@PrjField))
				/*--------------------------------------------------------------------------------*/
				/*---------------------------- BEGIN Fill variabele ------------------------------*/
				/*BEGIN Project*/
				/*--------------------------*/
				IF @PrjFieldName = 'ProjectID'
				BEGIN
					SELECT @ProjectID = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjCompanyId'
				BEGIN
					SELECT @prjCompanyId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjTitle'
				BEGIN
					SET @prjTitle = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
					IF(@prjTitle IS NOT NULL AND @prjTitle <> '')
					BEGIN
						DECLARE @prjIsFound BIT = 0
										
						EXEC [dbo].[MobspCheckAccessToProjectTitleForUser]
						@CrmUserId = @UserId,
						@PrjTitle = @prjTitle,
						@LanguageID = @LanguageID,
						@DefaultLanguageID = @DefaultLanguageID,
						@IsFound = @prjIsFound OUTPUT

						IF(@prjIsFound = 1)
							SET @ErrorMessage = @ErrorMessage + '|Msg=PrjAccess|' + CAST(@ProjectID AS NVARCHAR(10)) + '|PRJID|' + ISNULL(@prjTitle,'') + '|Msg=PrjAccess|'
					END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjDesc'
				BEGIN
					SET @prjDesc = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjStartDate'
				BEGIN
					SET @prjStartDate = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE REPLACE(@PrjFieldValue, '/', '') END							
					SET @prjStartDateTime = CASE WHEN @prjStartDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjStartDate, null) END			 	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjStartDay'
				BEGIN
					SET @prjStartDay = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjStartTime'
				BEGIN
					SET @prjStartTime = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjStarterUserId'
				BEGIN
					SELECT @prjStarterUserId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjFinishedStatusId'
				BEGIN
					SELECT @prjFinishedStatusId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjIsFinished'
				BEGIN
					SET @prjIsFinished = CASE WHEN @PrjFieldValue = 'null' THEN NULL 
										WHEN @PrjFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjFinishedDate'
				BEGIN
					SET @prjFinishedDate = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE REPLACE(@PrjFieldValue, '/', '') END							
					SET @prjFinishedDateTime = CASE WHEN @prjFinishedDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjFinishedDate, null) END			 	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjFinishedDay'
				BEGIN
					SET @prjFinishedDay = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjFinishedTime'
				BEGIN
					SET @prjFinishedTime = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjFinishedUserId'
				BEGIN
					SELECT @prjFinishedUserId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjGradeId'
				BEGIN
					SELECT @prjGradeId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjPriorityId'
				BEGIN
					SELECT @prjPriorityId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjFirstRegisterUserId'
				BEGIN
					SELECT @prjFirstRegisterUserId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjGroupId'
				BEGIN
					SELECT @prjGroupId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjcnvsStatusGroupId'
				BEGIN
					SELECT @prjcnvsStatusGroupId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjOrderView'
				BEGIN
					SELECT @prjOrderView = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjPostFix'
				BEGIN
					SET @prjPostFix = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjFirstRegisterDatePersian'
				BEGIN
					SET @prjFirstRegisterDatePersian = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE REPLACE(@PrjFieldValue, '/', '') END							
					SET @prjFirstRegisterDate = CASE WHEN @prjFirstRegisterDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjFirstRegisterDatePersian, @RegisterTime) END			 	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjRemindDate'
				BEGIN
					SET @prjRemindDate = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE REPLACE(@PrjFieldValue, '/', '') END	
					SET @prjRemindDateTime = CASE WHEN @prjRemindDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjRemindDate, null) END			 	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjInsertForbidden'
				BEGIN
					SET @prjInsertForbidden = CASE WHEN @PrjFieldValue = 'null' THEN NULL 
										WHEN @PrjFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				/*--------------------------*/
				IF @PrjFieldName = 'prjFOCmpCanSee'
				BEGIN
					SET @prjFOCmpCanSee = CASE WHEN @PrjFieldValue = 'null' THEN NULL 
										WHEN @PrjFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjIsTicket'
				BEGIN
					SET @prjIsTicket = CASE WHEN @PrjFieldValue = 'null' THEN NULL 
										WHEN @PrjFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjUserDepartmentId'
				BEGIN
					SELECT @prjUserDepartmentId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjHaveSms'
				BEGIN
					SET @prjHaveSms = CASE WHEN @PrjFieldValue = 'null' THEN NULL 
										WHEN @PrjFieldValue = 'false' THEN 0 
										ELSE 1 END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjSmsPrsIds'
				BEGIN
					SET @prjSmsPrsIds = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjSmsText'
				BEGIN
					SET @prjSmsText = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjSmsSendDatePersian'
				BEGIN
					SET @prjSmsSendDatePersian = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE REPLACE(@PrjFieldValue, '/', '') END							
					SET @prjSmsSendDate = CASE WHEN @prjSmsSendDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjSmsSendDatePersian, null) END		
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjInquiryNum'
				BEGIN
					SET @prjInquiryNum = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjSubject'
				BEGIN
					SET @prjSubject = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjTitleGroup'
				BEGIN
					SET @prjTitleGroup = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjCategoryId'
				BEGIN
					SET @prjCategoryId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjDescI'
				BEGIN
					SET @prjDescI = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjNumRef'
				BEGIN
					SET @prjNumRef = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjNumR'
				BEGIN
					SET @prjNumR = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS BIGINT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjToDoDate'
				BEGIN
					SET @prjToDoDate = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE REPLACE(@PrjFieldValue, '/', '') END							
					SET @prjToDoDateTime = CASE WHEN @prjToDoDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjToDoDate, null) END			 	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjToDoTime'
				BEGIN
					SET @prjToDoTime = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjToDoRegisterDate'
				BEGIN
					SET @prjToDoRegisterDate = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE REPLACE(@PrjFieldValue, '/', '') END							
					SET @prjToDoRegisterDateTime = CASE WHEN @prjToDoRegisterDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjToDoRegisterDate, null) END			 	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjToDoRegisterTime'
				BEGIN
					SET @prjToDoRegisterTime = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjToDoDoneDate'
				BEGIN
					SET @prjToDoDoneDate = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE REPLACE(@PrjFieldValue, '/', '') END							
					SET @prjToDoDoneDateTime = CASE WHEN @prjToDoDoneDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjToDoDoneDate, null) END			 	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjToDoDoneTime'
				BEGIN
					SET @prjToDoDoneTime = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjFOCmpCanInsCnvs'
				BEGIN
					SET @prjFOCmpCanInsCnvs = CASE WHEN @PrjFieldValue = 'null' THEN NULL 
										WHEN @PrjFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjFOCmpCanNotInsCnvs'
				BEGIN
					SET @prjFOCmpCanNotInsCnvs = CASE WHEN @PrjFieldValue = 'null' THEN NULL 
										WHEN @PrjFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjTicketStop'
				BEGIN
					SET @prjTicketStop = CASE WHEN @PrjFieldValue = 'null' THEN NULL 
										WHEN @PrjFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjIsTicketNew'
				BEGIN
					SET @prjIsTicketNew = CASE WHEN @PrjFieldValue = 'null' THEN NULL 
										WHEN @PrjFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/ 
				IF @PrjFieldName = 'prjToDoTimeSec'
				BEGIN
					SET @prjToDoTimeSec = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS BIGINT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjToDoTimeRegisterHistory'
				BEGIN
					SET @prjToDoTimeRegisterHistory = CASE WHEN @PrjFieldValue = '' OR @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END	
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjcmpPresentationId'
				BEGIN
					SELECT @prjcmpPresentationId = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE CAST(@PrjFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @PrjFieldName = 'prjcmpCampaignIds'
				BEGIN
					SELECT @prjcmpCampaignIds = CASE WHEN @PrjFieldValue = 'null' THEN NULL ELSE @PrjFieldValue END
				END
				/*--------------------------*/
				/*END Project*/		
				/*END GENERAL*/
				/*---------------------------- END Fill variabele --------------------------------*/
				/*---------------------------- Remove current parameter from listparam ------------*/
				SET @PjAllFields = SUBSTRING(@PjAllFields,
                                  LEN(@PrjField + '|#|') + 1,
                                  LEN(@PjAllFields))                                                                                                      
			END
			ELSE
			BEGIN
				SET @PrjField = @PjAllFields
				SET @PjAllFields = NULL
				
			END
		END  
		/************* Insert to tmp table***************/
		/*set date time*/
		IF(@prjStartTime IS NOT NULL AND @prjStartDate IS NOT NULL)
		BEGIN
			SET @prjStartDateTime = CASE WHEN @prjStartDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjStartDate, @prjStartTime) END			 	
		END
		/**/
		IF(@prjFinishedTime IS NOT NULL AND @prjFinishedDate IS NOT NULL)
		BEGIN
			SET @prjFinishedDateTime = CASE WHEN @prjFinishedDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjFinishedDate, @prjFinishedTime) END			 	
		END
		/**/
		IF(@prjToDoDate IS NOT NULL AND @prjToDoTime IS NOT NULL)
		BEGIN
			SET @prjToDoDateTime = CASE WHEN @prjToDoDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjToDoDate, @prjToDoTime) END			 	
		END
		/**/
		IF(@prjToDoRegisterDate IS NOT NULL AND @prjToDoRegisterTime IS NOT NULL)
		BEGIN
			SET @prjToDoRegisterDateTime = CASE WHEN @prjToDoRegisterDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjToDoRegisterDate, @prjToDoRegisterTime) END			 	
		END
		/**/
		IF(@prjToDoDoneDate IS NOT NULL AND @prjToDoDoneTime IS NOT NULL)
		BEGIN
			SET @prjToDoDoneDateTime = CASE WHEN @prjToDoDoneDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@prjToDoDoneDate, @prjToDoDoneTime) END			 	
		END


		INSERT INTO @ProjectTmpTable 
			(
				[ProjectID]  ,
				[prjCompanyId]  ,
				[prjTitle]  ,
				[prjDesc]  ,
				[prjStartDate]  ,
				[prjStartDay]  ,
				[prjStartTime]  ,
				[prjStartDateTime]  ,
				[prjStarterUserId]  ,
				[prjFinishedStatusId]  ,
				[prjIsFinished]  ,
				[prjFinishedDate]  ,
				[prjFinishedDay]  ,
				[prjFinishedTime]  ,
				[prjFinishedDateTime]  ,
				[prjFinishedUserId]  ,
				[prjGradeId]  ,
				[prjPriorityId]  ,
				[prjFirstRegisterUserId]  ,
				[prjGroupId]  ,
				[prjcnvsStatusGroupId]  ,
				[prjOrderView]  ,
				[prjPostFix]  ,
				[prjFirstRegisterDatePersian]  ,
				[prjFirstRegisterDate]  ,
				[prjRemindDate]  ,
				[prjRemindDateTime]  ,
				[prjInsertForbidden],
				[prjFOCmpCanSee] ,
				[prjIsTicket] ,
				[prjUserDepartmentId],
				[prjHaveSms],
				[prjSmsPrsIds],
				[prjSmsText],
				[prjSmsSendDate] ,
				[prjSmsSendDatePersian],
				[prjInquiryNum] ,
				[prjSubject] ,
				[prjTitleGroup] ,
				[prjCategoryId] ,
				[prjDescI] ,
				[prjNumRef] ,
				[prjNumR],
				[prjToDoDateTime],
				[prjToDoRegisterDateTime],
				[prjToDoDoneDateTime],
				[prjFOCmpCanInsCnvs],
				[prjFOCmpCanNotInsCnvs],
				[prjTicketStop],
				[prjIsTicketNew],
				[prjToDoTimeSec],
				[prjToDoTimeRegisterHistory],
				[prjcmpPresentationId],
				[prjcmpCampaignIds]
			)
			VALUES
			(
				@ProjectID  ,
				@prjCompanyId  ,
				@prjTitle  ,
				@prjDesc  ,
				@prjStartDate  ,
				@prjStartDay  ,
				@prjStartTime  ,
				@prjStartDateTime  ,
				@prjStarterUserId  ,
				@prjFinishedStatusId  ,
				@prjIsFinished  ,
				@prjFinishedDate  ,
				@prjFinishedDay  ,
				@prjFinishedTime  ,
				@prjFinishedDateTime  ,
				@prjFinishedUserId  ,
				@prjGradeId  ,
				@prjPriorityId  ,
				@prjFirstRegisterUserId  ,
				@prjGroupId  ,
				@prjcnvsStatusGroupId  ,
				@prjOrderView  ,
				@prjPostFix  ,
				@prjFirstRegisterDatePersian  ,
				@prjFirstRegisterDate  ,
				@prjRemindDate  ,
				@prjRemindDateTime  ,
				@prjInsertForbidden  ,	
				@prjFOCmpCanSee ,
				@prjIsTicket ,
				@prjUserDepartmentId,
				@prjHaveSms,
				@prjSmsPrsIds,
				@prjSmsText ,
				@prjSmsSendDate ,
				@prjSmsSendDatePersian ,
				@prjInquiryNum,
				@prjSubject,
				@prjTitleGroup,
				@prjCategoryId,
				@prjDescI,
				@prjNumRef,
				@prjNumR,
				@prjToDoDateTime,
				@prjToDoRegisterDateTime,
				@prjToDoDoneDateTime,
				@prjFOCmpCanInsCnvs,
				@prjFOCmpCanNotInsCnvs,
				@prjTicketStop,
				@prjIsTicketNew,
				@prjToDoTimeSec,
				@prjToDoTimeRegisterHistory,
				@prjcmpPresentationId,
				@prjcmpCampaignIds
			) 										                      
		/*END PROJETC*/		
        /*END GENERAL*/
        /*---------------------------- END Fill fields ------------------------------------*/
        /*---------------------------- Remove current parameter from listparam ------------*/
        SET @ProjectList = SUBSTRING(@ProjectList,
                                  LEN(@PrjAllFields + '|^#^|') + 1,
                                  LEN(@ProjectList))                                  
    END
    ELSE
    BEGIN
        SET @PrjAllFields = @ProjectList
        SET @ProjectList = NULL
        
    END
END
/**/
IF (@@ERROR > 0)
BEGIN SET @ErrorFrom='Error In Input Project' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END		
ELSE 
COMMIT TRAN 
/********************************************************************************/
/****************************** Conversation ************************************/
/********************************************************************************/
BEGIN TRAN
/**/
DECLARE @CnvsAllFields NVARCHAR(MAX) = NULL
DECLARE @CnvsField NVARCHAR(MAX) = NULL
/**************** Define & set null field **************/
DECLARE 
	@ConversationID INT = NULL,
	@cnvsProjectId INT = NULL,
	@cnvsCompanyId INT = NULL,
	@cnvsDate NVARCHAR(8) = NULL,
	@cnvsDay NVARCHAR(20) = NULL,
	@cnvsTime NVARCHAR(15) = NULL,
	@cnvsDateTime DATETIME = NULL,
	@cnvsTopicId INT = NULL,
	@cnvsSubject NVARCHAR(50) = NULL,
	@cnvsDesc NVARCHAR(MAX) = NULL, /*AI14020530*/
	@cnvsPersonId INT = NULL,
	@cnvsUserId INT = NULL,
	@cnvsReferUserId INT = NULL,
	@cnvsReferDesc NVARCHAR(500) = NULL,
	@cnvsStatusId INT = NULL,
	@cnvsPriorityId INT = NULL,
	@cnvsRemindDate NVARCHAR(8) = NULL,
	@cnvsRemindTime NVARCHAR(15) = NULL,
	@cnvsRemindDateTime DATETIME = NULL,
	@cnvsRemindOk BIT = NULL,
	@cnvsIsBookMark BIT = NULL,
	@cnvsFirstRegisterUserId INT = NULL,
	@cnvsFirstRegisterDatePersian NVARCHAR(8) = NULL,
	@cnvsFirstRegisterDate DATETIME = NULL,		
	@cnvsRemindDateForAllarm NVARCHAR(8) = NULL,
	@cnvsRemindDateTimeForAllarm DATETIME = NULL,
	@ApiId NVARCHAR(200) = NULL,	
	@cnvsCoordinateLatitude NVARCHAR(100) = NULL,
	@cnvsCoordinateLongitude NVARCHAR(100) = NULL,
	@cnvsCoordinateLastDate DATETIME = NULL,
	@cnvsCoordinateLastDatePersian VARCHAR(8) = NULL,
	@cnvsEventPolicyNeedCheck BIT = NULL ,
	@TmpUserMultiUserText NVARCHAR(MAX) = NULL ,	
	@cnvsFOCmpCanSee BIT = NULL,
	@cnvsIsTicket BIT = NULL,	
	@cnvsTicketIsRead BIT = NULL,
	@cnvsDoingTime TIME(7) = NULL,
	@cnvsIsCopy BIT = NULL,
	@cnvsDoingTimeSec BIGINT,
	@cnvsStatusProcessKindId INT,
	@cnvsStatusGroupId INT,
	@cnvsEmailEventPolicyNeedCheck BIT,
	@cnvsAvoidSendSms BIT,
	@cnvsAvoidSendEmail BIT,
	@cnvsHappyVote INT,
	@cnvsStatusResultId INT,
	@cnvsKnowledgeTankIds NVARCHAR(MAX)

WHILE LEN(@ConversationList) > 0 AND (@ConversationList IS NOT NULL)
BEGIN
	/*@ConversationList = N'cnvdDesc=desc1|&|cnvsTopicId=1|&||^#^|cnvdDesc=desc2|&|cnvsTopicId=2|&||^#^|'*/
    IF PATINDEX('%|^#^|%', @ConversationList) > 0
    BEGIN
        SET @CnvsAllFields = SUBSTRING(@ConversationList,
                                    0,
                                    PATINDEX('%|^#^|%', @ConversationList))
        /*--------------------------------------------------------------------------------*/
        /*For example => @CnvsAllFields = cnvdDesc=desc1|&|cnvsTopicId=1|&|*/
        /*--------------------------------------------------------------------------------*/
        /*---------------------------- BEGIN Fill fields  --------------------------------*/
        /*BEGIN Conversation*/
        DECLARE @CnAllFields NVARCHAR(MAX)
        SET @CnAllFields = @CnvsAllFields
        
        /**************** set null field **************/
         
        SET @ConversationID  = NULL
		SET @cnvsProjectId  = NULL
		SET @cnvsCompanyId  = NULL
		SET @cnvsDate  = NULL
		SET @cnvsDay  = NULL
		SET @cnvsTime  = NULL
		SET @cnvsDateTime  = NULL
		SET @cnvsTopicId  = NULL
		SET @cnvsSubject  = NULL
		SET @cnvsDesc  = NULL
		SET @cnvsPersonId  = NULL
		SET @cnvsUserId  = NULL
		SET @cnvsReferUserId  = NULL
		SET @cnvsReferDesc  = NULL
		SET @cnvsStatusId  = NULL
		SET @cnvsPriorityId  = NULL
		SET @cnvsRemindDate  = NULL
		SET @cnvsRemindTime  = NULL
		SET @cnvsRemindDateTime  = NULL
		SET @cnvsRemindOk  = NULL
		SET @cnvsIsBookMark  = NULL
		SET @cnvsFirstRegisterUserId  = NULL
		SET @cnvsFirstRegisterDatePersian  = NULL
		SET @cnvsFirstRegisterDate  = NULL		
		SET @cnvsRemindDateForAllarm  = NULL
		SET @cnvsRemindDateTimeForAllarm  = NULL
		SET @ApiId  = NULL	
		SET @cnvsCoordinateLatitude  = NULL
		SET @cnvsCoordinateLongitude  = NULL
		SET @cnvsCoordinateLastDate  = NULL
		SET @cnvsCoordinateLastDatePersian  = NULL
		SET @cnvsEventPolicyNeedCheck  = NULL 
		SET @TmpUserMultiUserText  = NULL    
		SET @cnvsFOCmpCanSee = NULL
		SET @cnvsIsTicket = NULL	
		SET @cnvsTicketIsRead = NULL
		SET @cnvsDoingTime = NULL
		SET @cnvsIsCopy  = NULL
		SET @cnvsDoingTimeSec = NULL
		SET @cnvsStatusProcessKindId = NULL
		SET @cnvsStatusGroupId = NULL
		SET @cnvsEmailEventPolicyNeedCheck = NULL
		SET @cnvsAvoidSendSms = NULL
		SET @cnvsAvoidSendEmail = NULL
		SET @cnvsHappyVote = NULL
        /**/
        WHILE LEN(@CnAllFields) > 0
		BEGIN
			IF PATINDEX('%|#|%', @CnAllFields) > 0
			BEGIN
				SET @CnvsField = SUBSTRING(@CnAllFields,
											0,
											PATINDEX('%|#|%', @CnAllFields))
				/*--------------------------------------------------------------------------------*/
				/*Get parameter name and split value form parameter*/
				/*For example => cnvsTopicId=102 => cnvsTopicId= => cnvsTopicId => Compare => value*/
				DECLARE @CnvsFieldValue NVARCHAR(MAX)
				DECLARE @CnvsFieldName NVARCHAR(200)
				SET @CnvsFieldName = SUBSTRING(@CnvsField, 1, CHARINDEX('=',@CnvsField)-1)                                    
				SET @CnvsFieldValue = SUBSTRING(@CnvsField, CHARINDEX('=', @CnvsField)+1, Len(@CnvsField))
				/*--------------------------------------------------------------------------------*/
				/*---------------------------- BEGIN Fill variabele ------------------------------*/
				/*BEGIN Conversation*/
				/*--------------------------*/
				IF @CnvsFieldName = 'ConversationID'
				BEGIN
					SELECT @ConversationID = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsProjectId'
				BEGIN
					SELECT @cnvsProjectId = CASE WHEN @CnvsFieldValue  = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsCompanyId'
				BEGIN
					SELECT @cnvsCompanyId = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsDate'
				BEGIN
					SET @cnvsDate = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE REPLACE(@CnvsFieldValue, '/', '') END							
					SET @cnvsDateTime = CASE WHEN @cnvsDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@cnvsDate, null) END			 	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsDay'
				BEGIN
					SET @cnvsDay = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsTime'
				BEGIN
					SET @cnvsTime = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsTopicId'
				BEGIN
					SELECT @cnvsTopicId = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsSubject'
				BEGIN
					SET @cnvsSubject = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsDesc'
				BEGIN
					SET @cnvsDesc = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END	
					/*--------------------------*/
					DECLARE @CnvsDescExtra NVARCHAR(MAX) = ''

					IF(ISNULL(@cmpTitleId,0) <> 0)
					BEGIN
					/**/
						SET @CnvsDescExtra = ISNULL((SELECT TOP(1) CompanyTitle FROM [dbo].[CrmCompanyTitle] CT WHERE CT.[CompanyTitleID] = @cmpTitleId) + ' ' ,'') 
					/**/
					END
					SET @CnvsDescExtra = ISNULL(@CnvsDescExtra,'') + ISNULL(@cmpName,'') + N' (' 

					/*-------------*/
					IF(ISNULL(@prsTitleId,0) <> 0)
					BEGIN
					/**/
						SET @CnvsDescExtra = ISNULL(@CnvsDescExtra,'') + (ISNULL((SELECT PersonTitle FROM [dbo].[CrmPersonTitle] PT WHERE PT.PersonTitleID = @prsTitleId) + ' ' ,'')) 
					/**/
					END
					SET @CnvsDescExtra = ISNULL(@CnvsDescExtra,'') + ISNULL(@prsFName + ' ' ,'') + ISNULL(@prsLName ,'') + N')'
					IF(ISNULL(@cnvsDesc,'') <> '')
					BEGIN
						SET @cnvsDesc = ISNULL(@cnvsDesc,'') + NCHAR(13) + NCHAR(10) + N'مخاطب تکراری نام هنگام ثبت : ' + ISNULL(@CnvsDescExtra,'')	
					END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsPersonId'
				BEGIN
					SELECT @cnvsPersonId = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsUserId'
				BEGIN
					SELECT @cnvsUserId = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsReferUserId'
				BEGIN
					SELECT @cnvsReferUserId = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsReferDesc'
				BEGIN
					SET @cnvsReferDesc = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsStatusId'
				BEGIN
					SELECT @cnvsStatusId = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsPriorityId'
				BEGIN
					SELECT @cnvsPriorityId = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsRemindDate'
				BEGIN
					SET @cnvsRemindDate = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE REPLACE(@CnvsFieldValue, '/', '') END	
					SET @cnvsRemindDateTime = CASE WHEN @cnvsRemindDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@cnvsRemindDate, null) END			 	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsRemindTime'
				BEGIN
					SET @cnvsRemindTime = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsRemindOk'
				BEGIN
					SET @cnvsRemindOk = CASE WHEN @CnvsFieldValue = 'null' THEN NULL 
										WHEN @CnvsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsIsBookMark'
				BEGIN
					SET @cnvsIsBookMark = CASE WHEN @CnvsFieldValue = 'null' THEN NULL 
										WHEN @CnvsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsFirstRegisterUserId'
				BEGIN
					SELECT @cnvsFirstRegisterUserId = CASE WHEN @CnvsFieldValue= 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsFirstRegisterDatePersian'
				BEGIN
					SET @cnvsFirstRegisterDatePersian = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE REPLACE(@CnvsFieldValue, '/', '') END							
					SET @cnvsFirstRegisterDate = CASE WHEN @cnvsFirstRegisterDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@cnvsFirstRegisterDatePersian, null) END			 	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsRemindDateForAllarm'
				BEGIN
					SET @cnvsRemindDateForAllarm = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE REPLACE(@CnvsFieldValue, '/', '') END							
					SET @cnvsRemindDateTimeForAllarm = CASE WHEN @cnvsRemindDateForAllarm IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@cnvsRemindDateForAllarm, null) END			 	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'ApiId'
				BEGIN
					SET @ApiId = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsCoordinateLatitude'
				BEGIN
					SET @cnvsCoordinateLatitude = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsCoordinateLongitude'
				BEGIN
					SET @cnvsCoordinateLongitude = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsEventPolicyNeedCheck'
				BEGIN
					SET @cnvsEventPolicyNeedCheck = CASE WHEN @CnvsFieldValue = 'null' THEN NULL 
										WHEN @CnvsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END  							
				/*--------------------------*/
				IF @CnvsFieldName = 'TmpUserMultiUserText'
				BEGIN
					SET @TmpUserMultiUserText = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END											
				END		
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsFOCmpCanSee'
				BEGIN
					SET @cnvsFOCmpCanSee = CASE WHEN @CnvsFieldValue = 'null' THEN NULL 
										WHEN @CnvsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsIsTicket'
				BEGIN
					SET @cnvsIsTicket = CASE WHEN @CnvsFieldValue = 'null' THEN NULL 
										WHEN @CnvsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsTicketIsRead'
				BEGIN
					SET @cnvsTicketIsRead = CASE WHEN @CnvsFieldValue = 'null' THEN NULL 
										WHEN @CnvsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsDoingTime'
				BEGIN
					SET @cnvsDoingTime = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS TIME(7)) END						
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsIsCopy'
				BEGIN
					SET @cnvsIsCopy = CASE WHEN @CnvsFieldValue = 'null' THEN NULL 
										WHEN @CnvsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END				
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsDoingTimeSec'
				BEGIN
					SET @cnvsDoingTimeSec = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS BIGINT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsStatusProcessKindId'
				BEGIN
					SELECT @cnvsStatusProcessKindId = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsStatusGroupId'
				BEGIN
					SELECT @cnvsStatusGroupId = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsEmailEventPolicyNeedCheck'
				BEGIN
					SET @cnvsEmailEventPolicyNeedCheck = CASE WHEN @CnvsFieldValue = 'null' THEN NULL 
										WHEN @CnvsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsAvoidSendSms'
				BEGIN
					SET @cnvsAvoidSendSms = CASE WHEN @CnvsFieldValue = 'null' THEN NULL 
										WHEN @CnvsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsAvoidSendEmail'
				BEGIN
					SET @cnvsAvoidSendEmail = CASE WHEN @CnvsFieldValue = 'null' THEN NULL 
										WHEN @CnvsFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsHappyVote'
				BEGIN
					SELECT @cnvsHappyVote = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsStatusResultId'
				BEGIN
					SELECT @cnvsStatusResultId = CASE WHEN @CnvsFieldValue = 'null' THEN NULL ELSE CAST(@CnvsFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @CnvsFieldName = 'cnvsKnowledgeTankIds'
				BEGIN
					SET @cnvsKnowledgeTankIds = CASE WHEN @CnvsFieldValue = '' OR @CnvsFieldValue = 'null' THEN NULL ELSE @CnvsFieldValue END	
				END
				/*--------------------------*/
				/*END Conversation*/		
				/*END GENERAL*/
				/*---------------------------- END Fill variabele --------------------------------*/
				/*---------------------------- Remove current parameter from listparam ------------*/
				SET @CnAllFields = SUBSTRING(@CnAllFields,
                                  LEN(@CnvsField + '|#|') + 1,
                                  LEN(@CnAllFields))                                                                                                      
			END
			ELSE
			BEGIN
				SET @CnvsField = @CnAllFields
				SET @CnAllFields = NULL
				
			END
		END  
		/************* Insert to tmp table***************/
		/*set date time*/
		IF(@cnvsTime IS NOT NULL AND @cnvsDate IS NOT NULL)
		BEGIN
			SET @cnvsDateTime = CASE WHEN @cnvsDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@cnvsDate, @cnvsTime) END			 	
		END
		IF(@cnvsTime IS NOT NULL AND @cnvsFirstRegisterDatePersian IS NOT NULL)
		BEGIN
			SET @cnvsFirstRegisterDate = CASE WHEN @cnvsFirstRegisterDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@cnvsFirstRegisterDatePersian, @cnvsTime) END			 	
		END
		/**/
		IF(@cnvsRemindTime IS NOT NULL AND @cnvsRemindDateForAllarm IS NOT NULL)
		BEGIN
			SET @cnvsRemindDateTimeForAllarm = CASE WHEN @cnvsRemindDateForAllarm IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@cnvsRemindDateForAllarm, @cnvsRemindTime) END			 	
		END
		IF((ISNULL(@cnvsCoordinateLatitude, '') <> '') AND (ISNULL(@cnvsCoordinateLongitude, '') <> ''))
		BEGIN
			SET @cnvsCoordinateLastDate = @RegisterDate
			SET @cnvsCoordinateLastDatePersian = @RegisterDatePersian
		END
		IF(ISNULL(@cnvsIsTicket, 0) = 1)
		BEGIN
			SET @cnvsDate = @RegisterDatePersian
			SET @cnvsDay = DATEPART(WEEKDAY, @RegisterDate)
			SET @cnvsTime = @RegisterTime
			SET @cnvsDateTime = @RegisterDate
		END
		INSERT INTO @ConversationTmpTable 
			(
				[ConversationID] ,
				[cnvsProjectId] ,
				[cnvsCompanyId] ,
				[cnvsDate] ,
				[cnvsDay] ,
				[cnvsTime] ,
				[cnvsDateTime] ,
				[cnvsTopicId] ,
				[cnvsSubject] ,
				[cnvsDesc] ,
				[cnvsPersonId] ,
				[cnvsUserId] ,
				[cnvsReferUserId] ,
				[cnvsReferDesc] ,
				[cnvsStatusId] ,
				[cnvsPriorityId] ,
				[cnvsRemindDate] ,
				[cnvsRemindTime] ,
				[cnvsRemindDateTime] ,
				[cnvsRemindOk] ,
				[cnvsIsBookMark] ,
				[cnvsFirstRegisterUserId] ,
				[cnvsFirstRegisterDatePersian] ,
				[cnvsFirstRegisterDate] ,		
				[cnvsRemindDateForAllarm] ,
				[cnvsRemindDateTimeForAllarm] ,
				[ApiId] ,	
				[cnvsCoordinateLatitude] ,
				[cnvsCoordinateLongitude] ,
				[cnvsCoordinateLastDate] ,
				[cnvsCoordinateLastDatePersian] ,
				[cnvsEventPolicyNeedCheck],
				[TmpUserMultiUserText],
				[cnvsFOCmpCanSee] ,
				[cnvsIsTicket] ,	
				[cnvsTicketIsRead] ,
				[cnvsDoingTime] ,
				[cnvsIsCopy] ,
				[cnvsDoingTimeSec],
				[cnvsStatusProcessKindId],
				[cnvsStatusGroupId],
				[cnvsEmailEventPolicyNeedCheck],
				[cnvsAvoidSendSms],
				[cnvsAvoidSendEmail],
				[cnvsHappyVote],
				[cnvsStatusResultId],
				[cnvsKnowledgeTankIds]
			)
			VALUES
			(
				@ConversationID ,
				@cnvsProjectId ,
				@cnvsCompanyId ,
				@cnvsDate ,
				@cnvsDay ,
				@cnvsTime ,
				@cnvsDateTime ,
				@cnvsTopicId ,
				@cnvsSubject ,
				@cnvsDesc ,
				@cnvsPersonId ,
				@cnvsUserId ,
				@cnvsReferUserId ,
				@cnvsReferDesc ,
				@cnvsStatusId ,
				@cnvsPriorityId ,
				@cnvsRemindDate ,
				@cnvsRemindTime ,
				@cnvsRemindDateTime ,
				@cnvsRemindOk ,
				@cnvsIsBookMark ,
				@cnvsFirstRegisterUserId ,
				@cnvsFirstRegisterDatePersian ,
				@cnvsFirstRegisterDate ,		
				@cnvsRemindDateForAllarm ,
				@cnvsRemindDateTimeForAllarm ,
				@ApiId ,	
				@cnvsCoordinateLatitude ,
				@cnvsCoordinateLongitude ,
				@cnvsCoordinateLastDate ,
				@cnvsCoordinateLastDatePersian ,
				@cnvsEventPolicyNeedCheck ,
				@TmpUserMultiUserText ,
				@cnvsFOCmpCanSee ,
				@cnvsIsTicket ,	
				@cnvsTicketIsRead ,
				@cnvsDoingTime ,
				@cnvsIsCopy ,
				@cnvsDoingTimeSec,
				@cnvsStatusProcessKindId,
				@cnvsStatusGroupId,
				@cnvsEmailEventPolicyNeedCheck,
				@cnvsAvoidSendSms,
				@cnvsAvoidSendEmail,
				@cnvsHappyVote,
				@cnvsStatusResultId,
				@cnvsKnowledgeTankIds
			)					                      
		/*END Conversation*/		
        /*END GENERAL*/
        /*---------------------------- END Fill fields ------------------------------------*/
        /*---------------------------- Remove current parameter from listparam ------------*/
        SET @ConversationList = SUBSTRING(@ConversationList,
                                  LEN(@CnvsAllFields + '|^#^|') + 1,
                                  LEN(@ConversationList))                                  
    END
    ELSE
    BEGIN
        SET @CnvsAllFields = @ConversationList
        SET @ConversationList = NULL
        
    END
END
/**/
IF (@@ERROR > 0)
BEGIN SET @ErrorFrom='Error In Input Conversation' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END		
ELSE 
COMMIT TRAN 

DECLARE @InsertPrjId INT, @InsertCnvsId INT
DECLARE @InsertedPrjIdsInMobAndDb NVARCHAR(500) = ''


IF (@ProjectList IS NOT NULL)
BEGIN
	IF(ISNULL(@IsDuplicate,0) = 0) /* @IsDuplicate = 0 ====> insert to main table*/
	BEGIN
		DECLARE CrsrPrj Cursor For
				SELECT 
					[ProjectID], [prjCompanyId], [prjTitle], [prjDesc], [prjStartDate], [prjStartDay], [prjStartTime],
					[prjStartDateTime], [prjStarterUserId], [prjFinishedStatusId], [prjIsFinished], [prjFinishedDate],
					[prjFinishedDay], [prjFinishedTime], [prjFinishedDateTime], [prjFinishedUserId], [prjGradeId],
					[prjPriorityId], [prjFirstRegisterUserId], [prjGroupId], [prjcnvsStatusGroupId], [prjOrderView], [prjPostFix],
					[prjFirstRegisterDatePersian], [prjFirstRegisterDate], [prjRemindDate], [prjRemindDateTime], [prjInsertForbidden],
					[prjFOCmpCanSee], [prjIsTicket], [prjUserDepartmentId],[prjHaveSms],[prjSmsPrsIds],[prjSmsText],
					[prjSmsSendDate] ,[prjSmsSendDatePersian],[prjInquiryNum] ,[prjSubject] ,[prjTitleGroup] ,[prjCategoryId] ,
					[prjDescI] ,[prjNumRef] ,[prjNumR]
					, [prjToDoDateTime], [prjToDoRegisterDateTime], [prjToDoDoneDateTime], [prjFOCmpCanInsCnvs], [prjFOCmpCanNotInsCnvs], [prjTicketStop], [prjIsTicketNew]
					,[prjToDoTimeSec] , [prjToDoTimeRegisterHistory] , [prjcmpPresentationId], [prjcmpCampaignIds]

				FROM @ProjectTmpTable		
			/**/
			OPEN CrsrPrj
			FETCH NEXT FROM CrsrPrj INTO @ProjectID, @prjCompanyId, @prjTitle, @prjDesc, @prjStartDate, @prjStartDay, @prjStartTime,
					@prjStartDateTime, @prjStarterUserId, @prjFinishedStatusId, @prjIsFinished, @prjFinishedDate,
					@prjFinishedDay, @prjFinishedTime, @prjFinishedDateTime, @prjFinishedUserId, @prjGradeId,
					@prjPriorityId, @prjFirstRegisterUserId, @prjGroupId, @prjcnvsStatusGroupId, @prjOrderView, @prjPostFix,
					@prjFirstRegisterDatePersian, @prjFirstRegisterDate, @prjRemindDate, @prjRemindDateTime, @prjInsertForbidden,
					@prjFOCmpCanSee, @prjIsTicket, @prjUserDepartmentId,@prjHaveSms,@prjSmsPrsIds,@prjSmsText ,@prjSmsSendDate ,
					@prjSmsSendDatePersian ,@prjInquiryNum,@prjSubject,@prjTitleGroup,@prjCategoryId,@prjDescI,@prjNumRef,@prjNumR
					,@prjToDoDateTime, @prjToDoRegisterDateTime, @prjToDoDoneDateTime, @prjFOCmpCanInsCnvs, @prjFOCmpCanNotInsCnvs, @prjTicketStop, @prjIsTicketNew
					,@prjToDoTimeSec, @prjToDoTimeRegisterHistory, @prjcmpPresentationId, @prjcmpCampaignIds
			WHILE @@Fetch_Status = 0
			BEGIN
			/**/
	
					/**************NumRef Check Dup****************/
					IF EXISTS (
					SELECT * FROM dbo.CrmsysRollPermission
					WHERE FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' )
					AND FormActionId = (SELECT Id FROM dbo.CrmsysFormActions WHERE ActionName = N'actAutoCalcNumRef'
										AND FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' ))
					AND RollId = (SELECT TOP 1 RollId FROM dbo.UsersPermission WHERE UserId = @UserId AND PrjId = 11/*CRM*/))
					BEGIN
						EXEC dbo.MobspReturnProjectNumRef
							@prjCompanyId = @CompanyId,
							@prjInquiryNum = @prjInquiryNum,
							@prjNumR = @prjNumR,
							@prjStarterUserId = @prjStarterUserId,
							@languageID = @LanguageID,
							@defaultLanguageID = @DefaultLanguageID,
							@selectedNumRef = @prjNumRef OUTPUT
					END

					IF(ISNULL(@prjNumRef, '') <> '')
					BEGIN
						IF EXISTS (
						SELECT * FROM dbo.CrmsysRollPermission
						WHERE FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' )
						AND FormActionId = (SELECT Id FROM dbo.CrmsysFormActions WHERE ActionName = N'actNotDupNumRef'
											AND FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' ))
						AND RollId = (SELECT TOP 1 RollId FROM dbo.UsersPermission WHERE UserId = @UserId AND PrjId = 11/*CRM*/))
						BEGIN
							EXEC dbo.MobspCheckDuplicatePrjNumRef
								@prjNumRef = @prjNumRef,
								@CurrId = 0,
								@LanguageID = @LanguageID,
								@DefaultLanguageID = @DefaultLanguageID

							IF @@ROWCOUNT > 0
							BEGIN
								SET @IsDuplicate = 1
							END
						END
					END
					/**************PrjDesc Check Dup****************/
					IF(ISNULL(@PrjDesc, '') <> '')
					BEGIN
						IF EXISTS (
						SELECT * FROM dbo.CrmsysRollPermission
						WHERE FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' )
						AND FormActionId = (SELECT Id FROM dbo.CrmsysFormActions WHERE ActionName = N'actNotCanSavePrjDescDup'
											AND FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' ))
						AND RollId = (SELECT TOP 1 RollId FROM dbo.UsersPermission WHERE UserId = @UserId AND PrjId = 11/*CRM*/))
						BEGIN
							EXEC [MobspCheckDuplicatePrjDesc]
								@PrjDesc = @PrjDesc,
								@CurrId = 0,
								@LanguageID = @LanguageID,
								@DefaultLanguageID = @DefaultLanguageID

							IF @@ROWCOUNT > 0
							BEGIN
								SET @IsDuplicate = 1
							END
						END
					END
					/**************PostFix Check Dup****************/
					IF(ISNULL(@PrjPostFix, '') <> '')
					BEGIN
						IF EXISTS (
						SELECT * FROM dbo.CrmsysRollPermission
						WHERE FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' )
						AND FormActionId = (SELECT Id FROM dbo.CrmsysFormActions WHERE ActionName = N'actNotCanSavePrjPostFixDup'
											AND FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' ))
						AND RollId = (SELECT TOP 1 RollId FROM dbo.UsersPermission WHERE UserId = @UserId AND PrjId = 11/*CRM*/))
						BEGIN
							EXEC [MobspCheckDuplicatePrjPostFix]
								@PrjPostFix = @PrjPostFix,
								@CurrId = 0,
								@LanguageID = @LanguageID,
								@DefaultLanguageID = @DefaultLanguageID

							IF @@ROWCOUNT > 0
							BEGIN
								SET @IsDuplicate = 1
							END
						END
					END
					/**************InquiryNum Check Dup****************/
					IF(ISNULL(@prjInquiryNum, '') <> '')
					BEGIN
						IF EXISTS (
						SELECT * FROM dbo.CrmsysRollPermission
						WHERE FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' )
						AND FormActionId = (SELECT Id FROM dbo.CrmsysFormActions WHERE ActionName = N'actNotDupInquiryNumByCmpPrj'
											AND FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' ))
						AND RollId = (SELECT TOP 1 RollId FROM dbo.UsersPermission WHERE UserId = @UserId AND PrjId = 11/*CRM*/))
						BEGIN
							EXEC [MobspCheckDuplicatePrjInquiryNum]
								@CompanyId = @CompanyId,
								@prjInquiryNum = @prjInquiryNum,
								@CurrId = 0,
								@LanguageID = @LanguageID,
								@DefaultLanguageID = @DefaultLanguageID

							IF @@ROWCOUNT > 0
							BEGIN
								SET @IsDuplicate = 1
							END
						END
						ELSE IF EXISTS (
						SELECT * FROM dbo.CrmsysRollPermission
						WHERE FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' )
						AND FormActionId = (SELECT Id FROM dbo.CrmsysFormActions WHERE ActionName = N'actNotDupInquiryNumByAllPrj'
											AND FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmDefineProjects' ))
						AND RollId = (SELECT TOP 1 RollId FROM dbo.UsersPermission WHERE UserId = @UserId AND PrjId = 11/*CRM*/))
						BEGIN
							EXEC [MobspCheckDuplicatePrjInquiryNum]
								@CompanyId = 0,
								@prjInquiryNum = @prjInquiryNum,
								@CurrId = 0,
								@LanguageID = @LanguageID,
								@DefaultLanguageID = @DefaultLanguageID

							IF @@ROWCOUNT > 0
							BEGIN
								SET @IsDuplicate = 1
							END
						END
					END
					/**************NumR Check Dup****************/
					IF(ISNULL(@prjNumR, 0) <> 0)
					BEGIN
						DECLARE @CantSaveDupPrjNumRByCmpPrj BIT
						DECLARE @CantSaveDupPrjNumRByAllPrj BIT

						SELECT TOP 1 
							@CantSaveDupPrjNumRByCmpPrj = [IsActivePrjNumRByCmpPrj]
							,@CantSaveDupPrjNumRByAllPrj = [IsActivePrjNumRByAllPrj]
						FROM [dbo].[CrmsysSetting]


						IF(@CantSaveDupPrjNumRByCmpPrj = 1)
						BEGIN
							EXEC [MobspCheckDuplicatePrjNumR]
								@CompanyId = @CompanyId,
								@prjNumR = @prjNumR,
								@CurrId = 0,
								@LanguageID = @LanguageID,
								@DefaultLanguageID = @DefaultLanguageID

							IF @@ROWCOUNT > 0
							BEGIN
								SET @IsDuplicate = 1
							END
						END
						ELSE IF(@CantSaveDupPrjNumRByAllPrj = 1)
						BEGIN
							EXEC [MobspCheckDuplicatePrjNumR]
								@CompanyId = 0,
								@prjNumR = @prjNumR,
								@CurrId = 0,
								@LanguageID = @LanguageID,
								@DefaultLanguageID = @DefaultLanguageID

							IF @@ROWCOUNT > 0
							BEGIN
								SET @IsDuplicate = 1
							END
						END
					END

					/*AI14021005 - Add OrderView to project*/
					IF(@prjOrderView IS NULL)
					BEGIN
						EXEC [dbo].[MobspReturnCompanyProjectOrderView]
						@CompanyId  = @CompanyId,
						@prjOrderView = @prjOrderView  OUTPUT
					END
					/*AI14021005 - End*/

					/******************************/
					INSERT INTO [dbo].[CrmProjects]
							([prjCompanyId]
							,[prjTitle]
							,[prjDesc]
							,[prjStartDate]
							,[prjStartDay]
							,[prjStartTime]
							,[prjStartDateTime]
							,[prjStarterUserId]
							,[prjFinishedStatusId]
							,[prjIsFinished]
							,[prjFinishedDate]
							,[prjFinishedDay]
							,[prjFinishedTime]
							,[prjFinishedDateTime]
							,[prjFinishedUserId]
							,[prjGradeId]
							,[prjPriorityId]
							,[prjFirstRegisterDate]
							,[prjFirstRegisterUserId]
							,[UserId]
							,[Year1]
							,[Month1]
							,[RegisterDate]
							,[RegisterDatePersian]
							,[prjGroupId]
							,[prjcnvsStatusGroupId]
							,[prjOrderView]
							,[AppType]
							,[prjPostFix]
							,[LanguageID]
							,[FirstRegisterUserId]
							,[FirstRegisterDateTime]
							,[FirstRegisterDatePersian]
							,[prjFirstRegisterDateTime]
							,[FirstRegisterDate]
							,[prjRemindDate]
							,[prjRemindDateTime]
							,[prjFOCmpCanSee] 
							,[prjIsTicket] 
							,[prjUserDepartmentId]
							,[prjHaveSms]
							,[prjSmsPrsIds]
							,[prjSmsText]
							,[prjSmsSendDate] 
							,[prjSmsSendDatePersian]
							,[prjInquiryNum]
							,[prjSubject] 
							,[prjTitleGroup] 
							,[prjCategoryId] 
							,[prjDescI] 
							,[prjNumRef] 
							,[prjNumR]
							,[prjToDoTimeRegister]
							,[prjToDoTimeDone]
							,[prjFOCmpCanInsCnvs]
							,[prjFOCmpCanNotInsCnvs]
							,[prjTicketStop]
							,[prjIsTicketNew]
							,[prjToDoTimeSec]
							,[prjToDoTimeRegisterHistory]
							,[prjcmpPresentationId]
							,[prjcmpCampaignIds]
						)
						VALUES
							(@CompanyId
							,@prjTitle
							,@prjDesc
							,@prjStartDate
							,@prjStartDay
							,@prjStartTime
							,@prjStartDateTime
							,@prjStarterUserId
							,@prjFinishedStatusId
							,@prjIsFinished
							,@prjFinishedDate
							,@prjFinishedDay
							,@prjFinishedTime
							,@prjFinishedDateTime
							,@prjFinishedUserId
							,@prjGradeId
							,@prjPriorityId
							,@RegisterDatePersian
							,@prjFirstRegisterUserId
							,@UserId
							,@Year1
							,@Month1
							,@RegisterDate
							,@RegisterDatePersian
							,@prjGroupId
							,@prjcnvsStatusGroupId
							,@prjOrderView
							,@AppType
							,@prjPostFix
							,@DefaultLanguageID
							,@prjFirstRegisterUserId
							,@RegisterDate
							,@RegisterDatePersian 
							,@RegisterDate
							,@RegisterDate
							,@prjRemindDate
							,@prjRemindDateTime
							,@prjFOCmpCanSee 
							,@prjIsTicket 
							,@prjUserDepartmentId
							,@prjHaveSms
							,@prjSmsPrsIds
							,@prjSmsText 
							,@prjSmsSendDate 
							,@prjSmsSendDatePersian 
							,@prjInquiryNum
							,@prjSubject
							,@prjTitleGroup
							,@prjCategoryId
							,@prjDescI
							,@prjNumRef
							,@prjNumR
							,@prjToDoRegisterDateTime
							,@prjToDoDoneDateTime
							,@prjFOCmpCanInsCnvs
							,@prjFOCmpCanNotInsCnvs
							,@prjTicketStop
							,@prjIsTicketNew
							,@prjToDoTimeSec
							,@prjToDoTimeRegisterHistory
							,@prjcmpPresentationId
							,@prjcmpCampaignIds
							)           								          													
					SET @InsertPrjId = SCOPE_IDENTITY()
					/******* Insert to lang table ********/
					INSERT INTO [dbo].[CrmProjects_Lang]
						([ProjectID]
						,[LanguageID]
						,[prjTitle]
						,[prjDesc]
						,[prjPostFix])
					SELECT
						@InsertPrjId
						,LN.LanguageID
						,@prjTitle
						,@prjDesc
						,@prjPostFix
					FROM dbo.Languages LN 
					WHERE LN.LanguageID <> @DefaultLanguageID	
					AND LN.IsActive =1
					/***** Insert project informations defualt field *****/						
					EXEC dbo.MobspInsertProjectInformationsDefualtField 
						@ProjectID = @InsertPrjId,
						@UserId = @UserId,
						@Year1 = @Year1,
						@Month1 = @Month1,
						@RegisterDate = @RegisterDate,
						@RegisterDatePersian = @RegisterDatePersian,
						@AppType = @AppType,
						@LanguageID = @DefaultLanguageID,
						@FirstRegisterUserId  = @prjFirstRegisterUserId,
						@FirstRegisterDatePersian = @RegisterDatePersian,
						@FirstRegisterDate = @RegisterDate
					/*********** Insert to Forbidden *********************/
					IF(@prjInsertForbidden = 1)
					BEGIN
						EXEC dbo.MobspInsertCrmProjectsForbiddenForUserFromDefineProject 
						@CrmUserId = @UserId,
						@ForbiddenProjectTitle = @prjTitle,
						@FirstRegisterDate = @prjFirstRegisterDate,
						@FirstRegisterDatePersian = @prjFirstRegisterDatePersian,
						@FirstRegisterUserId  = @prjFirstRegisterUserId,
						@UserId  = @UserId,
						@Year1  = @CurrYear,
						@Month1 = @Month1,
						@RegisterDate = @RegisterDate,
						@RegisterDatePersian = @RegisterDatePersian,
						@AppType = @AppType,
						@LanguageID = @DefaultLanguageID  
					END	
						
					/*************** Ids inserted ********/				
					/*SET @InsertedProjectIds = @InsertedProjectIds + CAST(@InsertPrjId AS NVARCHAR(10)) + '|'*/
					SET @InsertedPrjIdsInMobAndDb = @InsertedPrjIdsInMobAndDb + CAST(@ProjectID AS NVARCHAR(10)) + ',' + CAST(@InsertPrjId AS NVARCHAR(10)) + '|'
					SET @InsertedProjectIds = @InsertedPrjIdsInMobAndDb
			 					
			/**/	
			FETCH NEXT FROM CrsrPrj INTO @ProjectID, @prjCompanyId, @prjTitle, @prjDesc, @prjStartDate, @prjStartDay, @prjStartTime,
					@prjStartDateTime, @prjStarterUserId, @prjFinishedStatusId, @prjIsFinished, @prjFinishedDate,
					@prjFinishedDay, @prjFinishedTime, @prjFinishedDateTime, @prjFinishedUserId, @prjGradeId,
					@prjPriorityId, @prjFirstRegisterUserId, @prjGroupId, @prjcnvsStatusGroupId, @prjOrderView, @prjPostFix,
					@prjFirstRegisterDatePersian, @prjFirstRegisterDate, @prjRemindDate, @prjRemindDateTime, @prjInsertForbidden,
					@prjFOCmpCanSee, @prjIsTicket, @prjUserDepartmentId,@prjHaveSms,@prjSmsPrsIds,@prjSmsText ,@prjSmsSendDate ,
					@prjSmsSendDatePersian ,@prjInquiryNum,@prjSubject,@prjTitleGroup,@prjCategoryId,@prjDescI,@prjNumRef,@prjNumR
					,@prjToDoDateTime, @prjToDoRegisterDateTime, @prjToDoDoneDateTime, @prjFOCmpCanInsCnvs, @prjFOCmpCanNotInsCnvs, @prjTicketStop, @prjIsTicketNew
					,@prjToDoTimeSec, @prjToDoTimeRegisterHistory, @prjcmpPresentationId, @prjcmpCampaignIds
			END
			CLOSE CrsrPrj
			DEALLOCATE CrsrPrj   					 	 	 
	END
END


DECLARE @PrsIdInMob INT , @PrsIdInDb INT, @PrsIdsStr NVARCHAR(500)
	,@PrjIdInMob INT , @PrjIdInDb INT, @PrjIdsStr NVARCHAR(500)
IF(@ConversationList IS NOT NULL)
BEGIN
/*******************************************************/

IF(@InsertedPrjIdsInMobAndDb IS NOT NULL AND @InsertedPrjIdsInMobAndDb <> '')
BEGIN
	/*******************************************************/				
		IF(ISNULL(@IsDuplicate, 0) = 0) /* @IsDuplicate = 0 ====> insert to main table*/
		BEGIN
			DECLARE CrsrCnvs Cursor For
				SELECT 
					[ConversationID], [cnvsProjectId], [cnvsCompanyId], [cnvsDate], [cnvsDay], [cnvsTime], [cnvsDateTime],
					[cnvsTopicId], [cnvsSubject], [cnvsDesc], [cnvsPersonId], [cnvsUserId], [cnvsReferUserId], [cnvsReferDesc],
					[cnvsStatusId], [cnvsPriorityId], [cnvsRemindDate], [cnvsRemindTime], [cnvsRemindDateTime], [cnvsRemindOk],
					[cnvsIsBookMark], [cnvsFirstRegisterUserId], [cnvsFirstRegisterDatePersian], [cnvsFirstRegisterDate],		
					[cnvsRemindDateForAllarm], [cnvsRemindDateTimeForAllarm], [ApiId], [cnvsCoordinateLatitude],
					[cnvsCoordinateLongitude], [cnvsCoordinateLastDate], [cnvsCoordinateLastDatePersian], [cnvsEventPolicyNeedCheck], [TmpUserMultiUserText],
					[cnvsFOCmpCanSee], [cnvsIsTicket], [cnvsTicketIsRead], [cnvsDoingTime], [cnvsIsCopy]
					,[cnvsDoingTimeSec], [cnvsStatusProcessKindId], [cnvsStatusGroupId]
					,[cnvsEmailEventPolicyNeedCheck], [cnvsAvoidSendSms], [cnvsAvoidSendEmail] ,[cnvsHappyVote]
					,[cnvsStatusResultId] ,[cnvsKnowledgeTankIds]
				FROM @ConversationTmpTable																				
			/**/
			OPEN CrsrCnvs
			FETCH NEXT FROM CrsrCnvs INTO @ConversationID, @cnvsProjectId, @cnvsCompanyId, @cnvsDate, @cnvsDay, @cnvsTime, @cnvsDateTime,
					@cnvsTopicId, @cnvsSubject, @cnvsDesc, @cnvsPersonId, @cnvsUserId, @cnvsReferUserId, @cnvsReferDesc,
					@cnvsStatusId, @cnvsPriorityId, @cnvsRemindDate, @cnvsRemindTime, @cnvsRemindDateTime, @cnvsRemindOk,
					@cnvsIsBookMark, @cnvsFirstRegisterUserId, @cnvsFirstRegisterDatePersian, @cnvsFirstRegisterDate,		
					@cnvsRemindDateForAllarm, @cnvsRemindDateTimeForAllarm, @ApiId, @cnvsCoordinateLatitude,
					@cnvsCoordinateLongitude, @cnvsCoordinateLastDate, @cnvsCoordinateLastDatePersian, @cnvsEventPolicyNeedCheck, @TmpUserMultiUserText,
					@cnvsFOCmpCanSee, @cnvsIsTicket, @cnvsTicketIsRead, @cnvsDoingTime, @cnvsIsCopy
					,@cnvsDoingTimeSec, @cnvsStatusProcessKindId, @cnvsStatusGroupId
					,@cnvsEmailEventPolicyNeedCheck, @cnvsAvoidSendSms, @cnvsAvoidSendEmail ,@cnvsHappyVote
					,@cnvsStatusResultId ,@cnvsKnowledgeTankIds
			WHILE @@Fetch_Status = 0
			BEGIN
			/**/
				/******************* check for cnvsProjetc insert in db or not **********************/
				SET @PrjIdInMob = NULL 
				SET @PrjIdInDb = NULL
				SET @PrjIdsStr = NULL
				
				IF(@InsertedPrjIdsInMobAndDb IS NOT NULL AND @InsertedPrjIdsInMobAndDb <> '')
				BEGIN
					IF CHARINDEX(CAST(@cnvsProjectId AS NVARCHAR(10)) + ',',@InsertedPrjIdsInMobAndDb) > 0
					BEGIN
					/**/												
						SET @PrjIdsStr =   (SUBSTRING(@InsertedPrjIdsInMobAndDb,CHARINDEX(CAST(@cnvsProjectId AS NVARCHAR(10)) + ',',@InsertedPrjIdsInMobAndDb), LEN(@InsertedPrjIdsInMobAndDb)))
						SET @PrjIdsStr= (SUBSTRING(@PrjIdsStr,0, PATINDEX('%|%', @PrjIdsStr)))/*PrjidMob,PrjIdDb ====> 3,1520*/
						SET @PrjIdInMob = CAST((SUBSTRING(@PrjIdsStr,0, PATINDEX('%,%', @PrjIdsStr))) AS INT)
						SET @PrjIdInDb = CAST((SUBSTRING(@PrjIdsStr,PATINDEX('%,%', @PrjIdsStr) + 1, LEN(@PrjIdsStr))) AS INT)
						IF(@PrjIdInMob = @cnvsProjectId)
						BEGIN
							/**/

							/*Insert a conversation*/
							INSERT INTO [dbo].[CrmConversation]
								([cnvsProjectId]
								,[cnvsCompanyId]
								,[cnvsDate]
								,[cnvsDay]
								,[cnvsTime]
								,[cnvsDateTime]
								,[cnvsTopicId]
								,[cnvsSubject]
								,[cnvsDesc]
								,[cnvsPersonId]
								,[cnvsUserId]
								,[cnvsReferUserId]
								,[cnvsReferDesc]
								,[cnvsStatusId]
								,[cnvsPriorityId]
								,[cnvsRemindDate]
								,[cnvsRemindTime]
								,[cnvsRemindDateTime]
								,[cnvsRemindOk]
								,[cnvsIsBookMark]
								,[cnvsFirstRegisterUserId]
								,[cnvsFirstRegisterDate]
								,[cnvsFirstRegisterDateTime]
								,[UserId]
								,[Year1]
								,[Month1]
								,[RegisterDate]
								,[RegisterDatePersian]
								,[FirstRegisterDate]
								,[cnvsRemindDateForAllarm]
								,[cnvsRemindDateTimeForAllarm]
								,[AppType]
								,[LanguageID]
								,[FirstRegisterUserId]
								,[FirstRegisterDatePersian]
								,[ApiId]
								,[cnvsCoordinateLatitude]
								,[cnvsCoordinateLongitude]
								,[cnvsCoordinateLastDate]
								,[cnvsCoordinateLastDatePersian] 	
								,[cnvsFOCmpCanSee] 
								,[cnvsIsTicket] 
								,[cnvsTicketIsRead] 
								,[cnvsDoingTime]
								,[cnvsIsCopy] 
								,[cnvsDoingTimeSec]
								,[cnvsStatusProcessKindId]
								,[cnvsStatusGroupId]
								,[cnvsHappyVote]
								,[cnvsStatusResultId]
								,[cnvsKnowledgeTankIds]
							)
							VALUES
								(@PrjIdInDb
								,@CompanyId
								,@cnvsDate
								,@cnvsDay
								,@cnvsTime
								,@cnvsDateTime
								,@cnvsTopicId
								,@cnvsSubject
								,@cnvsDesc
								,@CompanyPersonId
								,@cnvsUserId
								,@cnvsReferUserId
								,@cnvsReferDesc
								,@cnvsStatusId
								,@cnvsPriorityId
								,@cnvsRemindDate
								,@cnvsRemindTime
								,@cnvsRemindDateTime
								,@cnvsRemindOk
								,@cnvsIsBookMark
								,@UserId
								,@RegisterDatePersian
								,@RegisterDate
								,@UserId
								,@Year1
								,@Month1
								,@RegisterDate
								,@RegisterDatePersian
								,@RegisterDate
								,@cnvsRemindDateForAllarm
								,@cnvsRemindDateTimeForAllarm
								,@AppType
								,@LanguageID
								,@UserId
								,@RegisterDatePersian
								,@ApiId
								,@cnvsCoordinateLatitude
								,@cnvsCoordinateLongitude
								,@cnvsCoordinateLastDate
								,@cnvsCoordinateLastDatePersian	
								,@cnvsFOCmpCanSee 
								,@cnvsIsTicket
								,@cnvsTicketIsRead 
								,@cnvsDoingTime
								,@cnvsIsCopy
								,@cnvsDoingTimeSec
								,@cnvsStatusProcessKindId
								,@cnvsStatusGroupId
								,@cnvsHappyVote
								,@cnvsStatusResultId
								,@cnvsKnowledgeTankIds
								)
							SET @InsertCnvsId = SCOPE_IDENTITY()
							/*************** Ids inserted ********/				
							SET @InsertedConversationIds = @InsertedConversationIds + CAST(@ConversationID AS NVARCHAR(10)) + ',' + CAST(@InsertCnvsId AS NVARCHAR(10)) + '|'   /*cnvsIdMob,cnvsIdDb*/
							/**/
						END
						ELSE
							SET @ErrorMessage = @ErrorMessage + '<CNVS><CNVSID>' + CAST(@ConversationID AS NVARCHAR(10))+ '<\CNVSID>' + '<\CNVS>'
					/**/
					END
					ELSE
						SET @ErrorMessage = @ErrorMessage + '<CNVSID>' + CAST(@ConversationID AS NVARCHAR(10)) + '<\CNVSID>' + '<PRJID>' + CAST(@cnvsProjectId AS NVARCHAR(10)) + '<\PRJID>'+ 'Msg=5'	/*not insert cnvsProject */					
				/**/									
				END
				ELSE
					SET @ErrorMessage = @ErrorMessage + '<CNVSID>' + CAST(@ConversationID AS NVARCHAR(10)) + '<\CNVSID>' + '<PRJID>' + CAST(@cnvsProjectId AS NVARCHAR(10)) + '<\PRJID>' + 'Msg=5'	/*not insert cnvsProject */																																		


			/*END	*/																																		
			/**/	
			FETCH NEXT FROM CrsrCnvs INTO @ConversationID, @cnvsProjectId, @cnvsCompanyId, @cnvsDate, @cnvsDay, @cnvsTime, @cnvsDateTime,
					@cnvsTopicId, @cnvsSubject, @cnvsDesc, @cnvsPersonId, @cnvsUserId, @cnvsReferUserId, @cnvsReferDesc,
					@cnvsStatusId, @cnvsPriorityId, @cnvsRemindDate, @cnvsRemindTime, @cnvsRemindDateTime, @cnvsRemindOk,
					@cnvsIsBookMark, @cnvsFirstRegisterUserId, @cnvsFirstRegisterDatePersian, @cnvsFirstRegisterDate,		
					@cnvsRemindDateForAllarm, @cnvsRemindDateTimeForAllarm, @ApiId, @cnvsCoordinateLatitude,
					@cnvsCoordinateLongitude, @cnvsCoordinateLastDate, @cnvsCoordinateLastDatePersian, @cnvsEventPolicyNeedCheck, @TmpUserMultiUserText,	
					@cnvsFOCmpCanSee, @cnvsIsTicket, @cnvsTicketIsRead, @cnvsDoingTime, @cnvsIsCopy
					,@cnvsDoingTimeSec, @cnvsStatusProcessKindId, @cnvsStatusGroupId
					,@cnvsEmailEventPolicyNeedCheck, @cnvsAvoidSendSms, @cnvsAvoidSendEmail ,@cnvsHappyVote
					,@cnvsStatusResultId ,@cnvsKnowledgeTankIds
		END
			CLOSE CrsrCnvs
			DEALLOCATE CrsrCnvs					 	 	 
		END
	/*******************************************************/																
END
ELSE/*Not insert projects*/	
	SET @ErrorMessage = @ErrorMessage + '|Msg=4' 																																	

/*******************************************************/
END



IF((@ErrorMessage IS NOT NULL AND @ErrorMessage <> '') OR @IsDuplicate = 1)
BEGIN
	ROLLBACK TRANSACTION Main
 	SELECT 1
END

IF (@ErrorNumber > 0)
BEGIN 
	RAISERROR('Error From TransAction %S', 16, 1, @ErrorFrom)
	ROLLBACK TRANSACTION Main
 	SELECT 0
END 
ELSE
BEGIN
	COMMIT TRANSACTION Main  	
 	SELECT 1
END	

END

END





