using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(DatenSpeichernUndLaden.Droid.AndroidTextFileHelper))]
namespace DatenSpeichernUndLaden.Droid
{
    public class AndroidTextFileHelper : ITextFileHelper
    {
        public string LoadFromTextFile(string filename)
        {
            // Varianten: Subfolder mit Android.OS.Environment
            // string folder = Android.OS.Environment.DataDirectory.AbsolutePath; // nur "/data"

            // Variante mit System.Environment
            // System.Environment.SpecialFolder.Personal // /data/data/com.companyname.MeineApp.files
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string fullPath = Path.Combine(folder, filename);
            return File.ReadAllText(fullPath);
        }

        public void SaveIntoTextFile(string filename, string content)
        {
            // Varianten:
            // string folder = Android.OS.Environment.DataDirectory.AbsolutePath; //

            // Variante mit System.Environment
            // System.Environment.SpecialFolder.Personal // /data/data/com.companyname.MeineApp.files
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string fullPath = Path.Combine(folder, filename);
            File.WriteAllText(fullPath, content);
        }
    }
}