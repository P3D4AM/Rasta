SET NOCOUNT ON;
USE [crmideal];

-- ============================================================================
-- ideal-write-audit-fifth-pending-sp.sql  (read-only; catalog metadata only)
-- ============================================================================
-- هدف: استخراج تعریف کامل (sys.sql_modules) و امضای پارامترها (sys.parameters)
--       برای پروسیجرهای باقی‌ماندهٔ ممیزی Write + پروسیجرهای مسیر AUTH/Center.
-- منبع فهرست اهداف: نگاشت فراخوانی ۱۸۲ پروسیجر خانوادهٔ Write در کد دیکامپایل‌شدهٔ
--       Mobile (Controllers/Classes) که تعریف SQL آن‌ها در هیچ‌یک از استخراج‌های
--       فعلی مخزن نیست (111 مورد) + اهداف دقیق فاز AUTH.
--
-- قواعد (مطابق استخراج‌های قبلی):
--   * فقط از نمای‌های کاتالوگ سیستم خوانده می‌شود (sys.objects, sys.parameters,
--     sys.sql_modules, sys.schemas). هیچ ردیف تجاری انتخاب/درون‌ریزی/ویرایش/حذف نمی‌شود.
--   * هیچ Stored Procedure اجرا نمی‌شود (هیچ EXECUTE <proc> در متن نیست).
--   * خروجی فقط برای Static Review است.
-- ============================================================================

DECLARE @ExactNames TABLE (ObjectName sysname PRIMARY KEY);
INSERT INTO @ExactNames (ObjectName) VALUES
N'CRMspUpdateUserLastCId', N'MobspCalcAndUpdateTimeAttendanceLeave', N'MobspCheckActionForUser', N'SHPMobspIssueOrder',
N'MobspCheckCmpDataPermissionForUser', N'MobspCheckCompanyDataPermissionForUser', N'MobspDeleteDocItemLinkOrderItem',
N'MobspDeleteDocLinkOrder', N'MobspDeleteFilesDirectoryTemplate', N'MobspDeleteFund',
N'MobspDeleteOrderItemSerialsByOrderItemId', N'MobspDeleteSysTempData', N'MobspDeleteWSOrderItemSerials',
N'MobspDyInsertFormFieldMasterValueDetails', N'MobspDyInsertFormFieldMasterValues', N'MobspDyInsertFormFieldValues',
N'MobspDyInsertUpdateFormFieldMasterValueDetails', N'MobspDyUpdateFormFieldMasterValueDetails', N'MobspDyUpdateFormFieldMasterValues',
N'MobspDyUpdateFormFieldValues', N'MobspInsertAutoDocItemSerial', N'MobspInsertAutoOrderItemSerial',
N'MobspInsertCompanyAddresses', N'MobspInsertCompanyAppDeviceInfo', N'MobspInsertCompanyMoneyBag',
N'MobspInsertConversationAutoReplyAfterSetDoingTimeTicket', N'MobspInsertCrmFilesDirectory', N'MobspInsertCrmUserTasks',
N'MobspInsertDiscountCodeHistory', N'MobspInsertDocItemFromLinkedPrd', N'MobspInsertDocItemFromLinkedPrdWithMinStock',
N'MobspInsertDocItemWithBarcode', N'MobspInsertEmailSendAttachment', N'MobspInsertEmailSendDetail',
N'MobspInsertEmailSendHeader', N'MobspInsertErrorLogs', N'MobspInsertFilesDirectory',
N'MobspInsertFilesDirectoryTemplate', N'MobspInsertInternalMessage', N'MobspInsertInternalMessageSingle',
N'MobspInsertLetter', N'MobspInsertLinkCompanyByCmpNumber', N'MobspInsertOrderFull',
N'MobspInsertPrintLog', N'MobspInsertQuickDocItemSerial', N'MobspInsertQuickOrderItem',
N'MobspInsertQuickOrderPayment', N'MobspInsertQuickPreOrderItem', N'MobspInsertQuickPreOrderPayment',
N'MobspInsertQuickPrjCnvsForDuplicate', N'MobspInsertShortLink', N'MobspInsertSurveyAnswerCategoryDetailValue',
N'MobspInsertSurveyAnswerValue', N'MobspInsertUpdateLeave', N'MobspInsertUpdateMultiUserMovementTracking',
N'MobspInsertUpdateOrdItemSerial', N'MobspInsertUpdateProjectProductHistory', N'MobspInsertUpdateSysTempData',
N'MobspInsertUpdateTimeAttendance', N'MobspInsertUpdateUserMovementTracking', N'MobspInsertUserAppDeviceInfo',
N'MobspIntMsgUpdateMultiReceiver', N'MobspIntMsgUpdateSelectReceiver', N'MobspInternalMessageUpdate',
N'MobspLoadUserLoginInfo', N'MobspOrderPaymentVerify', N'MobspOrderPaymentVerifyExit',
N'MobspPreOrderPaymentVerify', N'MobspPreOrderPaymentVerifyExit', N'MobspReUpdateFundRemain',
N'MobspSelectCentersWithIds', N'MobspSelectUserBaseInfoLastUpdate', N'MobspSelectUserRollPermission',
N'MobspSendSmsFoSettingOrdAfterVerify', N'MobspSendSmsFoSettingPordAfterVerify', N'MobspSendSmsPordFOLinkAfterVerify',
N'MobspSingleCrmConversationPreChecks', N'MobspUpdateBuyOrderEditAfterFixInfoJs', N'MobspUpdateCompanyAddresses',
N'MobspUpdateCompanyCIds', N'MobspUpdateCompanyCRMShopActive', N'MobspUpdateCompanyMoneyBag',
N'MobspUpdateCompanyMoneyBagFromPayment', N'MobspUpdateCompanyPersonCIds', N'MobspUpdateConversationHappyVote',
N'MobspUpdateConversationNotRemindOk', N'MobspUpdateConversationRemindOk', N'MobspUpdateCrmConversationRemindTimeForAllarm',
N'MobspUpdateCrmUserTaskRemindTime', N'MobspUpdateCrmUserTasks', N'MobspUpdateDocEditAfterFixInfoJs',
N'MobspUpdateDocItemSerial', N'MobspUpdateDyFormEditAfterFixInfoJs', N'MobspUpdateEmailSendDetail',
N'MobspUpdateEmailSendHeader', N'MobspUpdateFileDirectory', N'MobspUpdateFundWithId',
N'MobspUpdateInternalMessageAttachFileCount', N'MobspUpdateLeaveReplaceUserIntMsgId', N'MobspUpdateLetter',
N'MobspUpdateOrder', N'MobspUpdateOrderEditAfterFixInfoJs', N'MobspUpdateOrderItem',
N'MobspUpdateOrderItemsDeliveryDates', N'MobspUpdateOrderLinkAccControl', N'MobspUpdateOrderPayment',
N'MobspUpdatePreOrder', N'MobspUpdatePreOrderEditAfterFixInfoJs', N'MobspUpdatePreOrderExpireDate',
N'MobspUpdatePreOrderItem', N'MobspUpdatePreOrderPayment', N'MobspUpdateProjectTitleGroup',
N'MobspUpdateProjectToDoTime', N'MobspUpdateSendedDetailStatusAndRefId', N'MobspUpdateSerialInfoVI',
N'MobspUpdateSurveyHistoryRepliedDate', N'MobspUpdateTimeAttendanceRequestVerified', N'MobspUpdateUserAppDeviceInfoById',
N'MobspUpdateUserCoordinate', N'MobspUpdateUserMobAppDevSetting', N'MobspUpdateUserTaskDidIt',
N'MobspUpdatedUserMobBaseInfo', N'MobspVerificationRequestVerify';

