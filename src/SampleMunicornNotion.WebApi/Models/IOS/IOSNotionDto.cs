using SampleMunicornNotion.Models;

namespace SampleMunicornNotion.WebApi.Models;

public class IOSNotionDto
{
	public long Id { get; set; }

	public string PushToken { get; set; }
	public string Alert { get; set; }
	public int Priority { get; set; }
	public bool IsBackground { get; set; }

	public ProcessingStatus Status { get; set; }
}
