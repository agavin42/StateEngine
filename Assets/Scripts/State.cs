using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class State
{
	StateManager Manager;
	float StartTime;

	public class StateGoException : System.Exception
	{
		public State NewState;

		public StateGoException (State new_state) : base()
		{
			NewState = new_state;
		}
	}


	public State() {}

	public void Start(StateManager manager)
	{
		Manager = manager;
		StartTime = Time.time;		
	}

	public void Go (State new_state)
	{
		throw new StateGoException(new_state);
	}

	// generic tests if we are in a particular state type, or have inherieted from it
	public bool StateP<T1>()
	{
		return typeof(T1).IsAssignableFrom(this.GetType());
	}
	public bool StateP<T1, T2>()
	{
		return typeof(T1).IsAssignableFrom(this.GetType()) || typeof(T2).IsAssignableFrom(this.GetType());
	}
	public bool StateP<T1, T2, T3>()
	{
		return typeof(T1).IsAssignableFrom(this.GetType()) || typeof(T2).IsAssignableFrom(this.GetType()) || typeof(T3).IsAssignableFrom(this.GetType());
	}

	// amount of time we have been in this state
	public float StateTime()
	{
		return Time.time - StartTime;
	}

	// the previous state object
	public State PrevState()
	{
		return Manager.Previous;
	}

	// generic tests about state type, but for the previous state
	public bool PrevStateP<T1>()
	{
		return (Manager.Previous!=null) && typeof(T1).IsAssignableFrom(Manager.Previous.GetType());
	}

	// check's the MANAGER's current state, which can be used in an exit to check where we are going
	public bool NextStateP<T1>()
	{
		return (Manager.Current!=null) && typeof(T1).IsAssignableFrom(Manager.Current.GetType());
	}



	// Functions to override

	// Called anytime when a state in entered
	public virtual void Enter()
	{
	}

	// Called whenever you leave a state
	public virtual void Exit()
	{
	}

	// Called first in the update for the current state.
	// Intended to rules to test for transitions to new states.
	// Called immediately on going to a new state
	public virtual void Trans()
	{
	}

	// The generic update function for the current state
	public virtual void Update()
	{
	}
}