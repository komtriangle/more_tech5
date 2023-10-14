using LightFireMoreTech5.Models.Enums;

namespace LightFireMoreTech5.Models
{
	public class PointShotModel
	{
		public long Id { get; set; }

		/// <summary>
		/// Тип точки
		/// </summary>
		public PointType Type { get; set; }

		/// <summary>
		/// Название
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Адрес
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Расстояние в метрах до пользователя
		/// </summary>
		public double? DistanceMetres { get;set; }
	}
}
