using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace Asteroids
{


    public class GameManager : MonoBehaviour
    {
        public Text scoreText;

        private static int score = 0;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Score: " + score.ToString();
        }

        public static void AddScore(int scoreToAdd)
        {
            score += scoreToAdd;
        }
    }
}