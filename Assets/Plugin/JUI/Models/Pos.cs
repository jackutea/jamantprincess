using System;
using System.Text;
using UnityEngine;

[Serializable]
public struct Pos {

    static Pos() {
        zero = new Pos(0, 0);
        stringBuilder = new StringBuilder();
    }

    public Pos(Pos _pos) {
        m_x = (byte)_pos.x;
        m_y = (byte)_pos.y;
    }

    public Pos(byte _x, byte _y) {
        m_x = _x;
        m_y = _y;
    }

    public Pos(int _x, int _y) {
        m_x = (byte)_x;
        m_y = (byte)_y;
    }

    readonly static Pos zero;
    public static Pos Zero {
        get { return zero; }
    }

    byte m_x;
    public int x {
        get { return m_x; }
    }
    public void SetX(int _x) {
        m_x = (byte)_x;
    }

    byte m_y;
    public int y {
        get { return m_y; }
    }
    public void SetY(int _y) {
        m_y = (byte)_y;
    }

    public int this[int _index] {
        get {
            if (_index == 0) {
                return x;
            } else if (_index == 1) {
                return y;
            }
            throw new Exception("Index Must Be 0 or 1");
        }
    }

    static StringBuilder stringBuilder;
    public override string ToString() {
        stringBuilder.Clear();
        stringBuilder.Append(x);
        stringBuilder.Append(",");
        stringBuilder.Append(y);
        return stringBuilder.ToString();
    }

    public bool EqualPos(Pos _targetPos) {
        if (x == _targetPos.x && y == _targetPos.y) {
            return true;
        } else {
            return false;
        }
    }

    public static bool EqualPos(Pos _posA, Pos _posB) {
        if (_posA[0] == _posB[0] && _posA[1] == _posB[1]) {
            return true;
        } else {
            return false;
        }
    }

    public static int GetDistance(Pos _posA, Pos _posB) {

        int _xoff = Math.Abs(_posA[0] - _posB[0]);
        int _yoff = Math.Abs(_posA[1] - _posB[1]);

        int _dis = _xoff > _yoff ? _xoff : _yoff;

        return _dis;
        
    }

    public static int GetOppositeRadius(Pos _posA, Pos _posB) {

        int xoff = Math.Abs(_posA[0] - _posB[0]);
        int yoff = Math.Abs(_posA[1] - _posB[1]);

        int radius = (int)Math.Sqrt(xoff * xoff + yoff * yoff);

        return radius;

    }

}

public static class PosExtention {

    public static Pos SetPos(ref this Pos _pos, int _x, int _y) {
        _pos.SetX(_x);
        _pos.SetY(_y);
        return _pos;
    }

    public static Pos SetPos(ref this Pos _pos, Pos _posTarget) {
        _pos.SetX(_posTarget.x);
        _pos.SetY(_posTarget.y);
        return _pos;
    }

    public static Pos SetAndReturn(this Pos _pos, int _x, int _y) {
        _pos.SetX(_x);
        _pos.SetY(_y);
        return _pos;
    }

    public static Pos SetAndReturn(this Pos _pos, Pos _posTarget) {
        _pos.SetX(_posTarget.x);
        _pos.SetY(_posTarget.y);
        return _pos;
    }

    public static Vector3Int ToV3Int(this Pos _pos) {
        Vector3Int _v3 = Vector3Int.zero;
        _v3.Set(_pos.x, _pos.y, 0);
        return _v3;
    }

}