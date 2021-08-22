using System.Collections.Generic;

namespace AuthenticationDemoApp.Models.ViewModels
{
    public class Group_Select_ViewModel
    {
        #region Variables

        private Panel _panel;
        private List<Menu> _menus;

        #endregion

        #region Properties

        public Panel Panel
        {
            get { return _panel; }
            set { _panel = value; }
        }
        public List<Menu> Menus
        {
            get { return _menus; }
            set { _menus = value; }
        }

        #endregion

        #region Constructors

        public Group_Select_ViewModel()
        {
            Panel = new Panel();
            Menus = new List<Menu>();
        }

        #endregion
    }
}