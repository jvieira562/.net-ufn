using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.ViewModels;
using Cadastro.ViewModels.Products;

namespace Cadastro.Infrastructure.Web
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientViewModel, Client>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
