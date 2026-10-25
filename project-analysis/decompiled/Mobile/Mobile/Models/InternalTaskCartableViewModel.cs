using System.Collections.Generic;

namespace Mobile.Models;

public class InternalTaskCartableViewModel
{
	public int? InternalMessageId { get; set; }

	public int? MsgTypeId { get; set; }

	public string MessageType { get; set; }

	public int? InternalMessageDetailId { get; set; }

	public string SendDate { get; set; }

	public string SendDatePersian { get; set; }

	public string ReceiveDate { get; set; }

	public string ReceiveDatePersian { get; set; }

	public string ReadDate { get; set; }

	public string ReadDatePersian { get; set; }

	public bool? IsRead { get; set; }

	public string RequestFromDate { get; set; }

	public string RequestToDate { get; set; }

	public int? MsgdAttachRecId { get; set; }

	public int? CompanyId { get; set; }

	public int? ProjectId { get; set; }

	public int? OprId { get; set; }

	public int? msgdFromUserId { get; set; }

	public int? msgdPriorityId { get; set; }

	public int? msgdGroupId { get; set; }

	public bool? msgActiveInCycle { get; set; }

	public List<FileDirectoryViewModel> MsgFiles { get; set; }

	public List<IntMsgToUsersInfoViewModel> MsgToUsersInfo { get; set; }

	public Dictionary<string, object> MsgAdditionalInfo { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }

	public int CountPage { get; set; }
}
