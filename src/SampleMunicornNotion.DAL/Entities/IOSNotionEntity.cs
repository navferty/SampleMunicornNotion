using SampleMunicornNotion.Models;

namespace SampleMunicornNotion.DAL.Entities;

public class IOSNotionEntity
{
	public long Id { get; set; }

	public string PushToken { get; set; }
	public string Alert { get; set; }
	public int? Priority { get; set; }
	public bool? IsBackground { get; set; }

	public DateTime CreatedAt { get; set; }
	public DateTime? ProcessedAt { get; set; }
	public ProcessingStatus Status { get; set; }
}
