using CombatEvent;
using CombatPacket;
using ICombatProfile;

namespace EventBasicAttack{
    public class BasicAttack : ICombatEvent
    {

        public BasicAttack() {
        }
        public void activate(IProfile actor, IProfile target, ICombatPacket packet){
            target.health -= actor.attackValue;
            packet.writeLog(actor.name + " attacks " + target + " for " + actor.attackValue + "!");
        }

        public void activate(IProfile actor, List<IProfile> targets, ICombatPacket packet)
        {
            throw new NotImplementedException();
        }
    }
}