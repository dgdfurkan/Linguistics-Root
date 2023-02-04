using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    public GameObject inventoryPanel;

    public GameObject[] Slots;

    [SerializeField] private Transform lettersParent;
    [SerializeField] private GameObject letterPrefab;

    [SerializeField] private Letter letts;

    public List<string> ownLetterNames;
    public List<string> ownLetterNamesTemp;

    public string word;

    private void Start()
    {
        UpdateLetters();
    }

    public void UpdateLetters()
    {
        Instance = this;

        foreach (Lett item in letts.letters)
        {
            if (ownLetterNamesTemp.Contains(item.name))
            {
                Debug.Log(item.name);
                GameObject letterP = Instantiate(letterPrefab, lettersParent);

                letterP.name = item.name;
                letterP.transform.GetChild(0).GetComponent<Image>().sprite = item.sprite;
                ownLetterNamesTemp.Remove(item.name);

                letterP.GetComponent<Button>().onClick.AddListener(AddLetterToWrite);
            }
        }
    }

    public void AddLetterToWrite()
    {
        word = "";

        string letter = EventSystem.current.currentSelectedGameObject.name;
        Sprite letterS = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite;

        if (Slots[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "")
        {
            Slots[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = letter;
            Slots[0].GetComponent<Image>().sprite= letterS;
        }
        else if (Slots[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "")
        {
            Slots[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = letter;
            Slots[1].GetComponent<Image>().sprite = letterS;
        }
        else if (Slots[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "")
        {
            Slots[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = letter;
            Slots[2].GetComponent<Image>().sprite = letterS;
        }
        else if (Slots[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "")
        {
            Slots[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = letter;
            Slots[3].GetComponent<Image>().sprite = letterS;
        }
        else if (Slots[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "")
        {
            Slots[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = letter;
            Slots[4].GetComponent<Image>().sprite = letterS;
        }
        else if (Slots[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "")
        {
            Slots[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = letter;
            Slots[5].GetComponent<Image>().sprite = letterS;
        }
    }

    public void ResetWord()
    {
        word = "";
    }

    public void CheckWord()
    {
        word = Slots[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text + Slots[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text + Slots[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
            + Slots[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text + Slots[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text + Slots[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

        Debug.Log(word);

        switch (word)
        {
            case "fly":
                Debug.Log("fly");
                break;
            case "jump":
                Debug.Log("jump");
                break;
            case "slip":
                Debug.Log("slip");
                break;
            case "crouch":
                Debug.Log("crouch");
                break;
            case "climb":
                Debug.Log("climb");
                break;
        }
    }
}
