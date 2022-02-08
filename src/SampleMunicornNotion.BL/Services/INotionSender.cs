using SampleMunicornNotion.Models;

namespace SampleMunicornNotion.BL.Services
{
	public interface INotionSender<TNotion>
		where TNotion : INotion
	{
		/// <summary>
		/// Отправить уведомление.
		/// </summary>
		/// <param name="notion"></param>
		/// <returns></returns>
		Task<TNotion> SendNotion(TNotion notion);

		/// <summary>
		/// user-friendly имя
		/// </summary>
		string Name { get; }
	}
}
