using Pet.Business.Core.Notifications;
using Pet.Business.Models.Fornecedores;
using Pet.Business.Models.Fornecedores.Services;
using Pet.Business.Models.Produtos;
using Pet.Business.Models.Produtos.Services;
using Pet.Infra.Data.Context;
using Pet.Infra.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Pet.AppMvc.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDIContainer()
        {
            var container = new Container(); //cria o container
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle(); //escopo de aplicação WEB

            InitializeContainer(container); //metodo onde vamos ensinar a criar os objetos..

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());//registrar as controllers, 
            container.Verify(); //vai validar se elas estão configuradas para trabalhar com simpleinjector

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container)); //classe do MVC, estamos dizendo ao MVC quem vai trabalhar resolvendo as injeções de dependencias..
        }

        private static void InitializeContainer(Container container)
        {
            /*  
             *  Lifestyle.Singleton -> Uma unica Instância por aplicação
             *  Lifestyle.Transient -> Cria uma nova instancia para cada injeção
             *  Lifestyle.Scoped    -> Uma unica instância por Request **Só funciona para app WEB
             */
            container.Register<MeuDbContext>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped); // <TIPO QUE QUERO RESOLVER>, INSTANCIA_QUE_SERA_CRIADA 
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);
            container.Register<INotificador, Notificador>(Lifestyle.Scoped);

            //AutoMapper pode ser registrado como singleton, pois ele sabe se virar, e vai funcionar para a aplicação inteira..
            //AutoMapperConfig.GetMapperConfiguration() -> nós mesmos criamos a instancia do AutoMapper
            //CreateMapper(container.GetInstance) -> e passamos qual a instancia do container de injeção de dependencia..
            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));

        }
    }
}