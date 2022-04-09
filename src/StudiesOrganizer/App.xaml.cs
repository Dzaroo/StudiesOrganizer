using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudiesOrganizer.Database;
using StudiesOrganizer.Models;
using StudiesOrganizer.Services.DataService;
using StudiesOrganizer.Services.NavigationService;
using StudiesOrganizer.ViewModels;
using StudiesOrganizer.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StudiesOrganizer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow window = ServiceProvider.GetRequiredService<MainWindow>();

            window.Show();

            base.OnStartup(e);
        }
        //void AppStartup(object sender, StartupEventArgs e)
        //{
        //    StudiesOrganizerDbContext dbContext = ServiceProvider.GetService<StudiesOrganizerDbContext>();
        //    dbContext.Database.EnsureCreated();

        //    MainWindow window = ServiceProvider.GetRequiredService<MainWindow>();

        //    window.Show();

        //}
        private void ConfigureServices(ServiceCollection services)
        {
            //Database
            services.AddDbContext<StudiesOrganizerDbContext>(options =>
            {
                options.UseSqlite("Data Source = StudiesOrganizer.db");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            //Services
            services.AddSingleton<IDataService<Student>, StudentDataService>();
            services.AddSingleton<IDataService<Subject>, SubjectDataService>();

            //ViewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<StudentsViewModel>();
            services.AddSingleton<SubjectsViewModel>();

            //Views
            services.AddTransient<MainWindow>();
            services.AddTransient<StudentsView>();
            services.AddTransient<SubjectsView>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
