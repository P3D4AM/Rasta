SET NOCOUNT ON;
USE [crmideal];

-- Metadata/module-definition audit only.
-- No business rows are selected, inserted, updated, or deleted.

DECLARE @ExactNames TABLE (ObjectName sysname PRIMARY KEY);
INSERT INTO @ExactNames (ObjectName) VALUES
(N'ApispDyDeleteFormFieldMasterValuesBySysPart'),
(N'MobspDyDeleteFormFieldMasterValuesBySysPart'),
(N'MobspCheckCmpDataPermissionForUser'),
(N'MobspSetcmpDataPermission'),
(N'CRMspSetcmpDataPermission'),
(N'MobspCheckActionForUser'),
(N'MobspCheckCompanyDataPermissionForUser'),
(N'WSspDeletePreOrderFromPreOrderIndicator'),
(N'WSspIssueOrderFromBuyOrder'),
(N'WSspIssueStockSupplyFromPreOrder');

CREATE TABLE #Wanted
(
    object_id int NOT NULL PRIMARY KEY,
    Reason nvarchar(160) NOT NULL
);

-- 1) Exact targets, when present.
INSERT INTO #Wanted (object_id, Reason)
SELECT o.object_id, N'Exact target'
FROM sys.objects AS o
JOIN @ExactNames AS n ON n.ObjectName = o.name
WHERE o.type IN ('P','FN','IF','TF','V','TR')
  AND NOT EXISTS (SELECT 1 FROM #Wanted w WHERE w.object_id = o.object_id);

-- 2) All modules that reference the shared temp table or relevant helpers.
-- This includes candidate producers/consumers of TypeId=30 and TypeId=20.
INSERT INTO #Wanted (object_id, Reason)
SELECT DISTINCT o.object_id, N'References permission/temp-filter machinery'
FROM sys.sql_modules AS m
JOIN sys.objects AS o ON o.object_id = m.object_id
WHERE o.type IN ('P','FN','IF','TF','V','TR')
  AND
  (
       m.definition LIKE N'%CrmsysDBTempInfo%'
    OR m.definition LIKE N'%MobspCheckCmpDataPermissionForUser%'
    OR m.definition LIKE N'%MobspCheckActionForUser%'
    OR m.definition LIKE N'%WSspDeletePreOrderFromPreOrderIndicator%'
    OR m.definition LIKE N'%ApispDyDeleteFormFieldMasterValuesBySysPart%'
    OR m.definition LIKE N'%MobspDyDeleteFormFieldMasterValuesBySysPart%'
  )
  AND NOT EXISTS (SELECT 1 FROM #Wanted w WHERE w.object_id = o.object_id);

-- 3) Triggers attached to CrmsysDBTempInfo, if any.
DECLARE @TempInfoObjectId int = OBJECT_ID(N'dbo.CrmsysDBTempInfo', N'U');
IF @TempInfoObjectId IS NOT NULL
BEGIN
    INSERT INTO #Wanted (object_id, Reason)
    SELECT tr.object_id, N'Trigger on CrmsysDBTempInfo'
    FROM sys.triggers AS tr
    WHERE tr.parent_id = @TempInfoObjectId
      AND NOT EXISTS (SELECT 1 FROM #Wanted w WHERE w.object_id = tr.object_id);
END;

-- Result set 1: table columns (metadata only).
SELECT
    N'dbo.CrmsysDBTempInfo' AS TableName,
    c.column_id AS ColumnId,
    c.name AS ColumnName,
    TYPE_NAME(c.user_type_id) AS DataType,
    c.max_length AS MaxLengthBytes,
    c.is_nullable AS IsNullable
FROM sys.columns AS c
WHERE c.object_id = @TempInfoObjectId
ORDER BY c.column_id;

-- Result set 2: indexes/keys on the shared table.
SELECT
    i.name AS IndexName,
    i.is_unique AS IsUnique,
    i.is_primary_key AS IsPrimaryKey,
    ic.key_ordinal AS KeyOrdinal,
    c.name AS ColumnName,
    ic.is_included_column AS IsIncludedColumn
FROM sys.indexes AS i
JOIN sys.index_columns AS ic
  ON ic.object_id = i.object_id AND ic.index_id = i.index_id
JOIN sys.columns AS c
  ON c.object_id = ic.object_id AND c.column_id = ic.column_id
WHERE i.object_id = @TempInfoObjectId
  AND i.is_hypothetical = 0
ORDER BY i.index_id, ic.key_ordinal, ic.index_column_id;

-- Result set 3: all candidate modules and why they were selected.
SELECT
    s.name AS SchemaName,
    o.name AS ObjectName,
    o.type_desc AS ObjectType,
    w.Reason,
    LEN(m.definition) AS DefinitionCharacters,
    CASE WHEN m.definition IS NULL THEN 1 ELSE 0 END AS DefinitionUnavailable
FROM #Wanted AS w
JOIN sys.objects AS o ON o.object_id = w.object_id
JOIN sys.schemas AS s ON s.schema_id = o.schema_id
LEFT JOIN sys.sql_modules AS m ON m.object_id = o.object_id
ORDER BY w.Reason, s.name, o.name;

-- Result set 4: module dependencies. SQL Server exposes referenced_schema_name,
-- not referenced_schema_id, in sys.sql_expression_dependencies.
SELECT DISTINCT
    rs.name AS ReferencingSchema,
    ro.name AS ReferencingObject,
    d.referenced_schema_name AS ReferencedSchema,
    d.referenced_entity_name AS ReferencedObject,
    d.referenced_class_desc AS ReferencedClass,
    d.is_caller_dependent AS IsCallerDependent
FROM #Wanted AS w
JOIN sys.sql_expression_dependencies AS d
  ON d.referencing_id = w.object_id
JOIN sys.objects AS ro ON ro.object_id = d.referencing_id
JOIN sys.schemas AS rs ON rs.schema_id = ro.schema_id
ORDER BY rs.name, ro.name, d.referenced_schema_name, d.referenced_entity_name;

-- Result set 5: complete module definitions for static review.
SELECT
    CAST(
        N'-- [' + s.name + N'].[' + o.name + N'] | ' + w.Reason
        + CHAR(13) + CHAR(10)
        + COALESCE(m.definition, N'-- DEFINITION NOT AVAILABLE (possibly encrypted)')
        + CHAR(13) + CHAR(10) + N'GO'
        AS nvarchar(max)
    ) AS DefinitionText
FROM #Wanted AS w
JOIN sys.objects AS o ON o.object_id = w.object_id
JOIN sys.schemas AS s ON s.schema_id = o.schema_id
LEFT JOIN sys.sql_modules AS m ON m.object_id = o.object_id
ORDER BY s.name, o.name;

DROP TABLE #Wanted;
