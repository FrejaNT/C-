
using IEntity;

namespace CombatPacket {
    public interface ICombatPacket {
        public void writeLog (string line);
        public void clearLog ();
        public void update (List<Entity> left, List<Entity> right);
    }
}