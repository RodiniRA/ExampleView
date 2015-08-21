using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using AmTrustExample.ViewModels;


namespace AmTrustExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainViewModel _vm;
        public MainWindow()
        {
            _vm = new MainViewModel();
            DataContext = _vm;
            InitializeComponent();
        }

        //public void ShowFileFlyout(object sender, RoutedEventArgs e)
        //{
        //    ToggleFlyout(0);
        //}

        private void ToggleFlyout(int index)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
        }

        private void CheckNewSize(object sender, SizeChangedEventArgs e)
        {
            double width = e.NewSize.Width;
            double height = e.NewSize.Height;
        }

        private void DarkSkin_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resources = null;
            resources = (ResourceDictionary)Application.LoadComponent(new Uri("Skins/DarkSkin.xaml", UriKind.RelativeOrAbsolute));
            this.FileFlyout.IsOpen = false;

            this.Resources.MergedDictionaries.Clear();
            Application.Current.Resources = resources;
        }

        private void GreenSkin_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resources = null;
            resources = (ResourceDictionary)Application.LoadComponent(new Uri("Skins/GreenSkin.xaml", UriKind.RelativeOrAbsolute));
            this.FileFlyout.IsOpen = false;

            this.Resources.MergedDictionaries.Clear();
            Application.Current.Resources = resources;
        }

        private void ShowFileFlyout(object sender, MouseButtonEventArgs e)
        {
            ToggleFlyout(0);
            //this.File.Visibility = Visibility.Hidden;
        }

        private void SetDefaultTheme(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resources = null;
            resources = (ResourceDictionary)Application.LoadComponent(new Uri("Skins/DefaultSkin.xaml", UriKind.RelativeOrAbsolute));
            this.FileFlyout.IsOpen = false;

            this.Resources.MergedDictionaries.Clear();
            Application.Current.Resources = resources;
        }

        private void GummiBearSkin_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resources = null;
            resources = (ResourceDictionary)Application.LoadComponent(new Uri("Skins/GummiBearSkin.xaml", UriKind.RelativeOrAbsolute));
            this.FileFlyout.IsOpen = false;

            this.Resources.MergedDictionaries.Clear();
            Application.Current.Resources = resources;
        }

    }
}
