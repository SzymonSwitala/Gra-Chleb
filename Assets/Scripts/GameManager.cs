using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int listLength;
    [SerializeField] int minListLength;
    [SerializeField] int maxListLength;
    [SerializeField] TextMeshProUGUI shoppingListText;
    [SerializeField] private GameObject sheetGO;
    [SerializeField] private int listShowTime;
    [SerializeField] private Slider timeSlider;

    void Start()
    {
        GenerateShoppingList();
        StartCoroutine(ShowListAndCountdown());
    }

    private void GenerateShoppingList()
    {
        listLength = Random.Range(minListLength, maxListLength);
        Debug.Log("list length " + listLength);
    }
    private IEnumerator ShowListAndCountdown()
    {
        float counter = listShowTime;
        timeSlider.maxValue = counter;
        sheetGO.SetActive(true);

        while (counter>0)
        {
            counter -= Time.deltaTime;
            timeSlider.value = counter;
            yield return null;
        }
        sheetGO.SetActive(false);

    }
   
}
