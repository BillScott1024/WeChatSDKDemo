using System.Runtime.InteropServices;
public class WeChatController
{
	private string _APP_ID = "";

    #region iOS微信SDK
#if !UNITY_EDITOR && UNITY_IOS
    [DllImport("__Internal")]
    private static extern void RegisterApp(string appid);

    [DllImport("__Internal")]
    private static extern bool IsWechatInstalled_iOS();

    [DllImport("__Internal")]
    private static extern void ShareUrlToWX(int scene, string url, string title, string description);
#endif
    #endregion

	private static WeChatController _instance;
	public static WeChatController Instance {
		get {
			if (_instance == null) {
				_instance = new WeChatController();
			}
			return _instance;
		}
	}

	/// <summary>
	/// 初始化微信SDK， APPID是用户在微信开放平台注册是所分配的应用唯一标识， 可在微信开放平台找到
	/// </summary>
	/// <param name="APPID"></param>
	public void Init(string APPID) {
		_APP_ID = APPID;
#if !UNITY_EDITOR && UNITY_IOS
        RegisterApp(_APP_ID);
#endif
	}

	/// <summary>
	/// 判断是否是否安装了微信
	/// </summary>
	/// <returns></returns>
	public bool IsWeChatAppInstalled() {
#if !UNITY_EDITOR && UNITY_IOS
        return IsWechatInstalled_iOS();
#endif
		return false;
	}

	/// <summary>
	/// 分享链接至微信，缩略图用的是APP Icon
	/// </summary>
	/// <param name="scene">分享至什么场景, 0-对话、1-朋友圈、2-收藏</param>
	/// <param name="url">网页链接</param>
	/// <param name="title">标题</param>
	/// <param name="description">描述</param>
	public void ShareWebpageToWX(int scene, string url, string title, string description) {
#if !UNITY_EDITOR && UNITY_IOS
        ShareUrlToWX(scene, url, title, description);
#endif
	}
	/// <summary>
	/// TODO
	/// </summary>
	delegate void MyFuncType();
	[AOT.MonoPInvokeCallback(typeof(MyFuncType))]
	static void MyFunction()
	{
		// TODO
	}
	static extern void RegisterCallback(MyFuncType func);
	
	
}  

