using TMPro;

public class ItemManager : Singleton<ItemManager>
{

    public SOint coins;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiTextCoins.text = coins.value.ToString();
    }

    public void loseCoins(int amount = -1)
    {
        coins.value -= amount;
        UpdateUI();
    }
}

