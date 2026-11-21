




/*AI14000725*/
/*AI14010302 - Change 0 to null for ordIOrderView*/
/*AI14010423 - Add orditem field*/
/*AI14010606 - Add field*/
/*AI14010614 - Add field*/
/*AI14010706 - Add field*/
/*AI14010913 - Add field*/
/*AI14011005 - Set NULL VerifiedRegisterDate*/
/*AI14020119 - Add field*/
/*AI14020327 - Add field to Payment*/
/*AI14020407 - Add field to order*/
/*AI14020420 - Add ordTspSettingId*/
/*AI14020502 - allow field to be set as 0*/
/*AI14020530 - Add params for MobspReturnPrdQuantity*/
/*AI14020627 - Add MobspInsertOrderItemFromLinkedPrd*/
/*AI14020701 - Add field to Payment*/
/*AI14020710 - Add field to item*/
/*AI14020716 - Add field to order*/
/*AI14020803 - Add field to item*/
/*AI14020815 - Add field to payment*/
/*AI14020830 - UpdateOrderLinkAccConflictByPay*/
/*GHO14030211 - Add field to payment*/
CREATE PROCEDURE [dbo].[MobspInsertOrderFull]
/*
	EXEC MobspInsertOrderFull
*/
(
@Order NVARCHAR(MAX),
@OrdItemList NVARCHAR(MAX) = NULL,
@OrdPaymentList NVARCHAR(MAX) = NULL,
@UserId INT,
@Year1 SMALLINT,
@FPId INT,
@Month1 SMALLINT,
@RegisterDate DATETIME,
@RegisterDatePersian NVARCHAR(8),
@AppType VARCHAR(20), 
@LanguageID INT = NULL,
@DefaultLanguageID INT = NULL,
@ActCanNotSelectWithNoStock BIT,
/**/
@InsertedOrderId INT OUTPUT,
@InsertedOrdItemIds NVARCHAR(1000) OUTPUT,
@InsertedOrdPaymentIds NVARCHAR(1000) OUTPUT,
@ErrorMessage NVARCHAR(MAX) OUTPUT
)
AS
BEGIN
/**/
/********************************************************************************/
/****************************** TRANSACTION *************************************/
/********************************************************************************/
BEGIN TRANSACTION Main
/**/
/********************************************************************************/
/***************************** Define fields ************************************/
/********************************************************************************/
DECLARE 
/*********** Order ***********/
@OrderId INT,
@OrderOprID INT,
@ordTitle NVARCHAR(1000),
@ordNumber BIGINT,
@ordDate NVARCHAR(8),
@ordDateTime DATETIME,
@ordCompanyId INT,
@ordCompanyPersonId INT,
@ordProjectId INT,
@ordSubject NVARCHAR(1000),
@ordItemCount INT,
@ordItemsAmount NUMERIC(18,2),
@ordInstallAmount NUMERIC(18,2),
@ordDiscount NUMERIC(18,2),
@ordSumAmount NUMERIC(18,2),
@ordTax NUMERIC(18,2),
@ordTaxIndex NUMERIC(18,2),
@ordCalculateTax BIT,
@ordTotalAmount NUMERIC(18,2),
@ordTotalAmountStr NVARCHAR(400),
/*@ordIsVerified BIT,*/
/*@ordVerifiedRegisterDate DATETIME,
@ordVerifiedRegisterDatePersian NVARCHAR(8),*/
@ordStatusId INT,
/*@ordIsFixed BIT,*/
@ordGuarantyId INT,
@ordSpecialWord NVARCHAR(1000),
@ordDescriptionI NVARCHAR(4000),
@ordDescriptionII NVARCHAR(4000),
@ordDescriptionId INT,
@ordPrintFormatId INT,
@ordRLogoId INT,
@ordLLogoId INT,
@ordSigningI NVARCHAR(1000),
@ordSigningII NVARCHAR(1000),
@ordSigningIII NVARCHAR(1000),
@ordAccountNumberI NVARCHAR(1000),
@ordAccountShabaNumberI NVARCHAR(1000),
@ordAccountNumberII NVARCHAR(1000),
@ordAccountShabaNumberII NVARCHAR(1000),
@ordSignatureId INT,
/*@ordImportDate NVARCHAR(8),
@ordImportDateTime DATETIME,*/
/*@ordFirstRegisterUserId INT,
@ordVerifierId INT,*/
@ordSettlementTypeId INT,
@ordDay NVARCHAR(50),
@ordTime NVARCHAR(50),
@ordTransportation NUMERIC(18,2),
@ordReferUserId INT,
@ordDiscountPercent NUMERIC(18,2),
@ordDiscountTitle NVARCHAR(1000),
@ordRound NUMERIC(18,2),
@ordNote NVARCHAR(4000),
@ordcmpTitle NVARCHAR(1000),
@ordDeliveryDate NVARCHAR(8),
@ordDeliveryDateTime DATETIME,
@ordDeliveryTime NVARCHAR(10),
@ordSerial NVARCHAR(50),
@ordVerifierRequestId INT,
@ordVerificationWorkFlowId INT,
@ordCurrencyUnitId INT,
@ordDeliveryTermId INT,
@ordDeliveryEndDate NVARCHAR(8),
@ordDeliveryEndDateTime DATETIME,
@ordDeliveryEndTime NVARCHAR(10),
@ordNumRef NVARCHAR(150),
@ordDefWHId INT,
@ordDefPrdPriceGroupId INT,
@ordSellerId INT,
@ordEmailUsersInfoId INT,
@ordEmailUserDefaultSettingId INT,
@ordSaleCenterId INT,
@ordDefPayTypeId INT, /*AI14010706*/
/*AI14020407*/
@ordDailyCounter BIGINT,
@ordDeadlineDate DATETIME,
@ordDeadlineDatePersian NVARCHAR(8),
@ordDefaultSettingId INT,
/*AI14020407-End*/
/*AI14020716*/
@ordDeliveryDay NVARCHAR(20),
@ordDeliveryEndDay NVARCHAR(20)
/*AI14020716-End*/
/************************************ Current Year ******************************/
DECLARE @RegisterTime NVARCHAR(8)
SET @RegisterTime = (CONVERT(CHAR(8), @RegisterDate, 108))				
/************************************ Error *************************************/
DECLARE @ErrorFrom VARCHAR(50), @ErrorNumber INT
DECLARE @OrderIdInError INT,
		@OrdItemIdsInError NVARCHAR(1000),
		@OrdPaymentIdsInError NVARCHAR(1000)				
