using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCombat : MonoBehaviour
{
    [SerializeField] GameObject _combatCanvas;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Debug.Log(collision.collider.gameObject.name);
        AiMovement aiMove = collision.collider.gameObject.GetComponent<AiMovement>();

        if (aiMove == null)
        {
            return;
        }

        Debug.Log("WE HAVE HIT AN AI");
        _combatCanvas.SetActive(true);
        
        Time.timeScale = 0;
        //Time.timeScale =1; //unpauses the game
    }



}

