using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config param
   [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;//[Range(1f,10f)]min ve max speed'ı bir çubuk gibi değere koymamaızı sağlar.  
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    //state variables
    [SerializeField] int currnetScore=0;//0 dan baslatmamızın sebebi oyun sıfırlanırsa veya res. atarsak tekrar sıfırdan baslaması içindir.



    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;//saklanacagını söyleriz ve kaç tane oyun durumu nesnesi var diye baktırırız.
        if (gameStatusCount>1)//1'den büyük yazmamızın nedeni diylim ki 1 zaten varsa ve kednimi yaratmaya çalışırken bu senaryo kendimi yürütmeye çalışırken 2 numara olacagım demektir.
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }


    }



    private void Start()
    {
        scoreText.text = currnetScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currnetScore +=pointsPerBlockDestroyed;
      scoreText.text = currnetScore.ToString();

    }


    public void ResetGame()
    {
        Destroy(gameObject);
    }




}


