# Formal Specification

## System Model

The junction is moddeled as two synchronised directions:

Directions = {NS, EW}

NS = {North, South}
EW = {East, West}

Only one direction may be active at any time 

---

## Signal Domain

Signal ∈ {Red, RedAmber, Green, Amber, Off}

Active = {Green, RedAmber, Amber}

---

## Core Safety Requirement

Intersecting traffic flows must never be permitted simultaneously

---

## Formal Invariant

¬((NS ∈ {Green, RedAmber}) ∧ (EW ∈ {Green, RedAmber}))

--- 

## Strengthened Invariant

(NS ∈ Active) => (EW = Red)
(EW ∈ Active) => (NS = Red)

---

## System States

SystemState ∈
{
	NormalOperation,
	PedestrianCrossing,
	FaultOff
}

---

## Safety Invariants

SystemState = PedestrianCrossing => NS = Red ∧ EW = Red

North = South ∧ East = West

SystemState = FaultOff => NS = Off ∧ EW = Off

SystemState = FaultOff => FaultAlert = true

GreenDuration > 30s => OpposingTrafficWaiting = false ∧ PedestrianRequestPending = false

---

## Valid Transitions

Red -> RedAmber
RedAmber -> Green
Green -> Amber
Amber -> Red
Off -> Off

---

## Timing Constraints

RedAmberDuration = 1.5s
AmberDuration = 1.5s
GreenDuration ≤ 30s
PedestrianTime = 15s

GreenDuration > 30s => no opposing traffic ∧ no pedestrian request

---

## Pedestrian Behaviour

PedestrianRequest => PedestrianRequestPending = true

(NS = Red ∧ EW = Red) => SystemState = PedestrianCrossing

PedestrianAlert = true
PedestrianLight = true

ElapsedTime ≥ 15s => SystemState = NormalOperation

---

## Fault Conditions

SignalProgressionFailure V LightIlluminationFailure V LightDeIlluminationFailure

SystemState = FaultOff
AllSignals = Off
FaultAlert = true

---

## Test Mapping

bool nsActive = 
	controller.NorthSouth == Signal.Green ||
	controller.NorthSouth == Signal.RedAmber ||
	controller.NorthSouth == Signal.Amber;

bool ewActive =
	controller.EastWest == Signal.Green ||
	controller.EastWest == Signal.RedAmber ||
	controller.EastWest == Signal.Amber;

if (nsActive)
{
	Assert.Equal(Signal.Red, controller.EastWest);
}

if (ewActive)
{
	Assert.Equal(Signal.Red, controller.NorthSouth);
}

---

## Test Pattern

Arrange:
NS = Red, EW = Red

Act:
ChangeToNextSignal(NS)

Assert:
Invariant holds

---

## Verification Mapping

| Formal ELement | Requirement |
|---|---|
| Core invariant | Safe-02, Safe-03, Safe-04 |
| Strenghened invariant | Safe-01 |
| Pedestrian invariant | Safe-05, Safe-06 |
| Pair synchronisation | Safe-07 |
| Fault off | Safe-13 |
| Fault alert | Safe-14 |
| Green constraint | Req-11, Time-05 |
| Transitions | Req-04 - Req-07 |
| Timing | Time-01 - Time-05 |
| Pedestrian behaviour | Req-12 - Req-17 |
| Fault handling | Safe-08 - Safe-15 |

