using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessageDefaultContextMetadata))]
public class CrmInternalMessageDefaultContext
{
	public int InternalMessageDefaultContextId { get; set; }

	public int ContextUserId { get; set; }

	public string Col1 { get; set; }

	public string Col2 { get; set; }

	public string Col3 { get; set; }

	public string Col4 { get; set; }

	public string Col5 { get; set; }

	public string Col6 { get; set; }

	public string Col7 { get; set; }

	public string Col8 { get; set; }

	public string Col9 { get; set; }

	public string Col10 { get; set; }

	public string Col11 { get; set; }

	public string Col12 { get; set; }

	public string Col13 { get; set; }

	public string Col14 { get; set; }

	public string Col15 { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public virtual ICollection<CrmInternalMessageDefaultContext_Lang> CrmInternalMessageDefaultContext_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public CrmInternalMessageDefaultContext()
	{
		CrmInternalMessageDefaultContext_Lang = (ICollection<CrmInternalMessageDefaultContext_Lang>)new HashSet<CrmInternalMessageDefaultContext_Lang>();
	}
}
