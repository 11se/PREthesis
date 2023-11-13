using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    
    public void Initialise()
    {
        
        ChangeState(new AttackState());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        // activeState != null
        if(activeState!= null)
        {
            activeState.Exit();
        }
        // Change to new State.
        activeState = newState;

        //fail-safe null check to make sure new state wasn't null
        if(activeState != null)
        {
            //Setup new State
            activeState.stateMachine = this;
            activeState.enemy =GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
