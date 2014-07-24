using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System;
using System.Threading;
public class Sensor : MonoBehaviour {

	enum BUTTON{
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

	struct SensorData{
		public Vector3 accelation;
		public int touches;
		public Vector2 leftStick;
		public Vector2 rightStick;
		public bool[] buttons;
	};

	SensorData data;
	public GameObject touch;
	public GameObject gyro;
	public GameObject dataText;
	public GameObject guiText;
	IPAddress[] address;
	TcpListener listen;
	TcpClient client = null;
	NetworkStream ns;
	Thread thread;
	public Rect listenButton;
	public Rect listenStopButton;
	private bool isWrite = false;

	private TouchScreenKeyboard keyboard;
	public Rect textRect;
	private string iptext;
	public RenderTexture renderTex;
	// Use this for initialization
	void Start () {
		data.buttons = new bool[(int)BUTTON.MAX_BUTTON];
		string hostname = Dns.GetHostName ();
		address = Dns.GetHostAddresses (hostname);
		gyro.GetComponent<GUIText>().text = address[0].ToString();
		foreach (IPAddress ip in address) {
			dataText.GetComponent<GUIText>().text += ip.ToString() + "\n";
		}
		iptext = "";
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
			gyro.GetComponent<GUIText>().text = Input.gyro.userAcceleration.ToString();
			touch.GetComponent<GUIText> ().text = Input.touches.Length.ToString ();
			data.accelation = Input.gyro.userAcceleration;
			data.touches = Input.touches.Length;
			data.leftStick.x = Input.GetAxis ("Horizontal");
			data.leftStick.y = Input.GetAxis ("Vertical");
			data.rightStick.x = Input.GetAxis ("RightStickHorizontal");
			data.rightStick.y = Input.GetAxis ("RightStickVertical");
			data.buttons [(int)BUTTON.RIGHT_DOWN] = Input.GetKey (KeyCode.JoystickButton0);
			data.buttons [(int)BUTTON.RIGHT_RIGHT] = Input.GetKey (KeyCode.JoystickButton1);
			data.buttons [(int)BUTTON.RIGHT_LEFT] = Input.GetKey (KeyCode.JoystickButton2);
			data.buttons [(int)BUTTON.RIGHT_UP] = Input.GetKey (KeyCode.JoystickButton3);
			data.buttons [(int)BUTTON.LEFT_SHOULDER] = Input.GetKey (KeyCode.JoystickButton4);
			data.buttons [(int)BUTTON.RIGHT_SHOULDER] = Input.GetKey (KeyCode.JoystickButton5);
			data.buttons [(int)BUTTON.CENTER_LEFT] = Input.GetKey (KeyCode.JoystickButton6);
			data.buttons [(int)BUTTON.CENTER_RIGHT] = Input.GetKey (KeyCode.JoystickButton7);
			data.buttons [(int)BUTTON.LEFT_UP] = Input.GetKey (KeyCode.JoystickButton8);
			data.buttons [(int)BUTTON.LEFT_RIGHT] = Input.GetKey (KeyCode.JoystickButton9);
			data.buttons [(int)BUTTON.LEFT_DOWN] = Input.GetKey (KeyCode.JoystickButton10);
			data.buttons [(int)BUTTON.LEFT_LEFT] = Input.GetKey (KeyCode.JoystickButton11);
			
			guiText.GetComponent<GUIText> ().text = ns.DataAvailable.ToString ();
			if (client != null && client.Connected && ns.DataAvailable == true) {
				ns.ReadByte();
				ns.Write (BitConverter.GetBytes(data.touches), 0, sizeof(Int32));
				ns.Write (BitConverter.GetBytes(data.accelation.x), 0, sizeof(float));
				ns.Write (BitConverter.GetBytes(data.accelation.y), 0, sizeof(float));
				ns.Write (BitConverter.GetBytes(data.accelation.z), 0, sizeof(float));
				ns.Write (BitConverter.GetBytes(data.leftStick.x), 0, sizeof(float));
				ns.Write (BitConverter.GetBytes(data.leftStick.y), 0, sizeof(float));
				ns.Write (BitConverter.GetBytes(data.rightStick.x), 0, sizeof(float));
				ns.Write (BitConverter.GetBytes(data.rightStick.y), 0, sizeof(float));
				foreach(bool b in data.buttons){
					ns.Write (BitConverter.GetBytes(b), 0, sizeof(bool));
				}
				ns.Flush();
				dataText.GetComponent<GUIText> ().text = ns.DataAvailable.ToString();
				isWrite = true;
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
		//}
	}

	void CloseTCP(){
		ns.Close ();
		client.Close ();
		listen.Stop ();
	}
}
