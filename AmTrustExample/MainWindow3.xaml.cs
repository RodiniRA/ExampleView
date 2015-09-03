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
using AmTrustExample.ViewModels;
using AmTrustExample.Models;

namespace AmTrustExample
{
    /// <summary>
    /// Interaction logic for MainWindow3.xaml
    /// </summary>
    public partial class MainWindow3
    {
        private readonly MainViewModel _vm;

        public MainWindow3()
        {
            _vm = new MainViewModel();
            DataContext = _vm;
            InitializeComponent();
        }

        public void ShowFileFlyout(object sender, RoutedEventArgs e)
        {
            ToggleFlyout(0);
        }

        private void ToggleFlyout(int index)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
        }

        private void CloseFlyout_Click(object sender, RoutedEventArgs e)
        {
            this.FileFlyout.IsOpen = false;
        }


        private void SetDefaultTheme(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resources = null;
            resources = (ResourceDictionary)Application.LoadComponent(new Uri("Skins/DefaultSkin2.xaml", UriKind.RelativeOrAbsolute));
            this.FileFlyout.IsOpen = false;

            this.Resources.MergedDictionaries.Clear();
            Application.Current.Resources = resources;

            // add custom accent and theme resource dictionaries
            ThemeManager.AddAccent("DefaultBlue", new Uri("Styles\\Accents\\Blue.xaml", UriKind.Relative));

            // get the theme from the current application
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now use the custom accent
            ThemeManager.ChangeAppStyle(Application.Current,
                                    ThemeManager.GetAccent("DefaultBlue"),
                                    theme.Item1);


        }

        private void GreenSkin_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resources = null;
            resources = (ResourceDictionary)Application.LoadComponent(new Uri("Skins/GreenSkin2.xaml", UriKind.RelativeOrAbsolute));
            this.FileFlyout.IsOpen = false;

            this.Resources.MergedDictionaries.Clear();
            Application.Current.Resources = resources;

            // add custom accent and theme resource dictionaries
            //ThemeManager.AddAccent("Emerald", new Uri(string.Format("pack://application:,,,/MahApps.Metro;component/Styles/Accents/Emerald.xaml")));

            ThemeManager.AddAccent("Emerald", new Uri(@"Styles\Accents\Emerald.xaml", UriKind.RelativeOrAbsolute));

            // get the theme from the current application
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now use the custom accent
            ThemeManager.ChangeAppStyle(Application.Current,
                                    ThemeManager.GetAccent("Emerald"),
                                    theme.Item1);
        }

        private void DarkSkin_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resources = null;
            resources = (ResourceDictionary)Application.LoadComponent(new Uri("Skins/DarkSkin2.xaml", UriKind.RelativeOrAbsolute));
            this.FileFlyout.IsOpen = false;

            this.Resources.MergedDictionaries.Clear();
            Application.Current.Resources = resources;

            // add custom accent and theme resource dictionaries
            ThemeManager.AddAccent("Dark", new Uri(@"Styles\Accents\Dark.xaml", UriKind.RelativeOrAbsolute));

            // get the theme from the current application
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now use the custom accent
            ThemeManager.ChangeAppStyle(Application.Current,
                                    ThemeManager.GetAccent("Dark"),
                                    theme.Item1);
        }

        private void GummiBearSkin_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resources = null;
            resources = (ResourceDictionary)Application.LoadComponent(new Uri("Skins/GummiBearSkin2.xaml", UriKind.RelativeOrAbsolute));
            this.FileFlyout.IsOpen = false;

            this.Resources.MergedDictionaries.Clear();
            Application.Current.Resources = resources;

            // add custom accent and theme resource dictionaries
            ThemeManager.AddAccent("GummiBear", new Uri(@"Styles\Accents\GummiBear.xaml", UriKind.RelativeOrAbsolute));

            // get the theme from the current application
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now use the custom accent
            ThemeManager.ChangeAppStyle(Application.Current,
                                    ThemeManager.GetAccent("GummiBear"),
                                    theme.Item1);
        }

        private void ApplyAccent(object sender, RoutedEventArgs e)
        {
            // add custom accent and theme resource dictionaries
            ThemeManager.AddAccent("DefaultBlue", new Uri("Styles\\Accents\\Blue.xaml", UriKind.Relative));

            // get the theme from the current application
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now use the custom accent
            ThemeManager.ChangeAppStyle(Application.Current,
                                    ThemeManager.GetAccent("DefaultBlue"),
                                    theme.Item1);
        }

    }
}
