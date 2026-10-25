using System;
using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesCustomerResponseViewModel
{
	public List<RahkaranInternalSalesCustomerAddressInfoViewModel> Addresses { get; set; }

	public DateTime? BirthDate { get; set; }

	public string CompanyName { get; set; }

	public DateTime? CreationDate { get; set; }

	public string DLCode { get; set; }

	public string EconomicCode { get; set; }

	public string Email { get; set; }

	public string FidaRegistration { get; set; }

	public string FirstName { get; set; }

	public long? ID { get; set; }

	public string LastModificationDate { get; set; }

	public string LastName { get; set; }

	public string Mobile { get; set; }

	public string NationalID { get; set; }

	public string Number { get; set; }

	public long? ParentCustomerRef { get; set; }

	public long? PartyRef { get; set; }

	public int? PartyType { get; set; }

	public string RegistrationCode { get; set; }

	public long? Status { get; set; }

	public string Tel { get; set; }

	public long? Type { get; set; }

	public string WebsiteUrl { get; set; }

	public string Alias { get; set; }
}
