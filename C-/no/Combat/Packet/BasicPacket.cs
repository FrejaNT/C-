using CombatPacket;
using IEntity;

namespace BPacket {
    public class BasicPacket : ICombatPacket {
        List<Entity> left;
        List<Entity> right;
        LinkedList<string> log;
        public BasicPacket (List<Entity> left, List<Entity> right) {
            this.left = left;
            this.right = right;
            log = new LinkedList<string>();
        }


        public void writeLog (string line) {
            log.AddLast(line);
        }
        public void clearLog () {
            log.Clear();
        }

        public void update(List<Entity> left, List<Entity> right){
            this.left = left;
            this.right = right;
        }
    }
}