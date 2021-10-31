using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsData : RoomData
{
    public RoomBehaviour.SideConnectionType upLeft = RoomBehaviour.SideConnectionType.unset;
    public RoomBehaviour.SideConnectionType upRight = RoomBehaviour.SideConnectionType.unset;
    public RoomBehaviour.SideConnectionType upFront = RoomBehaviour.SideConnectionType.unset;
    public RoomBehaviour.SideConnectionType upBack = RoomBehaviour.SideConnectionType.unset;
    public RoomBehaviour.VertConnectionType upTop = RoomBehaviour.VertConnectionType.unset;

    public override void Rotate() {
        RoomBehaviour.SideConnectionType temp = left;
        left = back;
        back = right;
        right = front;
        front = temp;
        temp = upLeft;
        upLeft = upBack;
        upBack = upRight;
        upRight = upFront;
        upFront = temp;
    }

    public override bool CheckConnections(RoomBehaviour room) {
        if ((room.leftConn   == RoomBehaviour.SideConnectionType.unset ||
             room.leftConn   == left)   &&
            (room.rightConn  == RoomBehaviour.SideConnectionType.unset ||
             room.rightConn  == right)  &&
            (room.frontConn  == RoomBehaviour.SideConnectionType.unset ||
             room.frontConn  == front)  &&
            (room.backConn   == RoomBehaviour.SideConnectionType.unset ||
             room.backConn   == back)   &&
            (room.topConn    == RoomBehaviour.VertConnectionType.unset ||
             room.topConn    == top)    &&
            (room.bottomConn == RoomBehaviour.VertConnectionType.unset ||
             room.bottomConn == bottom) &&
            (room.top.leftConn == RoomBehaviour.SideConnectionType.unset ||
             room.top.leftConn == upLeft) &&
            (room.top.rightConn == RoomBehaviour.SideConnectionType.unset ||
             room.top.rightConn == upRight) &&
            (room.top.frontConn == RoomBehaviour.SideConnectionType.unset ||
             room.top.frontConn == upFront) &&
            (room.top.backConn == RoomBehaviour.SideConnectionType.unset ||
             room.top.backConn == upBack)) {
            
            return true;
        }

        return false;
    }

    public override void SetConnections(RoomBehaviour room) {
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
        room.top.leftConn = upLeft;
        room.top.left.rightConn = upLeft;
        room.top.rightConn = upRight;
        room.top.right.leftConn = upRight;
        room.top.frontConn = upFront;
        room.top.front.backConn = upFront;
        room.top.backConn = upBack;
        room.top.back.frontConn = upBack;
        room.top.topConn = upTop;
        room.top.top.bottomConn = upTop;
        room.top.isGenerated = true;
    }
}