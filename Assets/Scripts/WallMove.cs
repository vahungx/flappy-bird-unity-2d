using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float moveSpeed;
    public double moveRange;
    public float minY;
    public float maxY;

    private float oldPosition;
    private GameObject obj;
    void Start()
    {
        obj = gameObject;
        oldPosition = 10;
        moveRange = 20.44;
        moveSpeed = 3;
        minY = -1;
        maxY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0,0));

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ResetWall"))
        {
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY), 0);
        }
    }
}

