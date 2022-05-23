using System.Text.Json.Serialization;

namespace GameChanger.Core
{
    public class PlayerInfoResults
    {
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("first_name")]
		public string FirstName { get; set; }

		[JsonPropertyName("last_name")]
		public string LastName { get; set; }

		[JsonPropertyName("number")]
		public string Number { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("team_id")]
		public string TeamId { get; set; }

		[JsonPropertyName("user_id")]
		public string UserId { get; set; }

		[JsonPropertyName("meta_seq")]
		public int MetaSeq { get; set; }

		[JsonPropertyName("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonPropertyName("updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonPropertyName("bats")]

		public BattingThrowingInfo Bats { get; set; }

		[JsonPropertyName("person_id")]
		public string PersonId { get; set; }

	}
}