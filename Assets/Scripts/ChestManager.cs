using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestManager : MonoBehaviour
{
    /*  This script is to assign the 9 different chests to values and make sure they play their animations and then communicate with the main script when one is opened.
    */
    
    [SerializeField]
    private Button chestBtn1 = null;
    [SerializeField]
    private Button chestBtn2 = null;
    [SerializeField]
    private Button chestBtn3 = null;
    [SerializeField]
    private Button chestBtn4 = null;
    [SerializeField]
    private Button chestBtn5 = null;
    [SerializeField]
    private Button chestBtn6 = null;
    [SerializeField]
    private Button chestBtn7 = null;
    [SerializeField]
    private Button chestBtn8 = null;
    [SerializeField]
    private Button chestBtn9 = null;
    [SerializeField]
    private PlayGame playGame;


    

    // Start makes sure that each chesthas a on click function assigned.
    void Start()
    {
        chestBtn1.onClick.AddListener(delegate{runOpenChest(1);});
        chestBtn2.onClick.AddListener(delegate{runOpenChest(2);});
        chestBtn3.onClick.AddListener(delegate{runOpenChest(3);});
        chestBtn4.onClick.AddListener(delegate{runOpenChest(4);});
        chestBtn5.onClick.AddListener(delegate{runOpenChest(5);});
        chestBtn6.onClick.AddListener(delegate{runOpenChest(6);});
        chestBtn7.onClick.AddListener(delegate{runOpenChest(7);});
        chestBtn8.onClick.AddListener(delegate{runOpenChest(8);});
        chestBtn9.onClick.AddListener(delegate{runOpenChest(9);});
        enableChests();
    }
    public void enableChests(){
        //this function is called in the main PlayGame script and makes sure that each chest is enabled/active and their idle animations are running
        chestBtn1.gameObject.SetActive(true);
        chestBtn2.gameObject.SetActive(true);
        chestBtn3.gameObject.SetActive(true);
        chestBtn4.gameObject.SetActive(true);
        chestBtn5.gameObject.SetActive(true);
        chestBtn6.gameObject.SetActive(true);
        chestBtn7.gameObject.SetActive(true);
        chestBtn8.gameObject.SetActive(true);
        chestBtn9.gameObject.SetActive(true);
        chestBtn1.enabled = true;
        chestBtn2.enabled = true;
        chestBtn3.enabled = true;
        chestBtn4.enabled = true;
        chestBtn5.enabled = true;
        chestBtn6.enabled = true;
        chestBtn7.enabled = true;
        chestBtn8.enabled = true;
        chestBtn9.enabled = true;
        StartCoroutine(waitIdle());
        
    }
    
    private void runOpenChest(int id){
        // Here we get the chest that was clicked based on the value assigned earlier and run through a swithc statement. 
        // Within each case it will play the open animation for the chest and then start a coroutine called wait.
        switch(id){
            case 1:
                chestBtn1.animator.Play("chest");
                StartCoroutine(wait1());
                //chestBtn1.gameObject.SetActive(false);
                break;
            case 2:
                chestBtn2.animator.Play("chest");
                StartCoroutine(wait2());
                break;
            case 3:
                chestBtn3.animator.Play("chest");
                StartCoroutine(wait3());
                break;
            case 4:
                chestBtn4.animator.Play("chest");
                StartCoroutine(wait4());
                break;
            case 5:
                chestBtn5.animator.Play("chest");
                StartCoroutine(wait5());
                break;
            case 6:
                chestBtn6.animator.Play("chest");
                StartCoroutine(wait6());
                break;
            case 7:
                chestBtn7.animator.Play("chest");
                StartCoroutine(wait7());
                break;
            case 8:
                chestBtn8.animator.Play("chest");
                StartCoroutine(wait8());
                break;
            case 9:
                chestBtn9.animator.Play("chest");
                StartCoroutine(wait9());
                break;
        }
    }
    IEnumerator waitIdle()
    {
        //this wait allows a small delay for the idle to run so they are for sure on the screen
        yield return new WaitForSeconds(.05f);
        chestBtn1.animator.Play("idle");
        chestBtn2.animator.Play("idle");
        chestBtn3.animator.Play("idle");
        chestBtn4.animator.Play("idle");
        chestBtn5.animator.Play("idle");
        chestBtn6.animator.Play("idle");
        chestBtn7.animator.Play("idle");
        chestBtn8.animator.Play("idle");
        chestBtn9.animator.Play("idle");
    }
    
    
    //here are all the wait functions which have a 1.2 second delay in order to run the animation.
    //Then they call the open chest function within the main playgame script.
    IEnumerator wait1()
    {
        yield return new WaitForSeconds(1.2f);
        chestBtn1.enabled = false;
        playGame.openChest();
    }
    IEnumerator wait2()
    {
        yield return new WaitForSeconds(1.2f);
        chestBtn2.enabled = false;
        playGame.openChest();
    }
    IEnumerator wait3()
    {
        yield return new WaitForSeconds(1.2f);
        chestBtn3.enabled = false;
        playGame.openChest();
    }
    IEnumerator wait4()
    {
        yield return new WaitForSeconds(1.2f);
        chestBtn4.enabled = false;
        playGame.openChest();
    }
    IEnumerator wait5()
    {
        yield return new WaitForSeconds(1.2f);
        chestBtn5.enabled = false;
        playGame.openChest();
    }
    IEnumerator wait6()
    {
        yield return new WaitForSeconds(1.2f);
        chestBtn6.enabled = false;
        playGame.openChest();
    }
    IEnumerator wait7()
    {
        yield return new WaitForSeconds(1.2f);
        chestBtn7.enabled = false;
        playGame.openChest();
    }
    IEnumerator wait8()
    {
        yield return new WaitForSeconds(1.2f);
        chestBtn8.enabled = false;
        playGame.openChest();
    }
    IEnumerator wait9()
    {
        yield return new WaitForSeconds(1.2f);
        chestBtn9.enabled = false;
        playGame.openChest();
    }
}
