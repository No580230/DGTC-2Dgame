
using UnityEngine;

public class Play : MonoBehaviour
{
    [Header("速度")][Range(0,100f)]//設定範圍大小
   public float speed = 3.5f;
    [Header("跳越")][Range(100,2000)]//設定範圍大小
    public int jump = 300;
    [Header("是否在地板上")][Tooltip("用來判定角色是否在地板上。")]//提示文字
    public bool isGround = false;
    [Header("人物名稱")]
    public  string _name = "Jack";

}
