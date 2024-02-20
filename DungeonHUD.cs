using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeonHUD : MonoBehaviour
{
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

  public void Awake()
  {
    this.healthAmount = PlayerPrefs.GetFloat("ModifiedHP");
    this.UpdateHealthUI();
  }

  public void Start() => this.ActivateSelectedPlayer();

  private void Update()
  {
    this.healthAmount = PlayerPrefs.GetFloat("battleHP");
    this.UpdateHealthUI();
    if (Input.GetKey(KeyCode.Tab))
      this.playerWorldStatHUD.SetActive(true);
    else
      this.playerWorldStatHUD.SetActive(false);
  }

  private void UpdateHealthUI()
  {
    this.healthValueHud.text = this.healthAmount.ToString();
    this.healthValue.text = this.healthAmount.ToString();
    this.attackValue.text = this.attackAmount.ToString();
    this.defenseValue.text = this.defenseAmount.ToString();
    this.speedValue.text = this.speedAmount.ToString();
    this.dodgeRateValue.text = this.dodgeRateAmount.ToString() + "%";
    this.criticalDamageValue.text = this.criticalDamageAmount.ToString() + "%";
    this.criticalRateValue.text = this.criticalRateAmount.ToString() + "%";
    this.lootDropChanceValue.text = this.lootDropChanceAmount.ToString() + "%";
    this.proficiencyBonusValue.text = this.proficiencyBonusAmount.ToString() + "%";
  }

  private void ActivateSelectedPlayer()
  {
    switch (PlayerPrefs.GetInt("ChosenCharacter"))
    {
      case 1:
        this.rotisseurWorldHUD.SetActive(true);
        SpriteMovement.playerInstance.GetComponent<SpriteMovement>().SetCanMove(true);
        this.CallUpdatedStats();
        break;
      case 2:
        this.patissierWorldHUD.SetActive(true);
        SpriteMovement.playerInstance.GetComponent<SpriteMovement>().SetCanMove(true);
        this.CallUpdatedStats();
        break;
      case 3:
        this.entremetierWorldHUD.SetActive(true);
        SpriteMovement.playerInstance.GetComponent<SpriteMovement>().SetCanMove(true);
        this.CallUpdatedStats();
        break;
      default:
        Debug.LogWarning((object) "Invalid ChosenCharacter value in PlayerPrefs.");
        break;
    }
  }

  public void CallUpdatedStats()
  {
    this.healthAmount = PlayerPrefs.GetFloat("battleHP");
    this.attackAmount = PlayerPrefs.GetFloat("battleAttack");
    this.defenseAmount = PlayerPrefs.GetFloat("battleDefense");
    this.speedAmount = PlayerPrefs.GetFloat("battleSpeed");
    this.dodgeRateAmount = PlayerPrefs.GetFloat("battleDodgeRate");
    this.criticalDamageAmount = PlayerPrefs.GetFloat("battleCriticalDamage");
    this.criticalRateAmount = PlayerPrefs.GetFloat("battleCriticalRate");
    this.lootDropChanceAmount = PlayerPrefs.GetFloat("battleLootDropChance");
    this.proficiencyBonusAmount = PlayerPrefs.GetFloat("battleProficiencyBonus");
    this.UpdateHealthUI();
  }
}
