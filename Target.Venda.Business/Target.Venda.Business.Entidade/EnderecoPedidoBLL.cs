using System;
using System.Collections.Generic;
using Target.Venda.Business.Base;
using Target.Venda.Business.Helpers;
using Target.Venda.DataAccess.Base;
using Target.Venda.DataAccess.Entidade;
using Target.Venda.Helpers;
using Target.Venda.Helpers.Geral;
using Target.Venda.Model.Entidade;

namespace Target.Venda.Business.Entidade;

public class EnderecoPedidoBLL : EntidadeBaseBLL<EnderecoPedidoMO>
{
	protected override EntidadeBaseDAL<EnderecoPedidoMO> GetInstanceDAL()
	{
		return new EnderecoPedidoDAL();
	}

	public void CarregarEnderecoPedido(PedidoVendaMO pedidoVenda)
	{
		PedidoEletronicoMO pEDIDO_ELETRONICO = pedidoVenda.PEDIDO_ELETRONICO;
		List<EnderecoPedidoMO> list = new List<EnderecoPedidoMO>();
		foreach (EnderecoPedidoEletronicoMO eNDERECO in pEDIDO_ELETRONICO.ENDERECOS)
		{
			EnderecoPedidoMO item = ConvertHelper.ToObject<EnderecoPedidoMO>(eNDERECO, Array.Empty<string>());
			list.Add(item);
		}
		if (pedidoVenda.ENTREGA_OUTRO_CLIENTE.ToBool() && list.Count == 0)
		{
			list = new List<EnderecoPedidoMO>();
			int cODIGO_CLIENTE = pedidoVenda.CODIGO_CLIENTE_OUTRO_CLIENTE.ToInt();
			ClienteBLL clienteBLL = new ClienteBLL();
			ClienteMO clienteMO = clienteBLL.ObterUnicoPeloExemplo(new ClienteMO
			{
				CODIGO_CLIENTE = cODIGO_CLIENTE
			}, "ENDERECOS");
			EnderecoClienteMO obj_para_mapear = clienteMO.ENDERECOS.Find((EnderecoClienteMO x) => x.TIPO_ENDERECO == "EN");
			EnderecoPedidoMO enderecoPedidoMO = ConvertHelper.ToObject<EnderecoPedidoMO>(obj_para_mapear, Array.Empty<string>());
			enderecoPedidoMO.SEQ = 1;
			list.Add(enderecoPedidoMO);
		}
		if (list.Count == 0)
		{
			EnderecoClienteMO obj_para_mapear2 = pedidoVenda.CLIENTE.ENDERECOS.Find((EnderecoClienteMO x) => x.TIPO_ENDERECO == "EN");
			EnderecoPedidoMO enderecoPedidoMO2 = ConvertHelper.ToObject<EnderecoPedidoMO>(obj_para_mapear2, Array.Empty<string>());
			enderecoPedidoMO2.SEQ = 1;
			list.Add(enderecoPedidoMO2);
		}
		list.ForEach(delegate(EnderecoPedidoMO i)
		{
			i.DISTRITO = (string.IsNullOrEmpty(i.DISTRITO) ? string.Empty : i.DISTRITO);
			i.LOCALIZACAO = (string.IsNullOrEmpty(i.LOCALIZACAO) ? string.Empty : i.LOCALIZACAO);
			i.ENDERECO = (string.IsNullOrEmpty(i.ENDERECO) ? i.ENDERECO : i.ENDERECO.ToUpper());
			i.BAIRRO = (string.IsNullOrEmpty(i.BAIRRO) ? i.BAIRRO : i.BAIRRO.ToUpper());
			i.LOGRADOURO = (string.IsNullOrEmpty(i.LOGRADOURO) ? i.LOGRADOURO : i.LOGRADOURO.ToUpper());
		});
		pedidoVenda.ENDERECOS = list;
	}

	public void ValidarEnderecoPedido(PedidoVendaMO pedidoVenda)
	{
		MyException ex = new MyException();
		if (pedidoVenda.TIPO_ENTREGA == "EN" || pedidoVenda.TIPO_ENTREGA == "TR")
		{
			EnderecoPedidoMO enderecoPedidoMO = pedidoVenda.ENDERECOS.Find((EnderecoPedidoMO x) => x.TIPO_ENDERECO == "EN");
			ex.VerificarObjetoNull(enderecoPedidoMO, "Endereço de Entrega não informado");
			if (string.IsNullOrEmpty(enderecoPedidoMO.ENDERECO))
			{
				ex.AddErro("Endereço de Entrega não informado");
			}
			if (enderecoPedidoMO.CEP == 0)
			{
				ex.AddErro("CEP do Endereço de Entrega não informado.");
			}
			if (string.IsNullOrEmpty(enderecoPedidoMO.BAIRRO))
			{
				ex.AddErro("Bairro de Entrega não informado.");
			}
			if (string.IsNullOrEmpty(enderecoPedidoMO.MUNICIPIO))
			{
				ex.AddErro("Municipio de Entrega não informado.");
			}
		}
		ex.ThrowException();
	}
}
