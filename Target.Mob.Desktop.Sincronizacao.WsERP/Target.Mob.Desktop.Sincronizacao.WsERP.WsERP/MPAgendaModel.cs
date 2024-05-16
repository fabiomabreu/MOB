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
public class MPAgendaModel : MPAgendaWsModel
{
	private float? latitudeField;

	private float? longitudeField;

	private float? latitudeVendedorField;

	private float? longitudeVendedorField;

	private int? idVendedorField;

	[XmlElement(IsNullable = true, Order = 0)]
	public float? Latitude
	{
		get
		{
			return latitudeField;
		}
		set
		{
			latitudeField = value;
			RaisePropertyChanged("Latitude");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public float? Longitude
	{
		get
		{
			return longitudeField;
		}
		set
		{
			longitudeField = value;
			RaisePropertyChanged("Longitude");
		}
	}

	[XmlElement(IsNullable = true, Order = 2)]
	public float? LatitudeVendedor
	{
		get
		{
			return latitudeVendedorField;
		}
		set
		{
			latitudeVendedorField = value;
			RaisePropertyChanged("LatitudeVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public float? LongitudeVendedor
	{
		get
		{
			return longitudeVendedorField;
		}
		set
		{
			longitudeVendedorField = value;
			RaisePropertyChanged("LongitudeVendedor");
		}
	}

	[XmlElement(IsNullable = true, Order = 4)]
	public int? IdVendedor
	{
		get
		{
			return idVendedorField;
		}
		set
		{
			idVendedorField = value;
			RaisePropertyChanged("IdVendedor");
		}
	}
}
