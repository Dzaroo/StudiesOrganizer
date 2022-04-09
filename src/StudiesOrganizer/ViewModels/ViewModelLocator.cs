using Microsoft.Extensions.DependencyInjection;
using StudiesOrganizer.Models;
using StudiesOrganizer.Services.DataService;

namespace StudiesOrganizer.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel
            => App.ServiceProvider.GetService<MainWindowViewModel>();

        public StudentsViewModel StudentsViewModel
            => App.ServiceProvider.GetService<StudentsViewModel>();

        public SubjectsViewModel SubjectsViewModel
            => App.ServiceProvider.GetService<SubjectsViewModel>();

        public AddStudentViewModel AddStudentViewModel
            => new AddStudentViewModel(App.ServiceProvider.GetService<IDataService<Student>>(),
                                       App.ServiceProvider.GetService<StudentsViewModel>());
        public AddSubjectViewModel AddSubjectViewModel
            => new AddSubjectViewModel(App.ServiceProvider.GetService<IDataService<Subject>>(),
                                       App.ServiceProvider.GetService<SubjectsViewModel>());

        public AddStudentsToSubjectViewModel AddStudentsToSubjectViewModel
            => new AddStudentsToSubjectViewModel(App.ServiceProvider.GetService<IDataService<Student>>(),
                                                 App.ServiceProvider.GetService<IDataService<Subject>>(),
                                                 App.ServiceProvider.GetService<SubjectsViewModel>());
    }
}
