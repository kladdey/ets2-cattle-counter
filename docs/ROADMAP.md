# Roadmap

- [x] Repository skeleton and scope
- [ ] Core casualty calculation library
- [ ] Unit tests and synthetic telemetry fixture
- [ ] Windows WPF overlay
- [ ] Local JSON statistics
- [ ] Evaluate and integrate telemetry plugin
- [ ] Live ETS2 test
- [ ] Release ZIP with setup instructions

## Acceptance criteria for v0.1
- A simulated bad turn can generate a casualty event.
- Repeated samples from the same incident do not count twice.
- Counters remain consistent and never negative.
- Stats survive restarting the app.
- No ETS2 save modification.
