using System;
using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranRetailCustomerInfoViewModel
{
	public int? partyType { get; set; }

	public string economicCode { get; set; }

	public DateTime? creationDate { get; set; }

	public DateTime? declarationDate { get; set; }

	public long? id { get; set; }

	public string code { get; set; }

	public string firstName { get; set; }

	public string lastName { get; set; }

	public string nationalCode { get; set; }

	public DateTime? birthdate { get; set; }

	public DateTime? marriageDate { get; set; }

	public string tel { get; set; }

	public string mobile { get; set; }

	public long? representerId { get; set; }

	public long? salesOfficeId { get; set; }

	public List<RahkaranRetailCustomerAddressInfoViewModel> addresses { get; set; }
}
