namespace TIOFPSS.ViewModels
{
    public class FontsViewModel : ViewModel
    {
        private string[] data = { "Tahoma", "Segoe UI", "Arial", "Courier New", "Symbol" };

        public string[] FontsData
        {
            get { return this.data; }
            set
            {
                data=value;
                this.OnPropertyChanged("FontsData");
            }
        }
    }
}
