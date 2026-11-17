// ═══════════════════════════════════════════════════════════════
// LiveSchemaSql v3.0 — فهرست کامل کوئری‌های فرادادهٔ ابزار IdeaSchemaDump
// ───────────────────────────────────────────────────────────────
// فاز ۱۲.۵ — همهٔ کوئری‌های استخراج اینجا به‌صورت ثابت عمومی نگه داشته
// می‌شوند تا «تست‌های امنیتی ساختاری» بتوانند ضمانت‌های زیر را روی
// «کل مجموعه» اعمال کنند (و نه فقط چند نمونه):
//   ۱) هر کوئری تک‌دستوری SELECT است و از ReadOnlyCommandGuard می‌گذرد؛
//   ۲) هیچ «متن تعریف ماژول» (sys.sql_modules / OBJECT_DEFINITION /
//      sp_helptext) استخراج نمی‌شود — فقط نام/امضا/فراداده؛
//   ۳) هیچ محدودیت به یک Schema خاص (schema_id = 1 یا SCHEMA_ID('dbo'))
//      وجود ندارد — همهٔ Schemaهای قابل‌مشاهده پوشش داده می‌شوند؛
//   ۴) منبع هر کوئری فقط نمای کاتالوگ sys.* است — هیچ جدول/ویوی
//      کسب‌وکار (و هیچ دادهٔ واقعی) خوانده نمی‌شود.
// کوئری‌های «مکمل» (نسخه‌محور: Temporal/Generated Always/Memory-Optimized/
// Change Tracking/فیلتر ایندکس) ممکن است روی سرورهای قدیمی با خطای
// «ستون/نما موجود نیست» شکست بخورند؛ برنامه آنها را با «هشدار استخراج»
// ثبت می‌کند (الزام فاز ۱۲.۵: «Record extraction warnings when metadata
// is unavailable») — هرگز با مقدار ساختگی جایگزین نمی‌شوند.
// ═══════════════════════════════════════════════════════════════

namespace IdeaSchemaDump;

/// <summary>
/// مرجع یکتای کوئری‌های فرادادهٔ استخراج زنده (v3.0).
/// برای تست واحد (tests/IdealBridge.UnitTests/LiveSchemaSqlSecurityTests.cs)
/// و برای Program.cs — یک منبع، دو مصرف‌کننده، صفر انشعاب.
/// </summary>
public static class LiveSchemaSql
{
    // ─────────────────────────────────────────────
    // ۱) محیط غیرحساس سرور — بدون @@VERSION کامل (متن کامل شامل
    //    جزئیات سیستم‌عامل است و سیاست فاز ۱۲.۵ §۵ فقط نسخه/سطح/نسخه
    //    و سطح سازگاری را می‌خواهد). SERVERPROPERTY فقط.
    // ─────────────────────────────────────────────
    public const string ServerInfo = @"
SELECT CAST(SERVERPROPERTY('ProductVersion')  AS nvarchar(64))  AS ProductVersion,
       CAST(SERVERPROPERTY('ProductLevel')   AS nvarchar(64))  AS ProductLevel,
       CAST(SERVERPROPERTY('ProductMajorVersion') AS nvarchar(16)) AS ProductMajorVersion,
       CAST(SERVERPROPERTY('Edition')        AS nvarchar(128)) AS Edition,
       CAST(SERVERPROPERTY('EngineEdition')  AS int)           AS EngineEdition,
       CAST(SERVERPROPERTY('Collation')      AS nvarchar(128)) AS ServerCollation,
       @@SERVERNAME AS ServerName";

