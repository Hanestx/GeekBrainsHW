using UnityEngine;
using Asteroids;

public class AsteroidSpawner : MonoBehaviour {

	public Transform UL;
	public Transform UR;
	public Transform DL;
	public Transform DR;
	public Rigidbody2D[] asteroid;
	public int rockSpeed = 300;
	public float timeout = 5f;
	private float curTimeout;
	private Vector2 startPoint;
	private Vector2 direction;
	private Vector2 Up;
	private Vector2 Down;
	private Vector2 Left;
	private Vector2 Right;

	void Start () 
	{
		curTimeout = timeout;
	}

	void Update () 
	{
		curTimeout += Time.deltaTime;
		if(curTimeout > timeout)
		{
			curTimeout = 0;
			switch(Random.Range(0, 4))
			{
			case 0:
				Up = AsteroidPositionH(UL.position, UR.position, true);
				Down = AsteroidPositionH(DL.position, DR.position, false);
				direction = Down - Up;
				startPoint = Up;
				break;
			case 1:
				Up = AsteroidPositionH(UL.position, UR.position, false);
				Down = AsteroidPositionH(DL.position, DR.position, true);
				direction = Up - Down;
				startPoint = Down;
				break;
			case 2:
				Left = AsteroidPositionV(UL.position, DL.position, true);
				Right = AsteroidPositionV(UR.position, DR.position, false);
				direction = Right - Left;
				startPoint = Left;
				break;
			case 3:
				Left = AsteroidPositionV(UL.position, DL.position, false);
				Right = AsteroidPositionV(UR.position, DR.position, true);
				direction = Left - Right;
				startPoint = Right;
				break;
			}

			Rigidbody2D rockInstance = Instantiate(asteroid[Random.Range(0, asteroid.Length)], startPoint, Quaternion.identity) as Rigidbody2D;	
			rockInstance.AddForce(direction.normalized * rockSpeed);
			rockInstance.AddTorque(rockSpeed);
			rockInstance.GetComponent<Asteroid>()._asteroids = asteroid;
		}
	}

	Vector2 AsteroidPositionV(Vector2 a, Vector2 b, bool isLeft)
	{
		Vector2 result = Vector2.zero;
		int i = Random.Range(-1, 2);
		if(i == 0) i = -1;
		if(isLeft)
		{
			result = new Vector2(a.x, (Vector2.Distance(a, b)/Random.Range(2.3f, 7.5f)) * i);
		}
		else
		{
			result = new Vector2(b.x, (Vector2.Distance(a, b)/Random.Range(2.3f, 7.5f)) * i);
		}
		return result;
	}

	Vector2 AsteroidPositionH(Vector2 a, Vector2 b, bool isUp)
	{
		Vector2 result = Vector2.zero;
		int i = Random.Range(-1, 2);
		if(i == 0) i = -1;
		if(isUp)
		{
			result = new Vector2((Vector2.Distance(a, b)/Random.Range(2.3f, 7.5f)) * i, a.y);
		}
		else
		{
			result = new Vector2((Vector2.Distance(a, b)/Random.Range(2.3f, 7.5f)) * i, b.y);
		}
		return result;
	}
}