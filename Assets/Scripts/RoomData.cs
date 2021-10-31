using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    public RoomBehaviour.SideConnectionType left = RoomBehaviour.SideConnectionType.unset;
    public RoomBehaviour.SideConnectionType right = RoomBehaviour.SideConnectionType.unset;
    public RoomBehaviour.SideConnectionType front = RoomBehaviour.SideConnectionType.unset;
    public RoomBehaviour.SideConnectionType back = RoomBehaviour.SideConnectionType.unset;
    public RoomBehaviour.VertConnectionType top = RoomBehaviour.VertConnectionType.unset;
    public RoomBehaviour.VertConnectionType bottom = RoomBehaviour.VertConnectionType.unset;

    public virtual void Rotate() {
        RoomBehaviour.SideConnectionType temp = left;
        left = back;
        back = right;
        right = front;
        front = temp;
    }

    public virtual bool CheckConnections(RoomBehaviour room) {
        if ((room.leftConn   == RoomBehaviour.SideConnectionType.unset ||
             room.leftConn   == left)  &&
            (room.rightConn  == RoomBehaviour.SideConnectionType.unset ||
             room.rightConn  == right) &&
            (room.frontConn  == RoomBehaviour.SideConnectionType.unset ||
             room.frontConn  == front) &&
            (room.backConn   == RoomBehaviour.SideConnectionType.unset ||
             room.backConn   == back)  &&
            (room.topConn    == RoomBehaviour.VertConnectionType.unset ||
             room.topConn    == top)   &&
            (room.bottomConn == RoomBehaviour.VertConnectionType.unset ||
             room.bottomConn == bottom)) {
            
            return true;
        }

        return false;
    }

    public virtual void SetConnections(RoomBehaviour room) {
        room.leftConn = left;
        room.left.rightConn = left;
        room.rightConn = right;
        room.right.leftConn = right;
        room.frontConn = front;
        room.front.backConn = front;
        room.backConn = back;
        room.back.frontConn = back;
        room.topConn = top;
        room.top.bottomConn = top;
        room.bottomConn = bottom;
        room.bottom.topConn = bottom;
    }
}
