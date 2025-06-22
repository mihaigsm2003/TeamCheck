using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Modules.Utils;


namespace TeamCheckPlugin;

[MinimumApiVersion(318)]
public class TeamCheckPlugin : BasePlugin, IPluginConfig<TeamCheckConfig>
{
    public override string ModuleName => "TeamCheck";
    public override string ModuleAuthor => "GSM-RO";
    public override string ModuleVersion => "1.0.1";
    public override string ModuleDescription => "Team Check, Site Restrict";

    public TeamCheckConfig Config { get; set; } = new();

    public void OnConfigParsed(TeamCheckConfig config)
    {
        Config = config;
    }

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventRoundStart>(OnRoundStart);
    }

    private HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info)
    {
        AddTimer(Config.InitialDelaySeconds, () =>
        {
            int tCount = Utilities.GetPlayers().Count(p => p.Team == CsTeam.Terrorist && p.IsValid && !p.IsBot);
            int ctCount = Utilities.GetPlayers().Count(p => p.Team == CsTeam.CounterTerrorist && p.IsValid && !p.IsBot);

            string message = (tCount < Config.MinPlayersPerTeam || ctCount < Config.MinPlayersPerTeam)
                ? $" PLAY ONLY A!\nT: {tCount} Players || CT: {ctCount} Players"
                : $" PLAY A AND B!\nT: {tCount} Players || CT: {ctCount} Players";

            foreach (var player in Utilities.GetPlayers().Where(p =>
                         p.IsValid && !p.IsBot && p.Team is CsTeam.Terrorist or CsTeam.CounterTerrorist))
            {
                player.PrintToCenter(message);
            }

            AddTimer(Config.RepeatDelaySeconds, () =>
            {
                foreach (var player in Utilities.GetPlayers().Where(p =>
                             p.IsValid && !p.IsBot && p.Team is CsTeam.Terrorist or CsTeam.CounterTerrorist))
                {
                    player.PrintToCenter(message);
                }
            });
        });

        return HookResult.Continue;
    }
}
