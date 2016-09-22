﻿/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;

public class NotifyComplete : MonoBehaviour {

  public int numRobotsForCompletion = 4;

  private int num_robots_ = 0;

  public delegate void NotifyCompleted();
  public static event NotifyCompleted OnCompleted;

  public delegate void NotifyIncompleted();
  public static event NotifyIncompleted OnIncompleted;

  void OnEnable() {
    RobotHead.OnBootUp += IncrementRobot;
    RobotHead.OnShutDown += DecrementRobot;
  }

  void OnDisable() {
    RobotHead.OnBootUp -= IncrementRobot;
    RobotHead.OnShutDown -= DecrementRobot;
  }

  void IncrementRobot() {
    num_robots_++;
    if (num_robots_ == numRobotsForCompletion)
      OnCompleted();
  }

  void DecrementRobot() {
    if (num_robots_ == numRobotsForCompletion)
      OnIncompleted();
    num_robots_--;
  }
}
