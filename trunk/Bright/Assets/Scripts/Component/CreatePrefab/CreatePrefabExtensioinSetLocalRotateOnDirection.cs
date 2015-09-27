using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 向きによって生成するプレハブを設定するコンポーネント.
	/// </summary>
	public class CreatePrefabExtensioinSetLocalRotateOnDirection : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Vector3 leftDirection;

		[SerializeField]
		private Vector3 rightDirection;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			var direction = this.transform.lossyScale.x > 0.0f ? this.rightDirection : this.leftDirection;
			instance.transform.localRotation = Quaternion.Euler(direction);
		}
	}
}
