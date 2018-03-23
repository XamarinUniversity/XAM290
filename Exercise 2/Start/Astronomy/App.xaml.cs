using Astronomy.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace Astronomy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AboutPage();
        }
    }
}