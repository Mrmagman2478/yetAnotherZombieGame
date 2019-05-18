using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour {
    //public fields
    public float characterSpeed = 10;
    public float characterJumpHeight = 0.1f;
    //visiable fields that none editable
    [SerializeField]
    int kills = 0;
    [SerializeField]
    int score = 0;

    public Text GUI_kills;
    public Text GUI_Health;
    public Text GUI_Score;
    public Text GameOver_Score;
    public GameObject GameOver;
    public Button Restrart;

    void Start () {
        //allow custom speed and jumpheight while keeping movement variavble private
        gameObject.GetComponent<Character_Movement>().setMovementModifier(characterSpeed, characterJumpHeight);
        Restrart.onClick.AddListener(restartGame);
    }
	void Update () {
        GUI_Health.text = "Health: " + gameObject.GetComponent<Health>().getHealth().ToString();
        GUI_kills.text = "Kills: " + kills.ToString();
        GUI_Score.text = "Score: " + score.ToString();
        if (gameObject.GetComponent<Health>().checkLifeSigns() == false)
        {
            GUI_Score.enabled = false;
            GameOver_Score.text = "Score: " + score.ToString();
            GameOver.SetActive(true);
        }
    }
    public int getKills() { return kills; }

    public void addKill() { kills++; }

    public void addScore(int Score) { score = score + Score; }

    void restartGame()
    {
        SceneManager.LoadScene("Game_V1", LoadSceneMode.Single);
    }
}
