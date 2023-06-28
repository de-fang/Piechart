using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Piechart
{
    public class PieBox : ListBox
    {
        private string? displayValuePath;
        private string? displayColorPath;

        public event EventHandler<double> OnTotalChanged;
        public double Total
        {
            get; set;
        }



        public Color? ShadowColor
        {
            get
            {
                return (Color?)GetValue(ShadowColorProperty);
            }
            set
            {
                SetValue(ShadowColorProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ShadowColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color?), typeof(PieBox), new PropertyMetadata(Color.FromRgb(00, 00, 00)));



        public string? DisplayValuePath
        {
            get
            {
                return displayValuePath;
            }
            set
            {
                displayValuePath = value;
                if (DisplayValuePath != null)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        PieItem item = (PieItem)ItemContainerGenerator.ContainerFromIndex(i);
                        if (item is null)
                            return;
                        item.SetBinding(PieItem.ValueProperty, DisplayValuePath);
                    }
                }
            }
        }
        public string? DisplayColorPath
        {
            get
            {
                return displayColorPath;
            }
            set
            {
                displayColorPath = value;
                if (DisplayValuePath != null)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        PieItem item = (PieItem)ItemContainerGenerator.ContainerFromIndex(i);
                        if (item is null)
                            return;
                        item.SetBinding(PieItem.BackgroundProperty, DisplayColorPath);
                    }
                }

            }
        }

        public PieBox()
        {
            this.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
        }

        private void ItemContainerGenerator_StatusChanged(object? sender, EventArgs e)
        {
            if (ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                DisplayValuePath = displayValuePath;
                DisplayColorPath = displayColorPath;
                Update();
            }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new PieItem();

        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is PieItem;
        }




        public void Update()
        {
            Total = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                PieItem item = (PieItem)ItemContainerGenerator.ContainerFromIndex(i);
                if (item is null)
                    return;
                Total += item.Value;
            }
            OnTotalChanged?.Invoke(this, Total);
            double totalAngle = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                PieItem item = (PieItem)ItemContainerGenerator.ContainerFromIndex(i);
                if (item is null)
                    return;


                item.SetCurrentValue(PieItem.RadianProperty, item.Value / Total * 360);

                //item.SetValue(PieItem.PercentagePropertyKey, item.Value / Total * 100);


                item.SetRadianStart(totalAngle);
                totalAngle += item.Radian;

            }
        }

        private Brush GetBrush(int index)
        {
            switch (index)
            {
                case 0:
                    return Brushes.Pink;
                case 1:
                    return Brushes.Magenta;
                case 2:
                    return Brushes.Yellow;
                case 3:
                    return Brushes.Orange;
                case 4:
                    return Brushes.Orchid;
                case 5:
                    return Brushes.Blue;
                case 6:
                    return Brushes.Red;
                case 7:
                    return Brushes.Wheat;
                case 8:
                    return Brushes.Plum;
                case 9:
                    return Brushes.Purple;
                case 10:
                    return Brushes.PaleGoldenrod;
                case 11:
                    return Brushes.MediumPurple;
                case 12:
                    return Brushes.LightGray;
                case 13:
                    return Brushes.Purple;
                case 14:
                    return Brushes.Purple;
                default:
                    return Brushes.Gray;

            }
        }
    }
}
