using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class Teleport1 : MonoBehaviour
{
    public Animator transition;
    public int game;
    public float transitionTime = 1f;
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
            StartCoroutine(LoadLevel((int)game));
            StopMusic.Awake();
        }
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
