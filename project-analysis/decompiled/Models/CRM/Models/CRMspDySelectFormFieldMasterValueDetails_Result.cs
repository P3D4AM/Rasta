using System;

namespace CRM.Models;

public class CRMspDySelectFormFieldMasterValueDetails_Result
{
	public int? CompanyId { get; set; }

	public string Company { get; set; }

	public int? CompanyPersonId { get; set; }

	public string CompanyPerson { get; set; }

	public int? ProjectId { get; set; }

	public string Project { get; set; }

	public int? ConversationId { get; set; }

	public string cnvsDesc { get; set; }

	public string cnvsDate { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public int? MasterObjectId { get; set; }

	public string MasterObjectInfo { get; set; }

	public string MasterObjectDate { get; set; }

	public DateTime? MasterObjectDateTime { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public string cnvsTopic { get; set; }
}
