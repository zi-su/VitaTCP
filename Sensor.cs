using UnityEngine;
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
	byte[] buffAll;

	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
		string hostname = Dns.GetHostName ();
		buffAll = new byte[VitaSensorData.DataSize];
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
		data.gyro = new Vector3 (Input.gyro.attitude.x, Input.gyro.attitude.y,Input.gyro.attitude.z);
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

		if (client != null && client.Connected && ns != null)
        {
			//ns.ReadByte();
			Debug.Log ("ClientAvailable:"+ client.Available + "\n");
			Vector3 qe = data.gyro;
			byte[] d1 = BitConverter.GetBytes(data.touches);
			Array.Copy(d1, 0, buffAll, 0, d1.Length);
            //ns.Write(BitConverter.GetBytes(data.touches), 0, sizeof(Int32));
            //ns.Write(BitConverter.GetBytes(data.acceleration.x), 0, sizeof(float));
			byte[] d2 = BitConverter.GetBytes(data.acceleration.x);
			Array.Copy(d2, 0, buffAll, 4, d2.Length);
            //ns.Write(BitConverter.GetBytes(data.acceleration.y), 0, sizeof(float));
			byte[] d3 = BitConverter.GetBytes(data.acceleration.y);
			Array.Copy(d3, 0, buffAll, 8, d3.Length);
			//ns.Write(BitConverter.GetBytes(data.acceleration.z), 0, sizeof(float));
			byte[] d4 = BitConverter.GetBytes(data.acceleration.z);
			Array.Copy(d4, 0, buffAll, 12, d4.Length);
            //ns.Write (BitConverter.GetBytes(data.leftStick.x), 0, sizeof(float));
			byte[] d5 = BitConverter.GetBytes(data.leftStick.x);
			Array.Copy(d5, 0, buffAll, 16, d5.Length);
			//ns.Write (BitConverter.GetBytes(data.leftStick.y), 0, sizeof(float));
			byte[] d6 = BitConverter.GetBytes(data.leftStick.y);
			Array.Copy(d6, 0, buffAll, 20, d6.Length);
			//ns.Write (BitConverter.GetBytes(data.rightStick.x), 0, sizeof(float));
			byte[] d7 = BitConverter.GetBytes(data.rightStick.x);
			Array.Copy(d7, 0, buffAll, 24, d7.Length);
			//ns.Write (BitConverter.GetBytes(data.rightStick.y), 0, sizeof(float));
			byte[] d8 = BitConverter.GetBytes(data.rightStick.y);
			Array.Copy(d8, 0, buffAll, 28, d8.Length);
			//ns.Write(BitConverter.GetBytes(data.backTouches),0, sizeof(Int32));
			byte[] d9 = BitConverter.GetBytes(data.backTouches);
			Array.Copy(d9, 0, buffAll, 32, d9.Length);
			//ns.Write (BitConverter.GetBytes(qe.x),0, sizeof(float));
			byte[] d10 = BitConverter.GetBytes(qe.x);
			Array.Copy(d10, 0, buffAll, 36, d10.Length);
			//ns.Write (BitConverter.GetBytes(qe.y),0, sizeof(float));
			byte[] d11 = BitConverter.GetBytes(qe.y);
			Array.Copy(d11, 0, buffAll, 40, d11.Length);
			//ns.Write (BitConverter.GetBytes(qe.z),0, sizeof(float));
			byte[] d12 = BitConverter.GetBytes(qe.z);
			Array.Copy(d12, 0, buffAll, 44, d12.Length);
			for(int i = 0 ; i < data.buttons.Length ; i++){
				byte[] d13 = BitConverter.GetBytes(data.buttons[i]);
				Array.Copy(d13, 0, buffAll, 48+i, d13.Length);
			}
			for(int i = 0 ; i < data.buttonTriggers.Length ; i++){
				byte[] d14 = BitConverter.GetBytes(data.buttonTriggers[i]);
				Array.Copy(d14, 0, buffAll, 60+i, d14.Length);
			}
			for(int i = 0 ; i < buffAll.Length ; i++){
				Debug.Log (buffAll[i]);
			}
			ns.Write(buffAll, 0, buffAll.Length);
		}

	}
	void OnGUI(){
		if (GUI.Button (listenButton, "ListenStart")) {
			listen = new TcpListener (IPAddress.Parse(iptext), port);
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
