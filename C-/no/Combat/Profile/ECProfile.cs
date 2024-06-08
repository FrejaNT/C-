using CombatEvent;
using ICombatProfile;
using EventBasicAttack;


namespace EnemyProfile {
    public class ECProfile : IProfile {
        public string name {get;}
        public int health {
            get => health;
            set => health = value;
        }
        public int speed {
            get => speed;
            set => speed = value;
        }
        public int attackValue {
            get => attackValue;
            set => attackValue = value;
        }
        Random rnd;
        
        public ICombatEvent attack;
        public ECProfile (string name, int health, int speed , int attackValue) {
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.attackValue = attackValue;
            attack = new BasicAttack();
            rnd = new Random();
        }
        public void applyTurn (List<IProfile> friendlyTargets, List<IProfile> enemyTargets) {
            int targetIndex = rnd.Next(0, enemyTargets.Count);
            attack.activate(this, enemyTargets[targetIndex]);
        }
    }
}