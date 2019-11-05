using UnityEngine;
using System.Collections;

// iTween用自作簡易3Dアニメーションツール
public class ObjMotionController : MonoBehaviour
{

    // NOTE: ほしい機能メモ
    // 移動、回転、拡縮 ※組み合わせも可能に
    // インターバル機能、一時ストップ機能
    // イージング / または機会的なうごきも
    // 移動方向、回転方向、拡大/縮
    // ディレイ／duration
    // ループ／ピンポン
    // isLocal
    // Updateで動かす、動かさない


    #region メンバー変数
    // イージングタイプ
    public enum EaseType
    {
        easeInQuad,
        easeOutQuad,
        easeInOutQuad,
        easeInCubic,
        easeOutCubic,
        easeInOutCubic,
        easeInQuart,
        easeOutQuart,
        tQuart,
        easeInQuint,
        easeOutQuint,
        easeInOutQuint,
        easeInSine,
        easeOutSine,
        easeInOutSine,
        easeInExpo,
        easeOutExpo,
        easeInOutExpo,
        easeInCirc,
        easeOutCirc,
        easeInOutCirc,
        linear,
        spring,
        easeInBounce,
        easeOutBounce,
        easeInOutBounce,
        easeInBack,
        easeOutBack,
        easeInOutBack,
        easeInElastic,
        easeOutElastic,
        easeInOutElastic
    }

    [SerializeField] EaseType easeType = EaseType.easeOutQuart;
    public enum LoopType
    {
        none,
        loop,
        pingpong
    }
    [SerializeField] LoopType loopType = LoopType.loop;



    [SerializeField] bool isUpdate = false;  //Updateメソッドで移動反映するか
    [SerializeField] float intervalTime = 0f; //isUpdate=true時に時間を指定すると一定時間ごとに停止、再生を繰り返す
    [SerializeField] float delay = 0f; //ディレイ時間
    [SerializeField] float duration = 0f; // アニメーション時間
    [SerializeField] Vector3 moveTo; // 移動先
    [SerializeField] Vector3 moveFrom; // 初期位置
    // [SerializeField] Vector3 rotatoTo; 

    [SerializeField] Vector3 rotateTo; // 初期位置
    [SerializeField] Vector3 rorateFrom;
    [SerializeField] Vector3 scaleTo;
    [SerializeField] Vector3 scaleFrom;
    [SerializeField] bool isLocal = false; // ローカル座標を使うか、グローバル座標を使うか

    // 各アニメーションタイプ
    [SerializeField] bool moveAction = false;
    [SerializeField] bool rorateAction = false;
    [SerializeField] bool scaleAction = false;

    [SerializeField] bool debugTrigger = false; // ON/OFFすることで初期化を走らせる


    // TODO:必要な分だけ配列増やす？
    Hashtable iTweenHashMove;
    Hashtable iTweenHashRotate;
    Hashtable iTweenHashScale;
    // Hashtable iTweenHashTemp;

    #endregion

    void DebugTrigger(){
        Init();
    }

    // Use this for initialization
    void Start()
    {
        Init();
    }
    
    void Init(){

        // TODO: isLocalをここでも適用させるか検討
        if (moveAction)
        {
            moveFrom = this.gameObject.transform.position; //初期位置保持
            HashUpdate(0);
        }
        if (rorateAction)
        {
            // rorateFrom = this.gameObject.transform.rotation.eulerAngles;
            rorateFrom = new Vector3(this.gameObject.transform.rotation.x,this.gameObject.transform.rotation.y,this.gameObject.transform.rotation.z);
            HashUpdate(1);
        }
        if (scaleAction)
        {
            scaleFrom = this.gameObject.transform.lossyScale;
            HashUpdate(2);
        }

        // 一度のトリガーでアニメーション開始する場合
        if (isUpdate)
        {
            // intervalTimeの指定があると、一定間隔で停止、再生を繰り返す
            if (intervalTime > 0f)
            {
                StartCoroutine(IntervalSwitch(intervalTime));
            }
        }
        else
        {
            StartCoroutine(AnimeStart(0f));
        }
    }

