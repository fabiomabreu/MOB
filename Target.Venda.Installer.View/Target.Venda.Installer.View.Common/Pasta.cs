#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace Target.Venda.Installer.View.Common;

public class Pasta
{
	public ManagementBaseObject getPastaCompartilhada(string NomePasta, out string NomeCompartilhamnto)
	{
		NomeCompartilhamnto = string.Empty;
		ManagementBaseObject result = null;
		if (TryGetLocalFromUncDirectory(NomePasta, out var _, out NomeCompartilhamnto))
		{
			result = AddPermissions(NomeCompartilhamnto, Environment.UserDomainName, Environment.UserName);
			RemoveShare(NomeCompartilhamnto);
		}
		return result;
	}

	public void CriarPastaCompartilhada(string PastaDestino, string NomeCompartilhamento, ManagementBaseObject securityDescriptor)
	{
		if (Directory.Exists(PastaDestino))
		{
			if (string.IsNullOrEmpty(NomeCompartilhamento))
			{
				NomeCompartilhamento = "TARGET_VENDA";
			}
			CreateSharedFolder(securityDescriptor, NomeCompartilhamento, PastaDestino);
		}
	}

	private uint RemoveShare(string shareName)
	{
		try
		{
			using ManagementObject managementObject = new ManagementObject("root\\cimv2", "Win32_Share.Name='" + shareName + "'", null);
			ManagementBaseObject managementBaseObject = managementObject.InvokeMethod("delete", null, null);
			return (uint)managementBaseObject.Properties["ReturnValue"].Value;
		}
		catch (Exception)
		{
			return 1u;
		}
	}

	private ManagementBaseObject AddPermissions(string NomeCompartilhamnto, string domain, string userName)
	{
		try
		{
			ManagementObject sharedFolderObject = GetSharedFolderObject(NomeCompartilhamnto);
			if (sharedFolderObject == null)
			{
				Trace.WriteLine("The shared folder with given name does not exist");
				return null;
			}
			ManagementBaseObject managementBaseObject = sharedFolderObject.InvokeMethod("GetSecurityDescriptor", null, null);
			if (managementBaseObject == null)
			{
				Trace.WriteLine(string.Format(CultureInfo.InvariantCulture, "Error extracting security descriptor of the shared path."));
				return null;
			}
			if (Convert.ToInt32(managementBaseObject.Properties["ReturnValue"].Value) != 0)
			{
				Trace.WriteLine("Error extracting security descriptor of the shared path {0}. Error Code{1}.");
				return null;
			}
			ManagementBaseObject managementBaseObject2 = managementBaseObject.Properties["Descriptor"].Value as ManagementBaseObject;
			int num = 0;
			ManagementBaseObject[] array = managementBaseObject2.Properties["DACL"].Value as ManagementBaseObject[];
			if (array == null)
			{
				array = new ManagementBaseObject[1];
			}
			else
			{
				num = array.Length;
				Array.Resize(ref array, array.Length + 1);
			}
			ManagementObject managementObject = null;
			ManagementObject userAccountObject = GetUserAccountObject(domain, userName);
			managementObject = new ManagementObject(string.Format("Win32_SID.SID='{0}'", (string)userAccountObject.Properties["SID"].Value));
			managementObject.Get();
			ManagementObject trustee = CreateTrustee(domain, userName, managementObject);
			ManagementObject managementObject2 = CreateAccessControlEntry(trustee, deny: false);
			array[num] = managementObject2;
			managementBaseObject2.Properties["DACL"].Value = array;
			ManagementBaseObject methodParameters = sharedFolderObject.GetMethodParameters("SetSecurityDescriptor");
			methodParameters["Descriptor"] = managementBaseObject2;
			sharedFolderObject.InvokeMethod("SetSecurityDescriptor", methodParameters, null);
			return managementBaseObject2;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private bool TryGetLocalFromUncDirectory(string local, out string unc, out string sharedName)
	{
		sharedName = string.Empty;
		unc = string.Empty;
		if (string.IsNullOrEmpty(local))
		{
			throw new ArgumentNullException("local");
		}
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Name FROM Win32_share WHERE path ='" + local.Replace("\\", "\\\\") + "'");
		ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
		using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator())
		{
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
				sharedName = managementObject["Name"] as string;
				unc = "\\\\" + SystemInformation.ComputerName + "\\" + sharedName;
				return true;
			}
		}
		return false;
	}

	private static ManagementObject GetSharedFolderObject(string sharedFolderName)
	{
		ManagementObject result = null;
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_LogicalShareSecuritySetting where Name = '" + sharedFolderName + "'");
		ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
		if (managementObjectCollection.Count > 0)
		{
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectCollection.GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
				result = managementObject;
			}
		}
		return result;
	}

	private static ManagementObject GetUserAccountObject(string domain, string alias)
	{
		string queryString = $"select * from Win32_Account where Name = '{alias}' and Domain='{domain}'";
		ManagementObject result = null;
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString);
		ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
		if (managementObjectCollection.Count > 0)
		{
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectCollection.GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
				result = managementObject;
			}
		}
		return result;
	}

	private static ManagementObject CreateTrustee(string domain, string userName, ManagementObject securityIdentifierOfUser)
	{
		ManagementObject managementObject = new ManagementClass("Win32_Trustee").CreateInstance();
		managementObject.Properties["Domain"].Value = domain;
		managementObject.Properties["Name"].Value = userName;
		managementObject.Properties["SID"].Value = securityIdentifierOfUser.Properties["BinaryRepresentation"].Value;
		managementObject.Properties["SidLength"].Value = securityIdentifierOfUser.Properties["SidLength"].Value;
		managementObject.Properties["SIDString"].Value = securityIdentifierOfUser.Properties["SID"].Value;
		return managementObject;
	}

	private static ManagementObject CreateAccessControlEntry(ManagementObject trustee, bool deny)
	{
		ManagementObject managementObject = new ManagementClass("Win32_ACE").CreateInstance();
		managementObject.Properties["AccessMask"].Value = 2032127u;
		managementObject.Properties["AceFlags"].Value = 0u;
		managementObject.Properties["AceType"].Value = (deny ? 1u : 0u);
		managementObject.Properties["Trustee"].Value = trustee;
		return managementObject;
	}

	private void CreateSharedFolder(ManagementBaseObject securityDescriptor, string sharedFolderName, string destPath)
	{
		ManagementClass managementClass = new ManagementClass("Win32_Share");
		ManagementBaseObject methodParameters = managementClass.GetMethodParameters("Create");
		methodParameters["Description"] = "My Files Share";
		methodParameters["Name"] = sharedFolderName;
		methodParameters["Path"] = destPath;
		methodParameters["Type"] = 0;
		if (securityDescriptor != null)
		{
			methodParameters["Access"] = securityDescriptor;
		}
		ManagementBaseObject managementBaseObject = managementClass.InvokeMethod("Create", methodParameters, null);
		if ((uint)managementBaseObject.Properties["ReturnValue"].Value != 0)
		{
			throw new Exception("Unable to share directory.");
		}
	}
}
