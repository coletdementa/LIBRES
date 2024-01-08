using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool pauseTime;
    private bool playTime;
    public float speed;
    public float deathTime;
    public float loreCount;
    public bool deathCount;
    private float time;

    public Vector3 respawnPoint;
    
    public GameObject titleScreen;
    public GameObject pauseScreen;
    public GameObject exitScreen;
    public GameObject soundOn;
    public GameObject soundOff;

    public GameObject loreText0;
    public GameObject loreText1;
    public GameObject loreText2;
    public GameObject loreText3;
    public GameObject loreText4;
    public GameObject loreText5;

    public GameObject loreWolf;
    public GameObject loreMonkey;
    public GameObject loreEagle;
    public GameObject loreTiger;

    public GameObject dynamicObjects;

    public AudioClip plop;
    public AudioClip ico;
    public AudioClip walking;
    public AudioClip click;
    
    public GameObject character;
    public GameObject companion;
    
    public GrandoteMovement grandoteScriptCharacter;
    public ChiquitoMovement chiquitoScriptCharacter;

    private Rigidbody2D grandoteRb;
    private Rigidbody2D chiquitoRb;
    private AudioSource source;

    public Camera cam;

    void Start(){
        character = GameObject.Find("Chiquito");
        companion = GameObject.Find("Grandote");
        dynamicObjects = GameObject.Find("DynamicObjects");
        respawnPoint = character.transform.position;

        grandoteRb = grandoteScriptCharacter.GetComponent<Rigidbody2D>();
        chiquitoRb = chiquitoScriptCharacter.GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

        titleScreen.SetActive (true);
        pauseScreen.SetActive (false);
        exitScreen.SetActive (false);
        character.SetActive (false);

        loreText0.SetActive(false);
        loreText1.SetActive(false);
        loreText2.SetActive(false);
        loreText3.SetActive(false);
        loreText4.SetActive(false);
        loreText5.SetActive(false);

        loreWolf.SetActive(false);
        loreMonkey.SetActive(false);
        loreEagle.SetActive(false);
        loreTiger.SetActive(false);

        grandoteRb.bodyType = RigidbodyType2D.Static;
        chiquitoRb.bodyType = RigidbodyType2D.Dynamic;

        soundOn.SetActive (true);
        soundOff.SetActive (false);
        cam.GetComponent<AudioListener>().enabled = true;
    }

    public void StartGame(){
        source.clip = click;
        source.Play();
        titleScreen.SetActive (false);
        pauseScreen.SetActive (false);
        exitScreen.SetActive (false);
        character.SetActive (true);
    }

    public void ExitStageOne(){
        source.clip = click;
        source.Play();
        titleScreen.SetActive (false);
        pauseScreen.SetActive (false);
        exitScreen.SetActive (true);
        character.SetActive (false);  
    }

    public void ExitStageTwo(){
        source.clip = click;
        source.Play();
        Application.Quit();
    }

    public void Pause(){
        source.clip = click;
        source.Play();
        titleScreen.SetActive (false);
        pauseScreen.SetActive (true);
        exitScreen.SetActive (false);
    }
    
    public void Sound(){
        source.clip = click;
        source.Play();
        soundOn.SetActive (true);
        soundOff.SetActive (false);
        cam.GetComponent<AudioListener>().enabled = true;
    }

    public void NoSound(){
        source.clip = click;
        source.Play();
        soundOn.SetActive (false);
        soundOff.SetActive (true);
        cam.GetComponent<AudioListener>().enabled = false;
    }

    public void Wolf(){
        loreWolf.SetActive(false);
    }

    public void Monkey(){
        loreMonkey.SetActive(false);
        chiquitoScriptCharacter.jumpSpeed += 4;
    }
    
    public void Eagle(){
        loreEagle.SetActive(false);
        chiquitoScriptCharacter.totalJumps += 1;
    }

    public void Tiger(){
        loreTiger.SetActive(false);
        chiquitoScriptCharacter.claws += 1;
    }

    public void ExitLore (){
        source.clip = click;
        source.Play();
        
        loreText0.SetActive(false);
        loreText1.SetActive(false);
        loreText2.SetActive(false);
        loreText3.SetActive(false);
        loreText4.SetActive(false);
        loreText5.SetActive(false);
    }

    void Update(){
        if (Input.GetKeyDown("escape")){
            Pause();
        }
    }

    public void Unconnected(){
        grandoteRb.bodyType = RigidbodyType2D.Static;
    }

    public void Connected(){
        grandoteRb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void Death(){
        chiquitoScriptCharacter.faint = true;
        source.clip = plop;
        source.Play();
    }

    public void Respawn(){
        character.transform.position = respawnPoint;
        chiquitoScriptCharacter.SendMessage("Revive");
        dynamicObjects.BroadcastMessage("Replace");
        dynamicObjects.SendMessage("Reset");
        
    }

    public void NewRespawnPoint(Vector3 newRespawnPoint){
        respawnPoint = newRespawnPoint;
    }

    public void Restart(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }

    public void GrandoteNotAllowed(){
        companion.SetActive(false);
    }

    public void GrandoteAllowed(){
        companion.SetActive(true);
    }

}
