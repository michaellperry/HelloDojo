﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Logic.Models;
using Assisticant.Binding;
using WeatherApp.Logic.Services;
using System.Net.Http;

namespace WeatherApp.Logic.ViewModels
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; }

		public static void Initialize(string mashapeKey, IStorageService storageService)
        {
            if (Instance == null)
                Instance = new ViewModelLocator(mashapeKey, storageService);
        }

        private readonly Document _document;
        private readonly IWeatherServiceAgent _weatherServiceAgent;
        private readonly CitySelection _citySelection;
		private readonly IStorageService _storageService;
		private readonly ForecastRepository _forecastRepository;

		private BindingManager _bindings = new BindingManager();

		private ViewModelLocator(string mashapeKey, IStorageService storageService)
        {
			_storageService = storageService;

            _document = new Document();
            _citySelection = new CitySelection();
            _weatherServiceAgent = new FakeWeatherServiceAgent(_document);
			_forecastRepository = new ForecastRepository(
				_storageService,
				_weatherServiceAgent,
				_document);
        }

        public MainViewModel Main
        {
            get
            {
                return new MainViewModel(_document, _citySelection);
            }
        }

        public CityViewModel City
        {
            get
            {
                if (_citySelection.SelectedCity == null)
                    return null;

                return new CityViewModel(
					_citySelection.SelectedCity,
					_forecastRepository);
            }
        }

        public NewCityViewModel NewCity
        {
            get
            {
                return new NewCityViewModel(
					_document,
					_citySelection,
                    _storageService);
            }
        }
    }
}
