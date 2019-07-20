using System;
using System.Collections.Generic;
using MyLoL.ViewModels;
using Xamarin.Forms;

namespace MyLoL.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            var vm = new MainViewModel
            {
                Navigation = Navigation
            };

            BindingContext = vm;
        }
    }
}