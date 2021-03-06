using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameStates
{
    //ESTADOS DEL JUEGO
    PREP,
    GAME,
    WIN,
    LOST
}

public class GameManager : MonoBehaviour
{
    //ASIGNAMOS EL TMPRO
    [SerializeField] TMP_Text textTime;
    [SerializeField] TMP_Text textStateGame;
    [SerializeField] GameObject winPanel, lostPanel, startButton;
    [SerializeField] Image[] collecionables;
    [SerializeField] Image[] rescued;
    [SerializeField] GameObject lemmingsPanel;
    [SerializeField] Image  lemmingAliveUI;
    [SerializeField] Sprite lemmingDeathSprite;
    [SerializeField] Sprite rescuedSprite;
    [SerializeField] Sprite deathRescue;

    [SerializeField] List<Image> heartImages;

    //ASIGANOS EL TIEMPO DE PREPARACION Y VARIABLE DEL TIEMPO ACTUAL
    [Range(1, 100)]
    public int prepTime;
    int time;

    //ASIGNAMOS NUESTROS ESTADOS
    public GameStates myGameStates;

    //ASIGNAMOS AL MASTERLEMMING
    private MasterLemming myBoy;
    public int lemmings;

    //ASIGNAMOS EL NUMERO DE LEMMINGS VIVIOS, NUMERO DE LEMMINGS ENCONTRADOS Y COLECCIONABLES
    public int rescuedLemmings;
    public int foundCollectables = 0;
    public int aliveLemmings;

    //SIGUIENTE NIVEL
    public int nextLevel;


    private void Awake()
    {
        //BUSCAMOS AL MASTERLEMMING
        myBoy = FindObjectOfType<MasterLemming>();
    }
    private void Start()
    {
        //APAGAMOS LA UI
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
        startButton.SetActive(false);


        aliveLemmings = myBoy.lemmingsAlive.Count;

        //INICIALIZAMOS ESTADO "PREP" Y LA FASE DE PREPARACION
        myGameStates = GameStates.PREP;
        time = prepTime;
        textStateGame.text = "EN PREPARACION, MUEVE LOS OBSTACULOS :D";
        if (myGameStates == GameStates.PREP)
        {
            StartCoroutine(PrepPhase());
        }

        InitUIAliveLemmings();
    }

    //CORRUTINA O CREACION DE LA FASE DE PREPARACION
    private IEnumerator PrepPhase()
    {
        //RESTAMOS EL TIEMPO DE ESPERA HASTA LA SIQUIENTE FASE
        Invoke("ShowStartButton", 3f);
        while (time > 0)
        {
            yield return new WaitForSeconds(1.0f);
            time -= 1;
            textTime.text = time.ToString();
        }

        //INICIALIZAMOS EL ESTADO "GAME"
        Debug.Log("ESTATE GAME");
        myGameStates = GameStates.GAME;
        textStateGame.text = "VIGILA QUE TUS LEMMINGS LLEGUEN A LA META";
        StartCoroutine(MainPhase());
        
    }

    //CORRUTINA PARA ACTIVAR A LOS LEMMINGS Y LA MAINPHASE
    private IEnumerator MainPhase()
    {
        Debug.Log("MAIN PHASE");
        StartCoroutine(myBoy.GoBoys());
        yield return null;
    }

    //FUNCION DE VICTORIA
    public void WIN()
    {
        Debug.Log("VICTORIA :DDD");
        textStateGame.text = "LO LOGRASTE :D";
        myGameStates = GameStates.WIN;
        winPanel.SetActive(true);
    }

    public void LOST()
    {
        Debug.Log("DERROTA :C");
        textStateGame.text = "ERES UN ASESINO D:";
        myGameStates = GameStates.LOST;
        lostPanel.SetActive(true);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void StartLevel()
    {
        time = 1;
        startButton.SetActive(false);
    }

    private void ShowStartButton()
    {
        startButton.SetActive(true);
    }

    public void UpdateCollectable()
    {
        if(foundCollectables < collecionables.Length )
            collecionables[foundCollectables].color = Color.white; 
    }

    public void InitUIAliveLemmings()
    {
        for (int i = 0; i < aliveLemmings; i++)
        {
            Image go = Instantiate(lemmingAliveUI, lemmingsPanel.transform);

            go.transform.SetParent(lemmingsPanel.transform);

            heartImages.Add(go);
        }
    }

    public void UpdateUILemmingDeath()
    {
        if(aliveLemmings > 0)
            heartImages[aliveLemmings - 1].sprite = lemmingDeathSprite;
    }

    public void AddRescueLemmingsUI()
    {
        if (rescuedLemmings < rescued.Length)
            rescued[rescuedLemmings].sprite = rescuedSprite;
    }

  
}
