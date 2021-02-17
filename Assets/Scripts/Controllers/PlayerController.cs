using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class PlayerController : IController
    {
        private readonly Player _player;
        private readonly OutOfDisplayCheker _outOfDisplayCheker;
        private List<IExecute> _executeList;

        public PlayerController (Data data, OutOfDisplayCheker outOfDisplayCheker)
        {
            _player = data.Player;
            _outOfDisplayCheker = outOfDisplayCheker;
            _executeList = new List<IExecute>();
            _executeList.Add(_player);
            _executeList.Add(_outOfDisplayCheker);
        }


        public void Updater()
        {
            foreach (var item in _executeList)
                item.Execute();

        }
    }
}
