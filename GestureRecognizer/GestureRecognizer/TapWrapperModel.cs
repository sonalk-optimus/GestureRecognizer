using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GestureRecognizer
{
    public class TapWrapperModel :INotifyPropertyChanged
    {
        public Command ClickCommand { get; set; }
        public Command DoubleTapCommand { get; set; }
        public TapWrapperModel(TapViewModel tapViewModel)
        {
            ClickCommand = tapViewModel.TapCommand;
            DoubleTapCommand = tapViewModel.TapDoubleTapCommand;
           
        }
        private Color _backgroundColor = Color.Default;
        public Color BackgroundColor
        {
            get
            {
                if (_backgroundColor.IsDefault)
                    _backgroundColor = Color.Blue;

                return _backgroundColor;
            }

            private set
            {
                _backgroundColor = value;
                OnPropertyChanged();
            }
        }

        private bool _isSelected;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;

                BackgroundColor = Color.Blue;

                OnPropertyChanged();
            }
        }
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }
}
