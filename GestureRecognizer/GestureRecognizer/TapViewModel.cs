using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GestureRecognizer
{
    public class TapViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Command TapCommand { protected set; get; }

        public Command TapDoubleTapCommand { protected set; get; }
        public TapViewModel()
        {
            TapCommand = new Command<object>(OnTapped);
            TapDoubleTapCommand = new Command(OnDoubleTapped);
        }

        public void OnTapped(object obj)
        {
            (obj as Product).IsSelected = true;
            App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
        }

        public void OnDoubleTapped()
        {
            App.Current.MainPage.Navigation.PushAsync(new WelcomePage());
        }

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

}