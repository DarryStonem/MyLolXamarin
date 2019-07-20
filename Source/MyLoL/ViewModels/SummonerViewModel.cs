using System;
using System.Collections.ObjectModel;
using MvvmHelpers;
using MyLoL.Models;
using RiotSharp;
using RiotSharp.Endpoints.SummonerEndpoint;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;

namespace MyLoL.ViewModels
{
    public class SummonerViewModel : BaseVM
    {
        public Summoner CurrentSummoner { get; set; }

        public Command GetMatchesCommand { get; set; }

        private ObservableCollection<MatchesViewModel> _matchesItemCollection;
        public ObservableCollection<MatchesViewModel> MatchesItemCollection
        {
            get
            {
                return _matchesItemCollection;
            }
            set
            {
                SetValue(ref _matchesItemCollection, value);
                OnPropertyChanged(nameof(MatchesItemCollection));
            }
        }

        public string ProfileIcon => String.Format("http://ddragon.leagueoflegends.com/cdn/9.14.1/img/profileicon/{0}.png", CurrentSummoner.ProfileIconId);

        public SummonerViewModel()
        {
            GetMatchesCommand = new Command(() => GetSummonerAsync());
        }

        private async void GetSummonerAsync()
        {
            IsBusy = true;
            try
            {
                var api = RiotApi.GetDevelopmentInstance(Constants.APIKEY);
                var matchList = await api.Match.GetMatchListAsync(RiotSharp.Misc.Region.Na, CurrentSummoner.AccountId);
                var champions = await api.StaticData.Champions.GetAllAsync("9.14.1");

                if (matchList == null)
                {
                    return;
                }

                if (MatchesItemCollection == null)
                    MatchesItemCollection = new ObservableCollection<MatchesViewModel>();
                else
                    MatchesItemCollection.Clear();

                foreach (var item in matchList.Matches)
                {
                    var match = new MatchesViewModel(item);
                    match.Champion = champions.Champions.Values.FirstOrDefault(x => x.Id == match.MatchInformation.ChampionID);
                    match.ChampionImage = $"http://ddragon.leagueoflegends.com/cdn/9.14.1/img/champion/{match.Champion.Image.Full}";
                    Debug.WriteLine(match.ChampionImage);
                    MatchesItemCollection.Add(match);
                }
            }
            catch (RiotSharpException ex)
            {
                await CurrentPage.DisplayAlert("My LoL", "Summoner doesn't exists", "Ok");
            }
            catch (Exception ex)
            {
                await CurrentPage.DisplayAlert("My LoL", "Not controller exception", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}