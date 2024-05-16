using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(CoordenadaResidenciaModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class CoordenadaResidenciaWsModel : INotifyPropertyChanged
{
	private int? idCoordenadaResidenciaField;

	private int? idUsuarioField;

	private string tipoUsuarioField;

	private double? latitudeField;

	private double? longitudeField;

	private string usuarioLogadoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? IdCoordenadaResidencia
	{
		get
		{
			return idCoordenadaResidenciaField;
		}
		set
		{
			idCoordenadaResidenciaField = value;
			RaisePropertyChanged("IdCoordenadaResidencia");
		}
	}

	[XmlElement(IsNullable = true, Order = 1)]
	public int? IdUsuario
	{
		get
		{
			return idUsuarioField;
		}
		set
		{
			idUsuarioField = value;
			RaisePropertyChanged("IdUsuario");
		}
	}

	[XmlElement(Order = 2)]
	public string TipoUsuario
	{
		get
		{
			return tipoUsuarioField;
		}
		set
		{
			tipoUsuarioField = value;
			RaisePropertyChanged("TipoUsuario");
		}
	}

	[XmlElement(IsNullable = true, Order = 3)]
	public double? Latitude
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

	[XmlElement(IsNullable = true, Order = 4)]
	public double? Longitude
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

	[XmlElement(Order = 5)]
	public string UsuarioLogado
	{
		get
		{
			return usuarioLogadoField;
		}
		set
		{
			usuarioLogadoField = value;
			RaisePropertyChanged("UsuarioLogado");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
