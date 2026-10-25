using CattleCounter.Core;

var engine = new CasualtyEngine();
Console.WriteLine($"Cattle loaded: {engine.Loaded}");
var samples = new[]
{
    new DrivingSample(0, 0, 0, 0),
    new DrivingSample(10, 5.2, 0, 0),
    new DrivingSample(11, 5.2, 0, 0),
    new DrivingSample(20, 0, -7.1, 0),
    new DrivingSample(30, 0, 0, 0.15),
};
foreach (var sample in samples)
{
    var incident = engine.Process(sample);
    if (incident is not null)
        Console.WriteLine($"{incident.Reason}: -{incident.Lost} cattle, {incident.Alive} alive");
}
Console.WriteLine($"Delivery total: {engine.Lost} lost");
