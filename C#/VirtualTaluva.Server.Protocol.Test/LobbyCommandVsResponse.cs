using System.Linq;
using VirtualTaluva.Protocol;
using VirtualTaluva.Protocol.Lobby;
using VirtualTaluva.Protocol.Lobby.RegisteredMode;
using VirtualTaluva.Protocol.Lobby.QuickMode;
using VirtualTaluva.Server.Protocol.Test.Mocking;
using VirtualTaluva.Protocol.Tests.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VirtualTaluva.Server.Protocol.Test
{
    [TestClass]
    public class LobbyCommandVsResponse
    {
        private void CheckIfResponseIs<T>(AbstractCommand c) where T : AbstractCommand
        {
            var server = new ServerMock();
            server.Send(c);
            server.LobbyCommands.CompleteAdding();
            var received = server.ServerSendedCommands.GetConsumingEnumerable().First();
            Assert.AreEqual(typeof(T), received.Command.GetType());
        }
        [TestMethod]
        public void AuthenticateUserCommand()
        {
            CheckIfResponseIs<AuthenticateUserResponse>(LobbyCommandMock.AuthenticateUserCommand());
        }
        [TestMethod]
        public void CheckDisplayExistCommand()
        {
            CheckIfResponseIs<CheckDisplayExistResponse>(LobbyCommandMock.CheckDisplayExistCommand());
        }
        [TestMethod]
        public void CheckUserExistCommand()
        {
            CheckIfResponseIs<CheckUserExistResponse>(LobbyCommandMock.CheckUserExistCommand());
        }
        [TestMethod]
        public void CreateTableCommand()
        {
            CheckIfResponseIs<CreateTableResponse>(LobbyCommandMock.CreateTableCommand());
        }
        [TestMethod]
        public void CreateUserCommand()
        {
            CheckIfResponseIs<CreateUserResponse>(LobbyCommandMock.CreateUserCommand());
        }
        [TestMethod]
        public void GetUserCommand()
        {
            CheckIfResponseIs<GetUserResponse>(LobbyCommandMock.GetUserCommand());
        }
        [TestMethod]
        public void IdentifyCommand()
        {
            CheckIfResponseIs<IdentifyResponse>(LobbyCommandMock.IdentifyCommand());
        }
        [TestMethod]
        public void JoinTableCommand()
        {
            CheckIfResponseIs<JoinTableResponse>(LobbyCommandMock.JoinTableCommand());
        }
        [TestMethod]
        public void ListTableCommand()
        {
            CheckIfResponseIs<ListTableResponse>(LobbyCommandMock.ListTableCommand());
        }
        [TestMethod]
        public void CheckCompatibilityCommand()
        {
            CheckIfResponseIs<CheckCompatibilityResponse>(LobbyCommandMock.CheckCompatibilityCommand());
        }
    }
}
