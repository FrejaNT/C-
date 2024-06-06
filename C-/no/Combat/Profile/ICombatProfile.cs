namespace ICombatProfile {
    public interface Profile {
        string name {get;}
        int health {get; set;}
        int speed {get; set;}
        int attackValue {get; set;}
    }
}