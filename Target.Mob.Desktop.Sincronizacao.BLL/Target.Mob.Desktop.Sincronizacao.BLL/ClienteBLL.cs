using System;
using System.Linq;
using Target.Mob.Desktop.Sincronizacao.Common.Enumerators;
using Target.Mob.Desktop.Sincronizacao.Common.Util;
using Target.Mob.Desktop.Sincronizacao.DAL;
using Target.Mob.Desktop.Sincronizacao.Model;

namespace Target.Mob.Desktop.Sincronizacao.BLL;

public static class ClienteBLL
{
	public static bool Exists(string stringConnTargetERP, int CdClien)
	{
		return SelectByCdClien(stringConnTargetERP, CdClien, carregaFilhos: false) != null;
	}

	public static ClienteTO[] SelectExport(DbConnection connection, byte[] RowId)
	{
		ClienteTO[] array = ClienteDAL.SelectExport(connection, RowId);
		if (array != null)
		{
			ClienteTO[] array2 = array;
			foreach (ClienteTO clienteTO in array2)
			{
				clienteTO.oEndCli = EndCliBLL.Select(connection, clienteTO.CdClien);
			}
		}
		return array;
	}

	public static void Insert(DbConnection connection, ClienteTO cliente)
	{
		SeqCliDAL.Update(connection, new SeqCliTO());
		SeqCliTO seqCliTO = SeqCliBLL.Select(connection);
		cliente.CdClien = Convert.ToInt32(seqCliTO.Numero);
		ClienteDAL.Insert(connection, cliente);
		EndCliTO[] oEndCli = cliente.oEndCli;
		foreach (EndCliTO endCliTO in oEndCli)
		{
			endCliTO.CdClien = cliente.CdClien;
			EndCliBLL.Insert(connection, endCliTO);
		}
		TelCliTO[] oTelCli = cliente.oTelCli;
		foreach (TelCliTO telCliTO in oTelCli)
		{
			telCliTO.CdClien = cliente.CdClien;
			TelCliBLL.Insert(connection, telCliTO);
		}
		ContCliTO[] oContCli = cliente.oContCli;
		foreach (ContCliTO contCliTO in oContCli)
		{
			contCliTO.CdClien = cliente.CdClien;
			ContCliBLL.Insert(connection, contCliTO);
		}
		ClientePermCompTO[] oPermComp = cliente.OPermComp;
		foreach (ClientePermCompTO clientePermCompTO in oPermComp)
		{
			clientePermCompTO.CdClien = cliente.CdClien;
			ClientePermCompBLL.Insert(connection, clientePermCompTO);
		}
		if (cliente.CdTexto.HasValue)
		{
			CliLogAltObsTO cliLogAltObsTO = new CliLogAltObsTO();
			cliLogAltObsTO.CdClien = cliente.CdClien;
			cliLogAltObsTO.CdTexto = cliente.CdTexto.Value;
			cliLogAltObsTO.TipoObs = TipoObsCliLog.Geral;
			CliLogAltObsBLL.Insert(connection, cliLogAltObsTO);
		}
		if (cliente.CdTextoAlerta.HasValue)
		{
			CliLogAltObsTO cliLogAltObsTO2 = new CliLogAltObsTO();
			cliLogAltObsTO2.CdClien = cliente.CdClien;
			cliLogAltObsTO2.CdTexto = cliente.CdTextoAlerta.Value;
			cliLogAltObsTO2.TipoObs = TipoObsCliLog.Alerta;
			CliLogAltObsBLL.Insert(connection, cliLogAltObsTO2);
		}
		if (cliente.CdTextoExpe.HasValue)
		{
			CliLogAltObsTO cliLogAltObsTO3 = new CliLogAltObsTO();
			cliLogAltObsTO3.CdClien = cliente.CdClien;
			cliLogAltObsTO3.CdTexto = cliente.CdTextoExpe.Value;
			cliLogAltObsTO3.TipoObs = TipoObsCliLog.Expedicao;
			CliLogAltObsBLL.Insert(connection, cliLogAltObsTO3);
		}
		CliEmpTO[] array = CliEmpBLL.SelectNewCustomer(connection);
		foreach (CliEmpTO cliEmpTO in array)
		{
			cliEmpTO.CdClien = cliente.CdClien;
			CliEmpBLL.Insert(connection, cliEmpTO);
		}
		ClasCliTO[] array2 = ClasCliBLL.SelectNewCustomer(connection);
		foreach (ClasCliTO clasCliTO in array2)
		{
			clasCliTO.CdClien = cliente.CdClien;
			ClasCliBLL.Insert(connection, clasCliTO);
		}
		VendCliTO vendCliTO = new VendCliTO();
		vendCliTO.CdClien = cliente.CdClien;
		vendCliTO.CdVend = cliente.CdVend;
		vendCliTO.Prioritario = true;
		VendCliBLL.Insert(connection, vendCliTO);
		CliLogAltTO cliLogAltTO = new CliLogAltTO();
		cliLogAltTO.CdEmp = 1;
		cliLogAltTO.CdUsuario = "SUPER";
		cliLogAltTO.Data = DateTime.Now;
		cliLogAltTO.TpLog = "INC";
		CliLogAltBLL.Insert(connection, cliLogAltTO);
		IntFabrEnvioTO[] array3 = IntFabrEnvioBLL.SelectNewCustomer(connection);
		if (array3 != null)
		{
			IntFabrEnvioTO[] array4 = array3;
			foreach (IntFabrEnvioTO intFabrEnvioTO in array4)
			{
				intFabrEnvioTO.Codigo = cliente.CdClien.ToString();
				IntFabrEnvioBLL.Insert(connection, intFabrEnvioTO);
			}
		}
		MotCliRemuTO[] array5 = MotCliRemuBLL.SelectNewCustomer(connection);
		if (array5 != null)
		{
			MotCliRemuTO[] array6 = array5;
			foreach (MotCliRemuTO motCliRemuTO in array6)
			{
				motCliRemuTO.CdClien = cliente.CdClien;
				MotCliRemuBLL.Insert(connection, motCliRemuTO);
			}
		}
		seqCliTO.Numero++;
		SeqCliDAL.Update(connection, seqCliTO);
	}

