using ControleFinanceiro.Dominio.Repositorios;
using ControleFinanceiro.Infra.Repositorios;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ControleFinanceiro
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMetaRepositorio, MetaRepositorio>();
            container.RegisterType<ILancamentoRepositorio, LancamentoRepositorio>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}