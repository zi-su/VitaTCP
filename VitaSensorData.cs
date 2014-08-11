using UnityEngine;
using System.Collections;

public class VitaSensorData : MonoBehaviour {

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
	
	public class Data{
		public Vector3 gyro;
		public Vector3 acceleration;
		public int touches;
		public int backTouches;
		public Vector2 leftStick;
		public Vector2 rightStick;
		public bool[] buttons = new bool[12];
		public bool[] buttonTriggers = new bool[12];
		public Vector3 compass;
	};

	static public int DataSize = 72;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
