using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace CRMIdeal.SmsKaveNegar;

[Serializable]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[XmlType(Namespace = "http://api.kavenegar.com/")]
public enum BulkRecipientType
{
	PermanentCells,
	TemporaryCells,
	AllCells
}
