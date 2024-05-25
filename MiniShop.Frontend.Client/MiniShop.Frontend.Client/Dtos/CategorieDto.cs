using System;

namespace MiniShop.Frontend.Client.Dtos
{
    public class CategorieDto : NotifyPropertyChangedDto
    {
        private int id;
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }

        public Guid shopId;
        public Guid ShopId { get { return shopId; } set { shopId = value; OnPropertyChanged(); } }

        public int code;
        public int Code { get { return code; } set { code = value; OnPropertyChanged(); } }

        public string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }

        public int level;
        public int Level { get { return level; } set { level = value; OnPropertyChanged(); } }

        public int parentCode;
        public int ParentCode { get { return parentCode; } set { parentCode = value; OnPropertyChanged(); } }
    }
}