    // Hash値更新用
    void HashUpdate(int type = 0)
    {
        // 移動、回転、拡縮のアニメーション後の数値を変換
        Vector3 to = Vector3.zero;
        if(type == 0){ // moveAction用
            to = moveTo;
        }else if(type == 1){ // rorateAction
            to = rotateTo;
        }else if(type == 2){ //scaleAction
            to = scaleTo;
        }

        Hashtable iTweenHash = iTween.Hash(
                            "x", to.x,
                            "y", to.y,
                            "z", to.z,
                            "time", duration,
                            "delay", delay,
                            "easeType", easeType,
                            // "easeType", easeType,
                            "looptype", loopType,
                            // "oncomplete", "CompleteHandler",
                            // "oncompletetarget", this.gameObject,
                            "isLocal", isLocal
                            );

        if (type == 0)
        { // moveAction用
            iTweenHashMove = iTweenHash;
        }
        else if (type == 1)
        { // rorateAction
            iTweenHashRotate = iTweenHash;
        }
        else if (type == 2)
        { //scaleAction
            iTweenHashScale = iTweenHash;
        }

        // iTween
    }

    void CompleteHandler(){
        Debug.LogError("CompleteHandler");
        // pingpong用に

        if (moveAction)
        {
            moveTo = moveFrom; 
            moveFrom = this.gameObject.transform.position; // pingpong用に
            HashUpdate(0);
        }
        if (rorateAction)
        {

            // Quaternion.Euler qua = Quaternion.Euler(vec3);
            rotateTo = rorateFrom;
            // rotateTo = new Vector3(this.gameObject.transform.rotation.x,this.gameObject.transform.rotation.y,this.gameObject.transform.rotation.z);
            rorateFrom = this.gameObject.transform.rotation.eulerAngles; // pingpong用に
            HashUpdate(1);
        }
        if (scaleAction)
        {
            scaleTo = scaleFrom;
            scaleFrom = this.gameObject.transform.lossyScale; // pingpong用に
            HashUpdate(2);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(debugTrigger){
            DebugTrigger();
        }


        if (isUpdate)
        {
            if (moveAction)
            {
                MoveUpdate();
            }
            if (rorateAction)
            {
                RotateUpdate();
            }
            if (scaleAction)
            {
                ScaleUpdate();
            }
        }
    }

    private IEnumerator AnimeStart(float delayTime)
    {
        yield return null;
        // yield return new WaitForEndOfFrame(); // １フレーム待つ
        // yield return new WaitForSeconds(delayTime); // 指定時間待つ

        if (moveAction)
        {
            MoveStart();
        }
        if (rorateAction)
        {
            RotateStart();
        }
        if (scaleAction)
        {
            ScaleStart();
        }
    }


    #region 一度の呼び出しで動く系
    void MoveStart()
    {
        iTween.MoveTo(this.gameObject, iTweenHashMove);
    }

    void RotateStart()
    {
        iTween.RotateTo(this.gameObject, iTweenHashRotate);
    }

    void ScaleStart()
    {
        iTween.ScaleTo(this.gameObject, iTweenHashScale);
    }
    #endregion


    #region Updateメソッド更新する用

    void MoveUpdate()
    {
        iTween.MoveUpdate(this.gameObject, iTweenHashMove);
    }

    void RotateUpdate()
    {
        iTween.RotateUpdate(this.gameObject, iTweenHashRotate);

    }

    void ScaleUpdate()
    {
        iTween.ScaleUpdate(this.gameObject, iTweenHashScale);
    }
    #endregion

    // 一定時間ごとに止まる用
    private IEnumerator IntervalSwitch(float intervalTime)
    {
        // ループ
        while (true)
        {
            // 1秒毎にループします
            yield return new WaitForSeconds(intervalTime);
            // isUpdate = !isUpdate;

            CompleteHandler();

        }
    }

}

