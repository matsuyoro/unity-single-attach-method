 IEnumerator loadWeb(string url)
        {

            var webViewObject = transform.GetComponentInChildren<WebViewObject>();
            webViewObject.Init(
                cb: msg => { },     // jsコールバック用
                transparent: false,
                ua: "",             // ユーザーエージェント等指定があれば
                err: msg => { },
                ld: msg => { },
                enableWKWebView: true
            );

            // このUISpriteの上にWebviewを表示したい
            // このSpriteのサイズを使ってサイズを計算する
            var background = transform.Find("MailView/Sprite").GetComponent<UISprite>();

            // "backgroun(Sprite))"を写すカメラ
            var camera = GameObject.Find("/Map UI Root/Camera").GetComponent<Camera>();
           
            var worldLB = background.worldCorners[0];
            var worldRT = background.worldCorners[2];

            // "Background"の左下と右上のスクリーン座標
            var screenLB = camera.WorldToScreenPoint(worldLB);
            var screenRT = camera.WorldToScreenPoint(worldRT);

            // マージンの計算
            int marginL = (int)(screenLB.x);
            int marginT = (int)(Screen.height - screenRT.y);
            int marginR = (int)(Screen.width - screenRT.x);
            int marginB = (int)(screenLB.y);

            // PC用のフラグ（GETクエリで、サイト側の画面拡縮を計算。）
            string pcFlgStr ="";
            if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
            {
                pcFlgStr = "&pf=1";
            }

            // UnityEditor上（PC）でも、画面拡縮をwebviewサイズに合わせるため、GETクエリで、サイト側にサイズを投げる
            float scaleW = screenRT.x - screenLB.x;
            float scaleH = screenRT.y - screenLB.y;

            webViewObject.LoadURL(url + "?" + Random.value.ToString() + "&w=" + scaleW + "&h=" + scaleH + pcFlgStr);
            webViewObject.SetMargins(marginL, marginT, marginR, marginB);
            webViewObject.SetVisibility(true);


            yield break;
        }

