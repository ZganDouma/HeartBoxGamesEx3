using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
     Animator Mouve;
	bool moveD,moveG,jumpB;
	public GameObject camera;
	public GameObject Fin;
	public GameObject Assenceur;
	// Use this for initialization
	void Start () {
		//Mouve.SetBool ("param_idletowalk", true);
		Mouve=this.gameObject.GetComponent<Animator>();
		moveD = false;
		moveG = false;
		jumpB = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x>= 375)
		{
			Assenceur.SetActive(true);
		}
		if (moveD) {
			print ("moveD");
			this.transform.Translate (new Vector3 (0F, 0, 0.5F));
			camera.transform.position =new Vector3( this.transform.position.x,camera.transform.position.y,camera.transform.position.z);

		}
		if (moveG) {
			print ("MoveG");
			this.transform.Translate (new Vector3 (0F, 0, 0.5F));
			camera.transform.position =new Vector3( this.transform.position.x,camera.transform.position.y,camera.transform.position.z);

		}
	}
	public void jump()
	{ 
		{  
			if (!jumpB) {
				
				Mouve.CrossFade ("jump", 0);
				this.transform.Translate (new Vector3 (0F, 10F, 5));
				camera.transform.position = new Vector3 (this.transform.position.x, camera.transform.position.y, camera.transform.position.z);
				jumpB = true;
			}
		//	Mouve.SetBool ("param_idletojump", true);
		}
	

	}
	public void stopJump()
	{jumpB = false;
	//	Mouve.SetBool ("param_idletojump", false);

	}
	public void Droite()
	{		

		//Lancer l'animation running et depalcer le joueur
		Mouve.CrossFade ("running", 0);
		var rotationVector = transform.rotation.eulerAngles;
		rotationVector.y = 90;
		transform.rotation = Quaternion.Euler(rotationVector);
		Mouve.SetBool ("param_idletorunning", false);
		moveG=false;
		moveD = true;

	}
	public void stopDroite()
	{   Mouve.CrossFade ("idle", 0);
	     Mouve.SetBool ("param_idletorunning", false);
		moveD = false;
	}
	public void stopGauche()
	{
		//Arreter l'annimation running
		Mouve.CrossFade ("idle", 0);
		Mouve.SetBool ("param_idletorunning", false);
		moveG= false;
	}
	public void Gauche()

	{
		//Lancer l'animation running et depalcer le joueur

		Mouve.CrossFade ("running", 0);
		var rotationVector = transform.rotation.eulerAngles;
		rotationVector.y = -90;
		transform.rotation = Quaternion.Euler(rotationVector);
		Mouve.SetBool ("param_idletorunning", false);
		moveD=false;
		moveG = true;
	}
	void OnCollisionEnter(Collision col)
	{//Detecter la collision de entre le joueur et les portail et le fin
		if (col.gameObject.tag == "Portail 1") {
			print (col.gameObject.tag);
			GameObject go = GameObject.FindWithTag ("Portail 2");
			Vector3 tran = go.transform.position + new Vector3 (3.5f, 0.7f, 0);
			transform.position = (tran);

		} else if (col.gameObject.tag == "Fin") {
			Fin.SetActive (true);
		}
	}
	public void rejouer()
	{
		Application.LoadLevel (0);
	}
}
