using UnityEngine;
using System.Collections;



/// <summary>
/// よくある加算していくテキストアニメーション。
/// </summary>

public class textAnimation : MonoBehaviour {

  private UILabel label; // 同じgameObjectにNGUIのUILabelが１つ存在する必要がある
  //  private int textAnimationFrame = 40; 
  private float textAnimationFrame;

  private string defaultString;
  private float defaultFloat = 0.0f; //アニメーション後の数字
  private float diffFloat = 0.0f; //アニメーション後と前の差分
  private float initFloat = 0.0f; //アニメーション前の数字
  //  private int defaultInt = 0;

  public float delayTime = 0.0f;

  public string initString  = "0";	// 初期表示時のstring

  public int numType = 0;	// 0 = float 、1=int



  // Use this for initialization
  void Start () {

    label = GetComponent ("UILabel") as UILabel;

    defaultString = label.text;

    //  // intを扱う場合
    //  if(numType == 1){
    //  	//  defaultInt = int.Parse(label.text);
    //  	defaultFloat = float.Parse(label.text);
    //  	defaultFloat = defaultFloat - float.Parse(initString); //差分を出す
    //  }else{ // float を扱う場合
    //  	defaultFloat = float.Parse(label.text);
    //  	defaultFloat = defaultFloat - float.Parse(initString); //差分を出す
    //  }

    defaultFloat = float.Parse(label.text); 
    initFloat = float.Parse(initString);
    diffFloat = defaultFloat - initFloat; //差分を出す


    textAnimationFrame = 0.0f; //アニメーションフレーム TODO 実質1.0fになるようにしないとアニメーションの計算があわない

    label.text = initString;	//最初は0表示



  }

  // Update is called once per frame
  void Update () {


    if(delayTime < 0.0f){

      textAnimationFrame += Time.deltaTime;

      if(textAnimationFrame > 1.0f){

        textAnimationFrame = 1.0f;
        label.text = defaultString;

      }else{

        //  label.text = (textAnimationFrame).ToString();
        //  int value = (int)defaultFloat / textAnimationFrame;

        // intを扱う場合
        if(numType == 1){
          //  label.text = (defaultInt / (int)textAnimationFrame).ToString("f0");
          // label.text = (initFloat + (diffFloat * (textAnimationFrame / 2.0f))).ToString("f0");
          label.text = (initFloat + (diffFloat * (textAnimationFrame))).ToString("f0");

        }else{ // float を扱う場合

          // label.text = (initFloat + (diffFloat * (textAnimationFrame / 2.0f))).ToString("f1");
          label.text = (initFloat + (diffFloat * (textAnimationFrame))).ToString("f1");
        }

      }
    }else{
      delayTime -= Time.deltaTime;
    }
  }

}
