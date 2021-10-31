using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorBehaviour : MonoBehaviour
{
    public GameObject room;
    public int width = 5, length = 4, height = 3;
    public float roomWidth = 2, roomLength = 2, roomHeight = 2;
    private List<List<List<RoomBehaviour>>> map;

    private RoomBehaviour outside;

    // Start is called before the first frame update
    void Start()
    {
        GameObject outsideRoom = Instantiate(room, new Vector3(10000, 10000, 10000), Quaternion.identity);
        outside = outsideRoom.GetComponent<RoomBehaviour>();

        FillMap();
        GenerateFloors();
        RoomBehaviour.ClearRotatedRooms();
    }

    private void FillMap() {
        map = new List<List<List<RoomBehaviour>>>();
        for (int x = 0; x < width; x++) {
            List<List<RoomBehaviour>> xSlice = new List<List<RoomBehaviour>>();
            map.Add(xSlice);
            for (int y = 0; y < height; y++) {
                List<RoomBehaviour> column = new List<RoomBehaviour>();
                xSlice.Add(column);
                for (int z = 0; z < length; z++) {
                    GameObject newRoom = Instantiate(room, new Vector3(x * roomWidth, y * roomHeight, z * roomLength), Quaternion.identity);
                    RoomBehaviour newRoomBehaviour = newRoom.GetComponent<RoomBehaviour>();

                    if (x == 0) {
                        newRoomBehaviour.left = outside;
                    }
                    else if (x == width - 1) {
                        newRoomBehaviour.left = map[x - 1][y][z];
                        newRoomBehaviour.right = outside;
                        map[x - 1][y][z].right = newRoomBehaviour;
                    }
                    else {
                        newRoomBehaviour.left = map[x - 1][y][z];
                        map[x - 1][y][z].right = newRoomBehaviour;
                    }

                    if (y == 0) {
                        newRoomBehaviour.bottom = outside;
                    }
                    else if (y == height - 1) {
                        newRoomBehaviour.bottom = map[x][y - 1][z];
                        newRoomBehaviour.top = outside;
                        map[x][y - 1][z].top = newRoomBehaviour;
                    }
                    else {
                        newRoomBehaviour.bottom = map[x][y - 1][z];
                        map[x][y - 1][z].top = newRoomBehaviour;
                    }

                    if (z == 0) {
                        newRoomBehaviour.back = outside;
                    }
                    else if (z == length - 1) {
                        newRoomBehaviour.back = map[x][y][z - 1];
                        newRoomBehaviour.front = outside;
                        map[x][y][z - 1].front = newRoomBehaviour;
                    }
                    else {
                        newRoomBehaviour.back = map[x][y][z - 1];
                        map[x][y][z - 1].front = newRoomBehaviour;
                    }
                    column.Add(newRoomBehaviour);
                }
            }
        }
    }

    private void GenerateFloors() {
        for (int y = 0; y < height; y++) {
            bool done = false;
            while (!done) {
                int stairsX = Random.Range(0, width);
                int stairsZ = Random.Range(0, length);
                done = map[stairsX][y][stairsZ].SetStairs();
            }

        }

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                for (int z = 0; z < length; z++) {
                    if (y == height - 1) map[x][y][z].topConn = RoomBehaviour.VertConnectionType.floor;
                    map[x][y][z].Generate(y, height);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
