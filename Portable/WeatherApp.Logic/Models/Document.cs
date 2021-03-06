﻿using System;
using Assisticant.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using WeatherApp.Logic.Services;

namespace WeatherApp.Logic.Models
{
	public class Document
	{
		private ObservableList<City> _cities = new ObservableList<City>();

		public IEnumerable<City> Cities
		{
			get { return _cities; }
		}

		public City NewCity()
		{
			var city = new City();
			_cities.Add(city);
			return city;
		}

		public void RemoveCity(City city)
		{
			_cities.Remove(city);
		}

		public void Load(IEnumerable<CityMemento> cities)
		{
            throw new NotImplementedException();
        }

		public List<CityMemento> Save()
		{
            throw new NotImplementedException();
        }
	}
}

