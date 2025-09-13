using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject target;

    [SerializeField]
    private int distance;
    [SerializeField]
    private float speed;

    private Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = startingPos;
        v.x += distance * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            RangeWorld.instance.killCount++;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
