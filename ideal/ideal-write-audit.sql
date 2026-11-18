SET NOCOUNT ON;

SELECT
    CAST(
        '-- ==================================================' + CHAR(13) + CHAR(10) +
        '-- ' + QUOTENAME(S.name) + '.' + QUOTENAME(O.name) + CHAR(13) + CHAR(10) +
        '-- ==================================================' + CHAR(13) + CHAR(10) +
        M.definition + CHAR(13) + CHAR(10)
        AS NVARCHAR(MAX)
    ) AS SqlDefinition
FROM sys.sql_modules M
JOIN sys.objects O ON O.object_id = M.object_id
JOIN sys.schemas S ON S.schema_id = O.schema_id
WHERE O.type IN ('P', 'FN', 'IF', 'TF', 'V')
AND O.name IN (
    'ApispInsertCompany',
    'ApispUpdateCompany',
    'ApispInsertCompanyPersons',
    'ApispUpdateCompanyPerson',
    'MobspInsertQuickCompany',
    'MobspUpdateCompany',
    'ApispInsertPreOrder',
    'ApispInsertPreOrderItems',
    'ApispUpdatePreOrder',
    'ApispUpdatePreOrderItems',
    'MobspInsertPreOrderFull',
    'ApispInsertOrder',
    'ApispInsertOrderItems',
    'ApispUpdateOrder',
    'ApispUpdateOrderItems',
    'ApispInsertOrderPayments',
    'WSfnProductsInGroups',
    'WSfnProductsInGroups_Lang',
    'CRMvwSelectCompanyPersons'
)
ORDER BY O.name;
