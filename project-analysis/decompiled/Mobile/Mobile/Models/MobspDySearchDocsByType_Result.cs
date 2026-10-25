using System;

namespace Mobile.Models;

public class MobspDySearchDocsByType_Result
{
	public int DocID { get; set; }

	public int OprId { get; set; }

	public string DocOpr { get; set; }

	public int DocNumber { get; set; }

	public string DocDate { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string DocInfo { get; set; }

	public string DocLinkAccDocNumber { get; set; }

	public string TxtHelp { get; set; }
}
