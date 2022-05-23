using System.Text.Json.Serialization;

namespace GameChanger.Core
{
    public class TeamOffense
    {
        public int H { get; set; }
        public int R { get; set; }

        [JsonPropertyName("1B")]
        public int _1B { get; set; }
        [JsonPropertyName("2B")]
        public int _2B { get; set; }
        [JsonPropertyName("3B")]
        public int _3B { get; set; }

        [JsonPropertyName("6+")]
        public int _6 { get; set; }
        public int AB { get; set; }
        public int BB { get; set; }

        [JsonPropertyName("C%")]
        public double C { get; set; }
        public int CI { get; set; }
        public int CS { get; set; }
        public int FC { get; set; }
        public int GB { get; set; }
        public int GP { get; set; }
        public int HR { get; set; }
        public int OB { get; set; }
        public int OS { get; set; }
        public int PA { get; set; }
        public int PS { get; set; }
        public int SB { get; set; }
        public int SM { get; set; }
        public int SO { get; set; }
        public int SW { get; set; }
        public int TB { get; set; }
        public int TS { get; set; }

        [JsonPropertyName("6+%")]
        public double SixPitchABPercentage { get; set; }
        public double AVG { get; set; }

        [JsonPropertyName("CB%")]
        public int CB { get; set; }

        [JsonPropertyName("CH%")]
        public double CH { get; set; }

        [JsonPropertyName("CT%")]
        public int CT { get; set; }

        [JsonPropertyName("DB%")]
        public int DB { get; set; }

        [JsonPropertyName("DC%")]
        public int DC { get; set; }

        [JsonPropertyName("FB%")]
        public double FB { get; set; }
        public int FLB { get; set; }

        [JsonPropertyName("GB%")]
        public double OffenseGB { get; set; }
        public int HBP { get; set; }
        public int INP { get; set; }

        [JsonPropertyName("KB%")]
        public int KB { get; set; }

        [JsonPropertyName("KC%")]
        public int KC { get; set; }
        public int LND { get; set; }
        public int LOB { get; set; }
        public double OBP { get; set; }
        public double OPS { get; set; }

        [JsonPropertyName("OS%")]
        public double OffenseOS { get; set; }
        public int OSS { get; set; }
        public int PIK { get; set; }
        public int QAB { get; set; }

        [JsonPropertyName("RB%")]
        public int RB { get; set; }
        public int RBI { get; set; }
        public int ROE { get; set; }

        [JsonPropertyName("SB%")]
        public double OffenseSB { get; set; }

        [JsonPropertyName("SC%")]
        public int SC { get; set; }
        public int SHB { get; set; }
        public int SHF { get; set; }

        [JsonPropertyName("SL%")]
        public int SL { get; set; }
        public double SLG { get; set; }

        [JsonPropertyName("SM%")]
        public double OffenseSM { get; set; }
        public int SOL { get; set; }

        [JsonPropertyName("SW%")]
        public double OffenseSW { get; set; }
        public int XBH { get; set; }

        [JsonPropertyName("2S+3")]
        public int _2S3 { get; set; }

        [JsonPropertyName("BB/K")]
        public double BBK { get; set; }

        [JsonPropertyName("FLB%")]
        public double OffenseFLB { get; set; }
        public int FULL { get; set; }
        public int GIDP { get; set; }
        public int GITP { get; set; }
        public int GSHR { get; set; }
        public int HARD { get; set; }

        [JsonPropertyName("LND%")]
        public double OffenseLND { get; set; }
        public int LOBB { get; set; }
        public int OSSM { get; set; }
        public int OSSW { get; set; }

        [JsonPropertyName("QAB%")]
        public double OffenseQAB { get; set; }
        public int WEAK { get; set; }

        [JsonPropertyName("2S+3%")]
        public double Offense2S3 { get; set; }

        [JsonPropertyName("AB/HR")]
        public double ABHR { get; set; }
        public double BABIP { get; set; }
        public int HRISP { get; set; }

        [JsonPropertyName("PA/BB")]
        public double PABB { get; set; }

        [JsonPropertyName("PS/PA")]
        public double PSPA { get; set; }
        public int ABRISP { get; set; }
        public int _2OUTRBI { get; set; }

        [JsonPropertyName("BA/RISP")]
        public double BARISP { get; set; }
        public int _2STRIKES { get; set; }
    }

}
