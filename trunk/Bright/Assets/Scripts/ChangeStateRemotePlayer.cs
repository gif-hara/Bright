using UnityEngine;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// リモートプレイヤーのステートを切り替えるコンポーネント.
	/// </summary>
	public class ChangeStateRemotePlayer : MonoBehaviour
	{
		private SyncPlayerData syncPlayerData;

		private PlayerStateSwitcher playerStateSwitcher;

		void Start()
		{
			this.syncPlayerData = GetComponent<SyncPlayerData>();
			this.playerStateSwitcher = GetComponent<PlayerStateSwitcher>();
		}

		void Update()
		{
			this.playerStateSwitcher.Change(this.syncPlayerData.StateType);
		}
	}
}