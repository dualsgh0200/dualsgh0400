using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab; // �Ѿ� ������
    private float delta; // �Ѿ� �߻� ������ ��꿡 ���Ǵ� ����
    public bool isTouchBottom; // �Ʒ��� ���� ���� ���θ� ��Ÿ���� ����
    public bool isTouchTop;  // ���� ���� ���� ���θ� ��Ÿ���� ����
    public bool isTouchRight;  // ������ ���� ���� ���θ� ��Ÿ���� ����
    public bool isTouchLeft;  // ���� ���� ���� ���θ� ��Ÿ���� ����
    public float fmaxShotDelay = 0.7f; // �ִ� �Ѿ� �߻� ������
    public float fcurShotDelay; // ���� �Ѿ� �߻� ������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���� �Է°��� �޾ƿ��� ����
        // ����ڰ� ���� ����Ű�� ������ -1,
        // ������ ����Ű�� ������ 1�� ���� ��ȯ�ϸ�, �ƹ� �Էµ� ���� ��� 0�� ��ȯ
        var dirx = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && dirx == 1) || (isTouchLeft && dirx == -1))
        {
            dirx = 0;
        }
        // ���� �Է°��� �޾ƿ��� ����
        // ����ڰ� ���� ����Ű�� ������ 1, �Ʒ��� ����Ű�� ������ - 1�� ���� ��ȯ�ϸ�, 
        // �ƹ� �Էµ� ���� ��� 0�� ��ȯ
        var diry = Input.GetAxisRaw("Vertical"); 
        if ((isTouchTop && diry == 1) || (isTouchBottom && diry == -1))
            diry = 0;

        // �Է� ���� ���� ����
        var dir = new Vector3(dirx, diry, 0);

        // �Է� �������� �÷��̾� �̵�
        this.transform.Translate(dir.normalized * 3.0f * Time.deltaTime);

        // �����̽��� �Է� �� �Ѿ� �߻�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Shoot();
        }
        // �Ѿ� �߻� ������ ���
        Reload();
    }
    private void Shoot()
    {

        if (fcurShotDelay > fmaxShotDelay)
        {
            //�Ѿ� ����
            var bulletGo = Instantiate(this.bulletPrefab);
            bulletGo.transform.position = this.transform.position;

            //�Ѿ� �߻� �����̸� �ʱ�ȭ
            fcurShotDelay = 0;
        }
    }

    //�Ѿ˰� ���� �ε��� ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.tag == "Border")
        {
            // ���� ������ ��� �ش� ���� ������ true�� ����
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
            // ���� ������ ������ ��� �ش� ���� ������ false�� ����
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

    // �Ѿ� �߻� ������ ���
    void Reload()
    {
        fcurShotDelay += Time.deltaTime;
    }
}
