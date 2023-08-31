using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public string axis = "Horizontal";
    public float speed = 1.0f;
    public float range = 1.0f;
    private float startPosY;
    private float startPosZ;
    private float direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        startPosY = transform.position.y;
        startPosZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 orientation = Vector3.zero;
        if (axis == "Horizontal")
        {
            if (transform.position.z - startPosZ < -range || transform.position.z - startPosZ > range)
            {
                direction = -direction;
            }
            orientation = Vector3.forward;
        }
        else if (axis == "Vertical")
        {
            if (transform.position.y - startPosY < -range || transform.position.y - startPosY > range)
            {
                direction = -direction;
            }
            orientation = Vector3.up;
        }
        transform.Translate(orientation * Time.deltaTime * direction * speed);
    }
}
