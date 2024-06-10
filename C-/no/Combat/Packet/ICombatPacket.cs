
using BPacket;
using IEntity;

namespace CombatPacket {
    public interface ICombatPacket {
        public void writeLog (Entity actor, Entity Target, string line);
        public void writeLog (Entity actor, string line);
        public void clearLog ();
        public LinkedList<EventPacket> getLog (); // BADD
        public void update (List<Entity> left, List<Entity> right);
    }
}