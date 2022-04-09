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
    public class SubjectsViewModel : ViewModelBase
    {
        private readonly IDataService<Subject> _dataService;
        private ObservableCollection<Subject> _subjects;
        private ICommand _goToAddSubjectWindowCommand;
        private ICommand _goToAddStudentsToSubjectWindowCommand;
        private Subject _selectedSubject;

        public Subject SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }

        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        public ICommand GoToAddSubjectWindowCommand
        {
            get
            {
                if (_goToAddSubjectWindowCommand == null)
                {
                    _goToAddSubjectWindowCommand = new RelayCommand(
                        p => true,
                        p => GoToAddSubjectWindow());
                }
                return _goToAddSubjectWindowCommand;
            }
        }

        public ICommand GoToAddStudentsToSubjectWindowCommand
        {
            get
            {
                if (_goToAddStudentsToSubjectWindowCommand == null)
                {
                    _goToAddStudentsToSubjectWindowCommand = new RelayCommand(
                        p => true,
                        p => GoToAddStudentsToSubjectWindow());
                }
                return _goToAddStudentsToSubjectWindowCommand;
            }
        }

        public SubjectsViewModel(IDataService<Subject> dataService)
        {
            _dataService = dataService;
            GetSubjects();
        }
        private async void GetSubjects()
        {
            try
            {
                IEnumerable<Subject> subjects = await _dataService.GetAll();

                App.Current.Dispatcher.Invoke(() =>
                {
                    _subjects = new ObservableCollection<Subject>(subjects);
                });
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.GetBaseException().Message);
            }
        }

        private void GoToAddSubjectWindow()
        {
            AddSubjectView addSubjectDialog = new();
            addSubjectDialog.ShowDialog();
        }

        private void GoToAddStudentsToSubjectWindow()
        {
            if (_selectedSubject == null)
            {
                ShowErrorMessage("Wybierz przedmiot z listy");
                return;
            }

            AddStudentsToSubjectView addStudentsToSubjectDialog = new();
            addStudentsToSubjectDialog.ShowDialog();
        }
    }
}
