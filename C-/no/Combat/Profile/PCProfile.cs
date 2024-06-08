using ICombatProfile;
using CombatEvent;
using EventBasicAttack;
using CombatPacket;
using IEntity;
using PC;


namespace PlayerProfile {
    public class PCProfile : IProfile {
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
        public PCProfile (string name, int health, int speed , int attackValue, ICombatPacket packet) {
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
            return new PChar(name, health, speed, attackValue);
        }
    }
}