namespace CattleCounter.Core;

public sealed record DrivingSample(
    double ElapsedSeconds,
    double LateralAcceleration,
    double LongitudinalAcceleration,
    double Damage);

public sealed record CasualtyEvent(string Reason, int Lost, int Alive);

public sealed class CasualtyEngine
{
    private double _lastEventTime = double.NegativeInfinity;
    private double _previousDamage;
    private bool _hasSample;

    public int Loaded { get; private set; }
    public int Alive { get; private set; }
    public int Lost => Loaded - Alive;
    public double CooldownSeconds { get; init; } = 5;
    public double CorneringThreshold { get; init; } = 4.5;
    public double BrakingThreshold { get; init; } = -6.0;
    public double DamageJumpThreshold { get; init; } = 0.03;

    public CasualtyEngine(int cattle = 30) => StartDelivery(cattle);

    public void StartDelivery(int cattle)
    {
        if (cattle < 1) throw new ArgumentOutOfRangeException(nameof(cattle));
        Loaded = Alive = cattle;
        _lastEventTime = double.NegativeInfinity;
        _previousDamage = 0;
        _hasSample = false;
    }

    public CasualtyEvent? Process(DrivingSample sample)
    {
        if (!double.IsFinite(sample.ElapsedSeconds) ||
            !double.IsFinite(sample.LateralAcceleration) ||
            !double.IsFinite(sample.LongitudinalAcceleration) ||
            !double.IsFinite(sample.Damage))
            throw new ArgumentException("Telemetry must contain finite numbers.");

        var damageJump = _hasSample ? sample.Damage - _previousDamage : 0;
        _previousDamage = sample.Damage;
        _hasSample = true;

        if (Alive == 0 || sample.ElapsedSeconds - _lastEventTime < CooldownSeconds)
            return null;

        string? reason = null;
        int casualties = 0;

        if (damageJump >= DamageJumpThreshold)
        {
            reason = "Collision";
            casualties = Math.Clamp((int)Math.Ceiling(damageJump * 20), 1, 8);
        }
        else if (Math.Abs(sample.LateralAcceleration) >= CorneringThreshold)
        {
            reason = "Aggressive cornering";
            casualties = 1;
        }
        else if (sample.LongitudinalAcceleration <= BrakingThreshold)
        {
            reason = "Harsh braking";
            casualties = 1;
        }

        if (reason is null) return null;
        casualties = Math.Min(casualties, Alive);
        Alive -= casualties;
        _lastEventTime = sample.ElapsedSeconds;
        return new CasualtyEvent(reason, casualties, Alive);
    }
}
