namespace ICombatProfile {
    public interface IProfile {
        string name {get;}
        int health {get; set;}
        int speed {get; set;}
        int attackValue {get; set;}
    }
}