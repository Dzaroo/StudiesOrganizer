using System.Windows.Controls;

namespace StudiesOrganizer.Services.NavigationService
{
    public interface INavigationService
    {
        string CurrentPage { get; }
        void NavigateTo(string page);
        void NavigateTo(string page, object parameter);
        void GoBack();
        void SetAppFrame(Frame frame);
    }
}