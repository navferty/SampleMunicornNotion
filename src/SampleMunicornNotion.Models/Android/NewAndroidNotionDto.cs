namespace SampleMunicornNotion.Models.Android;

public class NewAndroidNotionDto
{
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
}
