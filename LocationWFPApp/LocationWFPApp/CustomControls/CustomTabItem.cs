using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LocationWFPApp.CustomControls
{
    class CustomTabItem : TabItem
    {

        public CustomTabItem()
        {
            SetValue(CustomTabItem.listBoxItemsProperty, new List<ListBoxItem>());
        }
        
        public Geometry IconData
        {
            get { return (Geometry)GetValue(IconDataProperty); }
            set { SetValue(IconDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconDataProperty =
            DependencyProperty.Register("IconData", typeof(Geometry), typeof(CustomTabItem), new PropertyMetadata(null));

        

        public string Count
        {
            get { return (string)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Count.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register("Count", typeof(string), typeof(CustomTabItem), new PropertyMetadata(""));



        public Brush BrushBackground
        {
            get { return (Brush)GetValue(BrushBackgroundProperty); }
            set { SetValue(BrushBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BrushBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BrushBackgroundProperty =
            DependencyProperty.Register("BrushBackground", typeof(Brush), typeof(CustomTabItem), new PropertyMetadata(null));




        public List<ListBoxItem> listBoxItems
        {
            get { return (List<ListBoxItem>)GetValue(listBoxItemsProperty); }
            set { SetValue(listBoxItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for listBoxItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty listBoxItemsProperty =
            DependencyProperty.Register("listBoxItems", typeof(List<ListBoxItem>), typeof(CustomTabItem), new PropertyMetadata(new List<ListBoxItem>()));


    }
}
