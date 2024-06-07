using ICombatProfile;

namespace PCProfile {
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
        
        public PCProfile (string name, int health, int speed , int attackValue) {
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.attackValue = attackValue;
        }
    }
}