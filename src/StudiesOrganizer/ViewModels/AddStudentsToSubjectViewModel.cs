using StudiesOrganizer.Models;
using StudiesOrganizer.Services.DataService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace StudiesOrganizer.ViewModels
{
    public class AddStudentsToSubjectViewModel : ViewModelBase
    {
        private ObservableCollection<Student> _students;
        private readonly IDataService<Student> _studentDataService;
        private readonly IDataService<Subject> _subjectDataService;
        private readonly SubjectsViewModel _subjectsViewModel;
        private ICommand _singStudentsCommand;

        public ObservableCollection<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        public ICommand SingStudentsCommand
        {
            get
            {
                if (_singStudentsCommand == null)
                {
                    _singStudentsCommand = new RelayCommand(
                        p => true,
                        p => SingStudentsToSubject(p));
                }
                return _singStudentsCommand;
            }
        }

        public AddStudentsToSubjectViewModel(IDataService<Student> studentDataService,
                                             IDataService<Subject> subjectDataService,
                                             SubjectsViewModel subjectsViewModel)
        {
            _studentDataService = studentDataService;
            _subjectDataService = subjectDataService;
            _subjectsViewModel = subjectsViewModel;
            GetStudents();
        }

        private async void GetStudents()
        {
            try
            {
                IEnumerable<Student> students = await _studentDataService.GetAll();

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

        private async void SingStudentsToSubject(object p)
        {
            try
            {
                if (p == null)
                    throw new Exception("Musisz wybrać munimum jednego studenta");

                System.Collections.IList selectedStudents = (System.Collections.IList)p;

                List<StudentSubject> studentsToUpdate = new List<StudentSubject>();

                foreach (object student in selectedStudents)
                {
                    Student st = (Student)student;

                    if(st.StudentSubjects != null)
                    {
                        if (st.StudentSubjects.Any(ss => ss.SubjectId == _subjectsViewModel.SelectedSubject.Id))
                            throw new Exception($"Student {st.FullName} jest już przypisany do tego przedmiotu");
                    }

                    StudentSubject studentSubject = new()
                    {
                        Student = st,
                        Subject = _subjectsViewModel.SelectedSubject,
                    };

                    studentsToUpdate.Add(studentSubject);
                }

                _subjectsViewModel.SelectedSubject.StudentSubjects = studentsToUpdate;

                await _subjectDataService.Update(_subjectsViewModel.SelectedSubject);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.GetBaseException().Message);
            }
        }
    }
}
