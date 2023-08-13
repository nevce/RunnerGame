using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //oyuncunun baþlama noktasý
    public Transform startingPoint;

    //lerp hýzý
    public float lerpSpeed;

    //oyuncunun yüksek skoru
    public float highScore = 0;

    //oyuncunun anlýk skoru
    public float score = 0;

    //skoru gösteren metin nesneleri
    public TextMeshProUGUI TotalScoreText;
    public TextMeshProUGUI HighScoreText;

    PlayerController playerControllerScript;

    private void Start()
    {
        //yüksek skoru oyuncu tercihlerinden al
        highScore = PlayerPrefs.GetFloat("EnYuksekSkorum", 0);

        //skoru ve yüksek skoru ekranda göster
        TotalScoreText.text = "SCORE: " + score;
        HighScoreText.text = "HIGHSCORE: " + highScore;

        //oyuncu kontrolleini al ve oyunu baþlat
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerControllerScript.gameOver = false;
        StartCoroutine(PlayerIntro());
    }

    private void Update()
    {
        //yüksek skoru güncelle
        HighScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    IEnumerator PlayerIntro()
    {
        //Intro animasyonu için baþlangýç ve bitiþ pozisyonularý
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;

        //Intro animasyonunun uzunluðu
        float journeyLength = Vector3.Distance(startPos, endPos);

        //intro animasyonunun baþlangýç zamaný
        float startTime = Time.time;

        //intro animasoynunun ne kadar sürede tamamlandýðý
        float distanceCov = (Time.time - startTime) / lerpSpeed;
        float fractionJourney = distanceCov / journeyLength;

        //intro animasyonunun lerp ile oynat
        while (fractionJourney < 1)
        {
            distanceCov = (Time.time - startTime) * lerpSpeed;
            fractionJourney = distanceCov / journeyLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionJourney);
            yield return null;
        }

        //intro sona erdiðinde oyunu devam ettirir
        playerControllerScript.gameOver = false;
    }

    //skor eklemek için metod
    public void AddScore(int value)
    {
        //skoru güncelle ve yüksek skoru kontrol et
        score += value;
        TotalScoreText.text = "SCORE: " + score;

        if (score >= highScore)
        {
            highScore = score;
            HighScoreText.text = "HIGHSCORE: " + highScore;

            //yeni yüksek skoru dataya kaydet
            PlayerPrefs.SetFloat("EnYuksekSkorum", highScore);
        }
        else
        {
            HighScoreText.text = "HIGHSCORE: " + highScore;
        }
    }

}
