using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanCustomerOneInfoViewModel
{
	public int? recNo { get; set; }

	public int? company { get; set; }

	public int? refFormal { get; set; }

	public string customerCode { get; set; }

	public bool? lockNational { get; set; }

	public string nationalCode { get; set; }

	public bool? lockEconomic { get; set; }

	public string economicCode { get; set; }

	public int? indexCredit { get; set; }

	public int? indexKind { get; set; }

	public int? indexClass { get; set; }

	public int? indexState { get; set; }

	public int? indexOwner { get; set; }

	public int? refGuild { get; set; }

	public string dateSayNIDEID { get; set; }

	public int? rnPersona { get; set; }

	public int? rnCompany { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
