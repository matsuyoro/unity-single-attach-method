using UnityEngine;
using System.Collections;


/// <summary>
/// iTweenアセットを使った、2D向けアニメーションを色々ぶっこみ、雑な引数で色々分岐するスクリプト。
/// </summary>

public class Obj2dAnimation : MonoBehaviour {

  private float initPosX,initPosY; 
  public float duration = 1.0f; //アニメーション時間
  public float speed = 1.0f;
  public int type = 0;

  // Use this for initialization
  void Start () {

    if(type >= 6){
      // 拡縮用
      initPosX = transform.localScale.x;
      initPosY = transform.localScale.y;
    }else{
      initPosX = transform.position.x;
      initPosY = transform.position.y;
    }


  }

  // Update is called once per frame
  void Update () {
    // transform.position = new Vector3(transform.position.x,initPosY + Mathf.PingPong(Time.time,0.5f), transform.position.z);
    if(type == 0){ //上下
      transform.position = new Vector2(transform.position.x,initPosY + Mathf.PingPong(Time.time * speed,duration));
    }else if(type == 1){ //左右
      transform.position = new Vector2(initPosX + Mathf.PingPong(Time.time * speed,duration),transform.position.y);
    }else if(type == 2){ //回転
      transform.Rotate(0, 0, speed * Time.deltaTime);
    }else if(type == 3){
      // InvokeRepeating("delayAnimation", 2, 0.3f);
    }else if(type == 4){
      transform.position = new Vector2(transform.position.x,initPosY - Mathf.PingPong(Time.time * speed,duration));
    }else if(type == 5){
      transform.position = new Vector2(initPosX - Mathf.PingPong(Time.time * speed,duration),transform.position.y);
    }else if (type == 6){
      transform.localScale = new Vector2(initPosX,initPosY + Mathf.PingPong(Time.time * speed,duration));
    }else if (type == 7){
      transform.localScale = new Vector2(initPosX + Mathf.PingPong(Time.time * speed,duration) ,initPosY );
    }
  }

  void delayAnimation(){
    transform.position = new Vector2(transform.position.x,initPosY + Mathf.PingPong(Time.time * speed,duration));
  }

  // 	指定位置から、ターゲット位置までを指定スピードで移動。
  // Mathf.MoveTowards ( current_pos, target_pos, speed * Time.deltaTime );

  // 指定角度から、ターゲット角度までを指定スピードで回転。
  // Mathf.MoveTowardsAngle ( current_ang, target_ang, speed * Time.deltaTime );

  // 0から指定の値までを折り返す。
  // Mathf.PingPong ( now_Val, 10 );

  // 0から指定の値までを繰り返す。
  // Mathf.Repeat ( now_Val, 10 );
}
