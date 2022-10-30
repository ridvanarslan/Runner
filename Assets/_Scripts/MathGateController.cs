using System;
using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class MathGateController : MonoBehaviour
    {
        [SerializeField] private int number;
        [SerializeField] private Math math;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        public int Number => number;
        public Math Math => math;
        

        private void Start()
        {
            _textMeshPro.text = math switch
            {
                Math.Sum => $"+{number}",
                Math.Sub => $"-{number}",
                Math.Multiply => $"x{number}",
                Math.Divide => $"/{number}",
                _ => _textMeshPro.text = "???"
            };
        }
    }
}

public enum Math
{
    Sum,Sub,Multiply,Divide
}