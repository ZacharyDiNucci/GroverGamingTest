using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{

    //This is the main script which deals with the generation of values and assigning of prizes.
    
    [SerializeField]
    private Button playBtn = null;
    [SerializeField]
    private Dropdown bidDropDown = null;
    [SerializeField]
    private Text balanceText = null;
    [SerializeField]
    private Button redeemBtn = null;    
    [SerializeField]
    private GameObject ChestPanel = null;
    [SerializeField]
    private ChestManager chestManager;
    [SerializeField]
    private StartGame startGame;
    [SerializeField]
    private Text rewardText;


    private double balance = 10.00;
    private double bid;
    private string balanceString;
    private bool playing = false;
    private int reward;
    private int[] rewards = new int[5];
    private int[] teir1Rewards = new int[] {1,2,3,4,5,6,7,8,9,10};
    private int[] teir2Rewards = new int[] {12,16,24,32,48,64};
    private int[] teir3Rewards = new int[] {100,200,300,400,500};
    private int i = 0;

    // Start is used to assign on lcick listeners to buttons
    void Start()
    {
        playBtn.onClick.AddListener(playGame);
        ChestPanel.SetActive(false);
        redeemBtn.onClick.AddListener(redeemMoney);
        rewardText.gameObject.SetActive(false);
    }

    // play game checks if a current round is being played and if not will start a new one by chekcing what the bid is and removing the bid from the balance text.
    // Then it will enable chests and generate rewards.
    private void playGame()
    {
        if(!playing){
            if(bidDropDown.value != 0){
            bidDropDown.enabled = false;
            playBtn.enabled = false;
                switch(bidDropDown.value){
                    case 1:
                        bid = .25;
                        break;
                    case 2:
                        bid = .50;
                        break;
                    case 3:
                        bid = 1.00;
                        break;
                    case 4:
                        bid = 5.00;
                        break;
                }
                balance = balance - bid;
                balanceString = balance.ToString("F2");
                balanceText.text = "Bal: $" + balanceString;
                playing = true;
                generateReward();
                chestManager.enableChests();
                ChestPanel.SetActive(true);
            i = 0;
            }
        }
    }

    //  The Generate reward function calls a random number between 1 and 20 and this is used to generate what tier of reward is given.
    private void generateReward(){
        int newReward = 0;
        reward = UnityEngine.Random.Range(1, 21);
        if(reward <= 10){
            newReward = 0;
        } else if(reward > 10 && reward <= 16){
            newReward = 1;
        } else if(reward > 16 && reward <= 19){
            newReward = 2;
        } else if(reward == 20){
            newReward = 3;
        }
        rewards[0] = newReward;
        getReward();
    }

    // The Get reward function checks the reward teir from before and then using some math split it up into smaller numbers that are divided in the chests.
    // the larger the reward the more chests the player will open before hitting the Pooper
    private void getReward(){
        int randomReward = 0;
        int reward1 = 0;
        int reward2 = 0;
        int reward3 = 0;
        int reward4 = 0;
        int reward5 = 0;
        int rewardRemainer = 0;
        switch(rewards[0]){
            case 0:
                rewards[0] = 0;
                break;
            case 1:
                reward = UnityEngine.Random.Range(1, teir1Rewards.Length);
                rewards[0] = teir1Rewards[reward];
                break;
            case 2:
                randomReward = UnityEngine.Random.Range(1, teir2Rewards.Length);
                reward = teir2Rewards[randomReward];
                reward1 = reward / 3;
                reward2 = reward1 /2;
                rewardRemainer = reward1 + reward2;
                reward3 = reward - rewardRemainer; 
                reward4 = 0;
                rewards[0] = reward1;
                rewards[1] = reward2;
                rewards[2] = reward3;
                rewards[3] = reward4;
                rewardRemainer = reward1 + reward2 + reward3;
                break;
            case 3:
                randomReward = UnityEngine.Random.Range(1, teir3Rewards.Length);
                reward = teir2Rewards[randomReward];
                reward1 = reward / 10;
                reward2 = reward1 / 2;
                rewardRemainer = reward1 + reward2;
                reward3 = rewardRemainer / 5; 
                rewardRemainer = reward1 + reward2 + reward3;
                reward4 = reward - rewardRemainer;
                reward5 = 0;
                rewards[0] = reward1;
                rewards[1] = reward2;
                rewards[2] = reward3;
                rewards[3] = reward4;
                rewards[4] = reward5;
                rewardRemainer = reward1 + reward2 + reward3 + reward4;
                break;
        }
    }

    // This is the function which is called in the chest manager script.
    // it checks what the reward is and then displays a rewards text with a small animation.
    // Then it runs a corutien that will deliver the reward.
    public void openChest(){
        rewardText.gameObject.SetActive(true);
         if(rewards[i] == 0){
              rewardText.text = "$0.00";
        } else{
            var rewardVal = bid * rewards[i];
            rewardText.text = "$" + rewardVal.ToString("F2");
        }
        StartCoroutine(wait1());
    }

    //  This coroutine calls assignes the reward and resets the game.
    IEnumerator wait1()
    {
        yield return new WaitForSeconds(1.2f);
        rewardText.gameObject.SetActive(false);
        if(rewards[i] == 0){
            playing = false;
            Array.Clear(rewards, 0, rewards.Length);
            ChestPanel.SetActive(false);
            bidDropDown.enabled = true;
            playBtn.enabled = true;
        } else{
            balance = bid * rewards[i] + balance;
            balanceString = balance.ToString("F2");
            balanceText.text = "Bal: $" + balanceString;
            i++;
        }
    }

    //  Redeem essentially resets the game and sets the game back to the start screen though would be where someone would collect their winnings.
    private void redeemMoney(){
        startGame.endGame();
        balance = 10.00;
        chestManager.enableChests();
        ChestPanel.SetActive(false);
        playing = false;
        bidDropDown.enabled = true;
        playBtn.enabled = true;
        Array.Clear(rewards, 0, rewards.Length);
    }
}
