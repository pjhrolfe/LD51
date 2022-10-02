using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour {
    public float camera_height;
    public float rounding_factor = 5f;
    public Transform player_transform;
    
    public void Update() {
        camera_height = Mathf.Round(player_transform.position.y * rounding_factor) / rounding_factor;
        transform.position = new Vector3(0, camera_height, -10);
    }
}
