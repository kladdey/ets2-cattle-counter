# ETS2 Cattle Casualty Counter 🐄

A ridiculous but functional livestock welfare tracker for Euro Truck Simulator 2.

## Goal
Track hypothetical cattle casualties caused by reckless driving while hauling livestock. This is a companion application, **not** a simulation of real animals or an ETS2-native cargo damage feature.

## MVP
- Read live speed, acceleration, collision/damage and cargo data through an ETS2 telemetry bridge.
- Detect aggressive cornering, harsh braking and impacts.
- Maintain cattle loaded, alive, lost on this delivery and lifetime lost.
- Show a small always-on-top Windows overlay.
- Persist statistics locally.
- Allow manual start/reset of a livestock delivery when telemetry cannot identify cargo reliably.

## Proposed stack
- C# / .NET 8, Windows desktop
- WPF overlay
- A separately installed ETS2 telemetry plugin/bridge (to be selected and validated)
- JSON configuration and local statistics

## Development phases
1. Implement and unit-test a pure casualty calculation engine with simulated telemetry.
2. Build a minimal WPF dashboard and persistent statistics.
3. Integrate a verified ETS2 telemetry bridge and test with the current game version.
4. Add automatic livestock detection, calibration and packaging.

## Important limitations
ETS2 does not provide individual animal health. All casualties are fictional estimates computed by this app. No in-game job payout changes are promised. Telemetry integration and exact signals need validation against a working plugin.

## Safety
Use a copy of your ETS2 profile when testing new integrations. This app should not modify saves or game files.
