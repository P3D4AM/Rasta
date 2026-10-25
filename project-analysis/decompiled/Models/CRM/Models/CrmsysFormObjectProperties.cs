using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysFormObjectPropertiesMetadata))]
public class CrmsysFormObjectProperties
{
	public int ID { get; set; }

	public int? FormId { get; set; }

	public string ObjectType { get; set; }

	public string ObjectName { get; set; }

	public string ObjectPersianName { get; set; }

	public bool? Visible { get; set; }

	public bool? Enable { get; set; }

	public int? Leftt { get; set; }

	public int? Topp { get; set; }

	public int? Width { get; set; }

	public int? Height { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? LanguageID { get; set; }

	public virtual CrmsysForms CrmsysForms { get; set; }

	public virtual ICollection<CrmsysFormObjectProperties_Lang> CrmsysFormObjectProperties_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmsysFormObjectProperties()
	{
		CrmsysFormObjectProperties_Lang = (ICollection<CrmsysFormObjectProperties_Lang>)new HashSet<CrmsysFormObjectProperties_Lang>();
	}
}
