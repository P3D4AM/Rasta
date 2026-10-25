using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsSendTypeMetadata))]
public class SmsSendType
{
	public int ID { get; set; }

	public string SMSSendType1 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<SmsSendType_Lang> SmsSendType_Lang { get; set; }

	public virtual Users Users { get; set; }

	public SmsSendType()
	{
		SmsSendType_Lang = (ICollection<SmsSendType_Lang>)new HashSet<SmsSendType_Lang>();
	}
}
