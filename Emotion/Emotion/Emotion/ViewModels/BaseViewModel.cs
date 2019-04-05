using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Emotion.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string Property = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));

        protected void SetValue<T>(ref T field, T value, [CallerMemberName]string PropertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;
            field = value;
            OnPropertyChanged(PropertyName);
        }
    }
}
