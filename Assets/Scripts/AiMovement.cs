using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 3;
    ////an array of GameObjets
    public List<Transform> waypoints;
    //public Transform[] waypoints;
    public int waypointIndex = 0;
    public GameObject waypointPrefab;


    //public GameObject position0;
    //public GameObject position1;
    public float speed = 1.5f;
    public float minGoalDistance = 0.1f;


    /*  public void Update()
      {
          Debug.Log(waypoints.Length);
          //are we within the player chase distance
          if (Vector2.Distance(transform.position, player.position) < chaseDistance)
          {
              AIMoveTowards(player);
          }

          else
          {
              WaypointUpdate();
              AIMoveTowards(waypoints[waypointIndex].transform);
          }
          //the number is called the index [NUMBER]


          //Moves towards our waypoints
          //
      }
     */

    private void Start()
    {
        NewWaypoints();
        NewWaypoints();
        NewWaypoints();
        NewWaypoints();
        NewWaypoints();
    }

    public void NewWaypoints()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);

        GameObject newPoint = Instantiate(waypointPrefab, new Vector2(x,y), Quaternion.identity);

        waypoints.Add(newPoint.transform);
    }


    public void LowestDistance()
    {
        float lowestDistance = float.PositiveInfinity;
        int lowestIndex = 0;
        float distance;

        for (int i = 0; i < waypoints.Count; i++)
        {
            distance = Vector2.Distance(player.position, waypoints[i].position);
            if (distance >= lowestDistance)
            {
                lowestDistance = distance;
                lowestIndex = i;
            }
            waypointIndex = lowestIndex;

        }
    }



    public void WaypointUpdate()
    {

   


        Vector2 AiPosition = transform.position;
        if (Vector2.Distance(AiPosition, waypoints[waypointIndex].position) < minGoalDistance)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Count)
            {
                //sets array back to 0, goes back to first diamond in array
                waypointIndex = 0;
            }

        }

        
    }

    public void AIMoveTowards(Transform goal)
    {


        Vector2 AiPosition = transform.position;

        //if we are not near the goal
        if (Vector2.Distance(AiPosition, goal.position) > minGoalDistance)
        {
            //direction from A to B
            Vector2 directionToGoal = (goal.transform.position - transform.position);
            directionToGoal.Normalize();
            transform.position += (Vector3)directionToGoal * speed * Time.deltaTime;
        }
    }


}

