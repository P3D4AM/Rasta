using System;

namespace CRM.Models;

public class CRMspSelectLastFilesDirectory_Result
{
	public int FileDirectoryID { get; set; }

	public int? FileDirectoryTypeId { get; set; }

	public int? MasterId { get; set; }

	public int? DetailId { get; set; }

	public int? SubDetailId { get; set; }

	public string Title { get; set; }

	public string FolderName { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public string CopyFromPath { get; set; }

	public string DocDate { get; set; }

	public string DocDay { get; set; }

	public string DocTime { get; set; }

	public DateTime? DocDateTime { get; set; }

	public int? TypeOprObjectId { get; set; }

	public int? TypeOprObjectIdI { get; set; }

	public int? TypeOprObjectIdII { get; set; }

	public string FileDirectoryNumRef { get; set; }

	public int? FileDirectoryParentId { get; set; }

	public bool? FileFOCmpCanSee { get; set; }
}
