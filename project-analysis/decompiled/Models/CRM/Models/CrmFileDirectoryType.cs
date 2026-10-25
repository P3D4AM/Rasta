using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFileDirectoryTypeMetadata))]
public class CrmFileDirectoryType
{
	public int FileDirectoryTypeID { get; set; }

	public string FileDirectoryType { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? FileDirectoryTypeOprId { get; set; }

	public int? OrderView { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual CrmFileDirectoryTypeOpr CrmFileDirectoryTypeOpr { get; set; }

	public virtual ICollection<CrmFileDirectoryType_Lang> CrmFileDirectoryType_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmFilesDirectory> CrmFilesDirectory { get; set; }

	public virtual ICollection<CrmFilesDirectoryTemplate> CrmFilesDirectoryTemplate { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmFileDirectoryType()
	{
		CrmFileDirectoryType_Lang = (ICollection<CrmFileDirectoryType_Lang>)new HashSet<CrmFileDirectoryType_Lang>();
		CrmFilesDirectory = (ICollection<CrmFilesDirectory>)new HashSet<CrmFilesDirectory>();
		CrmFilesDirectoryTemplate = (ICollection<CrmFilesDirectoryTemplate>)new HashSet<CrmFilesDirectoryTemplate>();
	}
}
