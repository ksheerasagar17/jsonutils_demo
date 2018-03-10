using Newtonsoft.Json;
using System;

namespace jsonutils_demo.Model
{
    namespace JSONUtils
    {
        public class PowerballDraw
        {
            [JsonProperty("draw_date")]
            public DateTime DrawDate { get; set; }

            [JsonProperty("multiplier")]
            public string Multiplier { get; set; }

            [JsonProperty("winning_numbers")]
            public string WinningNumbers { get; set; }
        }
    }
}
