using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using TMPro;
using UnityEngine.UI;

namespace Week2
{
    public class WebsocketConnection : MonoBehaviour
    {
        private WebSocket websocket;

        [SerializeField] TMP_Text textChat;
        string  IpInput,PortInput, messageFromData;
        GameObject search;
        InputField chat;
        [SerializeField] InputField Port, Ip;
        bool check = false;

        



        // Start is called before the first frame update
        void Start()
        {
            search = GameObject.Find("Chatbox");

        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (check == true) 
            {
                textChat.GetComponent<TMP_Text>().text += messageFromData + "\n";

                check = false;
            }

        }

        public void OnDestroy()
        {
            if(websocket != null)
            {
                websocket.Close();
            }
        }

        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Debug.Log("Message from server: " + messageEventArgs.Data);
            messageFromData = messageEventArgs.Data;

            check = true;


        }

        public void BottonCon()
        {

            chat = search.GetComponent<InputField>();
            websocket.Send(chat.text);

            
            chat.text = ("");

        }

        


        public void ServerConnect()
        {
            Port.GetComponent<InputField>();
            PortInput = Port.text;
            Ip.GetComponent<InputField>();
            IpInput = Ip.text;


            //server 127.0.0.1:25500
            websocket = new WebSocket("ws://"+ IpInput + ":" + PortInput + "/");           
            websocket.Connect();
            websocket.OnMessage += OnMessage;

        }

        

        

    }
}


