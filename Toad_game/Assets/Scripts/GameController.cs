using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    private static GameController instance = null;                   // singleton del controlador del juego
    public static GameController GetInstance() { return instance; }

    [SerializeField] private GameObject juegoUI = null;              // la interfaz de usuario
    [SerializeField] private GameObject limiteIzquierdo = null;      // el objeto para determitar el limite izquierdo
    [SerializeField] private GameObject limiteDerecho = null;        // el objeto para determinar el limite derecho
    [SerializeField] private GameObject player = null;               // el Player
    [SerializeField] private int maxVidas=0;                         // numero de vidas
    [SerializeField] private AudioClip audioGameOver=null;           // sonido al morir
    [SerializeField] private AudioClip audioWin = null;
    private AudioSource audioSource;

    private Text vidas;
    private Text puntos;
    private GameObject gameOver;
    private int nVidas = 0;
    private int nPuntos = 0;
    private float limIzq;
    private float limDer;
    private GameObject gameWin;
    public int Contador = 4;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy( this.gameObject );
        else
            instance = this;

        audioSource = GetComponent<AudioSource>();
        nVidas = maxVidas;

        limIzq = limiteIzquierdo.GetComponent<SpriteRenderer>().bounds.min.x;
        limDer = limiteDerecho.GetComponent<SpriteRenderer>().bounds.max.x;

        vidas = juegoUI.transform.Find("Vidas").gameObject.GetComponent<Text>();
        puntos = juegoUI.transform.Find("Puntos").gameObject.GetComponent<Text>();
        gameOver = juegoUI.transform.Find("GameOver").gameObject;
        gameWin = juegoUI.transform.Find("GameWin").gameObject;

        vidas.text = nVidas.ToString();
        puntos.text = nPuntos.ToString();
        gameOver.SetActive(false);
        gameWin.SetActive(false);
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public float GetLimiteIzquierdo()
    {
        return limIzq;
    }

    public float GetLimiteDerecho()
    {
        return limDer;
    }

    public int RestaVidas()
    {
        try
        {
            if (nVidas > 0)
            {
                nVidas--;
                if (nVidas == 0)
                {
                    audioSource.clip = audioGameOver;
                    audioSource.Play();
                    SceneManager.LoadScene(0);
                }
                vidas.text = nVidas.ToString();
            }
        }
        catch (Exception e)
        {
            print(e);
        }

        return nVidas;
    }
    public void SumaPuntos(int n)
    {
        try
        {
            nPuntos += n;
            puntos.text = nPuntos.ToString();
        }
        catch (Exception e)
        {
            print(e);
        }
        
        if(nPuntos == 7) 
        {
            audioSource.clip = audioWin;
            audioSource.Play();
            

            SceneManager.LoadScene(Contador);
            while (Contador < 5) 
            {
                Contador += 1;
            }
            
            
            



        }

        /*if (nPuntos == 7)
        {
            audioSource.clip = audioWin;
            audioSource.Play();


            int i = 0;
            int Contador = 4;
            while (i < 2)
            {
                
                
                SceneManager.LoadScene(Contador);
                Contador += 1;
                i += 1;
                if (Contador == 5) 
                {
                    SceneManager.LoadScene(5);
                    break;
                }
                
            }
            
        }
        vidas.text = nVidas.ToString(); */
    }
    


}


    


