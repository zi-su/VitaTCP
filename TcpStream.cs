﻿using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;
public class TcpStream : MonoBehaviour {

	public enum BUTTON{
		RIGHT_DOWN,
		RIGHT_RIGHT,
		RIGHT_LEFT,
		RIGHT_UP,
		LEFT_SHOULDER,
		RIGHT_SHOULDER,
		CENTER_RIGHT,
		CENTER_LEFT,
		LEFT_UP,
		LEFT_DOWN,
		LEFT_LEFT,
		LEFT_RIGHT,
		MAX_BUTTON,
	};

	public Rect textRect;
	private string textFieldString;
	public struct SensorData{
		public Vector3 accelation;
		public int touches;
		public Vector2 leftStick;
		public Vector2 rightStick;
		public bool[] buttons;
	};

	private bool isShowGUI = true;
	SensorData data;
	TcpClient client;
	NetworkStream ns;
	AudioClip clip;
	int position = 0;
	float frequency = 440;
	int sampleRate = 0;
	IPAddress address;
	Thread thread;

	public Rect connectButtonRect;
	public Rect connectStateRect;
	byte[] bytes;
	public string vitaIP;
	public SensorData DATA{
		get{ return data;}
	}
	private IPAddress[] ipAddress;
	// Use this for initialization
	void Start () {
		data.buttons = new bool[(int)BUTTON.MAX_BUTTON];


		textRect.width = 200;
		textRect.height = 50;
		textRect.x = 500;
		textRect.y = 0;
		textFieldString = "";
		string hostName = Dns.GetHostName ();
		ipAddress = Dns.GetHostAddresses (hostName);
	}
	
	// Update is called once per frame
	void Update () {
		//StartCoroutine ("ReadVitaSensor");
		if (Input.GetKeyDown (KeyCode.V)) {
			isShowGUI = !isShowGUI;
		}
	}

	void ReadVitaSensor(){
		//float time = Time.time;
		while (true) {
			if (ns != null) {
				Debug.Log ("DataAvaiable" + ns.DataAvailable);
				Debug.Log ("Avaiable:" + client.Available);
				if (ns.CanRead && ns.DataAvailable) {
					byte[] bufftouches = new byte[sizeof(Int32)];
					byte[] bufferaccel = new byte[sizeof(float) * 3];
					byte[] buffLeftStick = new byte[sizeof(float) * 2];
					byte[] buffRightStick = new byte[sizeof(float) * 2];
					byte[] buffButtons = new byte[sizeof(bool) * (int)BUTTON.MAX_BUTTON];
					int result = ns.Read (bufftouches, 0, sizeof(Int32));
					int result2 = ns.Read (bufferaccel, 0, sizeof(float) * 3);
					int result3 = ns.Read (buffLeftStick, 0, sizeof(float) * 2);
					int result4 = ns.Read (buffRightStick, 0, sizeof(float) * 2);
					int result5 = ns.Read (buffButtons, 0, sizeof(bool) * (int)BUTTON.MAX_BUTTON);
					int touches = BitConverter.ToInt32 (bufftouches, 0);
					data.touches = touches;
					data.accelation = new Vector3 (BitConverter.ToSingle (bufferaccel, 0), BitConverter.ToSingle (bufferaccel, sizeof(float)), BitConverter.ToSingle (bufferaccel, sizeof(float) * 2));
					data.leftStick = new Vector2(BitConverter.ToSingle(buffLeftStick, 0), BitConverter.ToSingle(buffLeftStick, sizeof(float)));
					data.rightStick = new Vector2(BitConverter.ToSingle(buffRightStick, 0), BitConverter.ToSingle(buffRightStick, sizeof(float)));
					for(int i = 0 ; i < data.buttons.Length ; i++){
						data.buttons[i] = BitConverter.ToBoolean(buffButtons, sizeof(bool) * i);
					}
					Debug.Log ("result:" + result);
					Debug.Log ("result2:" + result2);
					Debug.Log ("result3:" + result3);
					Debug.Log ("result4:" + result4);
					Debug.Log ("result5:" + result5);
					Debug.Log ("touches:" + touches + " accel:" + data.accelation);
					ns.WriteByte(0x01);
				}
			}
		}
	}
	private void Connect(){
		Debug.Log ("aaa");
		address = IPAddress.Parse (textFieldString);
		client = new TcpClient ();
		client.BeginConnect (address, 1234, new AsyncCallback(connectCallback), client);

	}

	void connectCallback(IAsyncResult result){
		ns = client.GetStream ();
		client.EndConnect (result);
		Debug.Log ("Connected");
		if (thread == null) {
			thread = new Thread (ReadVitaSensor);
			thread.Start ();
		}
	}


	void OnGUI(){
		if (!isShowGUI) {
			return;
		}
		if (GUI.Button (connectButtonRect, "Connect")) {
			Connect ();
		}
		textFieldString = GUI.TextField (textRect, textFieldString);

		string connectResult = "not connect";
		if (client != null && client.Connected) {
			connectResult = "connected";
		}

		connectResult += "\ntouches:" + data.touches.ToString ();
		connectResult += "\naccel:" + data.accelation.x.ToString () + ":" + data.accelation.y.ToString () + ":" + data.accelation.z.ToString ();
		connectResult += "\nLStick:" + data.leftStick.x.ToString () + ":" + data.leftStick.y.ToString ();
		connectResult += "\nRStick:" + data.rightStick.x.ToString () + ":" + data.rightStick.y.ToString () + "\n";
		for (BUTTON b = BUTTON.RIGHT_DOWN; b != BUTTON.MAX_BUTTON; b += 1) {
			int i = (int)b;
			connectResult += b.ToString() + ":" + data.buttons[i].ToString() + "\n";
		}
		foreach (IPAddress ip in ipAddress) {
			connectResult += ip.ToString() + "\n";
		}
		GUI.TextArea(connectStateRect, connectResult);
	}

	void OnApplicationQuit(){
		if (client != null) {
			client.Close ();
		}
		if (thread != null) {
			thread.Abort ();
		}
	}
	void OnDestroy(){
	}
}