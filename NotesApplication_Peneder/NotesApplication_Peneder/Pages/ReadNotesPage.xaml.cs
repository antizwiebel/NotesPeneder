using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesApplication_Peneder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReadNotesPage : Page
    {
        public ReadNotesPage()
        {
            this.InitializeComponent();
        }


        public MainViewModel ViewModel => DataContext as MainViewModel;

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateBack();
        }
    }
}
