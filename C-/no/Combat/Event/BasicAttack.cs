using CombatEvent;
using ICombatProfile;

namespace EventBasicAttack{
    public class BasicAttack : ICombatEvent
    {

        public BasicAttack() {
        }
        public void activate(IProfile actor, IProfile target){
            target.health -= actor.attackValue;
        }

        public void activate(IProfile actor, List<IProfile> targets)
        {
            throw new NotImplementedException();
        }
    }
}