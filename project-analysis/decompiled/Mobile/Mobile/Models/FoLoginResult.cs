using System.Collections.Generic;

namespace Mobile.Models;

public class FoLoginResult
{
	public string Token { get; set; }

	public int CompanyID { get; set; }

	public int? cmpNumber { get; set; }

	public string cmpName { get; set; }

	public string CompanyName { get; set; }

	public double CompanyScore { get; set; }

	public int MaxFileSizeForUploadMb { get; set; }

	public int cmpMainPersonId { get; set; }

	public string cmpMobile { get; set; }

	public string cmpPrsMobile { get; set; }

	public bool VBTicketPlus { get; set; }

	public bool VBOnlinePay { get; set; }

	public bool VBAttachFiles { get; set; }

	public List<FOMobspSelectCompanyProjectValidityPrd_Result> CompanyProjectValidityPrd { get; set; }

	public List<string> MaliciousFileExtensions { get; set; }

	public int FileDirectoryTitleLength { get; set; }

	public bool VBSimpleTicket { get; set; }

	public bool VBCallerId { get; set; }

	public bool VBRecorder { get; set; }

	public bool cmpFOIsActive { get; set; }

	public int LoginType { get; set; }

	public string cmpPersonName { get; set; }

	public string FoActiveCIds { get; set; }

	public int? LastCId { get; set; }

	public bool? VBCenter { get; set; }
}
