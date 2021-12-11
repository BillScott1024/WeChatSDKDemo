using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class InitManager : MonoBehaviour
{

     public Button btnWechatLogin;
     public Button btnWechatShareToChat;
     public Button btnWechatShareToMoment;
     public Button btnWechatShareToCollect;
     public Button btnClearLog;

     public Text textLog;
     private string logString;
     private string shareImagePath = "https://static01.imgkr.com/temp/2c9262ca665a419191a48cb21820447b.jpg";
     private string appId = "wxf4984b88ce91177d";
     public void Start()
     {
          logString += "Game Start!!!\n";
          Debug.LogWarning("Game Start!!!");
          Debug.LogWarning("WeChatController Init");
          logString += "WeChatController Init\n";
          WeChatController.Instance.Init(appId);
          Debug.LogWarning("WeChatController Init End");
          logString += "WeChatController Init End\n";
          bool isWeChatAppInstalled = WeChatController.Instance.IsWeChatAppInstalled();
          Debug.LogWarning("isWechatAppInstalled"+ isWeChatAppInstalled.ToString());
          logString += "isWechatAppInstalled: "+ isWeChatAppInstalled.ToString() + "\n";
          SetLogText(logString);

          // StartCoroutine(TestFunction());
          Addlistener();
          // GC.Collect();
     }

     private IEnumerator TestFunction()
     {
          Debug.LogWarning("StartCoroutine");
          yield return StartCoroutine(LogTime());
          Debug.LogWarning("StartCoroutine End");

     }

     private IEnumerator LogTime()
     {
          Debug.LogWarning("LogTime Start");
          for (int i = 0; i < 5; i++)
          {
               Debug.LogWarning("LogTime 1");
               Debug.LogWarning(UnityEngine.Time.time); 
               yield return new WaitForSeconds(1); 
               Debug.LogWarning("LogTime 2");
          }
          Debug.LogWarning("LogTime End");
          
     }

     private void Addlistener()
     {
          btnWechatLogin.onClick.AddListener(OnBtnLoginClick);
          btnWechatShareToChat.onClick.AddListener(OnBtnShareToChatClick);
          btnWechatShareToMoment.onClick.AddListener(OnBtnShareToMomentClick);
          btnWechatShareToCollect.onClick.AddListener(OnBtnShareToCollectClick);
          btnClearLog.onClick.AddListener(OnBtnClearLogClick);

     }

     private void RemoveListener()
     {
          btnWechatLogin.onClick.RemoveListener(OnBtnLoginClick);
          btnWechatShareToChat.onClick.RemoveListener(OnBtnShareToChatClick);
          btnWechatShareToMoment.onClick.RemoveListener(OnBtnShareToMomentClick);
          btnWechatShareToCollect.onClick.RemoveListener(OnBtnShareToCollectClick);
          btnClearLog.onClick.RemoveListener(OnBtnClearLogClick);
     }

     private void OnBtnClearLogClick()
     {
          logString = "";
          SetLogText("");
     }

     private void OnBtnLoginClick()
     {
          Debug.LogWarning("OnBtnLoginClick \n");
          logString += "OnBtnLoginClick 登录 \n";
          SetLogText(logString);
     }

     private void OnBtnShareToChatClick()
     {
          Debug.LogWarning("OnBtnShareToWeChatClick \n");
          logString += "OnBtnShareToWeChatClick 分享到聊天 \n";
          SetLogText(logString);
          WeChatShareAPI(0);
     }

     private void OnBtnShareToMomentClick()
     {
          Debug.LogWarning("OnBtnShareToWeChatClick \n");
          logString += "OnBtnShareToWeChatClick 分享到朋友圈 \n";
          SetLogText(logString);
          WeChatShareAPI(1);
     }
     private void OnBtnShareToCollectClick()
     {
          Debug.LogWarning("OnBtnShareToWeChatClick \n");
          logString += "OnBtnShareToWeChatClick 分享到收藏 \n";
          SetLogText(logString);
          WeChatShareAPI(2);

     }
     private void WeChatShareAPI(int scene)
     {
          WeChatController.Instance.ShareWebpageToWX(scene,shareImagePath,"坦克无敌真好玩!", "分享文案");

     }
     


     private void SetLogText(string logString)
     {
          textLog.text = logString;
     }


     public void OnDestroy()
     {
          logString = "";
          RemoveListener();
     }
}