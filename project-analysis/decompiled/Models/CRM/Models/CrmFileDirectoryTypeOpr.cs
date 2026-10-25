using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFileDirectoryTypeOprMetadata))]
public class CrmFileDirectoryTypeOpr
{
	public int FileDirectoryTypeOprId { get; set; }

	public string FileDirectoryTypeOpr { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmFileDirectoryType> CrmFileDirectoryType { get; set; }

	public virtual ICollection<CrmFileDirectoryTypeOpr_Lang> CrmFileDirectoryTypeOpr_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmFileDirectoryTypeOpr()
	{
		CrmFileDirectoryType = (ICollection<CrmFileDirectoryType>)new HashSet<CrmFileDirectoryType>();
		CrmFileDirectoryTypeOpr_Lang = (ICollection<CrmFileDirectoryTypeOpr_Lang>)new HashSet<CrmFileDirectoryTypeOpr_Lang>();
	}
}
