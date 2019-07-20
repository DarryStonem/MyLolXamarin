using System;
using System.Collections.Generic;
using MyLoL.ViewModels;
using RiotSharp.Endpoints.SummonerEndpoint;
using Xamarin.Forms;

namespace MyLoL.Views
{
    public partial class SummonerView : ContentPage
    {
        public SummonerView(Summoner summoner)
        {
            InitializeComponent();
            var vm = new SummonerViewModel
            {
                Navigation = Navigation,
                CurrentSummoner = summoner
            };

            BindingContext = vm;
        }
    }
}