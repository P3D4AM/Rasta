using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollListMetadata))]
public class PayRollList
{
	public int PayRollListId { get; set; }

	public int? PayRollListGroupId { get; set; }

	public string ListTitle { get; set; }

	public int ListYear { get; set; }

	public int ListMonth { get; set; }

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

	public int LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<PayRollList_Lang> PayRollList_Lang { get; set; }

	public virtual PayRollListGroups PayRollListGroups { get; set; }

	public virtual ICollection<PayRollListItems> PayRollListItems { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public PayRollList()
	{
		PayRollList_Lang = (ICollection<PayRollList_Lang>)new HashSet<PayRollList_Lang>();
		PayRollListItems = (ICollection<PayRollListItems>)new HashSet<PayRollListItems>();
	}
}
