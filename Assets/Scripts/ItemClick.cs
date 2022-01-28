using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color _mainColor; // ���� ������ � ��������� �����
    [SerializeField] private Color _activeColor; // ���� ������ � ��������� ���������
    [SerializeField] private Image[] _backgrounds; // ����������� �������� 

    private int _index; // ������� � ������
    private ItemSpawner _itemSpawner;

    private void Start()
    {
        int.TryParse(transform.gameObject.GetComponent<DisplayItemInfo>().TextPosition.text, out _index);
        _index = _index - 1;
        _itemSpawner = GameObject.FindObjectOfType<ItemSpawner>();
    }

    public void CheckActiveElemet() // ����� ����� ���������
    {
        if (_itemSpawner.MainItemIndex == _index)
        {
            foreach (Image img in _backgrounds)
            {
                img.color = _activeColor;
            }
        }
        else
        {
            foreach (Image img in _backgrounds)
            {
                img.color = _mainColor;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ChooseThisItem();

            eventData.Reset();

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            EditThisItem();

            eventData.Reset();
        }
    }

    private void ChooseThisItem()
    {
        _itemSpawner.MainItemIndex = _index;
    }

    private void EditThisItem()
    {
        _itemSpawner.MainItemIndex = _index;
        GameObject.FindObjectOfType<UI>().ShowEditPlayerPanel();
    }
}
