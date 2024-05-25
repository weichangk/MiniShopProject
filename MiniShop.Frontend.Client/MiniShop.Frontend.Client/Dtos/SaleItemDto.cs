using System;

namespace MiniShop.Frontend.Client.Dtos
{
    public class SaleItemDto : NotifyPropertyChangedDto
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        private string code;
        public string Code
        {
            get => code; 
            set { code = value; OnPropertyChanged(); }
        }

        private decimal price;
        public decimal Price
        {
            get { return Math.Round(price, 2); }
            set { price = value; OnPropertyChanged(); }
        }

        private decimal number;
        public decimal Number
        {
            get { return Math.Round(number, 2); }
            set { number = value; OnPropertyChanged(); }
        }

        private decimal amount;
        public decimal Amount
        {
            get { return Math.Round(amount, 2); }
            set { amount = value; OnPropertyChanged(); }
        }
    }
}
