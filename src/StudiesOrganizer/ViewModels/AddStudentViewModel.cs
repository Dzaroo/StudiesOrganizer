using StudiesOrganizer.Models;
using StudiesOrganizer.Services.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudiesOrganizer.ViewModels
{
    public class AddStudentViewModel : ViewModelBase
    {
        private Student _student;
        private readonly IDataService<Student> _dataService;
        private readonly StudentsViewModel _studentsViewModel;
        private ICommand _addStudentCommand;

        public Student Student
        {
            get => _student;
            set
            {
                _student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        public ICommand AddStudentCommand
        {
            get
            {
                if (_addStudentCommand == null)
                {
                    _addStudentCommand = new RelayCommand(
                        p => true,
                        p => AddStudent(p));
                }
                return _addStudentCommand;
            }
        }


        public AddStudentViewModel(IDataService<Student> dataService,
                                   StudentsViewModel studentsViewModel)
        {
            _student = new Student()
            {
                BirthDate = new DateTime(2000,1,1)
            };
            _dataService = dataService;
            _studentsViewModel = studentsViewModel;
        }

        private void AddStudent(object parameter)
        {
            try
            {
                Task.Run(async () =>
                {
                    await _dataService.Create(Student);
                });

                _studentsViewModel.Students.Add(Student);

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
