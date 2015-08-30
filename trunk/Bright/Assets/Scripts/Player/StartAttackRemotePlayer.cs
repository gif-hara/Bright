using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// リモートプレイヤーの攻撃開始処理を行うコンポーネント.
	/// </summary>
	public class StartAttackRemotePlayer : MonoBehaviour, IReceiveChangeStateRemotePlayer
	{
		private ExecuteOnStartAttack executeOnStartAttack;

		void Start()
		{
			this.executeOnStartAttack = GetComponent<ExecuteOnStartAttack>();
		}

		public void OnChangeStateRemotePlayer(GameDefine.StateType stateType)
		{
			if(stateType != GameDefine.StateType.Attack)
			{
				return;
			}

			this.executeOnStartAttack.Execute();
		}
	}
}
