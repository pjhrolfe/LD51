using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingChecker : MonoBehaviour
{
    public Player player;
    
    public void OnTriggerEnter2D(Collider2D col) {
        if (!col.CompareTag("Player")) {
            player.phys_celinged = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col) {
        if (!col.CompareTag("Player")) {
            player.phys_celinged = false;
        }
    }
}
