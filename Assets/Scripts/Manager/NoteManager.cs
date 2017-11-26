using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

using Assets.Scripts.Objects;
using Assets.Scripts.Commons;

namespace Assets.Scripts.Manager
{
	public class NoteManager : MonoBehaviour
	{
		// ====================
		// default
		// ====================

		private AudioSource _audio;
		void Start ()
		{
			_parent_note = GameObject.Find("Note");
			_clone_objects = GameObject.Find("CloneObjects");

			// テスト用のスコアデータ
			_score_timing = new float[1024];
			_score_line = new int[1024];
			loadScoredataCsv();

			// ノート生成の初期データ
			_start_timer = Time.time;
			_score_position = 0;

			// 音楽データの読み込み
			_audio = GameObject.Find("PlayMusic").GetComponent<AudioSource>();
			_audio.Play();
		}
		void Update ()
		{
			spawnNotes();
		}



		// ====================
		// original
		// ====================

		// 親ノートの複製
		private GameObject _parent_note;
		private GameObject _clone_objects;
		private void createNoteObject(Vector2 position)
		{
			GameObject child_note = Object.Instantiate(_parent_note) as GameObject;
			NotesObject clone = child_note.GetComponent<NotesObject>();
			clone.name = "Notes_child";
			clone.transform.parent = _clone_objects.transform;
			clone.transform.position = position;
		}

		// 読み込まれたデータの秒数に達成したときにノートを生成する
		private int _score_position;
		private float _start_timer;
		private void spawnNotes()
		{
			if (_score_timing[_score_position] - NotesDefine.SPAWN_DELAY_TIME < Time.time - _start_timer) {
				Vector2 spawn_position = NotesDefine.SPAWN_POSITION[_score_line[_score_position]-1];
				createNoteObject(spawn_position);
				_score_position++;
			}
		}



		// ====================
		// original
		// ====================

		// 譜面情報を保存しているCSVを読み込む
		private float[] _score_timing;
		private int[] _score_line;
		private void loadScoredataCsv()
		{
			// CSVをリーダーに読み込む
			StreamReader stream = new StreamReader("Assets/Scores/sample.csv");
			string stream_data = stream.ReadToEnd();
			StringReader reader = new StringReader(stream_data);
			// 1行ずつ読み込み、譜面データを生成していく
			int i = 0;
			while (reader.Peek() > -1) {
				string line = reader.ReadLine();
				string[] datas = line.Split(',');
				for (int j = 0; j < datas.Length; j++) {
					_score_timing[i] = float.Parse(datas[0]);
					_score_line[i] = int.Parse(datas[1]);
				}
				i++;
			}
		}
	}
}