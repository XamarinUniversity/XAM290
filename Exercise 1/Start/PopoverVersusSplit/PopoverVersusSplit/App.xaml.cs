using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

//
// XAM206 - Exercise 1
//   1. Uncomment one of the lines assigning a value to MasterBehavior
//   2. Run the app on a tablet or desktop form factor
//   3. If you can, switch between Portrait and Landscape
//   4. Repeat for as many of the MasterBehavior values as you would like to

namespace PopoverVersusSplit
{
    public partial class App : Application
    {
        MasterDetailPage masterDetailPage;

        public App()
        {
            InitializeComponent();

            masterDetailPage = new MasterDetailPage();

            //
            // Set up Master
            //
            var colors = new string[] { "Yellow", "SpringGreen", "Cyan" };

            var panel = new StackLayout();

            foreach (var color in colors)
            {
                var button = new Button() { Text = color };
                button.Clicked += (s, e) => LoadDetailPage(color);
                panel.Children.Add(button);
            }

            masterDetailPage.Master = new ContentPage() { Content = panel, Title = "Popover vs Split" };

            //
            // Initialize Detail
            //
            LoadDetailPage(colors[0]);

            //masterDetailPage.MasterBehavior = MasterBehavior.Default;
            //masterDetailPage.MasterBehavior = MasterBehavior.Popover;
            masterDetailPage.MasterBehavior = MasterBehavior.Split;
            //masterDetailPage.MasterBehavior = MasterBehavior.SplitOnLandscape;
            //masterDetailPage.MasterBehavior = MasterBehavior.SplitOnPortrait;

            masterDetailPage.Master.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            MainPage = masterDetailPage;
        }

        void LoadDetailPage(string message)
        {
            var colorConverter = new ColorTypeConverter();


            var page = new ContentPage()
            {
                Content = new StackLayout()
                {
                    Children = {
                        new Label()
                        {
                            Text = message,
                            FontAttributes = FontAttributes.Bold,
                        },
                    },
                },
                BackgroundColor = (Color)colorConverter.ConvertFromInvariantString(message),
            };
            page.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            masterDetailPage.Detail = new Xamarin.Forms.NavigationPage(page);

            if (masterDetailPage.CanChangeIsPresented)
                masterDetailPage.IsPresented = false;
        }
    }
}