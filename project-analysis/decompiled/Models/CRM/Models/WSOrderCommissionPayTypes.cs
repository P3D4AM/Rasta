using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderCommissionPayTypesMetadata))]
public class WSOrderCommissionPayTypes
{
	public int OrderCommissionPayTypeId { get; set; }

	public string CommPayTypeTitle { get; set; }

	public string CommPayTypeDescription { get; set; }

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

	public int? OrderView { get; set; }

	public int LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSOrderCommissionPayTypes_Lang> WSOrderCommissionPayTypes_Lang { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSOrderCommissionPayTypes()
	{
		WSOrderCommissionPayTypes_Lang = (ICollection<WSOrderCommissionPayTypes_Lang>)new HashSet<WSOrderCommissionPayTypes_Lang>();
		WSPreOrderCommissions = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
	}
}
