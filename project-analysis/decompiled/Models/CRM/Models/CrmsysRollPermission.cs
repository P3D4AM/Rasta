using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysRollPermissionMetadata))]
public class CrmsysRollPermission
{
	public int ID { get; set; }

	public int RollId { get; set; }

	public int FormId { get; set; }

	public int? FormActionId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CId { get; set; }

	public virtual CrmsysFormActions CrmsysFormActions { get; set; }

	public virtual CrmsysForms CrmsysForms { get; set; }

	public virtual CrmsysRolls CrmsysRolls { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }
}
