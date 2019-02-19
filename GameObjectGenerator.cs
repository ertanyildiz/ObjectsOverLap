using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets
{
    class GameObjectGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _orginalGameObject;
        public List<GameObject> InitObjects()
        {
            //object list that has instantiated objects
            var objList = new List<GameObject>();

            //GameObjects rectangles List
            var rectList = new List<Rect>();
            var safeCheck = 0;
            for (var i = 0; i < 10; i++)
            {
                var obj = _orginalGameObject;
                //Generate random x and y positions.
                var position = GeneratePositon();
                var vector3 = new Vector3(position.x, position.y, 0);
                if (i == 0)
                {
                    obj.transform.position = vector3;
                    var rect = GetRect();
                    rect.x = vector3.x;
                    rect.y = vector3.y;
                    rectList.Add(rect);
                }
                else
                {
                    while (true)
                    {
                        position = GeneratePositon();
                        vector3 = new Vector3(position.x, position.y, 0);
                        var rect = GetRect();
                        rect.x = vector3.x;
                        rect.y = vector3.y;
                        var check = CheckOverlap(rectList, rect);
                        if (check)
                        {
                            obj = Instantiate(_orginalGameObject, vector3, Quaternion.identity);
                            rectList.Add(rect);
                            objList.Add(obj);
                            break;
                        }
                        //Safety check: if while loop runs more than 50 let it overlap :/
                        if (safeCheck <= 50) continue;
                        obj = Instantiate(_orginalGameObject, vector3, Quaternion.identity);
                        objList.Add(obj);
                        break;
                    }
                }
            }
            return objList;

        }
        /// <summary>
        /// Generates random Vector2 positon using Random.Range method
        /// </summary>
        /// <returns>Vector2</returns>
        private Vector2 GeneratePositon()
        {
            var position = new Vector2(Random.Range(-7, 9), Random.Range(-1, 4));
            return position;
        }

        /// <summary>
        /// Gets GameObject's Rectangale in t he RectTransform Component
        /// </summary>
        /// <returns></returns>
        private Rect GetRect()
        {
            var rect = _orginalGameObject.GetComponent<RectTransform>();
            return rect.rect;
        }

        /// <summary>
        /// Checks if new Rect overlaps other Rects in the scene
        /// </summary>
        /// <param name="rectList">Dynamic Objects Rect List</param>
        /// <param name="rect">New created Dynamic Object Rect</param>
        /// <returns></returns>
        private bool CheckOverlap(List<Rect> rectList, Rect rect)
        {
            foreach (var rectObj in rectList)
            {
                if (rect.Overlaps(rectObj))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
