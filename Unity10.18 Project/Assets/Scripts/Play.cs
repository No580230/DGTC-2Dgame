
using UnityEngine;

public class Play : MonoBehaviour
{
    
    [Header("速度")] [Range(0, 100f)]//設定範圍大小
    public float speed = 3.5f;
    [Header("跳越")] [Range(100, 2000)]//設定範圍大小
    public int jump = 300;
    [Header("是否在地板上")] [Tooltip("用來判定角色是否在地板上。")]//提示文字
    public bool isGround = false;
    [Header("人物名稱")]
    public string _name = "Jack";
    [Header("2D 剛體")]
    public Rigidbody2D r2d;
    public Animator ani;
    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip soundDiamod;
    //定義方法
    //語法
    //修飾詞傳回類型 方法名稱


    private void Move()//移動
    {
        float h = Input.GetAxisRaw("Horizontal");//（x）軸向水平移動
        r2d.AddForce(new Vector2(speed*h ,0));
        ani.SetBool("奔跑鍵",h!=0); //動畫元件
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) transform.eulerAngles = new Vector3(0, 180, 0);
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) transform.eulerAngles = new Vector3(0, 0, 0);

    }
    private void Jump()//跳越
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround==true)
        {
            //在地板上 =取消
            isGround = false;
            //剛體.推力
            r2d.AddForce(new Vector2(5, jump));
            //動畫元件:設定觸發器(參數)
            ani.SetTrigger("跳越觸發");
        }
    }
    private void Dead()//死亡
    {

    }

    //添加事件 
    //更新事件 一秒執行約60次(60fps)
    private void Update()
    {
        Move();
        Jump();   
    }

    //踫撞事件
    //collision 參數：踫到物件的咨詢
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }
    }
}
