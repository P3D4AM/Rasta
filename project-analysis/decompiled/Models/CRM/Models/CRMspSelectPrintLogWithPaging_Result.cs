using System;

namespace CRM.Models;

public class CRMspSelectPrintLogWithPaging_Result
{
	public int PrintLogId { get; set; }

	public int PrintFormatTypeId { get; set; }

	public string PrintFormatType { get; set; }

	public int ObjectId { get; set; }

	public DateTime? PrintDateTime { get; set; }

	public int? PrintUserId { get; set; }

	public string PrintUser { get; set; }

	public int? PrintCmpId { get; set; }

	public string PrintCmp { get; set; }

	public DateTime? SeenDateTime { get; set; }

	public int? SeenUserId { get; set; }

	public string SeenUser { get; set; }

	public int? SeenCmpId { get; set; }

	public string SeenCmp { get; set; }

	public DateTime? DownloadDateTime { get; set; }

	public int? DownloadUserId { get; set; }

	public string DownloadUser { get; set; }

	public int? DownloadCmpId { get; set; }

	public string DownloadCmp { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string PrintLogType { get; set; }

	public long? RowNumber { get; set; }

	public int? LastPrintLogId { get; set; }
}
