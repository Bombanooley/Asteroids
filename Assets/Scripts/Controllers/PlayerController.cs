using UnityEngine;


namespace Asteroids
{
    public class PlayerController : IController
    {
        private readonly Player _player;

        public PlayerController (Player player)
        {
            _player = player;
        }


        public void Updater()
        {

        }
    }
}
