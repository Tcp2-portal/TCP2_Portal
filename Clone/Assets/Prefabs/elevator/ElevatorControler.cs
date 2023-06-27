using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ElevatorControler : MonoBehaviour
{
    private Dictionary<ElevatorState, string> elevatorStates;
    public ElevatorState state;
    private Animator animator;  
     private void Awake()
    {   
        this.animator = GetComponent<Animator>();
        
        elevatorStates = new Dictionary<ElevatorState, string>();
        elevatorStates.Add(ElevatorState.Up, "Up");
        elevatorStates.Add(ElevatorState.Down, "Down");
        elevatorStates.Add(ElevatorState.Inicialize, "Start");
        elevatorStates.Add(ElevatorState.End, "End");
    }
    public void Initialize()
    {
        state = ElevatorState.Inicialize;
        this.animator.SetTrigger(elevatorStates[state]);
    }
    public void End()
    {
        state = ElevatorState.End;
        this.animator.SetTrigger(elevatorStates[state]);
    }
    public void Up()
    {
        state = ElevatorState.Up;
        this.animator.SetTrigger(elevatorStates[state]);
    }
    public void Down()
    {
        state = ElevatorState.Down;
        this.animator.SetTrigger(elevatorStates[state]);
    }
}
[System.Serializable]
public enum ElevatorState{
    Default,
    Up,
    Down,
    Inicialize,
    End
}
