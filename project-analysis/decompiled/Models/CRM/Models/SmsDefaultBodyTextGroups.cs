using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsDefaultBodyTextGroupsMetadata))]
public class SmsDefaultBodyTextGroups
{
	public int Id { get; set; }

	public short? Code { get; set; }

	public string Name { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? OrderView { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<SmsDefaultBodyText> SmsDefaultBodyText { get; set; }

	public virtual ICollection<SmsDefaultBodyTextGroups_Lang> SmsDefaultBodyTextGroups_Lang { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public SmsDefaultBodyTextGroups()
	{
		SmsDefaultBodyText = (ICollection<SmsDefaultBodyText>)new HashSet<SmsDefaultBodyText>();
		SmsDefaultBodyTextGroups_Lang = (ICollection<SmsDefaultBodyTextGroups_Lang>)new HashSet<SmsDefaultBodyTextGroups_Lang>();
	}
}
