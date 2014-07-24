using UnityEngine;
using UnityEngine.PSM;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System;
using System.Threading;
public class Sensor : MonoBehaviour {
	VitaSensorData.Data data;
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



	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
		data.buttons = new bool[(int)VitaSensorData.BUTTON.MAX_BUTTON];
		string hostname = Dns.GetHostName ();
		address = Dns.GetHostAddresses (hostname);
		foreach (IPAddress ip in address) {
			dataText.GetComponent<GUIText>().text += ("\n" + ip.ToString() + "\n");
		}
	}

	void acceptCallback(IAsyncResult result){
		client = listen.EndAcceptTcpClient (result);
		ns = client.GetStream ();
	}
	// Update is called once per frame
	void Update () {
		TCPRoutine();
	}

	void TCPRoutine(){
		data.gyroAttitude = Input.gyro.attitude;
		data.acceleration = Input.gyro.userAcceleration;
		data.touches = Input.touches.Length;
		data.leftStick.x = Input.GetAxis ("Horizontal");
		data.leftStick.y = Input.GetAxis ("Vertical");
		data.rightStick.x = Input.GetAxis ("RightStickHorizontal");
		data.rightStick.y = Input.GetAxis ("RightStickVertical");
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
		if (client != null && client.Connected && ns != null && ns.DataAvailable == false) {
			//ns.Write(BitConverter.GetBytes(data.gyroAttitude.x), 0, sizeof(float));
			//ns.Write(BitConverter.GetBytes(data.gyroAttitude.y), 0, sizeof(float));
			//ns.Write(BitConverter.GetBytes(data.gyroAttitude.z), 0, sizeof(float));
			//ns.Write(BitConverter.GetBytes(data.gyroAttitude.w), 0, sizeof(float));
			//
			//
			//
			//ns.Write(BitConverter.GetBytes(data.compass.x),0, sizeof(float));
			//ns.Write(BitConverter.GetBytes(data.compass.y),0, sizeof(float));
			//ns.Write(BitConverter.GetBytes(data.compass.z),0, sizeof(float));
            ns.Write(BitConverter.GetBytes(data.touches), 0, sizeof(Int32));
            ns.Write(BitConverter.GetBytes(data.acceleration.x), 0, sizeof(float));
            ns.Write(BitConverter.GetBytes(data.acceleration.y), 0, sizeof(float));
            ns.Write(BitConverter.GetBytes(data.acceleration.z), 0, sizeof(float));
            ns.Write (BitConverter.GetBytes(data.leftStick.x), 0, sizeof(float));
			ns.Write (BitConverter.GetBytes(data.leftStick.y), 0, sizeof(float));
			ns.Write (BitConverter.GetBytes(data.rightStick.x), 0, sizeof(float));
			ns.Write (BitConverter.GetBytes(data.rightStick.y), 0, sizeof(float));
			
			//ns.Write(BitConverter.GetBytes(data.backTouches), 0, sizeof(Int32));
			foreach(bool b in data.buttons){
				ns.Write (BitConverter.GetBytes(b), 0, sizeof(bool));
			}
			ns.Flush();
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

	void CloseTCP(){
		ns.Close ();
		client.Close ();
		listen.Stop ();
	}
}
