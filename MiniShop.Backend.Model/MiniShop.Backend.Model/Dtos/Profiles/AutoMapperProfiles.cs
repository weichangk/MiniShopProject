using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace MiniShop.Backend.Model.Dto.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            #region ids
            CreateMap<IdentityUser, UserDto>();
            CreateMap<UserCreateDto, IdentityUser>();
            CreateMap<IdentityUser, UserCreateDto>();
            CreateMap<UserUpdateDto, IdentityUser>();
            CreateMap<IdentityUser, UserUpdateDto>();
            CreateMap<UserDto, UserUpdateDto>();
            #endregion

            #region shop
            CreateMap<Shop, ShopDto>();
            CreateMap<ShopCreateDto, Shop>();
            CreateMap<ShopUpdateDto, Shop>();
            CreateMap<Shop, ShopCreateDto>();
            CreateMap<Shop, ShopUpdateDto>();
            CreateMap<ShopDto, ShopCreateDto>();
            CreateMap<ShopDto, ShopUpdateDto>();
            #endregion

            #region store
            CreateMap<Store, StoreDto>();
            CreateMap<StoreCreateDto, Store>();
            CreateMap<StoreUpdateDto, Store>();
            CreateMap<Store, StoreCreateDto>();
            CreateMap<Store, StoreUpdateDto>();
            CreateMap<StoreDto, StoreCreateDto>();
            CreateMap<StoreDto, StoreUpdateDto>();
            #endregion

            #region categorie
            CreateMap<Categorie, CategorieDto>();
            CreateMap<CategorieCreateDto, Categorie>();
            CreateMap<CategorieUpdateDto, Categorie>();
            CreateMap<Categorie, CategorieCreateDto>();
            CreateMap<Categorie, CategorieUpdateDto>();
            CreateMap<CategorieDto, CategorieCreateDto>();
            CreateMap<CategorieDto, CategorieUpdateDto>();
            #endregion

            #region unit
            CreateMap<Unit, UnitDto>();
            CreateMap<UnitCreateDto, Unit>();
            CreateMap<UnitUpdateDto, Unit>();
            CreateMap<Unit, UnitCreateDto>();
            CreateMap<Unit, UnitUpdateDto>();
            CreateMap<UnitDto, UnitCreateDto>();
            CreateMap<UnitDto, UnitUpdateDto>();
            #endregion

            #region supplier
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierCreateDto, Supplier>();
            CreateMap<SupplierUpdateDto, Supplier>();
            CreateMap<Supplier, SupplierCreateDto>();
            CreateMap<Supplier, SupplierUpdateDto>();
            CreateMap<SupplierDto, SupplierCreateDto>();
            CreateMap<SupplierDto, SupplierUpdateDto>();
            #endregion

            #region item
            CreateMap<Item, ItemDto>()
                .ForMember(d => d.CategorieName, opt => opt.MapFrom(i => i.Categorie.Name))
                .ForMember(d => d.UnitName, opt => opt.MapFrom(i => i.Unit.Name));
            CreateMap<ItemCreateDto, Item>();
            CreateMap<ItemUpdateDto, Item>();
            CreateMap<Item, ItemCreateDto>();
            CreateMap<Item, ItemUpdateDto>();
            CreateMap<ItemDto, ItemCreateDto>();
            CreateMap<ItemDto, ItemUpdateDto>();
            #endregion

            #region purchaseoder
            CreateMap<PurchaseOder, PurchaseOderDto>()
                .ForMember(d => d.SupplierName, opt => opt.MapFrom(i => i.Supplier.Name));
            CreateMap<PurchaseOderCreateDto, PurchaseOder>();
            CreateMap<PurchaseOderUpdateDto, PurchaseOder>();
            CreateMap<PurchaseOder, PurchaseOderCreateDto>();
            CreateMap<PurchaseOder, PurchaseOderUpdateDto>();
            CreateMap<PurchaseOderDto, PurchaseOderCreateDto>();
            CreateMap<PurchaseOderDto, PurchaseOderUpdateDto>();

            CreateMap<PurchaseOder, PurchaseOderAuditDto>();
            CreateMap<PurchaseOderDto, PurchaseOderAuditDto>();
            CreateMap<PurchaseOderAuditDto, PurchaseOder>();
            CreateMap<PurchaseOderAuditDto, PurchaseOderDto>();

            CreateMap<PurchaseOderItem, PurchaseOderItemDto>()
                .ForMember(d => d.ItemCode, opt => opt.MapFrom(i => i.Item.Code))
                .ForMember(d => d.ItemName, opt => opt.MapFrom(i => i.Item.Name))
                .ForMember(d => d.UnitName, opt => opt.MapFrom(i => i.Item.Unit.Name))
                .ForMember(d => d.PurchasePrice, opt => opt.MapFrom(i => i.Item.PurchasePrice));
            CreateMap<PurchaseOderItemCreateDto, PurchaseOderItem>();
            CreateMap<PurchaseOderItemUpdateDto, PurchaseOderItem>();
            CreateMap<PurchaseOderItem, PurchaseOderItemCreateDto>();
            CreateMap<PurchaseOderItem, PurchaseOderItemUpdateDto>();
            CreateMap<PurchaseOderItemDto, PurchaseOderItemCreateDto>();
            CreateMap<PurchaseOderItemDto, PurchaseOderItemUpdateDto>();
            #endregion

            #region purchasereceiveoder
            CreateMap<PurchaseReceiveOder, PurchaseReceiveOderDto>()
                .ForMember(d => d.SupplierName, opt => opt.MapFrom(i => i.Supplier.Name));
            CreateMap<PurchaseReceiveOderCreateDto, PurchaseReceiveOder>();
            CreateMap<PurchaseReceiveOderUpdateDto, PurchaseReceiveOder>();
            CreateMap<PurchaseReceiveOder, PurchaseReceiveOderCreateDto>();
            CreateMap<PurchaseReceiveOder, PurchaseReceiveOderUpdateDto>();
            CreateMap<PurchaseReceiveOderDto, PurchaseReceiveOderCreateDto>();
            CreateMap<PurchaseReceiveOderDto, PurchaseReceiveOderUpdateDto>();

            CreateMap<PurchaseReceiveOderItem, PurchaseReceiveOderItemDto>()
                .ForMember(d => d.ItemCode, opt => opt.MapFrom(i => i.Item.Code))
                .ForMember(d => d.ItemName, opt => opt.MapFrom(i => i.Item.Name))
                .ForMember(d => d.UnitName, opt => opt.MapFrom(i => i.Item.Unit.Name))
                .ForMember(d => d.PurchasePrice, opt => opt.MapFrom(i => i.Item.PurchasePrice));
            CreateMap<PurchaseReceiveOderItemCreateDto, PurchaseReceiveOderItem>();
            CreateMap<PurchaseReceiveOderItemUpdateDto, PurchaseReceiveOderItem>();
            CreateMap<PurchaseReceiveOderItem, PurchaseReceiveOderItemCreateDto>();
            CreateMap<PurchaseReceiveOderItem, PurchaseReceiveOderItemUpdateDto>();
            CreateMap<PurchaseReceiveOderItemDto, PurchaseReceiveOderItemCreateDto>();
            CreateMap<PurchaseReceiveOderItemDto, PurchaseReceiveOderItemUpdateDto>();
            #endregion

            #region purchasereturnoder
            CreateMap<PurchaseReturnOder, PurchaseReturnOderDto>()
                .ForMember(d => d.SupplierName, opt => opt.MapFrom(i => i.Supplier.Name));
            CreateMap<PurchaseReturnOderCreateDto, PurchaseReturnOder>();
            CreateMap<PurchaseReturnOderUpdateDto, PurchaseReturnOder>();
            CreateMap<PurchaseReturnOder, PurchaseReturnOderCreateDto>();
            CreateMap<PurchaseReturnOder, PurchaseReturnOderUpdateDto>();
            CreateMap<PurchaseReturnOderDto, PurchaseReturnOderCreateDto>();
            CreateMap<PurchaseReturnOderDto, PurchaseReturnOderUpdateDto>();

            CreateMap<PurchaseReturnOderItem, PurchaseReturnOderItemDto>()
                .ForMember(d => d.ItemCode, opt => opt.MapFrom(i => i.Item.Code))
                .ForMember(d => d.ItemName, opt => opt.MapFrom(i => i.Item.Name))
                .ForMember(d => d.UnitName, opt => opt.MapFrom(i => i.Item.Unit.Name))
                .ForMember(d => d.PurchasePrice, opt => opt.MapFrom(i => i.Item.PurchasePrice));
            CreateMap<PurchaseReturnOderItemCreateDto, PurchaseReturnOderItem>();
            CreateMap<PurchaseReturnOderItemUpdateDto, PurchaseReturnOderItem>();
            CreateMap<PurchaseReturnOderItem, PurchaseReturnOderItemCreateDto>();
            CreateMap<PurchaseReturnOderItem, PurchaseReturnOderItemUpdateDto>();
            CreateMap<PurchaseReturnOderItemDto, PurchaseReturnOderItemCreateDto>();
            CreateMap<PurchaseReturnOderItemDto, PurchaseReturnOderItemUpdateDto>();
            #endregion

            #region stock
            CreateMap<Stock, StockDto>()
                .ForMember(d => d.ItemId, opt => opt.MapFrom(s => s.Item.Id))
                .ForMember(d => d.ItemCode, opt => opt.MapFrom(s => s.Item.Code))
                .ForMember(d => d.ItemName, opt => opt.MapFrom(s => s.Item.Name))
                .ForMember(d => d.UnitName, opt => opt.MapFrom(s => s.Item.Unit.Name))
                .ForMember(d => d.CategorieName, opt => opt.MapFrom(s => s.Item.Categorie.Name));
            CreateMap<StockCreateDto, Stock>();
            CreateMap<StockUpdateDto, Stock>();
            CreateMap<Stock, StockCreateDto>();
            CreateMap<Stock, StockUpdateDto>();
            CreateMap<StockDto, StockCreateDto>();
            CreateMap<StockDto, StockUpdateDto>();
            #endregion

            #region Payment
            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentCreateDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>();
            CreateMap<Payment, PaymentCreateDto>();
            CreateMap<Payment, PaymentUpdateDto>();
            CreateMap<PaymentDto, PaymentCreateDto>();
            CreateMap<PaymentDto, PaymentUpdateDto>();
            #endregion

            #region PosRegister
            CreateMap<PosRegister, PosRegisterDto>();
            CreateMap<PosRegisterCreateDto, PosRegister>();
            CreateMap<PosRegisterUpdateDto, PosRegister>();
            CreateMap<PosRegister, PosRegisterCreateDto>();
            CreateMap<PosRegister, PosRegisterUpdateDto>();
            CreateMap<PosRegisterDto, PosRegisterCreateDto>();
            CreateMap<PosRegisterDto, PosRegisterUpdateDto>();
            #endregion

            #region BillInfo
            CreateMap<BillInfo, BillInfoDto>();
            CreateMap<BillInfoCreateDto, BillInfo>();
            #endregion

            #region PayFlow
            CreateMap<PayFlow, PayFlowDto>();
            CreateMap<PayFlow, PayFlowBillInfoDto>();
            CreateMap<PayFlowCreateDto, PayFlow>();
            #endregion

            #region SaleFlow
            CreateMap<SaleFlow, SaleFlowDto>();
            CreateMap<SaleFlow, SaleFlowBillInfoDto>();
            CreateMap<SaleFlowCreateDto, SaleFlow>();
            #endregion

            #region VipType
            CreateMap<VipType, VipTypeDto>();
            CreateMap<VipTypeCreateDto, VipType>();
            CreateMap<VipTypeUpdateDto, VipType>();
            CreateMap<VipType, VipTypeCreateDto>();
            CreateMap<VipType, VipTypeUpdateDto>();
            CreateMap<VipTypeDto, VipTypeCreateDto>();
            CreateMap<VipTypeDto, VipTypeUpdateDto>();
            #endregion

            #region VipScoreSetting
            CreateMap<VipScoreSetting, VipScoreSettingDto>();
            CreateMap<VipScoreSettingCreateDto, VipScoreSetting>();
            CreateMap<VipScoreSettingUpdateDto, VipScoreSetting>();
            CreateMap<VipScoreSetting, VipScoreSettingCreateDto>();
            CreateMap<VipScoreSetting, VipScoreSettingUpdateDto>();
            CreateMap<VipScoreSettingDto, VipScoreSettingCreateDto>();
            CreateMap<VipScoreSettingDto, VipScoreSettingUpdateDto>();
            #endregion

            #region Vip
            CreateMap<Vip, VipDto>();
            CreateMap<VipCreateDto, Vip>();
            CreateMap<VipUpdateDto, Vip>();
            CreateMap<Vip, VipCreateDto>();
            CreateMap<Vip, VipUpdateDto>();
            CreateMap<VipDto, VipCreateDto>();
            CreateMap<VipDto, VipUpdateDto>();
            #endregion

            #region PromotionOder
            CreateMap<PromotionOder, PromotionOderDto>();
            CreateMap<PromotionOderCreateDto, PromotionOder>();
            CreateMap<PromotionOderUpdateDto, PromotionOder>();
            CreateMap<PromotionOder, PromotionOderCreateDto>();
            CreateMap<PromotionOder, PromotionOderUpdateDto>();
            CreateMap<PromotionOderDto, PromotionOderCreateDto>();
            CreateMap<PromotionOderDto, PromotionOderUpdateDto>();
            #endregion

            #region PromotionSpecialOfferItem
            CreateMap<PromotionSpecialOfferItem, PromotionSpecialOfferItemDto>()
                .ForMember(d => d.ItemCode, opt => opt.MapFrom(i => i.Item.Code))
                .ForMember(d => d.ItemName, opt => opt.MapFrom(i => i.Item.Name))
                .ForMember(d => d.UnitName, opt => opt.MapFrom(i => i.Item.Unit.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(i => i.Item.Price));
            CreateMap<PromotionSpecialOfferItemCreateDto, PromotionSpecialOfferItem>();
            CreateMap<PromotionSpecialOfferItemUpdateDto, PromotionSpecialOfferItem>();
            CreateMap<PromotionSpecialOfferItem, PromotionSpecialOfferItemCreateDto>();
            CreateMap<PromotionSpecialOfferItem, PromotionSpecialOfferItemUpdateDto>();
            CreateMap<PromotionSpecialOfferItemDto, PromotionSpecialOfferItemCreateDto>();
            CreateMap<PromotionSpecialOfferItemDto, PromotionSpecialOfferItemUpdateDto>();
            #endregion

            #region PromotionDiscountItem
            CreateMap<PromotionDiscountItem, PromotionDiscountItemDto>()
                .ForMember(d => d.ItemCode, opt => opt.MapFrom(i => i.Item.Code))
                .ForMember(d => d.ItemName, opt => opt.MapFrom(i => i.Item.Name))
                .ForMember(d => d.UnitName, opt => opt.MapFrom(i => i.Item.Unit.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(i => i.Item.Price));
            CreateMap<PromotionDiscountItemCreateDto, PromotionDiscountItem>();
            CreateMap<PromotionDiscountItemUpdateDto, PromotionDiscountItem>();
            CreateMap<PromotionDiscountItem, PromotionDiscountItemCreateDto>();
            CreateMap<PromotionDiscountItem, PromotionDiscountItemUpdateDto>();
            CreateMap<PromotionDiscountItemDto, PromotionDiscountItemCreateDto>();
            CreateMap<PromotionDiscountItemDto, PromotionDiscountItemUpdateDto>();
            #endregion

            #region PromotionDiscountCategorie
            CreateMap<PromotionDiscountCategorie, PromotionDiscountCategorieDto>()
                .ForMember(d => d.CategorieName, opt => opt.MapFrom(i => i.Categorie.Name))
                .ForMember(d => d.CategorieCode, opt => opt.MapFrom(i => i.Categorie.Code));
            CreateMap<PromotionDiscountCategorieCreateDto, PromotionDiscountCategorie>();
            CreateMap<PromotionDiscountCategorieUpdateDto, PromotionDiscountCategorie>();
            CreateMap<PromotionDiscountCategorie, PromotionDiscountCategorieCreateDto>();
            CreateMap<PromotionDiscountCategorie, PromotionDiscountCategorieUpdateDto>();
            CreateMap<PromotionDiscountCategorieDto, PromotionDiscountCategorieCreateDto>();
            CreateMap<PromotionDiscountCategorieDto, PromotionDiscountCategorieUpdateDto>();
            #endregion
        }
    }
}
