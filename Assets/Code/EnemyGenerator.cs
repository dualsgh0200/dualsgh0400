using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Alien1; // 외계인 1 프리팹 변수
    public GameObject Alien2; // 외계인 2 프리팹 변수
    private float fspan = 0.15f; // 외계인 생성 주기 변수
    private float fdelta = 0; // 누적 시간 변수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCome();
    }
    void EnemyCome()
    {
        this.fdelta += Time.deltaTime; // 매 프레임마다 누적 시간을 업데이트
        if (this.fdelta > this.fspan) // 누적 시간이 생성 주기를 초과시 외계인 생성
        {
            // 외계인 생성
            GameObject prefab;
            if (Random.value < 0.5f)
                prefab = Alien1; // 50%의 확률로 외계인 1 생성
            else
                prefab = Alien2; // 50%의 확률로 외계인 2 생성

            var go = Instantiate(prefab); // 프리팹을 인스턴스화하여 게임 오브젝트 생성
            // 랜덤한 위치에 생성
            go.transform.position = new Vector3(Random.Range(-2.58f, 2.58f), Random.Range(5.5f, 5.94f), 0);

            this.fdelta = 0; // 누적 시간 초기화
        }
    }
}
