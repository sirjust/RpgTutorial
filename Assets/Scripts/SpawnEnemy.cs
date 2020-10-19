using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyEncounterPrefab;

    private bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (this.spawning) Instantiate(enemyEncounterPrefab);
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.spawning = true;
            SceneManager.LoadScene("Battle");
        }
    }
}
