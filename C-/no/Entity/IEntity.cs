namespace IEntity {
    public interface Entity {
        string name {get;}
        int maxHealth {get; set;}
        int speed {get; set;}
        int attackValue {get; set;}
    }
}