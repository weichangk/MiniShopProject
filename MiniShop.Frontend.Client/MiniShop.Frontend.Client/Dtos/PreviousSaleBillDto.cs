namespace MiniShop.Frontend.Client.Dtos
{
    public class PreviousSaleBillDto : NotifyPropertyChangedDto
    {
        public int Id { get; set; }

        private string billNo;

        public string BillNo
        {
            get { return billNo; }
            set { billNo = value; OnPropertyChanged(); }
        }

        private decimal receivable;

        public decimal Receivable
        {
            get { return receivable; }
            set { receivable = value; OnPropertyChanged(); }
        }

        private decimal realreceivable;

        public decimal Realreceivable
        {
            get { return realreceivable; }
            set { realreceivable = value; OnPropertyChanged(); }
        }

        private decimal giveChange;

        public decimal GiveChange
        {
            get { return giveChange; }
            set { giveChange = value; OnPropertyChanged(); }
        }
    }
}
