using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GestureRecognizer
{
    public class TapModel : Product
    {
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { this.products = value; }
        }

        public TapModel() : base()
        {
            GenerateBookInfo();
        }

        internal void GenerateBookInfo()
        {
            products = new ObservableCollection<Product>();
            products.Add(new Product() { Number = 1, ProductName = "Object-Oriented Programming in C#" , ProductAmount = "200" });
            products.Add(new Product() { Number = 2, ProductName = "C# Code Contracts" , ProductAmount = "300" });
            products.Add(new Product() { Number = 3, ProductName = "Machine Learning Using C#" , ProductAmount = "300" });
        }
    }
}
