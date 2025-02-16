using System;
using System.Collections.Generic;
using static System.Collections.IEnumerable;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RentARide.ViewModel;
using RentARide.Views;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RentARide.Models
{
    public class ReservationSearch : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TypeVehicule { get; set; }
        public string CategorieAuto { get; set; }
        public string StationId { get; set; }
        public Enum Options { get; set; }
        public string MemberId { get; set; }
        private bool _isChecked;
        public bool IsChecked
    {
            set { SetProperty(ref _isChecked, value); }
            get { return _isChecked; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
