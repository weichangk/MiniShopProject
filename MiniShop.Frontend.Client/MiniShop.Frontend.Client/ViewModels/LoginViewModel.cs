using Microsoft.Extensions.Configuration;
using MiniShop.Frontend.Client.Common;
using MiniShop.Frontend.Client.Dtos;
using MiniShop.Frontend.Client.Extensions;
using MiniShop.Frontend.Client.HttpApis;
using MiniShop.Frontend.Client.Models;
using MiniShop.Frontend.Client.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniShop.Frontend.Client.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public string Title { get; set; } = "Shop";

        public event Action<IDialogResult> RequestClose;

        private readonly IEventAggregator aggregator;
        private readonly IConfiguration configuration;
        private readonly ILogger logger;
        private readonly IItemApi itemApi;
        private readonly ICategorieApi categorieApi;
        private readonly IUnitApi unitApi;
        private readonly IItemService itemService;
        private readonly ICategorieService categorieService;
        private readonly IUnitService unitService;

        public DelegateCommand<string> ExecuteCommand { get; private set; }

        public LoginViewModel(IEventAggregator aggregator, 
            IConfiguration configuration,
            ILogger logger,
            IItemApi itemApi,
            ICategorieApi categorieApi,
            IUnitApi unitApi,
            IItemService itemService,
            ICategorieService categorieService,
            IUnitService unitService)
        {
            this.aggregator = aggregator;
            this.configuration = configuration;
            this.logger = logger;
            this.itemApi = itemApi;
            this.categorieApi = categorieApi;
            this.unitApi = unitApi;
            this.itemService = itemService;
            this.categorieService = categorieService;
            this.unitService = unitService;
            ExecuteCommand = new DelegateCommand<string>(Execute);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            LoginOut();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }




        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(); }
        }

        private string progressBarVisibility = "Hidden";//Visible/Hidden

        public string ProgressBarVisibility
        {
            get { return progressBarVisibility; }
            set { progressBarVisibility = value; RaisePropertyChanged(); }
        }

        private int progressBarValue = 0;

        public int ProgressBarValue
        {
            get { return progressBarValue; }
            set { progressBarValue = value; RaisePropertyChanged(); }
        }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Login": Login(); break;
                case "LoginOut": LoginOut(); break;
            }
        }

        private async void Login()
        {
            UserDto user = new UserDto
            {
                UserName = UserName,
                PassWord = PassWord,
            };
            string error = "";
            bool loginSuccess = await LoginApi.AccessTokenAsync(user, configuration, error);
            if (loginSuccess)
            {
                ProgressBarVisibility = "Visible";
                ProgressBarValue = 10;//ProgressBarValue = 10 ▼▼▼

                await DownloadCategorieData();
 
                await DownloadUnitData();

                await DownloadItemDataAsync();

                ProgressBarValue = 100;//ProgressBarValue = 100 ▼▼▼
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            }
            else
            {
                //登录失败提示...
                aggregator.SendMessage(error, "Login");
            }

        }

        private void LoginOut()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        private async Task DownloadCategorieData()
        {
            var getResult = await ExecuteApi.ExecuteApiAsync(() => { return categorieApi.GetListAllByShopIdAsync(UserInfo.ShopId); });
            ProgressBarValue = 20;// ProgressBarValue = 20 ▼▼▼ 
            if (getResult.Success)
            {
                List<Categorie> categories = new List<Categorie>();
                foreach (var item in getResult.Data)
                {
                    dynamic model = Helper.DynamicValueKindToDynamic(item);
                    categories.Add(new Categorie
                    {
                        CategorieId = model.id,
                        ShopId = model.shopId,
                        Code = model.code,
                        Name = model.name,
                        Level = model.level,
                        ParentCode = model.parentCode,
                    });
                }
                var saveResult = await categorieService.InsertOrUpdateAsync(categories);
                ProgressBarValue = 30;// ProgressBarValue = 30 ▼▼▼
                if (!saveResult.Success)
                {
                    logger.Error("类别数据保存失败");
                }          
            }
            else
            {
                logger.Error($"类别数据请求失败：{getResult.Msg}");
            }      
        }

        private async Task DownloadUnitData()
        {
            var getResult = await ExecuteApi.ExecuteApiAsync(() => { return unitApi.GetListAllByShopIdAsync(UserInfo.ShopId); });
            ProgressBarValue = 40;// ProgressBarValue = 40 ▼▼▼
            if (getResult.Success)
            {
                List<Unit> units = new List<Unit>();
                foreach (var item in getResult.Data)
                {
                    dynamic model = Helper.DynamicValueKindToDynamic(item);
                    units.Add(new Unit
                    {
                        UnitId = model.id,
                        ShopId = model.shopId,
                        Code = model.code,
                        Name = model.name,
                    });
                }
                var saveResult = await unitService.InsertOrUpdateAsync(units);
                ProgressBarValue = 50;// ProgressBarValue = 50 ▼▼▼
                if (!saveResult.Success)
                {
                    logger.Error("单位数据保存失败");
                }
            }
            else
            {
                logger.Error($"单位数据请求失败：{getResult.Msg}");
            }
        }

        private async Task DownloadItemDataAsync()
        {
            var getResult = await ExecuteApi.ExecuteApiAsync(() => { return itemApi.GetListAllByShopIdAsync(UserInfo.ShopId); });
            ProgressBarValue = 60;// ProgressBarValue = 60 ▼▼▼
            if (getResult.Success)
            {
                List<Item> items = new List<Item>();
                foreach (var item in getResult.Data)
                {
                    dynamic model = Helper.DynamicValueKindToDynamic(item);
                    items.Add(new Item
                    {
                        ItemId = model.id,
                        ShopId = model.shopId,
                        CategorieId = model.categorieId,
                        UnitId = model.unitId,
                        Code = model.code,
                        Name = model.name,
                        PurchasePrice = model.purchasePrice,
                        Price = model.price,
                        State = model.state,
                        Type = model.type,
                        PriceType = model.priceType,
                        Picture = model.picture,
                    });
                }
                var saveResult = await itemService.InsertOrUpdateAsync(items);
                ProgressBarValue = 70;// ProgressBarValue = 70 ▼▼▼
                if (!saveResult.Success)
                {
                    logger.Error("商品数据保存失败");
                }
            }
            else
            {
                logger.Error($"商品数据请求失败：{getResult.Msg}");
            }
        }

    }
}
