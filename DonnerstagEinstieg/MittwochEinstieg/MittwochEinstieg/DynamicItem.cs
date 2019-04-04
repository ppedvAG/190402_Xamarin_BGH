using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace MittwochEinstieg
{
    class DynamicItem : INotifyPropertyChanged
    {
        public DynamicItem(string text,string data) // duration -> "Simulation" wie lange es laden soll ...
        {
            Text = text;
            Data = data;
            IsLoading = true;
            Loaded = false;
            Progress = 0;

            r = new Random();

            Task.Run(async () =>
            {
                while(this.Progress < 1.0)
                {
                    if (r.Next(0, 10) < 5)
                        this.Progress += 0.1;

                    await Task.Delay(500);
                }
                IsLoading = false;
                Loaded = true;
            });
        }

        private Random r;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        private bool loaded;

        public bool Loaded
        {
            get => loaded;
            set
            {
                loaded = value;
                OnPropertyChanged(nameof(Loaded));
            }
        }
        public string Text { get; set; }
        public string Data { get; set; }

        private double progress;
        public double Progress
        {
            get => progress;
            set
            {
                progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        } // 0 bis 1
    }
}
