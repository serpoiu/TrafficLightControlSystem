# Traceability Matrix

## Overview

This document maps requirements to formal specifications, hazards, tests, and implementation usint to ensure full traceability

---

## Traceability Matrix

| Requirement ID | Formal Element | Hazard | Test Case | Implementation Unit |
|---|---|---|---|---|
|Req-01| System Model			| Haz-01 | System initialisation test		| Controller |
|Req-02| Pair synchronisation	| Haz-03 | NS sync test						| Controller |
|Req-03| Pair synchronisation	| Haz-03 | EW sync test						| Controller |
|Req-04| Transitions			| Haz-05 | Red -> RedAmber test				| State Machine |
|Req-05| Transitions			| Haz-05 | RedAmber -> Green test			| State Machine |
|Req-06| Transitions			| Haz-05 | Green -> Amber test				| State Machine |
|Req-07| Transitions			| Haz-05 | Amber -> Red test				| State Machine |
|Req-08| Timing					| Haz-05 | RedAmber timing test				| Timer |
|Req-09| Timing					| Haz-05 | Amber timing test				| Timer |
|Req-10| Timing					| Haz-04 | Green limited timing test		| Timer |
|Req-11| Green constraint		| Haz-08 | Idefinited Green constraint test | Controller |
|Req-12| Pedestrian behaviour	| Haz-02 | Pedestrian request queue test	| Controller |
|Req-13| Pedestrian invariant	| Haz-02 | All Red during crossing test		| Controller |
|Req-14| Timing					| Haz-02 | Pedestrian duration test			| Timer |
|Req-15| Pedestrian behaviour	| Haz-02 | Pedestrian alert test			| Controller |
|Req-16| Pedestrian behaviour	| Haz-02 | Pedestrian light test			| Controller |
|Req-17| Pedestrian behaviour	| Haz-02 | Resume operation test			| Controller |
|Req-18| Monitoring				| Haz-06 | Signal state monitoring test		| Controller |
|Req-19| Monitoring				| Haz-04 | Sensor monitoring test			| Controller |
|Req-20| Monitoring				| Haz-08 | Pedestrian status test			| Controller |
|Safe-01| Core invariant		| Haz-01 | No conflicting flow test			| Controller |
|Safe-02| Core invariant		| Haz-01 | No dual Green test				| Controller |
|Safe-03| Core invariant		| Haz-01 | No dual Amber test				| Controller |
|Safe-04| Core invariant		| Haz-01 | No dual RedAmber test			| Controller |
|Safe-05| Pedestrian invariant	| Haz-02 | No traffic during crossing test	| Controller |
|Safe-06| Pedestrian invariant	| Haz-02 | All Red reinfircement test		| Controller |
|Safe-07| Pair synchronisation	| Haz-03 | Pair synchronisation test		| Controller |
|Safe-08| Sensor rule			| Haz-04 | Sensor fallback timing test		| Controller |
|Safe-09| Sensor rule			| Haz-05 | Sensor alert timing test			| Controller |
|Safe-10| Fault rules			| Haz-05 | Progression failure test			| Controller |
|Safe-11| Fault rules			| Haz-06 | Illumination failure test		| Controller |
|Safe-12| Fault rules			| Haz-07 | De-Illumination failure test		| Controller |
|Safe-13| Fault off				| Haz-09 | All lights off test				| Controller |
|Safe-14| Fault off				| Haz-09 | Fault alert test					| Controller |
|Safe-15| Fault rules			| Haz-09 | Fault persistence test			| Controller |
|Safe-16| Core invariant		| Haz-01 | Reject unsafe state test			| Controller |
|Time-01| Timing				| Haz-05 | RedAmber timing test				| Timer |
|Time-02| Timing				| Haz-05 | Amber timing test				| Timer |
|Time-03| Timing				| Haz-02 | Pedestrian exact timing test		| Timer |
|Time-04| Green constraint		| Haz-08 | Green constraint test			| Timer |
|Time-05| Timing				| Haz-04 | Green max timing test			| Timer |
|Time-06| Test constraint		|   n/a  | Deterministic time test			| Test Framework |
|Rel-01| Fault rules			| Haz-06 | Feedback mismatch test			| Controller |
|Rel-02| Fault rules			| Haz-05 | Progression failure test			| Controller |
|Rel-03| Fault rules			| Haz-04 | Fault alert test					| Controller |
|Rel-04| State model			| Haz-05 | Deterministic transition test	| State Machine |
|Rel-05| Testability			|   n/a  | Unit test coverage				| Test suite |
|Rel-06| Safety tests			|   n/a  | Safety invariants tests			| Test suite |
|Ver-01| Traceability			|   n/a  | Requirement coverage tests		| Documentation |
|Ver-02| TDD					|   n/a  | Failing test evidence			| Git history |
|Ver-03| Formal mapping			|   n/a  | Invariant mapping check			| Documentation |
|Ver-04| Traceability			|   n/a  | Test linkage check				| Documentation |
|Ver-05| TDD					|   n/a  | Commit sequence validation 		| Git history |
|Ver-06| Verification			|   n/a  | Test result evidence				| Test reports |
|Ver-07| Traceability			|   n/a  | Matrix completness check			| Documentation |

---

## Notes
	
	each requirement is linked to at least one test
	all safety requirements are enforced via formal invariants
	all hazards are mitigated though implementation and verified by tests
