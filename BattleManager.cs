using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BattleManager : MonoBehaviour
{
  [Header("Player MISC")]
  public GameObject battleRotisseur;
  public GameObject battlePatissier;
  public GameObject battleEntremetier;
  public TMP_Text battlePandaName;
  public bool canPlayerAttack = true;
  public Image battleHealthBar;
  public float ultimateSkill;
  public float energyRecharge;
  public Image rotisseurUltimateRecharge;
  public Image patissierUltimateRecharge;
  public Image entremetierUltimateRecharge;
  public GameObject playerWorldHud;
  public GameObject loseScreen;
  public GameObject winScreen;
  [Header("Battle Buttons")]
  public Button rotisseurBasicAttackButton;
  public Button patisseurBasicAttackButton;
  public Button entremetierBasicAttackButton;
  public Button rotisseurNormalSkillButton;
  public Button patisseurNormalSkillButton;
  public Button entremetierNormalSkillButton;
  public Button rotisseurUltimateSkillButton;
  public Button patisseurUltimateSkillButton;
  public Button entremetierUltimateSkillButton;
  [Header("Enemy MISC")]
  public GameObject MSGHealthBar;
  public GameObject MeatHealthBar;
  public GameObject DoughHealthBar;
  public GameObject VegetableHealthBar;
  public Image battleMSGHealthBar;
  public Image battleMeatHealthBar;
  public Image battleDoughHealthBar;
  public Image battleVegetableHealthBar;
  public GameObject battleMSGBoss;
  public GameObject battleMeat;
  public GameObject battleDough;
  public GameObject battleVegetable;
  public GameObject idlebattleMSGBoss;
  public GameObject idlebattleMeat;
  public GameObject idlebattleDough;
  public GameObject idlebattleVegetable;
  public TMP_Text battleEnemyName;
  public bool canEnemyAttack;
  [Header("Enemy Skill Effects")]
  public GameObject skillMSGBoss;
  public GameObject skillMeat;
  public GameObject skillDough;
  public GameObject skillVegetable;
  [Header("Player Normal Skill Effects")]
  public GameObject skillRotisseur;
  public GameObject skillPatissier;
  public GameObject skillEntremetier;
  [Header("Player Effects Overlay towards Enemy")]
  public GameObject rotisseurEffectsMSG;
  public GameObject patissierEffectsMSG;
  public GameObject entremetierEffectsMSG;
  public GameObject rotisseurEffectsMeat;
  public GameObject patissierEffectsMeat;
  public GameObject entremetierEffectsMeat;
  public GameObject rotisseurEffectsDough;
  public GameObject patissierEffectsDough;
  public GameObject entremetierEffectsDough;
  public GameObject rotisseurEffectsVegetable;
  public GameObject patissierEffectsVegetable;
  public GameObject entremetierEffectsVegetable;
  [Header("Player Current Stats")]
  public float currentBattlePlayerHP;
  public float currentBattlePlayerAttack;
  public float currentBattlePlayerDefense;
  public float currentBattlePlayerSpeed;
  public float currentBattlePlayerDodgeRate;
  public float currentBattlePlayerCriticalDamage;
  public float currentBattlePlayerCriticalRate;
  public float currentBattlePlayerLootDropChance;
  public float currentBattlePlayerProficiencyBonus;
  [Header("Player Updated Stats")]
  public float updatedPlayerHP;
  public float updatedPlayerAttack;
  public float updatedPlayerDefense;
  public float updatedPlayerSpeed;
  public float updatedPlayerDodgeRate;
  public float updatedPlayerCriticalDamage;
  public float updatedPlayerCriticalRate;
  public float updatedPlayerLootDropChance;
  public float updatedPlayerProficiencyBonus;
  [Header("Enemy Current Stats")]
  public float currentBattleEnemyHP;
  public float currentBattleEnemyAttack;
  public float currentBattleEnemyDefense;
  public float currentBattleEnemySpeed;
  public float currentBattleEnemyDodgeRate;
  public float currentBattleEnemyCriticalDamage;
  public float currentBattleEnemyCriticalRate;
  [Header("Enemy Updated Stats")]
  public float updatedEnemyHP;
  public float updatedEnemyAttack;
  public float updatedEnemyDefense;
  public float updatedEnemySpeed;
  public float updatedEnemyDodgeRate;
  public float updatedEnemyCriticalDamage;
  public float updatedEnemyCriticalRate;
  [Header("Battle Misc")]
  public GameObject battleScreen;
  public TMP_Text battlePlayerHealth;
  public TMP_Text battleEnemyHealth;
  public TMP_Text dialogueBox;
  [Header("MSG BOSS STATS")]
  public float msgBossHP = 500f;
  public float msgBossAttack = 55f;
  public float msgBossDefense = 50f;
  public float msgBossSpeed = 95f;
  public float msgBossDodgeRate = 15f;
  public float msgBossCriticalDamage = 180f;
  public float msgBossCriticalRate = 12f;
  public int currentMonster = 1;
  [Header("Meat STATS")]
  public float meatMonsterHP = 330f;
  public float meatMonsterAttack = 40f;
  public float meatMonsterDefense = 25f;
  public float meatMonsterSpeed = 117f;
  public float meatMonsterDodgeRate = 20f;
  public float meatMonsterCriticalDamage = 150f;
  public float meatMonsterCriticalRate = 10f;
  [Header("Dough STATS")]
  public float doughMonsterHP = 310f;
  public float doughMonsterAttack = 35f;
  public float doughMonsterDefense = 40f;
  public float doughMonsterSpeed = 111f;
  public float doughMonsterDodgeRate = 30f;
  public float doughMonsterCriticalDamage = 130f;
  public float doughMonsterCriticalRate = 15f;
  [Header("Vegetable Stats")]
  public float vegetableMonsterHP = 270f;
  public float vegetableMonsterAttack = 25f;
  public float vegetableMonsterDefense = 20f;
  public float vegetableMonsterSpeed = 120f;
  public float vegetableMonsterDodgeRate = 50f;
  public float vegetableMonsterCriticalDamage = 120f;
  public float vegetableMonsterCriticalRate = 27f;
  [Header("Rotisseur Normal Skill")]
  private float shieldDuration = 1f;
  private float shieldStrengthMultiplier = 1.5f;
  private float currentShieldStrength;
  [Header("Patisseur Normal Skill")]
  private float attackBoostMultiplier = 1.08f;
  private float currentAttackStrength = 1f;
  [Header("Dropped Objects")]
  public GameObject healingPotion1;
  public GameObject healingPotion2;
  public GameObject healingPotion3;

  private void Start()
  {
    this.ActivateBattleSelectedPlayer();
    this.currentBattlePlayerHP = PlayerPrefs.GetFloat("ModifiedHP");
    this.currentBattlePlayerAttack = PlayerPrefs.GetFloat("ModifiedAttack");
    this.currentBattlePlayerDefense = PlayerPrefs.GetFloat("ModifiedDefense");
    this.currentBattlePlayerSpeed = PlayerPrefs.GetFloat("ModifiedSpeed");
    this.currentBattlePlayerDodgeRate = PlayerPrefs.GetFloat("ModifiedDodgeRate");
    this.currentBattlePlayerCriticalDamage = PlayerPrefs.GetFloat("ModifiedCriticalDamage");
    this.currentBattlePlayerCriticalRate = PlayerPrefs.GetFloat("ModifiedCriticalRate");
    this.currentBattlePlayerLootDropChance = PlayerPrefs.GetFloat("ModifiedLootDropChance");
    this.currentBattlePlayerProficiencyBonus = PlayerPrefs.GetFloat("ModifiedProficiencyBonus");
    this.ResetUltimateSkill();
  }

  private void Update()
  {
    this.battlePlayerHealth.text = this.updatedPlayerHP.ToString();
    this.battleEnemyHealth.text = this.currentBattleEnemyHP.ToString();
    int num = PlayerPrefs.GetInt("ChosenCharacter");
    if ((double) this.ultimateSkill == 100.0)
    {
      switch (num)
      {
        case 1:
          this.rotisseurUltimateSkillButton.interactable = true;
          break;
        case 2:
          this.patisseurUltimateSkillButton.interactable = true;
          break;
        case 3:
          this.entremetierUltimateSkillButton.interactable = true;
          break;
      }
    }
    PlayerPrefs.SetFloat("battleHP", Mathf.Ceil(this.updatedPlayerHP));
    PlayerPrefs.SetFloat("battleAttack", Mathf.Ceil(this.updatedPlayerAttack));
    PlayerPrefs.SetFloat("battleDefense", Mathf.Ceil(this.updatedPlayerDefense));
    PlayerPrefs.SetFloat("battleSpeed", Mathf.Ceil(this.updatedPlayerSpeed));
    PlayerPrefs.SetFloat("battleDodgeRate", Mathf.Ceil(this.updatedPlayerDodgeRate));
    PlayerPrefs.SetFloat("battleCriticalDamage", Mathf.Ceil(this.updatedPlayerCriticalDamage));
    PlayerPrefs.SetFloat("battleCriticalRate", Mathf.Ceil(this.updatedPlayerCriticalRate));
    PlayerPrefs.SetFloat("battleLootDropChance", Mathf.Ceil(this.updatedPlayerLootDropChance));
    PlayerPrefs.SetFloat("battleProficiencyBonus", Mathf.Ceil(this.updatedPlayerProficiencyBonus));
  }

  public void ActivateBattleSelectedPlayer()
  {
    switch (PlayerPrefs.GetInt("ChosenCharacter"))
    {
      case 1:
        this.battleRotisseur.SetActive(true);
        this.battlePandaName.text = "ROTISSEUR";
        this.skillRotisseur.SetActive(true);
        this.updatedPlayerHP = this.currentBattlePlayerHP;
        this.updatedPlayerAttack = this.currentBattlePlayerAttack;
        this.updatedPlayerDefense = this.currentBattlePlayerDefense;
        this.updatedPlayerSpeed = this.currentBattlePlayerSpeed;
        this.updatedPlayerDodgeRate = this.currentBattlePlayerDodgeRate;
        this.updatedPlayerCriticalDamage = this.currentBattlePlayerCriticalDamage;
        this.updatedPlayerCriticalRate = this.currentBattlePlayerCriticalRate;
        this.updatedPlayerLootDropChance = this.currentBattlePlayerLootDropChance;
        this.updatedPlayerProficiencyBonus = this.currentBattlePlayerProficiencyBonus;
        break;
      case 2:
        this.battlePatissier.SetActive(true);
        this.battlePandaName.text = "PATISSIER";
        this.skillPatissier.SetActive(true);
        this.updatedPlayerHP = this.currentBattlePlayerHP;
        this.updatedPlayerAttack = this.currentBattlePlayerAttack;
        this.updatedPlayerDefense = this.currentBattlePlayerDefense;
        this.updatedPlayerSpeed = this.currentBattlePlayerSpeed;
        this.updatedPlayerDodgeRate = this.currentBattlePlayerDodgeRate;
        this.updatedPlayerCriticalDamage = this.currentBattlePlayerCriticalDamage;
        this.updatedPlayerCriticalRate = this.currentBattlePlayerCriticalRate;
        this.updatedPlayerLootDropChance = this.currentBattlePlayerLootDropChance;
        this.updatedPlayerProficiencyBonus = this.currentBattlePlayerProficiencyBonus;
        break;
      case 3:
        this.battleEntremetier.SetActive(true);
        this.battlePandaName.text = "ENTREMETIER";
        this.skillEntremetier.SetActive(true);
        this.updatedPlayerHP = this.currentBattlePlayerHP;
        this.updatedPlayerAttack = this.currentBattlePlayerAttack;
        this.updatedPlayerDefense = this.currentBattlePlayerDefense;
        this.updatedPlayerSpeed = this.currentBattlePlayerSpeed;
        this.updatedPlayerDodgeRate = this.currentBattlePlayerDodgeRate;
        this.updatedPlayerCriticalDamage = this.currentBattlePlayerCriticalDamage;
        this.updatedPlayerCriticalRate = this.currentBattlePlayerCriticalRate;
        this.updatedPlayerLootDropChance = this.currentBattlePlayerLootDropChance;
        this.updatedPlayerProficiencyBonus = this.currentBattlePlayerProficiencyBonus;
        break;
      default:
        Debug.LogWarning((object) "Invalid ChosenCharacter value in PlayerPrefs.");
        break;
    }
  }

  public void ActivateBattleSelectedEnemy()
  {
    int num = PlayerPrefs.GetInt("ChosenCharacter");
    switch (PlayerPrefs.GetInt("CurrentEnemy"))
    {
      case 1:
        this.battleMSGBoss.SetActive(true);
        this.battleEnemyName.text = "CHNoNa";
        this.battleScreen.SetActive(true);
        this.skillMSGBoss.SetActive(true);
        this.MSGHealthBar.SetActive(true);
        switch (num)
        {
          case 1:
            this.rotisseurEffectsMSG.SetActive(true);
            break;
          case 2:
            this.patissierEffectsMSG.SetActive(true);
            break;
          case 3:
            this.entremetierEffectsMSG.SetActive(true);
            break;
        }
        this.currentBattleEnemyHP = this.msgBossHP;
        this.currentBattleEnemyAttack = this.msgBossAttack;
        this.currentBattleEnemyDefense = this.msgBossDefense;
        this.currentBattleEnemySpeed = this.msgBossSpeed;
        this.currentBattleEnemyDodgeRate = this.msgBossDodgeRate;
        this.currentBattleEnemyCriticalDamage = this.msgBossCriticalDamage;
        this.currentBattleEnemyCriticalRate = this.msgBossCriticalRate;
        break;
      case 2:
        this.battleMeat.SetActive(true);
        this.battleEnemyName.text = "MEAT MONSTER";
        this.battleScreen.SetActive(true);
        this.skillMeat.SetActive(true);
        this.MeatHealthBar.SetActive(true);
        switch (num)
        {
          case 1:
            this.rotisseurEffectsMeat.SetActive(true);
            break;
          case 2:
            this.patissierEffectsMeat.SetActive(true);
            break;
          case 3:
            this.entremetierEffectsMeat.SetActive(true);
            break;
        }
        this.currentBattleEnemyHP = this.meatMonsterHP;
        this.currentBattleEnemyAttack = this.meatMonsterAttack;
        this.currentBattleEnemyDefense = this.meatMonsterDefense;
        this.currentBattleEnemySpeed = this.meatMonsterSpeed;
        this.currentBattleEnemyDodgeRate = this.meatMonsterDodgeRate;
        this.currentBattleEnemyCriticalDamage = this.meatMonsterCriticalDamage;
        this.currentBattleEnemyCriticalRate = this.meatMonsterCriticalRate;
        break;
      case 3:
        this.battleDough.SetActive(true);
        this.battleEnemyName.text = "DOUGH MONSTER";
        this.battleScreen.SetActive(true);
        this.skillDough.SetActive(true);
        this.DoughHealthBar.SetActive(true);
        switch (num)
        {
          case 1:
            this.rotisseurEffectsDough.SetActive(true);
            break;
          case 2:
            this.patissierEffectsDough.SetActive(true);
            break;
          case 3:
            this.entremetierEffectsDough.SetActive(true);
            break;
        }
        this.currentBattleEnemyHP = this.doughMonsterHP;
        this.currentBattleEnemyAttack = this.doughMonsterAttack;
        this.currentBattleEnemyDefense = this.doughMonsterDefense;
        this.currentBattleEnemySpeed = this.doughMonsterSpeed;
        this.currentBattleEnemyDodgeRate = this.doughMonsterDodgeRate;
        this.currentBattleEnemyCriticalDamage = this.doughMonsterCriticalDamage;
        this.currentBattleEnemyCriticalRate = this.doughMonsterCriticalRate;
        break;
      case 4:
        this.battleVegetable.SetActive(true);
        this.battleEnemyName.text = "VEGETABLE MONSTER";
        this.battleScreen.SetActive(true);
        this.skillVegetable.SetActive(true);
        this.VegetableHealthBar.SetActive(true);
        switch (num)
        {
          case 1:
            this.rotisseurEffectsVegetable.SetActive(true);
            break;
          case 2:
            this.patissierEffectsVegetable.SetActive(true);
            break;
          case 3:
            this.entremetierEffectsVegetable.SetActive(true);
            break;
        }
        this.currentBattleEnemyHP = 270f;
        this.currentBattleEnemyAttack = this.vegetableMonsterAttack;
        this.currentBattleEnemyDefense = this.vegetableMonsterDefense;
        this.currentBattleEnemySpeed = this.vegetableMonsterSpeed;
        this.currentBattleEnemyDodgeRate = this.vegetableMonsterDodgeRate;
        this.currentBattleEnemyCriticalDamage = this.vegetableMonsterCriticalDamage;
        this.currentBattleEnemyCriticalRate = this.vegetableMonsterCriticalRate;
        break;
      default:
        Debug.LogWarning((object) "Invalid Enemy value in PlayerPrefs.");
        break;
    }
  }

  public void BasicAttack()
  {
    if ((double) Random.value <= 0.800000011920929)
    {
      this.UltRecharge();
      if ((double) Random.value >= (double) this.currentBattleEnemyDodgeRate / 100.0)
      {
        float num = this.updatedPlayerAttack * (float) (1.0 - (double) this.currentBattleEnemyDefense * 0.6600000262260437 / 100.0);
        if ((double) Random.value < (double) this.updatedPlayerCriticalRate / 100.0)
        {
          num *= (float) (1.0 + (double) this.updatedPlayerCriticalDamage / 100.0);
          Debug.Log((object) "Critical hit!");
        }
        switch (PlayerPrefs.GetInt("ChosenCharacter"))
        {
          case 1:
            this.dialogueBox.text = "You used cleave slash!";
            this.rotisseurBasicAttackButton.interactable = false;
            this.rotisseurNormalSkillButton.interactable = false;
            this.rotisseurUltimateSkillButton.interactable = false;
            this.StartCoroutine(this.EnemyHpUpdateCoroutine(num));
            break;
          case 2:
            this.dialogueBox.text = "You used roller hit and dealt " + Mathf.Ceil(num).ToString() + " damage!";
            this.patisseurBasicAttackButton.interactable = false;
            this.patisseurNormalSkillButton.interactable = false;
            this.patisseurUltimateSkillButton.interactable = false;
            this.StartCoroutine(this.EnemyHpUpdateCoroutine(num));
            break;
          case 3:
            this.dialogueBox.text = "You used knife poke and dealt " + Mathf.Ceil(num).ToString() + " damage!";
            this.entremetierBasicAttackButton.interactable = false;
            this.entremetierNormalSkillButton.interactable = false;
            this.entremetierUltimateSkillButton.interactable = false;
            this.StartCoroutine(this.EnemyHpUpdateCoroutine(num));
            break;
        }
      }
      else
        this.StartCoroutine(this.EnemyDodgedAttack());
    }
    else
    {
      this.UltRecharge();
      switch (PlayerPrefs.GetInt("CurrentEnemy"))
      {
        case 2:
          this.MeatNormalSkill();
          break;
        case 3:
          this.DoughNormalSkill();
          break;
        case 4:
          this.VegetableNormalSkill();
          break;
        default:
          Debug.LogWarning((object) "Invalid Enemy value in PlayerPrefs.");
          break;
      }
    }
  }

  public void RotisseurNormalSkill()
  {
    this.UltRecharge();
    this.dialogueBox.text = "You used meat shield!";
    this.rotisseurBasicAttackButton.interactable = false;
    this.rotisseurNormalSkillButton.interactable = false;
    this.rotisseurUltimateSkillButton.interactable = false;
    this.ApplyShield(this.currentBattlePlayerDefense * this.shieldStrengthMultiplier);
    this.StartCoroutine(this.RemoveShieldAfterDuration(this.shieldDuration));
    this.StartCoroutine(this.WaitForShield());
  }

  private void ApplyShield(float strength) => this.currentShieldStrength = strength;

  private IEnumerator RemoveShieldAfterDuration(float duration)
  {
    yield return (object) new WaitForSeconds(8f);
    this.currentShieldStrength = 0.0f;
  }

  public void PatissierNormalSkill()
  {
    this.UltRecharge();
    this.dialogueBox.text = "You used Baker's Might!";
    this.patisseurBasicAttackButton.interactable = false;
    this.patisseurNormalSkillButton.interactable = false;
    this.patisseurUltimateSkillButton.interactable = false;
    this.ApplyAttackBoost(this.currentBattlePlayerAttack * (this.attackBoostMultiplier - 1f));
    this.StartCoroutine(this.RemoveAttackBoostAfterDuration(this.shieldDuration));
    this.StartCoroutine(this.WaitForAtkIncrease());
  }

  private void ApplyAttackBoost(float boost) => this.currentAttackStrength = boost + 1f;

  private IEnumerator RemoveAttackBoostAfterDuration(float duration)
  {
    yield return (object) new WaitForSeconds(8f);
    this.currentAttackStrength = 0.0f;
  }

  public void EntremetierNormalSkill(float healingAmount)
  {
    this.UltRecharge();
    healingAmount = 35f;
    this.updatedPlayerHP += Mathf.Ceil(healingAmount);
    this.updatedPlayerHP = Mathf.Clamp(this.updatedPlayerHP, 0.0f, this.currentBattlePlayerHP);
    this.battleHealthBar.fillAmount = Mathf.Ceil(this.updatedPlayerHP) / this.currentBattlePlayerHP;
    this.dialogueBox.text = "You used karen's meal!";
    this.entremetierBasicAttackButton.interactable = false;
    this.entremetierNormalSkillButton.interactable = false;
    this.entremetierUltimateSkillButton.interactable = false;
    this.canPlayerAttack = false;
    this.StartCoroutine(this.WaitForHeal());
  }

  private IEnumerator WaitForShield()
  {
    BattleManager battleManager = this;
    yield return (object) new WaitForSeconds(0.5f);
    battleManager.dialogueBox.text = "You created a shield equal to 150% of your defense!";
    yield return (object) new WaitForSeconds(1f);
    battleManager.StartCoroutine(battleManager.EnemyAttackAnimation());
  }

  private IEnumerator WaitForAtkIncrease()
  {
    BattleManager battleManager = this;
    yield return (object) new WaitForSeconds(0.5f);
    battleManager.dialogueBox.text = "Your attack got increased by 12%!";
    yield return (object) new WaitForSeconds(1f);
    battleManager.StartCoroutine(battleManager.EnemyAttackAnimation());
  }

  private IEnumerator WaitForHeal()
  {
    BattleManager battleManager = this;
    yield return (object) new WaitForSeconds(0.5f);
    battleManager.dialogueBox.text = "You got healed by 35 HP!";
    yield return (object) new WaitForSeconds(1f);
    battleManager.StartCoroutine(battleManager.EnemyAttackAnimation());
  }

  private IEnumerator EnemyAttackAnimation()
  {
    BattleManager battleManager = this;
    yield return (object) new WaitForSeconds(1.5f);
    int num = PlayerPrefs.GetInt("CurrentEnemy");
    if (num == 1)
    {
      if ((double) Random.value <= 0.5)
      {
        float customSpeed = 0.1f;
        battleManager.dialogueBox.text = "Enemy used amino smash!";
        Object.FindObjectOfType<MSGBossBattleMode>().PlayBasicAttackSprite(customSpeed);
        Object.FindObjectOfType<MSGBossSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed);
        battleManager.StartCoroutine(battleManager.EnemyAttack());
      }
      else
        battleManager.MsgNormalSkill();
    }
    if (num == 2)
    {
      float customSpeed = 0.1f;
      battleManager.dialogueBox.text = "Enemy used meat slap!";
      Object.FindObjectOfType<MeatBattleMode>().PlayBasicAttackSprite(customSpeed);
      Object.FindObjectOfType<MeatSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed);
      battleManager.StartCoroutine(battleManager.EnemyAttack());
    }
    if (num == 3)
    {
      float customSpeed = 0.1f;
      battleManager.dialogueBox.text = "Enemy used bread throw!";
      Object.FindObjectOfType<DoughBattleMode>().PlayBasicAttackSprite(customSpeed);
      Object.FindObjectOfType<DoughSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed);
      battleManager.StartCoroutine(battleManager.EnemyAttack());
    }
    if (num == 4)
    {
      float customSpeed = 0.1f;
      battleManager.dialogueBox.text = "Enemy used beet poke!";
      Object.FindObjectOfType<VegetableBattleMode>().PlayBasicAttackSprite(customSpeed);
      Object.FindObjectOfType<VegetableSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed);
      battleManager.StartCoroutine(battleManager.EnemyAttack());
    }
  }

  private IEnumerator EnemyDodgedAttack()
  {
    BattleManager battleManager = this;
    battleManager.rotisseurBasicAttackButton.interactable = false;
    battleManager.rotisseurNormalSkillButton.interactable = false;
    battleManager.rotisseurUltimateSkillButton.interactable = false;
    battleManager.patisseurBasicAttackButton.interactable = false;
    battleManager.patisseurNormalSkillButton.interactable = false;
    battleManager.patisseurUltimateSkillButton.interactable = false;
    battleManager.entremetierBasicAttackButton.interactable = false;
    battleManager.entremetierNormalSkillButton.interactable = false;
    battleManager.entremetierUltimateSkillButton.interactable = false;
    Debug.Log((object) "Enemy dodged the attack!");
    battleManager.dialogueBox.text = "Enemy dodged the attack!";
    yield return (object) new WaitForSeconds(1.5f);
    int num = PlayerPrefs.GetInt("CurrentEnemy");
    if (num == 1)
    {
      if ((double) Random.value <= 0.5)
      {
        float customSpeed = 0.1f;
        battleManager.dialogueBox.text = "Enemy used amino smash!";
        Object.FindObjectOfType<MSGBossBattleMode>().PlayBasicAttackSprite(customSpeed);
        Object.FindObjectOfType<MSGBossSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed);
        battleManager.StartCoroutine(battleManager.EnemyAttack());
      }
      else
        battleManager.MsgNormalSkill();
    }
    if (num == 2)
    {
      float customSpeed = 0.1f;
      battleManager.dialogueBox.text = "Enemy used meat slap!";
      Object.FindObjectOfType<MeatBattleMode>().PlayBasicAttackSprite(customSpeed);
      Object.FindObjectOfType<MeatSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed);
      battleManager.StartCoroutine(battleManager.EnemyAttack());
    }
    if (num == 3)
    {
      float customSpeed = 0.1f;
      battleManager.dialogueBox.text = "Enemy used bread throw!";
      Object.FindObjectOfType<DoughBattleMode>().PlayBasicAttackSprite(customSpeed);
      Object.FindObjectOfType<DoughSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed);
      battleManager.StartCoroutine(battleManager.EnemyAttack());
    }
    if (num == 4)
    {
      float customSpeed = 0.1f;
      battleManager.dialogueBox.text = "Enemy used beet poke!";
      Object.FindObjectOfType<VegetableBattleMode>().PlayBasicAttackSprite(customSpeed);
      Object.FindObjectOfType<VegetableSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed);
      battleManager.StartCoroutine(battleManager.EnemyAttack());
    }
  }

  private IEnumerator EnemyAttack()
  {
    BattleManager battleManager = this;
    battleManager.UltRecharge();
    int num1 = PlayerPrefs.GetInt("ChosenCharacter");
    float damageDealt;
    if ((double) Random.value >= (double) battleManager.currentBattlePlayerDodgeRate / 100.0)
    {
      switch (num1)
      {
        case 1:
          float hurtSpeed1 = 0.1f;
          Object.FindObjectOfType<RotisseurBattleMode>().PlayHurtSprite(hurtSpeed1);
          yield return (object) new WaitForSeconds(2f);
          damageDealt = battleManager.currentBattleEnemyAttack * (float) (1.0 - (double) battleManager.updatedPlayerDefense * 0.6600000262260437 / 100.0);
          if ((double) battleManager.currentShieldStrength > 0.0)
          {
            damageDealt -= battleManager.currentShieldStrength;
            damageDealt = Mathf.Max(0.0f, damageDealt);
          }
          battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage.";
          yield return (object) new WaitForSeconds(2f);
          if ((double) Random.value < (double) battleManager.currentBattleEnemyCriticalRate / 100.0)
          {
            damageDealt *= (float) (1.0 + (double) battleManager.currentBattleEnemyCriticalDamage / 100.0);
            Debug.Log((object) "Enemy critical hit!");
          }
          battleManager.updatedPlayerHP -= Mathf.Ceil(damageDealt);
          battleManager.battleHealthBar.fillAmount = Mathf.Ceil(battleManager.updatedPlayerHP) / battleManager.currentBattlePlayerHP;
          if ((double) battleManager.updatedPlayerHP <= 0.0)
          {
            battleManager.battleScreen.SetActive(false);
            Debug.Log((object) "Player defeated!");
            battleManager.loseScreen.SetActive(true);
            battleManager.playerWorldHud.SetActive(false);
            battleManager.canPlayerAttack = false;
            battleManager.canEnemyAttack = false;
            break;
          }
          int num2 = PlayerPrefs.GetInt("ChosenCharacter");
          if ((double) battleManager.ultimateSkill == 100.0)
          {
            if (num2 == 1)
              battleManager.rotisseurUltimateSkillButton.interactable = true;
            else if (num2 == 2)
              battleManager.patisseurUltimateSkillButton.interactable = true;
            else if (num2 == 3)
              battleManager.entremetierUltimateSkillButton.interactable = true;
          }
          if (num2 == 1)
          {
            battleManager.rotisseurBasicAttackButton.interactable = true;
            battleManager.rotisseurNormalSkillButton.interactable = true;
            battleManager.rotisseurUltimateSkillButton.interactable = false;
          }
          else if (num2 == 2)
          {
            battleManager.patisseurBasicAttackButton.interactable = true;
            battleManager.patisseurNormalSkillButton.interactable = true;
            battleManager.patisseurUltimateSkillButton.interactable = false;
          }
          else if (num2 == 3)
          {
            battleManager.entremetierBasicAttackButton.interactable = true;
            battleManager.entremetierNormalSkillButton.interactable = true;
            battleManager.entremetierUltimateSkillButton.interactable = false;
          }
          battleManager.canPlayerAttack = true;
          battleManager.dialogueBox.text = "What will you do?";
          break;
        case 2:
          float hurtSpeed2 = 0.1f;
          Object.FindObjectOfType<PatissierBattleMode>().PlayHurtSprite(hurtSpeed2);
          yield return (object) new WaitForSeconds(2f);
          damageDealt = battleManager.currentBattleEnemyAttack * (float) (1.0 - (double) battleManager.updatedPlayerDefense * 0.6600000262260437 / 100.0);
          battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage.";
          yield return (object) new WaitForSeconds(2f);
          if ((double) Random.value < (double) battleManager.currentBattleEnemyCriticalRate / 100.0)
          {
            damageDealt *= (float) (1.0 + (double) battleManager.currentBattleEnemyCriticalDamage / 100.0);
            Debug.Log((object) "Enemy critical hit!");
          }
          battleManager.updatedPlayerHP -= Mathf.Ceil(damageDealt);
          battleManager.battleHealthBar.fillAmount = Mathf.Ceil(battleManager.updatedPlayerHP) / battleManager.currentBattlePlayerHP;
          if ((double) battleManager.updatedPlayerHP <= 0.0)
          {
            battleManager.battleScreen.SetActive(false);
            Debug.Log((object) "Player defeated!");
            battleManager.loseScreen.SetActive(true);
            battleManager.playerWorldHud.SetActive(false);
            battleManager.canPlayerAttack = false;
            battleManager.canEnemyAttack = false;
            break;
          }
          int num3 = PlayerPrefs.GetInt("ChosenCharacter");
          if ((double) battleManager.ultimateSkill == 100.0)
          {
            if (num3 == 1)
              battleManager.rotisseurUltimateSkillButton.interactable = true;
            else if (num3 == 2)
              battleManager.patisseurUltimateSkillButton.interactable = true;
            else if (num3 == 3)
              battleManager.entremetierUltimateSkillButton.interactable = true;
          }
          if (num3 == 1)
          {
            battleManager.rotisseurBasicAttackButton.interactable = true;
            battleManager.rotisseurNormalSkillButton.interactable = true;
            battleManager.rotisseurUltimateSkillButton.interactable = false;
          }
          else if (num3 == 2)
          {
            battleManager.patisseurBasicAttackButton.interactable = true;
            battleManager.patisseurNormalSkillButton.interactable = true;
            battleManager.patisseurUltimateSkillButton.interactable = false;
          }
          else if (num3 == 3)
          {
            battleManager.entremetierBasicAttackButton.interactable = true;
            battleManager.entremetierNormalSkillButton.interactable = true;
            battleManager.entremetierUltimateSkillButton.interactable = false;
          }
          battleManager.canPlayerAttack = true;
          battleManager.dialogueBox.text = "What will you do?";
          break;
        case 3:
          float hurtSpeed3 = 0.1f;
          Object.FindObjectOfType<EntremetierBattleMode>().PlayHurtSprite(hurtSpeed3);
          yield return (object) new WaitForSeconds(2f);
          damageDealt = battleManager.currentBattleEnemyAttack * (float) (1.0 - (double) battleManager.updatedPlayerDefense * 0.6600000262260437 / 100.0);
          battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage.";
          yield return (object) new WaitForSeconds(2f);
          if ((double) Random.value < (double) battleManager.currentBattleEnemyCriticalRate / 100.0)
          {
            damageDealt *= (float) (1.0 + (double) battleManager.currentBattleEnemyCriticalDamage / 100.0);
            Debug.Log((object) "Enemy critical hit!");
          }
          battleManager.updatedPlayerHP -= Mathf.Ceil(damageDealt);
          battleManager.battleHealthBar.fillAmount = Mathf.Ceil(battleManager.updatedPlayerHP) / battleManager.currentBattlePlayerHP;
          if ((double) battleManager.updatedPlayerHP <= 0.0)
          {
            battleManager.battleScreen.SetActive(false);
            Debug.Log((object) "Player defeated!");
            battleManager.loseScreen.SetActive(true);
            battleManager.playerWorldHud.SetActive(false);
            battleManager.canPlayerAttack = false;
            battleManager.canEnemyAttack = false;
            break;
          }
          int num4 = PlayerPrefs.GetInt("ChosenCharacter");
          if ((double) battleManager.ultimateSkill == 100.0)
          {
            if (num4 == 1)
              battleManager.rotisseurUltimateSkillButton.interactable = true;
            else if (num4 == 2)
              battleManager.patisseurUltimateSkillButton.interactable = true;
            else if (num4 == 3)
              battleManager.entremetierUltimateSkillButton.interactable = true;
          }
          if (num4 == 1)
          {
            battleManager.rotisseurBasicAttackButton.interactable = true;
            battleManager.rotisseurNormalSkillButton.interactable = true;
            battleManager.rotisseurUltimateSkillButton.interactable = false;
          }
          else if (num4 == 2)
          {
            battleManager.patisseurBasicAttackButton.interactable = true;
            battleManager.patisseurNormalSkillButton.interactable = true;
            battleManager.patisseurUltimateSkillButton.interactable = false;
          }
          else if (num4 == 3)
          {
            battleManager.entremetierBasicAttackButton.interactable = true;
            battleManager.entremetierNormalSkillButton.interactable = true;
            battleManager.entremetierUltimateSkillButton.interactable = false;
          }
          battleManager.canPlayerAttack = true;
          battleManager.dialogueBox.text = "What will you do?";
          break;
      }
    }
    else
    {
      yield return (object) new WaitForSeconds(0.5f);
      battleManager.StartCoroutine(battleManager.PlayerDodgedAttack());
    }
  }

  private IEnumerator PlayerDodgedAttack()
  {
    Debug.Log((object) "You dodged the enemy's attack!");
    this.dialogueBox.text = "You dodged the enemy's attack!";
    yield return (object) new WaitForSeconds(1.5f);
    this.dialogueBox.text = "What will you do?";
    int num = PlayerPrefs.GetInt("ChosenCharacter");
    if ((double) this.ultimateSkill == 100.0)
    {
      switch (num)
      {
        case 1:
          this.rotisseurUltimateSkillButton.interactable = true;
          break;
        case 2:
          this.patisseurUltimateSkillButton.interactable = true;
          break;
        case 3:
          this.entremetierUltimateSkillButton.interactable = true;
          break;
      }
    }
    else
    {
      switch (num)
      {
        case 1:
          this.rotisseurBasicAttackButton.interactable = true;
          this.rotisseurNormalSkillButton.interactable = true;
          this.rotisseurUltimateSkillButton.interactable = false;
          break;
        case 2:
          this.patisseurBasicAttackButton.interactable = true;
          this.patisseurNormalSkillButton.interactable = true;
          this.patisseurUltimateSkillButton.interactable = false;
          break;
        case 3:
          this.entremetierBasicAttackButton.interactable = true;
          this.entremetierNormalSkillButton.interactable = true;
          this.entremetierUltimateSkillButton.interactable = false;
          break;
      }
    }
  }

  private IEnumerator EnemyHpUpdateCoroutine(float damageDealt)
  {
    BattleManager battleManager = this;
    switch (PlayerPrefs.GetInt("CurrentEnemy"))
    {
      case 1:
        float customHurtSpeed1 = 0.1f;
        Object.FindObjectOfType<MSGBossBattleMode>().PlayHurtSprite(customHurtSpeed1);
        yield return (object) new WaitForSeconds(1f);
        battleManager.currentBattleEnemyHP -= Mathf.Ceil(damageDealt);
        battleManager.battleMSGHealthBar.fillAmount = Mathf.Ceil(battleManager.currentBattleEnemyHP) / 500f;
        battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage to the enemy!";
        if ((double) battleManager.currentBattleEnemyHP < 0.0)
          battleManager.currentBattleEnemyHP = 0.0f;
        yield return (object) new WaitForSeconds(1.6f);
        if ((double) battleManager.currentBattleEnemyHP <= 0.0)
        {
          battleManager.currentBattleEnemyHP = 0.0f;
          battleManager.dialogueBox.text = "You have defeated the enemy!";
          Debug.Log((object) "Enemy defeated!");
          battleManager.canEnemyAttack = false;
          battleManager.StartCoroutine(battleManager.EnemyDyingCorutine());
          break;
        }
        if (PlayerPrefs.GetInt("CurrentEnemy") != 1)
          break;
        if ((double) Random.value <= 0.5)
        {
          float customSpeed = 0.1f;
          battleManager.dialogueBox.text = "Enemy used amino smash!";
          Object.FindObjectOfType<MSGBossBattleMode>().PlayBasicAttackSprite(customSpeed);
          Object.FindObjectOfType<MSGBossSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed);
          battleManager.StartCoroutine(battleManager.EnemyAttack());
          break;
        }
        battleManager.MsgNormalSkill();
        break;
      case 2:
        float customHurtSpeed2 = 0.1f;
        Object.FindObjectOfType<MeatBattleMode>().PlayHurtSprite(customHurtSpeed2);
        yield return (object) new WaitForSeconds(1f);
        battleManager.currentBattleEnemyHP -= Mathf.Ceil(damageDealt);
        battleManager.battleMeatHealthBar.fillAmount = Mathf.Ceil(battleManager.currentBattleEnemyHP) / 330f;
        battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage to the enemy!";
        if ((double) battleManager.currentBattleEnemyHP < 0.0)
          battleManager.currentBattleEnemyHP = 0.0f;
        yield return (object) new WaitForSeconds(1.6f);
        if ((double) battleManager.currentBattleEnemyHP <= 0.0)
        {
          battleManager.currentBattleEnemyHP = 0.0f;
          battleManager.dialogueBox.text = "You have defeated the enemy!";
          Debug.Log((object) "Enemy defeated!");
          battleManager.canEnemyAttack = false;
          battleManager.StartCoroutine(battleManager.EnemyDyingCorutine());
          break;
        }
        if (PlayerPrefs.GetInt("CurrentEnemy") != 2)
          break;
        battleManager.dialogueBox.text = "Enemy used steak slap!";
        yield return (object) new WaitForSeconds(1f);
        float customSpeed1 = 0.1f;
        Object.FindObjectOfType<MeatBattleMode>().PlayBasicAttackSprite(customSpeed1);
        Object.FindObjectOfType<MeatSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed1);
        battleManager.StartCoroutine(battleManager.EnemyAttack());
        break;
      case 3:
        float customHurtSpeed3 = 0.1f;
        Object.FindObjectOfType<DoughBattleMode>().PlayHurtSprite(customHurtSpeed3);
        yield return (object) new WaitForSeconds(1f);
        battleManager.currentBattleEnemyHP -= Mathf.Ceil(damageDealt);
        battleManager.battleDoughHealthBar.fillAmount = Mathf.Ceil(battleManager.currentBattleEnemyHP) / 310f;
        battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage to the enemy!";
        if ((double) battleManager.currentBattleEnemyHP < 0.0)
          battleManager.currentBattleEnemyHP = 0.0f;
        yield return (object) new WaitForSeconds(1.6f);
        if ((double) battleManager.currentBattleEnemyHP <= 0.0)
        {
          battleManager.currentBattleEnemyHP = 0.0f;
          battleManager.dialogueBox.text = "You have defeated the enemy!";
          Debug.Log((object) "Enemy defeated!");
          battleManager.canEnemyAttack = false;
          battleManager.StartCoroutine(battleManager.EnemyDyingCorutine());
          break;
        }
        if (PlayerPrefs.GetInt("CurrentEnemy") != 3)
          break;
        battleManager.dialogueBox.text = "Enemy used bread throw!";
        yield return (object) new WaitForSeconds(1f);
        float customSpeed2 = 0.1f;
        Object.FindObjectOfType<DoughBattleMode>().PlayBasicAttackSprite(customSpeed2);
        Object.FindObjectOfType<DoughSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed2);
        battleManager.StartCoroutine(battleManager.EnemyAttack());
        break;
      case 4:
        float customHurtSpeed4 = 0.1f;
        Object.FindObjectOfType<VegetableBattleMode>().PlayHurtSprite(customHurtSpeed4);
        yield return (object) new WaitForSeconds(1f);
        battleManager.currentBattleEnemyHP -= Mathf.Ceil(damageDealt);
        battleManager.battleVegetableHealthBar.fillAmount = Mathf.Ceil(battleManager.currentBattleEnemyHP) / 270f;
        battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage to the enemy!";
        if ((double) battleManager.currentBattleEnemyHP < 0.0)
          battleManager.currentBattleEnemyHP = 0.0f;
        yield return (object) new WaitForSeconds(1.6f);
        if ((double) battleManager.currentBattleEnemyHP <= 0.0)
        {
          battleManager.currentBattleEnemyHP = 0.0f;
          battleManager.dialogueBox.text = "You have defeated the enemy!";
          Debug.Log((object) "Enemy defeated!");
          battleManager.canEnemyAttack = false;
          battleManager.StartCoroutine(battleManager.EnemyDyingCorutine());
          break;
        }
        if (PlayerPrefs.GetInt("CurrentEnemy") != 4)
          break;
        battleManager.dialogueBox.text = "Enemy used beet poke!";
        yield return (object) new WaitForSeconds(1f);
        float customSpeed3 = 0.1f;
        Object.FindObjectOfType<VegetableBattleMode>().PlayBasicAttackSprite(customSpeed3);
        Object.FindObjectOfType<VegetableSkillEffect>().BasicAttackOverlaySpriteArray(customSpeed3);
        battleManager.StartCoroutine(battleManager.EnemyAttack());
        break;
    }
  }

  private IEnumerator EnemyDyingCorutine()
  {
    yield return (object) new WaitForSeconds(2f);
    this.battleScreen.SetActive(false);
    this.skillRotisseur.SetActive(false);
    this.skillPatissier.SetActive(false);
    this.skillEntremetier.SetActive(false);
    this.DestroyCurrentEnemy();
    this.canPlayerAttack = true;
    int num = PlayerPrefs.GetInt("ChosenCharacter");
    if ((double) this.ultimateSkill == 100.0)
    {
      if (num == 1)
        this.rotisseurUltimateSkillButton.interactable = true;
      else if (num == 2)
        this.patisseurUltimateSkillButton.interactable = true;
      else if (num == 3)
        this.entremetierUltimateSkillButton.interactable = true;
    }
    if (num == 1)
    {
      this.rotisseurBasicAttackButton.interactable = true;
      this.rotisseurNormalSkillButton.interactable = true;
      this.rotisseurUltimateSkillButton.interactable = false;
    }
    else if (num == 2)
    {
      this.patisseurBasicAttackButton.interactable = true;
      this.patisseurNormalSkillButton.interactable = true;
      this.patisseurUltimateSkillButton.interactable = false;
    }
    else if (num == 3)
    {
      this.entremetierBasicAttackButton.interactable = true;
      this.entremetierNormalSkillButton.interactable = true;
      this.entremetierUltimateSkillButton.interactable = false;
    }
  }

  public void HealingPotion(float potionHeal)
  {
    potionHeal = 50f;
    this.currentBattlePlayerHP += Mathf.Ceil(potionHeal);
    this.updatedPlayerHP += Mathf.Ceil(potionHeal);
  }

  private void DestroyCurrentEnemy()
  {
    this.dialogueBox.text = "What will you do?";
    int num = PlayerPrefs.GetInt("CurrentEnemy");
    SpriteMovement.playerInstance.GetComponent<SpriteMovement>().SetCanMove(true);
    switch (num)
    {
      case 1:
        this.battleMSGBoss.SetActive(false);
        this.idlebattleMSGBoss.SetActive(false);
        this.skillMSGBoss.SetActive(false);
        this.MSGHealthBar.SetActive(false);
        this.currentBattlePlayerHP = this.updatedPlayerHP;
        this.WinnerDinner();
        break;
      case 2:
        this.battleMeat.SetActive(false);
        this.idlebattleMeat.SetActive(false);
        this.skillMeat.SetActive(false);
        this.MeatHealthBar.SetActive(false);
        this.currentBattlePlayerHP = this.updatedPlayerHP;
        if ((double) Random.value <= 0.800000011920929)
        {
          this.healingPotion2.SetActive(true);
          break;
        }
        this.healingPotion2.SetActive(false);
        break;
      case 3:
        this.battleDough.SetActive(false);
        this.idlebattleDough.SetActive(false);
        this.skillDough.SetActive(false);
        this.DoughHealthBar.SetActive(false);
        this.currentBattlePlayerHP = this.updatedPlayerHP;
        if ((double) Random.value <= 0.800000011920929)
        {
          this.healingPotion1.SetActive(true);
          break;
        }
        this.healingPotion1.SetActive(false);
        break;
      case 4:
        this.battleVegetable.SetActive(false);
        this.idlebattleVegetable.SetActive(false);
        this.skillVegetable.SetActive(false);
        this.VegetableHealthBar.SetActive(false);
        this.currentBattlePlayerHP = this.updatedPlayerHP;
        if ((double) Random.value <= 0.800000011920929)
        {
          this.healingPotion3.SetActive(true);
          break;
        }
        this.healingPotion3.SetActive(false);
        break;
      default:
        Debug.LogWarning((object) "Invalid Enemy value in PlayerPrefs.");
        break;
    }
  }

  private IEnumerator MeatNormalSkill()
  {
    BattleManager battleManager = this;
    battleManager.UltRecharge();
    int num1 = PlayerPrefs.GetInt("ChosenCharacter");
    float damageDealt;
    if ((double) Random.value >= (double) battleManager.currentBattlePlayerDodgeRate / 100.0)
    {
      switch (num1)
      {
        case 1:
          float hurtSpeed1 = 0.1f;
          Object.FindObjectOfType<RotisseurBattleMode>().PlayHurtSprite(hurtSpeed1);
          yield return (object) new WaitForSeconds(2f);
          damageDealt = battleManager.currentBattleEnemyAttack + (float) (200.0 * (1.0 - (double) battleManager.updatedPlayerDefense * 0.6600000262260437 / 100.0));
          if ((double) battleManager.currentShieldStrength > 0.0)
          {
            damageDealt -= battleManager.currentShieldStrength;
            damageDealt = Mathf.Max(0.0f, damageDealt);
          }
          battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage.";
          yield return (object) new WaitForSeconds(2f);
          if ((double) Random.value < (double) battleManager.currentBattleEnemyCriticalRate / 100.0)
          {
            damageDealt *= (float) (1.0 + (double) battleManager.currentBattleEnemyCriticalDamage / 100.0);
            Debug.Log((object) "Enemy critical hit!");
          }
          battleManager.updatedPlayerHP -= Mathf.Ceil(damageDealt);
          battleManager.battleHealthBar.fillAmount = Mathf.Ceil(battleManager.updatedPlayerHP) / battleManager.currentBattlePlayerHP;
          if ((double) battleManager.updatedPlayerHP <= 0.0)
          {
            battleManager.battleScreen.SetActive(false);
            Debug.Log((object) "Player defeated!");
            battleManager.loseScreen.SetActive(true);
            battleManager.playerWorldHud.SetActive(false);
            battleManager.canPlayerAttack = false;
            battleManager.canEnemyAttack = false;
            break;
          }
          int num2 = PlayerPrefs.GetInt("ChosenCharacter");
          if ((double) battleManager.ultimateSkill == 100.0)
          {
            if (num2 == 1)
              battleManager.rotisseurUltimateSkillButton.interactable = true;
            else if (num2 == 2)
              battleManager.patisseurUltimateSkillButton.interactable = true;
            else if (num2 == 3)
              battleManager.entremetierUltimateSkillButton.interactable = true;
          }
          if (num2 == 1)
          {
            battleManager.rotisseurBasicAttackButton.interactable = true;
            battleManager.rotisseurNormalSkillButton.interactable = true;
            battleManager.rotisseurUltimateSkillButton.interactable = false;
          }
          else if (num2 == 2)
          {
            battleManager.patisseurBasicAttackButton.interactable = true;
            battleManager.patisseurNormalSkillButton.interactable = true;
            battleManager.patisseurUltimateSkillButton.interactable = false;
          }
          else if (num2 == 3)
          {
            battleManager.entremetierBasicAttackButton.interactable = true;
            battleManager.entremetierNormalSkillButton.interactable = true;
            battleManager.entremetierUltimateSkillButton.interactable = false;
          }
          battleManager.canPlayerAttack = true;
          battleManager.dialogueBox.text = "What will you do?";
          break;
        case 2:
          float hurtSpeed2 = 0.1f;
          Object.FindObjectOfType<PatissierBattleMode>().PlayHurtSprite(hurtSpeed2);
          yield return (object) new WaitForSeconds(2f);
          damageDealt = battleManager.currentBattleEnemyAttack * (float) (1.0 - (double) battleManager.updatedPlayerDefense * 0.6600000262260437 / 100.0);
          battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage.";
          yield return (object) new WaitForSeconds(2f);
          if ((double) Random.value < (double) battleManager.currentBattleEnemyCriticalRate / 100.0)
          {
            damageDealt *= (float) (1.0 + (double) battleManager.currentBattleEnemyCriticalDamage / 100.0);
            Debug.Log((object) "Enemy critical hit!");
          }
          battleManager.updatedPlayerHP -= Mathf.Ceil(damageDealt);
          if ((double) battleManager.updatedPlayerHP <= 0.0)
          {
            battleManager.battleScreen.SetActive(false);
            Debug.Log((object) "Player defeated!");
            battleManager.loseScreen.SetActive(true);
            battleManager.playerWorldHud.SetActive(false);
            battleManager.canPlayerAttack = false;
            battleManager.canEnemyAttack = false;
            break;
          }
          int num3 = PlayerPrefs.GetInt("ChosenCharacter");
          if ((double) battleManager.ultimateSkill == 100.0)
          {
            if (num3 == 1)
              battleManager.rotisseurUltimateSkillButton.interactable = true;
            else if (num3 == 2)
              battleManager.patisseurUltimateSkillButton.interactable = true;
            else if (num3 == 3)
              battleManager.entremetierUltimateSkillButton.interactable = true;
          }
          if (num3 == 1)
          {
            battleManager.rotisseurBasicAttackButton.interactable = true;
            battleManager.rotisseurNormalSkillButton.interactable = true;
            battleManager.rotisseurUltimateSkillButton.interactable = false;
          }
          else if (num3 == 2)
          {
            battleManager.patisseurBasicAttackButton.interactable = true;
            battleManager.patisseurNormalSkillButton.interactable = true;
            battleManager.patisseurUltimateSkillButton.interactable = false;
          }
          else if (num3 == 3)
          {
            battleManager.entremetierBasicAttackButton.interactable = true;
            battleManager.entremetierNormalSkillButton.interactable = true;
            battleManager.entremetierUltimateSkillButton.interactable = false;
          }
          battleManager.canPlayerAttack = true;
          battleManager.dialogueBox.text = "What will you do?";
          break;
        case 3:
          float hurtSpeed3 = 0.1f;
          Object.FindObjectOfType<EntremetierBattleMode>().PlayHurtSprite(hurtSpeed3);
          yield return (object) new WaitForSeconds(2f);
          damageDealt = battleManager.currentBattleEnemyAttack * (float) (1.0 - (double) battleManager.updatedPlayerDefense * 0.6600000262260437 / 100.0);
          battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage.";
          yield return (object) new WaitForSeconds(2f);
          if ((double) Random.value < (double) battleManager.currentBattleEnemyCriticalRate / 100.0)
          {
            damageDealt *= (float) (1.0 + (double) battleManager.currentBattleEnemyCriticalDamage / 100.0);
            Debug.Log((object) "Enemy critical hit!");
          }
          battleManager.updatedPlayerHP -= Mathf.Ceil(damageDealt);
          battleManager.battleHealthBar.fillAmount = Mathf.Ceil(battleManager.updatedPlayerHP) / battleManager.currentBattlePlayerHP;
          if ((double) battleManager.updatedPlayerHP <= 0.0)
          {
            battleManager.battleScreen.SetActive(false);
            Debug.Log((object) "Player defeated!");
            battleManager.loseScreen.SetActive(true);
            battleManager.playerWorldHud.SetActive(false);
            battleManager.canPlayerAttack = false;
            battleManager.canEnemyAttack = false;
            break;
          }
          int num4 = PlayerPrefs.GetInt("ChosenCharacter");
          if ((double) battleManager.ultimateSkill == 100.0)
          {
            if (num4 == 1)
              battleManager.rotisseurUltimateSkillButton.interactable = true;
            else if (num4 == 2)
              battleManager.patisseurUltimateSkillButton.interactable = true;
            else if (num4 == 3)
              battleManager.entremetierUltimateSkillButton.interactable = true;
          }
          if (num4 == 1)
          {
            battleManager.rotisseurBasicAttackButton.interactable = true;
            battleManager.rotisseurNormalSkillButton.interactable = true;
            battleManager.rotisseurUltimateSkillButton.interactable = false;
          }
          else if (num4 == 2)
          {
            battleManager.patisseurBasicAttackButton.interactable = true;
            battleManager.patisseurNormalSkillButton.interactable = true;
            battleManager.patisseurUltimateSkillButton.interactable = false;
          }
          else if (num4 == 3)
          {
            battleManager.entremetierBasicAttackButton.interactable = true;
            battleManager.entremetierNormalSkillButton.interactable = true;
            battleManager.entremetierUltimateSkillButton.interactable = false;
          }
          battleManager.canPlayerAttack = true;
          battleManager.dialogueBox.text = "What will you do?";
          break;
      }
    }
    else
    {
      yield return (object) new WaitForSeconds(0.5f);
      battleManager.StartCoroutine(battleManager.PlayerDodgedAttack());
    }
  }

  public void MsgNormalSkill()
  {
    if ((double) Random.value <= 0.5)
    {
      float customSpeed = 0.08f;
      this.currentBattleEnemyDefense *= 1.1f;
      Object.FindObjectOfType<MSGBossBattleMode>().PlayNormalSkillSprite(customSpeed);
      this.StartCoroutine(this.EnemyUsedNormalSkill("Enemy used solidify! defense is increased!"));
    }
    else
      this.MsgUltimateSkill();
  }

  public void MsgUltimateSkill()
  {
    float customSpeed = 0.1f;
    float ultSpeed = 0.08f;
    Object.FindObjectOfType<MSGBossBattleMode>().PlayUltimateSkillSprite(customSpeed);
    Object.FindObjectOfType<MSGBossSkillEffect>().UltimateSkillOverlaySpriteArray(ultSpeed);
    this.StartCoroutine(this.MsgUltimateAttack());
  }

  public void DoughNormalSkill()
  {
    float customSpeed = 0.08f;
    this.currentBattleEnemyHP += Mathf.Ceil(this.doughMonsterHP * 0.1f);
    Object.FindObjectOfType<DoughBattleMode>().PlayNormalSkillSprite(customSpeed);
    this.StartCoroutine(this.EnemyUsedNormalSkill("Enemy used basic fold! Enemy healed itself and did not take damage from that attack!"));
    if ((double) this.currentBattleEnemyHP <= 310.0)
      return;
    this.currentBattleEnemyHP = 310f;
  }

  public void VegetableNormalSkill()
  {
    float customSpeed = 0.08f;
    Object.FindObjectOfType<VegetableBattleMode>().PlayNormalSkillSprite(customSpeed);
    this.StartCoroutine(this.EnemyUsedNormalSkill("Enemy used veggie spin! Enemy increased their dodge rate!"));
  }

  private IEnumerator EnemyUsedNormalSkill(string message)
  {
    this.dialogueBox.text = message;
    yield return (object) new WaitForSeconds(2f);
    int num = PlayerPrefs.GetInt("ChosenCharacter");
    if ((double) this.ultimateSkill == 100.0)
    {
      if (num == 1)
        this.rotisseurUltimateSkillButton.interactable = true;
      else if (num == 2)
        this.patisseurUltimateSkillButton.interactable = true;
      else if (num == 3)
        this.entremetierUltimateSkillButton.interactable = true;
    }
    if (num == 1)
    {
      this.rotisseurBasicAttackButton.interactable = true;
      this.rotisseurNormalSkillButton.interactable = true;
      this.rotisseurUltimateSkillButton.interactable = false;
    }
    else if (num == 2)
    {
      this.patisseurBasicAttackButton.interactable = true;
      this.patisseurNormalSkillButton.interactable = true;
      this.patisseurUltimateSkillButton.interactable = false;
    }
    else if (num == 3)
    {
      this.entremetierBasicAttackButton.interactable = true;
      this.entremetierNormalSkillButton.interactable = true;
      this.entremetierUltimateSkillButton.interactable = false;
    }
    this.canPlayerAttack = true;
    this.dialogueBox.text = "What will you do?";
  }

  public void ResetUltimateSkill()
  {
    this.ultimateSkill = 0.0f;
    this.rotisseurUltimateSkillButton.interactable = false;
    this.patisseurUltimateSkillButton.interactable = false;
    this.entremetierUltimateSkillButton.interactable = false;
    this.UpdateUI();
  }

  public void RechargeUltimate(float rechargeAmount)
  {
    this.ultimateSkill += rechargeAmount;
    this.ultimateSkill = Mathf.Clamp(this.ultimateSkill, 0.0f, 100f);
    this.UpdateUI();
  }

  private void UltRecharge() => this.RechargeUltimate(10f);

  private void UpdateUI()
  {
    this.rotisseurUltimateRecharge.fillAmount = this.ultimateSkill / 100f;
    this.patissierUltimateRecharge.fillAmount = this.ultimateSkill / 100f;
    this.entremetierUltimateRecharge.fillAmount = this.ultimateSkill / 100f;
  }

  public void UltimateSkill()
  {
    this.ResetUltimateSkill();
    if ((double) Random.value <= 0.800000011920929)
    {
      if ((double) Random.value >= (double) this.currentBattleEnemyDodgeRate / 100.0)
      {
        float num = this.updatedPlayerAttack + (float) (200.0 * (1.0 - (double) this.currentBattleEnemyDefense * 0.6600000262260437 / 100.0));
        if ((double) Random.value < (double) this.updatedPlayerCriticalRate / 100.0)
        {
          num *= (float) (1.0 + (double) this.updatedPlayerCriticalDamage / 100.0);
          Debug.Log((object) "Critical hit!");
        }
        switch (PlayerPrefs.GetInt("ChosenCharacter"))
        {
          case 1:
            this.dialogueBox.text = "You used fresh meat and dealt! " + Mathf.Ceil(num).ToString() + " damage!";
            this.rotisseurBasicAttackButton.interactable = false;
            this.rotisseurNormalSkillButton.interactable = false;
            this.rotisseurUltimateSkillButton.interactable = false;
            this.StartCoroutine(this.EnemyHpUpdateCoroutine(num));
            break;
          case 2:
            this.dialogueBox.text = "You used bonk and dealt " + Mathf.Ceil(num).ToString() + " damage!";
            this.patisseurBasicAttackButton.interactable = false;
            this.patisseurNormalSkillButton.interactable = false;
            this.patisseurUltimateSkillButton.interactable = false;
            this.StartCoroutine(this.EnemyHpUpdateCoroutine(num));
            break;
          case 3:
            this.dialogueBox.text = "You used knife brigade and dealt " + Mathf.Ceil(num).ToString() + " damage!";
            this.entremetierBasicAttackButton.interactable = false;
            this.entremetierNormalSkillButton.interactable = false;
            this.entremetierUltimateSkillButton.interactable = false;
            this.StartCoroutine(this.EnemyHpUpdateCoroutine(num));
            break;
        }
      }
      else
        this.StartCoroutine(this.EnemyDodgedAttack());
    }
    else
    {
      switch (PlayerPrefs.GetInt("CurrentEnemy"))
      {
        case 1:
          this.MsgNormalSkill();
          break;
        case 2:
          this.MeatNormalSkill();
          break;
        case 3:
          this.DoughNormalSkill();
          break;
        case 4:
          this.VegetableNormalSkill();
          break;
        default:
          Debug.LogWarning((object) "Invalid Enemy value in PlayerPrefs.");
          break;
      }
    }
  }

  private IEnumerator MsgUltimateAttack()
  {
    BattleManager battleManager = this;
    int num1 = PlayerPrefs.GetInt("ChosenCharacter");
    float damageDealt;
    if ((double) Random.value >= (double) battleManager.currentBattlePlayerDodgeRate / 100.0)
    {
      switch (num1)
      {
        case 1:
          float hurtSpeed1 = 0.1f;
          Object.FindObjectOfType<RotisseurBattleMode>().PlayHurtSprite(hurtSpeed1);
          yield return (object) new WaitForSeconds(2f);
          damageDealt = battleManager.currentBattleEnemyAttack + (float) (100.0 * (1.0 - (double) battleManager.updatedPlayerDefense * 0.6600000262260437 / 100.0));
          if ((double) battleManager.currentShieldStrength > 0.0)
          {
            damageDealt -= battleManager.currentShieldStrength;
            damageDealt = Mathf.Max(0.0f, damageDealt);
          }
          battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage.";
          yield return (object) new WaitForSeconds(2f);
          if ((double) Random.value < (double) battleManager.currentBattleEnemyCriticalRate / 100.0)
          {
            damageDealt *= (float) (1.0 + (double) battleManager.currentBattleEnemyCriticalDamage / 100.0);
            Debug.Log((object) "Enemy critical hit!");
          }
          battleManager.updatedPlayerHP -= Mathf.Ceil(damageDealt);
          battleManager.battleHealthBar.fillAmount = Mathf.Ceil(battleManager.updatedPlayerHP) / battleManager.currentBattlePlayerHP;
          if ((double) battleManager.updatedPlayerHP <= 0.0)
          {
            battleManager.battleScreen.SetActive(false);
            Debug.Log((object) "Player defeated!");
            battleManager.loseScreen.SetActive(true);
            battleManager.playerWorldHud.SetActive(false);
            battleManager.canPlayerAttack = false;
            battleManager.canEnemyAttack = false;
            break;
          }
          int num2 = PlayerPrefs.GetInt("ChosenCharacter");
          if ((double) battleManager.ultimateSkill == 100.0)
          {
            if (num2 == 1)
              battleManager.rotisseurUltimateSkillButton.interactable = true;
            else if (num2 == 2)
              battleManager.patisseurUltimateSkillButton.interactable = true;
            else if (num2 == 3)
              battleManager.entremetierUltimateSkillButton.interactable = true;
          }
          if (num2 == 1)
          {
            battleManager.rotisseurBasicAttackButton.interactable = true;
            battleManager.rotisseurNormalSkillButton.interactable = true;
            battleManager.rotisseurUltimateSkillButton.interactable = false;
          }
          else if (num2 == 2)
          {
            battleManager.patisseurBasicAttackButton.interactable = true;
            battleManager.patisseurNormalSkillButton.interactable = true;
            battleManager.patisseurUltimateSkillButton.interactable = false;
          }
          else if (num2 == 3)
          {
            battleManager.entremetierBasicAttackButton.interactable = true;
            battleManager.entremetierNormalSkillButton.interactable = true;
            battleManager.entremetierUltimateSkillButton.interactable = false;
          }
          battleManager.canPlayerAttack = true;
          battleManager.dialogueBox.text = "What will you do?";
          break;
        case 2:
          float hurtSpeed2 = 0.1f;
          Object.FindObjectOfType<PatissierBattleMode>().PlayHurtSprite(hurtSpeed2);
          yield return (object) new WaitForSeconds(2f);
          damageDealt = battleManager.currentBattleEnemyAttack + (float) (200.0 * (1.0 - (double) battleManager.updatedPlayerDefense * 0.6600000262260437 / 100.0));
          battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage.";
          yield return (object) new WaitForSeconds(2f);
          if ((double) Random.value < (double) battleManager.currentBattleEnemyCriticalRate / 100.0)
          {
            damageDealt *= (float) (1.0 + (double) battleManager.currentBattleEnemyCriticalDamage / 100.0);
            Debug.Log((object) "Enemy critical hit!");
          }
          battleManager.updatedPlayerHP -= Mathf.Ceil(damageDealt);
          if ((double) battleManager.updatedPlayerHP <= 0.0)
          {
            battleManager.battleScreen.SetActive(false);
            Debug.Log((object) "Player defeated!");
            battleManager.loseScreen.SetActive(true);
            battleManager.playerWorldHud.SetActive(false);
            battleManager.canPlayerAttack = false;
            battleManager.canEnemyAttack = false;
            break;
          }
          int num3 = PlayerPrefs.GetInt("ChosenCharacter");
          if ((double) battleManager.ultimateSkill == 100.0)
          {
            if (num3 == 1)
              battleManager.rotisseurUltimateSkillButton.interactable = true;
            else if (num3 == 2)
              battleManager.patisseurUltimateSkillButton.interactable = true;
            else if (num3 == 3)
              battleManager.entremetierUltimateSkillButton.interactable = true;
          }
          if (num3 == 1)
          {
            battleManager.rotisseurBasicAttackButton.interactable = true;
            battleManager.rotisseurNormalSkillButton.interactable = true;
            battleManager.rotisseurUltimateSkillButton.interactable = false;
          }
          else if (num3 == 2)
          {
            battleManager.patisseurBasicAttackButton.interactable = true;
            battleManager.patisseurNormalSkillButton.interactable = true;
            battleManager.patisseurUltimateSkillButton.interactable = false;
          }
          else if (num3 == 3)
          {
            battleManager.entremetierBasicAttackButton.interactable = true;
            battleManager.entremetierNormalSkillButton.interactable = true;
            battleManager.entremetierUltimateSkillButton.interactable = false;
          }
          battleManager.canPlayerAttack = true;
          battleManager.dialogueBox.text = "What will you do?";
          break;
        case 3:
          float hurtSpeed3 = 0.1f;
          Object.FindObjectOfType<EntremetierBattleMode>().PlayHurtSprite(hurtSpeed3);
          yield return (object) new WaitForSeconds(2f);
          damageDealt = battleManager.currentBattleEnemyAttack + (float) (200.0 * (1.0 - (double) battleManager.updatedPlayerDefense * 0.6600000262260437 / 100.0));
          battleManager.dialogueBox.text = "It dealt " + Mathf.Ceil(damageDealt).ToString() + " damage.";
          yield return (object) new WaitForSeconds(2f);
          if ((double) Random.value < (double) battleManager.currentBattleEnemyCriticalRate / 100.0)
          {
            damageDealt *= (float) (1.0 + (double) battleManager.currentBattleEnemyCriticalDamage / 100.0);
            Debug.Log((object) "Enemy critical hit!");
          }
          battleManager.updatedPlayerHP -= Mathf.Ceil(damageDealt);
          battleManager.battleHealthBar.fillAmount = Mathf.Ceil(battleManager.updatedPlayerHP) / battleManager.currentBattlePlayerHP;
          if ((double) battleManager.updatedPlayerHP <= 0.0)
          {
            battleManager.battleScreen.SetActive(false);
            Debug.Log((object) "Player defeated!");
            battleManager.loseScreen.SetActive(true);
            battleManager.playerWorldHud.SetActive(false);
            battleManager.canPlayerAttack = false;
            battleManager.canEnemyAttack = false;
            break;
          }
          int num4 = PlayerPrefs.GetInt("ChosenCharacter");
          if ((double) battleManager.ultimateSkill == 100.0)
          {
            if (num4 == 1)
              battleManager.rotisseurUltimateSkillButton.interactable = true;
            else if (num4 == 2)
              battleManager.patisseurUltimateSkillButton.interactable = true;
            else if (num4 == 3)
              battleManager.entremetierUltimateSkillButton.interactable = true;
          }
          if (num4 == 1)
          {
            battleManager.rotisseurBasicAttackButton.interactable = true;
            battleManager.rotisseurNormalSkillButton.interactable = true;
            battleManager.rotisseurUltimateSkillButton.interactable = false;
          }
          else if (num4 == 2)
          {
            battleManager.patisseurBasicAttackButton.interactable = true;
            battleManager.patisseurNormalSkillButton.interactable = true;
            battleManager.patisseurUltimateSkillButton.interactable = false;
          }
          else if (num4 == 3)
          {
            battleManager.entremetierBasicAttackButton.interactable = true;
            battleManager.entremetierNormalSkillButton.interactable = true;
            battleManager.entremetierUltimateSkillButton.interactable = false;
          }
          battleManager.canPlayerAttack = true;
          battleManager.dialogueBox.text = "What will you do?";
          break;
      }
    }
    else
    {
      yield return (object) new WaitForSeconds(0.5f);
      battleManager.StartCoroutine(battleManager.PlayerDodgedAttack());
    }
  }

  public void WinnerDinner()
  {
    this.winScreen.SetActive(true);
    Object.FindObjectOfType<WinScreen>().PlayMsgWinSprite();
  }
}