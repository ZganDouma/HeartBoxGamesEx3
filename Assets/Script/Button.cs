using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public GameObject platforme;
	public GameObject player;
	bool go;
	bool gobutton;
	Animator Mouve;

	// Use this for initialization
	void Start () {
		platforme = GameObject.FindGameObjectWithTag ("Cube");
		player = GameObject.FindGameObjectWithTag ("Player");

		/*Mouve =player.gameObject.GetComponent<Animator>();*/
		go = false;
		gobutton = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(gobutton)
			{
				
		if (go == false) {
			platforme.transform.Translate (new Vector3 (-0.1F, 0, 0));

		} 
		else 
		{
				platforme.transform.Translate (new Vector3 (0.5F, 0F, 0));
				//player.transform.Translate(new Vector3 (0, 0.5F, 0));


		}
			if (platforme.transform.position.y >=-6) {
			go = false;
		}
			else if(platforme.transform.position.y<=-52){
			go =true;
		}
			}
		
			else
			{	}
			}
				
	public void MovePlatforme()
	{  
		gobutton = !gobutton;
		go = true;
	}
	public void Gauche()
	{
	//	Mouve.SetBool ("param_idletowalk", true);

	}
	public void Jump()
	{
		//Mouve.SetBool ("param_idletojump", true);

	}
	public void Droite()
	{
	
	}



}
