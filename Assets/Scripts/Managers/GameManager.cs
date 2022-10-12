using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PunchRunner.Managers
{
    public class GameManager : MonoSingleton<GameManager>
        // Start is called before the first frame update
    {
        public float sensitivity;
        public int upgradePrice,upgradeRate,baseExpValue;
        public int collectedCurrency=0;
        public float speed,speedRate;
        public int expRate;
        public string lvl = "LEVEL";
        public int maxStackIncreaseRate;
        public  GameObject smashParticle;
        public string fullStack = "Stack is Full!";
        public Character character;
        public bool isPunch = false;
        public int money,moneyRate;  //currency
        public Animator characterAnim;
        public bool tapToPlay = false;
        public bool isFinishLevel = false;
        public int currentStack, maxStack;
        public string state = "IdleRoutine";
        public Transform leftHand, rightHand;
        public float handScaleRate = 0.2f;
        public CameraFollow cameraFollow;
        public AudioSource audioSource;
        public AudioClip stackClip, obstacleClip,punchClip;
        private void Start()
        {
            LoadData();
            StartGame();

        }


        public void PlayAudio(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        void LoadData()
        {
            money = PlayerPrefs.GetInt("currency",money);
            expRate=PlayerPrefs.GetInt("expRate",2);
            upgradePrice= PlayerPrefs.GetInt("upgradePrice",upgradePrice);
            maxStack = PlayerPrefs.GetInt("maxStackCapacity", maxStack);
        }

        public void SaveData()
        {
            PlayerPrefs.SetInt("expRate", GameManager.Instance.expRate);
            PlayerPrefs.SetInt("upgradePrice",GameManager.Instance.upgradePrice);
            PlayerPrefs.SetInt("currency",GameManager.Instance.money);
            PlayerPrefs.SetInt("maxStackCapacity", maxStack);
        }

        public void Win()
        {
            cameraFollow.StopCoroutine("FollowRoutine");
            cameraFollow.StartCoroutine("CamRotate");
            isFinishLevel = true;
            character.StopCoroutine("MoveRoutine");
            UIManager.Instance.endPanel.SetActive(true);
            InputPanel.Instance.OnDragDelta.RemoveListener(character.Drag);
        }

        void StartGame()
        {

            UIManager.Instance.lvlTxt.text = lvl + " " + (PlayerPrefs.GetInt("Level",0)+1) ;
            audioSource = transform.GetComponent<AudioSource>();
            UIManager.Instance.totalCurrencyTxt.text = money.ToString();
       
            UIManager.Instance.SetStackTxt();
            UIManager.Instance.upgradePriceTxt.text = upgradePrice.ToString();
            UpgradeManager.Instance.CurrencyCheck();  // upgrade button interact check 
            LevelManager.Instance.SpawnLevel();
            cameraFollow = FindObjectOfType<CameraFollow>();
            cameraFollow.StartCoroutine("FollowRoutine");
            characterAnim = character.transform.GetComponentInChildren<Animator>();
            StartCoroutine("DecisionAnimRoutine");
            StartCoroutine(state);
     
        }

  
        private void Update()
        {
            if (!EventSystem.current.currentSelectedGameObject)
            {
                if (Input.GetMouseButtonDown(0)&&!tapToPlay)
                {
                    character.StartCoroutine("MoveRoutine");
                    InputPanel.Instance.OnDragDelta.AddListener(character.Drag);
                    UIManager.Instance.upgradeBtn.gameObject.SetActive(false);
                    UIManager.Instance.tapToPlayPanel.SetActive(false);
                    UIManager.Instance.inGamePanel.SetActive(true);
                    tapToPlay = true;

                }
            }
     
        }

        string currentAnimation;
        public void RegisterAnimation(string value)
        {

            if (value == currentAnimation)
                return;
        
     
            currentAnimation = value;
       
            characterAnim.CrossFade(currentAnimation,0.25f);
        }
    
    
        public void ChangeState(string value)
        {
            if (state == value)
                return;
            state = value;
        }
    
        public  IEnumerator DecisionAnimRoutine()
        {
        
            while (true)
            {
                if (!tapToPlay)
                {
                
                    ChangeState("IdleRoutine");
                }
                else if(isPunch)
                    ChangeState("PunchRoutine");
                else if(isFinishLevel )
                    ChangeState("DanceRoutine");
                else if (currentStack<maxStack)
                    ChangeState("Run1Routine");
                else
                    ChangeState("Run2Routine");
           
           
                yield return  null;
            }
        }
    
    
        IEnumerator IdleRoutine()
        { 
        
            if (state=="IdleRoutine")
            {
                RegisterAnimation("Idle");
                yield return null;
            }

            StartCoroutine(state);
        }
    
        IEnumerator DanceRoutine()
        { 
        
            if (state=="DanceRoutine")
            {
                RegisterAnimation("Dance");
      
                yield return null;
            }

            StartCoroutine(state);
        }
        IEnumerator Run1Routine()
        { 
        
            if (state=="Run1Routine")
            {
                RegisterAnimation("Run");
                yield return null;
            }

            StartCoroutine(state);
        }
    
        IEnumerator Run2Routine()
        { 
        
            if (state=="Run2Routine")
            {
                RegisterAnimation("Run2");
                yield return null;
            }

            StartCoroutine(state);
        }
        IEnumerator PunchRoutine()
        { 
        
            if (state=="PunchRoutine")
            {
                RegisterAnimation("punch");
            
                yield return null;
            }

            StartCoroutine(state);
        }


    }
}
