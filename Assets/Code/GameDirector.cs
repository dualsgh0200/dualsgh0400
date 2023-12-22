using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text textScore; //점수 표시
    private int Iscore;

    public int GetScore()
    {
        return Iscore;
    }

    public void UpdateScore(int addScore)
    {
        this.Iscore += addScore;
        // UI 텍스트를 업데이트하여 점수를 표시
        this.textScore.text = string.Format("{0}", this.Iscore);
    }

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
