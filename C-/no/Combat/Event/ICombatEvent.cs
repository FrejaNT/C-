using ICombatProfile;

namespace CombatEvent{
    public interface ICombatEvent {
        public void activate (IProfile actor, IProfile target);
        public void activate (IProfile actor, List<IProfile> targets);
    }
}