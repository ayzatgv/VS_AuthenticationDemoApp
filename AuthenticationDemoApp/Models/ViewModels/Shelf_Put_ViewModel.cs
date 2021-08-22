namespace AuthenticationDemoApp.Models.ViewModels
{
    public class Shelf_Put_ViewModel
    {
        private int _total;

        /// <summary>
        /// تعداد کل کتاب در کتابخانه
        /// </summary>
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

    }
}