SET @OrderIdInError = 0
SET @OrdItemIdsInError = ''
SET @OrdPaymentIdsInError = ''
/************************ Make A Table For OrdItemList *************************/
DECLARE @OrdItemTmpTable TABLE (
	[OrderItemID] INT,
	[ordIOrderId] INT,
	[ordIPrdId] INT,
	[ordIQuantity] FLOAT,
	[ordIPrice] NUMERIC(18,2),
	[ordITotalPrice] NUMERIC(18,2),
	[ordIDescription] NVARCHAR(MAX),
	[ordIQuantityDesc] NVARCHAR(1000),
	[ordIDiscountI] NUMERIC(18,2),
	[ordIDiscount] NUMERIC(18,2),
	[ordIDiscountPercent] NUMERIC(18,2),
	[ordIDiscountIPercent] NUMERIC(18,2),
	[ordIPrdUnitId] INT,
	[ordICurrencyUnitId] INT,
	[ordIOrderView] INT,
	[ordIFCR] FLOAT,
	[ordITax] NUMERIC(18,2),
	[ordITaxIndex] NUMERIC(18,2),
	[ordICalculateTax] BIT,
	[ordINotVisible] BIT,
	[ordIFCRI] FLOAT,
	[ordINotInSum] BIT,
	[ordIWHId] INT,
	[ordIRound] NUMERIC(18,2),
	[ordIRoundPlus] NUMERIC(18,2),
	[ordIPricePartI] NUMERIC(18,2),
	[ordIPricePartII] NUMERIC(18,2),
	[ordIPricePartRate] FLOAT,
	[ordIPrdPriceGroupID] INT,
    [ordITracing] NVARCHAR(200),
	[ordIPriceSum] NUMERIC(18,2),
	[ordIDiscountISum] NUMERIC(18,2),
	[ordIDiscountSum] NUMERIC(18,2),
	[ordITaxSum] NUMERIC(18,2),
    [ordIDeliveryTermId] INT,
	[ordIDeliveryDate] DATETIME,
	[ordIDeliveryDatePersian] NVARCHAR(8),
	/*AI14010423*/
	[ordIValidityExpireDate] DATETIME,
	[ordIValidityExpireDatePersian] NVARCHAR(8),
	/*AI14010423-End*/
	[ordIQuantityTotal] FLOAT, /*AI14010606*/
	[ordIPrdColorId] INT, /*AI14010614*/
	/*AI14010706*/
	[ordIPrdUnitIdI] INT,
	[ordIPrdUnitIRateResult] FLOAT,
	/*AI14010706*/
	/*AI14010913*/
	[ordIPrdValidityCountingNum] INT,
	[ordIPrdValidityCountingMin] INT,
	/*AI14010913-end*/
	[ordIPrdNickname] NVARCHAR(1000), /*AI14020119*/
	[insertLinkedProducts] BIT, /*AI14000204 - Add*/
	/*AI14020710*/
	[ordIDeliveryTime] NVARCHAR(10),
	[ordIDeliveryDay] NVARCHAR(20),
	[ordIDeliveryEndDate] DATETIME,
	[ordIDeliveryEndDatePersian] NVARCHAR(8),
	[ordIDeliveryEndTime] NVARCHAR(10),
	[ordIDeliveryEndDay] NVARCHAR(20),
	[ordIPrdAutoCalcRate] NUMERIC(18,2),
	[ordIDescriptionI] NVARCHAR(MAX),
	/*AI14020710-End*/
	[ordIDeliveryUserId] INT /*AI14020803*/
)
/************************ Make A Table For OrdPaymentList *********************/
DECLARE @OrdPaymentTmpTable TABLE (
	[OrderPaymentId] INT,
	[ordpayImportDate] NVARCHAR(8),
	[ordpayImportDateTime] DATETIME,
	[ordpayTypeId] INT,
	[ordpayOrderId] INT,
	[ordpayDocId] INT,
	[ordpayDocTypeId] INT,
	[ordpayAmount] NUMERIC(18, 2),
	[ordpayDocNumber] NVARCHAR(50),
	[ordpayDocDate] NVARCHAR(8),
	[ordpayDocDateTime] DATETIME,
	[ordpayDescription] NVARCHAR(2000),
	[ordpayDocAmount] NUMERIC(18,2),
	[ordpayBankDocNumber] VARCHAR(50),
	/*AI14020327-Add*/
	[ordpayCompanyMoneyBagId] INT,
	[ordpayDeActive] BIT,
	[ordpayAmountTemp] NUMERIC(18, 2),
	[ordpayFileTypeJson] NVARCHAR(MAX),
	[ordpayCardNumber] NVARCHAR(50),
	/*AI14020327-End*/
	[ordpayAccountNumber] NVARCHAR(50), /*AI14020701*/
	/*AI14020815*/
	[ordpayBankDocDate] DATETIME,
	[ordpayBankDocDatePersian] NVARCHAR(8),
	[ordpayBankDocAmount] NUMERIC(18,2),
	[ordpayBankDocDesc] NVARCHAR(4000),
	[ordpayBankDocDescI]NVARCHAR(4000),
	[ordpayBankDocRegisterUserId] INT,
	[ordpayBankDocRegisterDate] DATETIME,
	[ordpayBankDocRegisterDatePersian] NVARCHAR(8),
	/*AI14020815-End*/
	/*GHO14030211 - Add field to payment*/
	[ordpayDocDateTemp] NVARCHAR(8),
	[ordpayDocDateTimeTemp] DATETIME
	/*GHO14030211 - End*/
)    
/********************************************************************************/
/***************************** Split fields *************************************/
/********************************************************************************/
/********************************************************************************/
/****************************** Order ****************************************/
/********************************************************************************/
BEGIN TRAN
/**/
DECLARE @OrdField NVARCHAR(MAX) = NULL
WHILE LEN(@Order) > 0
BEGIN
    IF PATINDEX('%|#|%', @Order) > 0
    BEGIN
        SET @OrdField = SUBSTRING(@Order,
                                    0,
                                    PATINDEX('%|#|%', @Order))
        /*--------------------------------------------------------------------------------*/
        /*Get parameter name and split value form parameter*/
        /*For example => ordTitle=102 => ordTitle= => ordTitle => Compare => value*/
        DECLARE @OrdFieldValue NVARCHAR(MAX)
        DECLARE @OrdFieldName NVARCHAR(200)
        SET @OrdFieldName = SUBSTRING(@OrdField, 1, CHARINDEX('=',@OrdField)-1)                                    
		SET @OrdFieldValue = SUBSTRING(@OrdField, CHARINDEX('=', @OrdField)+1, Len(@OrdField))
        /*--------------------------------------------------------------------------------*/
        /*---------------------------- BEGIN Fill variabele ------------------------------*/
        /*BEGIN ORDER*/
        IF @OrdFieldName = 'OrderID'
        BEGIN
			SELECT @OrderID = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
			SET @OrderIdInError =  @OrderID /*====> For rollback when have error*/
        END      
		/*--------------------------*/
		IF @OrdFieldName = 'OrderOprID'
        BEGIN
			SELECT @OrderOprID = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END                                                          
        /*--------------------------*/
        IF @OrdFieldName = 'ordTitle'
        BEGIN
			SET @ordTitle = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END		
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordDate'
        BEGIN
			SET @ordDate = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdFieldValue, '/', '') END
			SET @ordDateTime = CASE WHEN @ordDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordDate, @RegisterTime) END		 			
        END
        /*--------------------------*/
		IF @OrdFieldName = 'ordCompanyId'
        BEGIN
			SELECT @ordCompanyId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
		IF @OrdFieldName = 'ordCompanyPersonId'
        BEGIN
			SELECT @ordCompanyPersonId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordProjectId'
        BEGIN
			SELECT @ordProjectId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
		IF @OrdFieldName = 'ordSubject'
        BEGIN
			SET @ordSubject = CASE WHEN @OrdFieldValue = '' THEN NULL ELSE @OrdFieldValue END
		END
        /*--------------------------*/
		IF @OrdFieldName = 'ordItemCount'
		BEGIN
			SELECT @ordItemCount = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordItemsAmount'
		BEGIN
			SELECT @ordItemsAmount = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS NUMERIC(18,2)) END
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordInstallAmount'
		BEGIN
			SELECT @ordInstallAmount = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS NUMERIC(18,2)) END
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordDiscount'
		BEGIN
			SELECT @ordDiscount = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS NUMERIC(18,2)) END
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordSumAmount'
		BEGIN
			SELECT @ordSumAmount = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS NUMERIC(18,2)) END
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordTax'
		BEGIN
			SELECT @ordTax = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS NUMERIC(18,2)) END
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordTaxIndex'
		BEGIN
			SELECT @ordTaxIndex = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS NUMERIC(18,2)) END
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordCalculateTax'
		BEGIN
			SET @ordCalculateTax = CASE WHEN @OrdFieldValue = 'null' THEN NULL 
								WHEN @OrdFieldValue = 'false' THEN 0 
								ELSE 1 END	
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordTotalAmount'
		BEGIN
			SELECT @ordTotalAmount = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS NUMERIC(18,2)) END
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordTotalAmountStr'
        BEGIN
			SET @ordTotalAmountStr = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
		/*IF @OrdFieldName = 'ordIsVerified'
		BEGIN
			SET @ordIsVerified = CASE WHEN @OrdFieldValue = 'null' THEN NULL 
								WHEN @OrdFieldValue = 'false' THEN 0 
								ELSE 1 END	
		END*/
		/*--------------------------*/
		/*IF @OrdFieldName = 'ordVerifierId'
        BEGIN
			SELECT @ordVerifierId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END*/
        /*--------------------------*/
        IF @OrdFieldName = 'ordVerifierRequestId'
        BEGIN
			SELECT @ordVerifierRequestId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
		/*IF @OrdFieldName = 'ordVerifiedRegisterDatePersian'
        BEGIN
			SET @ordVerifiedRegisterDatePersian = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdFieldValue, '/', '') END
			SET @ordVerifiedRegisterDate = CASE WHEN @ordVerifiedRegisterDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordVerifiedRegisterDatePersian, @RegisterTime) END		
        END*/
        /*--------------------------*/
		IF @OrdFieldName = 'ordStatusId'
        BEGIN
			SELECT @ordStatusId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
		/*IF @OrdFieldName = 'ordIsFixed'
		BEGIN
			SET @ordIsFixed = CASE WHEN @OrdFieldValue = 'null' THEN NULL 
								WHEN @OrdFieldValue = 'false' THEN 0 
								ELSE 1 END	
		END*/
		/*--------------------------*/
		IF @OrdFieldName = 'ordGuarantyId'
        BEGIN
			SELECT @ordGuarantyId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordSpecialWord'
        BEGIN
			SET @ordSpecialWord = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordDescriptionI'
        BEGIN
			SET @ordDescriptionI = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordDescriptionII'
        BEGIN
			SET @ordDescriptionII = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordDescriptionId'
        BEGIN
			SELECT @ordDescriptionId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordPrintFormatId'
        BEGIN
			SELECT @ordPrintFormatId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordRLogoId'
        BEGIN
			SELECT @ordRLogoId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordLLogoId'
        BEGIN
			SELECT @ordLLogoId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordSigningI'
        BEGIN
			SET @ordSigningI = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordSigningII'
        BEGIN
			SET @ordSigningII = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordSigningIII'
        BEGIN
			SET @ordSigningIII = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordAccountNumberI'
        BEGIN
			SET @ordAccountNumberI = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordAccountShabaNumberI'
        BEGIN
			SET @ordAccountShabaNumberI = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordAccountNumberII'
        BEGIN
			SET @ordAccountNumberII = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordAccountShabaNumberII'
        BEGIN
			SET @ordAccountShabaNumberII = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
		IF @OrdFieldName = 'ordSignatureId'
        BEGIN
			SELECT @ordSignatureId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
		/*IF @OrdFieldName = 'ordImportDate'
        BEGIN
			SET @ordImportDate = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdFieldValue, '/', '') END
			SET @ordImportDateTime = CASE WHEN @ordImportDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordImportDate, @RegisterTime) END
        END*/
        /*--------------------------*/
		/*IF @OrdFieldName = 'ordFirstRegisterUserId'
        BEGIN
			SELECT @ordFirstRegisterUserId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END*/
		/*--------------------------*/
		IF @OrdFieldName = 'ordSettlementTypeId'
        BEGIN
			SELECT @ordSettlementTypeId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordTransportation'
		BEGIN
			SELECT @ordTransportation = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS NUMERIC(18,2)) END
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordReferUserId'
        BEGIN
			SELECT @ordReferUserId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
        END
        /*--------------------------*/
		IF @OrdFieldName = 'ordDiscountPercent'
		BEGIN
			SELECT @ordDiscountPercent = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS NUMERIC(18,2)) END
		END
		/*--------------------------*/
        IF @OrdFieldName = 'ordDiscountTitle'
        BEGIN
			SET @ordDiscountTitle = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordRound'
		BEGIN
			SELECT @ordRound = CASE WHEN @OrdFieldValue = '0.0' OR @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS NUMERIC(18,2)) END
		END
		/*--------------------------*/
        IF @OrdFieldName = 'ordNote'
		BEGIN
			SELECT @ordNote = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END
		END
		/*--------------------------*/
		IF @OrdFieldName = 'ordcmpTitle'
        BEGIN
			SET @ordcmpTitle = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
        /*--------------------------*/
		IF @OrdFieldName = 'ordDeliveryDate'
        BEGIN
			SET @ordDeliveryDate = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdFieldValue, '/', '') END
			SET @ordDeliveryDateTime = CASE WHEN @ordDeliveryDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordDeliveryDate, null) END		
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordDeliveryTime'
        BEGIN
			SET @ordDeliveryTime = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
		/*--------------------------*/
        IF @OrdFieldName = 'ordSerial'
        BEGIN
			SET @ordSerial = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordVerificationWorkFlowId'
		BEGIN
			SELECT @ordVerificationWorkFlowId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END
		END
		/*--------------------------*/
        IF @OrdFieldName = 'ordCurrencyUnitId'
        BEGIN
			SET @ordCurrencyUnitId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END				
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordDeliveryTermId'
        BEGIN
			SET @ordDeliveryTermId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END				
        END
		/*--------------------------*/       
		IF @OrdFieldName = 'ordDeliveryEndDate'
        BEGIN
			SET @ordDeliveryEndDate = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdFieldValue, '/', '') END
			SET @ordDeliveryEndDateTime = CASE WHEN @ordDeliveryEndDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordDeliveryEndDate, null) END		
        END
        /*--------------------------*/
        IF @OrdFieldName = 'ordDeliveryEndTime'
        BEGIN
			SET @ordDeliveryEndTime = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
	    /*--------------------------*/
		IF @OrdFieldName = 'ordNumRef'
        BEGIN
			SET @ordNumRef = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END
        END
        /*--------------------------*/
		IF @OrdFieldName = 'ordDefWHId'
        BEGIN
			SET @ordDefWHId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordDefPrdPriceGroupId'
        BEGIN
			SET @ordDefPrdPriceGroupId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END				
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordSellerId'
        BEGIN
			SET @ordSellerId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END				
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordEmailUsersInfoId'
        BEGIN
			SET @ordEmailUsersInfoId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END				
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordEmailUserDefaultSettingId'
        BEGIN
			SET @ordEmailUserDefaultSettingId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END				
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordSaleCenterId'
        BEGIN
			SET @ordSaleCenterId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END				
        END
		/*--------------------------*/ /*AI14010706*/
		IF @OrdFieldName = 'ordDefPayTypeId'
        BEGIN
			SET @ordDefPayTypeId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END				
        END
		/*--------------------------*/
		/*AI14020407*/
		IF @OrdFieldName = 'ordDailyCounter'
        BEGIN
			SET @ordDailyCounter = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS BIGINT) END				
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordDeadlineDatePersian'
        BEGIN
			SET @ordDeadlineDatePersian = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdFieldValue, '/', '') END
			SET @ordDeadlineDate = CASE WHEN @ordDeadlineDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordDeadlineDatePersian, @RegisterTime) END	
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordDefaultSettingId'
        BEGIN
			SET @ordDefaultSettingId = CASE WHEN @OrdFieldValue = 'null' THEN NULL ELSE CAST(@OrdFieldValue AS INT) END				
        END
		/*AI14020407-End*/
		/*--------------------------*/
		/*AI14020716*/
        IF @OrdFieldName = 'ordDeliveryDay'
        BEGIN
			SET @ordDeliveryDay = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
		/*--------------------------*/
		IF @OrdFieldName = 'ordDeliveryEndDay'
        BEGIN
			SET @ordDeliveryEndDay = CASE WHEN @OrdFieldValue = '' OR @OrdFieldValue = 'null' THEN NULL ELSE @OrdFieldValue END				
        END
		/*AI14020716-End*/
		/*--------------------------*/
		/*AI14000302 End*/	     
        /*END ORDER*/		
        /*END GENERAL*/
        /*---------------------------- END Fill variabele --------------------------------*/
        /*---------------------------- Remove current parameter from listparam ------------*/
        SET @Order = SUBSTRING(@Order,
                                  LEN(@OrdField + '|#|') + 1,
                                  LEN(@Order))
    END
    ELSE
    BEGIN
        SET @OrdField = @Order
        SET @Order = NULL        
    END
END
/************************** Set date time in Order ************************/
IF(@ordDate IS NOT NULL)
BEGIN
	SET @ordDateTime = CASE WHEN @ordDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordDate, @RegisterTime) END
	SET @ordTime = CAST(CAST(@ordDateTime AS TIME) AS NVARCHAR(8))
	SET @ordDay = DATEPART(dw,@ordDateTime)			 	
END
	
/*IF(@ordImportDate IS NOT NULL)
BEGIN
	SET @ordImportDateTime = CASE WHEN @ordImportDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordImportDate, @RegisterTime) END			 	
END*/
/**/
IF(@ordDeliveryTime IS NOT NULL AND @ordDeliveryDate IS NOT NULL)
BEGIN
	SET @ordDeliveryDateTime = CASE WHEN @ordDeliveryDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordDeliveryDate, @ordDeliveryTime) END			 	
END
/**/
IF (@ordDeliveryEndDate IS NOT NULL AND @ordDeliveryEndTime IS NOT NULL)
BEGIN
	SET @ordDeliveryEndDateTime = CASE WHEN @ordDeliveryEndDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordDeliveryEndDate, @ordDeliveryEndTime) END
END
/**/ /*AI14020407*/
IF (@ordDeadlineDatePersian IS NOT NULL AND @RegisterTime IS NOT NULL)
BEGIN
	SET @ordDeadlineDate = CASE WHEN @ordDeadlineDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordDeadlineDatePersian, NULL) END
