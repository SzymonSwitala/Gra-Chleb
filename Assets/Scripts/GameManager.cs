using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[System.Serializable]
public class Bread
{
    [SerializeField] public string breadName;
    [SerializeField] public Sprite breadSprite;
}
public class GameManager : MonoBehaviour
{
    [SerializeField] private Table table;
    [SerializeField] private TextMeshProUGUI shoppingListText;
    [SerializeField] private GameObject sheetGO;
    [SerializeField] private Slider timeSlider;
    [SerializeField] private int listShowTime;
    [SerializeField] private Bread[] breadList;
    [SerializeField] private GameObject finishShoppingButton;

    [SerializeField] private int maxAmountOfBreadToBuy = 10;
    private int purchasedBreadCounter = 0;

    public int[] shoppingList;
    public int[] purchasedBreads;
  
    private void Start()
    {

        shoppingList = GenerateShoppingList();
        shoppingListText.text = GenerateShoppingListText(breadList, shoppingList, maxAmountOfBreadToBuy);
        StartCoroutine(ShowListAndCountdown());

        purchasedBreads = new int[breadList.Length];
    }
    private int[] GenerateShoppingList() // zwraca tablice z randomową ilością chlebków do zakupu
    {

        int[] index = new int[breadList.Length];

        for (int i = 0; i < maxAmountOfBreadToBuy; i++)
        {
            int randomBreadIndex = Random.Range(0, breadList.Length);
            index[randomBreadIndex]++;

        }
        return index;
    }
    private string GenerateShoppingListText(Bread[] breadList, int[] shoppingList, int maxAmountOfBreadToBuy) // zwraca string z wygenerowanym tekstem listy zakupów
    {
        string text = null;

        for (int i = 0; i < breadList.Length; i++)
        {

            if (shoppingList[i] != 0)
            {
                text += shoppingList[i] + " x " + breadList[i].breadName + "\n";
            }

        }
        return text;
    }
    private IEnumerator ShowListAndCountdown()
    {
        float counter = listShowTime;
        timeSlider.maxValue = counter;
        sheetGO.SetActive(true);

        while (counter > 0)
        {
            counter -= Time.deltaTime;
            timeSlider.value = counter;
            yield return null;
        }
        sheetGO.SetActive(false);

    }

    public void AddPurchasedBread(int index)
    {
        if (purchasedBreadCounter >= maxAmountOfBreadToBuy)
        {
            Debug.Log("Osiągnięto maksymalną ilość zakupionych chlebków");
            return;
        }
        purchasedBreadCounter++;
        purchasedBreads[index]++;
        table.SpawnBread(breadList[index].breadSprite);
      //  Debug.Log("dodano "+ breadList[index].breadName);

    }
    public void FinishShopping()
    {
        
        int maxScore = maxAmountOfBreadToBuy;
        int score = 0;
        for (int i=0;i< shoppingList.Length;i++)
        {
            score += Mathf.Min(shoppingList[i], purchasedBreads[i]);
        }
        Debug.Log("Zdobyłeś "+ score + " na "+ maxScore);

    }
}
