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
		public List<long> ServiceIds { get; set; }
	}
}
