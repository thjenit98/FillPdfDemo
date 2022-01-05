using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FirstApp.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void BtnNavigation_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
    }
}
