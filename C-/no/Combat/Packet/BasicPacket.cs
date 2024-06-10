using System.Runtime;
using CombatPacket;
using IEntity;

namespace BPacket {
    public class BasicPacket : ICombatPacket {
        public List<Entity> left {get; set;}
        public List<Entity> right {get; set;}
        public LinkedList<EventPacket> log {get; set;}

        public BasicPacket (List<Entity> left, List<Entity> right) {
            this.left = left;
            this.right = right;
            log = new LinkedList<EventPacket>();
        }

        public void writeLog (Entity actor, Entity target, string line) {
            log.AddLast(new EventPacket(actor, target, line));
        }
        public void writeLog (Entity actor, string line) {
            writeDeath(actor, line);
        }
        private void writeDeath (Entity actor, string line) {
            log.AddLast(new EventPacket(actor, true, line));
        }
        public void clearLog () {
            log.Clear();
        }
        public LinkedList<EventPacket> getLog () {
            return log;
        }
        public void update(List<Entity> left, List<Entity> right){
            this.left = left;
            this.right = right;
        }
    }
    public class EventPacket {
        public Entity Actor {get; set;}
        public Entity? Target {get; set;}
        public string Line {get; set;}
        public bool dead;

        public EventPacket (Entity actor, Entity target, string line) {
            Actor = actor;
            Target = target;
            Line = line;
            dead = false;
        }
        public EventPacket(Entity actor, bool dead, string line) {
            Actor = actor;
            Target = null;
            Line = line;
            this.dead = dead;
        }
    }
}