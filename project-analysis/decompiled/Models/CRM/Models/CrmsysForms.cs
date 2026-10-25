using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysFormsMetadata))]
public class CrmsysForms
{
	public int ID { get; set; }

	public string FormPersianName { get; set; }

	public string FormName { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmsysFormActions> CrmsysFormActions { get; set; }

	public virtual ICollection<CrmsysFormObjectProperties> CrmsysFormObjectProperties { get; set; }

	public virtual ICollection<CrmsysForms_Lang> CrmsysForms_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmsysRollPermission> CrmsysRollPermission { get; set; }

	public virtual Users Users { get; set; }

	public CrmsysForms()
	{
		CrmsysFormActions = (ICollection<CrmsysFormActions>)new HashSet<CrmsysFormActions>();
		CrmsysFormObjectProperties = (ICollection<CrmsysFormObjectProperties>)new HashSet<CrmsysFormObjectProperties>();
		CrmsysForms_Lang = (ICollection<CrmsysForms_Lang>)new HashSet<CrmsysForms_Lang>();
		CrmsysRollPermission = (ICollection<CrmsysRollPermission>)new HashSet<CrmsysRollPermission>();
	}
}
