using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System;
using System.Windows.Media.Imaging;


namespace AmTrustExample.UserControls
{
    public class RibbonButton : Button, ICloneable 
    {

        #region "Dependency Properties"
        public static readonly DependencyProperty IsInQuickAccessBarProperty = DependencyProperty.Register("IsInQuickAccessBar", typeof(bool?), typeof(RibbonButton));
        #endregion

        #region "Constructor"
        public RibbonButton()
        {
        }
        #endregion

        #region "Properties"
        public bool? IsInQuickAccessBar
        {
            get { return GetValue(IsInQuickAccessBarProperty) as bool?; }
            set { SetValue(IsInQuickAccessBarProperty, value); }
        }
        #endregion

        #region "Methods"
        public RibbonButton Clone() { return (RibbonButton)this.MemberwiseClone(); }
        object ICloneable.Clone() { return Clone(); }

        //public RibbonButton DeepCopy()
        //{
        //    RibbonButton other = (RibbonButton)this.MemberwiseClone();
        //    Image content = (Image) this.Content;
        //    content.Source
        //    other.Content = new Image() { Source = new sour}
        //}
        #endregion

    }
}