END
/*****************************************************************************/						
/**/
IF (@@ERROR > 0)
BEGIN SET @ErrorFrom='Error In Input Order' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END		
ELSE 
COMMIT TRAN 
/**/
/********************************************************************************/
/****************************** OrdItem ****************************************/
/********************************************************************************/
BEGIN TRAN
/**/
DECLARE @OrdIAllFields NVARCHAR(MAX) = NULL
DECLARE @OrdIField NVARCHAR(MAX) = NULL
/**************** Define & set null field **************/
DECLARE 
	@OrderItemID INT = NULL,
	@ordIOrderId INT = NULL,
	@ordIPrdId INT = NULL,
	@ordIQuantity FLOAT = NULL,
	@ordIPrice NUMERIC(18,2) = NULL,
	@ordITotalPrice NUMERIC(18,2) = NULL,
	@ordIDescription NVARCHAR(4000) = NULL,
	@ordIQuantityDesc NVARCHAR(1000) = NULL,
	@ordIDiscount NUMERIC(18,2) = NULL,
	@ordIDiscountI NUMERIC(18,2) = NULL,
	@ordIDiscountPercent NUMERIC(18,2) = NULL,
	@ordIDiscountIPercent NUMERIC(18,2) = NULL,
	@ordIPrdUnitId INT = NULL,
	@ordICurrencyUnitId INT = NULL,
	@ordIOrderView INT = NULL,
	@ordIFCR FLOAT = NULL,
	@ordITax NUMERIC(18,2) = NULL,
	@ordITaxIndex NUMERIC(18,2) = NULL,
	@ordICalculateTax BIT = NULL,
	@ordINotVisible BIT = NULL,
	@ordIFCRI FLOAT = NULL,
	@ordINotInSum BIT = NULL,
	@ordIWHId INT = NULL,
	@ordIRound NUMERIC(18,2) = NULL,
	@ordIRoundPlus NUMERIC(18,2) = NULL,
	@ordIPricePartI NUMERIC(18,2),
	@ordIPricePartII NUMERIC(18,2),
	@ordIPricePartRate FLOAT,
	@ordIPrdPriceGroupID INT = NULL,
	@ordITracing NVARCHAR(200) = NULL,
	@ordIPriceSum NUMERIC(18,2) = NULL,
	@ordIDiscountISum  NUMERIC(18,2) = NULL,
	@ordIDiscountSum  NUMERIC(18,2) = NULL,
	@ordITaxSum NUMERIC(18,2) = NULL,
	@ordIDeliveryTermId INT = NULL,
	@ordIDeliveryDatePersian NVARCHAR(8) = NULL,
	@ordIDeliveryDate DATETIME = NULL,
	@ordIDeliveryTime NVARCHAR(10) = NULL,
	/*AI14010423*/
	@ordIValidityExpireDatePersian NVARCHAR(8) = NULL,
	@ordIValidityExpireDate DATETIME = NULL,
	@ordIValidityExpireTime NVARCHAR(10) = NULL,
	/*AI14010423-End*/
	@ordIQuantityTotal FLOAT = NULL, /*AI14010606*/
	@ordIPrdColorId INT = NULL, /*AI14010614*/
	/*AI14010706*/
	@ordIPrdUnitIdI INT = NULL,
	@ordIPrdUnitIRateResult FLOAT = NULL,
	/*AI14010706-End*/
	/*AI14010913*/
	@ordIPrdValidityCountingNum INT = NULL,
	@ordIPrdValidityCountingMin INT = NULL,
	/*AI14010913-End*/
	@ordIPrdNickname NVARCHAR(1000) = NULL, /*AI14020119*/
	@insertLinkedProducts BIT = NULL, /*AI14000204 - Add*/
	/*AI14020710*/
	@ordIDeliveryDay NVARCHAR(20) = NULL,
	@ordIDeliveryEndDate DATETIME = NULL,
	@ordIDeliveryEndDatePersian NVARCHAR(8) = NULL,
	@ordIDeliveryEndTime NVARCHAR(10) = NULL,
	@ordIDeliveryEndDay NVARCHAR(20) = NULL,
	@ordIPrdAutoCalcRate NUMERIC(18,2) = NULL,
	@ordIDescriptionI NVARCHAR(MAX) = NULL,
	/*AI14020710-End*/
	@ordIDeliveryUserId INT = NULL /*AI14020803*/
