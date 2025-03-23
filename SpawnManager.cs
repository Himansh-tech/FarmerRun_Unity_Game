using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(37, 0, 0);
    public float startDelay = 2f;
    public float repeatRate = 2f;


    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacle()
    {

        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
       
}
