using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CountdownController : MonoBehaviour
{

    public int countdownTime;

    [SerializeField] private Text countdownDisplay1;
    [SerializeField] private Text countdownDisplay2;
    [SerializeField] private GameObject startWall;
    [SerializeField] private Text timeCounter1;
    [SerializeField] private Text timeCounter2;
    [SerializeField] private Text FinalTimerText1;
    [SerializeField] private Text FinalTimerText2;
    [SerializeField] private GameObject LeaderBoardPanel;
    [SerializeField] private float[] times;
    [SerializeField] private GameObject Star1;
    [SerializeField] private GameObject Star2;
    [SerializeField] private GameObject Star3;




    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake()
    {
        FinalTimerText1.gameObject.SetActive(false);
        FinalTimerText2.gameObject.SetActive(false);
        LeaderBoardPanel.gameObject.SetActive(false);
    }
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
        timeCounter1.gameObject.SetActive(false);
        timeCounter2.gameObject.SetActive(false);
        FinalTimerText1.gameObject.SetActive(true);
        FinalTimerText2.gameObject.SetActive(true);
        LeaderBoardPanel.gameObject.SetActive(true);
        StarRating();
        StartCoroutine(SlowDown());
    }
    IEnumerator CountdownToStart()
    {
        
        while(countdownTime > 0)
        {
            countdownDisplay1.text = countdownTime.ToString();
            countdownDisplay2.text = countdownTime.ToString();


            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay1.text = "GO!";
        countdownDisplay2.text = "GO!";

        BeginTimer();
        startWall.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);

        countdownDisplay1.gameObject.SetActive(false);
        countdownDisplay2.gameObject.SetActive(false);

        //startWall.gameObject.SetActive(false);

    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timeCounter1.text = timePlayingStr;
            timeCounter2.text = timePlayingStr;
            FinalTimerText1.text = timePlayingStr;
            FinalTimerText2.text = timePlayingStr;

            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        timeCounter1.text = "00:00.00";
        timeCounter2.text = "00:00.00";

        timerGoing = false;
        StartCoroutine(CountdownToStart());
    }

    IEnumerator SlowDown()
    {
        yield return new WaitForSeconds(5);
        //Star1.gameObject.SetActive(false);
        //Star2.gameObject.SetActive(false);
        //Star3.gameObject.SetActive(false);

        SceneManager.LoadScene(1);
    }

    public void StarRating()
    {
        if (elapsedTime <= times[2])
            Star1.gameObject.SetActive(true);
        if (elapsedTime <= times[1])
            Star2.gameObject.SetActive(true);
        if (elapsedTime <= times[0])
            Star3.gameObject.SetActive(true);

    }
}
