﻿using Prism.Commands;
using Prism.Navigation;
using System.Text.RegularExpressions;
using Taxi.Common.Models;
using Taxi.Common.Services;

namespace Taxi.Prism.ViewModels
{
    public class TaxiHistoryPageViewModel : ViewModelBase
    {
        
        private readonly IApiService _apiService;
        private TaxiResponse _taxi;
        private DelegateCommand _checkPlaqueCommand;
        public TaxiHistoryPageViewModel(
            INavigationService navigationService,
            IApiService apiService)
            : base(navigationService)
        {
            _apiService = apiService;
            Title = "Taxi's History";
        }
        public TaxiResponse Taxi
        {
            get => _taxi;
            set => SetProperty(ref _taxi, value);
        }
        public string Plaque { get; set; }

        public DelegateCommand CheckPlaqueCommand => _checkPlaqueCommand ?? (_checkPlaqueCommand = new DelegateCommand(CheckPlaqueAsync));

        private async void CheckPlaqueAsync()
        {
            if (string.IsNullOrEmpty(Plaque))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a plaque",
                    "Accept");
                return;
            }

            Regex regex = new Regex(@"^([A-Za-z]{3}\d{3})$");
            if (!regex.IsMatch(Plaque))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "The palque must start with three letters and ends with three numbers.",
                    "Accept");
                return;
            }
            
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetTaxiAsync(Plaque, url, "api", "/Taxis");
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            Taxi = (TaxiResponse)response.Result;
            
        }
    }
}
