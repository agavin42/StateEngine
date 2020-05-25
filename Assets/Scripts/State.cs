using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class State
{
	StateManager Manager;
	float StartTime;

	public State() {}

	public void Start(StateManager manager)
	{
		Manager = manager;
		StartTime = Time.time;		
	}

	public State Trans()
	{
		return null;
	}

	public void Update()
	{
	}
}