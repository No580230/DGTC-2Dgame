using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("跟隨目標")]
    public Transform target;
    [Header("跟隨速度"), Range(0f, 100f)]
    public float speed = 1.5f;


    private void Track()
    {
        // 浮點數 限制后的 Y=數學.夾住（要夾住的值，最小值，最大值）
        float limitY = Mathf.Clamp(target.position.y, -0.3f, 3f);
        //三維向量 =新 三維向量（目標+座標.X，目標.座標,Y,-10）-攝影機 Z 預設為-10
        Vector3 targetPos = new Vector3(target.position.x, limitY, -10);
        // 攝影機.座標 =三維向量.插值(攝影機.座標,目標座標,百分比*速度*-一幀的時間)
        transform.position = Vector3.Lerp(transform.position, targetPos,0.3f*speed*Time.deltaTime);
    }
    private void LateUpdate()
    {
        Track();
    }

}
