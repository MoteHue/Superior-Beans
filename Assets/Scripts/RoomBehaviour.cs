using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public List<GameObject> possibleRooms;
    private static List<RoomData> possibleRotatedRooms = null;
    public enum SideConnectionType{unset, door, open, wall}
    public enum VertConnectionType{unset, floor, stairs}

    public RoomBehaviour top = null, bottom = null, left = null, right = null, front = null, back = null;
    public SideConnectionType leftConn = SideConnectionType.unset, rightConn = SideConnectionType.unset;
    public SideConnectionType frontConn = SideConnectionType.unset, backConn = SideConnectionType.unset;
    public VertConnectionType topConn = VertConnectionType.unset, bottomConn = VertConnectionType.unset;

    public bool isGenerated = false;

    public bool IsGenerated() {
        return isGenerated;
    }

    public bool SetStairs() {
        if (topConn != VertConnectionType.unset) return false;
        topConn = VertConnectionType.stairs;

        top.bottomConn = VertConnectionType.stairs;

        return true;
    }

    public void Generate(int y, int height) {
        if (possibleRotatedRooms == null) {
            possibleRotatedRooms = new List<RoomData>();
            foreach (GameObject room in possibleRooms) {
                for (int i = 0; i < 4; i++) {
                    Vector3 pos = Vector3.zero;
                    if (i == 1) pos += new Vector3(0, 0, 8);
                    else if (i == 2) pos += new Vector3(8, 0, 8);
                    else if (i == 3) pos += new Vector3(8, 0, 0);
                    GameObject rotatedRoom = Instantiate(room, pos, Quaternion.Euler(0, 90 * i, 0));
                    RoomData roomData = rotatedRoom.GetComponent<RoomData>();
                    for (int j = 0; j < i; j++) {
                        roomData.Rotate();
                    }
                    // rotatedRoom.transform.position = Vector3.zero;
                    // rotatedRoom.transform.rotation = ;
                    possibleRotatedRooms.Add(roomData);
                    rotatedRoom.SetActive(false);
                }
            }
        }

        List<RoomData> potentialRoomLayouts = new List<RoomData>();

        // Debug.Log(possibleRotatedRooms);

        foreach (RoomData room in possibleRotatedRooms) {
            if (room.CheckConnections(this)) {
                potentialRoomLayouts.Add(room);
            }
        }

        if (potentialRoomLayouts.Count == 0) {
            Debug.LogWarning("No room fitted. left: " + leftConn + ", right: " + rightConn + ", front: " + frontConn + ", back: " + backConn + ", top: " + topConn + ", bottom: " + bottomConn);
        }
        else {
            int index = Random.Range(0, potentialRoomLayouts.Count);
            GameObject newRoom = Instantiate(potentialRoomLayouts[index].gameObject, transform);
            newRoom.SetActive(true);
            newRoom.GetComponent<RoomData>().SetConnections(this);
            EnemySpawner spawner = newRoom.GetComponentInChildren<EnemySpawner>();
            if (spawner != null) spawner.Configue(y, height);
            WeaponPickup pickup = newRoom.GetComponentInChildren<WeaponPickup>();
            if (pickup != null) {
                pickup.weaponIndex = Random.Range(1, 6);
                while (pickup.weaponIndex == 2) pickup.weaponIndex = Random.Range(1, 6);
            }
        }

        isGenerated = true;
    }

    public void ClearConns() {
        leftConn = RoomBehaviour.SideConnectionType.unset;
        rightConn = RoomBehaviour.SideConnectionType.unset;
        frontConn = RoomBehaviour.SideConnectionType.unset;
        backConn = RoomBehaviour.SideConnectionType.unset;
        topConn = RoomBehaviour.VertConnectionType.unset;
        bottomConn = RoomBehaviour.VertConnectionType.unset;
    }

    public static void ClearRotatedRooms() {
        foreach (RoomData room in possibleRotatedRooms) {
            Destroy(room.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
