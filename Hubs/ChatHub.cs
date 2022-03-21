using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRWebPack.Hubs
{
    public class ChatHub : Hub
    {
        //서버가 메시지를 수신한 후 수신된 메시지를 모든 연결된 사용자에게 브로드캐스트 합니다.
        //모든 메시지를 수신하기 위해 일반 on메소드를 포함할 필요는 없습니다.
        public async Task NewMessage(long username, string message)
        {
            await Clients.All.SendAsync("messageReceived", username, message);
            //messageReceived 이벤트는 index.js파일에서 사용한다.
        }
    }
}