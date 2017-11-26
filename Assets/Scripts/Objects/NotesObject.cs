using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Assets.Scripts.Commons;

namespace Assets.Scripts.Objects 
{
	public class NotesObject : MonoBehaviour
	{
		// ====================
		// default
		// ====================

		void Start ()
		{
			_fall_speed = 0.1f;
			if ("Notes_child" == this.name) {
				_can_move = true;
			} else {
				_can_move = false;
			}
		}
		void Update ()
		{
			tapJudge();
			move();
			if (-5.5f > this.transform.position.y) {
				FindObjectOfType<PointManager>().addPoint(-10);
				Destroy(this.gameObject);
			}
		}



		// ====================
		// original
		// ====================

		// 座標操作
		public void setPosition(float x, float y)
		{
			Vector2 sets = new Vector2(x, y);
			this.transform.position = sets;
		}

		// ノート落下操作
		private float _fall_speed;
		public float fall_speed {
			get { return _fall_speed; }
		}
		private bool _can_move;
		public bool can_move {
			get { return can_move; }
		}
		public void move()
		{
			if (false == _can_move) return;

			float after_y = this.transform.position.y + (_fall_speed * -1);
			setPosition(this.transform.position.x, after_y);
		}

		// ノートがタップされた判定
		void tapJudge()
		{
			if (0 < Input.touchCount) {
				Touch touch = Input.GetTouch(0);
				Vector2 touch_point = Camera.main.ScreenToWorldPoint(
					new Vector2(touch.position.x, touch.position.y)
				);
				Collider2D col = Physics2D.OverlapPoint(touch_point);
				if (col && touch.phase == TouchPhase.Began) {
					GameObject obj = col.gameObject;
					if (Mathf.Abs(NotesDefine.JUDGE_LINE_Y - obj.transform.position.y) < 1.0f) {
						FindObjectOfType<PointManager>().addPoint(10);
					} else {
						FindObjectOfType<PointManager>().addPoint(-10);
					}
					Destroy(obj);
				}
			}
		}
	}
}