using System.Collections.ObjectModel;

namespace MiniShop.Frontend.Client.Dtos
{
    public class SaleTotalDto : NotifyPropertyChangedDto
    {
        private decimal number;
        public decimal Number
        {
            get { return number; }
            set { number = value; OnPropertyChanged(); }
        }

        private decimal amount;
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged(); }
        }
    }
}
