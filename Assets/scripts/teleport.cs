﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform next;
    public GameObject player;
    public Vector3 offsetSpawn = new Vector3(1,0,0);
    public CharacterController charController;
    void Setup()
    {
        //charController = player.GetComponent<CharacterController>();
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