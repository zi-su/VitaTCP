﻿using UnityEngine;
using UnityEngine.PSM;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System;
using System.Threading;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class Sensor : MonoBehaviour {
	VitaSensorData.Data data = new VitaSensorData.Data();
	public GameObject touch;
	public GameObject gyro;
	public GameObject dataText;
	public GameObject guiText;
	public Rect listenButton;
	public Rect listenStopButton;
	public Rect textRect;
	public RenderTexture renderTex;
	public int port;
	public string iptext;
	IPAddress[] address;
	TcpListener listen;
	TcpClient client = null;
	NetworkStream ns;
	Thread thread;

	private TouchScreenKeyboard keyboard;
	int buffAllSize;


	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
		string hostname = Dns.GetHostName ();

		address = Dns.GetHostAddresses (hostname);
		foreach (IPAddress ip in address) {
			dataText.GetComponent<GUIText>().text += ("\n" + ip.ToString() + "\n");
			iptext = ip.ToString();
		}
	}

	
	// Update is called once per frame
	void Update () {
		TCPRoutine();
	}

	void TCPRoutine(){
		data.gyroEuler = Input.gyro.attitude.eulerAngles;
		data.acceleration = Input.gyro.userAcceleration;
		data.touches = Input.touches.Length;
		data.leftStick[0] = Input.GetAxis ("Horizontal");
		data.leftStick[1] = Input.GetAxis ("Vertical");
		data.rightStick[0] = Input.GetAxis ("RightHorizontal");
		data.rightStick[1] = Input.GetAxis ("RightVertical");
		data.backTouches = PSMInput.touchesSecondary.Length;
		data.compass = Input.compass.rawVector;
		data.buttons [(int)VitaSensorData.BUTTON.RIGHT_DOWN] = Input.GetKey (KeyCode.JoystickButton0);
		data.buttons [(int)VitaSensorData.BUTTON.RIGHT_RIGHT] = Input.GetKey (KeyCode.JoystickButton1);
		data.buttons [(int)VitaSensorData.BUTTON.RIGHT_LEFT] = Input.GetKey (KeyCode.JoystickButton2);
		data.buttons [(int)VitaSensorData.BUTTON.RIGHT_UP] = Input.GetKey (KeyCode.JoystickButton3);
		data.buttons [(int)VitaSensorData.BUTTON.LEFT_SHOULDER] = Input.GetKey (KeyCode.JoystickButton4);
		data.buttons [(int)VitaSensorData.BUTTON.RIGHT_SHOULDER] = Input.GetKey (KeyCode.JoystickButton5);
		data.buttons [(int)VitaSensorData.BUTTON.CENTER_LEFT] = Input.GetKey (KeyCode.JoystickButton6);
		data.buttons [(int)VitaSensorData.BUTTON.CENTER_RIGHT] = Input.GetKey (KeyCode.JoystickButton7);
		data.buttons [(int)VitaSensorData.BUTTON.LEFT_UP] = Input.GetKey (KeyCode.JoystickButton8);
		data.buttons [(int)VitaSensorData.BUTTON.LEFT_RIGHT] = Input.GetKey (KeyCode.JoystickButton9);
		data.buttons [(int)VitaSensorData.BUTTON.LEFT_DOWN] = Input.GetKey (KeyCode.JoystickButton10);
		data.buttons [(int)VitaSensorData.BUTTON.LEFT_LEFT] = Input.GetKey (KeyCode.JoystickButton11);

		for (int i = 0; i < (int)VitaSensorData.BUTTON.MAX_BUTTON; i++) {
			data.buttonTriggers[i] = Input.GetKeyDown(KeyCode.JoystickButton0+i);
		}

		if (client != null && client.Connected && ns != null && client.Available != 0)
        {
			ns.ReadByte();
			Debug.Log ("ClientAvailable:"+ client.Available + "\n");
			Vector3 qe = data.gyroEuler;

            ns.Write(BitConverter.GetBytes(data.touches), 0, sizeof(Int32));
            ns.Write(BitConverter.GetBytes(data.acceleration.x), 0, sizeof(float));
            ns.Write(BitConverter.GetBytes(data.acceleration.y), 0, sizeof(float));
            ns.Write(BitConverter.GetBytes(data.acceleration.z), 0, sizeof(float));
            ns.Write (BitConverter.GetBytes(data.leftStick.x), 0, sizeof(float));
			ns.Write (BitConverter.GetBytes(data.leftStick.y), 0, sizeof(float));
			ns.Write (BitConverter.GetBytes(data.rightStick.x), 0, sizeof(float));
			ns.Write (BitConverter.GetBytes(data.rightStick.y), 0, sizeof(float));
			ns.Write(BitConverter.GetBytes(data.backTouches),0, sizeof(Int32));

			ns.Write (BitConverter.GetBytes(qe.x),0, sizeof(float));
			ns.Write (BitConverter.GetBytes(qe.y),0, sizeof(float));
			ns.Write (BitConverter.GetBytes(qe.z),0, sizeof(float));
			foreach(bool b in data.buttons){
				ns.Write (BitConverter.GetBytes(b), 0, sizeof(bool));
			}
			foreach(bool b in data.buttonTriggers){
				ns.Write (BitConverter.GetBytes(b), 0, sizeof(bool));
			}
		}
	}
	void OnGUI(){
		if (GUI.Button (listenButton, "ListenStart")) {
			listen = new TcpListener (IPAddress.Parse(iptext), 1234);
			listen.Start ();
			listen.BeginAcceptTcpClient(new AsyncCallback(acceptCallback), listen);
		}
		if (GUI.Button (listenStopButton, "ListenStop")) {
			CloseTCP();
		}
		if (GUI.Button (textRect, "Input IpAddress")) {
			keyboard = TouchScreenKeyboard.Open(iptext);
		}
		if (keyboard != null) {
			iptext = keyboard.text;
		}
	}

    void acceptCallback(IAsyncResult result)
    {
        client = listen.EndAcceptTcpClient(result);
        ns = client.GetStream();
    }

	void CloseTCP(){
		ns.Close ();
		client.Close ();
		listen.Stop ();
	}
}
