using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace CRMIdeal.LinkKyan;

[Serializable]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[XmlType(Namespace = "KyanOnlineSaleService")]
public enum ItemType
{
	General,
	TemplateParent,
	TemplateChild,
	MatrisParent,
	MatrisChild,
	Discount,
	Service,
	Variety,
	Pack,
	Bulk,
	UnKnown
}
