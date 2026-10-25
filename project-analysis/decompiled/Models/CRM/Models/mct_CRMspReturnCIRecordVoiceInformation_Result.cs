using System;

namespace CRM.Models;

public class mct_CRMspReturnCIRecordVoiceInformation_Result
{
	public int ID { get; set; }

	public string CINumber { get; set; }

	public string Phone { get; set; }

	public string CallDate { get; set; }

	public string CallTime { get; set; }

	public string CallLenght { get; set; }

	public string HaveFile { get; set; }

	public string FilePath { get; set; }

	public string CallType { get; set; }

	public string Dial { get; set; }

	public int Line { get; set; }

	public string FilePathWeb { get; set; }

	public DateTime? CallDateTime { get; set; }

	public string internalDial { get; set; }

	public string internalName { get; set; }

	public int? DevType { get; set; }
}
