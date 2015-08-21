using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using AmTrustExample.Models;
using System.Windows.Media;

namespace AmTrustExample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public List<ButtonModel> QueryButtonOptions { get; set; }
        public List<ButtonModel> PolicySystemButtons { get; set; }

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
