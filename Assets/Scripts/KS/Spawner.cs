using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject[] prefabs;
    public GameObject spawnParent;
    public Transform tmpSpot;

    public float spawnBorder;
    public float checkSphereRadius;
    public float trySpawnInterval = 1;

    public bool spawning = false;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        DebugSpawn();

        if (spawning == false)
            StartCoroutine(IntervalSpawn());

        StartCoroutine(IntervalSpawn());
        DebugInfo();
	}

    private IEnumerator IntervalSpawn()
    {
        
        FinalSpawn();
        spawning = true;

        yield return new WaitForSeconds(0.2f);

        spawning = false;

    }

    private void FinalSpawn()
    {
        Vector3 pos = GetSpawnPosition();
        Vector3 exception = new Vector3(6, 6, 6);
        if (pos != exception)
            SpawnPrefab(pos);
    }


    private Vector3 randomSpawnPosition()
    {
        float y = spawnBorder;
        float x = Random.Range(-spawnBorder, spawnBorder);
        float z = 0;


        Vector3[] positions = new Vector3[] 
        {
            new Vector3(y,x,z),
            new Vector3(-y,x,z),
            new Vector3(x,y,z),
            new Vector3(x,-y,z)
        };

        int i = Random.Range(0, 4);

        return positions[i];
    }


    private void DebugSpawn()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FinalSpawn();
        }
    }

    private void SpawnPrefab(Vector3 spot)
    {
       float x = Random.Range(-180, 180);
       Quaternion rot0 = Quaternion.Euler(new Vector3(0, 0, x));
       var spawned =  Instantiate(RandomPrefab(), spot, rot0);
       spawned.transform.parent = spawnParent.transform;
    }

    private GameObject RandomPrefab()
    {
        int x = Random.Range(0, prefabs.Length);
        return prefabs[x];
    }

   private Vector3 GetSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3();
        bool test = false;
        int testCount = 0;
        while (test == false)
        {   
            spawnPosition = randomSpawnPosition();
            test = !Physics.CheckSphere(spawnPosition, checkSphereRadius);
            if (testCount >= 500)
            {
                return new Vector3(6, 6, 6);
            }

            testCount++;
        }
        return spawnPosition;
    }

    private void DebugInfo()
    {
        DebugPanel.Log("spawning", spawning);
    }
       
}
