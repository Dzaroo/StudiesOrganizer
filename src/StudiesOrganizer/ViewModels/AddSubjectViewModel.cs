using StudiesOrganizer.Models;
using StudiesOrganizer.Services.DataService;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudiesOrganizer.ViewModels
{
    public class AddSubjectViewModel : ViewModelBase
    {
        private Subject _subject;
        private readonly IDataService<Subject> _dataService;
        private readonly SubjectsViewModel _subjectsViewModel;
        private ICommand _addSubjectCommand;
        public int DefaultIndex { get; } = -1;
        public short[] SemestersNumber { get; }
        public Subject Subject
        {
            get => _subject;
            set
            {
                _subject = value;
                OnPropertyChanged(nameof(Subject));
            }
        }

        public ICommand AddSubjectCommand
        {
            get
            {
                if (_addSubjectCommand == null)
                {
                    _addSubjectCommand = new RelayCommand(
                        p => true,
                        p => AddSubject(p));
                }
                return _addSubjectCommand;
            }
        }


        public AddSubjectViewModel(IDataService<Subject> dataService,
                                   SubjectsViewModel SubjectsViewModel)
        {
            _subject = new Subject();
            _dataService = dataService;
            _subjectsViewModel = SubjectsViewModel;
            SemestersNumber = new short[] {1, 2, 3, 4, 5, 6, 7, 8, 9 ,10};
        }

        private void AddSubject(object parameter)
        {
            try
            {
                Task.Run(async () =>
                {
                    await _dataService.Create(Subject);
                });

                _subjectsViewModel.Subjects.Add(Subject);

                Window window = (Window)parameter;

                window.Close();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.GetBaseException().Message);
            }
        }

    }
}
