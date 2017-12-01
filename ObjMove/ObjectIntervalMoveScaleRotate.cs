using UnityEngine;
using System.Collections;



/// <summary>
/// インスペクタ上で、一定間隔で移動、回転、拡縮を、GameObjectにattacheすることで簡単にできるスクリプト 
/// </summary>

public class ObjLRController : MonoBehaviour
{

  public float rotateSpeed = 1.0f;
  public bool rotateFlg = false;
  public bool rotate2Flg = false;

  public float moveSpeed = 1.0f;
  public bool moveFlg = false;
  public bool zMoveFlg = false;

  public float scaleSpeed = 0.1f;
  public bool scaleFlg = false;

  public bool vertically = true; //縦か横か
  public float intervalTime = 2.0f;


  public int switchType = 0;  //スイッチオブジェクトと連携して動作する用
  private bool startFlg = false;  //このオブジェクトの動作をはじめてよいかどうか
  private int gameStatus = 0;


  // Use this for initialization
  void Start()
  {


  }


  // Update is called once per frame
  void Update()
  {


    // スイッチのチェック
    if (switchType == 0)
    {

      // 回転モード
      if (rotateFlg)
      {
        if (vertically)
        {
          transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        }
        else
        {
          transform.Rotate(new Vector3(rotateSpeed * Time.deltaTime, 0, 0));
        }
      }

      // 回転モード
      if (rotate2Flg)
      {
        transform.Rotate(new Vector3(0,rotateSpeed * Time.deltaTime ,0));
      }

      // 移動モード
      if (moveFlg)
      {

        if (vertically)
        {

          transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);   //移動量をTime.deltaTimeで一定に

        }
        else
        {

          transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        }
      }
      if(move2Flg)
      {
        if (vertically)
        {

          transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);   //移動量をTime.deltaTimeで一定に

        }
        else
        {

          transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        }
      }

      // 拡縮モード
      if (scaleFlg)
      {


        float scaleVal = scaleSpeed * Time.deltaTime;
        transform.localScale += new Vector3(scaleVal, scaleVal, scaleVal);


      }


      if (startFlg == false)
      {
        StartCoroutine("Blink");
      }

    }


  }

  // 反転
  void Return()
  {

    rotateSpeed = -rotateSpeed;
    moveSpeed = -moveSpeed;
    scaleSpeed = -scaleSpeed;


  }

  // ループコルーチン
  IEnumerator Blink()
  {
    startFlg = true;    //稼働中
    while (true)
    {
      yield return new WaitForSeconds(intervalTime);

      Return();
    }
  }

}

