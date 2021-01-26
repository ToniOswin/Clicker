using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeReference]
    GameObject[] enemies;
    [SerializeField]
    Camera cameraBg;
    [SerializeField]
    AudioSource hitSound;
    public static int enemyIdx = 0;
    public Slider slider;
    public Slider enemySlider;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI EnemyName;
    public TextMeshProUGUI EnemyDescription;
    bool enemyIsAlive;
    bool playerIsAlive;


    float actualHealth;
    Animator enemyAni;

    Color balck = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemie = Instantiate(enemies[enemyIdx]);
        actualHealth = PlayerStats.health;
        moneyText.text = PlayerStats.money.ToString() + " Coins";
        EnemyName.text = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>().enemyName;
        EnemyDescription.text = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>().description;
        enemyAni = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        SetHealth();
        SetEnemyHealth();
        enemyIsAlive = true;
        playerIsAlive = true;
        if(enemyIdx == 2)
        {
            cameraBg.backgroundColor = balck;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if( Physics.Raycast(ray,out hit))
            {
                if(hit.collider != null)
                {
                    Attack(hit.collider.gameObject.GetComponent<EnemyStats>());
                }
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    Attack(hit.collider.gameObject.GetComponent<EnemyStats>());
                }
            }
        }

        LostHealth();
    }

    void LostHealth()
    {
        if(playerIsAlive && enemyIsAlive)
        {
            actualHealth -= Time.deltaTime;
            slider.value = actualHealth;
        }
        if(actualHealth <=0)
        {
            playerIsAlive = false;
            GoToShop();
        }
        
    }
    void SetHealth()
    {
        slider.maxValue = actualHealth;
    }

    void SetEnemyHealth()
    {
        enemySlider.maxValue = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>().health;
        enemySlider.value = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>().health; 
    }

    void Attack(EnemyStats enemy)
    {
        hitSound.Play();
        if(playerIsAlive && enemyIsAlive)
        {
            enemyAni.SetBool("GetsHurt", true);
            
            enemy.health -= PlayerStats.Damage;
            enemySlider.value = enemy.health;

            PlayerStats.money += 1;
            moneyText.text = PlayerStats.money.ToString() + " Coins";
        }
        if(enemy.health<=0 && enemyIsAlive)
        {
            enemyIsAlive = false;
            if(enemyIdx < enemies.Length-1)
            {
                enemyIdx += 1;
                SceneManager.LoadScene("Battle");
            }
            else if (enemyIdx == enemies.Length - 1)
            {
                SceneManager.LoadScene( "Win");
            }
            
        }
    }

    void GoToShop() { SceneManager.LoadScene("Shop"); }
}
