using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class tileMap : MonoBehaviour {
    /*public TileType[] tileTypes;
    int[,] tiles;
    Node[,] graph;
    int mapSizeX = 10;
    int mapSizeY = 10;
    public GameObject selectedUnit;

    List<Node> currentPath = null;

    void Start()
    {
        generateMapData();
        //generatePathFindingGarph();
        generateMapVisuals();
    }
    public void generateMapData()
    {
        tiles = new int[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }
        tiles[1, 3] = 2;
        tiles[2, 3] = 2;
        tiles[3, 3] = 2;
        tiles[3, 2] = 2;
        tiles[3, 1] = 2;

        tiles[8, 6] = 2;
        tiles[7, 6] = 2;
        tiles[6, 6] = 2;
        tiles[6, 7] = 2;
        tiles[6, 8] = 2;
    }
    //-----------------------------
    class Node
    {
        public List<Node> neighbours;
        public int x;
        public int y;

        public Node()
        {
            neighbours = new List<Node>();
        }
        public float getDistanceTo(Node n)
        {
            return Vector2.Distance(new Vector2(x, y), new Vector2(n.x, n.y));
        }
    }
    //------------------------------

    void generatePathFindingGarph()
    {
        graph = new Node[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                graph[x, y].x = x;
                graph[x, y].y = y;

                if (x > 0)
                    graph[x, y].neighbours.Add(graph[x-1, y]);
                if (x < mapSizeX - 1)
                    graph[x, y].neighbours.Add(graph[x + 1, y]);
                if (y > 0)
                    graph[x, y].neighbours.Add(graph[x, y - 1]);
                if (y < mapSizeY - 1)
                    graph[x, y].neighbours.Add(graph[x, y + 1]);
            }
        }
    }
    void generateMapVisuals()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                //Debug.LogError(tiles[x, y]);
                TileType tt = tileTypes[tiles[x, y]];
                GameObject go = (GameObject) Instantiate(tt.tileVisualPrefab, new Vector3(x, y, 0), Quaternion.identity);

                ClickableTile ct = go.GetComponent<ClickableTile> ();
                ct.tileX = x;
                ct.tileY = y;
                ct.map = this;
            }
        }
    }
    public Vector3 getTileCoordToWorldCoord(int x, int y)
    {
        return new Vector3(x, y, 0);
    }
    public void moveSelectedUnitTo(int x, int y)
    {
       
    }*/
}
