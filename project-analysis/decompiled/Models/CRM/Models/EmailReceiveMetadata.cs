using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class EmailReceiveMetadata
{
	[Key]
	public int EmailReceiveId { get; set; }

	public string MessageId { get; set; }

	public DateTime? EmailDate { get; set; }

	public string EmailDatePersian { get; set; }

	public string FromUserEmail { get; set; }

	public string ToUserEmail { get; set; }

	public string Bcc { get; set; }

	public string Cc { get; set; }

	public string Subject { get; set; }

	public string Body { get; set; }

	public string HtmlBody { get; set; }

	public string FolderName { get; set; }

	public DateTime? ReceiveDate { get; set; }

	public string ReceiveDatePersian { get; set; }

	public bool? IsRead { get; set; }

	public DateTime? ReadDate { get; set; }

	public string ReadDatePersian { get; set; }

	public string Priority { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }
}
