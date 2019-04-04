using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.QrCode;

namespace XamarinPlugins
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CrossMedia.Current.Initialize();
        }

        private async void ButtonFoto_Clicked(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsCameraAvailable)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "XamarinForms",
                    Name = DateTime.Now.Ticks + ".jpg",
                });

                if (file == null) // Klick auf "Abbrechen"
                    return;

                await DisplayAlert("Dateiort:", file.Path, "OK");

                // Bild im Image-Element anzeigen
                imageFoto.Source = ImageSource.FromStream(() =>
                {

                    try
                    {
                        return file.GetStream();
                    }
                    catch (Exception ex)
                    {

                    }
                    return null;
                });
            }
        }

        private async void ButtonQR_Clicked(object sender, EventArgs e)
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan();
            await DisplayAlert("QR-Inhalt", result.Text, "Ok danke byeee !");
        }

        private void ButtonGenerateQR_Clicked(object sender, EventArgs e)
        {
            var writer = new QRCodeWriter();
            var bm = writer.encode(entryQR.Text, ZXing.BarcodeFormat.QR_CODE, 150, 150);

            // Aus QR-Bitmatrix ein SVG-Bild machen, das in der Webview anzeigbar ist
            var svgwriter = new BarcodeWriterSvg();
            var img = svgwriter.Renderer.Render(bm, BarcodeFormat.QR_CODE, entryQR.Text);

            webViewQR.Source = new HtmlWebViewSource { Html = img.Content };
        }
    }
}
