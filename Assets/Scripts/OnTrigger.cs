using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class OnTrigger : MonoBehaviour
{
    public float minY;
    public float maxY;

    private float oldPosition;
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = 8;
        minY = -1;
        maxY = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Wall");
        obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
    }
}
