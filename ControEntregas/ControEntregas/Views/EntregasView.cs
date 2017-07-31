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
        //private Label nameLabel2;
        //private Label nameLabel3;

        public EntregasView()
        {
            cellWrapper = new StackLayout {Orientation = StackOrientation.Horizontal};
            nameLabel = new Label { FontSize = 20, };
            //nameLabel2 = new Label { FontSize = 20, };
            //nameLabel3 = new Label { FontSize = 20,  };

            nameLabel.SetBinding(Label.TextProperty, "Tema");
            //nameLabel2.SetBinding(Label.TextProperty, "Espacio");
            //nameLabel3.SetBinding(Label.TextProperty, "ID");

            cellWrapper.Children.Add(nameLabel);            
          //  cellWrapper.Children.Add(nameLabel2);
            //cellWrapper.Children.Add(nameLabel3);
            View = cellWrapper;
            
        }
    }
}