	public static void UpdateLimitado(DbConnection connection, ClienteTO clienteWS, string _StringConnTargetErp)
	{
		ClienteTO clienteTO = SelectByCnpj(_StringConnTargetErp, clienteWS.CgcCpf);
		if ("A".Equals(clienteWS.TipoOperacao.ToUpper()) && clienteTO != null)
		{
			clienteWS.CdClien = clienteTO.CdClien;
			AtualizarCliente(connection, clienteWS, clienteTO);
			return;
		}
		throw new Exception($"Cliente não encontrado para atualização, CNPJ {clienteWS.CgcCpf}");
	}

	public static void UpdateLimitadoProspeccao(DbConnection connection, ClienteTO clienteWS, int codClienteProspeccao, string stringConnTargetErp)
	{
		ClienteTO clienteTO = SelectByCdClien(stringConnTargetErp, codClienteProspeccao, carregaFilhos: true);
		if (clienteTO != null)
		{
			clienteWS.CdClien = clienteTO.CdClien;
			AtualizarCliente(connection, clienteWS, clienteTO);
			return;
		}
		throw new Exception($"Cliente não encontrado para atualização, código prospeccao {codClienteProspeccao}");
	}

	private static void AtualizarCliente(DbConnection connection, ClienteTO clienteWS, ClienteTO clienteERP)
	{
		if (!string.IsNullOrEmpty(clienteWS.Iban) || !string.IsNullOrEmpty(clienteWS.EMail) || (clienteWS.QtdeCheckout.HasValue && clienteWS.QtdeCheckout > 0))
		{
			ClienteDAL.UpdateLimitado(connection, clienteWS);
		}
		EndCliTO[] oEndCli = clienteWS.oEndCli;
		foreach (EndCliTO endCliTO in oEndCli)
		{
			if (endCliTO.TipoOperacao != null && endCliTO.TipoOperacao.ToUpper().Equals("A"))
			{
				EndCliBLL.Update(connection, endCliTO);
				continue;
			}
			endCliTO.CdClien = clienteWS.CdClien;
			EndCliBLL.Insert(connection, endCliTO);
		}
		TelCliTO[] oTelCli = clienteWS.oTelCli;
		foreach (TelCliTO telCliTO in oTelCli)
		{
			if (telCliTO.TipoOperacao != null && telCliTO.TipoOperacao.ToUpper().Equals("A"))
			{
				TelCliBLL.Update(connection, telCliTO);
				continue;
			}
			telCliTO.CdClien = clienteWS.CdClien;
			TelCliBLL.Insert(connection, telCliTO);
		}
		ContCliTO[] oContCli = clienteWS.oContCli;
		foreach (ContCliTO contWS in oContCli)
		{
			bool flag = false;
			contWS.CdClien = clienteWS.CdClien;
			if ("A".Equals(contWS.TipoOperacao.ToUpper()) && clienteERP.oContCli != null && clienteERP.oContCli.Length != 0)
			{
				if (clienteERP.oContCli.Where((ContCliTO lc) => lc.Seq == contWS.Seq).FirstOrDefault() != null)
				{
					flag = true;
				}
				ContCliBLL.Update(connection, contWS);
			}
			if (!flag)
			{
				ContCliBLL.Insert(connection, contWS);
			}
		}
	}

