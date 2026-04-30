# Requirements Specification

## System

Traffic Light Control System for a UK 4-way junction

The junction has two synchronised  road pairs:

North/South pair
East/West pair

Each traffic light installation supports the following states:

Red
Red + Amber
Green
Amber
Off

Each instalation also have:

Traffic sensor
Pedestrian crossing subsystem
Light feedback monitoring

---

## Functional Requirements

| ID | Requirement |
|---|---|
|Req-01| The system shall controll four traffic light instalations in a 4-way junction |
|Req-02| The North and South installations shall operate as a synchronised pair |
|Req-03| The East and West installations shall operate as a synchronised pair |
|Req-04| A traffic kight showing Red shall transition to Red + Amber |
|Req-05| A traffuc light showing Red + Amber shall transition to Green |
|Req-06| A traffic light showing Green shall transition to Amber |
|Req-07| A traffic light showing Amber shall transition to Red |
|Req-08| Red + Amber shall be maintained for 1.5 seconds |
|Req-09| Amber shall be maintained for 1.5 seconds |
|Req-10| Green shall be maintained for 30 seconds when the intersecting road has waiting traffic or a pedestrian request is pending |
|Req-11| Green may be maintained indifinitely when the intersecting road has no waiting traffic and no pedestrian request is pending |
|Req-12| A pedestrian request shall be queued until next safe all-Red state |
|Req-13| When pedestrian are crossing, all traffic lights shall remain Red |
|Req-14| Pedestrian crossing mode shall last 15 seconds |
|Req-15| During pedestrian crossing mode, the pedestrian alert shall sound |
|Req-16| During pedestrian crossing mode, the pedrestian crossing shall illuminate |
|Req-17| After pedestrian crossing mode ends, normal traffic light operation shall resume |
|Req-18| The control software shall monitor the current displayed state of each traffic light installation |
|Req-19| The control software shall monitor taffic sensor status for each installation |
|Req-20| The control software shall monitor pedestrian request status |

---

## Safety Requirements

| ID | Requirement |
|---|---|
|Safe-01| Intersecting road pairs shall never display a signal that allows traffic to pass at the same time |
|Safe-02| North/South and East/West shall never both display Green simultanously |
|Safe-03| North/South and East/West shall never both display Amber simultanously |
|Safe-04| North/South and East/West shall never both display Red + Amber simultanously |
|Safe-05| Traffic shall not be allowed to pass while pedestrians are crossing |
|Safe-06| During pedestrian crossing mode, all traffic installations shall display Red |
|Safe-07| Paired installations shall always display identical signals |
|Safe-08| If a traffic sensor fails, the affected control logic shall use a fixed 30 seconds Green limit |
|Safe-09| If a traffic sensor fails, the system shall raise a sensor fault alert |
|Safe-10| If an installtion does not progress to the next expected signal, the system shall enter fault-off state |
|Safe-11| If a light fails to illuminate as expected, the system shall enter fault-off state |
|Safe-12| If a light fails to de-illuminate as expected, the system shall enter fault-off state |
|Safe-13| In fault-off state, all traffic light installations shall display no lights |
|Safe-14| In fault-off state, the system shall rise a fault alert |
|Safe-15| The system shall not leave fault-off state automatically |
|Safe-16| Unsafe signal combinations shall be rejected by the control logic |

---

## Timing Requirements

| ID | Requirements |
|---|---|
|Time-01| Red + Amber duration shall be exactly 1.5 seconds |
|Time-02| Amber dureation shall be exactly 1.5 seconds |
|Time-03| Pedestrian crossing shall be exactly 15 seconds |
|Time-04| Green duration shall be limited to 30 seconds when opposing traffic is waiting or pedestrian request is pending |
|Time-05| Green duration may exceed 30 seconds when opposing traffic is not waiting and no pedestrian request is pending |
|Time-06| Timing tests shall use controlled test time rather than real-time delays |

---

## Reliability Requirements

| ID | Requirements |
|---|---|
|Rel-01| The system shall fail safely when light feedback does not match the command signal |
|Rel-02| The system shall fail safely when signal progression does not occur as expected |
|Rel-03| The system shall raise alerts for detected hardware or sensor faults |
|Rel-04| The system shall maintain deterministic state transitions |
|Rel-05| The system shall support automated unit testing of all state stransitions |
|Rel-06| The system shall support automated testing of all safey constraints |

---

## Verification Requirements

| ID | Requirements |
|---|---|
|Ver-01| Each requirement shall have at least one corresponding test case |
|Ver-02| Tests shall be written before implementation code |
|Ver-03| Eaxh safety requirement shall be limked to a formal invariant |
|Ver-04| Each test shall be traceable to a requirement ID |
|Ver-05| Git commit history shall show failing tests before passing implementation |
|Ver-06| The final submission shall include test results as verification evidence |
|Ver-07| The final submission shall include a requirements traceability matrix |