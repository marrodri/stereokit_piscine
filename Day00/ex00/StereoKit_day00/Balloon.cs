using System;
using System.Collections.Generic;
using System.Text;
using StereoKit;

namespace StereoKit_day00
{
	class Balloon
	{
		public float balloonAir;
		bool gameStarted = false;
		float blowEnergy = 0.0f;
		public void Steps(Hand right_hand)
		{
			//right_hand

			if (right_hand.IsPinched && blowEnergy < 100)
			{
				//StereoKitApp.Quit();
				balloonAir += 0.007f;
				blowEnergy += 1;
				//BlowBalloon();
				gameStarted = true;
			}
			else if(gameStarted)
			{
				balloonAir -= 0.008f;
				if(!right_hand.IsPinched && blowEnergy > 0)
					blowEnergy -= 2;
			}
		}

		public bool GetGameStarted()
		{
			return gameStarted;
		}

		public Balloon(float air)
		{
			balloonAir = air;
		}
		void CreateBalloon()
		{
			/*
			** the mesh is a single collection of triangular faces with the surface
			** information that forms the visible object, they are combined with 
			** materials or added to models in order to draw them; 
			*/

			Mesh balloonMesh = Mesh.GenerateSphere(balloonAir);

			/*
			** Model is a collection of meshes, materials, and transforms that make up
			** a visual element by group together complex objects that have multiple
			** parts in.
			*/

			/*
			** the fromMesh will create a single mesh subset using the indicated Mesh and
			** material. An id will be generated right away for this asset
			*/

			Model balloonModel = Model.FromMesh(balloonMesh, Default.Material);
		}
		public void DrawBalloon()
		{
			Mesh balloonMesh = Mesh.GenerateSphere(balloonAir);
			Model balloonModel = Model.FromMesh(balloonMesh, Default.Material);
			balloonModel.Draw(Matrix.TS(Vec3.Zero, 0.1f));
		}
	}
}
