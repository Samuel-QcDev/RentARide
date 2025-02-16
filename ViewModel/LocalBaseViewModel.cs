using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace RentARide.Resources.ViewModel
{
    public class LocalBaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LocalBaseViewModel()
        {

        }

        public virtual void OnAppearing()
        {

        }
        public virtual void OnDisappearing()
        {

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var changes = PropertyChanged;
            if (changes == null)
            {
                return;
            }

            changes.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingstore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingstore, value))
                return false;

            backingstore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
