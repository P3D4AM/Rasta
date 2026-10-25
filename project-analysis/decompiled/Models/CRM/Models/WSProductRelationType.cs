using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductRelationTypeMetadata))]
public class WSProductRelationType
{
	public int ProductRelationTypeId { get; set; }

	public string RelationTypeName { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSProductRelationLimit> WSProductRelationLimit { get; set; }

	public virtual ICollection<WSProductRelationType_Lang> WSProductRelationType_Lang { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductRelationType()
	{
		WSProductRelationLimit = (ICollection<WSProductRelationLimit>)new HashSet<WSProductRelationLimit>();
		WSProductRelationType_Lang = (ICollection<WSProductRelationType_Lang>)new HashSet<WSProductRelationType_Lang>();
	}
}