WHILE LEN(@OrdItemList) > 0 AND (@OrdItemList IS NOT NULL)
BEGIN
	/*@OrdItemList = N'ordIPrdId=7|#|ordIQuantity=1|#||^#^|ordIPrdId=3|#|ordIQuantity=2|#||^#^|'*/
    IF PATINDEX('%|^#^|%', @OrdItemList) > 0
    BEGIN
        SET @OrdIAllFields = SUBSTRING(@OrdItemList,
                                    0,
                                    PATINDEX('%|^#^|%', @OrdItemList))
        /*--------------------------------------------------------------------------------*/
        /*For example => @OrdIAllFields = ordIPrdId=7|#|ordIQuantity=1|#|*/
        /*--------------------------------------------------------------------------------*/
        /*---------------------------- BEGIN Fill fields  --------------------------------*/
        /*BEGIN ORDITEM*/
        DECLARE @OItemAllFields NVARCHAR(MAX)
        SET @OItemAllFields = @OrdIAllFields
        
        /****************  set null field **************/  
			SET @OrderItemID = NULL
			SET @ordIOrderId = NULL
			SET @ordIPrdId = NULL
			SET @ordIQuantity = NULL
			SET @ordIPrice = NULL
			SET @ordITotalPrice = NULL
			SET @ordIDescription = NULL
			SET @ordIQuantityDesc = NULL
			SET @ordIDiscount = NULL
			SET @ordIDiscountI = NULL
			SET @ordIDiscountPercent = NULL
			SET @ordIDiscountIPercent = NULL
			SET @ordIPrdUnitId = NULL
			SET @ordICurrencyUnitId = NULL
			SET @ordIOrderView = NULL
			SET @ordIFCR = NULL
			SET @ordITax = NULL
			SET @ordITaxIndex = NULL
			SET @ordICalculateTax = NULL
			SET @ordINotVisible = NULL
			SET @ordIFCRI = NULL
			SET @ordINotInSum = NULL
			SET @ordIWHId = NULL
			SET @ordIRound = NULL
			SET @ordIRoundPlus = NULL
			SET @ordIPricePartI = NULL
			SET @ordIPricePartII = NULL
			SET @ordIPricePartRate = NULL
			SET @ordIPrdPriceGroupID = NULL
			SET @ordITracing = NULL
			SET @ordIPriceSum = NULL
			SET @ordIDiscountISum = NULL
			SET @ordIDiscountSum = NULL
			SET @ordITaxSum = NULL
			SET @ordIDeliveryTermId = NULL
			SET @ordIDeliveryDatePersian = NULL
			SET @ordIDeliveryDate = NULL
			SET @ordIDeliveryTime = NULL
			/*AI14010423*/
			SET @ordIValidityExpireDatePersian = NULL
			SET @ordIValidityExpireDate = NULL
			SET @ordIValidityExpireTime = NULL
			/*AI14010423-End*/
			SET @ordIQuantityTotal = NULL /*AI14010606*/
			SET @ordIPrdColorId = NULL /*AI14010614*/
			/*AI14010706*/
			SET @ordIPrdUnitIdI = NULL
			SET @ordIPrdUnitIRateResult = NULL
			/*AI14010706-End*/
			/*AI14010913*/
			SET @ordIPrdValidityCountingNum = NULL
			SET @ordIPrdValidityCountingMin = NULL
			/*AI14010913-End*/
			SET @ordIPrdNickname  = NULL /*AI14020119*/
			SET @insertLinkedProducts = NULL /*AI14000204 - Add*/
			/*AI14020710*/
			SET @ordIDeliveryDay = NULL
			SET @ordIDeliveryEndDate = NULL
			SET @ordIDeliveryEndDatePersian = NULL
			SET @ordIDeliveryEndTime = NULL
			SET @ordIDeliveryEndDay = NULL
			SET @ordIPrdAutoCalcRate = NULL
			SET @ordIDescriptionI = NULL
			/*AI14020710-End*/
			SET @ordIDeliveryUserId = NULL /*AI14020803*/
        /**/

        WHILE LEN(@OItemAllFields) > 0
		BEGIN
			IF PATINDEX('%|#|%', @OItemAllFields) > 0
			BEGIN
				SET @OrdIField = SUBSTRING(@OItemAllFields,
											0,
											PATINDEX('%|#|%', @OItemAllFields))
				/*--------------------------------------------------------------------------------*/
				/*Get parameter name and split value form parameter*/
				/*For example => ordIPrdId=7 => ordIPrdId= => ordIPrdId => Compare => value*/
				DECLARE @OrdIFieldValue NVARCHAR(MAX)
				DECLARE @OrdIFieldName NVARCHAR(200)
				SET @OrdIFieldName = SUBSTRING(@OrdIField, 1, CHARINDEX('=',@OrdIField)-1)                                    
				SET @OrdIFieldValue = SUBSTRING(@OrdIField, CHARINDEX('=', @OrdIField)+1, Len(@OrdIField))
				/*--------------------------------------------------------------------------------*/
				/*---------------------------- BEGIN Fill variabele ------------------------------*/
				/*BEGIN ORDITEM*/
				/*--------------------------*/
				IF @OrdIFieldName = 'OrderItemID'
				BEGIN
					SELECT @OrderItemID = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
					SET @OrdItemIdsInError = @OrdItemIdsInError + CAST(@OrderItemID AS NVARCHAR(10)) + ',0|' /*rollback when have error*/					
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIOrderId'
				BEGIN
					SELECT @ordIOrderId = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPrdId'
				BEGIN
					SELECT @ordIPrdId = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIQuantity'
				BEGIN
					SELECT @ordIQuantity = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS FLOAT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPrice'
				BEGIN
					SELECT @ordIPrice = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordITotalPrice'
				BEGIN
					SELECT @ordITotalPrice = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDescription'
				BEGIN
					SET @ordIDescription = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE @OrdIFieldValue END				
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIQuantityDesc'
				BEGIN
					SET @ordIQuantityDesc = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE @OrdIFieldValue END				
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDiscount'
				BEGIN
					SELECT @ordIDiscount = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDiscountI'
				BEGIN
					SELECT @ordIDiscountI = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDiscountPercent'
				BEGIN
					SELECT @ordIDiscountPercent = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDiscountIPercent'
				BEGIN
					SELECT @ordIDiscountIPercent = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPrdUnitId'
				BEGIN
					SELECT @ordIPrdUnitId = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordICurrencyUnitId'
				BEGIN
					SELECT @ordICurrencyUnitId = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIOrderView'
				BEGIN
					SELECT @ordIOrderView = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END /*AI14010302*/
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIFCR'
				BEGIN
					SELECT @ordIFCR = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS FLOAT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordITax'
				BEGIN
					SELECT @ordITax = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordITaxIndex'
				BEGIN
					SELECT @ordITaxIndex = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordICalculateTax'
				BEGIN
					SET @ordICalculateTax = CASE WHEN @OrdIFieldValue = 'null' THEN NULL 
										WHEN @OrdIFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordINotVisible'
				BEGIN
					SET @ordINotVisible = CASE WHEN @OrdIFieldValue = 'null' THEN NULL 
										WHEN @OrdIFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIFCRI'
				BEGIN
					SELECT @ordIFCRI = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS FLOAT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordINotInSum'
				BEGIN
					SET @ordINotInSum = CASE WHEN @OrdIFieldValue = 'null' THEN NULL 
										WHEN @OrdIFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIWHId'
				BEGIN
					SELECT @ordIWHId = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIRound'
				BEGIN
					SELECT @ordIRound = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIRoundPlus'
				BEGIN
					SELECT @ordIRoundPlus = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPricePartI'
				BEGIN
					SELECT @ordIPricePartI = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPricePartII'
				BEGIN
					SELECT @ordIPricePartII = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPricePartRate'
				BEGIN
					SELECT @ordIPricePartRate = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS FLOAT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPrdPriceGroupID'
				BEGIN
					SELECT @ordIPrdPriceGroupID = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordITracing'
				BEGIN
					SELECT @ordITracing = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE @OrdIFieldValue END /*AI991119*/		
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDiscountISum'
				BEGIN
					SELECT @ordIDiscountISum = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END/*AI991119*/
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDiscountSum'
				BEGIN
					SELECT @ordIDiscountSum = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END/*AI991119*/
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordITaxSum'
				BEGIN
					SELECT @ordITaxSum = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END/*AI991119*/
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPriceSum'
				BEGIN
					SELECT @ordIPriceSum = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END/*AI991119*/
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDeliveryTermId'
				BEGIN
					SELECT @ordIDeliveryTermId = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END/*AI991119*/
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDeliveryDate'
				BEGIN
					SET @ordIDeliveryDatePersian = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdIFieldValue, '/', '') END
					SET @ordIDeliveryDate = CASE WHEN @ordIDeliveryDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordIDeliveryDatePersian, null) END		
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDeliveryTime'
				BEGIN
					SET @ordIDeliveryTime = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE @OrdIFieldValue END				
				END
				/*--------------------------*/																														
				/*AI14010423*/
				IF @OrdIFieldName = 'ordIValidityExpireDate'
				BEGIN
					SET @ordIValidityExpireDatePersian = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdIFieldValue, '/', '') END
					SET @ordIValidityExpireDate = CASE WHEN @ordIValidityExpireDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordIValidityExpireDatePersian, null) END		
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIValidityExpireTime'
				BEGIN
					SET @ordIValidityExpireTime = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE @OrdIFieldValue END				
				END
				/*AI14010423-End*/
				/*--------------------------*/
				/*AI14010606*/
				IF @OrdIFieldName = 'ordIQuantityTotal'
				BEGIN
					SELECT @ordIQuantityTotal = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS FLOAT) END
				END
				/*--------------------------*/ /*AI14010614*/
				IF @OrdIFieldName = 'ordIPrdColorId'
				BEGIN
					SELECT @ordIPrdColorId = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*--------------------------*/
				/*AI14010706*/
				IF @OrdIFieldName = 'ordIPrdUnitIdI'
				BEGIN
					SELECT @ordIPrdUnitIdI = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPrdUnitIRateResult'
				BEGIN
					SELECT @ordIPrdUnitIRateResult = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS FLOAT) END
				END
				/*AI14010706-End*/
				/*--------------------------*/
				/*AI14010913*/
				IF @OrdIFieldName = 'ordIPrdValidityCountingNum'
				BEGIN
					SELECT @ordIPrdValidityCountingNum = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPrdValidityCountingMin'
				BEGIN
					SELECT @ordIPrdValidityCountingMin = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*AI14010913-End*/
				/*--------------------------*/
				/*AI14020119*/
				IF @OrdIFieldName = 'ordIPrdNickname'
				BEGIN
					SET @ordIPrdNickname = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE @OrdIFieldValue END				
				END
				/*--------------------------*/
				/*AI14000204 - Add*/
				IF @OrdIFieldName = 'insertLinkedProducts'
				BEGIN
					SET @insertLinkedProducts = CASE WHEN @OrdIFieldValue = 'null' THEN 0 
					WHEN @OrdIFieldValue = 'false' THEN 0 
					ELSE 1 END
				END
				/*AI14000204 End*/
				/*--------------------------*/
				/*AI14020710*/
				IF @OrdIFieldName = 'ordIDeliveryDay'
				BEGIN
					SET @ordIDeliveryDay = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE @OrdIFieldValue END				
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDeliveryEndDate'
				BEGIN
					SET @ordIDeliveryEndDatePersian = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdIFieldValue, '/', '') END
					SET @ordIDeliveryEndDate = CASE WHEN @ordIDeliveryEndDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordIDeliveryEndDatePersian, null) END		
				END
				/*--------------------------*/
				IF @OrdIFieldName = '@ordIDeliveryEndTime'
				BEGIN
					SET @ordIDeliveryEndTime = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE @OrdIFieldValue END				
				END
				/*--------------------------*/
				IF @OrdIFieldName = '@ordIDeliveryEndDay'
				BEGIN
					SET @ordIDeliveryEndDay = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE @OrdIFieldValue END				
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIPrdAutoCalcRate'
				BEGIN
					SELECT @ordIPrdAutoCalcRate = CASE WHEN @OrdIFieldValue = '0.0' OR @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS NUMERIC(18,2)) END
				END
				/*--------------------------*/
				IF @OrdIFieldName = 'ordIDescriptionI'
				BEGIN
					SET @ordIDescriptionI = CASE WHEN @OrdIFieldValue = '' OR @OrdIFieldValue = 'null' THEN NULL ELSE @OrdIFieldValue END				
				END
				/*AI14020710*/
				/*--------------------------*/ /*AI14020803*/
				IF @OrdIFieldName = 'ordIDeliveryUserId'
				BEGIN
					SELECT @ordIDeliveryUserId = CASE WHEN @OrdIFieldValue = 'null' THEN NULL ELSE CAST(@OrdIFieldValue AS INT) END
				END
				/*--------------------------*/
				/*END ORDITEM*/		
				/*END GENERAL*/
				/*---------------------------- END Fill variabele ---------------------------------*/
				/*---------------------------- Remove current parameter from listparam ------------*/
				SET @OItemAllFields = SUBSTRING(@OItemAllFields,
                                  LEN(@OrdIField + '|#|') + 1,
                                  LEN(@OItemAllFields))                                                                                                      
			END
			ELSE
			BEGIN
				SET @OrdIField = @OItemAllFields
				SET @OItemAllFields = NULL			
			END
		END  
		/************************** Set date time in OrderItem ************************/
		IF(@ordIDeliveryTime IS NOT NULL AND @ordIDeliveryDatePersian IS NOT NULL)
		BEGIN
			SET @ordIDeliveryDate = CASE WHEN @ordIDeliveryDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordIDeliveryDatePersian, @ordIDeliveryTime) END			 	
		END
		/************************** Set date time in OrderItem ************************/ /*AI14010423*/
		IF(@ordIValidityExpireTime IS NOT NULL AND @ordIValidityExpireDatePersian IS NOT NULL)
		BEGIN
			SET @ordIValidityExpireDate = CASE WHEN @ordIValidityExpireDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordIValidityExpireDatePersian, @ordIValidityExpireTime) END			 	
		END
		/************************** Set date time in OrderItem ************************/ /*AI14020710*/
		IF(@ordIDeliveryEndTime IS NOT NULL AND @ordIDeliveryEndDatePersian IS NOT NULL)
		BEGIN
			SET @ordIDeliveryEndDate = CASE WHEN @ordIDeliveryEndDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordIDeliveryEndDatePersian, @ordIDeliveryEndTime) END			 	
		END
		/*****************************************************************************/	
		/************* Insert to tmp table***************/
		INSERT INTO @OrdItemTmpTable 
				 (
					[OrderItemID],
					[ordIOrderId],
					[ordIPrdId],
					[ordIQuantity],
					[ordIPrice],
					[ordITotalPrice],
					[ordIDescription],
					[ordIQuantityDesc],
					[ordIDiscount],
					[ordIDiscountI],
					[ordIDiscountPercent],
					[ordIDiscountIPercent],
					[ordIPrdUnitId],
					[ordICurrencyUnitId],
					[ordIOrderView],
					[ordIFCR],
					[ordITax],
					[ordITaxIndex],
					[ordICalculateTax],
					[ordINotVisible],
					[ordIFCRI],
					[ordINotInSum],
					[ordIWHId],
					[ordIRound],
					[ordIRoundPlus],
					[ordIPricePartI],
					[ordIPricePartII],
					[ordIPricePartRate],
					[ordIPrdPriceGroupID],
					[ordITracing],
					[ordIPriceSum],
					[ordIDiscountISum],
					[ordIDiscountSum],
					[ordITaxSum],
					[ordIDeliveryTermId],
					[ordIDeliveryDate],
					[ordIDeliveryDatePersian],
					/*AI14010423*/
					[ordIValidityExpireDate],
					[ordIValidityExpireDatePersian],
					/*AI14010423-End*/
					[ordIQuantityTotal], /*AI14010606*/
					[ordIPrdColorId], /*AI14010614*/
					/*AI14010706*/
					[ordIPrdUnitIdI],
					[ordIPrdUnitIRateResult],
					/*AI14010706-End*/
					/*AI14010913*/
					[ordIPrdValidityCountingNum],
					[ordIPrdValidityCountingMin],
					/*AI14010913-End*/
					[ordIPrdNickname], /*AI14020119*/
					[insertLinkedProducts], /*AI14000204 - Add*/
					/*AI14020710*/
					[ordIDeliveryTime],
					[ordIDeliveryDay],
					[ordIDeliveryEndDate],
					[ordIDeliveryEndDatePersian],
					[ordIDeliveryEndTime],
					[ordIDeliveryEndDay],
					[ordIPrdAutoCalcRate],
					[ordIDescriptionI],
					/*AI14020710-End*/
					[ordIDeliveryUserId] /*AI14020803*/
				)
				VALUES
				(
					@OrderItemID,
					@ordIOrderId,
					@ordIPrdId,
					@ordIQuantity,
					@ordIPrice,
					@ordITotalPrice,
					@ordIDescription,
					@ordIQuantityDesc,
					@ordIDiscount,
					@ordIDiscountI,
					@ordIDiscountPercent,
					@ordIDiscountIPercent,
					@ordIPrdUnitId,
					@ordICurrencyUnitId,
					@ordIOrderView,
					@ordIFCR,
					@ordITax,
					@ordITaxIndex,
					@ordICalculateTax,
					@ordINotVisible,
					@ordIFCRI,
					@ordINotInSum,
					@ordIWHId,
					@ordIRound,
					@ordIRoundPlus,
					@ordIPricePartI,
					@ordIPricePartII,
					@ordIPricePartRate,
					@ordIPrdPriceGroupID,
					@ordITracing,
					@ordIPriceSum,
					@ordIDiscountISum,
					@ordIDiscountSum,
					@ordITaxSum,
					@ordIDeliveryTermId,
					@ordIDeliveryDate,
					@ordIDeliveryDatePersian,
					/*AI14010423*/
					@ordIValidityExpireDate,
					@ordIValidityExpireDatePersian,
					/*AI14010423*/
					@ordIQuantityTotal, /*AI14010606*/
					@ordIPrdColorId, /*AI14010614*/
					/*AI14010706*/
					@ordIPrdUnitIdI,
					@ordIPrdUnitIRateResult,
					/*AI14010706-End*/
					/*AI14010913*/
					@ordIPrdValidityCountingNum,
					@ordIPrdValidityCountingMin,
					/*AI14010913-End*/
					@ordIPrdNickname, /*AI14020119*/
					@insertLinkedProducts, /*AI14000204 - Add*/
					/*AI14020710*/
					@ordIDeliveryTime,
					@ordIDeliveryDay,
					@ordIDeliveryEndDate,
					@ordIDeliveryEndDatePersian,
					@ordIDeliveryEndTime,
					@ordIDeliveryEndDay,
					@ordIPrdAutoCalcRate,
					@ordIDescriptionI,
					/*AI14020710-End*/
					@ordIDeliveryUserId /*AI14020803*/
				)                                     
		/*END ORDITEM*/		
        /*END GENERAL*/
        /*---------------------------- END Fill fields ------------------------------------*/
        /*---------------------------- Remove current parameter from listparam ------------*/
        SET @OrdItemList = SUBSTRING(@OrdItemList,
                                  LEN(@OrdIAllFields + '|^#^|') + 1,
                                  LEN(@OrdItemList))                                  
    END
    ELSE
    BEGIN
        SET @OrdIAllFields = @OrdItemList
        SET @OrdItemList = NULL        
    END
END
/**/
IF (@@ERROR > 0)
BEGIN SET @ErrorFrom='Error In Input order Item' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END		
ELSE 
COMMIT TRAN 
/**/

/********************************************************************************/
/****************************** OrdPayment *************************************/
/********************************************************************************/
BEGIN TRAN
/**/
DECLARE @OrdPayAllFields NVARCHAR(MAX) = NULL
DECLARE @OrdPayField NVARCHAR(MAX) = NULL
/**************** Define & set null field **************/
DECLARE 
	@OrderPaymentId INT = NULL,
	@ordpayImportDate NVARCHAR(8) = NULL,
	@ordpayImportDateTime DATETIME = NULL,
	@ordpayTypeId INT = NULL,
	@ordpayOrderId INT = NULL,
	@ordpayDocId INT = NULL,
	@ordpayDocTypeId INT = NULL,
	@ordpayAmount NUMERIC(18, 2) = NULL,
	@ordpayDocNumber NVARCHAR(50) = NULL,
	@ordpayDocDate NVARCHAR(8) = NULL,
	@ordpayDocDateTime DATETIME = NULL,
	@ordpayDescription NVARCHAR(2000) = NULL,
	@ordpayDocAmount NUMERIC(18,2) = NULL,
	@ordpayBankDocNumber NVARCHAR(50) = NULL,
	/*AI14020327-Add*/
	@ordpayCompanyMoneyBagId INT = NULL,
	@ordpayDeActive BIT = NULL,
	@ordpayAmountTemp NUMERIC(18, 2) = NULL,
	@ordpayFileTypeJson NVARCHAR(MAX) = NULL,
	@ordpayCardNumber NVARCHAR(50) = NULL,
	/*AI14020327-End*/
	@ordpayAccountNumber NVARCHAR(50) = NULL, /*AI14020701*/
	/*AI14020815*/
	@ordpayBankDocDate DATETIME = NULL,
	@ordpayBankDocDatePersian NVARCHAR(80) = NULL,
	@ordpayBankDocAmount NUMERIC(18,2) = NULL,
	@ordpayBankDocDesc NVARCHAR(4000) = NULL,
	@ordpayBankDocDescI NVARCHAR(4000) = NULL,
	@ordpayBankDocRegisterUserId INT = NULL,
	@ordpayBankDocRegisterDate DATETIME = NULL,
	@ordpayBankDocRegisterDatePersian NVARCHAR(8) = NULL,
	/*AI14020815-End*/
	/*GHO14030211 - Add field to payment*/
	@ordpayDocDateTemp NVARCHAR(8) = NULL,
	@ordpayDocDateTimeTemp DATETIME = NULL
	/*GHOO14030211 - End*/