    // ─────────────────────────────────────────────
    // ۲) دیتابیس جاری — فقط تنظیمات ساختاری غیرحساس
    //    (سطح سازگاری/مرتب‌سازی/مدل بازیابی/فقط-خواندنی/Snapshot/RCS/CDC).
    //    هیچ Connection String و هیچ دادهٔ کسب‌وکار در خروجی نیست.
    // ─────────────────────────────────────────────
    public const string DatabaseInfo = @"
SELECT DB_NAME()                          AS DatabaseName,
       d.compatibility_level              AS CompatibilityLevel,
       d.collation_name                   AS Collation,
       d.recovery_model_desc              AS RecoveryModel,
       d.is_read_only                     AS IsReadOnly,
       d.state_desc                       AS State,
       d.snapshot_isolation_state_desc    AS SnapshotIsolation,
       d.is_read_committed_snapshot_on    AS ReadCommittedSnapshot,
       d.is_cdc_enabled                   AS IsCdcEnabled,
       d.log_reuse_wait_desc              AS LogReuseWait
FROM sys.databases d
WHERE d.database_id = DB_ID()";

    // ─────────────────────────────────────────────
    // ۳) همهٔ Schemaهای قابل‌مشاهده (dbo فقط نیست)
    // ─────────────────────────────────────────────
    public const string Schemas = @"
SELECT s.schema_id, s.name AS SchemaName
FROM sys.schemas s
ORDER BY s.schema_id";

    // ─────────────────────────────────────────────
    // ۴) همهٔ جدول‌ها در همهٔ Schemaها + پرچم‌های همگام‌سازی/تاریخچهٔ DDL
    //    (create_date/modify_date زمان آخرین تغییر «شیء» است، نه داده).
    // ─────────────────────────────────────────────
    public const string Tables = @"
SELECT t.object_id,
       s.name  AS SchemaName,
       t.name  AS TableName,
       t.is_replicated,
       t.has_replication_filter,
       t.is_merge_published,
       t.is_sync_tran_subscribed,
       t.create_date,
       t.modify_date
FROM sys.tables t
JOIN sys.schemas s ON s.schema_id = t.schema_id
ORDER BY s.name, t.name";

    // ─────────────────────────────────────────────
    // ۵) همهٔ ستون‌ها — نوع/طول/دقت/مقیاس/مرتب‌سازی/Nullable/Identity/
    //    Computed/Sparse. (بدون تعریف ماژول — ستون تعریفِ کلیدی نیست.)
    // ─────────────────────────────────────────────
    public const string Columns = @"
SELECT s.name  AS SchemaName,
       t.name  AS TableName,
       c.column_id,
       c.name  AS ColumnName,
       ty.name AS TypeName,
       c.max_length,
       c.precision,
       c.scale,
       c.collation_name,
       c.is_nullable,
       c.is_identity,
       c.is_computed,
       c.is_sparse
FROM sys.tables t
JOIN sys.schemas s  ON s.schema_id  = t.schema_id
JOIN sys.columns c  ON c.object_id   = t.object_id
JOIN sys.types   ty ON ty.user_type_id = c.user_type_id
ORDER BY s.name, t.name, c.column_id";

    // ─────────────────────────────────────────────
    // ۶) کلیدهای اصلی — همهٔ Schemaها
    // ─────────────────────────────────────────────
    public const string PrimaryKeys = @"
SELECT s.name AS SchemaName,
       t.name AS TableName,
       c.name AS ColumnName,
       ic.key_ordinal
FROM sys.key_constraints kc
JOIN sys.tables t        ON t.object_id  = kc.parent_object_id
JOIN sys.schemas s       ON s.schema_id  = t.schema_id
JOIN sys.index_columns ic ON ic.object_id = t.object_id AND ic.index_id = kc.unique_index_id
JOIN sys.columns c       ON c.object_id  = t.object_id AND c.column_id = ic.column_id
WHERE kc.type = 'PK'
ORDER BY s.name, t.name, ic.key_ordinal";

