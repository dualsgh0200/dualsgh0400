using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // 파티클 시스템 컴포넌트를 참조하기 위한 변수
    private ParticleSystem explosion;

    private void Awake()
    {
        // 현재 게임 오브젝트의 파티클 시스템 컴포넌트를 가져옴
        explosion = GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // 파티클 재생 중인지 확인
        if (explosion.isPlaying == false)
        {
            // 파티클 재생이 끝나면 자기 자신을 파괴
            Destroy(gameObject);
        }
    }
}
