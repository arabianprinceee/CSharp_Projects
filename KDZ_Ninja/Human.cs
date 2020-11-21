using System;

namespace KDZ
{
    public class Human
    {
        protected bool Poisoned;
        public bool poisoned { get { return Poisoned; } set { Poisoned = value; } }  // Проверка, отравлен ли персонаж
        protected double Healthy;
        public double healthy { get { return Healthy; } set { Healthy = value; } }  // Уровень здоровья персонажа
    }
}