    // ─────────────────────────────────────────────
    // ۷) کلیدهای خارجی — کامل: روی DELETE/UPDATE + Disabled/NotTrusted
    // ─────────────────────────────────────────────
    public const string ForeignKeys = @"
SELECT fk.name AS ConstraintName,
       sp.name AS ParentSchema,  tp.name AS ParentTable,  cp.name AS ParentColumn,
       sr.name AS ReferencedSchema, tr.name AS ReferencedTable, cr.name AS ReferencedColumn,
       fk.delete_referential_action_desc AS OnDelete,
       fk.update_referential_action_desc AS OnUpdate,
       fk.is_disabled  AS IsDisabled,
       fk.is_not_trusted AS IsNotTrusted
FROM sys.foreign_keys fk
JOIN sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
JOIN sys.tables tp ON tp.object_id = fkc.parent_object_id
JOIN sys.schemas sp ON sp.schema_id = tp.schema_id
JOIN sys.columns cp ON cp.object_id = fkc.parent_object_id AND cp.column_id = fkc.parent_column_id
JOIN sys.tables tr ON tr.object_id = fkc.referenced_object_id
JOIN sys.schemas sr ON sr.schema_id = tr.schema_id
JOIN sys.columns cr ON cr.object_id = fkc.referenced_object_id AND cr.column_id = fkc.referenced_column_id
ORDER BY sp.name, tp.name, fk.name";

    // ─────────────────────────────────────────────
    // ۸) ایندکس‌ها — هستهٔ همه-نسخه‌ها (بدون has_filter که ۲۰۰۸+ است)
    // ─────────────────────────────────────────────
    public const string IndexesCore = @"
SELECT s.name AS SchemaName,
       t.name AS TableName,
       i.name AS IndexName,
       i.type_desc,
       i.is_unique,
       i.is_primary_key,
       c.name AS ColumnName,
       ic.key_ordinal,
       ic.is_included_column,
       ic.is_descending_key
FROM sys.indexes i
JOIN sys.tables t        ON t.object_id  = i.object_id
JOIN sys.schemas s       ON s.schema_id  = t.schema_id
JOIN sys.index_columns ic ON ic.object_id = i.object_id AND ic.index_id = i.index_id
JOIN sys.columns c       ON c.object_id  = t.object_id AND c.column_id = ic.column_id
WHERE i.name IS NOT NULL
ORDER BY s.name, t.name, i.name, ic.key_ordinal";

    // ─────────────────────────────────────────────
    // ۸-مکمل) Filter/Disable ایندکس‌ها (SQL 2008+) — فقط ردیف‌های مرتبط
    // ─────────────────────────────────────────────
    public const string IndexFilters = @"
SELECT s.name AS SchemaName,
       t.name AS TableName,
       i.name AS IndexName,
       i.is_disabled   AS IsDisabled,
       i.has_filter    AS HasFilter,
       i.filter_definition AS FilterDefinition
FROM sys.indexes i
JOIN sys.tables t  ON t.object_id = i.object_id
JOIN sys.schemas s  ON s.schema_id = t.schema_id
WHERE i.name IS NOT NULL AND (i.has_filter = 1 OR i.is_disabled = 1)
ORDER BY s.name, t.name, i.name";

    // ─────────────────────────────────────────────
    // ۹) ویوها — فقط نام + ستون‌ها. «بدون هیچ متن تعریف»
    //    (الزام فاز ۱۲.۵: تعریف کامل ویوها هرگز به JSON راه نمی‌یابد).
    // ─────────────────────────────────────────────
    public const string Views = @"
SELECT s.name AS SchemaName,
       v.name AS ViewName,
       c.name AS ColumnName,
       c.column_id
FROM sys.views v
JOIN sys.schemas s ON s.schema_id = v.schema_id
JOIN sys.columns c ON c.object_id = v.object_id
ORDER BY s.name, v.name, c.column_id";

    // ─────────────────────────────────────────────
    // ۱۰) Stored Procedureها — فقط نام + امضای پارامترها.
    //     «بدون متن تعریف» و بدون اجرا.
    // ─────────────────────────────────────────────
    public const string StoredProcedures = @"
SELECT s.name  AS SchemaName,
       p.name  AS SpName,
       pr.name AS ParamName,
       ty.name AS TypeName,
       pr.max_length,
       pr.precision,
       pr.scale,
       pr.is_output,
       pr.parameter_id
FROM sys.procedures p
JOIN sys.schemas s ON s.schema_id = p.schema_id
LEFT JOIN sys.parameters pr ON pr.object_id = p.object_id
LEFT JOIN sys.types ty ON ty.user_type_id = pr.user_type_id
ORDER BY s.name, p.name, pr.parameter_id";

