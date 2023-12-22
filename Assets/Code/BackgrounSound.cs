using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrounSound : MonoBehaviour
{
    //배경음악에 대한 참조변수
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        //bgm을 무한 반복
        bgm.loop = true;
        //bgm 플레이
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