-- ----------------------------------------------------------------------------
-- Result set 1: وجود/نوع هر هدف دقیق (شامل کاوش نام بلند/کوتاه Helper مجوز)
-- ----------------------------------------------------------------------------
SELECT
    s.name AS SchemaName,
    o.name AS ObjectName,
    o.type_desc AS ObjectType,
    CASE WHEN m.definition IS NULL THEN 1 ELSE 0 END AS DefinitionUnavailable,
    LEN(m.definition) AS DefinitionCharacters
FROM @ExactNames AS n
LEFT JOIN sys.objects AS o  ON o.name = n.ObjectName AND o.type IN ('P','FN','IF','TF','V','TR')
LEFT JOIN sys.schemas AS s  ON s.schema_id = o.schema_id
LEFT JOIN sys.sql_modules AS m ON m.object_id = o.object_id
ORDER BY CASE WHEN o.object_id IS NULL THEN 1 ELSE 0 END, s.name, o.name;

-- ----------------------------------------------------------------------------
-- Result set 2: امضای کامل پارامترها برای هر هدف موجود
-- (مبنای حل تعارض قرارداد EF/SSDL ↔ دیتابیس واقعی — مثلاً پارامتر CenterId)
-- ----------------------------------------------------------------------------
SELECT
    s.name AS SchemaName,
    o.name AS ObjectName,
    p.parameter_id AS ParamOrdinal,
    p.name AS ParamName,
    TYPE_NAME(p.user_type_id) AS DataType,
    p.max_length AS MaxLengthBytes,
    p.precision AS [Precision],
    p.scale AS Scale,
    p.is_output AS IsOutput
FROM @ExactNames AS n
JOIN sys.objects AS o ON o.name = n.ObjectName AND o.type IN ('P','FN','IF','TF')
JOIN sys.schemas AS s ON s.schema_id = o.schema_id
JOIN sys.parameters AS p ON p.object_id = o.object_id
ORDER BY o.name, p.parameter_id;

-- ----------------------------------------------------------------------------
-- Result set 3: تعریف کامل ماژول‌های موجود (برای Static Review)
-- ----------------------------------------------------------------------------
SELECT
    CAST(
        N'-- [' + s.name + N'].[' + o.name + N']'
        + CHAR(13) + CHAR(10)
        + COALESCE(m.definition, N'-- DEFINITION NOT AVAILABLE (possibly encrypted)')
        + CHAR(13) + CHAR(10) + N'GO'
        AS nvarchar(max)
    ) AS DefinitionText
FROM @ExactNames AS n
JOIN sys.objects AS o ON o.name = n.ObjectName AND o.type IN ('P','FN','IF','TF','V')
JOIN sys.schemas AS s ON s.schema_id = o.schema_id
LEFT JOIN sys.sql_modules AS m ON m.object_id = o.object_id
ORDER BY s.name, o.name;

-- ----------------------------------------------------------------------------
-- Result set 4: فراخوانی‌کنندگان هر هدف (وابستگی‌ها — فقط فراداده)
-- ----------------------------------------------------------------------------
SELECT DISTINCT
    rs.name AS ReferencingSchema,
    ro.name AS ReferencingObject,
    d.referenced_entity_name AS ReferencedObject,
    d.referenced_class_desc AS ReferencedClass
FROM @ExactNames AS n
JOIN sys.objects AS o        ON o.name = n.ObjectName
JOIN sys.sql_expression_dependencies AS d ON d.referencing_id = o.object_id
JOIN sys.objects AS ro       ON ro.object_id = d.referencing_id
JOIN sys.schemas AS rs       ON rs.schema_id = ro.schema_id
ORDER BY rs.name, ro.name, d.referenced_entity_name;
