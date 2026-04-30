# Test Plan

## Overview

This document defines the testing strategy to verify correctness, safety and realibility using Test-Driven Development (TDD)

---

## Testing Strategy

	all tests are written before implementation
	all requirements must have at least one coresponding test
	safety invariants are tested continuosly
	deterministic time control is used, no real delays
	test follow Arrange-Act-Assert structure

---

## Test CAtegories

| Category | Description |
|---|---|
| Unit Tests		| Validate individual state transitions and logic |
| Invariant Tests	| Validate safety constraints are never vioated |
| Timing Tests		| Validate duration constaints |
| Fault Tests		| Validate fail-safe behaviour |
| Integration Tests | Validate interaction between components |

---

## Test Structure

Arrange:
Initialise system in known state

Act:
Apply single transition or input

Assert:
Verify expected state and invariants

---

## Invariant Testing

| Formal Element | Test Approach |
|---|---|
| Core invariant		| Ensure no conflicting active signals |
| Strenghened invariant	| Ensure opposing direction is Red when one is active |
| Pedestrian invariant	| Ensure all signals Red during crossing |
| Pair synchronisation	| Ensure paired signals match |
| Fault off				| Ensure signals in Off state |	
| Fault alert			| Ensure alert raised in fault state |
| Green constraint		| Ensure no indifinete Green when restricted |

---

## Transition Testing 

| Transition | Test |
|---|---|
| Red -> RedAmber	  | Valid transition test |
| RedAmber -> Green	  | Valid transition test |
| Green -> Amber	  | Valid transition test |
| Amber -> Red		  | Valid transition test |
| Invalid transitions | Rejection test |

---

## Timing Testing

| Constraint | Test |
|---|---|
| RedAmber = 1.5s			| Boundary test |
| Amber = 1.5s				| Boundary test |
| Green ≤ 30s (restricted)	| Limit test |
| Green > 30s (allowed)		| Conditional test |
| Pedestrian = 15s			| Exact duration test |

---

## Pedestrian Testing 

| Scenario | Test |
|---|---|
| Pedestrian request received		| Request queued |
| Transition to all red				| Crossing triggered |
| Crossing active					| Alerts and lights active |
| Crossing complete					| Normal operation resumes |

---

## Fault Testing

| Fault | Test |
|---|---|
| Sensor failure				| 30s fallback and alert |
| Signal progression failure	| Transition to FaultOff |
| Illumination failure			| Transition to FaultOff |
| De-Illumination failure		| Transition to FaultOff |
| Fault persistence				| No automatic recovery |

---

## Traceability

All tests must reference
	requirement ID
	formal element

Example:

Test: No conflicting flows
Requirement: Safe-01
Formal Element: Core invariant

---

## Coverage Requirements 

	100% requirement coverage
	100% safety invariant
	all transitions tested
	all fault conditions tested

---

## Tooling

Language: C#
Framework: xUnit
Version Control: GitHub
Test execution via Visual Studio 2022

---

## Acceptance Criteria

The system is accepted when:
	all tests pass
	no invariant violations occur
	all hazards are mitigated
	traceability matrix is complet
	test coverage requirements are met

---

## Test Evidence

The full automated test suite was executed in Visual Studio 202

Evidence captured:
	all unit tests passed
	no failed tests
	deterministic timing tests passed
	safety invariant tests passed
	fault handling tests passed
