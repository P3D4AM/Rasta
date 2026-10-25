using System.Configuration;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.SqlClient;
using CRM.General.Security;

namespace Mobile;

public class DbConnection
{
	private static DbConnection _ConsString;

	private string _String;

	public static string ConString
	{
		get
		{
			if (_ConsString == null)
			{
				_ConsString = new DbConnection
				{
					_String = Connect()
				};
				return _ConsString._String;
			}
			return _ConsString._String;
		}
	}

	private DbConnection()
	{
	}

	public static string Connect()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		SqlConnectionStringBuilder val = new SqlConnectionStringBuilder
		{
			DataSource = CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]),
			InitialCatalog = CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]),
			UserID = CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]),
			Password = CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]),
			MultipleActiveResultSets = true,
			ApplicationName = "EntityFramework"
		};
		return ((DbConnectionStringBuilder)new EntityConnectionStringBuilder
		{
			Provider = "System.Data.SqlClient",
			Metadata = "res://*/Models.Mob.csdl|res://*/Models.Mob.ssdl|res://*/Models.Mob.msl",
			ProviderConnectionString = ((object)val).ToString()
		}).ConnectionString;
	}
}