	public static int Count(DbConnection connection, string CgcCpf)
	{
		return ClienteDAL.Count(connection, CgcCpf);
	}

	public static int? getCodigoClienteByCnpj(string CnpjCpfCliente, int ID, string campo, string pais, string _StringConnTargetErp)
	{
		if (CnpjCpfCliente == null || string.Empty.Equals(CnpjCpfCliente.Trim()))
		{
			throw new Exception($"{campo} não importado. Busca de clientes sem CNPJ. Id do Painel: {ID}");
		}
		return (SelectByCnpjEPais(_StringConnTargetErp, CnpjCpfCliente, pais, loadFilhos: false) ?? throw new Exception($"{campo} não importado! Não foi encontrado o cliente com o CNPJ/CPF {CnpjCpfCliente}. ID do painel: {ID}")).CdClien;
	}

	public static void Update(DbConnection connTargetErp, ClienteTO cliente)
	{
		ClienteDAL.Update(connTargetErp, cliente);
		EndCliTO[] oEndCli = cliente.oEndCli;
		foreach (EndCliTO endCliTO in oEndCli)
		{
			endCliTO.CdClien = cliente.CdClien;
			EndCliBLL.Update(connTargetErp, endCliTO);
		}
		TelCliBLL.Delete(connTargetErp, cliente.CdClien);
		TelCliTO[] oTelCli = cliente.oTelCli;
		foreach (TelCliTO telCliTO in oTelCli)
		{
			telCliTO.CdClien = cliente.CdClien;
			TelCliBLL.Insert(connTargetErp, telCliTO);
		}
		ContCliBLL.Delete(connTargetErp, cliente.CdClien);
		ContCliTO[] oContCli = cliente.oContCli;
		foreach (ContCliTO contCliTO in oContCli)
		{
			contCliTO.CdClien = cliente.CdClien;
			ContCliBLL.Insert(connTargetErp, contCliTO);
		}
	}

	public static ClienteTO SelectByCnpj(string StringConnection, string Cnpj)
	{
		return ClienteDAL.SelectByCnpj(StringConnection, Cnpj);
	}

	public static ClienteTO SelectByCdClien(string stringConnTargetERP, int CdClien, bool carregaFilhos)
	{
		return ClienteDAL.SelectByCdClien(stringConnTargetERP, CdClien, carregaFilhos);
	}

	public static ClienteTO SelectByCnpjEPais(string _StringConnTargetErp, string cnpjCpf, string pais, bool loadFilhos)
	{
		return ClienteDAL.SelectByCnpjEPais(_StringConnTargetErp, cnpjCpf, pais, loadFilhos);
	}

	public static bool Exists(string StringConnection, string Cnpj)
	{
		return ClienteDAL.Exists(StringConnection, Cnpj);
	}
}
