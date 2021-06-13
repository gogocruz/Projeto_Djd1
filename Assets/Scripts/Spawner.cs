using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fallingObject;
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float maxSpawnDistance = 20.0f;
    [SerializeField]
    private float spawnDelay = 0.75f;

    private bool isActive;
    private float delayTimer;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        delayTimer = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            SpawnObject();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collidingObject = collision.gameObject;

        if (collidingObject.tag == "Player")
        {
            isActive = true;
            Debug.Log("Player is in danger zone");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collidingObject = collision.gameObject;

        if (collidingObject.tag == "Player")
        {
            isActive = false;
            //Debug.Log("Player left the danger zone");
        }
    }

    private void SpawnObject()
    {
        delayTimer -= Time.deltaTime;
        if (delayTimer <= 0 )
        {
            float leftSpawnMargin = player.position.x - maxSpawnDistance;
            float rightSpawnMargin = player.position.x + maxSpawnDistance;
            float height = camera.position.y + 90;
            float xSpawnPoint = Random.Range(leftSpawnMargin, rightSpawnMargin);

            Instantiate(fallingObject, new Vector3(xSpawnPoint, height, 0), Quaternion.identity);
            delayTimer = spawnDelay;
        }
    }
}
