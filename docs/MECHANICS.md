# Draft mechanics (subject to playtesting)

## State
- Loaded cattle: default 30, configurable.
- Alive = loaded - lost.
- Delivery losses and lifetime losses tracked separately.
- One driving incident must not repeatedly trigger casualties every telemetry tick.

## Inputs
Speed, longitudinal/lateral acceleration, and collision/damage changes when supported by the telemetry bridge.

## Candidate incidents
- Aggressive turns: lateral acceleration exceeds a configurable threshold for a minimum duration.
- Harsh braking: negative longitudinal acceleration exceeds a threshold.
- Impacts: sudden supported damage increase, with a cooldown to avoid duplicate incidents.

## Balancing
Thresholds and probability/severity are configurable. Include a simulated-telemetry mode for deterministic tests. Never decrement alive below zero.

## Cargo detection
Start with manual enable/disable. Automatic detection must be tested against actual livestock cargo IDs and localized cargo names; don't assume every trailer carrying livestock contains cattle.
