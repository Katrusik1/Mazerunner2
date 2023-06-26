using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public Room[] rooms;
    public Room StartRoom;

    private Room[,] spawnedrooms;

    void Start()
    {
        spawnedrooms = new Room[11, 11];
        spawnedrooms[5, 5] = StartRoom;
        for(int i = 0; i<15; i++)
        {
            PlaceOneRoom();
        }
    }

    public void PlaceOneRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x<spawnedrooms.GetLength(0); x++)
        {
            for (int y = 0; y<spawnedrooms.GetLength(1); y++)
            {
                if (spawnedrooms[x, y] == null) continue;

                int maxX = spawnedrooms.GetLength(0)-1;
                int maxY = spawnedrooms.GetLength(1)-1;

                if(x>0 && spawnedrooms[x-1,y]==null) vacantPlaces.Add(new Vector2Int(x-1,y));
                if (y > 0 && spawnedrooms[x, y-1] == null) vacantPlaces.Add(new Vector2Int(x, y-1));
                if (x < maxX && spawnedrooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedrooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }
        Room newRoom = Instantiate(rooms[Random.Range(0, rooms.Length)]);
        int limit = 500;
        while (limit-- >0)
        {
            Vector2Int position = vacantPlaces.ElementAt(UnityEngine.Random.Range(0, vacantPlaces.Count));


            if (ConnectToSmt(newRoom, position))
            {
                newRoom.transform.position = new Vector3(position.x - 5, 0, position.y - 5) * 25;
                spawnedrooms[position.x, position.y] = newRoom;
                break;
            }
        }        
    }

    private bool ConnectToSmt(Room room, Vector2Int p)
    {
        int maxX = spawnedrooms.GetLength(0) - 1;
        int maxY = spawnedrooms.GetLength(1) - 1;

        List<Vector2Int> neighbors = new List<Vector2Int>();

        if (room.DoorU != null && p.y<maxY && spawnedrooms[p.x, p.y+1]?.DoorD != null) neighbors.Add(Vector2Int.up);
        if (room.DoorD != null && p.y > 0 && spawnedrooms[p.x, p.y -1]?.DoorU != null) neighbors.Add(Vector2Int.down);
        if (room.DoorR != null && p.x < maxX && spawnedrooms[p.x+1, p.y]?.DoorL != null) neighbors.Add(Vector2Int.right);
        if (room.DoorL != null && p.x > 0 && spawnedrooms[p.x-1, p.y ]?.DoorR != null) neighbors.Add(Vector2Int.left);

        if (neighbors.Count == 0) return false;

        Vector2Int selectDerection = neighbors[UnityEngine.Random.Range(0, neighbors.Count)];
        Room selectedRoom = spawnedrooms[p.x + selectDerection.x, p.y + selectDerection.y];

        if(selectDerection == Vector2Int.up)
        {
            room.DoorU.SetActive(false); 
            selectedRoom.DoorD.SetActive(false);
        }
        if (selectDerection == Vector2Int.down)
        {
            room.DoorD.SetActive(false);
            selectedRoom.DoorU.SetActive(false);
        }
        if (selectDerection == Vector2Int.right)
        {
            room.DoorR.SetActive(false);
            selectedRoom.DoorL.SetActive(false);
        }
        if (selectDerection == Vector2Int.left)
        {
            room.DoorL.SetActive(false);
            selectedRoom.DoorR.SetActive(false);
        }
        return true;
    }
}
