using Microsoft.Xna.Framework;
using ThreeDWindowsGameLibrary.Simulation;

namespace GameLogicLibrary.Simulation
{
	public class GameEntity : Entity
	{
		public GameEntity(string name, Vector3 scale)
			: base(name, scale)
		{

		}
		
		public override Vector3 Position
		{
			get; set;
		}

		public override Matrix Rotation
		{
			get;
			set;
		}
	}
}
