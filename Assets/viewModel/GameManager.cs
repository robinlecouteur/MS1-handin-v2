using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UManager = UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager instance; 

    private bool gameRunning;

    public GameModel gameModel;

    public Canvas activeCanvas;
    public Canvas cnvGame;
    public Canvas cnvInventory;
    public Canvas cnvMap;
    private Dictionary<string, Canvas> canvases;

    public Dictionary<string, Canvas> Canvases
    {
        get
        {
            return canvases;
        }

        set
        {
            canvases = value;
        }
    }

    public void setActiveCanvas(string prName)
    {

        if (Canvases.ContainsKey(prName))
        {

            // set all to not active;
            foreach (Canvas prCanvas in Canvases.Values)
            {
                    prCanvas.gameObject.SetActive(false);
            }
                activeCanvas = Canvases[prName];
                Debug.Log("I am the active one " + prName);
                activeCanvas.gameObject.SetActive(true);
            
        }
        else
        {
            Debug.Log("I can not find " + prName + " to make active.");
        }

        Canvas[] tempCanvases = gameObject.GetComponentsInChildren<Canvas>();

        foreach (Canvas prCanvase in tempCanvases)
        {
            if (prCanvase.name != prName)
            {
                prCanvase.gameObject.SetActive(false);
            }
        }
    }
    public string currentUScene()
    {
        return UManager.SceneManager.GetActiveScene().name;
    }

    public void changeUScene(string pSceneName)
    {
        UManager.SceneManager.LoadScene(pSceneName);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameRunning = true;
            Debug.Log("I am the one");
            gameModel = new GameModel();
        }
        else
        {
            Destroy(gameObject);
        }

        if (Canvases == null)
        {
            Canvases = new Dictionary<string, Canvas>();
            Canvases["cnvGame"] = cnvGame;
            Canvases["cnvMap"] = cnvMap;
            Canvases["cnvInventory"] = cnvInventory;
            
        }
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }
}