/**/
WHILE LEN(@OrdPaymentList) > 0 AND (@OrdPaymentList IS NOT NULL)
BEGIN
	/*@OrdPaymentList = N'OrderPaymentId=1|#|OrdpayTypeId=1|#||^#^|OrderPaymentId=2|#|ordpayTypeId=2|#||^#^|'*/
    IF PATINDEX('%|^#^|%', @OrdPaymentList) > 0
    BEGIN
        SET @OrdPayAllFields = SUBSTRING(@OrdPaymentList,
                                    0,
                                    PATINDEX('%|^#^|%', @OrdPaymentList))
        /*--------------------------------------------------------------------------------*/
        /*For example => @OrdPayAllFields = OrderPaymentId=1|#|ordpayTypeId=1|#|*/
        /*--------------------------------------------------------------------------------*/
        /*---------------------------- BEGIN Fill fields  --------------------------------*/
        /*BEGIN ORDPAYMENT*/
        DECLARE @OPayAllFields NVARCHAR(MAX)
        SET @OPayAllFields = @OrdPayAllFields
        
        /**************** set null field **************/
        SET @OrderPaymentId = NULL
		SET @ordpayImportDate = NULL
		SET @ordpayImportDateTime = NULL
		SET @ordpayTypeId = NULL
		SET @ordpayOrderId = NULL
		SET @ordpayDocId = NULL
		SET @ordpayDocTypeId = NULL
		SET @ordpayAmount = NULL
		SET @ordpayDocNumber = NULL
		SET @ordpayDocDate = NULL
		SET @ordpayDocDateTime = NULL
		SET @ordpayDescription = NULL
		SET @ordpayDocAmount = NULL
		SET @ordpayBankDocNumber = NULL
		/*AI14020327-Add*/
		SET @ordpayCompanyMoneyBagId = NULL
		SET @ordpayDeActive = NULL
		SET @ordpayAmountTemp = NULL
		SET @ordpayFileTypeJson = NULL
		SET @ordpayCardNumber = NULL
		/*AI14020327-End*/
		SET @ordpayAccountNumber = NULL /*AI14020701*/
		/*AI14020815*/
		SET @ordpayBankDocDate = NULL
		SET @ordpayBankDocDatePersian = NULL
		SET @ordpayBankDocAmount = NULL
		SET @ordpayBankDocDesc = NULL
		SET @ordpayBankDocDescI = NULL
		SET @ordpayBankDocRegisterUserId = NULL
		SET @ordpayBankDocRegisterDate = NULL
		SET @ordpayBankDocRegisterDatePersian = NULL
		/*AI14020815-End*/
		/*GHO14030211 - Add field to payment*/
		SET @ordpayDocDateTemp = NULL
		SET @ordpayDocDateTimeTemp = NULL
		/*GHO14030211 - End*/
        /**/
        WHILE LEN(@OPayAllFields) > 0
		BEGIN
			IF PATINDEX('%|#|%', @OPayAllFields) > 0
			BEGIN
				SET @OrdPayField = SUBSTRING(@OPayAllFields,
											0,
											PATINDEX('%|#|%', @OPayAllFields))
				/*--------------------------------------------------------------------------------*/
				/*Get parameter name and split value form parameter*/
				/*For example => OrderPaymentId=1 => OrderPaymentId= => OrderPaymentId => Compare => value*/
				DECLARE @OrdPayFieldValue NVARCHAR(MAX)
				DECLARE @OrdPayFieldName NVARCHAR(200)
				SET @OrdPayFieldName = SUBSTRING(@OrdPayField, 1, CHARINDEX('=',@OrdPayField)-1)                                    
				SET @OrdPayFieldValue = SUBSTRING(@OrdPayField, CHARINDEX('=', @OrdPayField)+1, Len(@OrdPayField))
				/*--------------------------------------------------------------------------------*/
				/*---------------------------- BEGIN Fill variabele ------------------------------*/
				/*BEGIN ORDPAYMENT*/
				/*--------------------------*/
				IF @OrdPayFieldName = 'OrderPaymentId'
				BEGIN
					SELECT @OrderPaymentId = CASE WHEN @OrdPayFieldValue = 'null' THEN NULL ELSE CAST(@OrdPayFieldValue AS INT) END					
					SET @OrdPaymentIdsInError = @OrdPaymentIdsInError + CAST(@OrderPaymentId AS NVARCHAR(10)) + ',0|' /*rollback when have error*/					
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayImportDate'
				BEGIN
					SET @ordpayImportDate = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdPayFieldValue, '/', '') END
					SET @ordpayImportDateTime = CASE WHEN @ordpayImportDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordpayImportDate, @RegisterTime) END			 			
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayTypeId'
				BEGIN
					SELECT @ordpayTypeId = CASE WHEN @OrdPayFieldValue = 'null' THEN NULL ELSE CAST(@OrdPayFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayOrderId'
				BEGIN
					SELECT @ordpayOrderId = CASE WHEN @OrdPayFieldValue = 'null' THEN NULL ELSE CAST(@OrdPayFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayDocId'
				BEGIN
					SELECT @ordpayDocId = CASE WHEN @OrdPayFieldValue = 'null' THEN NULL ELSE CAST(@OrdPayFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayDocTypeId'
				BEGIN
					SELECT @ordpayDocTypeId = CASE WHEN @OrdPayFieldValue = 'null' THEN NULL ELSE CAST(@OrdPayFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayAmount'
				BEGIN
					SELECT @ordpayAmount = CASE WHEN /*AI14020502 @OrdPayFieldValue = '0.0' OR*/ @OrdPayFieldValue = 'null' THEN NULL ELSE CAST(@OrdPayFieldValue AS NUMERIC(18, 2)) END
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayDocNumber'
				BEGIN
					SET @ordpayDocNumber = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE @OrdPayFieldValue END				
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayDocDate'
				BEGIN
					SET @ordpayDocDate = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdPayFieldValue, '/', '') END
					SET @ordpayDocDateTime = CASE WHEN @ordpayDocDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordpayDocDate, @RegisterTime) END			 			
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayDocAmount'
				BEGIN
					SELECT @ordpayDocAmount = CASE WHEN @OrdPayFieldValue = '0.0' OR @OrdPayFieldValue = 'null' THEN NULL ELSE CAST(@OrdPayFieldValue AS NUMERIC(18, 2)) END
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayDescription'
				BEGIN
					SET @ordpayDescription = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE @OrdPayFieldValue END				
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayBankDocNumber'
				BEGIN
					SELECT @ordpayBankDocNumber = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE @OrdPayFieldValue END
				END
				/*--------------------------*/
				/*AI14020327 - Add field*/
				IF @OrdPayFieldName = 'ordpayCompanyMoneyBagId'
				BEGIN
					SELECT @ordpayCompanyMoneyBagId = CASE WHEN @OrdPayFieldValue = 'null' THEN NULL ELSE CAST(@OrdPayFieldValue AS INT) END
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayDeActive'
				BEGIN
					SET @ordpayDeActive = CASE WHEN @OrdPayFieldValue = 'null' THEN NULL 
										WHEN @OrdPayFieldValue = 'false' THEN 0 
										ELSE 1 END	
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayAmountTemp'
				BEGIN
					SELECT @ordpayAmountTemp = CASE WHEN @OrdPayFieldValue = '0.0' OR @OrdPayFieldValue = 'null' THEN NULL ELSE CAST(@OrdPayFieldValue AS NUMERIC(18, 2)) END
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayFileTypeJson'
				BEGIN
					SELECT @ordpayFileTypeJson = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE @OrdPayFieldValue END
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayCardNumber'
				BEGIN
					SELECT @ordpayCardNumber = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE @OrdPayFieldValue END
				END
				/*AI14020327-End*/
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayAccountNumber' /*AI14020701*/
				BEGIN
					SELECT @ordpayAccountNumber = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE @OrdPayFieldValue END
				END
				/*--------------------------*/
				/*AI14020815*/
				IF @OrdPayFieldName = 'ordpayBankDocDate'
				BEGIN
					SET @ordpayBankDocDatePersian = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdPayFieldValue, '/', '') END
					SET @ordpayBankDocDate = CASE WHEN @ordpayBankDocDatePersian IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordpayBankDocDatePersian, @RegisterTime) END			 			
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayBankDocAmount'
				BEGIN
					SELECT @ordpayBankDocAmount = CASE WHEN @OrdPayFieldValue = '0.0' OR @OrdPayFieldValue = 'null' THEN NULL ELSE CAST(@OrdPayFieldValue AS NUMERIC(18, 2)) END
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayBankDocDesc'
				BEGIN
					SET @ordpayBankDocDesc = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE @OrdPayFieldValue END				
				END
				/*--------------------------*/
				IF @OrdPayFieldName = 'ordpayBankDocDescI'
				BEGIN
					SET @ordpayBankDocDescI = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE @OrdPayFieldValue END				
				END
				/*AI14020815*/
				/*--------------------------*/
				/*GHO14030211 - Add field to payment*/
				IF @OrdPayFieldName = 'ordpayDocDateTemp'
				BEGIN
					SET @ordpayDocDateTemp = CASE WHEN @OrdPayFieldValue = '' OR @OrdPayFieldValue = 'null' THEN NULL ELSE REPLACE(@OrdPayFieldValue, '/', '') END
					SET @OrdpayDocDateTimeTemp = CASE WHEN @OrdpayDocDateTemp IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@OrdpayDocDateTemp, @RegisterTime) END
				END
				/*GHO14030211 - End*/
				/*--------------------------*/
				/*END ORDPAYMENT*/		
				/*END GENERAL*/
				/*---------------------------- END Fill variabele --------------------------------*/
				/*---------------------------- Remove current parameter from listparam ------------*/
				SET @OPayAllFields = SUBSTRING(@OPayAllFields,
                                  LEN(@OrdPayField + '|#|') + 1,
                                  LEN(@OPayAllFields))                                                                                                      
			END
			ELSE
			BEGIN
				SET @OrdPayField = @OPayAllFields
				SET @OPayAllFields = NULL
				
			END
		END  
		/************* Insert to tmp table***************/						
		/******************** set date time *********************/
		IF(@RegisterTime IS NOT NULL )
		BEGIN
			IF(@RegisterTime IS NOT NULL)
			BEGIN
				SET @ordpayImportDateTime = CASE WHEN @ordpayImportDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordpayImportDate, @RegisterTime) END			 	
			END
			
			IF(@ordpayDocDate IS NOT NULL)
			BEGIN
				SET @ordpayDocDateTime = CASE WHEN @ordpayDocDate IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordpayDocDate, @RegisterTime) END			 	
			END

			/*GHO14030211 - Add field to payment*/
			IF(@ordpayDocDateTemp IS NOT NULL)
			BEGIN
				SET @ordpayDocDateTimeTemp = CASE WHEN @ordpayDocDateTemp IS NULL THEN NULL ELSE dbo.fnPersianToGregorianDate(@ordpayDocDateTemp, @RegisterTime) END
			END
			/*GHO14030211 - End*/
		END
		/*AI14020815*/
		IF(
			ISNULL(@ordpayBankDocNumber, '') <> '' OR
			ISNULL(@ordpayBankDocDatePersian, '') <> '' OR
			ISNULL(@ordpayBankDocAmount, 0) <> 0 OR
			ISNULL(@ordpayBankDocDesc, '') <> '' OR
			ISNULL(@ordpayBankDocDescI, '') <> ''
		)
		BEGIN
			SET @ordpayBankDocRegisterUserId = @UserId
			SET @ordpayBankDocRegisterDate = @RegisterDate
			SET @ordpayBankDocRegisterDatePersian = @RegisterDatePersian
		END
		/*AI14020815-End*/
		/**/
		INSERT INTO @OrdPaymentTmpTable 
			(
				[OrderPaymentId],
				[ordpayImportDate],
				[ordpayImportDateTime],
				[ordpayTypeId],
				[ordpayOrderId],
				[ordpayDocId],
				[ordpayDocTypeId],
				[ordpayAmount],
				[ordpayDocNumber],
				[ordpayDocDate],
				[ordpayDocDateTime],
				[ordpayDescription],
				[ordpayDocAmount],
				[ordpayBankDocNumber],
				/*AI14020327 - Add field*/
				[ordpayCompanyMoneyBagId],
				[ordpayDeActive],
				[ordpayAmountTemp],
				[ordpayFileTypeJson],
				[ordpayCardNumber],
				/*AI14020327-End*/
				[ordpayAccountNumber], /*AI14020701*/
				/*AI14020815*/
				[ordpayBankDocDate],
				[ordpayBankDocDatePersian],
				[ordpayBankDocAmount],
				[ordpayBankDocDesc],
				[ordpayBankDocDescI],
				[ordpayBankDocRegisterUserId],
				[ordpayBankDocRegisterDate],
				[ordpayBankDocRegisterDatePersian],
				/*AI14020815-End*/
				/*GHO14030211 - Add field to payment*/
				[ordpayDocDateTemp],
				[ordpayDocDateTimeTemp]
				/*GHO14030211 - End*/
			)
			VALUES
			(
				@OrderPaymentId,
				@ordpayImportDate,
				@ordpayImportDateTime,
				@ordpayTypeId,
				@ordpayOrderId,
				@ordpayDocId,
				@ordpayDocTypeId,
				@ordpayAmount,
				@ordpayDocNumber,
				@ordpayDocDate,
				@ordpayDocDateTime,
				@ordpayDescription,
				@ordpayDocAmount,
				@ordpayBankDocNumber,
				/*AI14020327 - Add field*/
				@ordpayCompanyMoneyBagId,
				@ordpayDeActive,
				@ordpayAmountTemp,
				@ordpayFileTypeJson,
				@ordpayCardNumber,
				/*AI14020327-End*/
				@ordpayAccountNumber, /*AI14020701*/
				/*AI14020815*/
				@ordpayBankDocDate,
				@ordpayBankDocDatePersian,
				@ordpayBankDocAmount,
				@ordpayBankDocDesc,
				@ordpayBankDocDescI,
				@ordpayBankDocRegisterUserId,
				@ordpayBankDocRegisterDate,
				@ordpayBankDocRegisterDatePersian,
				/*AI14020815-End*/
				/*GHO14030211 - Add field to payment*/
				@ordpayDocDateTemp,
				@ordpayDocDateTimeTemp
				/*GHO14030211 - End*/
			) 									                      
		/*END ORDPAYMENT*/		
        /*END GENERAL*/
        /*---------------------------- END Fill fields ------------------------------------*/
        /*---------------------------- Remove current parameter from listparam ------------*/
        SET @OrdPaymentList = SUBSTRING(@OrdPaymentList,
                                  LEN(@OrdPayAllFields + '|^#^|') + 1,
                                  LEN(@OrdPaymentList))                                  
    END
    ELSE
    BEGIN
        SET @OrdPayAllFields = @OrdPaymentList
        SET @OrdPaymentList = NULL
        
    END
