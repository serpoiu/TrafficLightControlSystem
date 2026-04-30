# Readme First

## Important Architectural Note

The implementation intentionally consolidates the system in a single controller class.

I'm aware that this approach does not follow SOLID and KISS principles.
The decision was taken due to factors outside of the module and time constaints.

The Single Responsability Principle is breached by clumping together:
	state transitions,
	timing logic,
	safety constraints,
	pedestrian handling,
	fault handling

The KISS principle is not respected as the single class become larger and more
difficult to read and follow. Normally I would have split the code in smaller components
easier to read and to manage. 

---

## Reasoning

This design decision was made because of time constraints and priorities.
The focus was mainly on TDD and the formal specification alignment.

By using a single large class, the tests were directly mapped
and the implementation became "just addd the next method to pass the tests".

---

## Trade-offs 

This approach led to a code that is:
	difficult to maintain
	has tight coupling

I ended recreating a version of the UglyClient from the Software Engineering Module yeasr 2