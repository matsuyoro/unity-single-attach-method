using UnityEngine;
using System.Collections;

public class CustomSpriteAnimation : MonoBehaviour {

	// 実行中にitweenスクリプトがアタッチされるのでそれを参考にするとチューニングしやすい
	public string type;
    
    private bool isRun; // アニメーションがスタートしないことがあるので、動作チェック用
    
    void Awake(){
        
        // なぜかiTweenで、StartとAwakeで動くものと動かないものがある、複数やっているからか、それともsingletonで一元管理の必要あり？
        // とりあえず非同期なら全部動いた。
        StartCoroutine (AnimeStart());
    }
    
    // Use this for initialization
    void Start () {
        
        // AnimeStart();

        if(this.gameObject.GetComponent<SpriteRenderer>()){
            defaultColorR = this.gameObject.GetComponent<SpriteRenderer>().color.r;
            defaultColorG = this.gameObject.GetComponent<SpriteRenderer>().color.g;
            defaultColorB = this.gameObject.GetComponent<SpriteRenderer>().color.b;
        }

	}
    
    private IEnumerator AnimeStart ()
    {
		// １フレーム待つ
        yield return new WaitForEndOfFrame ();
        
        
        // void AnimeStart(){
        // Debug.Log("aime name" + this.gameObject.name);
        
        // iTween.Stop(gameObject);
        
        switch (type) {

            // エフェクト
            // 自機ボム発射時の矢印EF
            case "ef_arrow_bomb_dash":
            
           
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1,
                    "y",0.3, 
                    "time", 0.70f,
                    "easeType", iTween.EaseType.easeOutQuad,
                     "loopType", "pingPong"
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                    
                break;
             // 吾妻ボム_hosi
            case "ef_blackholl_uzu":
                
                
                
                // iTween.ScaleTo (this.gameObject, iTween.Hash (
                //     "x",1.0 ,
                //     "y",1.0 , 
                //     "time", 0.50f,
                //     "easeType", iTween.EaseType.easeInOutCirc
                //     // "oncomplete","returnScale",
                //     // "oncompletetarget", this.gameObject
                //     )
                //     );
                
                 iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", 1.0, 
                    "time", 1.0f,
                    "easeType",  iTween.EaseType.linear,
                    "loopType", "loop"
                    ));

            
                break;

            // 自機ボム発射時の矢印EF
            case "ef_arrow_fire":
            
           
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",0.3,
                    "y",1, 
                    "time", 1.70f,
                    "easeType", iTween.EaseType.easeOutQuad
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                    
                break;
            // アイテム取得時の光
            case "ef_circle_item_get":
            
           
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",0.1,
                    "y",0.1, 
                    "time", 0.30f,
                    "easeType", iTween.EaseType.easeOutBack
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                    
                break;
            // 最後一手エフェクト
            case "ef_circle_enemy_damage_end":
                
                // サイズをランダムに
                // float rand = 4 * Random.value;
                // float rand = 1.0f;
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",160.0f,
                    "y",160.0f, 
                    "time", 1.0f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            
                break;
            // 最後一手エフェクト ペンキ版
            case "ef_circle_enemy_damage_penki":
                
                // サイズをランダムに
                // float rand = 4 * Random.value;
                // float rand = 1.0f;
                float randScale = 12 * Random.value;

                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",10.0f + randScale,
                    "y",10.0f + randScale, 
                    "time", 0.1f * Random.value,
                    "easeType", iTween.EaseType.easeInExpo
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            
                break;


