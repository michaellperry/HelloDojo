using System;
using WeatherApp.Logic;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Linq;
using WeatherApp.Logic.Services;

namespace WeatherApp.Android
{
	public class AndroidStorageService : IStorageService
	{
		public List<CityMemento> LoadCities ()
		{
			var fileName = GetFileName ();

			if (File.Exists (fileName)) {
				try {
					using (var stream = new FileStream (
						                    fileName,
						                    FileMode.Open)) {
						var dc = new DataContractSerializer (
							         typeof(DocumentMemento));

						var document = (DocumentMemento)dc.ReadObject (stream);
						return document.Cities;
					}
				} catch (Exception x) {
					// TODO: Indicate the error to the user.
				}
			}

			return new List<CityMemento> ();
		}

		public void SaveCities (IEnumerable<CityMemento> cities)
		{
			var fileName = GetFileName ();

			FileMode fileMode = File.Exists (fileName)
				? FileMode.Truncate
				: FileMode.CreateNew;

			using (var stream = new FileStream (
				                    fileName,
				                    fileMode)) {
				var dc = new DataContractSerializer (
					         typeof(DocumentMemento));

				dc.WriteObject (stream, new DocumentMemento {
					Cities = cities.ToList ()
				});
			}
		}

		public List<ForecastMemento> LoadForecasts (string cityName)
		{
			var fileName = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), string.Concat (cityName, ".xml"));

			if (File.Exists (fileName)) {
				try {
					using (var stream = new FileStream (
						                    fileName,
						                    FileMode.Open)) {
						var dc = new DataContractSerializer (
							         typeof(List<ForecastMemento>));

						var forecasts = (List<ForecastMemento>)dc.ReadObject (stream);
						return forecasts;
					}
					
				} catch (Exception x) {
					// TODO: Indicate the error to the user.
					Console.WriteLine (x.Message);
				}
			}

			return new List<ForecastMemento> ();
		}

		public void SaveForecasts (string cityName, IEnumerable<ForecastMemento> forecasts)
		{
			var fileName = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), string.Concat (cityName, ".xml"));

			FileMode fileMode = File.Exists (fileName)
				? FileMode.Truncate
				: FileMode.CreateNew;

			try {

				using (var stream = new FileStream (

					                fileName,
					                fileMode)) {
					var dc = new DataContractSerializer (
						        typeof(List<ForecastMemento>));

					dc.WriteObject (stream, forecasts.ToList ());
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
			}

		}

		private static string GetFileName ()
		{
			var documents = Environment.GetFolderPath (
				                Environment.SpecialFolder.MyDocuments);
			return Path.Combine (documents, "cities.xml");
		}
	}
}

