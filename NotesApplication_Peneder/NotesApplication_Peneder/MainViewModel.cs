using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace NotesApplication_Peneder
{


    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;

        public MainViewModel()
        {
            _navigationService = new NavigationService();
            _navigationService.Configure("NewNote", typeof(NewNotePage));
            _navigationService.Configure("ReadNote", typeof(ReadNotesPage));
            _navigationService.Configure("Settings", typeof(SettingPage));

            Time=DateTime.Now;
            SearchString = "";

            MaxNotes = 15;
            Notes = new ObservableCollection<Note> ();
            searchedNotes= new ObservableCollection<Note>();
            AddNoteCommand = new RelayCommand(AddNote);
            DispatcherTimer time = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            time.Tick += new EventHandler<object>(time_tick);
            time.Start();
        }

        private void time_tick(object sender, object e)
        {
            Time = DateTime.Now;
        }
        
        

        public DateTime Time { get; set; }
        public void AddNote()
        {
            Notes.Add(new Note(Text, DateTime.Now));
            Text = string.Empty;
        }

        public bool CanAddNote => !string.IsNullOrEmpty(Text);

        public int MaxNotes { get; set; }

        public ObservableCollection<Note> Notes { get; set; }

        public string SearchString { get; set; } 

        private ObservableCollection<Note> searchedNotes { get; set; }

        public ObservableCollection<Note> SearchNotes {
            get
            {
                searchedNotes.Clear();
                foreach (var note in Notes.Where(n=>n.Text.ToUpper().Contains( SearchString.ToUpper()) )
                    .OrderByDescending(n=>n.Date).Take(MaxNotes).ToList())
                {
                    searchedNotes.Add(note);
                }
                return searchedNotes;
            }
        }

        public RelayCommand AddNoteCommand { get; set; }

        public string Text { get; set; }
        public void NavigateToNewNotePage()
        {
            _navigationService.NavigateTo("NewNote");
        }

        public void NavigateToReadNotePage()
        {
            _navigationService.NavigateTo("ReadNote");
        }
        public void NavigateToSearchNotePage()
        {
            _navigationService.NavigateTo("Search");
        }
        public void NavigateToSettingsPage()
        {
            _navigationService.NavigateTo("Settings");
        }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}