using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Piechart.Models
{
    class Data:INotifyPropertyChanged
    {
		private double value;

		public double Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
				NotifyPropertyChanged();
			}
		}

		private string color;

		public string Color
		{
			get
			{
				return color;
			}
			set
			{
				color = value;
			}
		}


		public event PropertyChangedEventHandler? PropertyChanged;

		public void NotifyPropertyChanged([CallerMemberName] string propName="")
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        }
    }
}
