using CombatEvent;
using ICombatProfile;
using EventBasicAttack;
using CombatPacket;
using IEntity;
using Enemy;


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
        private ICombatPacket packet;
        Random rnd;
        
        public ICombatEvent attack;
        public ECProfile (string name, int health, int speed , int attackValue, ICombatPacket packet) {
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.attackValue = attackValue;
            this.packet = packet;
            attack = new BasicAttack();
            rnd = new Random();
        }
        public void applyTurn (List<IProfile> friendlyTargets, List<IProfile> enemyTargets) {
            int targetIndex = rnd.Next(0, enemyTargets.Count);
            attack.activate(this, enemyTargets[targetIndex], packet);
        }

        public Entity toEntity() {
            return new EChar(name, health, speed, attackValue);
        }
    }
}