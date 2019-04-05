using System;
using System.Collections.Generic;
using System.Text;

namespace DatenSpeichernUndLaden
{
    public interface ITextFileHelper
    {
        void SaveIntoTextFile(string filename,string content);
        string LoadFromTextFile(string filename);
    }
}
