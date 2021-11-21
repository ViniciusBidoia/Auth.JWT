using Auth.JWT.API.ViewModel;
using Auth.JWT.Domain.Models;
using AutoMapper;

namespace Auth.JWT.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            /*
             *  Example
             *  CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
             */

            //Usuario
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();            
        }
    }
}
