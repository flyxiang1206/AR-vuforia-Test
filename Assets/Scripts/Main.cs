using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private static Text _txtScore { get; set; }
    private static Text _txtGetScore { get; set; }
    private static int _score { get; set; }
    private static int timeer { get; set; }
    private static int end { get; set; }

    // Use this for initialization
    private void Awake()
    {
        try
        {
            #region   //Scan
            int childCount = this.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                GameObject go = this.transform.GetChild(i).gameObject;
                Debug.Log("Child Index = " + i + " Name = " + go.name);
                if (go.name.Equals("Score"))
                {
                    _txtScore = go.GetComponent<Text>();
                }
                if (go.name.Equals("GetScore"))
                {
                    _txtGetScore = go.GetComponent<Text>();
                }

            }
            #endregion
        }
        catch (Exception exp)
        {
            Debug.LogError(exp.ToString());
        }
    }
    private void Start()
    {
        _score = 0;
        _txtScore.text = "Score : 0";
        _txtGetScore.text = "";
        timeer = 0;
        end = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        _txtScore.text = "Score : " + _score.ToString();
        if (timeer == 0)
        {
            txt(false);
        }
        else
        {
            timeer--;
        }
 
        if (_score >= 100)
        {
            _txtScore.text = "YOU WIN !!!!";
            if (end == 0)
            {
                end = 200;
                Debug.Log("OSO");

            }
        }
        if(end!=0)
        {
            end--;
            if (end == 0)
            {
                Debug.Log("END");
                Application.Quit();
            }
            Debug.Log(end.ToString());
        }
    }

    public void timee(object a, System.Timers.ElapsedEventArgs e)
    {
        txt(false);
    }

    public static void txt(bool a)
    {
        if (a)
        {
            _txtGetScore.gameObject.SetActive(true);
        }
        if (!a)
        {
            _txtGetScore.gameObject.SetActive(false);
        }
    }

    public static void Get(string g)
    {
        if (g == "Car1")
        {
            _score += 10;
            _txtGetScore.text = "+10";
            timeer = 60;
            txt(true);
        }
        if (g == "Car2")
        {
            _score += 20;
            _txtGetScore.text = "+20";
            timeer = 60;
            txt(true);
        }
    }
}
