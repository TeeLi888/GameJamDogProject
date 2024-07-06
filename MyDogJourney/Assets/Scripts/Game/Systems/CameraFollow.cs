using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public BoxCollider2D saveZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float leftMost = saveZone.transform.position.x - (saveZone.size.x / 2);
        float rightMost = saveZone.transform.position.x + (saveZone.size.x / 2);
        float xPos = Mathf.Clamp(target.position.x, leftMost, rightMost);
        if(target.position.x < leftMost)
        {
            transform.position += new Vector3(target.position.x - leftMost, 0, 0);
        }
        else if(target.position.x > rightMost)
        {
            transform.position += new Vector3(target.position.x - rightMost, 0, 0);
        }
    }
}
