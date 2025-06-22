using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace TeamCheckPlugin;

public class TeamCheckConfig : IBasePluginConfig
{
    [JsonPropertyName("MinPlayersPerTeam")]
    public int MinPlayersPerTeam { get; set; } = 5;

    [JsonPropertyName("InitialDelaySeconds")]
    public float InitialDelaySeconds { get; set; } = 5.0f;

    [JsonPropertyName("RepeatDelaySeconds")]
    public float RepeatDelaySeconds { get; set; } = 2.5f;

    public int Version { get; set; } = 1;
}
