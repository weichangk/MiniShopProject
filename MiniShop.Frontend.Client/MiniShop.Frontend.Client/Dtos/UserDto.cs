namespace MiniShop.Frontend.Client.Dtos
{
    public class UserDto : NotifyPropertyChangedDto
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(); }
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; OnPropertyChanged(); }
        }
    }
}
