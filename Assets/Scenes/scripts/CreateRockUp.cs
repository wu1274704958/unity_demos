using UnityEngine;
using System.Collections;

namespace Assets.Scenes.scripts
{
    public class CreateRockUp : RollObj<int,CreateRockd,Size>
    {
        public override int getArgs()
        {
            return 0;
        }

        // Use this for initialization
        override public void Start() 
        {
            base.Start();
        }

        // Update is called once per frame
        override public void Update()
        {
            base.Update();
        }
    }
}