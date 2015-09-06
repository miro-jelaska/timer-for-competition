# Competition timer
## Timer has following primary steps:
0. Idle state (Menu)
1. Preparation time
2. Presentation time
3. Q&A time

## Features:
1. Large counter (format: "mm:ss" and "ss")
2. Easy to customize
3. Pause/continue function
4. Timer durations can be changed in Competition.Timer/app.config
5. In general, if the state is finished earlier the remaining time is transfered to next state (e.g. someone spends 1 out of 5 min for preparation, remaining 4min are transfered to presentation time)
6. There are sound notifications when there is 15sec left, and when time's up

## Minor "Problems":
1. Timer doesn't start immediately. It takes <= 1sec to start.
2. Timer doesn't continue immediately. It takes <= 1sec to start.
3. No Dependency Injection Container was used

# Short implementation notes
## States
These are all the states and transitions (commands) in Timer.
![All states and transition](https://raw.githubusercontent.com/MiroslavJelaska/timer-for-competition/master/readme-resources/StateDiagram.png)
* Time can be transfered between states using TimeProvider which is injected in state
* All transitions are registered in Rules/Transition

# Usage
Timer was used on _(this list may become outdated)_:
* Microsoft ImagineCup final (27.3.2014., [FESB](https://www.fesb.unist.hr/))
* DUMP Young Programmers Association - Internship competition (2015., [DUMP](http://www.dump.hr/))
