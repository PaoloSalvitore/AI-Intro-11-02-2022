using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public GameObject position0;
    public GameObject position1;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        Vector2 AiPosition = transform.position;

        /*
         * Method 1
        if (transform.position.x < position0.transform.position.x)
        {

            AiPosition.x += (1 * Time.deltaTime);
            transform.position = AiPosition;
            //move right
        }

        else
        {
            AiPosition.x -= (1 * Time.deltaTime);
            transform.position = AiPosition;
            //move left
        }

        if (transform.position.y < position0.transform.position.y)
        {
            transform.position += (Vector3) Vector2.up * 1 * Time.deltaTime;
         
        }

        else
        {
            transform.position -= (Vector3) Vector2.up * 1 * Time.deltaTime;
          
        }
        */

        //method 3

        Vector2 directionToPos0 = (position0.transform.position - transform.position);
        directionToPos0.Normalize();
        transform.position += (Vector3) directionToPos0 * 1 * Time.deltaTime;

    }




    //THE END
}
