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


	public virtual void Enter()
	{
	}

	public virtual void Exit()
	{
	}

	public virtual void Trans()
	{
	}

	public virtual void Update()
	{
	}
}