using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;
public class TcpStream : MonoBehaviour {
	
	public Rect textRect;
	private bool isShowGUI = true;
	
	TcpClient client;
	NetworkStream ns;
	AudioClip clip;
	IPAddress address;
	Thread thread;
	
	public Rect connectButtonRect;
	public Rect connectStateRect;
	byte[] bytes;
	public string vitaIP;
	public int port;
	VitaSensorData.Data data;
	public VitaSensorData.Data DATA{
		get{return data;}
	}

	private IPAddress[] ipAddress;
	// Use this for initialization
	void Start () {
		data.buttons = new bool[(int)VitaSensorData.BUTTON.MAX_BUTTON];
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
				while(ns.DataAvailable) {
					byte[] bufftouches = new byte[sizeof(Int32)];
					byte[] bufferaccel = new byte[sizeof(float) * 3];
					byte[] buffLeftStick = new byte[sizeof(float) * 2];
					byte[] buffRightStick = new byte[sizeof(float) * 2];
					byte[] buffButtons = new byte[sizeof(bool) * (int)VitaSensorData.BUTTON.MAX_BUTTON];
					int result = ns.Read (bufftouches, 0, sizeof(Int32));
					int result2 = ns.Read (bufferaccel, 0, sizeof(float) * 3);
					int result3 = ns.Read (buffLeftStick, 0, sizeof(float) * 2);
					int result4 = ns.Read (buffRightStick, 0, sizeof(float) * 2);
					int result5 = ns.Read (buffButtons, 0, sizeof(bool) * (int)VitaSensorData.BUTTON.MAX_BUTTON);
					int touches = BitConverter.ToInt32 (bufftouches, 0);
					data.touches = touches;
					data.acceleration = new Vector3 (BitConverter.ToSingle (bufferaccel, 0), BitConverter.ToSingle (bufferaccel, sizeof(float)), BitConverter.ToSingle (bufferaccel, sizeof(float) * 2));
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
					Debug.Log ("touches:" + touches + " accel:" + data.acceleration);
				}
			}
		}
	}
	private void Connect(){
		address = IPAddress.Parse (vitaIP);
		client = new TcpClient ();
		client.BeginConnect (address, port, new AsyncCallback(connectCallback), client);
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
		string connectResult = "not connect";
		if (client != null && client.Connected) {
			connectResult = "connected";
		}
		
		connectResult += "\ntouches:" + data.touches.ToString ();
		connectResult += "\naccel:" + data.acceleration.x.ToString () + ":" + data.acceleration.y.ToString () + ":" + data.acceleration.z.ToString ();
		connectResult += "\nLStick:" + data.leftStick.x.ToString () + ":" + data.leftStick.y.ToString ();
		connectResult += "\nRStick:" + data.rightStick.x.ToString () + ":" + data.rightStick.y.ToString () + "\n";
		for (VitaSensorData.BUTTON b = VitaSensorData.BUTTON.RIGHT_DOWN; b != VitaSensorData.BUTTON.MAX_BUTTON; b += 1) {
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
