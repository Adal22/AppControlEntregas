using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ControEntregas.Views
{
    public class EntregasView : ViewCell
    {
        private StackLayout cellWrapper;
        private Label nameLabel;
        public EntregasView()
        {
            cellWrapper = new StackLayout {Orientation = StackOrientation.Vertical};
            nameLabel = new Label { FontSize = 20, HorizontalOptions = LayoutOptions.StartAndExpand };
            nameLabel.SetBinding(Label.TextProperty, "Tema");
            cellWrapper.Children.Add(nameLabel);
            View = cellWrapper;
            
        }
    }
}