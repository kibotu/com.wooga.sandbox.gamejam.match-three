using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {

	public int oneStarValue = 5000;
	public int twoStarValue = 7500;
	public int threeStarValue = 10000;

	public Star oneStar;
	public Star twoStar;
	public Star threeStar;

	void Start() {

		oneStar = Prefabs.CreateNewStar ().GetComponent<Star>();
		twoStar = Prefabs.CreateNewStar ().GetComponent<Star>();
		threeStar = Prefabs.CreateNewStar ().GetComponent<Star>();

		oneStar.pos.x = 193;
		oneStar.pos.y = 13;

		
		twoStar.pos.x = 214;
		twoStar.pos.y = 13;
		
		threeStar.pos.x = 236;
		threeStar.pos.y = 13;
	}

	public int updateStars(int value)
	{
		int ret = 0;

		if(value >= oneStarValue) {
			oneStar.enable(true);
			ret = 1;
		}
		
		if(value >= twoStarValue) {
			twoStar.enable(true);
			ret = 2;
		}

		if(value >= threeStarValue) {
			threeStar.enable(true);
			ret = 3;
		}

		return ret;
	}
}
