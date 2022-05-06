using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
/*
{
	"id":"b6893e0e-c78c-4a5f-84a2-eed5e2595db3",
	"first_name":"Luke",
	"last_name":"Oyler",
	"number":"00",
	"status":"active",
	"team_id":"559b701b-d408-4385-9d81-dafd3f8ea251",
	"user_id":null,
	"meta_seq":97964250,
	"created_at":"2022-01-02T03:59:52.440Z",
	"updated_at":"2022-01-02T03:59:52.440Z",
	"bats":
	{
		"player_id":"b6893e0e-c78c-4a5f-84a2-eed5e2595db3",
		"batting_side":"left",
		"throwing_hand":"right",
		"meta_seq":"84922138",
		"created_at":"2022-01-02T03:59:52.467Z",
		"updated_at":"2022-01-02T03:59:52.467Z"
	},
	"person_id":"b6893e0e-c78c-4a5f-84a2-eed5e2595db3"
}
*/