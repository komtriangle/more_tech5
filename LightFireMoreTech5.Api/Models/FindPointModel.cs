using LightFireMoreTech5.Models.Enums;

namespace LightFireMoreTech5.Models
{
	public class FindPointModel
	{
		/// <summary>
		/// Текущая широта пользователя
		/// </summary>
		public double Latitude { get; set; }

		/// <summary>
		/// Текущая долгота пользователя
		/// </summary>
		public double Longitude { get; set; }

		/// <summary>
		/// Радиус, в котором ищем отделния и банкоматы
		/// </summary>
		public double Radius { get; set; }

		public FindParameters? Parameters { get; set; }

	}

	public class FindParameters
	{
		public ClientType Type { get; set; }
		public List<long> SericeIds { get; set; }
	}
}
