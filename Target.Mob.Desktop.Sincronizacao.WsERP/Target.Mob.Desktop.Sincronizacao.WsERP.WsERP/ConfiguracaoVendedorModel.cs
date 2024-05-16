using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class ConfiguracaoVendedorModel : ConfiguracaoVendedorWsModel
{
	private bool? exibirImpostosField;

	private bool? enviarEmailExibirDescontoField;

	private bool? gPSExibeKmTotalField;

	private bool? gPSExibeTempoTotalField;

	private bool? gPSExibeKmPlanejadoInicialField;

	private bool? gPSExibeKmPlanejadoRoteiroField;

	private bool? gPSExibeKmPlanejadoFinalField;

	private bool? ativoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public bool? ExibirImpostos
	{
		get
		{
			return exibirImpostosField;
		}
		set
		{
			exibirImpostosField = value;
			RaisePropertyChanged("ExibirImpostos");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public bool? EnviarEmailExibirDesconto
	{
		get
		{
			return enviarEmailExibirDescontoField;
		}
		set
		{
			enviarEmailExibirDescontoField = value;
			RaisePropertyChanged("EnviarEmailExibirDesconto");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public bool? GPSExibeKmTotal
	{
		get
		{
			return gPSExibeKmTotalField;
		}
		set
		{
			gPSExibeKmTotalField = value;
			RaisePropertyChanged("GPSExibeKmTotal");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public bool? GPSExibeTempoTotal
	{
		get
		{
			return gPSExibeTempoTotalField;
		}
		set
		{
			gPSExibeTempoTotalField = value;
			RaisePropertyChanged("GPSExibeTempoTotal");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public bool? GPSExibeKmPlanejadoInicial
	{
		get
		{
			return gPSExibeKmPlanejadoInicialField;
		}
		set
		{
			gPSExibeKmPlanejadoInicialField = value;
			RaisePropertyChanged("GPSExibeKmPlanejadoInicial");
		}
	}

	[XmlElement(IsNullable = true, Order = 5)]
	public bool? GPSExibeKmPlanejadoRoteiro
	{
		get
		{
			return gPSExibeKmPlanejadoRoteiroField;
		}
		set
		{
			gPSExibeKmPlanejadoRoteiroField = value;
			RaisePropertyChanged("GPSExibeKmPlanejadoRoteiro");
		}
	}

	[XmlElement(IsNullable = true, Order = 6)]
	public bool? GPSExibeKmPlanejadoFinal
	{
		get
		{
			return gPSExibeKmPlanejadoFinalField;
		}
		set
		{
			gPSExibeKmPlanejadoFinalField = value;
			RaisePropertyChanged("GPSExibeKmPlanejadoFinal");
		}
	}

	[XmlElement(IsNullable = true, Order = 7)]
	public bool? Ativo
	{
		get
		{
			return ativoField;
		}
		set
		{
			ativoField = value;
			RaisePropertyChanged("Ativo");
		}
	}
}
