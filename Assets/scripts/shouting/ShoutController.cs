using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShoutController : MonoBehaviour {

	public static ShoutController sc;
	public GameObject playerRatingSelection;

	public Shout shouter;

	public bool shoutingPhase=true;


	public int[] ratings= new int[4];
	public float[] scores=new float[5];
	public int winner=-1;

	public float sympathy=10;

	public float maxStrength=40;

	public List<int> played=new List<int>();
	public int currentCharacter=0;
	bool playerRated=false;

	public float nextRoundTimer=0,nextRoundTime=4;
    public bool cheated = false;

	public Sprite[] spritesIdle= new Sprite[5];
	public Sprite[] spritesRate= new Sprite[5];
	public Sprite[] spritesShout= new Sprite[5];

	public SpriteRenderer player;
	public SpriteRenderer[] jurys=new SpriteRenderer[4];

	public GameObject[] ratingTexts=new GameObject[4];

    // Use this for initialization
    void Start () {
		sc=this;
		ChooseCharacter();
		ClearRatingText();
	}
	
	// Update is called once per frame
	void Update () {
        if (!Menu.instance.gameIsRunning) {
            return;
        }
		if (!shoutingPhase && ((currentCharacter==0) || playerRated)){
			

			nextRoundTimer+=Time.deltaTime;
			if (nextRoundTimer>=nextRoundTime){

				ClearRatingText();
				nextRoundTimer=0;
				playerRated=false;

				scores[currentCharacter]=AvgRating();

				if (played.Count<5)
					ChooseCharacter();
				else{
					ChooseWinner();
				}
			}
		}
	}

	float AvgRating(){
		float avg=0;

		for (int i=0; i<4; i++){
			avg+=ratings[i];
		}
		avg/=4;

		return avg;
	}

	void ChooseWinner(){
		float winnerScore=0;
		for(int i=0; i<5; i++){
			if (scores[i]>winnerScore){
				winnerScore=scores[i];
				winner=i;
                Menu.instance.EndGame("name of winner", cheated);
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
	
		player.sprite=spritesShout[currentCharacter];

		int jury=0;
		for(int i=0; i<4; i++){
			if (currentCharacter==jury)
				jury++;
			jurys[i].sprite=spritesIdle[jury++];
		}
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

		int jury=start;
		for(int i=start; i<4; i++){
			if (currentCharacter==jury)
				jury++;
			jurys[i].sprite=spritesRate[jury];

			float y=0;
			switch(jury){
			case 0:
				y=18.1f;
				break;
			case 1:
				y=18.1f;
				break;
			case 2:
				y=28.4f;
				break;
			case 3:
				y=-17.7f;
				break;
			case 4:
				y=19.5f;
				break;
			}
			ratingTexts[i].GetComponent<RectTransform>().localPosition=new Vector2(ratingTexts[i].GetComponent<RectTransform>().localPosition.x,y);

			jury++;
		}

		SetRatingText();
	}

	public void PlayerRate(int rating){
		playerRatingSelection.SetActive(false);
		ratings[0]=rating;
		playerRated=true;
        if (rating < 2) {
            // y u rate so low, asshole?
            cheated = true;
        }

		jurys[0].sprite=spritesRate[0];
		SetRatingText();

	}

	void SetRatingText(){
		int start=0;

		if (!playerRated && currentCharacter!=0){
			start=1;
		}


		for(int i=start; i<4; i++){
			ratingTexts[i].GetComponent<Text>().text=ratings[i]+"";
		}
	}

	void ClearRatingText(){
		for(int i=0; i<4; i++){
			ratingTexts[i].GetComponent<Text>().text="";
		}
	}
}
