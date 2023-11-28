/*
using System;
namespace CodeWars
{
    class Pong
    {
        private int maxScore;
        int p1score = 0;
        int p2score = 0;
        bool isPlayingPlayerOne = false;
        public Pong(int maxScore)
        { this.maxScore = maxScore; }
        public string play(int ballPos, int playerPos)
        {
            if (p1score >= maxScore || p2score >= maxScore)
                return "Game Over!";
            isPlayingPlayerOne = !isPlayingPlayerOne;
            if (Math.Abs(ballPos - playerPos) < 4)
            {
                if (isPlayingPlayerOne) return "Player 1 has hit the ball!";
                else return "Player 2 has hit the ball!";
            }
            else
            {
                if (isPlayingPlayerOne)
                {
                    p2score++; if (p2score == maxScore) return "Player 2 has won the game!";
                    return "Player 1 has missed the ball!";
                }
                else
                {
                    p1score++;
                    if (p1score == maxScore)
                        }
*/