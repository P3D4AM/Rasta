using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CRMtmpManageTellNumberMetadata))]
public class CRMtmpManageTellNumber
{
	public int ID { get; set; }

	public int? UserId { get; set; }

	public int? cmpId { get; set; }

	public int? prsId { get; set; }

	public int? cmpCityId { get; set; }

	public bool? Sel { get; set; }

	public string cmpPreTel { get; set; }

	public string cmpPreTelNew { get; set; }

	public string cmpTel { get; set; }

	public string cmpTelNew { get; set; }

	public string cmpPreTelII { get; set; }

	public string cmpPreTelIINew { get; set; }

	public string cmpTelII { get; set; }

	public string cmpTelIINew { get; set; }

	public string cmpFax { get; set; }

	public string cmpFaxNew { get; set; }

	public int? mode { get; set; }

	public string AppType { get; set; }

	public Guid? GUId { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
