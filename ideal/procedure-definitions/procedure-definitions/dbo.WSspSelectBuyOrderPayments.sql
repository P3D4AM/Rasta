




/*ADBF9503*/
/*RZ960203 For multi language*/
/*RZ981210- Add fields*/
/*RZ14020901- Add bordpayDeActive*/
/*RZ14030129-Add bordpayDocDateTemp and bordpayAmountTemp*/ 
Create Procedure [dbo].[WSspSelectBuyOrderPayments]
/* 
	exec WSspSelectBuyOrderPayments  3,1033, 1065 
*/		
(
@BuyOrderID INT,
@LanguageID INT = NULL,
@DefaultLanguageID INT = NULL 
)
As
BEGIN
/**/
IF(@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
BEGIN
/**/
		SELECT /***//*RZ981210- Convert * to field*/
			 [BuyOrderPaymentId]
			,[ImportDate]
			,[bordpayTypeId]
			,[bordpayOrderId]
			,[bordpayDocId]
			,[bordpayDocTypeId]
			,[bordpayAmount]
			,[bordpayDocNumber]
			,[bordpayDocDate]
			,[bordpayDescription]
			,[bordpayFirstRegisterUserId]
			,[bordpayFirstRegisteDatePersian]
			,[bordpayFirstRegisteDate]
			,[UserId]
			,[FPId]
			,[Month1]
			,[RegisterDate]
			,[RegisterDatePersian]
			,[ImportDateTime]
			,[bordpayDocDateTime]
			,[GUId]
			,[AppType]
			,[bordpayDocAmount]
			,[LanguageID]
			,[FirstRegisterUserId]
			,[FirstRegisterDatePersian]
			,[FirstRegisterDate]
			,(SELECT bordpayType FROM dbo.WSBuyOrderPaymentTypes WHERE BuyOrderPaymentTypeId  = bordpayTypeId) bordpayType 
			/*RZ981210- Add fields*/
			,[bordpayLinkAccHeaderId]
			,[bordpayLinkAccHeaderNumber]
			,[bordpayLinkAccDetailId]
			,[bordpayLinkAccVoucherId]
			,[bordpayLinkAccVoucherNumber]
			/*RZ981210- End*/
			,[bordpayDeActive]/*RZ14020901- Add bordpayDeActive*/
			/*RZ14030129-Add bordpayDocDateTemp and bordpayAmountTemp*/ 
			,[bordpayAmountTemp]
			,[bordpayDocDateTemp]
			,[bordpayDocDateTimeTemp]
			/*RZ14030129- End*/ 
		FROM dbo.WSBuyOrderPayments 
		WHERE bordpayOrderId = @BuyOrderId 
/**/
END
ELSE IF(@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
BEGIN/*RZ960203 for multi language*/
/**/
		SELECT 
			  [BuyOrderPaymentId]
			,[ImportDate]
			,[bordpayTypeId]
			,[bordpayOrderId]
			,[bordpayDocId]
			,[bordpayDocTypeId]
			,[bordpayAmount]
			,[bordpayDocNumber]
			,[bordpayDocDate]
			,(SELECT [bordpayDescription] FROM WSBuyOrderPayments_Lang BOPLN WHERE BOPLN.BuyOrderPaymentId = BOP.BuyOrderPaymentId AND BOPLN.LanguageID = @LanguageID) [bordpayDescription]
			,[bordpayFirstRegisterUserId]
			,[bordpayFirstRegisteDatePersian]
			,[bordpayFirstRegisteDate]
			,[UserId]
			,[FPId]
			,[Month1]
			,[RegisterDate]
			,[RegisterDatePersian]
			,[ImportDateTime]
			,[bordpayDocDateTime]
			,[GUId]
			,[AppType]
			,[bordpayDocAmount]
			,[LanguageID]
			,[FirstRegisterUserId]
			,[FirstRegisterDatePersian]
			,[FirstRegisterDate]
			,(SELECT bordpayType FROM dbo.WSBuyOrderPaymentTypes_Lang BOPTLN WHERE BOPTLN.BuyOrderPaymentTypeId  = BOP.bordpayTypeId AND BOPTLN.LanguageID = @LanguageID) bordpayType 
			/*RZ981210- Add fields*/
			,[bordpayLinkAccHeaderId]
			,[bordpayLinkAccHeaderNumber]
			,[bordpayLinkAccDetailId]
			,[bordpayLinkAccVoucherId]
			,[bordpayLinkAccVoucherNumber]
			/*RZ981210- End*/
			,[bordpayDeActive]/*RZ14020901- Add bordpayDeActive*/
			/*RZ14030129-Add bordpayDocDateTemp and bordpayAmountTemp*/ 
			,[bordpayAmountTemp]
			,[bordpayDocDateTemp]
			,[bordpayDocDateTimeTemp]
			/*RZ14030129- End*/ 
		FROM dbo.WSBuyOrderPayments BOP
		WHERE bordpayOrderId = @BuyOrderId 
/**/
END
/*RZ960203 for multi language*/
/**/
END