END
/**/
IF (@@ERROR > 0)
BEGIN SET @ErrorFrom='Error In Input Order Payment' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END		
ELSE 
COMMIT TRAN 
/**/

/*==============================================================================*/
/********************************************************************************/
/****************************** Insert Order *********************************/
/********************************************************************************/
/******************************* Check Duplicate **********************************/
/*---------------------- OrdNumber ---------------------------------*/
DECLARE @InsertOrdId INT, @InsertOrdIId INT, @InsertOrdPayId INT,
@InsertedOrdIIdsInMobAndDb NVARCHAR(500) = ''
BEGIN TRAN
/**/
/** Get Order number and check **/
SET @ordNumber = (SELECT [dbo].[MobfnReturnOrderNumber](@FPId, @OrderOprID))
DECLARE @CheckDupOrderNumber BIGINT
SET @CheckDupOrderNumber = (SELECT TOP 1 ordNumber FROM [dbo].[MobfnCheckDuplicateOrderNumber](@ordNumber, 0, @FPId, @OrderOprID))
IF(@CheckDupOrderNumber IS NOT NULL)
BEGIN
	SET @ErrorMessage = @ErrorMessage + '|ordNumberIsDup' 	
END
/*---------------------- OrdDailyCounter ---------------------------------*/ /*AI14020407*/
IF(ISNULL(@OrderOprID, 0) <> 0 AND @ordDateTime IS NOT NULL)
BEGIN
	SET @ordDailyCounter = (SELECT [dbo].[MobfnReturnOrderDailyCounter](@OrderOprID, @ordDateTime))
