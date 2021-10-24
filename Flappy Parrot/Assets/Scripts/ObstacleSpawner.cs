using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float maxTime = 1f;
    public float height;
    private float timer = 0;
    public GameObject obstacle;

    void Start()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(newObstacle, 15);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
