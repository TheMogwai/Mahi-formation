using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState  {MainMenu = 0,PlayingEasy = 1,PlayingHard = 2}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State { get; set; }

    void Awake()
    {
        Instance = this;
        State = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
