using UnityEngine;
using System.Collections;

public class RTSCamera : MonoBehaviour
{
    float speed = 2;

	void Update ()
    {
        transform.position += Input.GetAxis("Horizontal")* speed * transform.right;
        transform.position += Input.GetAxis("Vertical") * speed * new Vector3(transform.forward.x,0,transform.forward.z).normalized;
    }
}
