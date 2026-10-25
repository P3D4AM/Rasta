using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysFormActionsMetadata))]
public class CrmsysFormActions
{
	public int ID { get; set; }

	public int FormId { get; set; }

	public string ActionPersianName { get; set; }

	public string ActionName { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? ActionGroupId { get; set; }

	public string ActionGroupName { get; set; }

	public int? ActionPriorityId { get; set; }

	public string ActionDesc { get; set; }

	public string ActionIcon { get; set; }

	public string ActionStyle { get; set; }

	public string ActionHelpLink { get; set; }

	public int? OrderView { get; set; }

	public bool? ActionDeActive { get; set; }

	public virtual CrmsysForms CrmsysForms { get; set; }

	public virtual ICollection<CrmsysFormActions_Lang> CrmsysFormActions_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmsysRollPermission> CrmsysRollPermission { get; set; }

	public virtual Users Users { get; set; }

	public CrmsysFormActions()
	{
		CrmsysFormActions_Lang = (ICollection<CrmsysFormActions_Lang>)new HashSet<CrmsysFormActions_Lang>();
		CrmsysRollPermission = (ICollection<CrmsysRollPermission>)new HashSet<CrmsysRollPermission>();
	}
}
