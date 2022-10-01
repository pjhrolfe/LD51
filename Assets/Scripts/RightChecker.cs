using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightChecker : MonoBehaviour
{
    public Player player;
    
    public void OnTriggerEnter2D(Collider2D col) {
        if (!col.CompareTag("Player")) {
            player.phys_can_wall_jump_right = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col) {
        if (!col.CompareTag("Player")) {
            player.phys_can_wall_jump_right = false;
        }
    }
}
