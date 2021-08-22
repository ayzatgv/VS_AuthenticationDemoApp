namespace AuthenticationDemoApp.Models.ViewModels
{
    public class Allow_Select_ViewModel
    {
        private int _id;
        private string _name;
        private string _description;
        private bool _status;

        /// <summary>
        /// ای دی پنل در دیتابیس
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Allow_Select_ViewModel()
        {

        }
        public Allow_Select_ViewModel(Panel panel)
        {
            this.ID = panel.ID;
            this.Name = panel.Name;
            this.Description = panel.Description;
            this.Status = false;
        }
    }
}