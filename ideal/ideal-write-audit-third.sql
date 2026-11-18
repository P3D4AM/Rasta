SET NOCOUNT ON;

DECLARE @ExactNames TABLE (ObjectName sysname PRIMARY KEY);

INSERT INTO @ExactNames (ObjectName) VALUES
(N'MobspCheckActionForUser'),
(N'MobspSetcmpDataPermission'),
(N'CRMspSetcmpDataPermission'),
(N'MobspCheckCmpDataPermissionForUser'),
(N'MobspCheckCompanyDataPermissionForUser'),
(N'WSspCheckPreOrderHaveStockSupply'),
(N'WSspCalcAndUpdateStockSupplyFields'),
(N'MobspCheckDuplicateDocNumRef'),
(N'MobspReturnDocNumRef'),
(N'MobspCheckDuplicatePrdSerial'),
(N'MobspSelectDocItemTracing'),
(N'ApispCalcAndUpdateBuyOrderAmounts'),
(N'ApispCalcAndUpdateOrderAmounts'),
(N'ApispCalcAndUpdatePreOrderAmounts'),
(N'MobspCalcAndUpdatePreOrderAmounts');

CREATE TABLE #Wanted
(
    object_id int NOT NULL PRIMARY KEY,
    Reason nvarchar(100) NOT NULL
);

-- 1) آبجکت‌های مشخص‌شده برای ممیزی وابستگی‌ها
INSERT INTO #Wanted (object_id, Reason)
SELECT o.object_id, N'Explicit dependency'
FROM sys.objects AS o
JOIN @ExactNames AS n ON n.ObjectName = o.name
WHERE o.type IN ('P','FN','IF','TF','V')
  AND NOT EXISTS (
      SELECT 1 FROM #Wanted w WHERE w.object_id = o.object_id
  );

-- 2) کشف عملیات تغییردهنده وضعیت در خانواده‌های API
INSERT INTO #Wanted (object_id, Reason)
SELECT o.object_id, N'Potential state-changing procedure'
FROM sys.procedures AS p
JOIN sys.objects AS o ON o.object_id = p.object_id
WHERE
    (
        o.name LIKE 'Apisp%'
        OR o.name LIKE 'Mobsp%'
        OR o.name LIKE 'WSsp%'
    )
    AND
    (
        o.name LIKE '%Delete%'
        OR o.name LIKE '%Remove%'
        OR o.name LIKE '%Verify%'
        OR o.name LIKE '%UnVerify%'
        OR o.name LIKE '%Fixed%'
        OR o.name LIKE '%UnFixed%'
        OR o.name LIKE '%Issue%'
        OR o.name LIKE '%Cancel%'
        OR o.name LIKE '%Transfer%'
        OR o.name LIKE '%Exit%'
        OR o.name LIKE '%Confirm%'
        OR o.name LIKE '%Reject%'
        OR o.name LIKE '%Close%'
        OR o.name LIKE '%Open%'
    )
    AND NOT EXISTS (
        SELECT 1 FROM #Wanted w WHERE w.object_id = o.object_id
    );

-- 3) یک سطح از وابستگی‌های ثبت‌شده برای آبجکت‌های منتخب
INSERT INTO #Wanted (object_id, Reason)
SELECT DISTINCT referenced.object_id, N'Direct module dependency'
FROM #Wanted AS seed
JOIN sys.sql_expression_dependencies AS d
    ON d.referencing_id = seed.object_id
JOIN sys.objects AS referenced
    ON referenced.object_id = d.referenced_id
WHERE referenced.type IN ('P','FN','IF','TF','V')
  AND NOT EXISTS (
      SELECT 1 FROM #Wanted w
      WHERE w.object_id = referenced.object_id
  );

-- فهرست آبجکت‌های پیدا‌شده و علت انتخاب
SELECT
    s.name AS SchemaName,
    o.name AS ObjectName,
    o.type_desc AS ObjectType,
    w.Reason,
    LEN(m.definition) AS DefinitionCharacters
FROM #Wanted AS w
JOIN sys.objects AS o ON o.object_id = w.object_id
JOIN sys.schemas AS s ON s.schema_id = o.schema_id
LEFT JOIN sys.sql_modules AS m ON m.object_id = o.object_id
ORDER BY w.Reason, s.name, o.name;

-- متن کامل تعاریف؛ فقط خواندن metadata
SELECT
    CAST(
        N'-- [' + s.name + N'].[' + o.name + N']' + CHAR(13) + CHAR(10)
        + COALESCE(m.definition, N'-- DEFINITION NOT AVAILABLE')
        + CHAR(13) + CHAR(10) + N'GO'
        AS nvarchar(max)
    ) AS DefinitionText
FROM #Wanted AS w
JOIN sys.objects AS o ON o.object_id = w.object_id
JOIN sys.schemas AS s ON s.schema_id = o.schema_id
LEFT JOIN sys.sql_modules AS m ON m.object_id = o.object_id
ORDER BY s.name, o.name;

DROP TABLE #Wanted;
