using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    private float delta; // 총알 발사 딜레이 계산에 사용되는 변수
    public bool isTouchBottom; // 아래쪽 벽과 접촉 여부를 나타내는 변수
    public bool isTouchTop;  // 위쪽 벽과 접촉 여부를 나타내는 변수
    public bool isTouchRight;  // 오른쪽 벽과 접촉 여부를 나타내는 변수
    public bool isTouchLeft;  // 왼쪽 벽과 접촉 여부를 나타내는 변수
    public float fmaxShotDelay = 0.7f; // 최대 총알 발사 딜레이
    public float fcurShotDelay; // 현재 총알 발사 딜레이

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 수평 입력값을 받아오는 변수
        // 사용자가 왼쪽 방향키를 누르면 -1,
        // 오른쪽 방향키를 누르면 1의 값을 반환하며, 아무 입력도 없을 경우 0을 반환
        var dirx = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && dirx == 1) || (isTouchLeft && dirx == -1))
        {
            dirx = 0;
        }
        // 수직 입력값을 받아오는 변수
        // 사용자가 위쪽 방향키를 누르면 1, 아래쪽 방향키를 누르면 - 1의 값을 반환하며, 
        // 아무 입력도 없을 경우 0을 반환
        var diry = Input.GetAxisRaw("Vertical"); 
        if ((isTouchTop && diry == 1) || (isTouchBottom && diry == -1))
            diry = 0;

        // 입력 방향 벡터 생성
        var dir = new Vector3(dirx, diry, 0);

        // 입력 방향으로 플레이어 이동
        this.transform.Translate(dir.normalized * 3.0f * Time.deltaTime);

        // 스페이스바 입력 시 총알 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Shoot();
        }
        // 총알 발사 딜레이 계산
        Reload();
    }
    private void Shoot()
    {

        if (fcurShotDelay > fmaxShotDelay)
        {
            //총알 생성
            var bulletGo = Instantiate(this.bulletPrefab);
            bulletGo.transform.position = this.transform.position;

            //총알 발사 딜레이를 초기화
            fcurShotDelay = 0;
        }
    }

    //총알과 적이 부딪힐 경우
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.tag == "Border")
        {
            // 벽과 접촉한 경우 해당 방향 변수를 true로 설정
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
            }
        }
    }

   

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            // 벽과 접촉이 해제된 경우 해당 방향 변수를 false로 설정
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
            }
        }
    }

    // 총알 발사 딜레이 계산
    void Reload()
    {
        fcurShotDelay += Time.deltaTime;
    }
}
