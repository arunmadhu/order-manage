using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Model;

namespace webapi.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<order.queryservices.OrderAddress, AddressInfo>()
               .ForMember(map => map.AddressId, des => des.MapFrom(src => src.Address.Id))
               .ForMember(map => map.AddressLine1, des => des.MapFrom(src => src.Address.AddressLine1))
               .ForMember(map => map.AddressLine2, des => des.MapFrom(src => src.Address.AddressLine2))
               .ForMember(map => map.Pincode, des => des.MapFrom(src => src.Address.Pincode))
               .ForMember(map => map.State, des => des.MapFrom(src => src.Address.State));
            
            CreateMap<order.queryservices.Order, OrderInfo>()
                .ForMember(map => map.OrderId , des => des.MapFrom(src => src.Id))
                .ForMember(map => map.CustomerName, des => des.MapFrom(src => src.CustomerName))
                .ForMember(map => map.OrderNumber, des => des.MapFrom(src => src.OrderNumber))
                .ForMember(map => map.TotalPrice, des => des.MapFrom(src => src.TotalPrice))
                .ForMember(map => map.Addresses, des => des.MapFrom(src => src.OrderAddress));

            CreateMap<order.queryservices.Address, AddressInfo>()
               .ForMember(map => map.AddressId, des => des.MapFrom(src => src.Id))
               .ForMember(map => map.AddressLine1, des => des.MapFrom(src => src.AddressLine1))
               .ForMember(map => map.AddressLine2, des => des.MapFrom(src => src.AddressLine2))
               .ForMember(map => map.Pincode, des => des.MapFrom(src => src.Pincode))
               .ForMember(map => map.State, des => des.MapFrom(src => src.State));

            CreateMap<OrderInfo,order.commandservices.Order>()
                .ForMember(map => map.CustomerName, des => des.MapFrom(src => src.CustomerName))
                .ForMember(map => map.OrderNumber, des => des.MapFrom(src => src.OrderNumber))
                .ForMember(map => map.TotalPrice, des => des.MapFrom(src => src.TotalPrice));

            CreateMap<AddressInfo,order.commandservices.Address>()
              .ForMember(map => map.AddressLine1, des => des.MapFrom(src => src.AddressLine1))
              .ForMember(map => map.AddressLine2, des => des.MapFrom(src => src.AddressLine2))
              .ForMember(map => map.Pincode, des => des.MapFrom(src => src.Pincode))
              .ForMember(map => map.State, des => des.MapFrom(src => src.State));
        }
    }
}