END
/*---------------------- ordNumRef ---------------------------------*/
IF EXISTS (
SELECT * FROM dbo.CrmsysRollPermission
WHERE FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmOrderDataEntry' )
AND FormActionId = (SELECT Id FROM dbo.CrmsysFormActions WHERE ActionName = N'actAutoCalcNumRef'
					AND FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmOrderDataEntry' ))
AND RollId = (SELECT TOP 1 RollId FROM dbo.UsersPermission WHERE UserId = @UserId AND PrjId = 11/*CRM*/))
BEGIN	
	EXEC [dbo].[MobspReturnOrderNumRef]
		@OrdCompanyId = @ordCompanyId,
		@OrdProjectId = @ordProjectId,
		@OrdReferUserId = @ordReferUserId,
		@OrdNumber = @ordNumber,
		@LanguageID = @LanguageID,
		@DefaultLanguageID = @DefaultLanguageID,
		@OrdDailyCounter = @ordDailyCounter, /*AI14020410*/
		@selectedNumRef = @ordNumRef OUTPUT
END

IF EXISTS (
SELECT * FROM dbo.CrmsysRollPermission
WHERE FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmOrderDataEntry' )
AND FormActionId = (SELECT Id FROM dbo.CrmsysFormActions WHERE ActionName = N'actNotDupNumRef'
					AND FormId = (SELECT ID FROM dbo.CrmsysForms WHERE FormName = N'frmOrderDataEntry' ))
AND RollId = (SELECT TOP 1 RollId FROM dbo.UsersPermission WHERE UserId = @UserId AND PrjId = 11/*CRM*/)
AND @ordNumRef IS NOT NULL)
BEGIN

	DECLARE @DupOrdNumber INT
	DECLARE @TempTableForOrdNumRefCheckDuplicate TABLE (
	[ordNumber] INT,
	[ordNumRef] NVARCHAR(150))

	INSERT INTO @TempTableForOrdNumRefCheckDuplicate 
	EXEC [dbo].[MobspCheckDuplicateOrderNumRef]
		@OrdNumRef = @ordNumRef,
		@CurrOrderId = 0,
		@OrderOprId = @OrderOprID

	SELECT TOP 1
		@DupOrdNumber = [ordNumber]
	FROM @TempTableForOrdNumRefCheckDuplicate	 

	IF(@DupOrdNumber IS NOT NULL)
	BEGIN
		SET @ErrorMessage = @ErrorMessage + '@ordNumRef=Dup' +
			',@DupOrdNumber=' + ISNULL(CAST(@DupOrdNumber AS NVARCHAR(10)),'') + '|^|'	
	END
END
/*-------------------------------------------------------*/
/*AI14020420- Add ordTspSettingId*/
DECLARE @ordTspSettingId INT 
SET @ordTspSettingId = (SELECT TOP(1) TspSettingId FROM [dbo].[TspSetting])
/*AI14020420- End*/
/*-------------------------------------------------------*/
/*********** Insert to main table ***********/
INSERT INTO [dbo].[WSOrder]
        ([OrderOprID]
        ,[ordTitle]
        ,[ordNumber]
        ,[ordDate]
        ,[ordCompanyId]
        ,[ordCompanyPersonId]
        ,[ordProjectId]
        ,[ordSubject]
        ,[ordItemCount]
        ,[ordItemsAmount]
        ,[ordInstallAmount]
        ,[ordDiscount]
        ,[ordSumAmount]
        ,[ordTax]
        ,[ordTaxIndex]
        ,[ordCalculateTax]
        ,[ordTotalAmount]
        ,[ordTotalAmountStr]
        /*,[ordIsVerified]*/
        /*,[ordVerifiedRegisterDate]
        ,[ordVerifiedRegisterDatePersian] AI14011005*/
        ,[ordStatusId]
        /*,[ordIsFixed]*/
        ,[ordGuarantyId]
        ,[ordSpecialWord]
        ,[ordDescriptionI]
        ,[ordDescriptionII]
        ,[ordDescriptionId]
        ,[ordPrintFormatId]
        ,[ordRLogoId]
        ,[ordLLogoId]
        ,[ordSigningI]
        ,[ordSigningII]
        ,[ordSigningIII]
        ,[ordAccountNumberI]
        ,[ordAccountShabaNumberI]
        ,[ordAccountNumberII]
        ,[ordAccountShabaNumberII]
        ,[ordSignatureId]
        ,[ordImportDate]
        ,[ordFirstRegisterUserId]
        ,[UserId]
        ,[FPId]
        ,[Month1]
        ,[RegisterDate]
        ,[RegisterDatePersian]
        /*,[ordVerifierId]*/
        ,[ordSettlementTypeId]
        ,[ordDay]
        ,[ordTime]
        ,[ordTransportation]
        ,[ordReferUserId]
        ,[ordDiscountPercent]
        ,[ordDiscountTitle]
        ,[ordRound]
        ,[ordNote]
        ,[ordcmpTitle]
        ,[ordDateTime]
        ,[ordImportDateTime]
        ,[ordDeliveryDate]
        ,[ordDeliveryDateTime]
        ,[ordDeliveryTime]
        ,[ordSerial]
        ,[AppType]
        ,[ordVerifierRequestId]
        ,[LanguageID]
        ,[FirstRegisterUserId]
        ,[FirstRegisterDatePersian]
        ,[FirstRegisterDate]
        ,[ordVerificationWorkFlowId]
        ,[ordCurrencyUnitId]
        ,[ordDeliveryTermId]
        ,[ordDeliveryEndDate]
        ,[ordDeliveryEndDateTime]
        ,[ordDeliveryEndTime]
        ,[ordNumRef]
        ,[ordDefWHId]
        ,[ordDefPrdPriceGroupId]
        ,[ordSellerId]
        ,[ordEmailUsersInfoId]
        ,[ordEmailUserDefaultSettingId]
        ,[ordSaleCenterId]
		,[ordDefPayTypeId] /*AI14010706*/
		/*AI14020407*/
		,[ordDailyCounter]
		,[ordDeadlineDate]
		,[ordDeadlineDatePersian]
		,[ordDefaultSettingId]
		/*AI14020407-End*/
		,[ordTspSettingId] /*AI14020420*/
		/*AI14020716*/
		,[ordDeliveryDay]
		,[ordDeliveryEndDay]
		/*AI14020716-End*/
		)
VALUES
		(
		@OrderOprID
		,@ordTitle
		,@ordNumber
		,@ordDate
		,@ordCompanyId
		,@ordCompanyPersonId
		,@ordProjectId
		,@ordSubject
		,@ordItemCount
		,@ordItemsAmount
		,@ordInstallAmount
		,@ordDiscount
		,@ordSumAmount
		,@ordTax
		,@ordTaxIndex
		,@ordCalculateTax
		,@ordTotalAmount
		,@ordTotalAmountStr
		/*,@ordIsVerified*/
		/*,@RegisterDate
		,@RegisterDatePersian AI14011005*/
		,@ordStatusId
		/*,@ordIsFixed*/
		,@ordGuarantyId
		,@ordSpecialWord
		,@ordDescriptionI
		,@ordDescriptionII
		,@ordDescriptionId
		,@ordPrintFormatId
		,@ordRLogoId
		,@ordLLogoId
		,@ordSigningI
		,@ordSigningII
		,@ordSigningIII
		,@ordAccountNumberI
		,@ordAccountShabaNumberI
		,@ordAccountNumberII
		,@ordAccountShabaNumberII
		,@ordSignatureId
		,@RegisterDatePersian /*@ordImportDate*/
		,@UserId
		,@UserId
		,@FPId
		,@Month1
		,@RegisterDate
		,@RegisterDatePersian
		/*,@ordVerifierId*/
		,@ordSettlementTypeId
		,@ordDay
		,@ordTime
		,@ordTransportation
		,@ordReferUserId
		,@ordDiscountPercent
		,@ordDiscountTitle
		,@ordRound
		,@ordNote
		,@ordcmpTitle
		,@ordDateTime
		,@RegisterDate  /*@ordImportDateTime*/
		,@ordDeliveryDate
		,@ordDeliveryDateTime
		,@ordDeliveryTime
		,@ordSerial
		,@AppType
		,@ordVerifierRequestId
		,@DefaultLanguageID
		,@UserId
		,@RegisterDatePersian
		,@RegisterDate
		,@ordVerificationWorkFlowId
		,@ordCurrencyUnitId
		,@ordDeliveryTermId
		,@ordDeliveryEndDate
		,@ordDeliveryEndDateTime
		,@ordDeliveryEndTime
		,@ordNumRef
		,@ordDefWHId
		,@ordDefPrdPriceGroupId
		,@ordSellerId
		,@ordEmailUsersInfoId
		,@ordEmailUserDefaultSettingId
		,@ordSaleCenterId
		,@ordDefPayTypeId /*AI14010706*/
		/*AI14020407*/
		,@ordDailyCounter
		,@ordDeadlineDate
		,@ordDeadlineDatePersian
		,@ordDefaultSettingId
		/*AI14020407-End*/
		,@ordTspSettingId /*AI14020420*/
		/*AI14020716*/
		,@ordDeliveryDay
		,@ordDeliveryEndDay
		/*AI14020716-End*/
		)
SET @InsertOrdId = SCOPE_IDENTITY()
/*********** Insert to lang table ***********/
INSERT INTO [dbo].[WSOrder_Lang]
           ([OrderID]
		   ,[LanguageID]
           ,[ordTitle]
           ,[ordSubject]
           ,[ordSpecialWord]
           ,[ordDescriptionI]
           ,[ordDescriptionII]
           ,[ordSigningI]
           ,[ordSigningII]
           ,[ordSigningIII]
           ,[ordDiscountTitle]
           ,[ordNote]
           ,[ordcmpTitle]
           ,[ordTotalAmountStr])
SELECT
			@InsertOrdId
		   ,LN.LanguageID
		   ,@ordTitle
		   ,@ordSubject
		   ,@ordSpecialWord
		   ,@ordDescriptionI
		   ,@ordDescriptionII
		   ,@ordSigningI
		   ,@ordSigningII
		   ,@ordSigningIII
		   ,@ordDiscountTitle
		   ,@ordNote
		   ,@ordcmpTitle
		   ,@ordTotalAmountStr  
FROM dbo.Languages LN 
WHERE LN.LanguageID <> @DefaultLanguageID	
AND ISNULL(LN.IsActive,0) =1	 
/**/
IF (@@ERROR > 0)
BEGIN SET @ErrorFrom='Error In Insert Order' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END		
ELSE 
COMMIT TRAN 
/**/
SET @InsertedOrderId = @InsertOrdId
/**/
/********************************************************************************/
/****************************** Insert OrdItem *********************************/
/********************************************************************************/
BEGIN TRAN
/**/
/*check Order is inserted*/
IF(@InsertedOrderId > 0) 
BEGIN
	IF (@OrdItemList IS NOT NULL)
	BEGIN	
		DECLARE CrsrOrdI Cursor For
				SELECT 
					 [OrderItemID], [ordIOrderId] , [ordIPrdId], [ordIQuantity], [ordIPrice], [ordITotalPrice],
					 [ordIDescription], [ordIQuantityDesc], [ordIDiscount], [ordIDiscountI], [ordIDiscountPercent],
					 [ordIDiscountIPercent], [ordIPrdUnitId], [ordICurrencyUnitId], [ordIOrderView], [ordIFCR],
					 [ordITax], [ordITaxIndex], [ordICalculateTax], [ordINotVisible], [ordIFCRI], [ordINotInSum],
					 [ordIWHId],[ordIRound], [ordIRoundPlus], [ordIPricePartI], [ordIPricePartII], [ordIPricePartRate],
					 [ordIPrdPriceGroupID], [ordITracing], [ordIPriceSum], [ordIDiscountISum], [ordIDiscountSum], [ordITaxSum],
					 [ordIDeliveryTermId], [ordIDeliveryDate], [ordIDeliveryDatePersian],
					 /*AI14010423*/[ordIValidityExpireDate], [ordIValidityExpireDatePersian], /*AI14010423-End*/
					 [ordIQuantityTotal] /*AI14010606*/ ,[ordIPrdColorId] /*AI14010614*/, [ordIPrdUnitIdI], [ordIPrdUnitIRateResult] /*AI14010706*/
					 ,[ordIPrdValidityCountingNum], [ordIPrdValidityCountingMin] /*AI14010913*/ ,[ordIPrdNickname] /*AI14020119*/
					 ,[insertLinkedProducts] /*AI14000204 - Add*/
					 /*AI14020710*/ ,[ordIDeliveryTime] ,[ordIDeliveryDay] ,[ordIDeliveryEndDate] ,[ordIDeliveryEndDatePersian]
					 ,[ordIDeliveryEndTime] ,[ordIDeliveryEndDay] ,[ordIPrdAutoCalcRate] ,[ordIDescriptionI] /*AI14020710*/
					 ,[ordIDeliveryUserId] /*AI14020803*/
				FROM @OrdItemTmpTable		
		/**/
		OPEN CrsrOrdI
		FETCH NEXT FROM CrsrOrdI INTO
					@OrderItemID, @ordIOrderId , @ordIPrdId, @ordIQuantity, @ordIPrice, @ordITotalPrice,
					@ordIDescription, @ordIQuantityDesc, @ordIDiscount, @ordIDiscountI, @ordIDiscountPercent,
					@ordIDiscountIPercent, @ordIPrdUnitId, @ordICurrencyUnitId, @ordIOrderView, @ordIFCR,
					@ordITax, @ordITaxIndex, @ordICalculateTax, @ordINotVisible, @ordIFCRI, @ordINotInSum,
					@ordIWHId, @ordIRound, @ordIRoundPlus, @ordIPricePartI, @ordIPricePartII, @ordIPricePartRate,
					@ordIPrdPriceGroupID, @ordITracing, @ordIPriceSum, @ordIDiscountISum, @ordIDiscountSum, @ordITaxSum,
					@ordIDeliveryTermId, @ordIDeliveryDate, @ordIDeliveryDatePersian,
					/*AI14010423*/@ordIValidityExpireDate, @ordIValidityExpireDatePersian, /*AI14010423-End*/
					@ordIQuantityTotal /*AI14010606*/ ,@ordIPrdColorId /*AI14010614*/, @ordIPrdUnitIdI, @ordIPrdUnitIRateResult /*AI14010706*/
					,@ordIPrdValidityCountingNum, @ordIPrdValidityCountingMin /*AI14010913*/ ,@ordIPrdNickname /*AI14020119*/
					,@insertLinkedProducts /*AI14000204 - Add*/
					/*AI14020710*/ ,@ordIDeliveryTime ,@ordIDeliveryDay ,@ordIDeliveryEndDate ,@ordIDeliveryEndDatePersian
					,@ordIDeliveryEndTime ,@ordIDeliveryEndDay ,@ordIPrdAutoCalcRate ,@ordIDescriptionI /*AI14020710*/
					,@ordIDeliveryUserId /*AI14020803*/

		WHILE @@Fetch_Status = 0
		BEGIN
		/**/
			IF(@ordIOrderId = @OrderID)
			BEGIN		
				/*------*/
				/********* Check quantity ************/
				IF(@ActCanNotSelectWithNoStock = 1)
				BEGIN
					SELECT 1 /*===> because error in return from sp in visual studio*/
					DECLARE @QuantityRemain FLOAT = 0
					EXEC dbo.MobspReturnPrdQuantity 
					@PrdId = @ordIPrdId, 
					@FPId = @FPId, 
					@WHId = @ordIWHId, 
					@CurrId = 0, 
					@QuantityRemain = @QuantityRemain OUTPUT,
					@LanguageID  = @LanguageID,
					@DefaultLanguageID  = @DefaultLanguageID,
					/*AI14020530*/
					@FCR = @ordIFCR,
					@FCRI = @ordIFCRI,
					@Tracing = @ordITracing
					/*AI14020530-End*/
					IF(@QuantityRemain <= 0 OR @QuantityRemain < @ordIQuantity)
					BEGIN
						SET @ErrorMessage = @ErrorMessage + 'Msg=5<PRDID>' + CAST(@ordIPrdId AS NVARCHAR(10)) + '<\PRDID>' + '<QuantityRemain>' + CAST(@QuantityRemain AS NVARCHAR(20)) +'<\QuantityRemain>'
					END																
				END				

				/******* Insert to main table ********/
			INSERT INTO [dbo].[WSOrderItems]
					   ([OrderId]
					   ,[ordIPrdId]
					   ,[ordIQuantity]
					   ,[ordIPrice]
					   ,[ordITotalPrice]
					   ,[ordIDescription]
					   ,[UserId]
					   ,[FPId]
					   ,[Month1]
					   ,[RegisterDate]
					   ,[RegisterDatePersian]
					   ,[ordIQuantityDesc]
					   ,[ordIDiscountI]
					   ,[ordIDiscount]
					   ,[ordIDiscountPercent]
					   ,[ordIDiscountIPercent]
					   ,[ordIPrdUnitId]
					   ,[ordICurrencyUnitId]
					   ,[ordIOrderView]
					   ,[ordIFCR]
					   ,[ordITax]
					   ,[ordITaxIndex]
					   ,[ordICalculateTax]
					   ,[ordINotVisible]
					   ,[ordIFCRI]
					   ,[ordINotInSum]
					   ,[ordIWHId]
					   ,[ordIRound]
					   ,[AppType]
					   ,[LanguageID]
					   ,[FirstRegisterUserId]
					   ,[FirstRegisterDatePersian]
					   ,[FirstRegisterDate]
					   ,[ordIRoundPlus]
					   ,[ordIPricePartRate]
					   ,[ordIPricePartI]
					   ,[ordIPricePartII]
					   ,[ordIPrdPriceGroupID]
					   ,[ordITracing]
					   ,[ordIPriceSum]
					   ,[ordIDiscountISum]
					   ,[ordIDiscountSum]
					   ,[ordITaxSum]
					   ,[ordIDeliveryTermId]
					   ,[ordIDeliveryDate]
					   ,[ordIDeliveryDatePersian]
					   /*AI14010423*/
					   ,[ordIValidityExpireDate]
					   ,[ordIValidityExpireDatePersian]
					   /*AI14010423-End*/
					   ,[ordIQuantityTotal] /*AI14010606*/
					   ,[ordIPrdColorId] /*AI14010614*/
					   /*AI14010706*/
					   ,[ordIPrdUnitIdI]
					   ,[ordIPrdUnitIRateResult]
					   /*AI14010706-End*/
						/*AI14010913*/
						,[ordIPrdValidityCountingNum]
						,[ordIPrdValidityCountingMin]
						/*AI14010913-End*/
						,[ordIPrdNickname] /*AI14020119*/
						/*AI14020710*/
						,[ordIDeliveryTime]
						,[ordIDeliveryDay]
						,[ordIDeliveryEndDate]
						,[ordIDeliveryEndDatePersian]
						,[ordIDeliveryEndTime]
						,[ordIDeliveryEndDay]
						,[ordIPrdAutoCalcRate]
						,[ordIDescriptionI]
						/*AI14020710-End*/
						,[ordIDeliveryUserId] /*AI14020803*/
					   )
			 VALUES
						(
						@InsertOrdId
						,@ordIPrdId
						,@ordIQuantity
						,@ordIPrice
						,@ordITotalPrice
						,@ordIDescription
						,@UserId
						,@FPId
						,@Month1
						,@RegisterDate
						,@RegisterDatePersian
						,@ordIQuantityDesc
						,@ordIDiscountI
						,@ordIDiscount
						,@ordIDiscountPercent
						,@ordIDiscountIPercent
						,@ordIPrdUnitId
						,@ordICurrencyUnitId
						,@ordIOrderView
						,@ordIFCR
						,@ordITax
						,@ordITaxIndex
						,@ordICalculateTax
						,@ordINotVisible
						,@ordIFCRI
						,@ordINotInSum
						,@ordIWHId
						,@ordIRound
						,@AppType
						,@DefaultLanguageID
						,@UserId 
						,@RegisterDatePersian
						,@RegisterDate
						,@ordIRoundPlus
						,@ordIPricePartRate
						,@ordIPricePartI
						,@ordIPricePartII
						,@ordIPrdPriceGroupID
						,@ordITracing
						,@ordIPriceSum
						,@ordIDiscountISum
						,@ordIDiscountSum
						,@ordITaxSum
						,@ordIDeliveryTermId
						,@ordIDeliveryDate
						,@ordIDeliveryDatePersian
						/*AI14010423*/
						,@ordIValidityExpireDate
						,@ordIValidityExpireDatePersian
						/*AI14010423-End*/
						,@ordIQuantityTotal /*AI14010606*/
						,@ordIPrdColorId /*AI14010614*/
						/*AI14010706*/
						,@ordIPrdUnitIdI
						,@ordIPrdUnitIRateResult
						/*AI14010706-End*/
						/*AI14010913*/
						,@ordIPrdValidityCountingNum
						,@ordIPrdValidityCountingMin
						/*AI14010913-End*/
						,@ordIPrdNickname /*AI14020119*/
						/*AI14020710*/
						,@ordIDeliveryTime
						,@ordIDeliveryDay
						,@ordIDeliveryEndDate
						,@ordIDeliveryEndDatePersian
						,@ordIDeliveryEndTime
						,@ordIDeliveryEndDay
						,@ordIPrdAutoCalcRate
						,@ordIDescriptionI
						/*AI14020710-End*/
						,@ordIDeliveryUserId /*AI14020803*/
						)

				SET @InsertOrdIId = SCOPE_IDENTITY()					
				/******* Insert to lang table ********/
				INSERT INTO [dbo].[WSOrderItems_Lang]
					   ([OrderItemID]
					   ,[LanguageID]
					   ,[ordIDescription]
					   ,[ordIQuantityDesc])
				SELECT
					@InsertOrdIId
				    ,LN.LanguageID
				    ,@ordIDescription
				    ,@ordIQuantityDesc
				FROM dbo.Languages LN 
				WHERE LN.LanguageID <> @DefaultLanguageID	
				AND ISNULL(LN.IsActive,0) =1
				AND ISNULL(LN.IsActive,0) =1
				/******* Insert linked prd ********/
				IF(ISNULL(@insertLinkedProducts,0) = 1)
				BEGIN
					EXEC [dbo].[MobspInsertOrderItemFromLinkedPrd] 
					@ProductId = @ordIPrdId,
					@OrderId = @ordIOrderId,
					@ProductPriceGroupId = @ordIPrdPriceGroupID,
					@OrdIWHId = @ordIWHId,
					@UserId = @UserId,
					@FPId = @FPId,
					@Month1 = @Month1,
					@RegisterDate = @RegisterDate,
					@RegisterDatePersian = @RegisterDatePersian,
					@AppType = @AppType,
					@LanguageID = @DefaultLanguageID,
					@LinkedPrdIds = NULL,
					@OrderItemId = @InsertOrdIId /*AI14020627*/
				END
				/*************** Ids inserted ********/				
				SET @InsertedOrdIIdsInMobAndDb = @InsertedOrdIIdsInMobAndDb + CAST(@OrderItemID AS NVARCHAR(10)) + ',' + CAST(@InsertOrdIId AS NVARCHAR(10)) + '|'
				SET @InsertedOrdItemIds = @InsertedOrdIIdsInMobAndDb
				/*------*/
			END
			ELSE
				SET @ErrorMessage = @ErrorMessage + 'Msg=1'					
		/**/					 					
		FETCH NEXT FROM CrsrOrdI INTO
					@OrderItemID, @ordIOrderId , @ordIPrdId, @ordIQuantity, @ordIPrice, @ordITotalPrice,
					@ordIDescription, @ordIQuantityDesc, @ordIDiscount, @ordIDiscountI, @ordIDiscountPercent,
					@ordIDiscountIPercent, @ordIPrdUnitId, @ordICurrencyUnitId, @ordIOrderView, @ordIFCR,
					@ordITax, @ordITaxIndex, @ordICalculateTax, @ordINotVisible, @ordIFCRI, @ordINotInSum,
					@ordIWHId, @ordIRound, @ordIRoundPlus, @ordIPricePartI, @ordIPricePartII, @ordIPricePartRate,
					@ordIPrdPriceGroupID, @ordITracing, @ordIPriceSum, @ordIDiscountISum, @ordIDiscountSum, @ordITaxSum,
					@ordIDeliveryTermId, @ordIDeliveryDate, @ordIDeliveryDatePersian,
					/*AI14010423*/ @ordIValidityExpireDate, @ordIValidityExpireDatePersian, /*AI14010423-End*/
					@ordIQuantityTotal /*AI14010606*/ ,@ordIPrdColorId /*AI14010614*/, @ordIPrdUnitIdI, @ordIPrdUnitIRateResult /*AI14010706*/ 
					,@ordIPrdValidityCountingNum, @ordIPrdValidityCountingMin /*AI14010913*/ ,@ordIPrdNickname /*AI14020119*/
					,@insertLinkedProducts /*AI14000204 - Add*/
					/*AI14020710*/ ,@ordIDeliveryTime ,@ordIDeliveryDay ,@ordIDeliveryEndDate ,@ordIDeliveryEndDatePersian
					,@ordIDeliveryEndTime ,@ordIDeliveryEndDay ,@ordIPrdAutoCalcRate ,@ordIDescriptionI /*AI14020710*/
					,@ordIDeliveryUserId /*AI14020803*/
		END
		CLOSE CrsrOrdI
		DEALLOCATE CrsrOrdI    					 	 	 
	
	END
END
ELSE /*Not insert Order*/
	SET @ErrorMessage = @ErrorMessage + '|Msg=0' 	
/**/
IF (@@ERROR > 0)
BEGIN SET @ErrorFrom='Error In Insert Order Item' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END		
ELSE 
COMMIT TRAN 
/**/
/**/
/********************************************************************************/
/****************************** Insert  OrdPayment *****************************/
/********************************************************************************/
BEGIN TRAN
/**/
/*check Order is inserted*/
IF(@InsertedOrderId > 0)
BEGIN
	IF (@OrdPaymentList IS NOT NULL)
	BEGIN
		DECLARE CrsrOrdPay Cursor For
		SELECT 
			[OrderPaymentId], [ordpayImportDate], [ordpayImportDateTime], [ordpayTypeId], [ordpayOrderId],
			[ordpayDocId], [ordpayDocTypeId], [ordpayAmount], [ordpayDocNumber], [ordpayDocDate],
			[ordpayDocDateTime], [ordpayDescription], [ordpayDocAmount], [ordpayBankDocNumber],
			/*AI14020327 - Add field*/
			[ordpayCompanyMoneyBagId], [ordpayDeActive], [ordpayAmountTemp], [ordpayFileTypeJson], [ordpayCardNumber]
			/*AI14020327-End*/
			,[ordpayAccountNumber] /*AI14020701*/ /*AI14020815*/,[ordpayBankDocDate] ,[ordpayBankDocDatePersian] ,[ordpayBankDocAmount]
			,[ordpayBankDocDesc] ,[ordpayBankDocDescI] ,[ordpayBankDocRegisterUserId] ,[ordpayBankDocRegisterDate] ,[ordpayBankDocRegisterDatePersian] /*AI14020815*/,
			[ordpayDocDateTemp] /*GHO14030211*/, [ordpayDocDateTimeTemp] /*GHO14030211*/
		FROM @OrdPaymentTmpTable		
		/**/
		OPEN CrsrOrdPay
		FETCH NEXT FROM CrsrOrdPay INTO @OrderPaymentId, @ordpayImportDate, @ordpayImportDateTime, @ordpayTypeId, @ordpayOrderId,
										 @ordpayDocId, @ordpayDocTypeId, @ordpayAmount, @ordpayDocNumber, @ordpayDocDate,
										 @ordpayDocDateTime, @ordpayDescription, @ordpayDocAmount, @ordpayBankDocNumber,
										 /*AI14020327 - Add field*/
										 @ordpayCompanyMoneyBagId, @ordpayDeActive, @ordpayAmountTemp, @ordpayFileTypeJson, @ordpayCardNumber
										 /*AI14020327-End*/
										 ,@ordpayAccountNumber /*AI14020701*/ /*AI14020815*/,@ordpayBankDocDate ,@ordpayBankDocDatePersian ,@ordpayBankDocAmount
										 ,@ordpayBankDocDesc ,@ordpayBankDocDescI ,@ordpayBankDocRegisterUserId ,@ordpayBankDocRegisterDate
										 ,@ordpayBankDocRegisterDatePersian /*AI14020815*/,@ordpayDocDateTemp /*GHO14030211*/ , @ordpayDocDateTimeTemp /*GHO14030211*/
		WHILE @@Fetch_Status = 0
		BEGIN
			/**/
			IF(@ordpayOrderId = @OrderID)
			BEGIN
				/*----*/
				/******* Insert to main table ********/
				INSERT INTO [dbo].[WSOrderPayments]
							([ImportDate]
							,[ordpayTypeId]
							,[ordpayOrderId]
							,[ordpayDocId]
							,[ordpayDocTypeId]
							,[ordpayAmount]
							,[ordpayDocNumber]
							,[ordpayDocDate]
							,[ordpayDescription]
							,[ordpayFirstRegisterUserId]
							,[ordpayFirstRegisteDatePersian]
							,[ordpayFirstRegisteDate]
							,[UserId]
							,[FPId]
							,[Month1]
							,[RegisterDate]
							,[RegisterDatePersian]
							,[ImportDateTime]
							,[ordpayDocDateTime]
							,[ordpayDocAmount]
							,[AppType]
							,[LanguageID]
							,[FirstRegisterUserId]
							,[FirstRegisterDatePersian]
							,[FirstRegisterDate]
							,[ordpayBankDocNumber]
						   	/*AI14020327 - Add field*/
							,[ordpayCompanyMoneyBagId]
							,[ordpayDeActive]
							,[ordpayAmountTemp]
							,[ordpayFileTypeJson]
							,[ordpayCardNumber]
							/*AI14020327-End*/
							,[ordpayAccountNumber] /*AI14020701*/
							/*AI14020815*/
							,[ordpayBankDocDate]
							,[ordpayBankDocDatePersian]
							,[ordpayBankDocAmount]
							,[ordpayBankDocDesc]
							,[ordpayBankDocDescI]
							,[ordpayBankDocRegisterUserId]
							,[ordpayBankDocRegisterDate]
							,[ordpayBankDocRegisterDatePersian]
							/*AI14020815-End*/
							/*GHO14030211 - Add field to payent*/
							,[ordpayDocDateTemp]
							,[ordpayDocDateTimeTemp]
							/*GHO14030211 - End*/
						   )
					VALUES
							(@ordpayImportDate
							,@ordpayTypeId
							,@InsertOrdId
							,@ordpayDocId
							,@ordpayDocTypeId
							,@ordpayAmount
							,@ordpayDocNumber
							,@ordpayDocDate
							,@ordpayDescription
							,@UserId
							,@RegisterDatePersian
							,@RegisterDate
							,@UserId
							,@FPId
							,@Month1
							,@RegisterDate
							,@RegisterDatePersian
							,@ordpayImportDateTime
							,@ordpayDocDateTime
							,@ordpayDocAmount
							,@AppType
							,@DefaultLanguageID
							,@UserId
							,@RegisterDatePersian
							,@RegisterDate
							,@ordpayBankDocNumber
						   	/*AI14020327 - Add field*/
							,@ordpayCompanyMoneyBagId
							,@ordpayDeActive
							,@ordpayAmountTemp
							,@ordpayFileTypeJson
							,@ordpayCardNumber
							/*AI14020327-End*/
							,@ordpayAccountNumber /*AI14020701*/
							/*AI14020815*/
							,@ordpayBankDocDate
							,@ordpayBankDocDatePersian
							,@ordpayBankDocAmount
							,@ordpayBankDocDesc
							,@ordpayBankDocDescI
							,@ordpayBankDocRegisterUserId
							,@ordpayBankDocRegisterDate
							,@ordpayBankDocRegisterDatePersian
							/*AI14020815-End*/
							/*GHO14030211 - Add field to payment*/
							,@ordpayDocDateTemp
							,@ordpayDocDateTimeTemp
							/*GHO14030211 - END*/
						   )																																			          													
				SET @InsertOrdPayId = SCOPE_IDENTITY()
				/******* Insert to lang table ********/
				INSERT INTO [dbo].[WSOrderPayments_Lang]
						([OrderPaymentId]
						,[LanguageID]
						,[ordpayDescription]
						/*AI14020815*/
						,[ordpayBankDocDesc]
						,[ordpayBankDocDescI]
						/*AI14020815-End*/
						)
				SELECT
						@InsertOrdPayId
						,LN.LanguageID
						,@ordpayDescription
						/*AI14020815*/
						,@ordpayBankDocDesc
						,@ordpayBankDocDescI
						/*AI14020815-End*/
				FROM dbo.Languages LN 
				WHERE LN.LanguageID <> @DefaultLanguageID	
				AND ISNULL(LN.IsActive,0) = 1																			     				
				/*************** Ids inserted ********/								
				SET @InsertedOrdPaymentIds = @InsertedOrdPaymentIds + CAST(@OrderPaymentId AS NVARCHAR(10)) + ',' + CAST(@InsertOrdPayId AS NVARCHAR(10)) + '|'				
				/*----*/
			END
			ELSE    	
				SET @ErrorMessage = @ErrorMessage + 'Msg=1'			 					
			/**/
		FETCH NEXT FROM CrsrOrdPay INTO @OrderPaymentId, @ordpayImportDate, @ordpayImportDateTime, @ordpayTypeId, @ordpayOrderId,
										 @ordpayDocId, @ordpayDocTypeId, @ordpayAmount, @ordpayDocNumber, @ordpayDocDate,
										 @ordpayDocDateTime, @ordpayDescription, @ordpayDocAmount, @ordpayBankDocNumber,
										 /*AI14020327 - Add field*/
										 @ordpayCompanyMoneyBagId, @ordpayDeActive, @ordpayAmountTemp, @ordpayFileTypeJson, @ordpayCardNumber
										 /*AI14020327-End*/
										 ,@ordpayAccountNumber /*AI14020701*/ /*AI14020815*/,@ordpayBankDocDate ,@ordpayBankDocDatePersian ,@ordpayBankDocAmount
										 ,@ordpayBankDocDesc ,@ordpayBankDocDescI ,@ordpayBankDocRegisterUserId ,@ordpayBankDocRegisterDate
										 ,@ordpayBankDocRegisterDatePersian /*AI14020815*/, @ordpayDocDateTemp /*GHO14030211*/, @ordpayDocDateTimeTemp /*GHO14030211*/
		END
		CLOSE CrsrOrdPay
		DEALLOCATE CrsrOrdPay  
	END
END
ELSE /*Not insert Order*/
	SET @ErrorMessage = @ErrorMessage + '|Msg=0' 	
/**/
IF (@@ERROR > 0)
BEGIN SET @ErrorFrom='Error In Insert Order Payment' SET @ErrorNumber=@@ERROR ROLLBACK TRAN END		
ELSE 
COMMIT TRAN
/**/
/**/
/********************************************************************************/
/********************************************************************************/
/****************** rollback when have error Start ******************************/
EXEC [dbo].[MobspCalcAndUpdateOrderAmounts] @InsertOrdId, @Month1, @LanguageID, @DefaultLanguageID

EXEC [dbo].[MobspUpdateOrderLinkAccConflictByPay] @InsertOrdId /*AI14020830*/


IF(@ErrorMessage IS NOT NULL AND @ErrorMessage <> '')
BEGIN
	ROLLBACK TRANSACTION Main
 	SELECT 1
	SET @InsertedOrderId = @OrderIdInError
	SET @InsertedOrdItemIds = @OrdItemIdsInError
	SET @InsertedOrdPaymentIds = @OrdPaymentIdsInError			
END
/****************** rollback when have error End ******************************/
/**/
IF (@ErrorNumber > 0)
BEGIN 
	RAISERROR('Error From TransAction %S', 16, 1, @ErrorFrom)
	ROLLBACK TRANSACTION Main
 	SELECT 0
END 
ELSE
BEGIN
	IF(@ErrorMessage IS NULL OR @ErrorMessage = '')
	BEGIN
	COMMIT TRANSACTION Main 
	SELECT 1
	END
	ELSE
	SELECT 0
END	
/**/
END






