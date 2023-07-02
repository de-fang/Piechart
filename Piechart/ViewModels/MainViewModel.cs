using Piechart.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piechart.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<Data> Datas
        {
            get;
        }
       
        public MainViewModel()
        {
            Datas = new();
            Datas.Add(new Data
            {
                 Color="red",
                 Value=3344
            });

            Datas.Add(new Data
            {
                Color = "Blue",
                Value = 1344
            });

            Datas.Add(new Data
            {
                Color = "Green",
                Value = 2344
            });
            Update();
        }



        private async Task Update()
        {
           await Task.Run(async () =>
            {
                while (true)
                {
                    foreach (var item in Datas)
                    {
                        item.Value = Random.Shared.NextDouble() * 1000;
                    }
                   await Task.Delay(500);
                }
               
            });
           
        }
    }
}
