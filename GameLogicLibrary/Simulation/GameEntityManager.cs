using System.Collections.Generic;
using SpaceFortress2;

namespace GameLogicLibrary.Simulation
{
	public class GameEntityManager
	{
		private List<GameEntity> _entities = new List<GameEntity>();

		public List<GameEntity> Entities
		{
			get
			{
				return _entities;
			}
		}

		public void AddEntity(GameEntity entity)
		{
			_entities.Add(entity);

			if (entity is PhysicsGameEntity)
			{
				PhysicsGameEntity rbe = (PhysicsGameEntity)entity;
				GameStateManager.GameManager.World.AddBody(rbe.Body);
			}
		}

		public void RemoveEntity(GameEntity entity)
		{
			if (Entities.Contains(entity))
				Entities.Remove(entity);
		}
	}
}
