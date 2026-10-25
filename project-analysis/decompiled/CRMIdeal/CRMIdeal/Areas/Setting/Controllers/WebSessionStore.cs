using System;
using System.IO;
using CRM.General.IO;
using TLSharp.Core;

namespace CRMIdeal.Areas.Setting.Controllers;

public class WebSessionStore : ISessionStore
{
	private int settingId;

	public WebSessionStore(int settingId)
	{
		this.settingId = settingId;
	}

	public void Save(Session session)
	{
		string text = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\WebTelegramSession\\\\";
		if (!System.IO.Directory.Exists(text))
		{
			System.IO.Directory.CreateDirectory(text);
			CRM.General.IO.Directory.SetFullControlForEveryOne(text);
		}
		text = text + "TelegSetting-" + settingId + "\\";
		if (!System.IO.Directory.Exists(text))
		{
			System.IO.Directory.CreateDirectory(text);
			CRM.General.IO.Directory.SetFullControlForEveryOne(text);
		}
		using FileStream fileStream = new FileStream(string.Format(text + "{0}.dat", session.SessionUserId), FileMode.OpenOrCreate);
		byte[] array = session.ToBytes();
		fileStream.Write(array, 0, array.Length);
	}

	public Session Load(string sessionUserId)
	{
		string text = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\WebTelegramSession\\\\";
		if (!System.IO.Directory.Exists(text))
		{
			System.IO.Directory.CreateDirectory(text);
			CRM.General.IO.Directory.SetFullControlForEveryOne(text);
		}
		text = text + "TelegSetting-" + settingId + "\\";
		if (!System.IO.Directory.Exists(text))
		{
			System.IO.Directory.CreateDirectory(text);
			CRM.General.IO.Directory.SetFullControlForEveryOne(text);
		}
		string text2 = text + "{0}.dat";
		CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
		string path = string.Format(text2, sessionUserId);
		if (!System.IO.File.Exists(path))
		{
			return null;
		}
		return Session.FromBytes(System.IO.File.ReadAllBytes(path), this, sessionUserId);
	}
}
