using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Piechart
{
    public class PieBox : ListBox
    {
        private string? displayValuePath;
        private string? displayColorPath;

        private double Total { get; set; }

       

        public string? DisplayValuePath
        {
            get { return displayValuePath; }
            set
            {
                displayValuePath = value;
                if (DisplayValuePath != null)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        PieItem item = (PieItem)ItemContainerGenerator.ContainerFromIndex(i);
                        if (item is null) return;
                        item.SetBinding(PieItem.ValueProperty, DisplayValuePath);
                    }
                }
            }
        }
        public string? DisplayColorPath
        {
            get { return displayColorPath; }
            set { displayColorPath = value;
                if (DisplayValuePath != null)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        PieItem item = (PieItem)ItemContainerGenerator.ContainerFromIndex(i);
                        if (item is null) return;
                        item.SetBinding(PieItem.BackgroundProperty, DisplayColorPath);
                    }
                }
              
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

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            DisplayValuePath = displayValuePath;
            DisplayColorPath = displayColorPath;
            Update();
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
            double totalAngle = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                PieItem item = (PieItem)ItemContainerGenerator.ContainerFromIndex(i);
                if (item is null)
                    return;


                item.SetCurrentValue(PieItem.RadianProperty, item.Value / Total * 360);




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
