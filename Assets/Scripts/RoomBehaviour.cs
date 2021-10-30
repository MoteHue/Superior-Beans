using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public enum SideConnectionType{unset, door, open, wall}
    public enum VertConnectionType{unset, floor, stairs}

    public RoomBehaviour top = null, bottom = null, left = null, right = null, front = null, back = null;
    public SideConnectionType leftConn = SideConnectionType.unset, rightConn = SideConnectionType.unset;
    public SideConnectionType frontConn = SideConnectionType.unset, backConn = SideConnectionType.unset;
    public VertConnectionType topConn = VertConnectionType.unset, bottomConn = VertConnectionType.unset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
