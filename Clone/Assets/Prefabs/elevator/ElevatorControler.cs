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
    }
    public void Up()
    {
        state = ElevatorState.Up;
    }
    public void Down()
    {
        state = ElevatorState.Down;
    }
    private void Update()
    {
        this.animator.SetTrigger(elevatorStates[state]);
    }
}
public enum ElevatorState{
    Up,
    Down
}
