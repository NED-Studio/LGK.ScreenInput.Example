//
// Author: Leo Pripos Marbun <leopripos@gmail.com>
// Ask author for more information
//
// Copyright (c) 2017 NED Studio
// See the LICENSE file in the project root directory for more information.
//
using UnityEngine;
using UnityEngine.UI;
using LGK.ScreenInput;

namespace LGK.ScreenInputExample
{
	public class ScreenInputManagerBehaviour : MonoBehaviour
	{
		[SerializeField]
		private Text m_ActionInfo;
		[SerializeField]
		private Text m_PointerInfo;

		private ScreenInputManager m_Manager;

		private void Awake ()
		{
			m_Manager = new ScreenInputManager ();
		}

		private void OnEnable ()
		{
			m_Manager.OnPointerDown += OnPointerDown_Handler;
			m_Manager.OnPointerMoved += OnPointerMoved_Handler;
			m_Manager.OnPointerUp += OnPointerUp_Handler;

			m_Manager.OnTap += OnTap_Handler;
			m_Manager.OnDoubleTap += OnDoubleTap_Handler;
			m_Manager.OnLongTap += OnLongTap_Handler;
			m_Manager.OnSwipe += OnSwipe_Handler;
			m_Manager.OnDrag += OnDrag_Handler;
			m_Manager.OnPinch += OnPinch_Handler;
		}

		private void OnDisable ()
		{
			m_Manager.OnPointerDown -= OnPointerDown_Handler;
			m_Manager.OnPointerMoved -= OnPointerMoved_Handler;
			m_Manager.OnPointerUp -= OnPointerUp_Handler;

			m_Manager.OnTap -= OnTap_Handler;
			m_Manager.OnDoubleTap -= OnDoubleTap_Handler;
			m_Manager.OnLongTap -= OnLongTap_Handler;
			m_Manager.OnSwipe -= OnSwipe_Handler;
			m_Manager.OnDrag -= OnDrag_Handler;
			m_Manager.OnPinch -= OnPinch_Handler;
		}

		private void Update ()
		{
			m_Manager.Update (Time.deltaTime);
			m_PointerInfo.text = m_Manager.Pointers.Count.ToString ();
		}

		void OnPointerDown_Handler (IPointer pointer)
		{
			Debug.Log (string.Format ("OnPointerMoved_Handler[position:{0}, deltaPosition:{1}]", pointer.Position, pointer.DeltaPosition));   
		}

		void OnPointerMoved_Handler (IPointer pointer)
		{
			Debug.Log (string.Format ("OnPointerMoved_Handler[position:{0}, deltaPosition:{1}]", pointer.Position, pointer.DeltaPosition));
		}

		void OnPointerUp_Handler (IPointer pointer)
		{
			Debug.Log (string.Format ("OnPointerMoved_Handler[position:{0}, deltaPosition:{1}]", pointer.Position, pointer.DeltaPosition));
		}

		void OnTap_Handler (Vector2 position, float totalTime)
		{
			m_ActionInfo.text = "Tap " + position.ToString ();
		}

		void OnDoubleTap_Handler (Vector2 position, float totalTime)
		{
			m_ActionInfo.text = "Double Tap" + position.ToString ();
		}

		void OnLongTap_Handler (Vector2 position, float totalTime)
		{
			m_ActionInfo.text = "Long Tap" + position.ToString ();
		}

		void OnSwipe_Handler (Vector2 direction, float totalTime)
		{
			var swipe8Direction = ScreenInputUtility.ConvertSwipeTo8Direction (direction);

			m_ActionInfo.text = "Swipe " + swipe8Direction.ToString ();
		}

		void OnDrag_Handler (Vector2 position, Vector2 deltaPosition)
		{
			m_ActionInfo.text = "Drag" + position.ToString ();
		}

		void OnPinch_Handler (Vector2 position, float deltaScale)
		{
			m_ActionInfo.text = "Pinch" + position.ToString ();
		}
	}
}

