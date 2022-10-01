using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour {
    public float phys_gravity;
    public float phys_jump_power = 5f;
    public float phys_wall_jump_power = 1f;
    public float phys_run_power = 2f;
    public float phys_air_control_factor = 0.25f; // ALWAYS LESS THAN 1!
    public float max_delta_time = Single.MinValue;
    public float min_delta_time = Single.MaxValue;
    public Vector2 phys_velocity;
    [FormerlySerializedAs("phys_is_grounded")] public bool phys_grounded;
    [FormerlySerializedAs("phys_hit_ceiling")] public bool phys_celinged;
    public bool phys_can_wall_jump_left;
    public bool phys_can_wall_jump_right;

    private Rigidbody2D rb2d;

    void Start() {
        // rb2d = GetComponent<Rigidbody2D>();
        phys_velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update() {
        if (Time.fixedDeltaTime > max_delta_time) {
            max_delta_time = Time.fixedDeltaTime;
        } else if (Time.fixedDeltaTime < min_delta_time) {
            min_delta_time = Time.fixedDeltaTime;
        }
        
        if (!phys_grounded && !phys_celinged) {
            phys_velocity.y -= phys_gravity * Time.fixedDeltaTime;
        } else if (phys_celinged) {
            phys_velocity.y = 0;
            transform.Translate(0, -0.01f, 0);
        } else {
            phys_velocity.y = 0;
        }
        
        if (phys_grounded && !phys_celinged) {
            phys_velocity.x = phys_run_power * Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        } else {
            // phys_velocity.x = phys_run_power * phys_air_control_factor * Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        }

        if (Input.GetButton("Jump") && phys_grounded) {
            phys_velocity.y = phys_jump_power;
        } else if (Input.GetButtonDown("Jump") && phys_can_wall_jump_left) {
            Debug.LogWarning("LeftWallJump here");
            phys_velocity = new Vector2(0.8f, 1.5f) * phys_wall_jump_power;
        } else if (Input.GetButtonDown("Jump") && phys_can_wall_jump_right) {
            Debug.LogWarning("RightWallJump here");
            phys_velocity = new Vector2(-0.8f, 1.5f) * phys_wall_jump_power;
        }

        // rb2d.MovePosition(new Vector2(transform.position.x, transform.position.y) + phys_velocity);
        transform.Translate(new Vector3(phys_velocity.x, phys_velocity.y));
    }

    private void FixedUpdate() {
        transform.Translate(new Vector3(phys_velocity.x, phys_velocity.y));
    }
}
