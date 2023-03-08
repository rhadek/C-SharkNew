using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
