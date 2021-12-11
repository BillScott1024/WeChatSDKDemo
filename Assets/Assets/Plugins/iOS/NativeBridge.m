//
//  NativeBridge.m
//  Unity-iPhone
//

#import <Foundation/Foundation.h>
#import "WXApi.h"

//这是向微信终端注册你的appid
void RegisterApp(const char* appid)
{
    NSString *weichatId = [NSString stringWithFormat:@"%s", appid];
    
    BOOL installed = [WXApi isWXAppInstalled];
    NSLog(@"installed result: %@", installed?@"true":@"false");

    BOOL result = [WXApi registerApp:weichatId universalLink:(@"https://www.mylittleenglish.com/app/hanzi/")];
    
    NSLog(@"result: %@", result?@"true":@"false");
}


// 分享链接至微信
void ShareUrlToWX(int scene, const char* url, const char* title, const char* description){
    WXWebpageObject *webpageObject = [WXWebpageObject object];
    webpageObject.webpageUrl = [NSString stringWithUTF8String:url];
    WXMediaMessage *message = [WXMediaMessage message];
    message.title = [NSString stringWithUTF8String:title];
    message.description = [NSString stringWithUTF8String:description];
    // 用APP的Icon做缩略图
    NSDictionary *infoPlist = [[NSBundle mainBundle] infoDictionary];
    NSString *icon = [[infoPlist valueForKeyPath:@"CFBundleIcons.CFBundlePrimaryIcon.CFBundleIconFiles"] lastObject];
    [message setThumbImage:[UIImage imageNamed:icon]];
    message.mediaObject = webpageObject;
    SendMessageToWXReq *req = [[SendMessageToWXReq alloc] init];
    req.bText = NO;
    req.message = message;
    req.scene = scene;
    [WXApi sendReq:req completion:nil];
}


//判断是否安装微信
bool IsWechatInstalled_iOS()
{
    return [WXApi isWXAppInstalled];
}


typedef void (*MyFuncType)();

void RegisterCallback(MyFuncType func)
{
    // TODO 
}
