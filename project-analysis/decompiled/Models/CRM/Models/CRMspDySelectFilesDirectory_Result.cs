using System;

namespace CRM.Models;

public class CRMspDySelectFilesDirectory_Result
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

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string DocDate { get; set; }

	public string DocDay { get; set; }

	public string DocTime { get; set; }

	public Guid? GUId { get; set; }

	public DateTime? DocDateTime { get; set; }

	public int? TypeOprObjectId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string prjTitle { get; set; }

	public string FileDirectoryType { get; set; }

	public string FileDirectoryTypeOpr { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int? OrderView { get; set; }

	public int? TypeOprObjectIdI { get; set; }

	public int? TypeOprObjectIdII { get; set; }

	public string FileDesc { get; set; }

	public string FileDescLangJson { get; set; }
}
