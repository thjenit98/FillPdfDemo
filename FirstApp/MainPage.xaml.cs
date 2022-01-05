using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfPdfViewer.XForms;
using Xamarin.Forms;

namespace FirstApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            pdfViewerControl.DocumentSaveInitiated += PdfViewerControl_DocumentSaved;
        }

        private void PdfViewerControl_DocumentSaved(object sender, DocumentSaveInitiatedEventArgs args)
        {
            var fileStream = args.SaveStream as MemoryStream;
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "filesample.pdf");
            File.WriteAllBytes(fileName, fileStream.ToArray());            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var fileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("FirstApp.Assets.PDF_Succinctly.pdf");           
            //var fileStream = await DownloadPdfStream("http://samples.leanpub.com/thereactnativebook-sample.pdf");
            if (fileStream != null)
            {
                //Load the PDF
                pdfViewerControl.LoadDocument(fileStream);              
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.PopModalAsync();
        }

        private async Task<Stream> DownloadPdfStream(string URL)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(URL);
            //Check whether redirection is needed
            if ((int)response.StatusCode == 302)
            {
                //The URL to redirect is in the header location of the response message
                HttpResponseMessage redirectedResponse = await httpClient.GetAsync(response.Headers.Location.AbsoluteUri);
                return await redirectedResponse.Content.ReadAsStreamAsync();
            }
            return await response.Content.ReadAsStreamAsync();
        }
    }
}
