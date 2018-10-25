using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace LocationWFPApp.Behaviors
{
    class Slider : Behavior<DependencyObject>
    {

        public double Height { get; set; }


        public ListBox listBox
        {
            get { return (ListBox)GetValue(listBoxProperty); }
            set { SetValue(listBoxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for listBox.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty listBoxProperty =
            DependencyProperty.Register("listBox", typeof(ListBox), typeof(Slider), new PropertyMetadata(null));
        
        public Slider()
        {

        }

        protected override void OnAttached()
        {
            base.OnAttached();

            Border border = (Border)AssociatedObject;
            border.Loaded += Border_Loaded;
            border.MouseEnter += Border_MouseEnter;
            border.MouseLeave += Border_MouseLeave;
        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (listBox.Items.Count == 0)
            {
                return;
            }
            DoubleAnimation animation = new DoubleAnimation(this.Height, 0, new Duration(TimeSpan.FromSeconds(0.2f)));
            listBox.BeginAnimation(ListBox.MaxHeightProperty, animation);
        }

        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            listBox.Visibility = Visibility.Visible;
            listBox.UpdateLayout();

            DoubleAnimation animation = new DoubleAnimation(0, this.Height, new Duration(TimeSpan.FromSeconds(0.2f)));
            listBox.BeginAnimation(ListBox.MaxHeightProperty, animation);
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            listBox.Visibility = Visibility.Visible;
            listBox.UpdateLayout();
            this.Height = listBox.ActualHeight;
            listBox.Visibility = Visibility.Collapsed;
        }
    }
}
