using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Target.Mob.Desktop.Sincronizacao.WsERP.WsERP;

[Serializable]
[XmlInclude(typeof(PedVdaTextoGravacaoModel))]
[GeneratedCode("System.Xml", "4.8.9037.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "Target.WsERP")]
public class PedVdaTextoGravacaoWsModel : INotifyPropertyChanged
{
	private int? idPedVdaTextoGravacaoField;

	private int idPedVdaField;

	private short nuLinhaField;

	private string textoField;

	[XmlElement(IsNullable = true, Order = 0)]
	public int? idPedVdaTextoGravacao
	{
		get
		{
			return idPedVdaTextoGravacaoField;
		}
		set
		{
			idPedVdaTextoGravacaoField = value;
			RaisePropertyChanged("idPedVdaTextoGravacao");
		}
	}

	[XmlElement(Order = 1)]
	public int idPedVda
	{
		get
		{
			return idPedVdaField;
		}
		set
		{
			idPedVdaField = value;
			RaisePropertyChanged("idPedVda");
		}
	}

	[XmlElement(Order = 2)]
	public short nuLinha
	{
		get
		{
			return nuLinhaField;
		}
		set
		{
			nuLinhaField = value;
			RaisePropertyChanged("nuLinha");
		}
	}

	[XmlElement(Order = 3)]
	public string texto
	{
		get
		{
			return textoField;
		}
		set
		{
			textoField = value;
			RaisePropertyChanged("texto");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
