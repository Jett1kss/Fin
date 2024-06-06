using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMove : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Sprite sprite;

    private Tile[,] map = new Tile[30, 20];

    private int targetId = -1;

    private List<Vector2> path = new List<Vector2>();
    private Vector2[] pathFinal = null;

    private bool calcing = true;

    private int index = 0;


    private void Start()
    {
        InvokeRepeating("Way", 0, 10);
        InvokeRepeating("Move", 1, 0.5f);
    }

    private void Move()
    {
        if (!calcing)
        {
            if (index < pathFinal.Length)
            {
                transform.position = new Vector3(pathFinal[index].x, 0, pathFinal[index].y);
                index++;
            }
            else
            {
                Way();
            }
        }
    }

    private void Way()
    {
        calcing = true;
        index = 0;
        path.Clear();
        pathFinal = null;
        InitMap();

        int nowX = (int)Mathf.Round(transform.position.x);
        int nowZ = (int)Mathf.Round(transform.position.z);

        int nowId = 1;
        int maxId = 1;

        map[nowX, nowZ].ID = nowId;
        map[nowX, nowZ].LastID = -10;
        map[nowX, nowZ].Open = false;
        
        while (true)
        {
            bool found = false;
            for (int x = 0; x < 30; x++)
            {
                for (int z = 0; z < 20; z++)
                {
                    if (map[x, z].ID == nowId)
                    {
                        nowX = x;
                        nowZ = z;
                        found = true;
                    }
                }
            }

            if ((nowX == Mathf.Round(player.position.x)) && (nowZ == Mathf.Round(player.position.z)))
            {
                targetId = nowId;
                WayEnd();

                break;
            }

            if (!found)
            {
                break;
            }

            if (nowZ < 19)
            {
                if (map[nowX, nowZ + 1].Open)
                {
                    map[nowX, nowZ + 1].LastID = nowId;
                    maxId++;
                    map[nowX, nowZ + 1].ID = maxId;
                    map[nowX, nowZ + 1].Open = false;
                }
            }

            if (nowZ > 0)
            {
                if (map[nowX, nowZ - 1].Open)
                {
                    map[nowX, nowZ - 1].LastID = nowId;
                    maxId++;
                    map[nowX, nowZ - 1].ID = maxId;
                    map[nowX, nowZ - 1].Open = false;
                }
            }

            if (nowX > 0)
            {
                if (map[nowX - 1, nowZ].Open)
                {
                    map[nowX - 1, nowZ].LastID = nowId;
                    maxId++;
                    map[nowX - 1, nowZ].ID = maxId;
                    map[nowX - 1, nowZ].Open = false;
                }
            }

            if (nowX < 29)
            {
                if (map[nowX + 1, nowZ].Open)
                {
                    map[nowX + 1, nowZ].LastID = nowId;
                    maxId++;
                    map[nowX + 1, nowZ].ID = maxId;
                    map[nowX + 1, nowZ].Open = false;
                }
            }

            nowId++;
        }
        calcing = false;
    }

    private void WayEnd()
    {
        while (targetId != -10)
        {
            for (int x = 0; x < 30; x++)
            {
                for (int z = 0; z < 20; z++)
                {
                    if (map[x, z].ID == targetId)
                    {
                        int nowX = x;
                        int nowZ = z;

                        path.Add(new Vector2(nowX, nowZ));
                        targetId = map[nowX, nowZ].LastID;
                    }
                }
            }
        }
        pathFinal = new Vector2[path.Count];
        for (int i = 0; i < path.Count; i++)
        {
            pathFinal[i] = path[path.Count - i - 1];
        }
    }

    private void InitMap()
    {
        for (int x = 0; x < 30; x++)
        {
            for (int z = 0; z < 20; z++)
            {
                bool open = true;
                if (sprite.texture.GetPixel(x, z).r == 0)
                {
                    open = false;
                }
                map[x, z] = new Tile(open, -1, -1);
            }
        }
    }
}
