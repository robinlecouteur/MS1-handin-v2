using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.model
{
    public class GameAction
    {
        private Area _scene;
        private string _actionType; //Stores the type of the the Action ie: Combat, show 
        private object _obj1;
        private object _obj2;
        private string _text;
        
        public GameAction(Area prScene)
        {
            _scene = prScene;
            
        }


        public bool Condition
        {
            
            get
            {
                bool lcBool = (Obj1 == _obj2);
                return lcBool;
            }
        }
        public string ActionType
        {
            get
            {
                return _actionType;
            }

            set
            {
                _actionType = value;
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
            }
        }

        public object Obj1
        {
            get
            {
                return _obj1;
            }

            set
            {
                _obj1 = value;
            }
        }

        public object Obj2
        {
            get
            {
                return _obj2;
            }

            set
            {
                _obj2 = value;
            }
        }

        public string DoAction()
        {
            string lcText = "";
            switch (_actionType)
            {
                case ("ShowText"):
                    lcText = _text;
                    break;
            }
            return lcText;
        }

    }
}
