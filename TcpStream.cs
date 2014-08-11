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
	public Rect connectIPRect;

	byte[] bytes;
	public string vitaIP;
	public int port;
	VitaSensorData.Data data = new VitaSensorData.Data();
	public VitaSensorData.Data DATA{
		get{return data;}
	}

	private IPAddress[] ipAddress;
	// Use this for initialization
	void Start () {
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
					byte[] bufftouches = new byte[sizeof(Int32)];
					byte[] bufferaccel = new byte[sizeof(float) * 3];
					byte[] buffLeftStick = new byte[sizeof(float) * 2];
					byte[] buffRightStick = new byte[sizeof(float) * 2];
					byte[] buffButtons = new byte[sizeof(bool) * (int)VitaSensorData.BUTTON.MAX_BUTTON];
					byte[] buffBackTouch = new byte[sizeof(Int32)];
					byte[] buffGyro = new byte[sizeof(float) * 3];
					byte[] buffAll = new byte[VitaSensorData.DataSize];
					ns.Read(buffAll, 0, VitaSensorData.DataSize);
					data.touches = BitConverter.ToInt32(buffAll, 0);
					data.acceleration = new Vector3(BitConverter.ToSingle(buffAll, 4), BitConverter.ToSingle(buffAll, 8), BitConverter.ToSingle(buffAll, 12));
					data.leftStick = new Vector2(BitConverter.ToSingle(buffAll, 16), BitConverter.ToSingle(buffAll, 20));
					data.rightStick =  new Vector2(BitConverter.ToSingle(buffAll, 24), BitConverter.ToSingle(buffAll, 28));
					data.backTouches = BitConverter.ToInt32(buffAll, 32);
					data.gyro = new Vector3(BitConverter.ToSingle(buffAll, 36),BitConverter.ToSingle(buffAll, 40),BitConverter.ToSingle(buffAll, 44));
					for(int i = 0 ; i < data.buttons.Length ; i++){
						data.buttons[i] = BitConverter.ToBoolean(buffAll, 48+i);
					}
					for(int i = 0 ; i < data.buttonTriggers.Length ; i++){
						data.buttonTriggers[i] = BitConverter.ToBoolean(buffAll, 60+i);
					}
					//ns.WriteByte(0x01);
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
			//ns.WriteByte(0x01);
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

		for (VitaSensorData.BUTTON b = VitaSensorData.BUTTON.RIGHT_DOWN; b != VitaSensorData.BUTTON.MAX_BUTTON; b += 1) {
			int i = (int)b;
			connectResult += b.ToString() + "Trigger:" + data.buttonTriggers[i].ToString() + "\n";
		}
		foreach (IPAddress ip in ipAddress) {
			connectResult += ip.ToString() + "\n";
		}
		GUI.TextArea(connectStateRect, connectResult);
		vitaIP = GUI.TextArea (connectIPRect, vitaIP);
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
