using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public ShootProperty _ShootProperty;
    public float CharacterSpeed = 5f;

    public Slider HealthBar;
    public Text ScoreText;
    public Text CoinText;
    public Image ArrowImage;
    public BundleManager loader;

    public int Health { get; set; }
    public int Score { get; set; }
    public int Coins { get; set; }
    public WeaponType Weapon { get; set; }
    public GameObject Character { get; private set; }

    private GameObject Arrow1;
    private GameObject Arrow2;
    private GameObject Arrow3;

    private Sprite Arrow1_Sprite;
    private Sprite Arrow2_Sprite;
    private Sprite Arrow3_Sprite;

    private float ShootTime = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Health = 100;
        Score = 0;
        Weapon = WeaponType.Arrow1;

        HealthBar.value = Health;
        LoadPlayer();
        LoadArrows();
        ArrowImage.sprite = Arrow1_Sprite;
    }

    private void Update()
    {
        ShootTime += Time.deltaTime;
    }

    private void LoadPlayer()
    {
        GameObject Prefab = AssetLoader.Instance.PlayerPrefab;
        Character = Instantiate(Prefab, gameObject.transform.position, Quaternion.identity);

        if(Character != null)
        {
            //Add components here
        }
    }

    private void LoadArrows()
    {
        Arrow1 = AssetLoader.Instance.BulletPrefab1;
        Arrow2 = AssetLoader.Instance.BulletPrefab2;
        Arrow3 = AssetLoader.Instance.BulletPrefab3;

        Arrow1_Sprite = AssetLoader.Instance.BulletSprite1;
        Arrow2_Sprite = AssetLoader.Instance.BulletSprite2;
        Arrow3_Sprite = AssetLoader.Instance.BulletSprite3;
    }

    public void Shoot()
    {
        if (ShootTime > _ShootProperty.ShootInterval)
        {
            ShootTime = 0;

            switch (Weapon)
            {
                case WeaponType.Arrow1:
                    GameObject Arrow1Clone = Instantiate(Arrow1);
                    Arrow1Clone.transform.position = Character.transform.position;
                    Destroy(Arrow1Clone, _ShootProperty.BulletLifetime);
                    break;

                case WeaponType.Arrow2:
                    GameObject Arrow2Clone = Instantiate(Arrow2);
                    Arrow2Clone.transform.position = Character.transform.position;
                    Destroy(Arrow2Clone, _ShootProperty.BulletLifetime);
                    break;

                case WeaponType.Arrow3:
                    GameObject Arrow3Clone = Instantiate(Arrow3);
                    Arrow3Clone.transform.position = Character.transform.position;
                    Destroy(Arrow3Clone, _ShootProperty.BulletLifetime);
                    break;
            }

        }
    }

    public void CharacterMove(Vector3 changed)
    {
        Character.transform.Translate(changed);
    }

    public void RefreshHealth()
    {
        Health = 100;
        HealthBar.value = Health;
    }

    public void DamageCharacter(int dmg)
    {
        Health -= dmg;
        HealthBar.value = Health;

        if(Health <= 0)
        {
            GameManager.Instance.Gameover();
        }
    }

    public void ChangeWeapon(WeaponType newWeapon)
    {
        Weapon = newWeapon;

        switch (Weapon)
        {
            case WeaponType.Arrow1:
                ArrowImage.sprite = Arrow1_Sprite;
                break;

            case WeaponType.Arrow2:
                ArrowImage.sprite = Arrow2_Sprite;
                break;

            case WeaponType.Arrow3:
                ArrowImage.sprite = Arrow3_Sprite;
                break;
        }
    }

    public void GainPoints(int points)
    {
        Score += points;
        ScoreText.text = Score.ToString();
    }

    public void GainCoins(int coins)
    {
        Coins += coins;
        CoinText.text = Coins.ToString();
    }
}
