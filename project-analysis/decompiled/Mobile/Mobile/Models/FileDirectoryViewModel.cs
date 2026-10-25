using System.Collections.Generic;

namespace Mobile.Models;

public class FileDirectoryViewModel
{
	public int? FileDirectoryID { get; set; }

	public int? FileDirectoryTypeId { get; set; }

	public int? MasterId { get; set; }

	public int? DetailId { get; set; }

	public int? SubDetailId { get; set; }

	public int? TypeOprObjectId { get; set; }

	public string Title { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public string DocDate { get; set; }

	public string DocDatePersian { get; set; }

	public string DocDay { get; set; }

	public string DocDayPersian { get; set; }

	public string DocTime { get; set; }

	public string FileDirectoryType { get; set; }

	public string ProjectTitle { get; set; }

	public string CompanyName { get; set; }

	public int? FileDirectoryTypeOprId { get; set; }

	public string FileDirectoryTypeOpr { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }
}
