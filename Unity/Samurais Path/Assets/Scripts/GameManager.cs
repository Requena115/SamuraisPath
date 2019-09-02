using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;

public class GameManager : MonoBehaviour {

    private List<Enemy> enemies = new List<Enemy>();
    private Collider2D[] enemiesS;
    public GameObject enemyPrefab;

    private List<Bomb> bombs = new List<Bomb>();
    private Collider2D[] bombsS;
    public GameObject bombPrefab;

    private List<PowerUp> powerUps = new List<PowerUp>();
    private Collider2D[] powerUpsS;
    public GameObject powerUpPrefab;

    public bool isPowerUpActive = false;

    private float lastSpawn;
    private float deltaSpawn = 1.0f;
    private float lastSpawnB;
    private float deltaSpawnB = 5.0f;
    private float lastSpawnP;
    private float deltaSpawnP = 20.0f;

    private const float SLICEFORCE = 50.0f;
    private Vector3 lastMousePosition;
    private bool isPause;

    private int score;
    private int highscore;
    private int lifepoint;
    public Text scoreText;
    public Text highscoreText;
    public Image[] lifepoints;
    public GameObject pauseMenu;
    public GameObject deathMenu;

    
    public Transform trail;
    
    public static GameManager Instance { set; get; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        enemiesS = new Collider2D[0];
        bombsS = new Collider2D[1];
        powerUpsS = new Collider2D[2];
        NewGame();
    }

    public void NewGame()
    {
        score = 0;
        lifepoint = 3;
        pauseMenu.SetActive(false);
        scoreText.text = score.ToString();
        highscore = PlayerPrefs.GetInt("Score");
        highscoreText.text = highscore.ToString();
        Time.timeScale = 1;
        isPause = false;

        foreach (Image i in lifepoints)
            i.enabled = true;
        foreach (Enemy e in enemies)
            Destroy(e.gameObject);
        enemies.Clear();
        foreach (Bomb b in bombs)
            Destroy(b.gameObject);
        bombs.Clear();
        foreach (PowerUp p in powerUps)
            Destroy(p.gameObject);
        powerUps.Clear();




        deathMenu.SetActive(false);



    }

    private void Update()
    {
        if (isPause)
            return;
        if(Time.time - lastSpawn > deltaSpawn)
        {
            Enemy e = GetEnemy();
            float randomX = Random.Range(-1.65f, 1.65f);

            e.LaunchEnemy(Random.Range(1.85f, 2.75f), randomX, -randomX);
            lastSpawn = Time.time;
        }
        if(Time.time - lastSpawnB > deltaSpawnB)
        {
            Bomb e = GetBomb();
            float randomX = Random.Range(-1.65f, 1.65f);
            e.LaunchBomb(Random.Range(1.85f, 2.75f), randomX, -randomX);
            lastSpawnB = Time.time;
        }
        if (Time.time - lastSpawnP > deltaSpawnP)
        {
            PowerUp e = GetPowerUp();
            float randomX = Random.Range(-1.65f, 1.65f);
            e.LaunchPowerUp(Random.Range(1.85f, 2.75f), randomX, -randomX);
            lastSpawnP = Time.time;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -1;
            trail.position = pos;
            Collider2D[] thisFramesEnemy = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Enemy"));
            Collider2D[] thisFramesBomb = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("Bomb"));
            Collider2D[] thisFramesPowerUp = Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y), LayerMask.GetMask("PowerUp"));

            if ((Input.mousePosition - lastMousePosition).sqrMagnitude > SLICEFORCE)
            {
                foreach (Collider2D c in thisFramesEnemy)
                {
                    for (int i = 0; i < enemiesS.Length; i++)
                    {
                        if (c == enemiesS[i])
                        {
                            c.GetComponent<Enemy>().Slice();
                        }
                    }
                }
                foreach (Collider2D c in thisFramesBomb)
                {
                    for (int i = 0; i < bombsS.Length; i++)
                    {
                        if (c == bombsS[i])
                        {
                            c.GetComponent<Bomb>().Slice();
                        }
                    }
                }
                foreach (Collider2D c in thisFramesPowerUp)
                {
                    for (int i = 0; i < powerUpsS.Length; i++)
                    {
                        if (c == powerUpsS[i])
                        {
                            c.GetComponent<PowerUp>().Slice();
                        }
                    }
                }
            }
  
            lastMousePosition = Input.mousePosition;
            enemiesS = thisFramesEnemy;
            bombsS = thisFramesBomb;
            powerUpsS = thisFramesPowerUp;
                
        }
    }

    private Enemy GetEnemy()
    {
        Enemy e = enemies.Find(x => !x.IsActive);

        if ( e == null)
        {
            e = Instantiate(enemyPrefab).GetComponent<Enemy>();
            enemies.Add(e);

        }
        return e;
    }

    private Bomb GetBomb()
    {
        Bomb b = bombs.Find(x => !x.IsActive);
        if(b == null)
        {
            b = Instantiate(bombPrefab).GetComponent<Bomb>();
            bombs.Add(b);
        }
        return b;
    }

    private PowerUp GetPowerUp()
    {
        PowerUp p = powerUps.Find(x => !x.IsActive);
        if (p == null)
        {
            p = Instantiate(powerUpPrefab).GetComponent<PowerUp>();
            powerUps.Add(p);
        }
        return p;
    }

    public void gainPowerUp() {
        isPowerUpActive = true;
        Debug.Log("power up obtained");
    }

    public void LoseLP()
    {
        if (lifepoint == 0)
            return;

        lifepoint--;
        lifepoints[lifepoint].enabled = false;
        if (lifepoint == 0)
            Death();

    }

    public void IncrementScore(int scoreAmount)
    {
        score = score + scoreAmount;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = highscore.ToString();
            PlayerPrefs.SetInt("Score", highscore);
        }
        //if (score > 25)
        //{
        //  PlayerPrefs.SetInt("MAX_LEVEL", 2);
        //}
        //if (score > 50)
        //{
        //    PlayerPrefs.SetInt("MAX_LEVEL", 3);
        //}

    }

    public void Death()
    {
        isPause = true;
        Debug.Log("The score is: " + score);
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportScore(score,
                GPGSIds.leaderboard_ninja_sliced,
                (bool success) =>
                {
                    Debug.Log("Leaderboard update success: " + success);
                });
        }
        deathMenu.SetActive(true);
    }

    

    public void PauseGame()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        isPause = pauseMenu.activeSelf;
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
    }

    public void backMenu()
    {
     
            SceneManager.LoadScene("Menu");
    }

}
