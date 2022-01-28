using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _parentGameObject; 
    [SerializeField] private GameObject _itemToSpawn;
    [SerializeField] private List<PlayerItem> _playerItems; // ���� � ����������� � �������

    [SerializeField] private int _mainItemIndex;
    public int MainItemIndex
    {
        get { return _mainItemIndex; }
        set
        {
            _mainItemIndex = value;
            ItemClick[] itemClick = GameObject.FindObjectsOfType<ItemClick>();
            foreach (ItemClick item in itemClick) //����� ����� ���� ������
            {
                item.CheckActiveElemet();
            }
        }
    }

    public int ActiveItemPointsCount
    {
        get { return _playerItems[MainItemIndex].PointsCount; }
    } // ���������� � ����������� � ��������� ��������

    public string ActiveItemNickName
    {
        get { return _playerItems[MainItemIndex].Nickname; }
    }

    void Start()
    {
        LoadItems();
    }

    public void LoadItems() // ����� ���������� � ������� � ���� ������ ��������� �� �����
    {
        SortList();
        for (int i = 0; i < _playerItems.Count; i++)
        {
            GameObject item = Instantiate(_itemToSpawn, _parentGameObject.transform);

            DisplayItemInfo displayItemInfo = item.GetComponent<DisplayItemInfo>();
            displayItemInfo.TextPosition.text = (i+1).ToString();
            displayItemInfo.TextNickname.text = _playerItems[i].Nickname;
            displayItemInfo.TextPointsCount.text = _playerItems[i].PointsCount.ToString();
        }
    }

    public void AddItem(string newNickname, int newPointsCount) // �������� ���������� ������ � ������
    {
        DeleteList();

        PlayerItem newItem = new PlayerItem();
        newItem.Nickname = newNickname;
        newItem.PointsCount = newPointsCount;
        _playerItems.Add(newItem);

        LoadItems();
    }

    public void DeleteList() // ������� ��� ����������� �������� ������� �� �����
    {
        DisplayItemInfo[] itemsToDestroy = GameObject.FindObjectsOfType<DisplayItemInfo>(); 
        foreach (DisplayItemInfo item in itemsToDestroy)
        {
            Destroy(item.transform.gameObject);
        }
    }

    public void DeleteItem() // ������� ���������� � ��������� ������ �� ������
    {
        DeleteList();

        _playerItems.Remove(_playerItems[MainItemIndex]);

        LoadItems();
    }

    public void EditItem(string newNickname, int newPointsCount) // ������������� ���������� � ������ � ������
    {
        DeleteList();

        _playerItems[MainItemIndex].Nickname = newNickname;
        _playerItems[MainItemIndex].PointsCount = newPointsCount;

        LoadItems();
    }

    private void SortList()
    {
        for (int i=0; i < _playerItems.Count; i++)
        {
            for (int j=0; j<_playerItems.Count-1; j++)
            {
                if (_playerItems[j].PointsCount < _playerItems[j + 1].PointsCount)
                {
                    PlayerItem tmpItem = _playerItems[j];
                    _playerItems[j] = _playerItems[j + 1];
                    _playerItems[j + 1] = tmpItem;
                }
            }
        }
    }
}