    // ─────────────────────────────────────────────
    // ۱۱) توابع — سه‌گانهٔ اسکالر/جدولی-درجا/جدولی-چنددستوری
    //     (+ CLR/تجمیعی) با امضا. «بدون متن تعریف» و بدون اجرا.
    // ─────────────────────────────────────────────
    public const string Functions = @"
SELECT s.name  AS SchemaName,
       o.name  AS FunctionName,
       o.type_desc AS FunctionType,
       o.type     AS FunctionTypeCode,
       pr.name AS ParamName,
       ty.name AS TypeName,
       pr.max_length,
       pr.precision,
       pr.scale,
       pr.is_output,
       pr.parameter_id
FROM sys.objects o
JOIN sys.schemas s ON s.schema_id = o.schema_id
LEFT JOIN sys.parameters pr ON pr.object_id = o.object_id
LEFT JOIN sys.types ty ON ty.user_type_id = pr.user_type_id
WHERE o.type IN ('FN', 'IF', 'TF', 'AF', 'FS', 'FT')
ORDER BY s.name, o.name, pr.parameter_id";

    // ─────────────────────────────────────────────
    // ۱۲) تریگرها + رویدادها — نام/والد/نوع رویداد/Disabled.
    //     «بدون متن تعریف».
    // ─────────────────────────────────────────────
    public const string Triggers = @"
SELECT tr.object_id,
       s.name  AS TriggerSchema,
       tr.name AS TriggerName,
       tr.parent_class_desc AS ParentClass,
       ps.name AS ParentSchema,
       pt.name AS ParentTable,
       tr.type_desc AS TriggerType,
       tr.is_disabled AS IsDisabled
FROM sys.triggers tr
LEFT JOIN sys.schemas s  ON s.schema_id = tr.schema_id
LEFT JOIN sys.tables  pt ON pt.object_id = tr.parent_id
LEFT JOIN sys.schemas ps ON ps.schema_id = pt.schema_id
ORDER BY s.name, tr.name";

    public const string TriggerEvents = @"
SELECT te.object_id,
       te.type       AS EventTypeCode,
       te.type_desc  AS EventType,
       te.event_group_type_desc AS EventGroupType,
       te.is_first   AS IsFirst,
       te.is_last    AS IsLast
FROM sys.trigger_events te
ORDER BY te.object_id, te.type";

    // ─────────────────────────────────────────────
    // ۱۳) ستون‌های Identity — Seed/Increment (بدون last_value:
    //     state زمان اجراست و به فرادادهٔ ساختاری مربوط نیست).
    // ─────────────────────────────────────────────
    public const string IdentityColumns = @"
SELECT s.name AS SchemaName,
       t.name AS TableName,
       ic.name AS ColumnName,
       ic.seed_value,
       ic.increment_value
FROM sys.identity_columns ic
JOIN sys.tables t  ON t.object_id  = ic.object_id
JOIN sys.schemas s ON s.schema_id  = t.schema_id
ORDER BY s.name, t.name";

    // ─────────────────────────────────────────────
    // ۱۴) ستون‌های محاسباتی — عبارت سطح-ستون (فراداده؛ «ماژول» نیست)
    // ─────────────────────────────────────────────
    public const string ComputedColumns = @"
SELECT s.name AS SchemaName,
       t.name AS TableName,
       cc.name AS ColumnName,
       cc.definition AS Expression,
       cc.is_persisted AS IsPersisted
FROM sys.computed_columns cc
JOIN sys.tables t  ON t.object_id  = cc.object_id
JOIN sys.schemas s ON s.schema_id  = t.schema_id
ORDER BY s.name, t.name";

