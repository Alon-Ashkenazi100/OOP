using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .1555f;

        private Tile[,] tiles;

        #region Unity Functions

        // Use this for initialization
        void Start()
        {
            // Generate tiles on startup
            GenerateTiles();
        }
        // Update is called once per frame
        void Update()
        {
            // LET mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition)
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // LET hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction)
            RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);

            // IF hit.collider != null
            if (hit.collider != null)
            {
                // <datatype> <variablename> ;
                // LET hitTile = hit.collider.GetComponent<Tile>()
                Tile hitTile = hit.collider.GetComponent<Tile>();

                // IF hitTile != null
                if (hitTile != null)
                {
                    // LET adjacent Mines = GetAdjacentMineCountAt(hitTile)
                    int adjacentMines = GetAdjacentMineCount(hitTile);

                    // CALL hitTile.Reveal(adjacentMines)
                    hitTile.Reveal(adjacentMines);
                }
                {
                    // Check if Mouse Button is pressed
                    if (Input.GetMouseButtonDown(0))
                    {
                        // Run the method for selecting tiles
                        SelectATile();
                    }
                }
            }
        }

        void SelectATile()
        {
            // Generate a ray from the camera with mouse position
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Perform raycast
            RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);

            // If the mouse hit something
            if (hit.collider != null)
            {
                // Try getting a Tile component from the thing we hit
                Tile hitTile = hit.collider.GetComponent<Tile>();
                // Check if the thimg it hit was a Tile
                if (hitTile != null)
                {
                    // Get a count of all mines around the hit tile
                    int adjacentMines = GetAdjacentMineCount(hitTile);
                    // Reveal what that hit tile is
                    hitTile.Reveal(adjacentMines);
                }
            }
        }
        #endregion

        #region Custom Functions
        // Spawns tiles in a grid-like pattern
        void GenerateTiles()
        {
            // Create new 2D array of size width x height
            tiles = new Tile[width, height];

            // Loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Store half size for later use
                    Vector2 halfSize = new Vector2(width / 2, height / 2);

                    // Pivot tiles around Grid
                    Vector2 pos = new Vector2(x - halfSize.x,
                                              y - halfSize.y);
                    pos.x += .5f;
                    pos.y += .5f;

                    // Apply spacing
                    pos *= spacing;

                    // Spawn the tile
                    Tile tile = SpawnTile(pos);
                    // Attach newly spawned tile to
                    tile.transform.SetParent(transform);
                    // Store it's array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    // Store tile in array at those coordinates
                    tiles[x, y] = tile;

                }
            }
        }
        // Functionality for spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            // Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; // position tile
            Tile currentTile = clone.GetComponent<Tile>(); // Get Tile component
            return currentTile; //return it
        }
        #endregion

        public int GetAdjacentMineCount(Tile tile)
        {
            // Set count to 0
            int count = 0;
            // Loop through all adjacent tiles on the X
            for (int x = -1; x <= 1; x++)
            {
                // Loop through all adjacent tiles on the Y
                for (int y = -1; y <= 1; y++)
                {
                    // Calculate which adjacent tile to look at
                    int desiredX = tile.x + x;
                    int desiredY = tile.y + y;
                    // Select current tile
                    Tile currentTile = tiles[desiredX, desiredY];
                    // Checdk if that tile is a mine
                    if(currentTile.isMine)
                    {
                        // Increment count by 1
                        count++;
                    }
                }
            }
 
            // Remember to return the count!
            return count;
        }
    }
}
