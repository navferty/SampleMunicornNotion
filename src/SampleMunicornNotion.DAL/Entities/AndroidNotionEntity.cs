using SampleMunicornNotion.Models;

namespace SampleMunicornNotion.DAL.Entities;

public class AndroidNotionEntity
{
	public long Id { get; set; }

	public string DeviceToken { get; set; }
	public string Message { get; set; }
	public string Title { get; set; }
	public string Condition { get; set; }

	public DateTime CreatedAt { get; set; }
	public DateTime? ProcessedAt { get; set; }
	public ProcessingStatus Status { get; set; }
}
