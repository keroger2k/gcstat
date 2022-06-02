using System.Text.Json.Serialization;

namespace GameChanger.Core
{

	public class PlayerSprayChart : PlayerInfoResults
    {
        public PlayerSprayChart()
        {

        }
        public PlayerSprayChart(PlayerInfoResults result)
        {
			this.Id = result.Id;
			this.FirstName = result.FirstName;
			this.LastName = result.LastName;	
			this.Number = result.Number;
			this.Status = result.Status;
			this.TeamId = result.TeamId;
			this.UserId = result.UserId; 
			this.MetaSeq = result.MetaSeq;
			this.CreatedAt = result.CreatedAt;
			this.UpdatedAt = result.UpdatedAt;
			this.Bats = result.Bats; 
			this.PersonId = result.PersonId;
			this.SprayChart = new List<NotSure>();
        }
		public List<NotSure> SprayChart {  get ; set; }
    }

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