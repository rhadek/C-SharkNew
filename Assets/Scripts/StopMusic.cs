using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class StopMusic : MonoBehaviour
{
    public static void Awake()
    {
        GameObject musicObject = GameObject.FindWithTag("Music");
        if (musicObject != null)
        {
            AudioSource musicSource = musicObject.GetComponent<AudioSource>();
            musicSource.Stop();
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(musicObject);
        }
        else
        {
            DontDestroyOnLoad(musicObject);
        }

    }
}
