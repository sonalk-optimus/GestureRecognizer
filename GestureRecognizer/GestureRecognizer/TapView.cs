using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GestureRecognizer
{
    public class TapView : ContentPage
    {
        #region Private constants

        private const int RowHeight = 49;

        #endregion
        
        SfListView listView;

        public TapView()
        {
            TapModel viewModel = new TapModel();
            TapViewModel tapViewModel = new TapViewModel();
            TapWrapperModel tapWrapperModel = new TapWrapperModel(tapViewModel);
            listView = new SfListView();
            listView.ItemsSource = viewModel.Products;
            listView.ItemSpacing = new Thickness(5);
            listView.ItemTemplate = new DataTemplate(() =>
            {
                Grid bodyLayout = new Grid
                {
                    ColumnSpacing = 0,
                    RowSpacing = 0,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                bodyLayout.RowDefinitions.Add(new RowDefinition { Height = RowHeight });
                bodyLayout.RowDefinitions.Add(new RowDefinition { Height = 1 });

                StackLayout checkLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                for (int i = 0; i < 4; i++)
                {
                    AddCell(checkLayout.Children, i, nameof(Product.Number));
                }

                Grid.SetRow(checkLayout, 0);
                bodyLayout.Children.Add(checkLayout);

                BoxView separatorBoxView = new BoxView
                {
                    BackgroundColor = Color.Gray,
                    Margin = 0
                };
                Grid.SetRow(separatorBoxView, 1);
                bodyLayout.Children.Add(separatorBoxView);


                // Single tap
                TapGestureRecognizer gestureRecognizer = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
                //gestureRecognizer.BindingContext = listItemWrapperModel;
                gestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, new Binding() { Source = tapWrapperModel, Path = "ClickCommand" });
                gestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, ".");
                bodyLayout.GestureRecognizers.Add(gestureRecognizer);

                // Double tap
                gestureRecognizer = new TapGestureRecognizer { NumberOfTapsRequired = 2 };
                gestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, new Binding() { Source = tapWrapperModel, Path = "DoubleTapCommand" });
                gestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, ".");
                bodyLayout.GestureRecognizers.Add(gestureRecognizer);

                return bodyLayout;
            });

            Content = listView;
        }

        private static Label CreateLabel(string automationId = null)
        {
            Label label = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 15,
                LineBreakMode = LineBreakMode.WordWrap,
                Margin = new Thickness(10, 0, 10, 0),
                VerticalTextAlignment = TextAlignment.Center,
                AutomationId = automationId,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand

            };
          
            return label;
        }

        private static BoxView CreateBoxView(int column, string automationId = null)
        {
            BoxView boxView = new BoxView
            {
                WidthRequest = 2,
                Color = Color.Blue, // column % 2 == 0 ? Color.White : Color.Gray,
                AutomationId = automationId
            };

            return boxView;
        }

        private static Tuple<BoxView, Label> AddCell(ICollection<View> gridChildren, int column,
            string textBindingProperty, string text = null, bool isBindable = true)
        {
            BoxView cellBoxView = CreateBoxView(column);
            //Grid.SetColumn(cellBoxView, column);
            gridChildren.Add(cellBoxView);

            Label cellLabel = CreateLabel(textBindingProperty);

            if (isBindable)
            {
                cellBoxView.SetBinding(IsVisibleProperty, new Binding("IsSelected"));
            }

            if (text == null)
                cellLabel.SetBinding(Label.TextProperty, textBindingProperty);
            else
                cellLabel.Text = text;

            //Grid.SetColumn(cellLabel, column);
            gridChildren.Add(cellLabel);

            return new Tuple<BoxView, Label>(cellBoxView, cellLabel);
        }
    }
}