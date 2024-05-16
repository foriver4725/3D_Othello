using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ex;
using TMPro;
using Math = Ex.Math;

public class Main : MonoBehaviour
{
    public GameObject[] Prfbs;
    public TMP_InputField PlayerInput;

    // Must be even.
    static readonly int fieldSize = 8;

    // 0:nothing, 1:black, 2:white. [0, 0, 0] ~ [7, 7, 7].
    GameObject[,,] fieldObj = new GameObject[fieldSize, fieldSize, fieldSize];
    int[,,] field = new int[fieldSize, fieldSize, fieldSize];
    bool isBlackTurn = true;

    void Start()
    {
        // Set up the field.
        foreach (Vector3Int e in Collection.Enumerate(fieldSize, fieldSize, fieldSize))
        {
            fieldObj.Set(e, gameObject.GetGrandsChild(0, e.z, e.y, e.x));
        }
        Vector3Int cnt = Vector3Int.one * (fieldSize / 2 - 1);
        Collection.Map(Collection.Enumerate(2, 2, 2), (e) => field.Set(cnt, e, e.Sum() % 2 == 0 ? 1 : 2));

        Display(fieldObj, field, fieldSize);
    }

    void Update()
    {
        // Get the player's input.
        if (KeyCode.Return.Down())
        {
            int inputNum = int.Parse(PlayerInput.text);
            (int x, int _y) = Math.DivMod(inputNum, 100);
            (int y, int z) = Math.DivMod(_y, 10);
            Put(field, fieldSize, new Vector3Int(x, y, z).Clamp(0, fieldSize - 1), isBlackTurn ? 1 : 2);
            Display(fieldObj, field, fieldSize);

            isBlackTurn = !isBlackTurn;
            PlayerInput.text = "";
        }
    }

    // 1:black, 2:white.
    void Put(int[,,] f, int size, Vector3Int p, int col)
    {
        if (col == 0) throw new System.Exception("Invalid color.");

        if (f.Where(p) != 0) return;
        else f.Set(p, col);

        foreach (Vector3Int _e in Collection.Enumerate((-1, 2), (-1, 2), (-1, 2)))
        {
            Vector3Int e = (p + _e).Clamp(0, size - 1);
            if (e != p && f.Where(e) == RevCol(col)) Rev(f, size, p, col, e - p);
        }
    }

    void Rev(int[,,] f, int size, Vector3Int p, int col, Vector3Int dir)
    {
        List<Vector3Int> revPosMemo = new();

        for (int i = 0; i < size; i++, p += dir)
        {
            // On 0th loop, p is the put position.
            if (i == 0) continue;

            // Reached the edge.
            if (!p.IsIn(0, size - 1)) break;

            if (f.Where(p) == RevCol(col)) revPosMemo.Add(new(p.x, p.y, p.z));
            else if (f.Where(p) == col) Collection.Map(revPosMemo, (e) => f.Set(e, col));
            else return;
        }
    }

    void Display(GameObject[,,] fieldObj, int[,,] field, int size)
    {
        foreach (Vector3Int e in Collection.Enumerate(size, size, size))
        {
            Transform parent = fieldObj.Where(e).transform.parent;
            Destroy(fieldObj.Where(e));
            fieldObj.Set(e, Instantiate(Prfbs[field.Where(e)], e, Quaternion.identity, parent));
        }
    }

    int RevCol(int col)
    {
        if (col == 1) return 2;
        else if (col == 2) return 1;
        else throw new System.Exception("Invalid color.");
    }
}
