using MiniShop.Frontend.Client.Common;
using MiniShop.Frontend.Client.Dtos;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Frontend.Client.ViewModels
{
    public class CashierDeskViewModel : BindableBase
    {
        private ObservableCollection<CategorieDto>categorieDtos;
        public ObservableCollection<CategorieDto> CategorieDtos
        {
            get { return categorieDtos; }
            set { categorieDtos = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<ItemDto> itemDtos;
        public ObservableCollection<ItemDto> ItemDtos
        {
            get { return itemDtos; }
            set { itemDtos = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<SaleItemDto> saleItemDtos;
        public ObservableCollection<SaleItemDto> SaleItemDtos
        {
            get { return saleItemDtos; }
            set { saleItemDtos = value; RaisePropertyChanged(); }
        }
        private SaleTotalDto saleTotalDtos;
        public SaleTotalDto SaleTotalDtos
        {
            get { return saleTotalDtos; }
            set { saleTotalDtos = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<CashierOperBar> cashierOperBars;
        public ObservableCollection<CashierOperBar> CashierOperBars
        {
            get { return cashierOperBars; }
            set { cashierOperBars = value; RaisePropertyChanged(); }
        }



        public DelegateCommand<int?> SelectItemCommand { get; private set; }
        public DelegateCommand<int?> SelectCategorieCommand { get; private set; }
        public DelegateCommand<CashierOperBar> CashierOperCommand { get; }

        public CashierDeskViewModel()
        {
            #region datainit
            SaleTotalDtos = new SaleTotalDto()
            {
                Amount = 123,
                Number = 10,
            };

            SaleItemDtos = new ObservableCollection<SaleItemDto>
            {
                new SaleItemDto
                {
                    Id = 1,
                    Name = "哈哈哈",
                    Code = "1234567890123",
                    Price = 10,
                    Number = 1,
                    Amount = 10,
                },
                new SaleItemDto
                {
                    Id = 2,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 3,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 4,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 5,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 6,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 7,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 8,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 1,
                    Name = "哈哈哈",
                    Code = "1234567890123",
                    Price = 10,
                    Number = 1,
                    Amount = 10,
                },
                new SaleItemDto
                {
                    Id = 2,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 3,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 4,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 5,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 6,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 7,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                },
                new SaleItemDto
                {
                    Id = 8,
                    Name = "哈哈哈",
                    Code = "6699663355114",
                    Price = 9999.99M,
                    Number = 9999.99M,
                    Amount = 1013.01M,
                }
            };

            CategorieDtos = new ObservableCollection<CategorieDto>
            {
                new CategorieDto{ Id = 1, Code = 101, Name = "水果" },
                new CategorieDto{ Id = 2, Code = 101, Name = "手机" },
                new CategorieDto{ Id = 3, Code = 101, Name = "烟" },
                new CategorieDto{ Id = 4, Code = 101, Name = "酒" },
                new CategorieDto{ Id = 5, Code = 101, Name = "猪肉" },
                new CategorieDto{ Id = 6, Code = 101, Name = "水果1" },
                new CategorieDto{ Id = 7, Code = 101, Name = "水果2" },
                new CategorieDto{ Id = 8, Code = 101, Name = "水果3" },
                new CategorieDto{ Id = 9, Code = 101, Name = "水果4" },
                new CategorieDto{ Id = 10, Code = 101, Name = "水果5" },
                new CategorieDto{ Id = 11, Code = 101, Name = "水果6" },
                new CategorieDto{ Id = 12, Code = 101, Name = "水果7" },
                new CategorieDto{ Id = 13, Code = 101, Name = "水果8" },
                new CategorieDto{ Id = 14, Code = 101, Name = "水果9" },
                new CategorieDto{ Id = 15, Code = 101, Name = "水果10" },
                new CategorieDto{ Id = 15, Code = 101, Name = "水果11" },
                new CategorieDto{ Id = 15, Code = 101, Name = "水果12" },
                new CategorieDto{ Id = 15, Code = 101, Name = "水果13" },
                new CategorieDto{ Id = 15, Code = 101, Name = "水果14" },
                new CategorieDto{ Id = 15, Code = 101, Name = "水果15" },
                new CategorieDto{ Id = 15, Code = 101, Name = "水果16" },
            };

            ItemDtos = new ObservableCollection<ItemDto>
            {
                new ItemDto{ Id = 1, Code = "101", Name = "芙蓉王", Price = 1 },
                new ItemDto{ Id = 2, Code = "102", Name = "玉溪", Price = 2 },
                new ItemDto{ Id = 3, Code = "103", Name = "好日子", Price = 3 },
                new ItemDto{ Id = 4, Code = "104", Name = "红双喜", Price = 4 },
                new ItemDto{ Id = 5, Code = "105", Name = "七匹狼", Price = 5 },
                new ItemDto{ Id = 6, Code = "106", Name = "中华", Price = 6 },
                new ItemDto{ Id = 7, Code = "107", Name = "轿子", Price = 7 },
                new ItemDto{ Id = 8, Code = "108", Name = "利群", Price = 8 },
                new ItemDto{ Id = 9, Code = "109", Name = "真龙", Price = 9 },
                new ItemDto{ Id = 10, Code = "110", Name = "熊猫", Price = 10 },
                new ItemDto{ Id = 11, Code = "111", Name = "万宝路", Price = 11 },
                new ItemDto{ Id = 12, Code = "112", Name = "云烟", Price = 12 },
                new ItemDto{ Id = 13, Code = "113", Name = "黄鹤楼", Price = 13 },
                new ItemDto{ Id = 14, Code = "114", Name = "苹果", Price = 14 },
                new ItemDto{ Id = 15, Code = "115", Name = "香蕉", Price = 15 },
                new ItemDto{ Id = 16, Code = "116", Name = "雪梨", Price = 16 },
                new ItemDto{ Id = 17, Code = "117", Name = "西瓜", Price = 17 },
                new ItemDto{ Id = 18, Code = "118", Name = "芒果", Price = 18 },
                new ItemDto{ Id = 19, Code = "119", Name = "葡萄", Price = 19 },
                new ItemDto{ Id = 20, Code = "120", Name = "水蜜桃", Price = 20 },
                new ItemDto{ Id = 21, Code = "121", Name = "哈密瓜", Price = 21 },
                new ItemDto{ Id = 22, Code = "122", Name = "榴莲", Price = 22 },
                new ItemDto{ Id = 23, Code = "123", Name = "荔枝", Price = 23 },
                new ItemDto{ Id = 24, Code = "124", Name = "草莓", Price = 24 },
                new ItemDto{ Id = 25, Code = "125", Name = "火龙果", Price = 25 },
                new ItemDto{ Id = 26, Code = "126", Name = "三华李", Price = 26 },
                new ItemDto{ Id = 27, Code = "127", Name = "水果1", Price = 27 },
                new ItemDto{ Id = 28, Code = "128", Name = "水果2", Price = 28 },
                new ItemDto{ Id = 29, Code = "129", Name = "水果3", Price = 29 },
                new ItemDto{ Id = 30, Code = "130", Name = "水果4", Price = 30 },
                new ItemDto{ Id = 31, Code = "131", Name = "水果5", Price = 31 },
                new ItemDto{ Id = 32, Code = "132", Name = "水果6", Price = 32 },
                new ItemDto{ Id = 33, Code = "133", Name = "水果7", Price = 33 },
                new ItemDto{ Id = 34, Code = "134", Name = "水果8", Price = 34 },
                new ItemDto{ Id = 35, Code = "135", Name = "水果9", Price = 35 },
                new ItemDto{ Id = 36, Code = "136", Name = "水果10", Price = 36 },
                new ItemDto{ Id = 37, Code = "137", Name = "水果11", Price = 37 },
                new ItemDto{ Id = 38, Code = "138", Name = "水果12", Price = 38 },
                new ItemDto{ Id = 39, Code = "139", Name = "水果13", Price = 39 },
                new ItemDto{ Id = 40, Code = "140", Name = "水果14", Price = 40 },
                new ItemDto{ Id = 41, Code = "141", Name = "水果15", Price = 41 },
                new ItemDto{ Id = 42, Code = "142", Name = "水果16", Price = 42 },
                new ItemDto{ Id = 1, Code = "101", Name = "芙蓉王", Price = 1 },
                new ItemDto{ Id = 2, Code = "102", Name = "玉溪", Price = 2 },
                new ItemDto{ Id = 3, Code = "103", Name = "好日子", Price = 3 },
                new ItemDto{ Id = 4, Code = "104", Name = "红双喜", Price = 4 },
                new ItemDto{ Id = 5, Code = "105", Name = "七匹狼", Price = 5 },
                new ItemDto{ Id = 6, Code = "106", Name = "中华", Price = 6 },
                new ItemDto{ Id = 7, Code = "107", Name = "轿子", Price = 7 },
                new ItemDto{ Id = 8, Code = "108", Name = "利群", Price = 8 },
                new ItemDto{ Id = 9, Code = "109", Name = "真龙", Price = 9 },
                new ItemDto{ Id = 10, Code = "110", Name = "熊猫", Price = 10 },
                new ItemDto{ Id = 11, Code = "111", Name = "万宝路", Price = 11 },
                new ItemDto{ Id = 12, Code = "112", Name = "云烟", Price = 12 },
                new ItemDto{ Id = 13, Code = "113", Name = "黄鹤楼", Price = 13 },
                new ItemDto{ Id = 14, Code = "114", Name = "苹果", Price = 14 },
                new ItemDto{ Id = 15, Code = "115", Name = "香蕉", Price = 15 },
                new ItemDto{ Id = 16, Code = "116", Name = "雪梨", Price = 16 },
                new ItemDto{ Id = 17, Code = "117", Name = "西瓜", Price = 17 },
                new ItemDto{ Id = 18, Code = "118", Name = "芒果", Price = 18 },
                new ItemDto{ Id = 19, Code = "119", Name = "葡萄", Price = 19 },
                new ItemDto{ Id = 20, Code = "120", Name = "水蜜桃", Price = 20 },
                new ItemDto{ Id = 21, Code = "121", Name = "哈密瓜", Price = 21 },
                new ItemDto{ Id = 22, Code = "122", Name = "榴莲", Price = 22 },
                new ItemDto{ Id = 23, Code = "123", Name = "荔枝", Price = 23 },
                new ItemDto{ Id = 24, Code = "124", Name = "草莓", Price = 24 },
                new ItemDto{ Id = 25, Code = "125", Name = "火龙果", Price = 25 },
                new ItemDto{ Id = 26, Code = "126", Name = "三华李", Price = 26 },
                new ItemDto{ Id = 27, Code = "127", Name = "水果1", Price = 27 },
                new ItemDto{ Id = 28, Code = "128", Name = "水果2", Price = 28 },
                new ItemDto{ Id = 29, Code = "129", Name = "水果3", Price = 29 },
                new ItemDto{ Id = 30, Code = "130", Name = "水果4", Price = 30 },
                new ItemDto{ Id = 31, Code = "131", Name = "水果5", Price = 31 },
                new ItemDto{ Id = 32, Code = "132", Name = "水果6", Price = 32 },
                new ItemDto{ Id = 33, Code = "133", Name = "水果7", Price = 33 },
                new ItemDto{ Id = 34, Code = "134", Name = "水果8", Price = 34 },
                new ItemDto{ Id = 35, Code = "135", Name = "水果9", Price = 35 },
                new ItemDto{ Id = 36, Code = "136", Name = "水果10", Price = 36 },
                new ItemDto{ Id = 37, Code = "137", Name = "水果11", Price = 37 },
                new ItemDto{ Id = 38, Code = "138", Name = "水果12", Price = 38 },
                new ItemDto{ Id = 39, Code = "139", Name = "水果13", Price = 39 },
                new ItemDto{ Id = 40, Code = "140", Name = "水果14", Price = 40 },
                new ItemDto{ Id = 41, Code = "141", Name = "水果15", Price = 41 },
                new ItemDto{ Id = 42, Code = "142", Name = "水果16", Price = 42 },
            };

            CashierOperBars = new ObservableCollection<CashierOperBar>
            {
                new CashierOperBar { Icon = "Home", Title = "结账", NameSpace = "SettleAccountView" },
                new CashierOperBar { Icon = "FileArrowLeftRight", Title = "会员", NameSpace = "VipView" },
                new CashierOperBar { Icon = "Vhs", Title = "优惠", NameSpace = "CheckStockView" },
                new CashierOperBar { Icon = "Cog", Title = "退货", NameSpace = "SettingView" },
                new CashierOperBar { Icon = "Cog", Title = "挂单", NameSpace = "SettingView" },
                new CashierOperBar { Icon = "Cog", Title = "赠送", NameSpace = "SettingView" },
                new CashierOperBar { Icon = "Cog", Title = "修改", NameSpace = "SettingView" },
                new CashierOperBar { Icon = "Cog", Title = "整单取消", NameSpace = "AllCancelCommand" },
                new CashierOperBar { Icon = "Cog", Title = "更多", NameSpace = "SettingView" }
            };
            #endregion


            CashierOperCommand = new DelegateCommand<CashierOperBar>(CashierOper);
            SelectItemCommand = new DelegateCommand<int?>(SelectItem);
            SelectCategorieCommand = new DelegateCommand<int?>(SelectCategorie);


        }

        private void SelectCategorie(int? id)
        {
            CategorieDto selectCategorie = CategorieDtos.ToList().First(i => i.Id == id);
            if (selectCategorie != null)
            {
                selectCategorie.Name += "1";
            }
        }
        private void SelectItem(int? id)
        {
            ItemDto selectItem = ItemDtos.ToList().First(i => i.Id == id);
            if (selectItem != null)
            {
                SaleItemDto shopItemDto = new()
                {
                    Id = selectItem.Id,
                    Code = selectItem.Code,
                    Name = selectItem.Name,
                    Price = selectItem.Price,
                    Number = 1,
                    Amount = selectItem.Price,
                };
                SaleItemDtos.Add(shopItemDto);
            }
        }
        private void CashierOper(CashierOperBar obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.NameSpace))
                return;
            if (obj.NameSpace.Contains("View"))
            {
                //regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back => {
                //    journal = back.Context.NavigationService.Journal;
                //});
            }
            else
            {
                switch (obj.NameSpace)
                {
                    case "AllCancelCommand": AllCancel(); break;
                }
            }

        }


        private void AllCancel()
        {
            SaleItemDtos.Clear();
        }
    }
}
