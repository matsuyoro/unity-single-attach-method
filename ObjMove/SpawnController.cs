using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 生成処理を外付けコントロール可能に
public class SpawnController : MonoBehaviour {

	
	[SerializeField] private GameObject[] actors;

	private int spawnCount = 0;
    [SerializeField] private float intervalTime = 3f;

    // Use this for initialization
    void Start()
    {
        if (actors.Length > 0)
        {
            StartCoroutine(LoopCheck(intervalTime));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }


    // 出現
    void Spawn()
    {
        // Quaternion.Euler(90, 30, 10);
        // var instantObj = Instantiate(actor, this.gameObject.transform.position, Quaternion.identity);

        
        // if(actors[] == null){
        //     return;
        // }

        int boxIndex = spawnCount % actors.Length; //actorの種類を、ループ

        if (actors[boxIndex] != null)
        {
            // var instantObj = Instantiate(actors[1],this.gameObject.transform.position, Quaternion.Euler(-10f, -90f, 0));
            // var instantObj = Instantiate(actors[0], new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z), Quaternion.Euler(-10f,-90f,0));
            // var instantObj = Instantiate(actors[boxIndex], this.gameObject.transform);
            var instantObj = Instantiate(actors[boxIndex], this.gameObject.transform.position,Quaternion.Euler(0f,0f,0f));
            instantObj.transform.parent = this.gameObject.transform.parent;
        }




        // // アイテムを載せた飛行機
        // if(spawnCount % 3 == 0){
        //     //うるさいので３回に１回
        //     // Sound.PlaySe("se_airplane");

            
            
        //     // instantObj.transform.localScale = Vector3.zero;
        //     // MoveToは、既に移動が制御されているせいか、きかない。。？
        //     // iTween.MoveAdd(instantObj, iTween.Hash("y", -2, "time", 2.0f, "delay", 1.0f));
        //     // iTween.MoveTo(instantObj, iTween.Hash("x", -100f, "y", 5f, "time", 10f, "isLocal", true));
        //     // Destroy(instantObj, 10f);

        // }else{

        //     if (actors[0] == null)
        //     {
        //         // var instantObj = Instantiate(actors[0], new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z), Quaternion.Euler(-10f,-90f,0));
        //         var instantObj = Instantiate(actors[1], this.gameObject.transform);
        //         instantObj.transform.parent = this.gameObject.transform.parent;
        //         // instantObj.transform.localScale = Vector3.zero;
        //     }

        //     // MoveToは、既に移動が制御されているせいか、きかない。。？
        //     // iTween.MoveAdd(instantObj, iTween.Hash("y", -2, "time", 2.0f, "delay", 1.0f));


        //     // iTween.MoveTo(instantObj, iTween.Hash("x", -100f, "y", 5f, "time", 10f, "isLocal", true));

        //     // Destroy(instantObj, 10f);

        // }
        
        // // 出現時あにめ
        // iTween.ScaleTo(instantObj, iTween.Hash(
        // 	"x", 1.4,
        // 	"y", 1.4,
        // 	"z", 1.4,
        // 	"time", 2.0f,
        // 	// "delay", 1.0f,
        // 	"easeType", iTween.EaseType.linear
        // 	));





    }

    //　ゲームの状況を定期的にチェックするメソッド
    IEnumerator LoopCheck(float intervalTime = 1f)
    {

        //　カウント用のローカル変数
        // int count = 0;

        //　コルーチンがオンの時は1秒待ってデータ出力しカウントを進める
        while (true)
        {
            //　最初に現在のカウントを表示
            Debug.Log(spawnCount);

            Spawn();

            //　カウントアップ
            spawnCount++;

            //　1秒待つ
            yield return new WaitForSeconds(intervalTime);
            //　次のフレームに飛ばす
            yield return null;
        }
    }
}

