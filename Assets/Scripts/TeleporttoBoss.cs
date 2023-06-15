using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class TeleporttoBoss : MonoBehaviour
{
    public GameObject teleportDestination; // The place to teleport the player to
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D teleport)
    {
        // Check if the player is on the ground
        if (teleport.gameObject.CompareTag("Player"))
        {
            teleport.gameObject.transform.position = teleportDestination.transform.position;
        }
    }
    

}