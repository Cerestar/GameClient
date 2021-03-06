using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour {
    
    //very important data sent infrequently
    private static void SendTCPData(Packet _packet) {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    //less important data sent frequently
    private static void SendUDPData(Packet _packet) {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeRecieved() {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived)) {
            _packet.Write(Client.instance.myId);
            _packet.Write(UIManager.instance.usernameField.text);

            SendTCPData(_packet);
        }
    }

    public static void PlayerMovement(bool[] _inputs) {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement)) {
            _packet.Write(_inputs.Length);
            foreach (bool _input in _inputs)
                _packet.Write(_input);

            SendUDPData(_packet);
        }
    }
    #endregion
}
