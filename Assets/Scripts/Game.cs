using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public float ten_second_timer;
    
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update() {
        ten_second_timer += Time.deltaTime;

        if (ten_second_timer >= 10) {
            Debug.Log("10 seconds has passed");
            ten_second_timer = 0;
        }
     }

    void Setup() {
        ten_second_timer = 0f;
    }
}
