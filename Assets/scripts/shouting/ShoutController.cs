using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShoutController : MonoBehaviour {

	public static ShoutController sc;
	public GameObject playerRatingSelection;

	public Shout shouter;

	public bool shoutingPhase=true;

	public Text ratingText;


	public int[] ratings= new int[4];
	public float sympathy=10;

	public float maxStrength=40;

	public List<int> played=new List<int>();
	public int currentCharacter=0;
	bool playerRated=false;

	public float nextRoundTimer=0,nextRoundTime=4;

	// Use this for initialization
	void Start () {
		sc=this;
		ChooseCharacter();
	}
	
	// Update is called once per frame
	void Update () {
		if (!shoutingPhase && ((currentCharacter==0) || playerRated)){
			nextRoundTimer+=Time.deltaTime;
			if (nextRoundTimer>=nextRoundTime){
				nextRoundTimer=0;
				playerRated=false;

				if (played.Count<5)
					ChooseCharacter();
			}
		}
	}

	public void ChooseCharacter(){
		do{
			currentCharacter=Random.Range(0,5);
		}while(played.Contains(currentCharacter));
		played.Add(currentCharacter);

		shoutingPhase=true;
		shouter.enabled=true;
		shouter.character=currentCharacter;
	}

	public void RatingPhase(float strength){
		if (currentCharacter!=0)
			playerRatingSelection.SetActive(true);


		shoutingPhase=false;
		string text="";
		float rating;

		int start=0;

		if (currentCharacter!=0){
			start=1;
			ratings[0]=0;
		}

		for (int i=start; i<4; i++){
			rating=(strength/maxStrength)*10-Random.value*(10-sympathy);
			rating=Mathf.Clamp(rating,0,10);
			ratings[i]=(int)rating+1;

			text+=ratings[i]+" ";
		}

		ratingText.text=text;
	}

	public void PlayerRate(int rating){
		playerRatingSelection.SetActive(false);
		ratings[0]=rating;
		playerRated=true;

		ratingText.text=ratings[0]+" "+ratings[1]+" "+ratings[2]+" "+ratings[3];
	}
}
