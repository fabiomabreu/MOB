using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Target.Mob.Common.IO;

public static class PermissaoDiretorio
{
	public static bool PermissaoEscrita(string diretorio)
	{
		try
		{
			FileSystemSecurity fileSystemSecurity = ((!File.Exists(diretorio)) ? ((FileSystemSecurity)Directory.GetAccessControl(diretorio)) : ((FileSystemSecurity)File.GetAccessControl(diretorio)));
			AuthorizationRuleCollection accessRules = fileSystemSecurity.GetAccessRules(includeExplicit: true, includeInherited: true, typeof(NTAccount));
			WindowsPrincipal windowsPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
			bool result = false;
			foreach (FileSystemAccessRule item in accessRules)
			{
				if ((item.FileSystemRights & FileSystemRights.Write) == 0)
				{
					continue;
				}
				if (item.IdentityReference.Value.StartsWith("S-1-"))
				{
					SecurityIdentifier sid = new SecurityIdentifier(item.IdentityReference.Value);
					if (!windowsPrincipal.IsInRole(sid))
					{
						continue;
					}
				}
				else if (!windowsPrincipal.IsInRole(item.IdentityReference.Value))
				{
					continue;
				}
				if (item.AccessControlType == AccessControlType.Deny)
				{
					return false;
				}
				if (item.AccessControlType == AccessControlType.Allow)
				{
					result = true;
				}
			}
			return result;
		}
		catch
		{
			return false;
		}
	}
}
