using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject block; 
    public float maxX;
    public RectTransform spawnPoint;
    public float spawnRate;
    public Slider slider;
    public List<GameObject> tutorialObjs;

    bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        slider.GetComponent<TimeBar>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            this.disableTutorial();
            slider.GetComponent<TimeBar>().enabled = true;
            StartSpawning();
            gameStarted = true;
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);


        Instantiate(block, spawnPos, Quaternion.identity);
    }

    private void disableTutorial()
    {
        foreach(GameObject obj in this.tutorialObjs)
        {
            obj.SetActive(false);
        }
    }

}