    // ─────────────────────────────────────────────
    // ۱۵) ستون‌های RowVersion — از نام نوع سیستمی «timestamp»
    //     (نام sys.types برای rowversion در همهٔ نسخه‌ها؛ پایدارتر از
    //     ستون‌های نسخه‌محور). هیچ مقدار RowVersion واقعی خوانده نمی‌شود.
    // ─────────────────────────────────────────────
    public const string RowVersionColumns = @"
SELECT s.name AS SchemaName,
       t.name AS TableName,
       c.name AS ColumnName
FROM sys.columns c
JOIN sys.tables t  ON t.object_id  = c.object_id
JOIN sys.schemas s ON s.schema_id  = t.schema_id
JOIN sys.types  ty ON ty.user_type_id = c.user_type_id
WHERE ty.name = N'timestamp'
ORDER BY s.name, t.name";

    // ─────────────────────────────────────────────
    // ۱۶) Default Constraintها — عبارت سطح-ستون (فراداده؛ «ماژول» نیست)
    // ─────────────────────────────────────────────
    public const string DefaultConstraints = @"
SELECT s.name AS SchemaName,
       t.name AS TableName,
       c.name AS ColumnName,
       dc.name AS ConstraintName,
       dc.definition AS DefaultValue
FROM sys.default_constraints dc
JOIN sys.tables t  ON t.object_id  = dc.parent_object_id
JOIN sys.schemas s ON s.schema_id  = t.schema_id
JOIN sys.columns c ON c.object_id = t.object_id AND c.column_id = dc.parent_column_id
ORDER BY s.name, t.name";

    // ─────────────────────────────────────────────
    // ۱۷-مکمل) جدول‌های Temporal (SQL 2016+) — با جدول History
    // ─────────────────────────────────────────────
    public const string TemporalTables = @"
SELECT s.name AS SchemaName,
       t.name AS TableName,
       t.temporal_type      AS TemporalType,
       t.temporal_type_desc AS TemporalTypeDesc,
       hs.name AS HistorySchema,
       h.name  AS HistoryTable
FROM sys.tables t
JOIN sys.schemas s ON s.schema_id = t.schema_id
LEFT JOIN sys.tables h  ON h.object_id = t.history_table_id
LEFT JOIN sys.schemas hs ON hs.schema_id = h.schema_id
WHERE t.temporal_type IN (1, 2)
ORDER BY s.name, t.name";

    // ─────────────────────────────────────────────
    // ۱۸-مکمل) جدول‌های Memory-Optimized (SQL 2014+)
    // ─────────────────────────────────────────────
    public const string MemoryOptimizedTables = @"
SELECT s.name AS SchemaName,
       t.name AS TableName
FROM sys.tables t
JOIN sys.schemas s ON s.schema_id = t.schema_id
WHERE t.is_memory_optimized = 1
ORDER BY s.name, t.name";

    // ─────────────────────────────────────────────
    // ۱۹-مکمل) ستون‌های GENERATED ALWAYS (SQL 2016+)
    // ─────────────────────────────────────────────
    public const string GeneratedAlwaysColumns = @"
SELECT s.name AS SchemaName,
       t.name AS TableName,
       c.name AS ColumnName,
       c.generated_always_type      AS GeneratedAlwaysType,
       c.generated_always_type_desc AS GeneratedAlwaysTypeDesc,
       c.is_hidden                  AS IsHidden
FROM sys.columns c
JOIN sys.tables t  ON t.object_id  = c.object_id
JOIN sys.schemas s ON s.schema_id  = t.schema_id
WHERE c.generated_always_type <> 0
ORDER BY s.name, t.name";

