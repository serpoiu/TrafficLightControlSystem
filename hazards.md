# Hazards and Risk Mitigation

## Hazard Identification

| ID | Hazard |
|---|---|
| Haz-01 | Conflicting Green signals causing vehicle collision |
| Haz-02 | Traffic allowed during pedestrian crossing |
| Haz-03 | Desynchronised paired signals causing unsafe flow |
| Haz-04 | Sensor failure leading to unsafe timing decisions |
| Haz-05 | Signal not progressing causing deadlock or unsafe state |
| Haz-06 | Light failing to illuminate causing incorrect driver interpretation |
| Haz-07 | Light failing to de-illuminate causing conflicting signals |
| Haz-08 | Indefinite Green ignoring pedestrian request |
| Haz-09 | System continuing operation in faulty state |

---

## Risk Clasification

| ID | Severity | Likelihood | Risk Level
|---|---|---|---|
| Haz-01 | Critical | Medium | High |
| Haz-02 | Critical | Medium | High |
| Haz-03 | High		| Low	 | Medium |
| Haz-04 | High		| Medium | High |
| Haz-05 | High		| Low	 | Medium |
| Haz-06 | Critical | Low	 | High |
| Haz-07 | Critical | Low    | High |
| Haz-08 | Medium	| Medium | Medium |
| Haz-09 | Critical | Low	 | High |

---

## Mitigation Strategies

| Hazard | Mitigation |
|---|---|
| Haz-01 | Enforce invariant preventing simultaneous active signals |
| Haz-02 | Force all signals to Red during pedestrian crossing |
| Haz-03 | Enforce paired signal synchronisation invariant |
| Haz-04 | Apply fixed 30s Green fallback and raise alert |
| Haz-05 | Transition system to FaultOff state |
| Haz-06 | Detect mismatch and transition to FaultOff state |
| Haz-07 | Detect mismatch and transition to FaultOff state |
| Haz-08 | Prevent indefinite Green when pedestrian crossing pending |
| Haz-09 | Enforce FaultOff state with manual recovery only |

---

## Safety Constraints Mapping

| Hazard | Safety Requirement |
|---|---|
| Haz-01 | Safe-01, Safe-02 |
| Haz-02 | Safe-05, Safe-06 |
| Haz-03 | Safe-07 |
| Haz-04 | Safe-08, Safe-09 |
| Haz-05 | Safe-10 |
| Haz-06 | Safe-11 |
| Haz-07 | Req-12 |
| Haz-08 | Req-11, Time-05 |
| Haz-09 | Safe-13, Safe-14, Safe-15 |

---

## Verification Approach

| Hazard | Verification Method |
|---|---|
| Haz-01 | Invariant unit tests |
| Haz-02 | Pedestrian crossing tests |
| Haz-03 | Synchronisation tests |
| Haz-04 | Sensor failure tests |
| Haz-05 | Fault transition tests |
| Haz-06 | Light feedback tests |
| Haz-07 | Light feedback tests |
| Haz-08 | Timing constraints tests |
| Haz-09 | Fault persistence tests |

---

## Residual Risk

All hazards are reduced to acceptable levels through:
	enforced invariants#
	deterministic state transitions
	fail-safe fault handling
	full unit test coverage


No hazards permits unsafe system behaviour under defined constraints
