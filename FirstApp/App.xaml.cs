using System;
using FirstApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTU4OTQxQDMxMzkyZTM0MmUzMGMrQXpEQ0w2aVJnMGlCZGc2RTcrdzVBbE94ek11WWpTWHdFRUw1eDcwclk9");            

            InitializeComponent();

            MainPage = new StartPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
