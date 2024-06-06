using IEntity;

namespace PC {
    public class PChar : Entity {
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
        
        public PChar (string name, int maxHealth, int speed , int attackValue) {
            this.name = name;
            this.maxHealth = maxHealth;
            this.speed = speed;
            this.attackValue = attackValue;
        }
        
    }
}