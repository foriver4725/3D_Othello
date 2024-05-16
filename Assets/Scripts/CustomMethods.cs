using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Ex
{
    public static class Debug
    {
        public static void Print<T>(T msg)
        {
#if true
            UnityEngine.Debug.Log(msg);
#else
            return;
#endif
        }

        public static void Print<T>(string title, T msg)
        {
#if true
            UnityEngine.Debug.Log($"{title}:{msg}");
#else
            return;
#endif
        }

        public static void Show<T>(this T self)
        {
            Print(self);
        }

        public static void Show<T>(this T self, string title)
        {
            Print(title, self);
        }
    }

    public static class Math
    {
        /// <summary>
        /// Return "true" if the distance between "a" and "b" is larger than or equal to "d", else "false";
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="d"></param>
        public static bool CompareDistance(Vector3 a, Vector3 b, float d)
        {
            return (a - b).sqrMagnitude >= Mathf.Pow(d, 2);
        }

        public static int Abs(this int sc)
        {
            return Mathf.Abs(sc);
        }

        public static float Abs(this float sc)
        {
            return Mathf.Abs(sc);
        }

        public static float Cos(this float theta)
        {
            return Mathf.Cos(theta);
        }

        public static float Sin(this float theta)
        {
            return Mathf.Sin(theta);
        }

        public static float Tan(this float theta)
        {
            return Mathf.Tan(theta);
        }

        public static float Acos(this float theta)
        {
            return Mathf.Acos(theta);
        }

        public static float Asin(this float theta)
        {
            return Mathf.Asin(theta);
        }

        public static float Atan(this float theta)
        {
            return Mathf.Atan(theta);
        }

        public static float Atan2(this Vector2 vec)
        {
            return Mathf.Atan2(vec.y, vec.x);
        }

        public static float Pow(this float _base, float exponent)
        {
            return Mathf.Pow(_base, exponent);
        }

        public static int Scroll(int len, int nowIndex, int indexDelta)
        {
            if (len <= 0) throw new ArgumentOutOfRangeException(nameof(len));

            nowIndex += indexDelta;

            if (indexDelta >= 0)
            {
                while (nowIndex > len - 1)
                {
                    nowIndex -= len;
                }
            }
            else
            {
                while (nowIndex < 0)
                {
                    nowIndex += len;
                }
            }

            return nowIndex;
        }

        public static int Clamp(this int self, int min, int max)
        {
            return Mathf.Clamp(self, min, max);
        }

        public static float Clamp(this float self, float min, float max)
        {
            return Mathf.Clamp(self, min, max);
        }

        public static Vector2 Clamp(this Vector2 self, float min, float max)
        {
            return new(self.x.Clamp(min, max), self.y.Clamp(min, max));
        }

        public static Vector3 Clamp(this Vector3 self, float min, float max)
        {
            return new(self.x.Clamp(min, max), self.y.Clamp(min, max), self.z.Clamp(min, max));
        }

        public static Vector2Int Clamp(this Vector2Int self, int min, int max)
        {
            return new(self.x.Clamp(min, max), self.y.Clamp(min, max));
        }

        public static Vector3Int Clamp(this Vector3Int self, int min, int max)
        {
            return new(self.x.Clamp(min, max), self.y.Clamp(min, max), self.z.Clamp(min, max));
        }

        public static int ClampFloor(this int self, int min)
        {
            return self < min ? min : self;
        }

        public static float ClampFloor(this float self, float min)
        {
            return self < min ? min : self;
        }

        public static Vector2 ClampFloor(this Vector2 self, float min)
        {
            return new(self.x < min ? min : self.x, self.y < min ? min : self.y);
        }

        public static Vector3 ClampFloor(this Vector3 self, float min)
        {
            return new(self.x < min ? min : self.x, self.y < min ? min : self.y, self.z < min ? min : self.z);
        }

        public static Vector2Int ClampFloor(this Vector2Int self, int min)
        {
            return new(self.x < min ? min : self.x, self.y < min ? min : self.y);
        }

        public static Vector3Int ClampFloor(this Vector3Int self, int min)
        {
            return new(self.x < min ? min : self.x, self.y < min ? min : self.y, self.z < min ? min : self.z);
        }

        public static int ClampCeil(this int self, int max)
        {
            return self > max ? max : self;
        }

        public static float ClampCeil(this float self, float max)
        {
            return self > max ? max : self;
        }

        public static Vector2 ClampCeil(this Vector2 self, float max)
        {
            return new(self.x > max ? max : self.x, self.y > max ? max : self.y);
        }

        public static Vector3 ClampCeil(this Vector3 self, float max)
        {
            return new(self.x > max ? max : self.x, self.y > max ? max : self.y, self.z > max ? max : self.z);
        }

        public static Vector2Int ClampCeil(this Vector2Int self, int max)
        {
            return new(self.x > max ? max : self.x, self.y > max ? max : self.y);
        }

        public static Vector3Int ClampCeil(this Vector3Int self, int max)
        {
            return new(self.x > max ? max : self.x, self.y > max ? max : self.y, self.z > max ? max : self.z);
        }

        public static (int q, int r) DivMod(int a, int b)
        {
            int q = a / b;
            int r = a % b;
            return (q, r);
        }

        public static (int q, float r) DivMod(float a, float b)
        {
            int q = (int)(a / b);
            float r = a % b;
            return (q, r);
        }

        public static (int min, int sec, int thi) NormalizedTime(this float time)
        {
            (int min, float time_) = DivMod(time, 60);
            (int sec, float thi_) = DivMod(time_ * 100, 100);
            int thi = (int)thi_;
            return (min, sec, thi);
        }

        public static int Round2(float sc)
        {
            return (int)System.Math.Round(sc, 0, MidpointRounding.AwayFromZero);
        }

        public static int Rounded(this float sc)
        {
            return (int)Mathf.Round(sc);
        }

        public static int Rounded2(this float sc)
        {
            return (int)System.Math.Round(sc, 0, MidpointRounding.AwayFromZero);
        }

        public static float Sum(this Vector2 self)
        {
            return self.x + self.y;
        }

        public static float Sum(this Vector3 self)
        {
            return self.x + self.y + self.z;
        }

        public static int Sum(this Vector2Int self)
        {
            return self.x + self.y;
        }

        public static int Sum(this Vector3Int self)
        {
            return self.x + self.y + self.z;
        }
    }

    public static class Random
    {
        public static bool RandomBool()
        {
            return RandInt(0, 1) == 0;
        }

        public static int RandInt(int min, int max)
        {
            return UnityEngine.Random.Range(min, max + 1);
        }

        public static float RandFloat(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }

        public static Vector2 RandSquare(float sizeX, float sizeY)
        {
            return new(RandFloat(0, sizeX), RandFloat(0, sizeY));
        }

        public static Vector2Int RandSquare(int sizeX, int sizeY)
        {
            return new(RandInt(0, sizeX), RandInt(0, sizeY));
        }

        /// <param name="sizeR">sizeR >= 0</param>
        public static Vector2 RandCircle(float sizeR)
        {
            float theta = RandFloat(0, 2 * Mathf.PI);
            return new Vector2(theta.Cos(), theta.Sin()) * sizeR;
        }

        public static Vector3 RandCube(float sizeX, float sizeY, float sizeZ)
        {
            return new(RandFloat(0, sizeX), RandFloat(0, sizeY), RandFloat(0, sizeZ));
        }

        public static Vector3Int RandCube(int sizeX, int sizeY, int sizeZ)
        {
            return new(RandInt(0, sizeX), RandInt(0, sizeY), RandInt(0, sizeZ));
        }

        /// <param name="sizeR">sizeR >= 0</param>
        public static Vector3 RandSphere(float sizeR)
        {
            float theta = RandFloat(0, Mathf.PI);
            float phi = RandFloat(0, 2 * Mathf.PI);
            return new Vector3(theta.Sin() * phi.Cos(), theta.Sin() * phi.Sin(), theta.Cos()) * sizeR;
        }
    }

    public static class Collection
    {
        public static List<T> ToList<T>(this IEnumerable<T> collection)
        {
            List<T> ret = new();
            foreach (T e in collection)
            {
                ret.Add(e);
            }
            return ret;
        }

        public static IEnumerable<T> ToIEe<T>(this List<T> collection)
        {
            foreach (T e in collection)
            {
                yield return e;
            }
        }

        public static IEnumerable<int> Range(int stop)
        {
            for (int i = 0; i < stop; i += 1)
            {
                yield return i;
            }
        }

        public static IEnumerable<int> Range(int start, int stop)
        {
            for (int i = start; i < stop; i += 1)
            {
                yield return i;
            }
        }

        public static IEnumerable<int> Range(int start, int stop, int step)
        {
            if (step == 0) throw new Exception("InfinityLoop.");

            if (step > 0)
            {
                for (int i = start; i < stop; i += step)
                {
                    yield return i;
                }
            }
            else
            {
                for (int i = start; i > stop; i += step)
                {
                    yield return i;
                }
            }
        }

        public static IEnumerable<(int index, T value)> Enumerate<T>(IEnumerable<T> self)
        {
            using (IEnumerator<T> IEr = self.GetEnumerator())
            {
                int i = 0;
                while (IEr.MoveNext())
                {
                    i++;
                    yield return (i, IEr.Current);
                }
            }
        }

        public static IEnumerable<(int index, T value)> Enumerate<T>(List<T> self)
        {
            for (int i = 0; i < self.Count; i++)
            {
                yield return (i, self[i]);
            }
        }

        public static IEnumerable<(int index, T1 key, T2 value)> Enumerate<T1, T2>(Dictionary<T1, T2> self)
        {
            int i = 0;
            foreach (KeyValuePair<T1, T2> e in self)
            {
                yield return (i, e.Key, e.Value);
                i++;
            }
        }

        public static IEnumerable<Vector2Int> Enumerate(Vector2Int vec)
        {
            for (int x = 0; x < vec.x; x++)
            {
                for (int y = 0; y < vec.y; y++)
                {
                    yield return new(x, y);
                }
            }
        }

        public static IEnumerable<Vector2Int> Enumerate(int _x, int _y)
        {
            for (int x = 0; x < _x; x++)
            {
                for (int y = 0; y < _y; y++)
                {
                    yield return new(x, y);
                }
            }
        }

        public static IEnumerable<Vector2Int> Enumerate((int start, int stop) _x, (int start, int stop) _y)
        {
            for (int x = _x.start; x < _x.stop; x++)
            {
                for (int y = _y.start; y < _y.stop; y++)
                {
                    yield return new(x, y);
                }
            }
        }

        public static IEnumerable<Vector2Int> Enumerate((int start, int stop, int step) _x, (int start, int stop, int step) _y)
        {
            if (_x.step == 0 || _y.step == 0) throw new Exception("InfinityLoop.");

            if (_x.step > 0 && _y.step > 0)
            {
                for (int x = _x.start; x < _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y < _y.stop; y += _y.step)
                    {
                        yield return new(x, y);
                    }
                }
            }
            else if (_x.step > 0 && _y.step < 0)
            {
                for (int x = _x.start; x < _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y > _y.stop; y += _y.step)
                    {
                        yield return new(x, y);
                    }
                }
            }
            else if (_x.step < 0 && _y.step > 0)
            {
                for (int x = _x.start; x > _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y < _y.stop; y += _y.step)
                    {
                        yield return new(x, y);
                    }
                }
            }
            else
            {
                for (int x = _x.start; x > _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y > _y.stop; y += _y.step)
                    {
                        yield return new(x, y);
                    }
                }
            }
        }

        public static IEnumerable<Vector3Int> Enumerate(Vector3Int vec)
        {
            for (int x = 0; x < vec.x; x++)
            {
                for (int y = 0; y < vec.y; y++)
                {
                    for (int z = 0; z < vec.z; z++)
                    {
                        yield return new(x, y, z);
                    }
                }
            }
        }

        public static IEnumerable<Vector3Int> Enumerate(int _x, int _y, int _z)
        {
            for (int x = 0; x < _x; x++)
            {
                for (int y = 0; y < _y; y++)
                {
                    for (int z = 0; z < _z; z++)
                    {
                        yield return new(x, y, z);
                    }
                }
            }
        }

        public static IEnumerable<Vector3Int> Enumerate((int start, int stop) _x, (int start, int stop) _y, (int start, int stop) _z)
        {
            for (int x = _x.start; x < _x.stop; x++)
            {
                for (int y = _y.start; y < _y.stop; y++)
                {
                    for (int z = _z.start; z < _z.stop; z++)
                    {
                        yield return new(x, y, z);
                    }
                }
            }
        }

        public static IEnumerable<Vector3Int> Enumerate((int start, int stop, int step) _x, (int start, int stop, int step) _y, (int start, int stop, int step) _z)
        {
            if (_x.step == 0 || _y.step == 0 || _z.step == 0) throw new Exception("InfinityLoop.");

            if (_x.step > 0 && _y.step > 0 && _z.step > 0)
            {
                for (int x = _x.start; x < _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y < _y.stop; y += _y.step)
                    {
                        for (int z = _z.start; z < _z.stop; z += _z.step)
                        {
                            yield return new(x, y, z);
                        }
                    }
                }
            }
            else if (_x.step > 0 && _y.step > 0 && _z.step < 0)
            {
                for (int x = _x.start; x < _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y < _y.stop; y += _y.step)
                    {
                        for (int z = _z.start; z > _z.stop; z += _z.step)
                        {
                            yield return new(x, y, z);
                        }
                    }
                }
            }
            else if (_x.step > 0 && _y.step < 0 && _z.step > 0)
            {
                for (int x = _x.start; x < _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y > _y.stop; y += _y.step)
                    {
                        for (int z = _z.start; z < _z.stop; z += _z.step)
                        {
                            yield return new(x, y, z);
                        }
                    }
                }
            }
            else if (_x.step > 0 && _y.step < 0 && _z.step < 0)
            {
                for (int x = _x.start; x < _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y > _y.stop; y += _y.step)
                    {
                        for (int z = _z.start; z > _z.stop; z += _z.step)
                        {
                            yield return new(x, y, z);
                        }
                    }
                }
            }
            else if (_x.step < 0 && _y.step > 0 && _z.step > 0)
            {
                for (int x = _x.start; x > _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y < _y.stop; y += _y.step)
                    {
                        for (int z = _z.start; z < _z.stop; z += _z.step)
                        {
                            yield return new(x, y, z);
                        }
                    }
                }
            }
            else if (_x.step < 0 && _y.step > 0 && _z.step < 0)
            {
                for (int x = _x.start; x > _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y < _y.stop; y += _y.step)
                    {
                        for (int z = _z.start; z > _z.stop; z += _z.step)
                        {
                            yield return new(x, y, z);
                        }
                    }
                }
            }
            else if (_x.step < 0 && _y.step < 0 && _z.step > 0)
            {
                for (int x = _x.start; x > _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y > _y.stop; y += _y.step)
                    {
                        for (int z = _z.start; z < _z.stop; z += _z.step)
                        {
                            yield return new(x, y, z);
                        }
                    }
                }
            }
            else
            {
                for (int x = _x.start; x > _x.stop; x += _x.step)
                {
                    for (int y = _y.start; y > _y.stop; y += _y.step)
                    {
                        for (int z = _z.start; z > _z.stop; z += _z.step)
                        {
                            yield return new(x, y, z);
                        }
                    }
                }
            }
        }

        public static List<T> Shuffle<T>(this List<T> self)
        {
            int n = self.Count;
            List<T> ret = new(self);

            for (int i = n - 1; i >= 1; i--)
            {
                int j = Random.RandInt(0, i);
                (ret[i], ret[j]) = (ret[j], ret[i]);
            }

            return ret;
        }

        public static T RandomChoice<T>(this List<T> self)
        {
            return self[Random.RandInt(0, self.Count - 1)];
        }

        public static void Look<T>(this List<T> self)
        {
            string start = "List(";
            string end = ")";
            string middle = "";

            foreach ((int index, T value) in Enumerate(self))
            {
                if (index == 0)
                {
                    middle += $"{value}";
                }
                else
                {
                    middle += $", {value}";
                }
            }

            (start + middle + end).Show();
        }

        public static void Look<T1, T2>(this List<T1> self, Func<T1, T2> func)
        {
            string start = "List(";
            string end = ")";
            string middle = "";

            foreach ((int index, T1 value) in Enumerate(self))
            {
                if (index == 0)
                {
                    middle += $"{func(value)}";
                }
                else
                {
                    middle += $", {func(value)}";
                }
            }

            (start + middle + end).Show();
        }

        public static void Look<T>(this IEnumerable<T> self)
        {
            string start = "List(";
            string end = ")";
            string middle = "";

            foreach ((int index, T value) in Enumerate(self))
            {
                if (index == 0)
                {
                    middle += $"{value}";
                }
                else
                {
                    middle += $", {value}";
                }
            }

            (start + middle + end).Show();
        }

        public static void Look<T1, T2>(this IEnumerable<T1> self, Func<T1, T2> func)
        {
            string start = "List(";
            string end = ")";
            string middle = "";

            foreach ((int index, T1 value) in Enumerate(self))
            {
                if (index == 0)
                {
                    middle += $"{func(value)}";
                }
                else
                {
                    middle += $", {func(value)}";
                }
            }

            (start + middle + end).Show();
        }

        public static IEnumerable<(T1 e1, T2 e2)> Zip<T1, T2>(IEnumerable<T1> collection1, IEnumerable<T2> collection2)
        {
            using (IEnumerator<T1> IEr1 = collection1.GetEnumerator())
            using (IEnumerator<T2> IEr2 = collection2.GetEnumerator())
            {
                while (IEr1.MoveNext() && IEr2.MoveNext())
                {
                    yield return (IEr1.Current, IEr2.Current);
                }
            }
        }

        public static int Count(this IEnumerable<bool> self, bool val)
        {
            int num = 0;

            foreach (bool e in self)
            {
                if (e == val)
                {
                    num++;
                }
            }

            return num;
        }

        public static bool All(IEnumerable<bool> list)
        {
            foreach (bool e in list)
            {
                if (e != true)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any(IEnumerable<bool> list)
        {
            foreach (bool e in list)
            {
                if (e == true)
                {
                    return true;
                }
            }

            return false;
        }

        public static IEnumerable<T2> Make<T1, T2>(IEnumerable<T1> collection, Func<T1, T2> func)
        {
            foreach (T1 e in collection)
            {
                yield return func(e);
            }
        }

        public static IEnumerable<T2> Make<T1, T2>(IEnumerable<T1> collection, Func<T1, bool> condition, Func<T1, T2> func)
        {
            foreach (T1 e in collection)
            {
                if (condition(e))
                {
                    yield return func(e);
                }
            }
        }

        public static List<T> Set<T>(this List<T> self)
        {
            List<T> ret = new();
            foreach (T e in self)
            {
                if (!ret.Contains(e))
                {
                    ret.Add(e);
                }
            }

            return ret;
        }

        public static IEnumerable<T2> Map<T1, T2>(IEnumerable<T1> collection, Func<T1, T2> func)
        {
            foreach (T1 e in collection)
            {
                yield return func(e);
            }
        }

        public static void Map<T>(IEnumerable<T> collection, Action<T> act)
        {
            foreach (T e in collection)
            {
                act(e);
            }
        }

        public static (string key, T value) Find<T>(this List<(string key, T value)> self, string key)
        {
            for (int i = 0; i < self.Count; i++)
            {
                if (self[i].key == key)
                {
                    return self[i];
                }
            }
            throw new Exception();
        }

        /// <summary>Return true if the key was found.</summary>
        public static bool Target<T>(this List<(string key, T value)> self, string key, Func<(string key, T value), (string key, T value)> funcIfFound, Action<string> actIfNotFound)
        {
            for (int i = 0; i < self.Count; i++)
            {
                if (self[i].key == key)
                {
                    self[i] = funcIfFound((self[i].key, self[i].value));
                    return true;
                }
            }
            actIfNotFound(key);
            return false;
        }

        public static int Len<T>(this List<T> self)
        {
            return self.Count;
        }

        public static int Len<T>(this T[] self)
        {
            return self.Length;
        }

        public static int Sum(List<int> list)
        {
            int ret = 0;
            foreach (int e in list)
            {
                ret += e;
            }
            return ret;
        }

        public static float Sum(List<float> list)
        {
            float ret = 0;
            foreach (float e in list)
            {
                ret += e;
            }
            return ret;
        }

        public static IEnumerable<T> Slice<T>(this List<T> self, int stop)
        {
            for (int i = 0; i < stop; i++)
            {
                yield return self[i];
            }
        }

        public static IEnumerable<T> Slice<T>(this List<T> self, int start, int stop)
        {
            for (int i = start; i < stop; i++)
            {
                yield return self[i];
            }
        }

        public static IEnumerable<T> Slice<T>(this List<T> self, int start, int stop, int step)
        {
            if (step == 0) throw new Exception("InfinityLoop.");

            if (step > 0)
            {
                for (int i = start; i < stop; i += step)
                {
                    yield return self[i];
                }
            }
            else
            {
                for (int i = start; i > stop; i += step)
                {
                    yield return self[i];
                }
            }
        }

        public static IEnumerable<T> Reversed<T>(this List<T> self)
        {
            for (int i = self.Count - 1; i >= 0; i--)
            {
                yield return self[i];
            }
        }

        public static List<T> Sorted<T>(this List<T> self, bool isSmall2Big = true) where T : IComparable<T>
        {
            List<T> copiedSelf = new(self);
            if (isSmall2Big)
            {
                copiedSelf.Sort();
            }
            else
            {
                copiedSelf.Sort((a, b) => b.CompareTo(a));
            }
            return copiedSelf;
        }

        public static T Where<T>(this T[,] self, Vector2Int pos)
        {
            return self[pos.x, pos.y];
        }

        public static void Set<T>(this T[,] self, Vector2Int pos, T val)
        {
            self[pos.x, pos.y] = val;
        }

        public static T Where<T>(this T[,,] self, Vector3Int pos)
        {
            return self[pos.x, pos.y, pos.z];
        }

        public static void Set<T>(this T[,,] self, Vector3Int pos, T val)
        {
            self[pos.x, pos.y, pos.z] = val;
        }

        public static T Where<T>(this T[,] self, Vector2Int pos, Vector2Int ofst)
        {
            return self[pos.x + ofst.x, pos.y + ofst.y];
        }

        public static void Set<T>(this T[,] self, Vector2Int pos, Vector2Int ofst, T val)
        {
            self[pos.x + ofst.x, pos.y + ofst.y] = val;
        }

        public static T Where<T>(this T[,,] self, Vector3Int pos, Vector3Int ofst)
        {
            return self[pos.x + ofst.x, pos.y + ofst.y, pos.z + ofst.z];
        }

        public static void Set<T>(this T[,,] self, Vector3Int pos, Vector3Int ofst, T val)
        {
            self[pos.x + ofst.x, pos.y + ofst.y, pos.z + ofst.z] = val;
        }
    }

    public static class Flow
    {
        public static void Loop(Action action, uint loopNum)
        {
            for (int _ = 0; _ < loopNum; _++)
            {
                action();
            }
        }

        public static void Pass()
        {
            return;
        }

        public static T Pass<T>(T value)
        {
            return value;
        }

        public static void PassSelf<T1>(this T1 self)
        {
            return;
        }

        public static T2 PassSelf<T1, T2>(this T1 self, T2 value)
        {
            return value;
        }

        public static void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    public static class Tag
    {
        public static GameObject FindTag(this string self)
        {
            return GameObject.FindGameObjectWithTag(self);
        }

        public static T FindTag<T>(this string self) where T : Component
        {
            return GameObject.FindGameObjectWithTag(self).GetComponent<T>();
        }

        public static List<GameObject> FindsTag(this string self)
        {
            GameObject[] objsArray = GameObject.FindGameObjectsWithTag(self);
            List<GameObject> ret = new(objsArray);
            return ret;
        }

        public static List<T> FindsTag<T>(this string self) where T : Component
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(self);
            List<T> ret = Collection.Make(new List<GameObject>(objs), (e) => e.GetComponent<T>()).ToList();
            return ret;
        }

        public static bool HasTag(this Collider self, string tag)
        {
            return self.CompareTag(tag);
        }

        public static bool HasTag(this Collision self, string tag)
        {
            return self.gameObject.CompareTag(tag);
        }
    }

    public static class UI
    {
        public static void OnClick(this Button button, UnityEngine.Events.UnityAction call)
        {
            button.onClick.AddListener(call);
        }
    }

    public static class Instance
    {
        public static GameObject GetChild(this GameObject self, int index)
        {
            return self.transform.GetChild(index).gameObject;
        }

        public static GameObject GetGrandsChild(this GameObject self, params int[] indices)
        {
            Transform retTf = self.transform;
            for (int i = 0; i < indices.Length; i++)
            {
                retTf = retTf.GetChild(indices[i]);
            }
            return retTf.gameObject;
        }

        public static T GetChildComponent<T>(this GameObject self, int childIndex) where T : Component
        {
            return self.transform.GetChild(childIndex).GetComponent<T>();
        }

        public static T GetGrandsChildComponent<T>(this GameObject self, params int[] grandsChildIndices) where T : Component
        {
            return self.GetGrandsChild(grandsChildIndices).GetComponent<T>();
        }

        public static T GC<T>(this GameObject self) where T : Component
        {
            return self.GetComponent<T>();
        }

        public static T GCC<T>(this GameObject self, int childIndex) where T : Component
        {
            return self.GetChildComponent<T>(childIndex);
        }

        public static T GGCC<T>(this GameObject self, params int[] grandsChildIndices) where T : Component
        {
            return self.GetGrandsChildComponent<T>(grandsChildIndices);
        }
    }

    public static class Input
    {
        public static bool Up(this KeyCode keyCode)
        {
            return UnityEngine.Input.GetKeyUp(keyCode);
        }

        public static bool Down(this KeyCode keyCode)
        {
            return UnityEngine.Input.GetKeyDown(keyCode);
        }

        public static bool Stay(this KeyCode keyCode)
        {
            return UnityEngine.Input.GetKey(keyCode);
        }

        public static bool MouseUp(this int index)
        {
            return UnityEngine.Input.GetMouseButtonUp(index);
        }

        public static bool MouseDown(this int index)
        {
            return UnityEngine.Input.GetMouseButtonDown(index);
        }

        public static bool MouseStay(this int index)
        {
            return UnityEngine.Input.GetMouseButton(index);
        }
    }

    public static class Condition
    {
        public static bool IsIn(this int val, int min, int max, bool isMinInclude = true, bool isMaxInclude = true)
        {
            if (isMinInclude && isMaxInclude) return min <= val && val <= max;
            else if (!isMinInclude && isMaxInclude) return min < val && val <= max;
            else if (isMinInclude && !isMaxInclude) return min <= val && val < max;
            else return min < val && val < max;
        }

        public static bool IsIn(this float val, float min, float max, bool isMinInclude = true, bool isMaxInclude = true)
        {
            if (isMinInclude && isMaxInclude) return min <= val && val <= max;
            else if (!isMinInclude && isMaxInclude) return min < val && val <= max;
            else if (isMinInclude && !isMaxInclude) return min <= val && val < max;
            else return min < val && val < max;
        }

        public static bool IsIn(this Vector2Int val, int min, int max, bool isMinInclude = true, bool isMaxInclude = true)
        {
            if (isMinInclude && isMaxInclude) return (min <= val.x && val.x <= max) && (min <= val.y && val.y <= max);
            else if (!isMinInclude && isMaxInclude) return (min < val.x && val.x <= max) && (min < val.y && val.y <= max);
            else if (isMinInclude && !isMaxInclude) return (min <= val.x && val.x < max) && (min <= val.y && val.y < max);
            else return (min < val.x && val.x < max) && (min < val.y && val.y < max);
        }

        public static bool IsIn(this Vector3Int val, int min, int max, bool isMinInclude = true, bool isMaxInclude = true)
        {
            if (isMinInclude && isMaxInclude) return (min <= val.x && val.x <= max) && (min <= val.y && val.y <= max) && (min <= val.z && val.z <= max);
            else if (!isMinInclude && isMaxInclude) return (min < val.x && val.x <= max) && (min < val.y && val.y <= max) && (min < val.z && val.z <= max);
            else if (isMinInclude && !isMaxInclude) return (min <= val.x && val.x < max) && (min <= val.y && val.y < max) && (min <= val.z && val.z < max);
            else return (min < val.x && val.x < max) && (min < val.y && val.y < max) && (min < val.z && val.z < max);
        }

        public static bool IsIn(this Vector2 val, float min, float max, bool isMinInclude = true, bool isMaxInclude = true)
        {
            if (isMinInclude && isMaxInclude) return (min <= val.x && val.x <= max) && (min <= val.y && val.y <= max);
            else if (!isMinInclude && isMaxInclude) return (min < val.x && val.x <= max) && (min < val.y && val.y <= max);
            else if (isMinInclude && !isMaxInclude) return (min <= val.x && val.x < max) && (min <= val.y && val.y < max);
            else return (min < val.x && val.x < max) && (min < val.y && val.y < max);
        }

        public static bool IsIn(this Vector3 val, float min, float max, bool isMinInclude = true, bool isMaxInclude = true)
        {
            if (isMinInclude && isMaxInclude) return (min <= val.x && val.x <= max) && (min <= val.y && val.y <= max) && (min <= val.z && val.z <= max);
            else if (!isMinInclude && isMaxInclude) return (min < val.x && val.x <= max) && (min < val.y && val.y <= max) && (min < val.z && val.z <= max);
            else if (isMinInclude && !isMaxInclude) return (min <= val.x && val.x < max) && (min <= val.y && val.y < max) && (min <= val.z && val.z < max);
            else return (min < val.x && val.x < max) && (min < val.y && val.y < max) && (min < val.z && val.z < max);
        }
    }

    public static class Colors
    {
        public static readonly Color AliceBlue = new Color32(240, 248, 255, 255);
        public static readonly Color AntiqueWhite = new Color32(250, 235, 215, 255);
        public static readonly Color Aqua = new Color32(0, 255, 255, 255);
        public static readonly Color Aquamarine = new Color32(127, 255, 212, 255);
        public static readonly Color Azure = new Color32(240, 255, 255, 255);
        public static readonly Color Beige = new Color32(245, 245, 220, 255);
        public static readonly Color Bisque = new Color32(255, 228, 196, 255);
        public static readonly Color Black = new Color32(0, 0, 0, 255);
        public static readonly Color BlanchedAlmond = new Color32(255, 235, 205, 255);
        public static readonly Color Blue = new Color32(0, 0, 255, 255);
        public static readonly Color BlueViolet = new Color32(138, 43, 226, 255);
        public static readonly Color Brown = new Color32(165, 42, 42, 255);
        public static readonly Color Burlywood = new Color32(222, 184, 135, 255);
        public static readonly Color CadetBlue = new Color32(95, 158, 160, 255);
        public static readonly Color Chartreuse = new Color32(127, 255, 0, 255);
        public static readonly Color Chocolate = new Color32(210, 105, 30, 255);
        public static readonly Color Coral = new Color32(255, 127, 80, 255);
        public static readonly Color CornflowerBlue = new Color32(100, 149, 237, 255);
        public static readonly Color Cornsilk = new Color32(255, 248, 220, 255);
        public static readonly Color Crimson = new Color32(220, 20, 60, 255);
        public static readonly Color Cyan = new Color32(0, 255, 255, 255);
        public static readonly Color DarkBlue = new Color32(0, 0, 139, 255);
        public static readonly Color DarkCyan = new Color32(0, 139, 139, 255);
        public static readonly Color DarkGoldenrod = new Color32(184, 134, 11, 255);
        public static readonly Color DarkGray = new Color32(169, 169, 169, 255);
        public static readonly Color DarkGreen = new Color32(0, 100, 0, 255);
        public static readonly Color DarkKhaki = new Color32(189, 183, 107, 255);
        public static readonly Color DarkMagenta = new Color32(139, 0, 139, 255);
        public static readonly Color DarkOliveGreen = new Color32(85, 107, 47, 255);
        public static readonly Color DarkOrange = new Color32(255, 140, 0, 255);
        public static readonly Color DarkOrchid = new Color32(153, 50, 204, 255);
        public static readonly Color DarkRed = new Color32(139, 0, 0, 255);
        public static readonly Color DarkSalmon = new Color32(233, 150, 122, 255);
        public static readonly Color DarkSeaGreen = new Color32(143, 188, 143, 255);
        public static readonly Color DarkSlateBlue = new Color32(72, 61, 139, 255);
        public static readonly Color DarkSlateGray = new Color32(47, 79, 79, 255);
        public static readonly Color DarkTurquoise = new Color32(0, 206, 209, 255);
        public static readonly Color DarkViolet = new Color32(148, 0, 211, 255);
        public static readonly Color DeepPink = new Color32(255, 20, 147, 255);
        public static readonly Color DeepSkyBlue = new Color32(0, 191, 255, 255);
        public static readonly Color DimGray = new Color32(105, 105, 105, 255);
        public static readonly Color DodgerBlue = new Color32(30, 144, 255, 255);
        public static readonly Color FireBrick = new Color32(178, 34, 34, 255);
        public static readonly Color FloralWhite = new Color32(255, 250, 240, 255);
        public static readonly Color ForestGreen = new Color32(34, 139, 34, 255);
        public static readonly Color Fuchsia = new Color32(255, 0, 255, 255);
        public static readonly Color Gainsboro = new Color32(220, 220, 220, 255);
        public static readonly Color GhostWhite = new Color32(248, 248, 255, 255);
        public static readonly Color Gold = new Color32(255, 215, 0, 255);
        public static readonly Color Goldenrod = new Color32(218, 165, 32, 255);
        public static readonly Color Gray = new Color32(128, 128, 128, 255);
        public static readonly Color Green = new Color32(0, 128, 0, 255);
        public static readonly Color GreenYellow = new Color32(173, 255, 47, 255);
        public static readonly Color Honeydew = new Color32(240, 255, 240, 255);
        public static readonly Color HotPink = new Color32(255, 105, 180, 255);
        public static readonly Color IndianRed = new Color32(205, 92, 92, 255);
        public static readonly Color Indigo = new Color32(75, 0, 130, 255);
        public static readonly Color Ivory = new Color32(255, 255, 240, 255);
        public static readonly Color Khaki = new Color32(240, 230, 140, 255);
        public static readonly Color Lavender = new Color32(230, 230, 250, 255);
        public static readonly Color Lavenderblush = new Color32(255, 240, 245, 255);
        public static readonly Color LawnGreen = new Color32(124, 252, 0, 255);
        public static readonly Color LemonChiffon = new Color32(255, 250, 205, 255);
        public static readonly Color LightBlue = new Color32(173, 216, 230, 255);
        public static readonly Color LightCoral = new Color32(240, 128, 128, 255);
        public static readonly Color LightCyan = new Color32(224, 255, 255, 255);
        public static readonly Color LightGoldenodYellow = new Color32(250, 250, 210, 255);
        public static readonly Color LightGray = new Color32(211, 211, 211, 255);
        public static readonly Color LightGreen = new Color32(144, 238, 144, 255);
        public static readonly Color LightPink = new Color32(255, 182, 193, 255);
        public static readonly Color LightSalmon = new Color32(255, 160, 122, 255);
        public static readonly Color LightSeaGreen = new Color32(32, 178, 170, 255);
        public static readonly Color LightSkyBlue = new Color32(135, 206, 250, 255);
        public static readonly Color LightSlateGray = new Color32(119, 136, 153, 255);
        public static readonly Color LightSteelBlue = new Color32(176, 196, 222, 255);
        public static readonly Color LightYellow = new Color32(255, 255, 224, 255);
        public static readonly Color Lime = new Color32(0, 255, 0, 255);
        public static readonly Color LimeGreen = new Color32(50, 205, 50, 255);
        public static readonly Color Linen = new Color32(250, 240, 230, 255);
        public static readonly Color Magenta = new Color32(255, 0, 255, 255);
        public static readonly Color Maroon = new Color32(128, 0, 0, 255);
        public static readonly Color MediumAquamarine = new Color32(102, 205, 170, 255);
        public static readonly Color MediumBlue = new Color32(0, 0, 205, 255);
        public static readonly Color MediumOrchid = new Color32(186, 85, 211, 255);
        public static readonly Color MediumPurple = new Color32(147, 112, 219, 255);
        public static readonly Color MediumSeaGreen = new Color32(60, 179, 113, 255);
        public static readonly Color MediumSlateBlue = new Color32(123, 104, 238, 255);
        public static readonly Color MediumSpringGreen = new Color32(0, 250, 154, 255);
        public static readonly Color MediumTurquoise = new Color32(72, 209, 204, 255);
        public static readonly Color MediumVioletRed = new Color32(199, 21, 133, 255);
        public static readonly Color MidnightBlue = new Color32(25, 25, 112, 255);
        public static readonly Color Mintcream = new Color32(245, 255, 250, 255);
        public static readonly Color MistyRose = new Color32(255, 228, 225, 255);
        public static readonly Color Moccasin = new Color32(255, 228, 181, 255);
        public static readonly Color NavajoWhite = new Color32(255, 222, 173, 255);
        public static readonly Color Navy = new Color32(0, 0, 128, 255);
        public static readonly Color OldLace = new Color32(253, 245, 230, 255);
        public static readonly Color Olive = new Color32(128, 128, 0, 255);
        public static readonly Color Olivedrab = new Color32(107, 142, 35, 255);
        public static readonly Color Orange = new Color32(255, 165, 0, 255);
        public static readonly Color Orangered = new Color32(255, 69, 0, 255);
        public static readonly Color Orchid = new Color32(218, 112, 214, 255);
        public static readonly Color PaleGoldenrod = new Color32(238, 232, 170, 255);
        public static readonly Color PaleGreen = new Color32(152, 251, 152, 255);
        public static readonly Color PaleTurquoise = new Color32(175, 238, 238, 255);
        public static readonly Color PaleVioletred = new Color32(219, 112, 147, 255);
        public static readonly Color PapayaWhip = new Color32(255, 239, 213, 255);
        public static readonly Color PeachPuff = new Color32(255, 218, 185, 255);
        public static readonly Color Peru = new Color32(205, 133, 63, 255);
        public static readonly Color Pink = new Color32(255, 192, 203, 255);
        public static readonly Color Plum = new Color32(221, 160, 221, 255);
        public static readonly Color PowderBlue = new Color32(176, 224, 230, 255);
        public static readonly Color Purple = new Color32(128, 0, 128, 255);
        public static readonly Color Red = new Color32(255, 0, 0, 255);
        public static readonly Color RosyBrown = new Color32(188, 143, 143, 255);
        public static readonly Color RoyalBlue = new Color32(65, 105, 225, 255);
        public static readonly Color SaddleBrown = new Color32(139, 69, 19, 255);
        public static readonly Color Salmon = new Color32(250, 128, 114, 255);
        public static readonly Color SandyBrown = new Color32(244, 164, 96, 255);
        public static readonly Color SeaGreen = new Color32(46, 139, 87, 255);
        public static readonly Color Seashell = new Color32(255, 245, 238, 255);
        public static readonly Color Sienna = new Color32(160, 82, 45, 255);
        public static readonly Color Silver = new Color32(192, 192, 192, 255);
        public static readonly Color SkyBlue = new Color32(135, 206, 235, 255);
        public static readonly Color SlateBlue = new Color32(106, 90, 205, 255);
        public static readonly Color SlateGray = new Color32(112, 128, 144, 255);
        public static readonly Color Snow = new Color32(255, 250, 250, 255);
        public static readonly Color SpringGreen = new Color32(0, 255, 127, 255);
        public static readonly Color SteelBlue = new Color32(70, 130, 180, 255);
        public static readonly Color Tan = new Color32(210, 180, 140, 255);
        public static readonly Color Teal = new Color32(0, 128, 128, 255);
        public static readonly Color Thistle = new Color32(216, 191, 216, 255);
        public static readonly Color Tomato = new Color32(255, 99, 71, 255);
        public static readonly Color Turquoise = new Color32(64, 224, 208, 255);
        public static readonly Color Violet = new Color32(238, 130, 238, 255);
        public static readonly Color Wheat = new Color32(245, 222, 179, 255);
        public static readonly Color White = new Color32(255, 255, 255, 255);
        public static readonly Color WhiteSmoke = new Color32(245, 245, 245, 255);
        public static readonly Color Yellow = new Color32(255, 255, 0, 255);
        public static readonly Color YellowGreen = new Color32(154, 205, 50, 255);
    }
}