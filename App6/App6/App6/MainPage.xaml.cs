using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App6
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            listView.ItemSelected += async (sender, e) =>
             {
                 if (e.SelectedItem == null) return;
                 var emp = e.SelectedItem as Emp;

                 var nextPage = new NextPage();
                 nextPage.BindingContext = emp;
                 await Navigation.PushAsync(nextPage);
             };
        }
    }
}
