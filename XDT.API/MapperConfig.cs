using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XDT.API.Config;
using XDT.Domain.Model;
using XDT.Infrastructure;
using XDT.Model.DTO;

namespace XDT.API
{
    /// <summary>
    /// automapper的配置
    /// </summary>
    public class MapperConfig
    {
        public static void MapperDTO()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserDTO, User>().ForMember(uMember => uMember.Password, mceUto =>
                        mceUto.ResolveUsing<PassWordResolver, string>(src => src.Password));
                cfg.CreateMap<User, UserDTO>()
                      .ForMember(udoMember => udoMember.Password, mceu => mceu.ResolveUsing<InversedPassWordResolver, string>(fm => fm.Password));
                cfg.CreateMap<BoxItem, BoxItemDTO>()
                .ForMember(odto => odto.UserId,
                mceo => mceo.ResolveUsing(o => o.Box.User.ID))
                .ForMember(odto => odto.BoxId,
                mceo => mceo.ResolveUsing(o => o.Box.ID))
                 .ForMember(odto => odto.CurrentPrice,
                mceo => mceo.ResolveUsing(o => o.WareItem.CurrentPrice))
                .ForMember(odto => odto.Description,
                mceo => mceo.ResolveUsing(o => o.WareItem.Description))
                .ForMember(odto => odto.FirstListenTime,
                mceo => mceo.ResolveUsing(o => o.WareItem.FirstListenTime))
                .ForMember(odto => odto.ItemImage,
                mceo => mceo.ResolveUsing(o => o.WareItem.ItemImage))
                .ForMember(odto => odto.ItemName,
                mceo => mceo.ResolveUsing(o => o.WareItem.ItemName))
                .ForMember(odto => odto.ItemSource,
                mceo => mceo.ResolveUsing(o => o.WareItem.ItemSource))
                .ForMember(odto => odto.LastListenTime,
                mceo => mceo.ResolveUsing(o => o.WareItem.LastListenTime))
                .ForMember(odto => odto.ListenUrl,
                mceo => mceo.ResolveUsing(o => o.WareItem.ListenUrl))
                .ForMember(odto => odto.WareItemId,
                mceo => mceo.ResolveUsing(o => o.WareItem.ID))
                .ForMember(odto => odto.Status,
                mceo => mceo.ResolveUsing(o => o.WareItem.Status))
                 .ForMember(odto => odto.Trend,
                mceo => mceo.ResolveUsing(o => o.WareItem.Trend));
                cfg.CreateMap<BoxItem, BoxItemDTO>()
                .ForMember(odto => odto.UserId,
                mceo => mceo.ResolveUsing(o => o.Box.User.ID))
                .ForMember(odto => odto.BoxId,
                mceo => mceo.ResolveUsing(o => o.Box.ID))
                 .ForMember(odto => odto.CurrentPrice,
                mceo => mceo.ResolveUsing(o => o.WareItem.CurrentPrice))
                .ForMember(odto => odto.Description,
                mceo => mceo.ResolveUsing(o => o.WareItem.Description))
                .ForMember(odto => odto.FirstListenTime,
                mceo => mceo.ResolveUsing(o => o.WareItem.FirstListenTime))
                .ForMember(odto => odto.ItemImage,
                mceo => mceo.ResolveUsing(o => o.WareItem.ItemImage))
                .ForMember(odto => odto.ItemName,
                mceo => mceo.ResolveUsing(o => o.WareItem.ItemName))
                .ForMember(odto => odto.ItemSource,
                mceo => mceo.ResolveUsing(o => o.WareItem.ItemSource))
                .ForMember(odto => odto.LastListenTime,
                mceo => mceo.ResolveUsing(o => o.WareItem.LastListenTime))
                .ForMember(odto => odto.ListenUrl,
                mceo => mceo.ResolveUsing(o => o.WareItem.ListenUrl))
                .ForMember(odto => odto.WareItemId,
                mceo => mceo.ResolveUsing(o => o.WareItem.ID))
                .ForMember(odto => odto.Status,
                mceo => mceo.ResolveUsing(o => o.WareItem.Status))
                 .ForMember(odto => odto.Trend,
                mceo => mceo.ResolveUsing(o => o.WareItem.Trend));
                cfg.CreateMap<WareItemDTO, WareItem>()
                .ForMember(odto => odto.Operator,
                mceo => mceo.ResolveUsing(o => Mapper.Map<User>(o.Operator)));
                cfg.CreateMap<WareItem, WareItemDTO>()
                .ForMember(odto => odto.BoxItemDto,
                mceo => mceo.ResolveUsing(o => Mapper.Map<BoxItemDTO>(o.BoxItem)))
                .ForMember(odto => odto.Operator,
                mceo => mceo.ResolveUsing(o => Mapper.Map<UserDTO>(o.Operator)));
                cfg.CreateMap<BoxItemDTO, BoxItem>();
                cfg.CreateMap<BoxDTO, Box>();
                cfg.CreateMap<Box, BoxDTO>();
                cfg.CreateMap<PriceItem, PriceItemDTO>()
                .ForMember(odto => odto.WareItemId,
                mceo => mceo.ResolveUsing(o =>
                {
                    return o.WareItem?.ID;
                }))
                .ForMember(odto => odto.UpdateDay,
                mceo => mceo.ResolveUsing(o => o.UpdateTime.ToString("MM-dd")));
                cfg.CreateMap<PriceItemDTO, PriceItem>();
                cfg.CreateMap<WareItemDiscussDTO, WareItemDiscuss>();
                cfg.CreateMap<WareItemDiscuss, WareItemDiscussDTO>()
                .ForMember(odto => odto.WareItemId,
                mceo => mceo.ResolveUsing(o => o.WareItem.ID))
                 .ForMember(odto => odto.UserId,
                mceo => mceo.ResolveUsing(o => o.User.ID));
                cfg.CreateMap<NoticeMessageDTO,NoticeMessage>().ForMember(odto => odto.User,mceo => mceo.ResolveUsing(o =>
                {
                    if (o.UserId.HasValue&&o.UserId.Value>0)
                    {
                        var user = new User() { ID = o.UserId.Value };
                        return user;
                    }
                    return null;
                }));
                cfg.CreateMap<NoticeMessage, NoticeMessageDTO>()
                .ForMember(odto => odto.UserId,
                mceo => mceo.ResolveUsing(o =>
                {
                    return o.User?.ID;
                }));
                cfg.CreateMap<UserAdviceDTO
               , UserAdvice>().ForMember(odto => odto.User,
               mceo => mceo.ResolveUsing(o =>
               {
                   if (o.UserId.HasValue)
                   {
                       var user = new User() { ID =  o.UserId.Value };
                       return user;
                   }
                   return null;
               }));
                cfg.CreateMap<UserAdvice, UserAdviceDTO>()
                .ForMember(odto => odto.UserId,
                mceo => mceo.ResolveUsing(o =>
                {
                    return o.User?.ID;
                }));
            });
          
        }
    }
}
