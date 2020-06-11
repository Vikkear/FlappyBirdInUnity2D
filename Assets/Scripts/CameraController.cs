using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTransform;

    public GameObject pipeObject;

    private float nextSpawn = 2f;
    public float spawnInterval = 2f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            SpawnPipe();
            nextSpawn += spawnInterval;
        }
    }

    void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, this.transform.position.y, -1);


    }

    void SpawnPipe()
    {
        Vector3 screenVector = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        float yPos = 0.0f;

        // Determine if upper or lower pipe
        int determinant = Random.Range(1, 3);

        // Upper pipe
        if (determinant == 1)
        {
            yPos = screenVector.y;
        }

        // Lower pipe
        else
        {
            yPos -= screenVector.y;
        }

        Instantiate(pipeObject, new Vector3(screenVector.x, yPos, 0), Quaternion.identity);
    }

}
