//
//  MyAppController.m
//  Unity-iPhone
//

#import "WXApi.h"
#import "UnityAppController.h"

@interface MyAppController : UnityAppController<WXApiDelegate>
@end
// 优先调用 自定义子类
IMPL_APP_CONTROLLER_SUBCLASS (MyAppController)

@implementation MyAppController

- (BOOL)application:(UIApplication *)application continueUserActivity:(NSUserActivity *)userActivity
#if defined(__IPHONE_12_0) || defined(__TVOS_12_0)
    restorationHandler:(void (^)(NSArray<id<UIUserActivityRestoring> > * _Nullable restorableObjects))restorationHandler
#else
    restorationHandler:(void (^)(NSArray * _Nullable))restorationHandler
#endif
{
    return [WXApi handleOpenUniversalLink:userActivity delegate:self];
}

- (BOOL)application:(UIApplication*)application openURL:(NSURL*)url sourceApplication:(NSString*)sourceApplication annotation:(id)annotation
{
    return [WXApi handleOpenURL:url delegate:self];
}

- (BOOL)application:(UIApplication *)application handleOpenURL:(NSURL *)url
{
    return [WXApi handleOpenURL:url delegate:self];
}

- (void)onResp:(BaseResp *)resp
{
    // do something
}

- (void)onReq:(BaseReq *)req
{
    // do something
}

@end

