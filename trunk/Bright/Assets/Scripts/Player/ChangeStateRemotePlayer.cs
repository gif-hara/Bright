using UnityEngine;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// リモートプレイヤーのステートを切り替えるコンポーネント.
	/// </summary>
	public class ChangeStateRemotePlayer : MonoBehaviour, IReceiveChangeStateRemotePlayer
	{
		private PlayerStateSwitcher playerStateSwitcher;

		public void OnChangeStateRemotePlayer(GameDefine.StateType stateType)
		{
			this.playerStateSwitcher.Change(stateType);
		}

		void Start()
		{
			this.playerStateSwitcher = GetComponent<PlayerStateSwitcher>();
		}
	}
}