using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text textScore; //���� ǥ��
    private int Iscore;

    public int GetScore()
    {
        return Iscore;
    }

    public void UpdateScore(int addScore)
    {
        this.Iscore += addScore;
        // UI �ؽ�Ʈ�� ������Ʈ�Ͽ� ������ ǥ��
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
