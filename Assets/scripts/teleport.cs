﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform next;
    public GameObject player;
    public Vector3 offsetSpawn = new Vector3(1, 0, 0);
    public CharacterController charController;
    public CharMove playerScript;

    void Start()
    {
        charController = player.GetComponent<CharacterController>();
        playerScript = player.GetComponent<CharMove>();
        Debug.Log("howdy");
        //charController.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject == player)
        {
            Debug.Log(col.name + "trigger enter");
            Debug.Log(col.gameObject.transform.position);
            Debug.Log(next.position + Vector3.Scale(next.forward, offsetSpawn));
            // Instantiate(player, next.position, player.transform.rotation);

            charController.enabled = false;
            player.transform.position = next.position + Vector3.Scale(next.up, offsetSpawn);
            charController.enabled = true;

            playerScript.lastMirror = playerScript.thisMirror;
            playerScript.thisMirror = player.transform.position;
            
            //Destroy(col.gameObject);
            //player.transform.Translate(0, 1000, 0);
            //Destroy(player);
            //}
        }
        else
        {
            col.gameObject.transform.position = next.position + Vector3.Scale(next.up, offsetSpawn);
        }
    }
}