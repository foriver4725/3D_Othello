using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ex;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Main : MonoBehaviour
{
    public Toggle IsBlack;
    public Slider X, Y, Z;

    // Must be even.
    static readonly int boardSize = 8;

    // 0:nothing, 1:black, 2:white. [0, 0, 0] ~ [7, 7, 7].
    int[,,] field = new int[boardSize, boardSize, boardSize];

    // (3, 3, 3).
    Vector3Int c = new(boardSize / 2 - 1, boardSize / 2 - 1, boardSize / 2 - 1);

    void Start()
    {
        // Set up the field.
        field.To(c, new(0, 0, 0), 1);
        field.To(c, new(1, 0, 0), 2);
        field.To(c, new(0, 0, 1), 2);
        field.To(c, new(1, 0, 1), 1);
        field.To(c, new(0, 1, 0), 2);
        field.To(c, new(1, 1, 0), 1);
        field.To(c, new(0, 1, 1), 1);
        field.To(c, new(1, 1, 1), 2);
        Display(field, boardSize);
    }

    void Update()
    {
        if (KeyCode.Return.Down())
        {
            Vector3Int pos = new((int)X.value, (int)Y.value, (int)Z.value);
            Put(field, boardSize, pos, IsBlack.isOn ? 1 : 2);
            $">> ({pos.x}, {pos.y}, {pos.z})".Show();
            Display(field, boardSize);
        }
    }

    // 1:black, 2:white.
    void Put(int[,,] f, int size, Vector3Int p, int col)
    {
        if (f.At(p) != 0) return;
        else f.To(p, col);

        foreach (int _x in Collection.Range(p.x - 1, p.x + 2))
        {
            foreach (int _y in Collection.Range(p.y - 1, p.y + 2))
            {
                foreach (int _z in Collection.Range(p.z - 1, p.z + 2))
                {
                    int x = _x.Clamp(0, size - 1);
                    int y = _y.Clamp(0, size - 1);
                    int z = _z.Clamp(0, size - 1);
                    if (!(x == p.x && y == p.y && z == p.z))
                    {
                        if (col == 0) continue;
                        if (f[x, y, z] == RevCol(col)) Rev(f, size, p, col, new Vector3Int(x - p.x, y - p.y, z - p.z));
                    }
                }
            }
        }
    }

    void Rev(int[,,] f, int size, Vector3Int p, int col, Vector3Int dir)
    {
        List<Vector3Int> revPosMemo = new();

        for (int i = 0; i < size; i++, p.x += dir.x, p.y += dir.y, p.z += dir.z)
        {
            // On 0th loop, p is the put position.
            if (i == 0) continue;

            // Cannot reverse.
            if (i == 1 && col != 0 && f.At(p) == RevCol(col)) return;

            // Reached the edge.
            if (p.x.IsIn(0, size - 1) || p.y.IsIn(0, size - 1) || p.z.IsIn(0, size - 1)) break;

            if (f.At(p) == RevCol(col)) revPosMemo.Add(new(p.x, p.y, p.z));
            else if (f.At(p) == col) Collection.Map(revPosMemo, (e) => f.To(e, col));
            else return;
        }
    }

    void Display(int[,,] f, int size)
    {
        "##################################################".Show();
        foreach (int x in Collection.Range(size))
        {
            string s = "";
            foreach (int y in Collection.Range(size))
            {
                foreach (int z in Collection.Range(size))
                {
                    int v = f[x, y, z];
                    if (v == 0)
                    {
                        s += $"({x},{y},{z}):<color=green>{v}</color>, ";
                    }
                    else if (v == 1)
                    {
                        s += $"({x},{y},{z}):<color=red>{v}</color>, ";
                    }
                    else if (v == 2)
                    {
                        s += $"({x},{y},{z}):<color=blue>{v}</color>, ";
                    }
                }
                s += "\n";
            }
            s.Show();
        }
        "##################################################".Show();
    }

    int RevCol(int col)
    {
        if (col == 1) return 2;
        else if (col == 2) return 1;
        else throw new System.Exception("Invalid color.");
    }
}
