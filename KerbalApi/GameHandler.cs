using KerbalApiServer;
using Thrift;
using System;

namespace KerbalApi
{
    using Api;

    [KerbalApi("GameService", typeof(GameService))]
    public class GameHandler : Handler, GameService.Iface
    {
        public Game getGame(string authString)
        {
            Authorize("getGame", authString);
            return HighLogic.CurrentGame.ToApi();
        }
    }
}

