using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntEnemy : MonoBehaviour
{
    [SerializeField] MG1Manager mg1Manager;
    [SerializeField] private float despawnDist;
    [SerializeField] private float moveSpeed;
    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, initialPos) >= despawnDist)
        {
            Destroy(this.gameObject);
        }

        if (mg1Manager.StartSpawning == false)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (mg1Manager.StartSpawning == false)
        {
            return;
        }

        if (collision.CompareTag("Grabber"))
        {
            mg1Manager.MG1Lose();
            Destroy(this.gameObject);
        }
    }
}
