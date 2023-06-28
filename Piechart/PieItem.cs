using Piechart.Helper;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace Piechart
{
    [TemplatePart(Name = "PART_Pie", Type = typeof(Pie))]
    public class PieItem : ListBoxItem
    {
        [NotNull]
        private Pie pie;

        private PieBox Parent=>VisualHelper.FindParent<PieBox>(this);

        private static DependencyPropertyKey PercentagePropertyKey = DependencyProperty.RegisterReadOnly("Percentage", typeof(double), typeof(PieItem), new PropertyMetadata(0d));

        public static DependencyProperty PercentageProperty = PercentagePropertyKey.DependencyProperty;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            pie = (Pie)Template.FindName("PART_Pie", this);
            Parent.OnTotalChanged += Parent_OnTotalChanged;
        }

        public PieItem()
        {
            Loaded += PieItem_Loaded;
            
        }

        private void Parent_OnTotalChanged(object? sender, double e)
        {
           this.SetValue(PercentagePropertyKey, Value/ e);
        }

        private void PieItem_Loaded(object sender, RoutedEventArgs e)
        {
            Parent?.Update();
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(PieItem), new PropertyMetadata(0d,UpdateView));

        private static void UpdateView(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is PieItem item)
            {
                item.Parent?.Update();
                
            }
        }

        public double Radian
        {
            get { return (double)GetValue(RadianProperty); }
            set { SetValue(RadianProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Radian.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadianProperty =
            DependencyProperty.Register("Radian", typeof(double), typeof(PieItem), new PropertyMetadata(0d));


        internal void SetRadianStart(double value)
        {
            if (pie != null)
            {
                pie.RadianStart = value;
             
            }
        }

       
    }
}
