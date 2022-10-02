using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Game : MonoBehaviour {
    public float ten_second_timer;
    public Tilemap tilemap;
    public Tile water_tile;
    public int water_level = -4;
    
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update() {
        ten_second_timer += Time.deltaTime;

        if (ten_second_timer >= 10) {
            // Debug.Log("10 seconds has passed");
            ten_second_timer = 0;
            FillGaps(water_level);
            water_level++;
        }
     }

    void Setup() {
        ten_second_timer = 0f;
        Debug.LogWarning(tilemap.cellBounds);
    }

    public void FillGaps(int row) {
        for (int i = tilemap.cellBounds.xMin; i < tilemap.cellBounds.xMax; i++) {
            // Debug.Log(tilemap.GetTile(new Vector3Int(i, row, 0)));
            if (tilemap.GetTile(new Vector3Int(i, row, 0)) == null) {
                Debug.LogWarning("NULL at " + i + " " + row);
                tilemap.SetTile(new Vector3Int(i, row, 0), water_tile);
            }
        } 
    }
}
