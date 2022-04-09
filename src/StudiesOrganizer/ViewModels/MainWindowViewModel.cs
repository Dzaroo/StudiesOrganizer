using System.Windows.Input;

namespace StudiesOrganizer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly StudentsViewModel _studentsViewModel;
        private readonly SubjectsViewModel _subjectsViewModel;
        private ICommand _goToStudents;
        private ICommand _goToSubjects;

        public ICommand GoToStudents
        {
            get
            {
                if (_goToStudents == null)
                {
                    _goToStudents = new RelayCommand(
                        p => true,
                        p => SetStudentsViewModel());
                }
                return _goToStudents;
            }
        }

        public ICommand GoToSubjects
        {
            get
            {
                if (_goToSubjects == null)
                {
                    _goToSubjects = new RelayCommand(
                        p => true,
                        p => SetSubjectsViewModel());
                }
                return _goToSubjects;
            }
        }

        public MainWindowViewModel(StudentsViewModel studentsViewModel,
                                   SubjectsViewModel subjectsViewModel)
        {
            _studentsViewModel = studentsViewModel;
            _subjectsViewModel = subjectsViewModel;
        }

        private void SetStudentsViewModel()
        {
            SelectedViewModel = _studentsViewModel;
        }

        private void SetSubjectsViewModel()
        {
            SelectedViewModel = _subjectsViewModel;
        }
    }
}
