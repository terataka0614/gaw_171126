using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
		// ====================
		// default
		// ====================

		void Start ()
		{
			pointInitialize();
		}
		void Update ()
		{
			point_text.text = point.ToString();
		}



		// ====================
		// original
		// ====================

		// 得点関係の変数設定
		public Text point_text;
		private int point;

		// 得点の初期化
		void pointInitialize()
		{
			point = 0;
		}

		// 得点の加算
		public void addPoint(int value)
		{
			point += value;
		}
}
