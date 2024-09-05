using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefab;
    public float spawnRate = 2f;
    public float minHeight = -1f;
    public float maxHeight = 2f;
    int NumberOfPlanel;

    private void Start()
    {
        Spawn();
    }
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        if (NumberOfPlanel ==5 || NumberOfPlanel == 6)
        {
            while (NumberOfPlanel == 5 || NumberOfPlanel == 6)
            {
                NumberOfPlanel = UnityEngine.Random.Range(0, prefab.Length);
            }
        }
        else
        {
            NumberOfPlanel = UnityEngine.Random.Range(0, prefab.Length);
        }

        GameObject pipes = Instantiate(prefab[NumberOfPlanel], transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        
        
    }
}
