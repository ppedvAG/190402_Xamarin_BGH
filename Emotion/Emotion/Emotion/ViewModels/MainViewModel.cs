using Emotion.Models;
using Emotion.Models.Interfaces;
using Emotion.Views;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;

namespace Emotion.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private const string api_key = "9cab504f4b1e41788109ac8b036947e2";
        private readonly IPageService pageService;
        private ImageSource thumbnail;
        public ImageSource Thumbnail
        {
            get { return thumbnail; }
            set { SetValue(ref thumbnail, value); }
        }

        private bool computingImage;

        public bool ComputingImage
        {
            get { return computingImage; }
            set { SetValue(ref computingImage, value); }
        }


        private MediaFile photo;


        private Command buttonTakeImageClicked;
        public Command ButtonTakeImageClickedCommand
        {
            get
            {
                buttonTakeImageClicked = buttonTakeImageClicked ?? new Command(async () =>
                {
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await pageService.DisplayAlert("Fehler", "Es ist leider keine Kamera verfügbar", "OK");
                        return;
                    }

                    photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        Name = $"{DateTime.Now.ToString()}.jpg"
                    });

                    if (photo == null)
                        return;
                    else
                    {
                        Thumbnail = ImageSource.FromStream(() => photo.GetStream());
                    }
                });
                return buttonTakeImageClicked;
            }
        }

        private Command buttonImageFromGalleryClickedCommand;
        public Command ButtonImageFromGalleryClickedCommand
        {
            get
            {
                buttonImageFromGalleryClickedCommand = buttonImageFromGalleryClickedCommand ?? new Command(async () =>
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await pageService.DisplayAlert("No upload", "No Gallery", "Ok");
                        return;
                    }

                    photo = await CrossMedia.Current.PickPhotoAsync();

                    if (photo == null)
                        return;
                    else
                    {
                        Thumbnail = ImageSource.FromStream(() => photo.GetStream());
                    }
                });
                return buttonImageFromGalleryClickedCommand;
            }
        }

        private Command buttonScanClickedCommand;
        public Command ButtonScanClickedCommand
        {
            get
            {
                buttonScanClickedCommand = buttonScanClickedCommand ?? new Command(async () =>
                {
                    ComputingImage = true;
                    var client = new HttpClient();
                    // Request headers - replace this example key with your valid subscription key.
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", api_key);

                    // Request parameters. A third optional parameter is "details".
                    string requestParameters = "returnFaceAttributes=age,gender,emotion";
                    string uri = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/detect?" + requestParameters;

                    HttpResponseMessage response;

                    // Request body. Try this sample with a locally stored JPEG image.
                    byte[] byteData = DependencyService.Get<IFileHelper>().GetImageAsByteArray(photo.Path);
                    string responseContent;
                    using (var content = new ByteArrayContent(byteData))
                    {
                        // This example uses content type "application/octet-stream".
                        // The other content types you can use are "application/json" and "multipart/form-data".
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                        response = await client.PostAsync(uri, content);
                        responseContent = response.Content.ReadAsStringAsync().Result;
                    }
                    if (responseContent.Contains("\"statusCode\": 401"))
                    {
                        await pageService.DisplayAlert("Fehler", $"Der API-Key, der im MainPageViewModel verwendet wird, ist ungültig.{Environment.NewLine}Bitte ersetzen Sie den API-Key in der Datei: MainPageViewModel.cs", "OK");
                        ComputingImage = false;
                        return;
                    }
                    Face f = JsonConvert.DeserializeObject<Face[]>(responseContent)[0];
                    ComputingImage = false;
                    await pageService.PushModalAsync(new DetailPage(new DetailViewModel(f, photo)));
                });
                return buttonScanClickedCommand;
            }
        }
        public MainViewModel(IPageService pageservice)
        {
            this.pageService = pageservice;
            Thumbnail = ImageSource.FromResource("Emotion.Images.thumb.png");
            ComputingImage = false;
        }
    }
}
