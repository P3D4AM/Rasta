using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspSelectUserTempNumberInModeViewModel
{
	public long ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Selector")]
	public bool Selector { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "sutnMobile")]
	public string Mobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "sutnCompanyName")]
	public string CompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "sutnPersonName")]
	public string PersonName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "sutnPhone")]
	public string Phone { get; set; }

	public int CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int MobileLength { get; set; }

	public string MobilePreNum { get; set; }

	public int UserId { get; set; }

	public string cmpTitle { get; set; }

	public string cmpName { get; set; }

	public string PrsTitle { get; set; }

	public string PrsFName { get; set; }

	public string PrsLName { get; set; }

	public string PrsJob { get; set; }

	public string Body { get; set; }

	public int? BodyCount { get; set; }

	public string BodyLangType { get; set; }

	public decimal? BodyCost { get; set; }

	public int? SID { get; set; }

	public Guid? GUId { get; set; }
}
