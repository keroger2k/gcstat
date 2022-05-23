using System.Text.Json.Serialization;

namespace GameChanger.Core
{
    public class BattingThrowingInfo
	{
		[JsonPropertyName("player_id")]
		public string PlayerId { get; set; }

		[JsonPropertyName("batting_side")]
		public string BattingSide { get; set; }

		[JsonPropertyName("throwing_hand")]
		public string ThrowingHand { get; set; }

		[JsonPropertyName("meta_seq")]
		public string MetaSeq { get; set; }

		[JsonPropertyName("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonPropertyName("updated_at")]
		public DateTime UpdatedAt { get; set; }

	}
}