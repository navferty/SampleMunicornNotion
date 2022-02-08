namespace SampleMunicornNotion.Models.IOS;

public class NewIOSNotionDto
{
	/// <summary>
	/// Уникальный идентификатор девайса, куда будет отправлено уведомление.
	/// строка до 50 символов. Поле обязательное.
	/// </summary>
	public string PushToken { get; set; }

	/// <summary>
	/// Само сообщение.
	/// строка до 2000 символов. Поле обязательное.
	/// </summary>
	public string Alert { get; set; }

	/// <summary>
	/// Приоритет. По умолчанию должно принимать значение 10.
	/// </summary>
	public int? Priority { get; set; }

	/// <summary>
	/// Является фоновым. По умолчанию должно принимать значение true.
	/// </summary>
	public bool? IsBackground { get; set; }
}