    // ─────────────────────────────────────────────
    // ۲۰) اشیای Schema «cdc» — فقط از sys.objects (فهرست نام/نوع).
    //     جدول‌های cdc.change_tables مستقیم خوانده «نمی‌شوند» (نیازمند
    //     SELECT است که حساب ibk_schema_reader ندارد و سیاست فاز ۱۲.۵
    //     درخواست مجوز جدید را ممنوع می‌کند). نمونه‌های Capture از الگوی
    //     نام اشیای cdc استنتاج می‌شود — خواندن «تغییرات واقعی» هرگز
    //     انجام نمی‌شود.
    // ─────────────────────────────────────────────
    public const string CdcObjects = @"
SELECT s.name  AS SchemaName,
       o.name  AS ObjectName,
       o.type_desc AS ObjectType
FROM sys.objects o
JOIN sys.schemas s ON s.schema_id = o.schema_id
WHERE s.name = N'cdc'
ORDER BY o.name";

    // ─────────────────────────────────────────────
    // ۲۱-مکمل) Change Tracking — سطح دیتابیس (سراسری؛ ردیف فقط برای
    //     دیتابیس‌های فعال CT برگردانده می‌شود = «خاموش» اگر خالی بود)
    // ─────────────────────────────────────────────
    public const string ChangeTrackingDatabase = @"
SELECT ctd.database_id,
       ctd.is_auto_cleanup_on          AS IsAutoCleanupOn,
       ctd.retention_period            AS RetentionPeriod,
       ctd.retention_period_units_desc AS RetentionPeriodUnits
FROM sys.change_tracking_databases ctd
WHERE ctd.database_id = DB_ID()";

    // ۲۱-مکمل-ب) Change Tracking — سطح جدول (is_track_columns_updated_on)
    public const string ChangeTrackingTables = @"
SELECT ctt.object_id,
       ctt.is_track_columns_updated_on AS IsTrackColumnsUpdatedOn,
       ctt.begin_version               AS BeginVersion,
       ctt.cleanup_version             AS CleanupVersion,
       ctt.min_valid_version           AS MinValidVersion
FROM sys.change_tracking_tables ctt";

    /// <summary>
    /// همهٔ کوئری‌های فراداده — تست‌های امنیتی ساختاری روی همین فهرست
    /// اجرا می‌شوند؛ هر کوئری جدید «باید» به این فهرست اضافه شود.
    /// </summary>
    public static readonly string[] All =
    {
        ServerInfo, DatabaseInfo, Schemas, Tables, Columns, PrimaryKeys, ForeignKeys,
        IndexesCore, IndexFilters, Views, StoredProcedures, Functions, Triggers,
        TriggerEvents, IdentityColumns, ComputedColumns, RowVersionColumns,
        DefaultConstraints, TemporalTables, MemoryOptimizedTables, GeneratedAlwaysColumns,
        CdcObjects, ChangeTrackingDatabase, ChangeTrackingTables,
    };

    /// <summary>نام کوتاه کوئری برای پیام تست/هشدار.</summary>
    public static readonly (string Key, string Sql)[] Named =
    {
        ("serverInfo",            ServerInfo),
        ("databaseInfo",          DatabaseInfo),
        ("schemas",               Schemas),
        ("tables",                Tables),
        ("columns",               Columns),
        ("primaryKeys",           PrimaryKeys),
        ("foreignKeys",           ForeignKeys),
        ("indexesCore",           IndexesCore),
        ("indexFilters",          IndexFilters),
        ("views",                 Views),
        ("storedProcedures",      StoredProcedures),
        ("functions",             Functions),
        ("triggers",              Triggers),
        ("triggerEvents",         TriggerEvents),
        ("identityColumns",       IdentityColumns),
        ("computedColumns",       ComputedColumns),
        ("rowVersionColumns",     RowVersionColumns),
        ("defaultConstraints",    DefaultConstraints),
        ("temporalTables",        TemporalTables),
        ("memoryOptimizedTables", MemoryOptimizedTables),
        ("generatedAlwaysColumns",GeneratedAlwaysColumns),
        ("cdcObjects",            CdcObjects),
        ("changeTrackingDatabase",ChangeTrackingDatabase),
        ("changeTrackingTables",  ChangeTrackingTables),
    };
}
