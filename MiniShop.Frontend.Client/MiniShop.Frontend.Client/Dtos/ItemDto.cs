using System;

namespace MiniShop.Frontend.Client.Dtos
{
    public class ItemDto : NotifyPropertyChangedDto
    {
        private int id;
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }

        public Guid shopId;
        public Guid ShopId { get { return shopId; } set { shopId = value; OnPropertyChanged(); } }

        private int unitId;
        public int UnitId { get { return unitId; } set { unitId = value; OnPropertyChanged(); } }

        private int categorieId;
        public int CategorieId { get { return categorieId; } set { categorieId = value; OnPropertyChanged(); } }

        private string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }

        private string code;
        public string Code { get { return code; } set { code = value; OnPropertyChanged(); } }

        private decimal price;
        public decimal Price { get { return price; } set { price = value; OnPropertyChanged(); } }

        private decimal purchasePrice;
        public decimal PurchasePrice { get { return purchasePrice; } set { purchasePrice = value; OnPropertyChanged(); } }

        private int state;
        public int State { get { return state; } set { state = value; OnPropertyChanged(); } }

        private int type;
        public int Type { get { return type; } set { type = value; OnPropertyChanged(); } }

        private int priceType;
        public int PriceType { get { return priceType; } set { priceType = value; OnPropertyChanged(); } }

        private string picture;
        public string Picture { get { return picture; } set { picture = value; OnPropertyChanged(); } }
    }
}
