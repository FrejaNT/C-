using CombatPacket;
using ICombatProfile;
using IEntity;
using TL;

namespace CombatMain {
    // Handles overall combat logic, manages and updates combat profiles.
    // Also produces combat packets.
    public class CombatEngine {
        private List<IProfile> left;
        private List<IProfile> right;
        public ICombatPacket packet {get; set;}
        private TurnList turnList;

        public CombatEngine (List<IProfile> left, List<IProfile> right, ICombatPacket packet){
            this.left = left;
            this.right = right;
            this.packet = packet;
            turnList = new TurnList(left[0], left[0].speed, true);

            foreach (IProfile p in left) turnList.Add(p, p.speed, true);
            foreach (IProfile p in right) turnList.Add(p, p.speed, false);
        }

        public bool startTurn () {
            if (left.Count() == 0 && right.Count() == 0) return false;
            packet.clearLog();
            turnList.activateEvents(left, right);
            List<Entity> eLeft = new List<Entity>();
            List<Entity> eRight = new List<Entity>(); 
            foreach (IProfile p in left) {
                Entity pe = p.toEntity();
                if (p.health <= 0) {
                    left.Remove(p);
                    turnList.Delete(p);
                    packet.writeLog(pe, p.name + " has died!");
                } else {
                eLeft.Add(pe);
                }
            }
            foreach (IProfile p in right) {
                if (p.health <= 0) {
                    right.Remove(p);
                    turnList.Delete(p);
                } else {
                    eRight.Add(p.toEntity());
                }
            }
            return true;
        }

    }
}