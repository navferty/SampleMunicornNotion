namespace SampleMunicornNotion.Models;

public class AndroidNotion : INotion
{
	public long Id { get; set; }

	/// <summary>
	/// строка до 50 символов.Уникальный идентификатор девайса, куда будет отправлено уведомление.Поле обязательное.
	/// </summary>
	public string DeviceToken { get; set; }

	/// <summary>
	/// строка до 2000 символов.Само сообщение. Поле обязательное.
	/// </summary>
	public string Message { get; set; }

	/// <summary>
	/// строка до 255 символов.Поле обязательное.
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	/// строка до 2000 символов.Поле является опциональным.
	/// </summary>
	public string Condition { get; set; }

	public DateTime CreatedAt { get; set; }
	public DateTime? ProcessedAt { get; set; }
	public ProcessingStatus Status { get; set; }

	public override string ToString() => $"Android notion: {Title}; {Message}, Condition: {Condition}";
}
