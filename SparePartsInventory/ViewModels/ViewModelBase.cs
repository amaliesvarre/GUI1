using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SparePartsInventory.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? n = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(n);
            return true;
        }
    }
}