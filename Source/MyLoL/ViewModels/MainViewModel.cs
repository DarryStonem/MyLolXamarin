using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;
using MvvmHelpers;
using MyLoL.Views;
using RiotSharp;
using Xamarin.Forms;

namespace MyLoL.ViewModels
{
    public class MainViewModel : BaseVM
    {
        public Command GetSummonerCommand { get; set; }

        private string _summoner;
        public string Summoner
        {
            get { return _summoner; }
            set
            {
                SetValue(ref _summoner, value);
            }
        }

        public MainViewModel()
        {
            GetSummonerCommand = new Command(() => GetSummonerAsync());
        }

        private async void GetSummonerAsync()
        {
            if(String.IsNullOrEmpty(Summoner))
            {
                Crashes.GenerateTestCrash();
                return;
            }

            try
            {
                var api = RiotApi.GetDevelopmentInstance(Constants.APIKEY);
                var summoner = await api.Summoner.GetSummonerByNameAsync(RiotSharp.Misc.Region.Na, Summoner);

                Application.Current.MainPage = new NavigationPage(new SummonerView(summoner));
            }
            catch (RiotSharpException ex)
            {
                var properties = new Dictionary<string, string> {
                    { "Summoner", Summoner },
                    { "Version", "1.2" }
                };

                Crashes.TrackError(ex, properties);
                await Application.Current.MainPage.DisplayAlert("My LoL", "Summoner doesn't exists", "Ok");
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                await Application.Current.MainPage.DisplayAlert("My LoL", "Try again later.", "Ok");
            }
        }
    }
}