using IEntity;

namespace Enemy {
    public class EChar : Entity {
        public string name {get;}

        public int maxHealth {
            get => maxHealth;
            set => maxHealth = value;
        }
        public int speed {
            get => speed;
            set => speed = value;
        }
        public int attackValue {
            get => attackValue;
            set => attackValue = value;
        }

        public EChar (string name, int maxHealth, int attackValue) {
            this.name = name;
            this.maxHealth = maxHealth;
            this.attackValue = attackValue;
        }
        
    }
}