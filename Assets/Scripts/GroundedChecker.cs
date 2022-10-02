using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker : MonoBehaviour {
    public Player player;
    
    public void OnTriggerEnter2D(Collider2D col) {
        if (!col.CompareTag("Player")) {
            player.phys_grounded = true;
            AudioManager.Instance.Play("Hit");
        }
    }

    public void OnTriggerExit2D(Collider2D col) {
        if (!col.CompareTag("Player")) {
            player.phys_grounded = false;
        }
    }
}
