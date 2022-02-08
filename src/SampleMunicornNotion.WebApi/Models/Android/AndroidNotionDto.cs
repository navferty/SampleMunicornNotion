using SampleMunicornNotion.Models;

namespace SampleMunicornNotion.WebApi.Models;

public class AndroidNotionDto
{
	public long Id { get; set; }

	public string DeviceToken { get; set; }
	public string Message { get; set; }
	public string Title { get; set; }
	public string Condition { get; set; }

	public ProcessingStatus Status { get; set; }
}
