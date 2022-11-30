using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTilemapGenerator : MonoBehaviour
{
    [SerializeField] GameObject tileset;
    [SerializeField] Tilemap tilemaps;
    [SerializeField] Tile[] tile;
    [SerializeField] Tile[] tileBase;
    [SerializeField] Tile[] tileDark;
    [SerializeField] int width=5, height;
    
    void Start()
    {
        for (int i = 0; i < width; i++)
        {
            Vector2 pos = new Vector2(i, 0);
            int ranInt = Random.Range(1, tile.Length);
            Instantiate(tile[ranInt], pos, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }

    private int rows = 5;
    private int cols = 8;
    private float tileSize = 1;

    
}
