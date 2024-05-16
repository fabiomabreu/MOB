using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Extensions.ChildKernel;
using Target.Mob.Desktop.Api.Interface;

namespace Target.Mob.Desktop.Api.Resolver;

public class NinjectResolver : IDependencyResolver, IDependencyScope, IDisposable
{
	private IKernel kernel;

	private Type _typeConfiguration;

	public NinjectResolver(Type typeConfiguration)
		: this(new StandardKernel(), scope: false, typeConfiguration)
	{
	}

	public NinjectResolver(IKernel ninjectKernel, bool scope = false, Type typeConfiguration = null)
	{
		if (typeConfiguration != null)
		{
			_typeConfiguration = typeConfiguration;
		}
		kernel = ninjectKernel;
		if (!scope)
		{
			AddBindings(kernel);
		}
	}

	public IDependencyScope BeginScope()
	{
		return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), scope: true);
	}

	public object GetService(Type serviceType)
	{
		return kernel.TryGet(serviceType);
	}

	public IEnumerable<object> GetServices(Type serviceType)
	{
		return kernel.GetAll(serviceType);
	}

	public void Dispose()
	{
	}

	private void AddBindings(IKernel kernel)
	{
		kernel.Bind<IConfiguration>().To(_typeConfiguration).InSingletonScope();
	}

	private IKernel AddRequestBindings(IKernel kernel)
	{
		return kernel;
	}
}
