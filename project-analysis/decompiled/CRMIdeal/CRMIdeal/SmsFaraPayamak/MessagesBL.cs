using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CRMIdeal.SmsFaraPayamak;

[Serializable]
[GeneratedCode("System.Xml", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
public class MessagesBL : BaseBL
{
	private long msgIDField;

	private int userIDField;

	private int linkIDField;

	private int numberIDField;

	private double tariffField;

	private byte msgTypeField;

	private string bodyField;

	private string udhField;

	private DateTime sendDateField;

	private string senderField;

	private string receiverField;

	private int firstLocationField;

	private int currentLocationField;

	private int partsField;

	private bool isFlashField;

	private bool isReadField;

	private bool isUnicodeField;

	private double creditField;

	private int moduleField;

	private int recCountField;

	private int recFailedField;

	private int recSuccessField;

	private bool isMoneyBackField;

	private int userStepedMasterField;

	private int userMasterField;

	private int moneyBackCountField;

	private int moneyBackLevelField;

	private bool? autoSpeechTextField;

	private int? shareServiceBodyIDField;

	[XmlElement(Order = 0)]
	public long MsgID
	{
		get
		{
			return msgIDField;
		}
		set
		{
			msgIDField = value;
			RaisePropertyChanged("MsgID");
		}
	}

	[XmlElement(Order = 1)]
	public int UserID
	{
		get
		{
			return userIDField;
		}
		set
		{
			userIDField = value;
			RaisePropertyChanged("UserID");
		}
	}

	[XmlElement(Order = 2)]
	public int LinkID
	{
		get
		{
			return linkIDField;
		}
		set
		{
			linkIDField = value;
			RaisePropertyChanged("LinkID");
		}
	}

	[XmlElement(Order = 3)]
	public int NumberID
	{
		get
		{
			return numberIDField;
		}
		set
		{
			numberIDField = value;
			RaisePropertyChanged("NumberID");
		}
	}

	[XmlElement(Order = 4)]
	public double Tariff
	{
		get
		{
			return tariffField;
		}
		set
		{
			tariffField = value;
			RaisePropertyChanged("Tariff");
		}
	}

	[XmlElement(Order = 5)]
	public byte MsgType
	{
		get
		{
			return msgTypeField;
		}
		set
		{
			msgTypeField = value;
			RaisePropertyChanged("MsgType");
		}
	}

	[XmlElement(Order = 6)]
	public string Body
	{
		get
		{
			return bodyField;
		}
		set
		{
			bodyField = value;
			RaisePropertyChanged("Body");
		}
	}

	[XmlElement(Order = 7)]
	public string Udh
	{
		get
		{
			return udhField;
		}
		set
		{
			udhField = value;
			RaisePropertyChanged("Udh");
		}
	}

	[XmlElement(Order = 8)]
	public DateTime SendDate
	{
		get
		{
			return sendDateField;
		}
		set
		{
			sendDateField = value;
			RaisePropertyChanged("SendDate");
		}
	}

	[XmlElement(Order = 9)]
	public string Sender
	{
		get
		{
			return senderField;
		}
		set
		{
			senderField = value;
			RaisePropertyChanged("Sender");
		}
	}

	[XmlElement(Order = 10)]
	public string Receiver
	{
		get
		{
			return receiverField;
		}
		set
		{
			receiverField = value;
			RaisePropertyChanged("Receiver");
		}
	}

	[XmlElement(Order = 11)]
	public int FirstLocation
	{
		get
		{
			return firstLocationField;
		}
		set
		{
			firstLocationField = value;
			RaisePropertyChanged("FirstLocation");
		}
	}

	[XmlElement(Order = 12)]
	public int CurrentLocation
	{
		get
		{
			return currentLocationField;
		}
		set
		{
			currentLocationField = value;
			RaisePropertyChanged("CurrentLocation");
		}
	}

	[XmlElement(Order = 13)]
	public int Parts
	{
		get
		{
			return partsField;
		}
		set
		{
			partsField = value;
			RaisePropertyChanged("Parts");
		}
	}

	[XmlElement(Order = 14)]
	public bool IsFlash
	{
		get
		{
			return isFlashField;
		}
		set
		{
			isFlashField = value;
			RaisePropertyChanged("IsFlash");
		}
	}

	[XmlElement(Order = 15)]
	public bool IsRead
	{
		get
		{
			return isReadField;
		}
		set
		{
			isReadField = value;
			RaisePropertyChanged("IsRead");
		}
	}

	[XmlElement(Order = 16)]
	public bool IsUnicode
	{
		get
		{
			return isUnicodeField;
		}
		set
		{
			isUnicodeField = value;
			RaisePropertyChanged("IsUnicode");
		}
	}

	[XmlElement(Order = 17)]
	public double Credit
	{
		get
		{
			return creditField;
		}
		set
		{
			creditField = value;
			RaisePropertyChanged("Credit");
		}
	}

	[XmlElement(Order = 18)]
	public int Module
	{
		get
		{
			return moduleField;
		}
		set
		{
			moduleField = value;
			RaisePropertyChanged("Module");
		}
	}

	[XmlElement(Order = 19)]
	public int RecCount
	{
		get
		{
			return recCountField;
		}
		set
		{
			recCountField = value;
			RaisePropertyChanged("RecCount");
		}
	}

	[XmlElement(Order = 20)]
	public int RecFailed
	{
		get
		{
			return recFailedField;
		}
		set
		{
			recFailedField = value;
			RaisePropertyChanged("RecFailed");
		}
	}

	[XmlElement(Order = 21)]
	public int RecSuccess
	{
		get
		{
			return recSuccessField;
		}
		set
		{
			recSuccessField = value;
			RaisePropertyChanged("RecSuccess");
		}
	}

	[XmlElement(Order = 22)]
	public bool IsMoneyBack
	{
		get
		{
			return isMoneyBackField;
		}
		set
		{
			isMoneyBackField = value;
			RaisePropertyChanged("IsMoneyBack");
		}
	}

	[XmlElement(Order = 23)]
	public int UserStepedMaster
	{
		get
		{
			return userStepedMasterField;
		}
		set
		{
			userStepedMasterField = value;
			RaisePropertyChanged("UserStepedMaster");
		}
	}

	[XmlElement(Order = 24)]
	public int UserMaster
	{
		get
		{
			return userMasterField;
		}
		set
		{
			userMasterField = value;
			RaisePropertyChanged("UserMaster");
		}
	}

	[XmlElement(Order = 25)]
	public int MoneyBackCount
	{
		get
		{
			return moneyBackCountField;
		}
		set
		{
			moneyBackCountField = value;
			RaisePropertyChanged("MoneyBackCount");
		}
	}

	[XmlElement(Order = 26)]
	public int MoneyBackLevel
	{
		get
		{
			return moneyBackLevelField;
		}
		set
		{
			moneyBackLevelField = value;
			RaisePropertyChanged("MoneyBackLevel");
		}
	}

	[XmlElement(IsNullable = true, Order = 27)]
	public bool? AutoSpeechText
	{
		get
		{
			return autoSpeechTextField;
		}
		set
		{
			autoSpeechTextField = value;
			RaisePropertyChanged("AutoSpeechText");
		}
	}

	[XmlElement(IsNullable = true, Order = 28)]
	public int? ShareServiceBodyID
	{
		get
		{
			return shareServiceBodyIDField;
		}
		set
		{
			shareServiceBodyIDField = value;
			RaisePropertyChanged("ShareServiceBodyID");
		}
	}
}
