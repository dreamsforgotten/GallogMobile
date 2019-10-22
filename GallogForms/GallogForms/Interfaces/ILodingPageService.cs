using Xamarin.Forms;

namespace GallogForms.Interfaces
{
    public interface ILodingPageService    {
        void InitLoadingPage
                  (ContentPage loadingIndicatorPage = null);

        void ShowLoadingPage();

        void HideLoadingPage();
    }
}
