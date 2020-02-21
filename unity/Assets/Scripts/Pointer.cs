using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.Extras;

namespace Mahi
{
    public class Pointer : MonoBehaviour
    {
        private SteamVR_LaserPointer steamVrLaserPointer;

        private void Awake()
        {
                gameObject.SetActive(Valve.VR.SteamVR.active);

            steamVrLaserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();
            steamVrLaserPointer.PointerIn += OnPointerIn;
            steamVrLaserPointer.PointerOut += OnPointerOut;
            steamVrLaserPointer.PointerClick += OnPointerClick;
        }

        private void OnPointerClick(object sender, PointerEventArgs e)
        {
            IPointerClickHandler clickHandler = e.target.GetComponent<IPointerClickHandler>();
            if (clickHandler == null)
            {
                return;
            }


            PointerEventData myData = new PointerEventData(EventSystem.current)
            {
                worldPosition = e.position,
                
            };
            clickHandler.OnPointerClick(myData);
        }

        private void OnPointerOut(object sender, PointerEventArgs e)
        {
            IPointerExitHandler pointerExitHandler = e.target.GetComponent<IPointerExitHandler>();
            if (pointerExitHandler == null)
            {
                return;
            }

            PointerEventData myData = new PointerEventData(EventSystem.current)
            {
                worldPosition = e.position
            };
            pointerExitHandler.OnPointerExit(myData);
        }

        private void OnPointerIn(object sender, PointerEventArgs e)
        {
            IPointerEnterHandler pointerEnterHandler = e.target.GetComponent<IPointerEnterHandler>();
            if (pointerEnterHandler == null)
            {
                return;
            }
            PointerEventData myData = new PointerEventData(EventSystem.current)
            {
                worldPosition = e.position,
            };
            pointerEnterHandler.OnPointerEnter(myData);
        }
    }
}