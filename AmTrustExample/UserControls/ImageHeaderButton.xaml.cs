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

namespace AmTrustExample.UserControls
{
    /// <summary>
    /// Interaction logic for ImageHeaderButton.xaml
    /// </summary>
    public partial class ImageHeaderButton : UserControl
    {
        public ImageHeaderButton()
        {
            InitializeComponent();
            ImageHeaderButtonRoot.DataContext = this;
        }

        public ImageSource ButtonImage
        {
            get { return (ImageSource)GetValue(ButtonImageProperty); }
            set { SetValue(ButtonImageProperty, value); }
        }

        public static readonly DependencyProperty ButtonImageProperty =
            DependencyProperty.Register("ButtonImage", typeof(ImageSource), typeof(ImageHeaderButton), new UIPropertyMetadata(null));


        public string ButtonLabel
        {
            get { return (string)GetValue(ButtonLabelProperty); }
            set { SetValue(ButtonLabelProperty, value); }
        }

        public static readonly DependencyProperty ButtonLabelProperty =
            DependencyProperty.Register("ButtonLabel", typeof(string), typeof(ImageHeaderButton), new UIPropertyMetadata(null));

    }
}
