using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerItem
{
    // ��� ������ � ���������� ����� �������� �������������, �������/������ ���������� �� ������� ������� � ������
    [SerializeField] private string _nickname;
    public string Nickname
    {
        get { return _nickname; }
        set { _nickname = value; }
    }

    [SerializeField] private int _pointsCount;
    public int PointsCount
    {
        get { return _pointsCount; }
        set { _pointsCount = value; }
    }
}
