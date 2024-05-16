using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Reflection;

namespace Target.Venda.Model.Base;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class DecimalPrecision : Attribute
{
	public byte precision { get; set; }

	public byte scale { get; set; }

	public DecimalPrecision(byte inPrecision, byte inScale)
	{
		precision = inPrecision;
		scale = inScale;
	}

	public static void ConfigureModelBuilder(DbModelBuilder modelBuilder)
	{
		(from x in modelBuilder.Properties()
			where x.GetCustomAttributes(inherit: false).OfType<DecimalPrecision>().Any()
			select x).Configure(delegate(ConventionPrimitivePropertyConfiguration c)
		{
			c.HasPrecision(c.ClrPropertyInfo.GetCustomAttributes(inherit: false).OfType<DecimalPrecision>().First()
				.precision, c.ClrPropertyInfo.GetCustomAttributes(inherit: false).OfType<DecimalPrecision>().First()
					.scale);
				});
			}
		}
