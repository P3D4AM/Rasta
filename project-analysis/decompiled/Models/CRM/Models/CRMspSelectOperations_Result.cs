using System;

namespace CRM.Models;

public class CRMspSelectOperations_Result
{
	public string Type { get; set; }

	public int? FileDirectoryTypeOprId { get; set; }

	public int Id { get; set; }

	public long OprNumber { get; set; }

	public DateTime? OprDateTime { get; set; }

	public string OprDatePerWithSlash { get; set; }

	public decimal? TotalAmount { get; set; }

	public int? CompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? PersonId { get; set; }

	public string PersonName { get; set; }

	public int? ProjectId { get; set; }

	public string Project { get; set; }

	public int? ReferUserId { get; set; }

	public string ReferUser { get; set; }

	public string FullName { get; set; }

	public int? OprId { get; set; }

	public string Opr { get; set; }
}
