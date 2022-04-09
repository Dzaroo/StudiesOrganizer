using System.ComponentModel;
using System.Windows;

namespace StudiesOrganizer.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private object _selectedViewModel;

        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
