using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using AmTrustExample.Models;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AmTrustExample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public List<ButtonModel> QueryButtonOptions { get; set; }
        public List<ButtonModel> PolicySystemButtons { get; set; }

        private ContextMenu _testMenu = null;
        private ContextMenu _underwritingDropDownMenu = null;
        private ContextMenu _queryDropDownMenu = null;

        public ContextMenu TestMenu
        {
            get
            {
                if (_testMenu == null)
                {
                    _testMenu = new ContextMenu();

                    for (int i = 0; i < 5; i++)
                    {
                        var mItem = new MenuItem();
                        mItem.Header = "Test " + i;
                        mItem.ToolTip = "TEST puffaPUFFApuffa TEST";
                        mItem.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)), Height = 32, Width = 32 };

                        _testMenu.Items.Add(mItem);
                    }
                }
                return _testMenu;
            }
        }

        public ContextMenu UnderwritingDropDownMenu
        {
            get
            {
                if (_underwritingDropDownMenu == null)
                {
                    _underwritingDropDownMenu = new ContextMenu();

                    var mItem = new MenuItem();

                    mItem.Header = "Quote";
                    mItem.ToolTip = "UNDERWRITE THE ACCOUNT";
                    mItem.Name = "btnUnderwritingQuote";
                    mItem.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)), Height = 32, Width = 32 };
                    _underwritingDropDownMenu.Items.Add(mItem);
                    mItem = new MenuItem();
                    mItem.Header = "Decline";
                    mItem.ToolTip = "SEND A DECLINATION LETTER";
                    mItem.Name = "btnUnderwritingDecline";
                    mItem.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)), Height = 32, Width = 32 };
                    _underwritingDropDownMenu.Items.Add(mItem);
                    mItem = new MenuItem();
                    mItem.Header = "Additional Information";
                    mItem.ToolTip = "REQUEST ADDITIONAL INFORMATION";
                    mItem.Name = "btnUnderwritingADDInfo";
                    mItem.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)), Height = 32, Width = 32 };
                    _underwritingDropDownMenu.Items.Add(mItem);
                    mItem = new MenuItem();
                    mItem.Header = "Bind Pending";
                    mItem.ToolTip = "FINE, I DIDN'T WANT A TOOL TIP ANYWAYS";
                    mItem.Name = "btnUnderwritingBindPending";
                    mItem.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)), Height = 32, Width = 32 };
                    _underwritingDropDownMenu.Items.Add(mItem);
                    mItem = new MenuItem();
                    mItem.Header = "General";
                    mItem.ToolTip = "GENERAL RESPONSE TO AGENT";
                    mItem.Name = "btnUnderwritingGeneral";
                    mItem.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)), Height = 32, Width = 32 };
                    _underwritingDropDownMenu.Items.Add(mItem);
                    mItem = new MenuItem();
                    mItem.Header = "Non Renew";
                    mItem.ToolTip = "BIND THE VISIBLE UNDERWRITING FILE. ONLY AIIS RENEWALS";
                    mItem.Name = "btnUnderwritingNonRenew";
                    mItem.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)), Height = 32, Width = 32 };
                    _underwritingDropDownMenu.Items.Add(mItem);
                }
                return _underwritingDropDownMenu;
            }
        }

        public ContextMenu QueryDropDownMenu
        {
            get
            {
                if (_queryDropDownMenu == null)
                {
                    _queryDropDownMenu = new ContextMenu();

                    var mItem = new MenuItem();

                    mItem = new MenuItem();
                    mItem.Header = "Agent Info";
                    mItem.ToolTip = "OBTAIN AGENT INFORMATION.  ALSO, CHANGE WEB LOGON INFO.";
                    mItem.Name = "btnQueryAgentInfo";
                    mItem.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)), Height = 32, Width = 32 };
                    _queryDropDownMenu.Items.Add(mItem);
                    mItem = new MenuItem();
                    mItem.Header = "Document Info";
                    mItem.ToolTip = "DISPLAYS ALL SETUP INFORMATION ASSOCIATED WITH DOCUMENT";
                    mItem.Name = "btnQueryDocumentInfo";
                    mItem.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)), Height = 32, Width = 32 };
                    _queryDropDownMenu.Items.Add(mItem);
                }
                return _queryDropDownMenu;
            }
        }

        #region "Constructor"
        public MainViewModel()
        {
            SampleData.Seed();

            QueryButtonOptions = SampleData.ButtonModels;
            PolicySystemButtons = SampleData.PolicySystemButtons;

        }
        #endregion

        #region "Events"
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
