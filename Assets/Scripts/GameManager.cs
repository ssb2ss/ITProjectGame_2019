using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private AudioSource mainSound;

    private static GameManager instance = null;

    public Pattern[] patterns;
    public GameObject gameStart;
    public GameObject gameOver;
    public GameObject background;

    public static int curState = 0;
    public static int cnt = 0;

    private int currentPattern;

    private float bgR, bgG, bgB;


    public static GameManager GetInstance()
    {
        return instance;
    }


    private void Awake()
    {
           
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        mainSound = GetComponent<AudioSource>();
        BulletManager.GetInstance().Create(Resources.Load<GameObject>("Prefabs/Bullet"), 500);

        Time.timeScale = 0;
        currentPattern = 0;

        bgR = Random.Range(0f, 0.5f);
        bgG = Random.Range(0f, 0.5f);
        bgB = Random.Range(0f, 0.5f);

        background.GetComponent<SpriteRenderer>().color = new Color(bgR, bgG, bgB);

        StartCoroutine(BackgroundColorChange());
    }
    private void Update()
    {

        if (curState == 0 && Input.GetMouseButtonDown(0))
        {
            gameStart.SetActive(false);
            StartCoroutine(StartPattern());
            Time.timeScale = 1;
            curState = 1;
        }

        if (curState == 2 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            curState = 0;
        }

        if (cnt == 1 && curState == 2)
        {
            gameOver.SetActive(true);

            Time.timeScale = 0;
            cnt = 0;
        }

        SpriteRenderer spr = background.GetComponent<SpriteRenderer>();
        background.GetComponent<SpriteRenderer>().color += new Color(
            (bgR - background.GetComponent<SpriteRenderer>().color.r) / 10f,
            (bgG - background.GetComponent<SpriteRenderer>().color.g) / 10f,
            (bgB - background.GetComponent<SpriteRenderer>().color.b) / 10f);
    }

    private void OnEnable()
    {
 
       
    }

    public void SetPattern()
    {
        Debug.Log("Pattern Setting...");

        for (int i = 0; i < patterns.Length; i++)
            patterns[i].isReady = false;

        //int rand = Random.Range(0, patterns.Length);

        patterns[currentPattern].isInit = true;

        currentPattern++;
        if (currentPattern >= patterns.Length)
            currentPattern = 0;
    }

    private IEnumerator StartPattern()
    {
        yield return new WaitForSeconds(1f);
        SetPattern();
        yield return null;
    }

    private IEnumerator BackgroundColorChange()
    {
        while(true)
        {
            bgR = Random.Range(0f, 0.5f);
            bgG = Random.Range(0f, 0.5f);
            bgB = Random.Range(0f, 0.5f);

            yield return new WaitForSeconds(0.5f);
        }
    }

}
