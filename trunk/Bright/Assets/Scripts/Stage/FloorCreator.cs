using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 床を生成するクラス.
	/// </summary>
	public class FloorCreator
	{
		private StageManager stageManager;

		private int y;

		private int initialY;

		/// <summary>
		/// Y座標変更処理を行うか.
		/// </summary>
		private bool calculateFixedY;

		private int continuity;

		private int blank;

		/// <summary>
		/// Y座標の変更可能範囲.
		/// </summary>
		private int RangeY = 3;

		public FloorCreator(StageManager stageManager, int y)
		{
			this.stageManager = stageManager;
			this.y = Random.Range(y - RangeY, y + RangeY + 1);
			this.y = this.y < 1 ? 1 : this.y;
			this.initialY = y;

			this.continuity = Random.Range(6, 10);
			this.blank = Random.Range(0, 4);
		}

		/// <summary>
		/// 生成・自分自身の死亡処理・宝箱の配置・敵の配置を行う.
		/// </summary>
		/// <param name="chunkSize">Chunk size.</param>
		public void Calculate(int chunkSize)
		{
			for(int x=0; x<chunkSize; x++)
			{
				if(this.continuity > 0)
				{
					this.stageManager.CmdCreateBlock(this.stageManager.BlockPrefab, x, y);
					this.continuity--;
					this.UpdateY(0.2f);
				}
				else if(this.blank > 0)
				{
					this.blank--;
				}
				else
				{
					this.UpdateY(1.0f);
					this.continuity = Random.Range(3, 7);
					this.blank = Random.Range(0, 4);
				}
			}
		}

		private void UpdateY(float probability)
		{
			if(Random.value > probability)
			{
				return;
			}

			this.y += Random.Range(-3, 4);
			this.y = this.y < 1 ? 1 : this.y;

			var max = (this.initialY + RangeY);
			var min = (this.initialY - RangeY);
			this.y = this.y >= max ? max : this.y;
			this.y = this.y <= min ? min : this.y;
			this.calculateFixedY = false;
		}
	}
}
