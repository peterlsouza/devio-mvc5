using AutoMapper;
using Pet.AppMvc.ViewModels;
using Pet.Business.Models.Fornecedores;
using Pet.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Pet.AppMvc.App_Start
{
    public class AutoMapperConfig
    {
        //ensinar o automapper encontrar o perfil e adiciona-los
        public static MapperConfiguration GetMapperConfiguration()
        {
            //na inicialização.. vai pegar todos os assemblys e obter o tipo deles.. e após pegar os que são tipo Profile, 
            //coleção de objetos que herdam de Profile..
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            //com base na lista de profiles, ele vai adicionar o profile.. e criar a instancia..
            return new MapperConfiguration(config =>
            {
                foreach (var profile in profiles)
                {
                    config.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    //criar o perfil com as classes que serão mapeadas
    public class AutoMapperProfile : Profile
    {
        //ensinando o autommaper como mapear.. 
        public AutoMapperProfile()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            
        }

        //Usado para mapear de uma entidade para um DTO/viewmodel e vice-versa 
        //para nao ter que criar a instancia e fazer trabalho manual..
        //mapeia um tipo e o nome, ambos devem ter mesmo nome.. se houver campos diferentes devemos configurar
    }
}

