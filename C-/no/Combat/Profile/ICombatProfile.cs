using IEntity;

namespace ICombatProfile {
    public interface IProfile {
        string name {get;}
        int health {get; set;}
        int speed {get; set;}
        int attackValue {get; set;}

        void applyTurn (List<IProfile> friendlyTargets, List<IProfile> enemyTargets);

        public Entity toEntity();
    }
}