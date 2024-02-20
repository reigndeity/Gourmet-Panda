using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class HUDManager : MonoBehaviour
{
    [Header("Character GameObjects")]
    // Player Object
    public GameObject rotisseurPlayer;
    public GameObject patissierPlayer;
    public GameObject entremetierPlayer;

    
    // Player World Hud
    public GameObject rotisseurWorldHUD;
    public GameObject patissierWorldHUD;
    public GameObject entremetierWorldHUD;

    [Header("World HUD Misc")]
    public TMP_Text healthValueHud;

    public TMP_Text healthValue;
    public TMP_Text attackValue;
    public TMP_Text defenseValue;
    public TMP_Text speedValue;
    public TMP_Text dodgeRateValue;
    public TMP_Text criticalDamageValue;
    public TMP_Text criticalRateValue;
    public TMP_Text lootDropChanceValue;
    public TMP_Text proficiencyBonusValue;

    public GameObject playerWorldStatHUD;

    [Header("Character Modified Stats")]
    public Image healthBar;
    public float healthAmount;
    public float attackAmount;
    public float defenseAmount;
    public float speedAmount;
    public float dodgeRateAmount;
    public float criticalDamageAmount;
    public float criticalRateAmount;
    public float lootDropChanceAmount;
    public float proficiencyBonusAmount;




    private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        // Get the Cinemachine Virtual Camera component
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        // Activate the player based on PlayerPrefs
        ActivateSelectedPlayer();

        // Follow the initially selected player
        SetCameraFollowTarget();

    }

    private void Update()
    {
        healthValueHud.text = healthAmount.ToString();

        healthValue.text = healthAmount.ToString();
        attackValue.text = attackAmount.ToString();
        defenseValue.text = defenseAmount.ToString();
        speedValue.text = speedAmount.ToString();
        dodgeRateValue.text = dodgeRateAmount.ToString() + "%";
        criticalDamageValue.text = criticalDamageAmount.ToString() + "%";
        criticalRateValue.text = criticalRateAmount.ToString() + "%";
        lootDropChanceValue.text = lootDropChanceAmount.ToString() + "%";
        proficiencyBonusValue.text= proficiencyBonusAmount.ToString() + "%";


        // testing

        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.H)) 
        {
            Heal(10);        
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            playerWorldStatHUD.SetActive(true); 
        }
        else
        {
            playerWorldStatHUD.SetActive(false);
        }

        // delete testing when done

    }

    private void ActivateSelectedPlayer()
    {
        int chosenCharacter = PlayerPrefs.GetInt("ChosenCharacter");


        // Activate the selected player
        switch (chosenCharacter)
        {
            case 1:
                rotisseurPlayer.SetActive(true);
                rotisseurWorldHUD.SetActive(true);
                SpriteMovement.playerInstance.GetComponent<SpriteMovement>().SetCanMove(true);
                CallModifiedStats();
                break;
            case 2:
                patissierPlayer.SetActive(true);
                patissierWorldHUD.SetActive(true);
                SpriteMovement.playerInstance.GetComponent<SpriteMovement>().SetCanMove(true);
                CallModifiedStats();
                break;
            case 3:
                entremetierPlayer.SetActive(true);
                entremetierWorldHUD.SetActive(true);
                SpriteMovement.playerInstance.GetComponent<SpriteMovement>().SetCanMove(true);
                CallModifiedStats();
                break;
            default:
                Debug.LogWarning("Invalid ChosenCharacter value in PlayerPrefs.");
                break;
        }
    }

    private void SetCameraFollowTarget()
    {
        int chosenCharacter = PlayerPrefs.GetInt("ChosenCharacter");

        // Find the selected player's transform
        Transform selectedPlayerTransform = null;

        switch (chosenCharacter)
        {
            case 1:
                selectedPlayerTransform = rotisseurPlayer.transform;
                break;
            case 2:
                selectedPlayerTransform = patissierPlayer.transform;
                break;
            case 3:
                selectedPlayerTransform = entremetierPlayer.transform;
                break;
            default:
                Debug.LogWarning("Invalid ChosenCharacter value in PlayerPrefs.");
                break;
        }

        // Set the Cinemachine Virtual Camera's follow target
        if (virtualCamera != null && selectedPlayerTransform != null)
        {
            virtualCamera.Follow = selectedPlayerTransform;
            virtualCamera.LookAt = selectedPlayerTransform;
        }
        else
        {
            Debug.LogError("Cinemachine Virtual Camera or selected player not found in the scene!");
        }
    }

    public void CallModifiedStats()
    {
        healthAmount = PlayerPrefs.GetFloat("ModifiedHP");
        attackAmount = PlayerPrefs.GetFloat("ModifiedAttack");
        defenseAmount = PlayerPrefs.GetFloat("ModifiedDefense");
        speedAmount = PlayerPrefs.GetFloat("ModifiedSpeed");
        dodgeRateAmount = PlayerPrefs.GetFloat("ModifiedDodgeRate");
        criticalDamageAmount = PlayerPrefs.GetFloat("ModifiedCriticalDamage");
        criticalRateAmount = PlayerPrefs.GetFloat("ModifiedCriticalRate");
        lootDropChanceAmount = PlayerPrefs.GetFloat("ModifiedLootDropChance");
        proficiencyBonusAmount = PlayerPrefs.GetFloat("ModifiedProficiencyBonus");
    }

    // testing area

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 249f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount+= healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmount);
        healthBar.fillAmount = healthAmount / 249f;
    }

    // delete testing area when done


}
