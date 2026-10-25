using System;

namespace Mobile.Models;

public class FOMobspSelectCentersWithIds_Result
{
	public int CenterID { get; set; }

	public string CenterName { get; set; }

	public string CenterDesc { get; set; }

	public bool? CenterInActive { get; set; }

	public int? OrderView { get; set; }

	public byte[] CenterPicture { get; set; }

	public string LinkAccCenterCode { get; set; }

	public string LinkAccCenterIdStr { get; set; }

	public string LinkAccData { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public int? FoSettingId { get; set; }
}
