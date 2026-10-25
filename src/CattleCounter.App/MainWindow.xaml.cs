using System;
using System.Windows;
using CattleCounter.Core;

namespace CattleCounter.App;

public partial class MainWindow : Window
{
    private readonly CasualtyEngine _engine = new();
    private double _time;
    private double _damage;

    public MainWindow()
    {
        InitializeComponent();
        Refresh();
    }

    private void Incident(double lateral, double longitudinal, double damageIncrement)
    {
        _time += 10; // Deliberately spaced synthetic samples; no live telemetry yet.
        _damage += damageIncrement;
        var result = _engine.Process(new DrivingSample(_time, lateral, longitudinal, _damage));
        if (result is not null)
        {
            IncidentList.Items.Insert(0, $"{result.Reason}: {result.Lost} lost, {result.Alive} alive");
        }
        Refresh();
    }

    private void BadTurn_Click(object sender, RoutedEventArgs e) => Incident(5.2, 0, 0);
    private void HardBrake_Click(object sender, RoutedEventArgs e) => Incident(0, -7.1, 0);
    private void Crash_Click(object sender, RoutedEventArgs e) => Incident(0, 0, 0.15);

    private void Reset_Click(object sender, RoutedEventArgs e)
    {
        _engine.StartDelivery(30);
        _time = 0;
        _damage = 0;
        IncidentList.Items.Clear();
        Refresh();
    }

    private void Refresh()
    {
        LoadedText.Text = _engine.Loaded.ToString();
        AliveText.Text = _engine.Alive.ToString();
        DeadText.Text = _engine.Lost.ToString();
    }
}
