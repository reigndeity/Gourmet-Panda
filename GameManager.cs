using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Character Base Stats")]
    public float pandaBaseHP;
    public float pandaBaseAttack;
    public float pandaBaseDefense;
    public float pandaBaseSpeed;
    public float pandaBaseDodgeRate;
    public float pandaBaseCriticalDamage;
    public float pandaBaseCriticalRate;
    public float pandaBaseLootDropChance;
    public float pandaBaseProficiencyBonus;

    public TMP_Text textBaseHP;
    public TMP_Text textBaseAttack;
    public TMP_Text textBaseDefense;
    public TMP_Text textBaseSpeed;
    public TMP_Text textBaseDodgeRate;
    public TMP_Text textBaseCriticalDamage;
    public TMP_Text textBaseCriticalRate;
    public TMP_Text textBaseLootDropChance;
    public TMP_Text textBaseProficiencyBonus;


    [Header("Rotisseur Base Stats")]
    public float rotisseurBaseHP = 121;
    public float rotisseurBaseAttack = 28.5f;
    public float rotisseurBaseDefense = 24.8f;
    public float rotisseurBaseSpeed = 103;
    public float rotisseurBaseDodgeRate = 31.80f;
    public float rotisseurBaseCriticalDamage = 157.50f;
    public float rotisseurBaseCriticalRate = 10;
    public float rotisseurBaseLootDropChance = 50;
    public float rotisseurBaseProficiencyBonus = 150;

    [Header("Patissier Base Stats")]
    public float patissierBaseHP = 107;
    public float patissierBaseAttack = 19.5f;
    public float patissierBaseDefense = 21.6f;
    public float patissierBaseSpeed = 100;
    public float patissierBaseDodgeRate = 30;
    public float patissierBaseCriticalDamage = 150;
    public float patissierBaseCriticalRate = 15.20f;
    public float patissierBaseLootDropChance = 56.20f;
    public float patissierBaseProficiencyBonus = 168;

    [Header("Entremetier Base Stats")]
    public float entremetierBaseHP = 100;
    public float entremetierBaseAttack = 15;
    public float entremetierBaseDefense = 20;
    public float entremetierBaseSpeed = 109;
    public float entremetierBaseDodgeRate = 35.70f;
    public float entremetierBaseCriticalDamage = 172.50f;
    public float entremetierBaseCriticalRate = 11.50f;
    public float entremetierBaseLootDropChance = 52;
    public float entremetierBaseProficiencyBonus = 156;

    [Header("Modified Stats")]
    public float modifiedHP;
    public float modifiedAttack;
    public float modifiedDefense;
    public float modifiedSpeed;
    public float modifiedDodgeRate;
    public float modifiedCriticalDamage;
    public float modifiedCriticalRate;
    public float modifiedLootDropChance;
    public float modifiedProficiencyBonus;

    public TMP_Text textModifiedHP;
    public TMP_Text textModifiedAttack;
    public TMP_Text textModifiedDefense;
    public TMP_Text textModifiedSpeed;
    public TMP_Text textModifiedDodgeRate;
    public TMP_Text textModifiedCriticalDamage;
    public TMP_Text textModifiedCriticalRate;
    public TMP_Text textModifiedLootDropChance;
    public TMP_Text textModifiedProficiencyBonus;

    [Header("Stat Points")]
    public int statPoint;
    public int pandaModifierSTR = 0;
    public int pandaModifierAGI = 0;
    public int pandaModifierLUCK = 0;
    public TMP_Text statPointText;
    private int totalStatPoints = 15;
    public TMP_Text valueSTR;
    public TMP_Text valueAGI;
    public TMP_Text valueLUCK;

    [Header("Misc")]
    public Button proceedButton;
    public Button strDeductButton;
    public Button strIncreaseButton;
    public Button agiDeductButton;
    public Button agiIncreaseButton;
    public Button lukDeductButton;
    public Button lukIncreaseButton;

    [Header("Chosen Characters")]
    public int chosenPandaCharacter;


    private void Update()
    {
        CalculateStat();
        UpdateUI();

        PlayerPrefs.SetInt("ChosenCharacter", chosenPandaCharacter);
        PlayerPrefs.SetFloat("ModifiedHP", Mathf.Ceil(modifiedHP));
        PlayerPrefs.SetFloat("ModifiedAttack", Mathf.Ceil(modifiedAttack));
        PlayerPrefs.SetFloat("ModifiedDefense", Mathf.Ceil(modifiedDefense));
        PlayerPrefs.SetFloat("ModifiedSpeed", Mathf.Ceil(modifiedSpeed));
        PlayerPrefs.SetFloat("ModifiedDodgeRate", Mathf.Ceil(modifiedDodgeRate));
        PlayerPrefs.SetFloat("ModifiedCriticalDamage", Mathf.Ceil(modifiedCriticalDamage));
        PlayerPrefs.SetFloat("ModifiedCriticalRate", Mathf.Ceil(modifiedCriticalRate));
        PlayerPrefs.SetFloat("ModifiedLootDropChance", Mathf.Ceil(modifiedLootDropChance));
        PlayerPrefs.SetFloat("ModifiedProficiencyBonus", Mathf.Ceil(modifiedProficiencyBonus));

        if (totalStatPoints == 0)
        {
            proceedButton.interactable = true;
            strIncreaseButton.interactable = false;
            strDeductButton.interactable = true;
            agiIncreaseButton.interactable = false;
            agiDeductButton.interactable = true;
            lukIncreaseButton.interactable = false;
            lukDeductButton.interactable = true;
        }
        else if (totalStatPoints < 15)
        {
            proceedButton.interactable = false;
            strIncreaseButton.interactable = true;
            strDeductButton.interactable = true;
            agiIncreaseButton.interactable = true;
            agiDeductButton.interactable = true;
            lukIncreaseButton.interactable = true;
            lukDeductButton.interactable = true;
        }
        else
        {
            proceedButton.interactable = false;
            strIncreaseButton.interactable = true;
            strDeductButton.interactable = false;
            agiIncreaseButton.interactable = true;
            agiDeductButton.interactable = false;
            lukIncreaseButton.interactable = true;
            lukDeductButton.interactable = false;
        }

    }

    


    public void UpdateUI()
    {
        textBaseHP.text = pandaBaseHP.ToString();
        textBaseAttack.text = pandaBaseAttack.ToString();
        textBaseDefense.text = pandaBaseDefense.ToString();
        textBaseSpeed.text = pandaBaseSpeed.ToString();
        textBaseDodgeRate.text = pandaBaseDodgeRate.ToString();
        textBaseCriticalDamage.text = pandaBaseCriticalDamage.ToString();
        textBaseCriticalRate.text = pandaBaseCriticalRate.ToString();
        textBaseLootDropChance.text = pandaBaseLootDropChance.ToString();
        textBaseProficiencyBonus.text = pandaBaseProficiencyBonus.ToString();

        textModifiedHP.text = modifiedHP.ToString("F1");
        textModifiedAttack.text = modifiedAttack.ToString("F1");
        textModifiedDefense.text = modifiedDefense.ToString("F1");
        textModifiedSpeed.text = modifiedSpeed.ToString("F1");
        textModifiedDodgeRate.text = modifiedDodgeRate.ToString("F1") + "%";
        textModifiedCriticalDamage.text = modifiedCriticalDamage.ToString("F1") + "%";
        textModifiedCriticalRate.text = modifiedCriticalRate.ToString("F1") + "%";
        textModifiedLootDropChance.text = modifiedLootDropChance.ToString("F1") + "%";
        textModifiedProficiencyBonus.text = modifiedProficiencyBonus.ToString("F1") + "%";

        statPointText.text = "" + totalStatPoints;
    }

    public void RotisseurOption() 
    {

        pandaBaseHP = rotisseurBaseHP;
        pandaBaseAttack = rotisseurBaseAttack;
        pandaBaseDefense = rotisseurBaseDefense;
        pandaBaseSpeed = rotisseurBaseSpeed;
        pandaBaseDodgeRate = rotisseurBaseDodgeRate;
        pandaBaseCriticalDamage = rotisseurBaseCriticalDamage;
        pandaBaseCriticalRate = rotisseurBaseCriticalRate;
        pandaBaseLootDropChance = rotisseurBaseLootDropChance;
        pandaBaseProficiencyBonus = rotisseurBaseProficiencyBonus;

        chosenPandaCharacter = 1;
    }

    public void PatissierOption()
    {
        pandaBaseHP = patissierBaseHP;
        pandaBaseAttack = patissierBaseAttack;
        pandaBaseDefense = patissierBaseDefense;
        pandaBaseSpeed = patissierBaseSpeed;
        pandaBaseDodgeRate = patissierBaseDodgeRate;
        pandaBaseCriticalDamage = patissierBaseCriticalDamage;
        pandaBaseCriticalRate = patissierBaseCriticalRate;
        pandaBaseLootDropChance = patissierBaseLootDropChance;
        pandaBaseProficiencyBonus = patissierBaseProficiencyBonus;

        chosenPandaCharacter = 2;
    }

    public void EntremetierOption()
    {
        pandaBaseHP = entremetierBaseHP;
        pandaBaseAttack = entremetierBaseAttack;
        pandaBaseDefense = entremetierBaseDefense;
        pandaBaseSpeed = entremetierBaseSpeed;
        pandaBaseDodgeRate = entremetierBaseDodgeRate;
        pandaBaseCriticalDamage = entremetierBaseCriticalDamage;
        pandaBaseCriticalRate = entremetierBaseCriticalRate;
        pandaBaseLootDropChance = entremetierBaseLootDropChance;
        pandaBaseProficiencyBonus = entremetierBaseProficiencyBonus;

        chosenPandaCharacter = 3;
    }

    public void CalculateStat()
    {
        // STRENGTH
        modifiedHP = pandaBaseHP + ((pandaBaseHP * 0.07f) * pandaModifierSTR);
        modifiedAttack = pandaBaseAttack + ((pandaBaseAttack * 0.30f) * pandaModifierSTR);
        modifiedDefense = pandaBaseDefense + ((pandaBaseDefense * 0.08f) * pandaModifierSTR);

        // AGILITY
        modifiedSpeed = pandaBaseSpeed * Mathf.Pow(1.03f, pandaModifierAGI);
        modifiedDodgeRate = pandaBaseDodgeRate * Mathf.Pow(1.06f, pandaModifierAGI);
        modifiedCriticalDamage = pandaBaseCriticalDamage + (7.5f * pandaModifierAGI);

        // LUCK
        modifiedCriticalRate = Mathf.Min((pandaBaseCriticalRate * Mathf.Pow(1.15f, pandaModifierLUCK)), 100f);
        modifiedLootDropChance = Mathf.Min(pandaBaseLootDropChance * Mathf.Pow(1.04f, pandaModifierLUCK), 100f);
        modifiedProficiencyBonus = pandaBaseProficiencyBonus + (6f * pandaModifierLUCK);
    }

    public void IncreaseSTR()
    {
        if (totalStatPoints > 0 && pandaModifierSTR < 15)
        {
            pandaModifierSTR++;
            valueSTR.text = pandaModifierSTR.ToString();
            totalStatPoints--;
            UpdateStats();
        }
    }

    public void DecreaseSTR()
    {
        if (pandaModifierSTR > 0)
        {
            pandaModifierSTR--;
            valueSTR.text = pandaModifierSTR.ToString();
            totalStatPoints++;
            UpdateStats();
        }
    }

    public void IncreaseAGI()
    {
        if (totalStatPoints > 0 && pandaModifierAGI < 15)
        {
            pandaModifierAGI++;
            valueAGI.text = pandaModifierAGI.ToString();
            totalStatPoints--;
            UpdateStats();
        }
    }

    public void DecreaseAGI()
    {
        if (pandaModifierAGI > 0)
        {
            pandaModifierAGI--;
            valueAGI.text = pandaModifierAGI.ToString();
            totalStatPoints++;;
            UpdateStats();
        }
    }

    public void IncreaseLUCK()
    {
        if (totalStatPoints > 0 && pandaModifierLUCK < 15)
        {
            pandaModifierLUCK++;
            valueLUCK.text = pandaModifierLUCK.ToString();
            totalStatPoints--;
            UpdateStats();

        }
    }

    public void DecreaseLUCK()
    {
        if (pandaModifierLUCK > 0)
        {
            pandaModifierLUCK--;
            valueLUCK.text = pandaModifierLUCK.ToString();
            totalStatPoints++;
            UpdateStats();


        }
    }

    private void UpdateStats()
    {
        CalculateStat();
        UpdateUI();
    }
}