             // スター獲得エフェクト
             case "ef_circle_clear_rate_flash":
            
           
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1,
                    "y",1, 
                    "time", 0.7f,
                    // "delay", 4.8,
                    "easeType", iTween.EaseType.easeOutBack
                    // "oncomplete","endDestroy",
                    // "oncompletetarget", this.gameObject
                    )
                    );

                 // 値を 0.5 から 1.0 へ、1秒かけて変化させます。
                iTween.ValueTo(gameObject, iTween.Hash(
                    "from", 1f
                    , "to", 0f
                    , "time", 1f
                    , "onupdate", "SetAlpha"  // 毎フレーム SetAlpha() を呼びます。
                    ));
                    
                break;
             // 魂合体時の吸い込む光
             case "ef_circle_spirit_union":
            
           
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",0.1,
                    "y",0.1, 
                    "time", 0.50f,
                    "easeType", iTween.EaseType.easeOutBack
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                    
                break;
            // 魂合体時の吸い込む光
             case "ef_circle_spirit_bom_smalling_flash":
            
           
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",0.1,
                    "y",0.1, 
                    "time", 1.50f,
                    "easeType", iTween.EaseType.easeOutBack
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                    
                break;
             // ボム 4
             case "ef_circle_spirit_bom_yoko":
            
           
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0,
                    "y",0.1, 
                    "time", 0.50f,
                    "easeType", iTween.EaseType.easeInBounce,
                    "oncomplete","endDestroy",
                    "oncompletetarget", this.gameObject
                    )
                    );
                    
                break;
             
            
            // 墓回収時の光る円
            case "ef_circle_hit":
                
                // サイズをランダムに
                // float rand = 4 * Random.value;
                float rand = 1.0f;
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0 + rand,
                    "y",1.0 + rand, 
                    "time", 0.30f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            
                break;

            // ボム3のぶつぶつ
            case "ef_circle_spirit_bomb_inner_star3":
                
                
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.4 ,
                    "y",1.4 , 
                    "time", 0.50f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                
                 iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", -1.0, 
                    "time", 4.3f,
                    "easeType", iTween.EaseType.linear, 
                    "loopType", "pingPong"
                    ));

            
                break;

            // ボム3のにょろ
            case "ef_circle_spirit_bomb_inner_star2":
                
                
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.2 ,
                    "y",1.2 , 
                    "time", 0.50f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                
                 iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", 1.0, 
                    "time", 4.3f,
                    "easeType", iTween.EaseType.linear, 
                    "loopType", "pingPong"
                    ));

            
                break;
             // 吾妻ボム_hosi
            case "ef_circle_spirit_bomb_inner_star":
                
                
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0 ,
                    "y",1.0 , 
                    "time", 0.50f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                
                 iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", 1.0, 
                    "time", 4.3f,
                    "easeType", "easeInOut", 
                    "loopType", "pingPong"
                    ));

            
                break;
            // bomb2
            case "ef_circle_spirit_bomb2":
                
                
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0 ,
                    "y",1.0 , 
                    "time", 0.30f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            
                break;
        
            // ボム
            case "ef_circle_spirit_bomb":
                
                // サイズをランダムに
                // float rand = 4 * Random.value;
                // float rand = 1.0f;
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0f,
                    "y",1.0f, 
                    "time", 0.30f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            
                break;
             // spiritボムの本体サイズで当たり判定変わる注意
            case "ef_circle_spirit_bomb_collider_new":
                
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",2.0f,
                    "y",2.0f, 
                    "time", 3.0f,
                    "easeType", iTween.EaseType.easeInOutCirc,
                    "oncomplete","returnScale",
                    "oncompletetarget", this.gameObject
                    )
                    );
            
                break;
            case "ef_circle_spirit_bomb_collider_new_bomb4": //課金アイテムのボム4ヨウ
                
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",2.5f,
                    "y",2.5f, 
                    "time", 3.0f,
                    "easeType", iTween.EaseType.easeInOutCirc,
                    "oncomplete","returnScale",
                    "oncompletetarget", this.gameObject
                    )
                    );
            
                break;
             // ボムの本体サイズで当たり判定変わる注意
            case "ef_circle_spirit_bomb_collider":
                
                // サイズをランダムに
                // float rand = 4 * Random.value;
                // float rand = 1.0f;
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",2.0f,
                    "y",2.0f, 
                    "time", 3.30f,
                    "easeType", iTween.EaseType.easeInOutCirc,
                    "oncomplete","returnScale",
                    "oncompletetarget", this.gameObject
                    )
                    );
            
                break;
             // ブラックホールの本体サイズで当たり判定変わる注意
            case "ef_circle_spirit_holl_collider":
                
                // サイズをランダムに
                // float rand = 4 * Random.value;
                // float rand = 1.0f;
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",2.0f,
                    "y",2.0f, 
                    "time", 3.30f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            
                break;

            // ボム 外側に広がる光
            case "ef_circle_spirit_bomb3":
                
                // サイズをランダムに
                // float rand = 4 * Random.value;
                // float rand = 1.0f;
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",8.0f,
                    "y",8.0f, 
                    "time", 0.20f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                break;
            

            // 浮遊ボム
            case "ef_spirit_hover":
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0f,
                    "y",1.0f, 
                    "time", 0.20f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );

                // 値を 0.5 から 1.0 へ、1秒かけて変化させます。
                iTween.ValueTo(gameObject, iTween.Hash(
                    "from", 0.1f
                    , "to", 1f
                    , "time", 1f
                    , "onupdate", "SetAlpha"  // 毎フレーム SetAlpha() を呼びます。
                    ));

            break;
            /////////////
            // 自機ボム
            /////////////
            case "ef_bomb_all_circle_big":
               
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0f,
                    "y",1.0f, 
                    "time", 0.20f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );


            
                // 値を 0.5 から 1.0 へ、1秒かけて変化させます。
                iTween.ValueTo(gameObject, iTween.Hash(
                    "from", 0.1f
                    , "to", 1f
                    , "time", 1f
                    , "onupdate", "SetAlpha"  // 毎フレーム SetAlpha() を呼びます。
                    ));


            break;
            
            case "ef_bomb_all_circle_big2":
               
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0f,
                    "y",1.0f, 
                    "time", 2.20f,
                    "easeType", iTween.EaseType.easeInOutCirc
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            break;
            case "ef_bomb_all_circle_waku_rotate":
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0 ,
                    "y",1.0 , 
                    "time", 0.3f,
                    "easeType", "easeInOut"
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            

                iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", 4.0, 
                    "time", 2.3f,
                    "easeType", "easeInOut", 
                    "loopType", "pingPong"
                    ));

            break;    
            case "ef_bomb_all_circle_waku_rotate2":
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0 ,
                    "y",1.0 , 
                    "time", 0.3f,
                    "easeType", "easeInOut"
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            

                iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", 2.2, 
                    "time", 2.3f,
                    "easeType", "easeInOut", 
                    "loopType", "pingPong",
                    "delay",0.3
                    ));

            break;   
            case "ef_bomb_all_circle_waku_rotate3":
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",1.0 ,
                    "y",1.0 , 
                    "time", 0.3f,
                    "easeType", "easeInOut"
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            

                iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", 2.4, 
                    "time", 2.3f,
                    "easeType", "easeInOut", 
                    "loopType", "pingPong",
                    "delay",0.6
                    ));

            break;     
             
            // 魂の合体時の波紋
            case "ef_circle_ripple_spirit":
             
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",3.7,
                    "y",3.7, 
                    "time", 0.30f,
                    "easeType", iTween.EaseType.easeOutQuad
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
            
                break;
                    
            // 墓の周りの魂アイドル状態
            case "grave_spirit_idle":
                
                // サイズをランダムに
                // float rand = 4 * Random.value;
                float rand2 = 1.0f;
                
                iTween.MoveBy (this.gameObject, iTween.Hash (
                    // "x",1.0 + rand2,
                    "y",0.3, 
                    "time", 0.80f,
                    "easeType", iTween.EaseType.easeInOutCirc,
                    "loopType","pingPong"
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                break;
          
            // モヤのアニメーション１
            case "smog1":
                
                // サイズをランダムに
                // float rand = 4 * Random.value;
                
                
                iTween.MoveBy (this.gameObject, iTween.Hash (
                    "x",-30.0,
                    // "y",1.0, 
                    "time", 30.80f,
                    "easeType", iTween.EaseType.linear,
                    "loopType","pingPong"
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                    
                
                    
                break;
                
            case "smog2":
                iTween.MoveBy (this.gameObject, iTween.Hash (
                    "x",30.0,
                    // "y",1.0, 
                    "time", 30.80f,
                    "easeType", iTween.EaseType.linear,
                    "loopType","pingPong"
                    )
                    );
                    
                
                    
                break;
          
           // 塔攻撃時の光る星
           case "ef_star_hit":
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                    "x",0.3,
                    "y",0.3, 
                    "time", 0.30f,
                    "easeType", iTween.EaseType.easeOutBack
                    // "easeType", iTween.EaseType.easeInElastic
                    // "easeType", iTween.EaseType.easeInOutElastic
                    // "oncomplete","returnScale",
                    // "oncompletetarget", this.gameObject
                    )
                    );
                    
                iTween.RotateBy(gameObject, iTween.Hash(
                    "z", 1.0, "time", 0.3f,
                    "easeType", "easeInOut", 
                    "loopType", "pingPong"
                    ));
                    
                break;
            
            case "player_neji":
                 iTween.ScaleTo (this.gameObject, iTween.Hash (
                        "x", 0.5,
                        "y", -0.5,
                        "time", 1.25f, 
                        "easeType", iTween.EaseType.easeInOutCubic,
                        "loopType", "pingPong"
                        // "oncomplete","compStop",
                        // "oncompletetarget", this.gameObject
                        ));
                break;
                
            case "player_eye":
                
				iTween.ScaleTo(this.gameObject, iTween.Hash (
                    "y", .5, 
                    "time", 0.3f + (0.5f * Random.value),
                    // "easeType", "easeInOutBack",
                    "easeType", iTween.EaseType.easeOutQuint, 
                    "loopType", "pingPong", 
                    "delay", 1.5
                    ));
                    

				break;
                
            
            case "player_body_anime":
            
            
            
                // iTween.RotateBy(gameObject, iTween.Hash(
                //     "z", 1.0, "time", 0.3f,
                //     "easeType", "easeInOut", 
                //     "loopType", "pingPong"
                //     ));
                
                iTween.ScaleTo (this.gameObject, iTween.Hash (
                        "x", 2.2,
                        "y", 1.8, 
                        "time", 0.75f, 
                        "easeType", iTween.EaseType.easeInOutCubic,
                        "loopType", "pingPong"
                        // "oncomplete","compStop",
                        // "oncompletetarget", this.gameObject
                        ));
			
                break;
            
            
			
			
			case "player_head":
				iTween.RotateBy(this.gameObject, iTween.Hash (
                    "z", .05, 
                    // "easeType", "easeInOutBack",
                    "easeType", iTween.EaseType.easeInOutCubic, 
                    "loopType", "pingPong", 
                    "delay", .4
                    ));
                    

				break;
            

			case "player_leg":
                
                
                
                iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", -0.15,
                    "time", 0.3f,
                    "easeType", iTween.EaseType.easeInOutCubic,
                    "loopType", "pingPong"
                    // "delay", .4
                    ));
               
               iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", .15,
                    "time", 0.3f,
                    "easeType", iTween.EaseType.easeInOutCubic,
                    "loopType", "pingPong",
                    "delay", .5
                    ));
                
                    
				break;
            case "player_leg2":
                
                
                
                iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", .15,
                    "time", 0.3f,
                    "easeType", iTween.EaseType.easeInOutCubic,
                    "loopType", "pingPong",
                    "delay", .4
                    ));
                
                iTween.RotateBy(this.gameObject, iTween.Hash(
                    "z", -0.15,
                    "time", 0.3f,
                    "easeType", iTween.EaseType.easeInOutCubic,
                    "loopType", "pingPong",
                    "delay", .8
                    ));
                
                    
				break;
            case "back_grid_anime":
                iTween.ScaleTo(gameObject, iTween.Hash("x", 1.05,"y",1.05, "time", 1.2f,"loopType","pingPong"));
                // iTween.RotateBy(this.gameObject, iTween.Hash(
                //     "z", 1,
                //     "time", 2.4f,
                //     "easeType", iTween.EaseType.easeInOutCubic,
                //     "loopType", "pingPong",
                //     "delay", .4
                //     ));
            break;
			default :
				iTween.ScaleTo(gameObject, iTween.Hash("x", 1.2,"y",1.2, "time", 0.2f,"loopType","loop"));
				break;
                
		}
        
        if(this.gameObject.GetComponent<iTween>()){
            isRun = true;
        }else{
            isRun = false;
        }
            
        
    }

    // アニメーション終了後に削除するメソッド
    void endDestroy(){
		Destroy(this.gameObject);
	}


    void returnScale(){
		iTween.ScaleTo (this.gameObject, 
				iTween.Hash ("x",0.1,"y", 0.1, "time", 2.2f, "oncomplete","endDestroy","oncompletetarget", this.gameObject)); //拡
	}

    float defaultColorR;
    float defaultColorG;
    float defaultColorB;
	void SetAlpha(float value)
    {
        // 受け取った値を、スプライトのアルファ値として代入します。
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(defaultColorR,defaultColorG,defaultColorB,value);
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
