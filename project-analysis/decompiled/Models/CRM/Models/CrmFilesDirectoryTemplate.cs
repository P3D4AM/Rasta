using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFilesDirectoryTemplateMetadata))]
public class CrmFilesDirectoryTemplate
{
	public long FileDirectoryTemplateID { get; set; }

	public string Title { get; set; }

	public string CopyFromPath { get; set; }

	public int UserId { get; set; }

	public int TypeId { get; set; }

	public string AppType { get; set; }

	public Guid? GUId { get; set; }

	public int? FileDirectoryTypeId { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? LanguageID { get; set; }

	public int? ObjectId { get; set; }

	public int? ObjectIdI { get; set; }

	public int? ObjectIdII { get; set; }

	public int? ObjectIdIII { get; set; }

	public virtual CrmFileDirectoryType CrmFileDirectoryType { get; set; }

	public virtual CrmFilesDirectoryTemplateType CrmFilesDirectoryTemplateType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }
}
