using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Game : MonoBehaviour {
    public float ten_second_timer;
    public Tilemap tilemap;
    public Tile water_tile;
    public int water_level = -4;
    public int water_level_rise = 3;
    
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
            for (int i = 0; i < water_level_rise; i++) {
                FillGaps(water_level);
                FillGaps(water_level + i);
            }
            water_level += water_level_rise;
            water_level_rise++;
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
