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
using AmTrustExample.Extensions;
using System.Data;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls.Dialogs;

namespace AmTrustExample.Views
{
    /// <summary>
    /// Interaction logic for MainWindow3.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainViewModel _vm;
        private int _currentSubFlyoutOpen;

        public MainWindow()
        {
            _vm = new MainViewModel();
            DataContext = _vm;
            InitializeComponent();
            this.Resources.Clear();
        }

        #region "Flyout Handling"
        //TODO: If a person clicks fast enough when switching from the Accents flyout to another one, they can accidently click
        //one and change their window's accent during the withdraw animation. Not a big issue, just a little annoying.

        private void ToggleFlyout(int index)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
        }

        /// <summary>
        /// only closes the last flyout that was opening when opening another
        /// </summary>
        private void ClosePreviousFlyout()
        {
            if (_currentSubFlyoutOpen > 0)
            {
                var flyout = (Flyout)Flyouts.Items[_currentSubFlyoutOpen];
                flyout.IsOpen = false;
            }
        }

        /// <summary>
        /// one click to open a flyout, 2nd click on the same one to close
        /// </summary>
        /// <param name="flyoutIndex"></param>
        private void CloseCurrentFlyout(int flyoutIndex)
        {
            Flyout flyout = (Flyout)Flyouts.Items[flyoutIndex];
            flyout.IsOpen = false;
        }

        /// <summary>
        /// determines how to handle the opening of a subFlyout
        /// </summary>
        /// <param name="flyoutIndex"></param>
        private void OpenFlyout(int flyoutIndex)
        {
            if (IsFlyoutOpen(flyoutIndex))
            {
                CloseCurrentFlyout(flyoutIndex);
            }
            else
            {
                ClosePreviousFlyout();
                _currentSubFlyoutOpen = flyoutIndex;
                ToggleFlyout(flyoutIndex);
            }
        }

        /// <summary>
        /// Checks to see if a flyout is already open instead of closing and reopening it
        /// </summary>
        /// <param name="flyoutIndex">The Flyout's index</param>
        /// <returns></returns>
        private bool IsFlyoutOpen(int flyoutIndex)
        {
            Flyout flyout = (Flyout)Flyouts.Items[flyoutIndex];
            return flyout.IsOpen;
        }

        public void ShowFileFlyout(object sender, RoutedEventArgs e)
        {
            ToggleFlyout(0);
        }

        private void CloseFlyout_Click(object sender, RoutedEventArgs e)
        {
            ClosePreviousFlyout();
            this.FileFlyout.IsOpen = false;
        }

        private void OpenEmailFlyout(object sender, MouseButtonEventArgs e)
        {
            OpenFlyout(1);
        }

        private void CloseEmailFlyout_Click(object sender, RoutedEventArgs e)
        {
            this.EmailFlyout.IsOpen = false;
        }

        private void OpenReferenceLinksFlyout(object sender, MouseButtonEventArgs e)
        {
            OpenFlyout(2);
        }

        private void CloseReferenceLinksFlyout_Click(object sender, RoutedEventArgs e)
        {
            this.ReferenceLinksFlyout.IsOpen = false;
        }

        private void OpenAdminToolsFlyout(object sender, MouseButtonEventArgs e)
        {
            OpenFlyout(3);
        }

        private void CloseAdminToolsFlyout_Click(object sender, RoutedEventArgs e)
        {
            this.AdminToolsFlyout.IsOpen = false;
        }

        private void OpenRecentActivityFlyout(object sender, MouseButtonEventArgs e)
        {
            OpenFlyout(4);
        }

        private void CloseRecentActivityFlyout_Click(object sender, RoutedEventArgs e)
        {
            this.RecentActivityFlyout.IsOpen = false;
        }

        private void OpenAccentFlyout(object sender, MouseButtonEventArgs e)
        {
            OpenFlyout(5);
        }

        private void CloseAccentFlyout_Click(object sender, RoutedEventArgs e)
        {
            this.AccentFlyout.IsOpen = false;
        }

        private void OpenThemeFlyout(object sender, MouseButtonEventArgs e)
        {
            OpenFlyout(6);
        }

        private void CloseThemeFlyout_Click(object sender, RoutedEventArgs e)
        {
            this.ThemeFlyout.IsOpen = false;
        }

        private void OpenAboutFlyout(object sender, MouseButtonEventArgs e)
        {
            OpenFlyout(7);
        }

        private void CloseAboutFlyout_Click(object sender, RoutedEventArgs e)
        {
            this.AboutFlyout.IsOpen = false;
        }
        #endregion

        #region "Ribbon Handling"
        private void Ribbon_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Only want it to expand/collapse when clicking on a Header in the tabcontrol
            if (e.OriginalSource.GetType() == typeof(Border) ||
                e.OriginalSource.GetType() == typeof(TextBlock))
            {
                if (this.homeContent.Visibility == System.Windows.Visibility.Visible)
                {
                    this.homeContent.Visibility = System.Windows.Visibility.Collapsed;
                    this.underwritingContent.Visibility = System.Windows.Visibility.Collapsed;
                    this.auditContent.Visibility = System.Windows.Visibility.Collapsed;
                    this.processingContent.Visibility = System.Windows.Visibility.Collapsed;
                    this.RibbonTabControl.Margin = new Thickness(0, 0, 0, -6);
                }
                else
                {
                    this.homeContent.Visibility = System.Windows.Visibility.Visible;
                    this.underwritingContent.Visibility = System.Windows.Visibility.Visible;
                    this.auditContent.Visibility = System.Windows.Visibility.Visible;
                    this.processingContent.Visibility = System.Windows.Visibility.Visible;
                    this.RibbonTabControl.Margin = new Thickness(0);
                }
            }
        }
        #endregion

        #region "DataGrid Handling"
        /// <summary>
        /// Will fill in the tooltip for a row
        /// Will only work when the GridView is populated by a DataTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult hitTestResult =
            VisualTreeHelper.HitTest(this.MainDataGrid, e.GetPosition(this.MainDataGrid));
            if (hitTestResult == null) return;
            DataGridRow dataGridRow = hitTestResult.VisualHit.GetParentOfType<DataGridRow>();

            if (dataGridRow != null && dataGridRow.Item != null)
            {
                var rowItem = dataGridRow.Item;
                var stackPanel = new StackPanel();

                if (rowItem.GetType() == typeof(DataRowView))
                {
                    var dataRowViewItem = (DataRowView)rowItem;
                    for (int i = 0; i < dataRowViewItem.Row.ItemArray.Count(); i++)
                    {
                        var innerStackPanel = new StackPanel();
                        innerStackPanel.Orientation = Orientation.Horizontal;
                        if (i % 2 == 0)
                        {
                            innerStackPanel.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#55808080"));
                        }

                        var columnName = new TextBlock();
                        columnName.Text = string.Format("{0}: ", dataRowViewItem.DataView.Table.Columns[i].ToString());
                        columnName.Margin = new Thickness(0, 0, 5, 0);

                        var value = new TextBlock();
                        value.Text = dataRowViewItem.Row.ItemArray[i].ToString();
                        value.FontWeight = FontWeights.Bold;

                        innerStackPanel.Children.Add(columnName);
                        innerStackPanel.Children.Add(value);

                        stackPanel.Children.Add(innerStackPanel);
                    }
                }
                dataGridRow.ToolTip = stackPanel;
            }
        }
        #endregion

        private void CollapseExpandTreeView_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
