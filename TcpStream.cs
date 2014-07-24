<<<<<<< HEAD
﻿using UnityEngine;
using UnityEngine.PSM;
=======
using UnityEngine;
>>>>>>> FETCH_HEAD
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System;
using System.Threading;
<<<<<<< HEAD
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
	
	private bool isWrite = false;
	
	private TouchScreenKeyboard keyboard;
	
	
	
	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
		data.buttons = new bool[(int)VitaSensorData.BUTTON.MAX_BUTTON];
		string hostname = Dns.GetHostName ();
		address = Dns.GetHostAddresses (hostname);
		gyro.GetComponent<GUIText>().text = address[0].ToString();
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
		gyro.GetComponent<GUIText>().text = Input.gyro.userAcceleration.ToString();
		touch.GetComponent<GUIText> ().text = Input.touches.Length.ToString ();
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
		Debug.Log (data.compass + "backToches " + data.backTouches);
		if (client != null && client.Connected && ns != null && ns.DataAvailable == false) {
			ns.Write (BitConverter.GetBytes(data.touches), 0, sizeof(Int32));
			ns.Write (BitConverter.GetBytes(data.acceleration.x), 0, sizeof(float));
			ns.Write (BitConverter.GetBytes(data.acceleration.y), 0, sizeof(float));
			ns.Write (BitConverter.GetBytes(data.acceleration.z), 0, sizeof(float));
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
	}
	
	void CloseTCP(){
		ns.Close ();
		client.Close ();
		listen.Stop ();
	}
=======
public class TcpStream : MonoBehaviour
{

    public struct SensorData
    {
        public Vector3 accelation;
        public int touches;
        public Vector2 leftStick;
        public Vector2 rightStick;
        public bool[] buttons;
    };

    public enum BUTTON
    {
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
    public Rect connectButtonRect;
    public Rect connectStateRect;
    public int port;
    public string vitaIP;

    private bool isShowGUI = true;

    TcpClient client;
    NetworkStream ns;
    AudioClip clip;

    IPAddress address;
    Thread thread;

    private SensorData data;
    public SensorData DATA
    {
        get { return data; }
    }
    private IPAddress[] ipAddress;
    // Use this for initialization
    void Start()
    {
        data.buttons = new bool[(int)BUTTON.MAX_BUTTON];
        string hostName = Dns.GetHostName();
        ipAddress = Dns.GetHostAddresses(hostName);
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine ("ReadVitaSensor");
        if (Input.GetKeyDown(KeyCode.V))
        {
            isShowGUI = !isShowGUI;
        }
    }

    void ReadVitaSensor()
    {
        //float time = Time.time;
        while (true)
        {
            if (ns != null)
            {
                if (ns.CanRead)
                {
                    while (ns.DataAvailable)
                    {
                        byte[] bufftouches = new byte[sizeof(Int32)];
                        byte[] bufferaccel = new byte[sizeof(float) * 3];
                        byte[] buffLeftStick = new byte[sizeof(float) * 2];
                        byte[] buffRightStick = new byte[sizeof(float) * 2];
                        byte[] buffButtons = new byte[sizeof(bool) * (int)BUTTON.MAX_BUTTON];
                        int result = ns.Read(bufftouches, 0, sizeof(Int32));
                        int result2 = ns.Read(bufferaccel, 0, sizeof(float) * 3);
                        int result3 = ns.Read(buffLeftStick, 0, sizeof(float) * 2);
                        int result4 = ns.Read(buffRightStick, 0, sizeof(float) * 2);
                        int result5 = ns.Read(buffButtons, 0, sizeof(bool) * (int)BUTTON.MAX_BUTTON);
                        int touches = BitConverter.ToInt32(bufftouches, 0);
                        data.touches = touches;
                        data.accelation = new Vector3(BitConverter.ToSingle(bufferaccel, 0), BitConverter.ToSingle(bufferaccel, sizeof(float)), BitConverter.ToSingle(bufferaccel, sizeof(float) * 2));
                        data.leftStick = new Vector2(BitConverter.ToSingle(buffLeftStick, 0), BitConverter.ToSingle(buffLeftStick, sizeof(float)));
                        data.rightStick = new Vector2(BitConverter.ToSingle(buffRightStick, 0), BitConverter.ToSingle(buffRightStick, sizeof(float)));
                        for (int i = 0; i < data.buttons.Length; i++)
                        {
                            data.buttons[i] = BitConverter.ToBoolean(buffButtons, sizeof(bool) * i);
                        }
                    }
                    /*
                    Debug.Log ("result:" + result);
                    Debug.Log ("result2:" + result2);
                    Debug.Log ("result3:" + result3);
                    Debug.Log ("result4:" + result4);
                    Debug.Log ("result5:" + result5);
                    Debug.Log ("touches:" + touches + " accel:" + data.accelation);
                    */
                }
            }
        }
    }
    private void Connect()
    {
        Debug.Log("ConnectStart");

        address = IPAddress.Parse(vitaIP);
        client = new TcpClient();
        client.BeginConnect(address, port, new AsyncCallback(connectCallback), client);
    }

    void connectCallback(IAsyncResult result)
    {
        ns = client.GetStream();
        client.EndConnect(result);
        Debug.Log("Connected");
        if (thread == null)
        {
            thread = new Thread(ReadVitaSensor);
            thread.Start();
        }
    }


    void OnGUI()
    {
        if (!isShowGUI)
        {
            return;
        }
        if (GUI.Button(connectButtonRect, "Connect"))
        {
            Connect();
        }
        vitaIP = GUI.TextField(textRect, vitaIP);

        string connectResult = "not connect";
        if (client != null && client.Connected)
        {
            connectResult = "connected";
        }
        foreach (IPAddress ip in ipAddress)
        {
            connectResult += ip.ToString() + "\n";
        }
        connectResult += "\ntouches:" + data.touches.ToString();
        connectResult += "\naccel:" + data.accelation.x.ToString() + ":" + data.accelation.y.ToString() + ":" + data.accelation.z.ToString();
        connectResult += "\nLStick:" + data.leftStick.x.ToString() + ":" + data.leftStick.y.ToString();
        connectResult += "\nRStick:" + data.rightStick.x.ToString() + ":" + data.rightStick.y.ToString() + "\n";
        for (BUTTON b = BUTTON.RIGHT_DOWN; b != BUTTON.MAX_BUTTON; b += 1)
        {
            int i = (int)b;
            connectResult += b.ToString() + ":" + data.buttons[i].ToString() + "\n";
        }

        GUI.TextArea(connectStateRect, connectResult);
    }

    void OnApplicationQuit()
    {
        if (client != null)
        {
            client.Close();
        }
        if (thread != null)
        {
            thread.Abort();
        }
    }
    void OnDestroy()
    {
    }
>>>>>>> FETCH_HEAD
}