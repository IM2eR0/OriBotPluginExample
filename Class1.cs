using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System.Runtime.CompilerServices;

namespace TestPlugin
{
    public class PluginLoadEnter : CqPostPlugin
    {
        //插件的入口，主程序需要从此处载入插件，你可以在这里添加插件信息
        //请确保 _s.UsePlugin(this); 存在
        public void Load(CqWsSession _s)
        {
            _s.UsePlugin(this);
        }

        // 复读机
        public override async Task OnGroupMessageAsync(CqGroupMessagePostContext context)
        {
            if (context.Session is not ICqActionSession actionSession)
                return;

            if(context.RawMessage.StartsWith(".say "))
            {
                string msg = context.RawMessage.Substring(5);
                context.SendGroupMessageAsync(context.GroupId, new CqTextMsg(msg));
            }
        }
    }
}