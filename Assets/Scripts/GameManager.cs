using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Bread
{
    [SerializeField] public string breadName;
    [SerializeField] public Sprite breadSprite;
}
public class GameManager : MonoBehaviour
{
    private int amountOfBreadToBuy; // liczba chlebków które zostaną wylosowane do zakupu
    [SerializeField] private int listShowTime; // czas pokazywania listy zakupów
    [SerializeField] private int startingMoney=20;
    [SerializeField] private int money=0; // liczba kasy na chelbki. 1 chlebek kosztuje 1 kasy

    [SerializeField] private Bread[] breadList;

    //panele
    [SerializeField] private Table table;
    [SerializeField] private TextMeshProUGUI shoppingListText;
    [SerializeField] private Slider timeSlider;
    [SerializeField] private GameObject shoppingListPanel;
    [SerializeField] private GameObject summaryPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private TextMeshProUGUI summaryPanelText;
    [SerializeField] private TextMeshProUGUI summaryShoppingList;
    [SerializeField] private TextMeshProUGUI summaryPurchaseList;
    [SerializeField] private TextMeshProUGUI moneyText;
   
    public int[] shoppingList; // tablica z iloscia chlebków w liscie zakupów
    public int[] purchasedBreads; // tablica z iloscią chlebków zakupionych przez gracza

    private void Start()
    {
        money=startingMoney;
        amountOfBreadToBuy = Random.Range(4, 8); // randomowe losowanie ilosci chlebkow w liscie zakupow
        summaryPanel.SetActive(false);
        mainPanel.SetActive(false);
        shoppingList = GenerateShoppingList();
        shoppingListText.text = GenerateShoppingListText(breadList, shoppingList, amountOfBreadToBuy);
        StartCoroutine(ShowListAndCountdown());

        purchasedBreads = new int[breadList.Length];
    }
    private int[] GenerateShoppingList() // zwraca tablice z randomową ilością chlebków do zakupu
    {

        int[] index = new int[breadList.Length];

        for (int i = 0; i < amountOfBreadToBuy; i++)
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
        shoppingListPanel.SetActive(true);

        while (counter > 0)
        {
            counter -= Time.deltaTime;
            timeSlider.value = counter;
            yield return null;
        }
        shoppingListPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void AddPurchasedBread(int index)
    {
        if (money <= 0)
        {
            Debug.Log("Nie masz kasy biedaku");
            return;
        }
        money--;
        moneyText.text = "Kasa: " + money + " zł";
        purchasedBreads[index]++;
        table.SpawnBread(breadList[index].breadSprite);

    }
    public void FinishShopping()
    {

        int maxScore = amountOfBreadToBuy;
        int score = 0;
        for (int i = 0; i < shoppingList.Length; i++)
        {
            score += Mathf.Min(shoppingList[i], purchasedBreads[i]);
        }

        summaryPanel.SetActive(true);
        int spendedMoney = startingMoney - money;
        float percent = (float)score / (float)maxScore * 100;
        //  summaryPanelText.text = (int)percent + "%";
        if (percent==100)
        {
            summaryPanelText.text = "Kupiłeś wszystkie potrzebne chlebki";

            if (spendedMoney > amountOfBreadToBuy)
            {

             
                summaryPanelText.text += " ,ale wydałeś na to o " + (spendedMoney - amountOfBreadToBuy) + " zł za dużo.";
            }
            else
            {
                summaryPanelText.text += ". Żona będzie zadowolona";
            }
        }
        else
        {
            summaryPanelText.text = "Nie kupiłeś wszystkich potrzebnych chlebków";
            if (spendedMoney > amountOfBreadToBuy)
            {

              
                summaryPanelText.text += " i jeszcze wydałeś na to o " + (spendedMoney - amountOfBreadToBuy) + " zł za dużo";
            }
            summaryPanelText.text += ". Żona będzie wciekła";
        }

       
    
        
        summaryShoppingList.text = GenerateShoppingListText(breadList, shoppingList, amountOfBreadToBuy);
        summaryPurchaseList.text = GenerateShoppingListText(breadList, purchasedBreads, amountOfBreadToBuy);
    }
}
