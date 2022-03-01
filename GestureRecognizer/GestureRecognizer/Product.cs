using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GestureRecognizer
{
    public class Product : INotifyPropertyChanged
    {
        private int number;
        private string productName;
        private string productAmount;

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
            }
        }

        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
            }
        }

        public string ProductAmount
        {
            get { return productAmount; }
            set
            {
                productAmount = value;
            }
        }


        private bool _isSelected;
        public virtual bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
