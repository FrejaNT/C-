using ICombatProfile;
using CombatPacket;

namespace CombatEvent{
    public interface ICombatEvent {
        public void activate (IProfile actor, IProfile target, ICombatPacket packet);
        public void activate (IProfile actor, List<IProfile> targets, ICombatPacket packet);
    }
}