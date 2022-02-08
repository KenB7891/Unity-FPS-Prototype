using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    // 3rd Person View Camera
    // private Vector3 offset = new Vector3(0, 8, -11);

    // Top-down view Camera
    private Vector3 offset = new Vector3(0, 20, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
