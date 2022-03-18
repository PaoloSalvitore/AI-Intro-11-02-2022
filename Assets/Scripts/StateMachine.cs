using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Attack,
        Defence,
        RunAway,
        BerryPicking
    }

    public State currentState;
    public AiMovement aiMovement;

    private void Start()
    {
        aiMovement = GetComponent<AiMovement>();
        NextState();

    }

    public void NewWaypoint()
        {

        }
        




    private void NextState()
    {

        //runs one of the case that matches the value (in this example the value is currentState)
        switch (currentState)
        {
            case State.Attack:
                StartCoroutine(AttackState());
                break;
            case State.Defence:
                StartCoroutine(DefenceState());
                break;
            case State.RunAway:
                StartCoroutine(RunAwayState()); 
                break;
            case State.BerryPicking:
                StartCoroutine(BerryPickingState());
                break;
        }
    }

    //Coroutine is a special method that can be paused and returned to later

    private IEnumerator AttackState()
    {
        Debug.Log(message:"Attack: Enter");
        while (currentState == State.Attack)
        {

            aiMovement.AIMoveTowards(aiMovement.player);
            if (Vector2.Distance(transform.position, aiMovement.player.position)
                >= aiMovement.chaseDistance)
            {
                currentState = State.BerryPicking;
            }
            Debug.Log(message: "Currently Attacking");
            yield return null;
        }
        Debug.Log(message: "Attack: Exit");
        NextState();

      //  Debug.Log(message: "First Log Attack");
        //yield returns pauses running of our coroutine
      //  yield return new WaitForSeconds(3f);
      //  yield return null;
      //  Debug.Log(message: "Second Log Attack");

       /* while (currentState==State.Attack)
        {
            Debug.Log(message: "Attack");
        }
       */
    }

    private IEnumerator DefenceState()
    {
        Debug.Log(message: "Defence: Enter");
        while (currentState == State.Defence)
        {
            Debug.Log(message: "Currently Defending");
            yield return null;
        }
        Debug.Log(message: "Defence: Exit");
        NextState();

    }
    private IEnumerator RunAwayState()
    {
        Debug.Log(message: "RunAway: Enter");
        while (currentState == State.RunAway)
        {
            Debug.Log(message: "Currently Running Away");
            yield return null;
        }
        Debug.Log(message: "RunAway: Exit");
        NextState();


    }
    private IEnumerator BerryPickingState()
    {
        Debug.Log(message: "BerryPicking: Enter");

        aiMovement.LowestDistance();

        while (currentState == State.BerryPicking)
        {
            
            aiMovement.WaypointUpdate();
            aiMovement.AIMoveTowards(aiMovement.waypoints[aiMovement.waypointIndex]);


            if (Vector2.Distance(transform.position, aiMovement.player.position) < aiMovement.chaseDistance)
            {
                currentState = State.Attack;
            }


            yield return null;
        }
        Debug.Log(message: "BerryPicking: Exit");
        NextState();

    }




}
