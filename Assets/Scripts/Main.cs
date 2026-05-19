using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Main : MonoBehaviour
{
    private enum Stone : byte
    {
        None = 0,
        Black = 1,
        White = 2,
    }

    [SerializeField] private GameObject emptyStonePrefab;
    [SerializeField] private GameObject blackStonePrefab;
    [SerializeField] private GameObject whiteStonePrefab;

    [SerializeField] private TMP_InputField inputField;

    private readonly Dictionary<Stone, GameObject> _prefabs = new()
    {
        { Stone.None, null },
        { Stone.Black, null },
        { Stone.White, null },
    };

    private static readonly Dictionary<Vector3Int, Stone> InitialStones = new()
    {
        { new Vector3Int(3, 3, 3), Stone.Black },
        { new Vector3Int(4, 3, 3), Stone.White },
        { new Vector3Int(3, 4, 3), Stone.White },
        { new Vector3Int(4, 4, 3), Stone.Black },
        { new Vector3Int(3, 3, 4), Stone.White },
        { new Vector3Int(4, 3, 4), Stone.Black },
        { new Vector3Int(3, 4, 4), Stone.Black },
        { new Vector3Int(4, 4, 4), Stone.White },
    };

    // Must be even.
    private const int FieldSize = 8;

    private readonly GameObject[] _fieldObj = new GameObject[FieldSize * FieldSize * FieldSize];
    private readonly Stone[] _field = new Stone[FieldSize * FieldSize * FieldSize];
    private bool _isBlackTurn = true;

    private void Start()
    {
        _prefabs[Stone.None] = emptyStonePrefab;
        _prefabs[Stone.Black] = blackStonePrefab;
        _prefabs[Stone.White] = whiteStonePrefab;

        // Set up the field.
        Array.Fill(_fieldObj, null);
        Array.Fill(_field, Stone.None);

        foreach (var (position, stone) in InitialStones)
        {
            SetStone(position, stone);
        }

        Display();
    }

    private void Update()
    {
        // Get the player's input.
        if (Keyboard.current?.enterKey.wasPressedThisFrame == true)
        {
            int x, y, z;
            try
            {
                var inputText = inputField.text;

                var xChar = inputText[0];
                var yChar = inputText[1];
                var zChar = inputText[2];

                x = xChar - '0';
                y = yChar - '0';
                z = zChar - '0';

                if (x is not (>= 0 and < FieldSize)) throw new Exception("Invalid position.");
                if (y is not (>= 0 and < FieldSize)) throw new Exception("Invalid position.");
                if (z is not (>= 0 and < FieldSize)) throw new Exception("Invalid position.");
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                return;
            }

            Put(new Vector3Int(x, y, z), _isBlackTurn ? Stone.Black : Stone.White);
            Display();

            _isBlackTurn = !_isBlackTurn;
            inputField.text = "";
        }
    }

    private void Put(Vector3Int position, Stone stone)
    {
        if (stone == Stone.None) throw new Exception("Invalid color.");
        if (GetStone(position) != Stone.None) return;

        SetStone(position, stone);

        for (var x = -1; x <= 1; x++)
        for (var y = -1; y <= 1; y++)
        for (var z = -1; z <= 1; z++)
        {
            if (x == 0 && y == 0 && z == 0) continue;

            Vector3Int e = position + new Vector3Int(x, y, z);
            if (e.x is not (>= 0 and < FieldSize)) continue;
            if (e.y is not (>= 0 and < FieldSize)) continue;
            if (e.z is not (>= 0 and < FieldSize)) continue;

            if (GetStone(e) == GetOpponentStone(stone))
            {
                ReverseLine(position, stone, e - position);
            }
        }
    }

    private void ReverseLine(Vector3Int position, Stone stone, Vector3Int direction)
    {
        List<Vector3Int> revPosMemo = new();

        for (int i = 0; i < FieldSize; i++, position += direction)
        {
            // On 0th loop, p is the put position.
            if (i == 0) continue;

            // Reached the edge.
            if (position.x is not (>= 0 and < FieldSize)) continue;
            if (position.y is not (>= 0 and < FieldSize)) continue;
            if (position.z is not (>= 0 and < FieldSize)) continue;

            if (GetStone(position) == GetOpponentStone(stone)) revPosMemo.Add(new(position.x, position.y, position.z));
            else if (GetStone(position) == stone)
            {
                foreach (var memo in revPosMemo)
                    SetStone(memo, stone);
            }
            else return;
        }
    }

    private void Display()
    {
        for (var x = 0; x < FieldSize; x++)
        for (var y = 0; y < FieldSize; y++)
        for (var z = 0; z < FieldSize; z++)
        {
            var e = new Vector3Int(x, y, z);

            var fieldObject = GetFieldObject(e);
            if (fieldObject != null)
            {
                Destroy(fieldObject);
            }

            var newObject = Instantiate(_prefabs[GetStone(e)], e, Quaternion.identity, transform);
            SetFieldObject(e, newObject);
        }
    }

    private GameObject GetFieldObject(Vector3Int position)
        => _fieldObj[GetIndex(position)];

    private void SetFieldObject(Vector3Int position, GameObject obj)
        => _fieldObj[GetIndex(position)] = obj;

    private Stone GetStone(Vector3Int position)
        => _field[GetIndex(position)];

    private void SetStone(Vector3Int position, Stone stone)
        => _field[GetIndex(position)] = stone;

    private static int GetIndex(Vector3Int position)
        => position.x * FieldSize * FieldSize + position.y * FieldSize + position.z;

    private static Stone GetOpponentStone(Stone stone) => stone switch
    {
        Stone.Black => Stone.White,
        Stone.White => Stone.Black,
        _           => throw new Exception("Invalid stone color.")
    };
}