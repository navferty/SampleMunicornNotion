namespace SampleMunicornNotion.Models;

public class IOSNotion : INotion
{
	public long Id { get; set; }

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
	public int Priority { get; set; }

	/// <summary>
	/// Является фоновым. По умолчанию должно принимать значение true.
	/// </summary>
	public bool IsBackground { get; set; }

	public DateTime CreatedAt { get; set; }
	public DateTime? ProcessedAt { get; set; }
	public ProcessingStatus Status { get; set; }

	public override string ToString() => $"iOS notion: {Alert}, Priority={Priority}, IsBackground={IsBackground}";
}
