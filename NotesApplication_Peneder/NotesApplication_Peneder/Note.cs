using System;
using GalaSoft.MvvmLight;

namespace NotesApplication_Peneder
{
    public class Note : ObservableObject
    {
        public Note()
        {
        }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public Note(string text, DateTime date)
        {
            Date = date;
            Text = text;
        }

        public override string ToString()
        {
            return "[ " + Date + "]: " + Text;
        }
    }
}