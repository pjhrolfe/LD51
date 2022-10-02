using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour {
    public float camera_height;
    public Vector2 camera_height_bounds = new Vector2(0f, 100f);
    public float rounding_factor = 5f;
    public Transform player_transform;
    
    public void Update() {
        camera_height = Mathf.Round(player_transform.position.y * rounding_factor) / rounding_factor;

        if (camera_height < camera_height_bounds.x) {
            camera_height = camera_height_bounds.x;
        } else if (camera_height > camera_height_bounds.y) {
            camera_height = camera_height_bounds.y;
        }
        
        transform.position = new Vector3(0, camera_height, -10);
    }
}
