using Emotion.Models;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Emotion.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private Face Face;

        private ImageSource thumbnail;
        public ImageSource Thumbnail
        {
            get { return thumbnail; }
            set { SetValue(ref thumbnail, value); }
        }

        public string Age => Face.FaceAttributes.Age.ToString();
        public string Gender => Face.FaceAttributes.Gender;
        public string Neutral => $"{Face.FaceAttributes.Emotion.Neutral * 100}%";
        public string Happiness => $"{Face.FaceAttributes.Emotion.Happiness * 100}%";
        public string Sadness => $"{Face.FaceAttributes.Emotion.Sadness * 100}%";
        public string Anger => $"{Face.FaceAttributes.Emotion.Anger * 100}%";
        public string Contempt => $"{Face.FaceAttributes.Emotion.Contempt * 100}%";
        public string Surprise => $"{Face.FaceAttributes.Emotion.Surprise * 100}%";
        public string Disgust => $"{Face.FaceAttributes.Emotion.Disgust * 100}%";

        public DetailViewModel(Face Face, MediaFile photo)
        {
            this.Face = Face;
            thumbnail = ImageSource.FromStream(() => photo.GetStream());
        }
    }
}
