using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalls : MonoBehaviour
{
    public Transform FirePosition;
    public GameObject FireBall;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(FireBall, FirePosition.position, FirePosition.rotation);
        }
    }
}