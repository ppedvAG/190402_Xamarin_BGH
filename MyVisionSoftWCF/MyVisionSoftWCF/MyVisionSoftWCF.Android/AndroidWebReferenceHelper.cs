using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(MyVisionSoftWCF.Droid.AndroidWebReferenceHelper))]
namespace MyVisionSoftWCF.Droid
{
    public class AndroidWebReferenceHelper : IWebReferenceHelper
    {
        public object GetTestDataSet()
        {
            var service = new MyVisionSoft.Logic.WebReference.Service();
            var dataSet = service.TestFileList();
            return dataSet;
        }
    }
}