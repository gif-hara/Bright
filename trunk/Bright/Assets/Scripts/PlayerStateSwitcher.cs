using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// プレイヤーのステートを切り替えるコンポーネント.
	/// </summary>
	public class PlayerStateSwitcher : MonoBehaviour
	{
		[SerializeField]
		private StateManager refStateManager;

		[SerializeField]
		private List<GameObject> stateObjects;

		public void Change(GameDefine.StateType stateType)
		{
			this.refStateManager.Change(this.stateObjects[(int)stateType]);
		}
	}
}