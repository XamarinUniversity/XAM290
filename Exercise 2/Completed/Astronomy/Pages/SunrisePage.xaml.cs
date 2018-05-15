using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Astronomy.Pages
{
    public partial class SunrisePage : ContentPage
    {
        public SunrisePage ()
        {
            InitializeComponent ();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await InitializeUI();
        }

        async Task InitializeUI ()
        {
            var latLongData = await new LatLongService().GetLatLong();
            var sunData = await new SunriseService().GetSunriseSunsetTimes(latLongData.Latitude, latLongData.Longitude);

            var riseTime = sunData.Sunrise.ToLocalTime();
            var setTime = sunData.Sunset.ToLocalTime();

            var span = setTime.TimeOfDay - riseTime.TimeOfDay;

            lblDate.Text = DateTime.Today.ToString("D");
            lblSunrise.Text = riseTime.ToString("h:mm tt");
            lblDaylight.Text = $"{span.Hours} hours, {span.Minutes} minutes";
            lblSunset.Text = setTime.ToString("h:mm tt");
        }
    }
}