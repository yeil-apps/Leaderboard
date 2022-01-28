using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject PlayerAddPanel;
    public Text EditName;
    public Text EditScore;

    public GameObject PlayerEditPanel;
    public Text AddName;
    public Text AddScore;

    private ItemSpawner _itemSpawner;
    private void Start()
    {
        _itemSpawner = GameObject.FindObjectOfType<ItemSpawner>();
    }
    public void ShowAddPlayerPanel()
    {
        PlayerAddPanel.SetActive(true);
        AddName.text = "";
        AddScore.text = "";
    }

    public void HidePlayerAddPanel()
    {
        PlayerAddPanel.SetActive(false);
    }

    public void AddPlayer()
    {
        int newPoints;
        int.TryParse(AddScore.text, out newPoints);
        _itemSpawner.AddItem(AddName.text, newPoints);
        HidePlayerAddPanel();
    }

    public void EditPlayer()
    {
        int newPoints;
        int.TryParse(EditScore.text, out newPoints);
        _itemSpawner.EditItem(EditName.text, newPoints);
        HideEditPlayerPanel();
    }

    public void DeletePlayer()
    {
        _itemSpawner.DeleteItem();
    }

    public void ShowEditPlayerPanel()
    {
        PlayerEditPanel.SetActive(true);
    }

    public void HideEditPlayerPanel()
    {
        PlayerEditPanel.SetActive(false);
    }
}
