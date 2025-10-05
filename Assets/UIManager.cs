using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data.SqlTypes;

public class UIManager : MonoBehaviour
{

    public enum VariableType
    {
        Name,
        Health,
        XP,
        Score,
        Coins,
        Lives

    }

    public TMP_InputField nameInput;

    public TextMeshProUGUI nameUI;
    public TextMeshProUGUI healthUI;
    public TextMeshProUGUI XPUI;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI coinsUI;
    public TextMeshProUGUI LivesUI;

    private TextMeshProUGUI textMeshProUGUI;


    [SerializeField] private VariableType variableSelected;

    public int amount;

    private GameManager gameManager => GameManager.Instance;

    void Update()
    {
        nameUI.text = $"Name: {gameManager.PlayerName}";
        healthUI.text = $"Health: {gameManager.Health.ToString()}";
        XPUI.text = $"XP: {gameManager.Xp.ToString()}";
        scoreUI.text = $"score: {gameManager.Score.ToString()}";
        coinsUI.text = $"coins: {gameManager.Coins.ToString()}";
        LivesUI.text = $"lives: {gameManager.Lives.ToString()}";

        if (variableSelected == VariableType.Name)
        {
            nameInput.gameObject.SetActive(true);
        }
        else
        {
            nameInput.gameObject.SetActive(false);
        }
    }

    void ChangeName(string String)
    {
        gameManager.PlayerName = String;
    }
    public void NameSelected()
    {
        variableSelected = VariableType.Name;
        nameInput.onEndEdit.AddListener(ChangeName);
    }

    public void HealthSelected()
    {
        variableSelected = VariableType.Health;
    }

    public void XPSelected()
    {
        variableSelected = VariableType.XP;
    }

    public void ScoreSelected()
    {
        variableSelected = VariableType.Score;
    }

    public void CoinsSelected()
    {
        variableSelected = VariableType.Coins;
    }

    public void LivesSelected()
    {
        variableSelected = VariableType.Lives;
    }

    public void TakeAway()
    {
        switch (variableSelected)
        {
            case VariableType.Name:
                break;
            case VariableType.Health:
                gameManager.Health -= amount;
                break;
            case VariableType.XP:
                gameManager.Xp -= amount;
                break;
            case VariableType.Score:
                gameManager.Score -= amount;
                break;
            case VariableType.Coins:
                gameManager.Coins -= amount;
                break;
            case VariableType.Lives:
                gameManager.Lives -= amount;
                break;
        }
    }

    public void Add()
    {
        switch (variableSelected)
        {
            case VariableType.Name:
                break;
            case VariableType.Health:
                gameManager.Health += amount;
                break;
            case VariableType.XP:
                gameManager.Xp += amount;
                break;
            case VariableType.Score:
                gameManager.Score += amount;
                break;
            case VariableType.Coins:
                gameManager.Coins += amount;
                break;
            case VariableType.Lives:
                gameManager.Lives += amount;
                break;
        }
    }

    void DisableAllMenus()
    {
        nameUI.gameObject.SetActive(false);
        healthUI.gameObject.SetActive(false);
        XPUI.gameObject.SetActive(false);
        scoreUI.gameObject.SetActive(false);
        coinsUI.gameObject.SetActive(false);
        LivesUI.gameObject.SetActive(false);
    }
}
