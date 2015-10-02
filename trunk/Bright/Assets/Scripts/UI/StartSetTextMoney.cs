using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// Startイベント時にお金をテキストに設定するコンポーネント.
	/// </summary>
	public class StartSetTextMoney : MonoBehaviour
	{
		[SerializeField]
		private Text target;

		[SerializeField]
		private string key;

		void Start()
		{
			this.target.text = StringAsset.Format(this.key, PlayerStatus.Instance.Wallet.Money);
		}

	}
}
