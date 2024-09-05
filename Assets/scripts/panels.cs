using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panels : MonoBehaviour
{
    public Transform top;
    public Transform bottom;
    public float speed =  5f;

    private float leftEdge;
    [SerializeField] GameObject SpawnElement;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10f;
    }

    private void Update()
    {
        if (transform.position.x > 0 || transform.position.x < -1)
        {
            SpawnElement.SetActive(false);
        }
        else
        {
            SpawnElement.SetActive(true);
        }
        transform.position += speed * Time.deltaTime * Vector3.left;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
