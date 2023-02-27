using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TYControls
{
    public class ControlAttache : DependencyObject
    {
        public static object GetOnContent(DependencyObject obj)
        {
            return (object)obj.GetValue(OnContentProperty);
        }

        public static void SetOnContent(DependencyObject obj, object value)
        {
            obj.SetValue(OnContentProperty, value);
        }

        public static readonly DependencyProperty OnContentProperty =
           DependencyProperty.RegisterAttached("OnContent", typeof(object), typeof(ControlAttache), new PropertyMetadata(null));




        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ControlAttache), new PropertyMetadata(new CornerRadius(0d)));





        public static Brush GetMouseOverBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseOverBackgroundProperty);
        }

        public static void SetMouseOverBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseOverBackgroundProperty, value);
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.RegisterAttached("MouseOverBackground", typeof(Brush), typeof(ControlAttache), new PropertyMetadata(SystemColors.ControlLightBrush));





        public static object GetDesignDataContext(DependencyObject obj)
        {
            return (object)obj.GetValue(DesignDataContextProperty);
        }

        public static void SetDesignDataContext(DependencyObject obj, object value)
        {
            obj.SetValue(DesignDataContextProperty, value);
        }

        // Using a DependencyProperty as the backing store for DesignDataContext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DesignDataContextProperty =
            DependencyProperty.RegisterAttached("DesignDataContext", typeof(object), typeof(ControlAttache), new PropertyMetadata(null, OnDesignDataContextChange));

        private static void OnDesignDataContextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Page page)
            {
                if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(page))
                {
                    page.DataContext = e.NewValue;
                }
            }
            else if (d is Control control)
            {
                if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(control))
                {
                    control.DataContext = e.NewValue;
                }
            }
        }

        public static Brush GetDesignBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(DesignBackgroundProperty);
        }

        public static void SetDesignBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(DesignBackgroundProperty, value);
        }

        // Using a DependencyProperty as the backing store for DesignBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DesignBackgroundProperty =
            DependencyProperty.RegisterAttached("DesignBackground", typeof(Brush), typeof(ControlAttache), new PropertyMetadata(Brushes.Transparent, OnDesignBackgroundChange));

        private static void OnDesignBackgroundChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is Brush brush)
            {
                if (d is Page page)
                {
                    if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(page))
                    {
                        page.Background = brush;
                    }
                }
                else if (d is Control control)
                {
                    if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(control))
                    {
                        control.Background = brush;
                    }
                }
            }

        }
    }
}
