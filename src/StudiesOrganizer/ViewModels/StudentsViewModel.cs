using StudiesOrganizer.Models;
using StudiesOrganizer.Services.DataService;
using StudiesOrganizer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudiesOrganizer.ViewModels
{
    public class StudentsViewModel : ViewModelBase
    {
        private readonly IDataService<Student> _dataService;
        private ObservableCollection<Student> _students;
        private ICommand _goToAddStudentWindowCommand;

        public ObservableCollection<Student> Students
        {
            get => _students;
            set 
            { 
                _students = value; 
                OnPropertyChanged(nameof(Students));
            }
        }

        public ICommand GoToAddStudentWindowCommand
        {
            get
            {
                if (_goToAddStudentWindowCommand == null)
                {
                    _goToAddStudentWindowCommand = new RelayCommand(
                        p => true,
                        p => GoToAddStudentWindow());
                }
                return _goToAddStudentWindowCommand;
            }
        }

        public StudentsViewModel(IDataService<Student> dataService)
        {
            _dataService = dataService;
            GetStudents();
        }

        private async void GetStudents()
        {
            try
            {
                IEnumerable<Student> students = await _dataService.GetAll();

                App.Current.Dispatcher.Invoke(() =>
                {
                    _students = new ObservableCollection<Student>(students);
                });
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.GetBaseException().Message);
            }
        }
        private void GoToAddStudentWindow()
        {
            AddStudentView addStudentDialog = new();
            addStudentDialog.ShowDialog();
        }
    }
}
