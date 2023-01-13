using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObject;
using GeekShopping.CartAPI.Model;

namespace GeekShopping.CartAPI.Config
{
	public static class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config=>
			{
				config.CreateMap<ProductVO, Product>().ReverseMap();
				config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
				config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
				config.CreateMap<CartVO, Cart>().ReverseMap();				
			});
			return mappingConfig;
		}
	}
}
