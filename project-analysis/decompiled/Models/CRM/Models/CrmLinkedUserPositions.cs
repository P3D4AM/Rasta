using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkedUserPositionsMetadata))]
public class CrmLinkedUserPositions
{
	public int LinkedUserPositionId { get; set; }

	public int LinkedTypeId { get; set; }

	public int PositionId { get; set; }

	public int LinkedPositionId { get; set; }

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

	public int? CId { get; set; }

	public virtual CrmLinkedType CrmLinkedType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual UserPositions UserPositions { get; set; }

	public virtual UserPositions UserPositions1 { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
