
namespace SampleMunicornNotion.Models
{
	public interface INotion
	{
		DateTime CreatedAt { get; set; }
		long Id { get; set; }
		DateTime? ProcessedAt { get; set; }
		ProcessingStatus Status { get; set; }
	}
}