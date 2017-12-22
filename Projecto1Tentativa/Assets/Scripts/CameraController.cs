using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    public Transform player;
    public Transform losingBoundary;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        if (transform.position.y < player.position.y + offset.y)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z), 5f*Time.deltaTime);
            losingBoundary.position = new Vector3(0, player.position.y + offset.y, 0);
        }
    }
}
