namespace MiniShop.Frontend.Client.Dtos
{
    public class VipDto : NotifyPropertyChangedDto
    {
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged(); }
        }

        private decimal remain;

        public decimal Remain
        {
            get { return remain; }
            set { remain = value; OnPropertyChanged(); }
        }

        private decimal integral;

        public decimal Integral
        {
            get { return integral; }
            set { integral = value; OnPropertyChanged(); }
        }

    }
}
