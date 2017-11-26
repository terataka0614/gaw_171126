using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts.Commons
{
	public class NotesDefine
	{
		public const float CLONE_POSITION_1 = -2.12f;
		public const float CLONE_POSITION_2 = -0.7f;
		public const float CLONE_POSITION_3 = 0.7f;
		public const float CLONE_POSITION_4 = 2.12f;
		public const float CLONE_POSITION_Y = 6.5f;

		public const float JUDGE_LINE_Y = -3.5f;

		public const float SPAWN_DELAY_TIME = 2.0f;

		public const int NOTE_TYPE_NORMAL = 1;

		public static Vector2[] SPAWN_POSITION = {
			new Vector2(CLONE_POSITION_1, CLONE_POSITION_Y),
			new Vector2(CLONE_POSITION_2, CLONE_POSITION_Y),
			new Vector2(CLONE_POSITION_3, CLONE_POSITION_Y),
			new Vector2(CLONE_POSITION_4, CLONE_POSITION_Y),
		};
	}
}